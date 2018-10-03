namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPModificationsForTT295TT394 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
ALTER PROCEDURE [dbo].[return_track_report_images] 
	@quote_auto INT,
	@position VARCHAR(1)
AS
BEGIN


	SET NOCOUNT ON;
	DECLARE @pos INT
	DECLARE @InspectedSide int
	SELECT @pos = CASE @position WHEN 'L' THEN 3 ELSE 4 END

	SELECT @InspectedSide = CASE @position WHEN 'L' THEN 1 ELSE 2 END 


	DECLARE @side INT
	SELECT @side = CASE @position WHEN 'L' THEN 1 ELSE 2 END

	IF (SELECT COUNT(*)	FROM  TRACK_QUOTE tq

			LEFT JOIN TRACK_INSPECTION ti on tq.inspection_auto = ti.inspection_auto
			LEFT JOIN TRACK_INSPECTION_DETAIL tid on ti.inspection_auto = tid.inspection_auto 
			LEFT JOIN InspectionDetails_Side tidSide ON tid.inspection_detail_auto = tidSide.InspectionDetailsId
			LEFT JOIN TRACK_INSPECTION_IMAGES tdimg on tdimg.inspection_detail_auto = tid.inspection_detail_auto
			--LEFT JOIN GENERAL_EQ_UNIT geu on ti.equipmentid_auto = geu.equipmentid_auto and geu.equnit_auto = tid.track_unit_auto AND geu.compartid_auto = tii.compartid_auto 
		WHERE tq.quote_auto = @quote_auto AND tidSide.Side = @InspectedSide
		) > 0

	BEGIN

		SELECT DISTINCT idimg.guid AS ID, CAST(lct.sorder as varchar) +  @position+':'+ cast(geu.pos as varchar)+':' + lc.compart AS [Component], idimg.image_data AS [Data], 
		(CASE WHEN idimg.image_comment IS NULL AND tid.comments IS NOT NULL THEN tid.comments 		
		WHEN idimg.image_comment IS NOT NULL and tid.comments IS NULL THEN idimg.image_comment
		WHEN idimg.image_comment IS NOT NULL and tid.comments IS NOT NULL THEN idimg.image_comment + ' ' + tid.comments END)
		 AS [ImageComments],lct.sorder
		FROM  TRACK_QUOTE tq
			LEFT JOIN TRACK_INSPECTION ti on tq.inspection_auto = ti.inspection_auto
			LEFT JOIN TRACK_INSPECTION_DETAIL tid on ti.inspection_auto = tid.inspection_auto 
			LEFT JOIN InspectionDetails_Side tidSide ON tid.inspection_detail_auto = tidSide.InspectionDetailsId
			LEFT JOIN GENERAL_EQ_UNIT geu on tid.track_unit_auto = geu.equnit_auto
			left JOIN LU_COMPART lc ON lc.compartid_auto = geu.compartid_auto
			INNER JOIN LU_COMPART_TYPE lct ON lct.comparttype_auto = lc.comparttype_auto
			LEFT JOIN TRACK_INSPECTION_IMAGES idimg ON tid.inspection_detail_auto = idimg.InspectionDetailId
		
		WHERE tq.quote_auto = @quote_auto AND tidSide.Side = @InspectedSide  AND ((idimg.image_data IS NOT NULL) OR (tid.comments IS NOT NULL))
		order BY lct.sorder asc

	END
	ELSE
	BEGIN
		SELECT DISTINCT NEWID()  AS ID, CAST(lct.sorder as varchar) +  @position +':'+ cast(geu.pos as varchar)+':' + comp.compart AS [Component], NULL AS [Data], tid.comments AS [ImageComments],lct.sorder
		FROM  TRACK_QUOTE tq
			INNER JOIN TRACK_INSPECTION ti on tq.inspection_auto = ti.inspection_auto
			INNER JOIN TRACK_INSPECTION_DETAIL tid on ti.inspection_auto = tid.inspection_auto 
			INNER JOIN GENERAL_EQ_UNIT geu on ti.equipmentid_auto = geu.equipmentid_auto and geu.equnit_auto = tid.track_unit_auto 
			INNER JOIN LU_COMPART comp ON geu.compartid_auto = comp.compartid_auto 
			INNER JOIN LU_COMPART_TYPE lct ON lct.comparttype_auto = comp.comparttype_auto
		WHERE tq.quote_auto = @quote_auto AND geu.side = @side AND tid.comments <> '' AND tid.comments IS NOT NULL
		ORDER BY Component ASC
	END
END
");

            Sql(@"

ALTER PROCEDURE [dbo].[SaveInspectionForNewEquipment] 
	@inspection_auto	INT = NULL OUTPUT, --inspection_auto
	@equipmentid		BIGINT,				--equipmentid_auto 
	@smu				BIGINT,				--smu_at_install	
	@tracksagleft		DECIMAL,			
	@tracksagright		DECIMAL,
	@dryjointleft		DECIMAL,
	@dryjointright		DECIMAL,
	@extcannonleft		DECIMAL,
	@extcannonright		DECIMAL,
	@impact				SMALLINT,
	@abrasive			SMALLINT,
	@moisture			SMALLINT,
	@packing			SMALLINT,
	@inspectioncomments	VARCHAR(200),
	@jobsitecomments	VARCHAR(200),
	@createdDate	DATETIME,			--created_date
	@createdUser	VARCHAR(50),		--created_user
	
	@leftTrackSagComment VARCHAR(max),			
	@rightTrackSagComment VARCHAR(max),
	@leftCannonExtComment VARCHAR(max),
	@rightCannonExtComment VARCHAR(max),
	@leftTrackSagImage VARBINARY(max),			
	@rightTrackSagImage VARBINARY(max),
	@leftCannonExtImage VARBINARY(max),
	@rightCannonExtImage VARBINARY(max)

AS
BEGIN
	
	INSERT INTO Mbl_Track_Inspection(equipmentid_auto,		--EquipmentID
									examiner,				--Examiner
									inspection_date,		--Date
									smu,					--SMU
									track_sag_left,			--Track Sag Left
									track_sag_right,		--Track Sag Right
									dry_joints_left,		--Dry Joints Left
									dry_joints_right,		--Dry Joints Right
									ext_cannon_left,		--Ext Cannon Left
									ext_cannon_right,		--Ext Cannon Right
									impact,					--Impact
									abrasive,				--Abrasive
									moisture,				--Moisture
									packing,				--Packing
									created_date,			--Created Date (Examinier)
									created_user,			--Date
									inspection_comments,	--Inspection Comments
									Jobsite_Comms,			--Jobsite Comments
									LeftTrackSagComment,
									RightTrackSagComment,
									LeftCannonExtensionComment,
									RightCannonExtensionComment,
									LeftTrackSagImage,
									RightTrackSagImage,
									LeftCannonExtensionImage,
									RightCannonExtensionImage)
	VALUES(@equipmentid,@createdUser,@createdDate,@smu,@tracksagleft,@tracksagright,@dryjointleft,@dryjointright,@extcannonleft,@extcannonright,@impact,@abrasive,@moisture,@packing,@createdDate,@createdUser,@inspectioncomments,@jobsitecomments,	@leftTrackSagComment,			
	@rightTrackSagComment,
	@leftCannonExtComment,
	@rightCannonExtComment,
	@leftTrackSagImage,			
	@rightTrackSagImage,
	@leftCannonExtImage,
	@rightCannonExtImage)

	SET @inspection_auto = CAST(SCOPE_IDENTITY() AS [int])
END


");
        }
        
        public override void Down()
        {

            Sql(@"
ALTER PROCEDURE [dbo].[SaveInspectionForNewEquipment] 
	@inspection_auto	INT = NULL OUTPUT, --inspection_auto
	@equipmentid		BIGINT,				--equipmentid_auto 
	@smu				BIGINT,				--smu_at_install	
	@tracksagleft		DECIMAL,			
	@tracksagright		DECIMAL,
	@dryjointleft		DECIMAL,
	@dryjointright		DECIMAL,
	@extcannonleft		DECIMAL,
	@extcannonright		DECIMAL,
	@impact				SMALLINT,
	@abrasive			SMALLINT,
	@moisture			SMALLINT,
	@packing			SMALLINT,
	@inspectioncomments	VARCHAR(200),
	@jobsitecomments	VARCHAR(200),
	@createdDate	DATETIME,			--created_date
	@createdUser	VARCHAR(50)			--created_user

AS
BEGIN
	
	INSERT INTO Mbl_Track_Inspection(equipmentid_auto,		--EquipmentID
									examiner,				--Examiner
									inspection_date,		--Date
									smu,					--SMU
									track_sag_left,			--Track Sag Left
									track_sag_right,		--Track Sag Right
									dry_joints_left,		--Dry Joints Left
									dry_joints_right,		--Dry Joints Right
									ext_cannon_left,		--Ext Cannon Left
									ext_cannon_right,		--Ext Cannon Right
									impact,					--Impact
									abrasive,				--Abrasive
									moisture,				--Moisture
									packing,				--Packing
									created_date,			--Created Date (Examinier)
									created_user,			--Date
									inspection_comments,	--Inspection Comments
									Jobsite_Comms)			--Jobsite Comments
	VALUES(@equipmentid,@createdUser,@createdDate,@smu,@tracksagleft,@tracksagright,@dryjointleft,@dryjointright,@extcannonleft,@extcannonright,@impact,@abrasive,@moisture,@packing,@createdDate,@createdUser,@inspectioncomments,@jobsitecomments)

	SET @inspection_auto = CAST(SCOPE_IDENTITY() AS [int])
END


");

        }
    }
}
