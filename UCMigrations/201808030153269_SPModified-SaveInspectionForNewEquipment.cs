namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPModifiedSaveInspectionForNewEquipment : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
	@rightCannonExtImage VARBINARY(max),
	@travelForward		INT,
	@travelReverse		INT,
	@leftScallop		DECIMAL,
	@rightScallop		DECIMAL,
	@travelledKms BIT
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
									RightCannonExtensionImage,
									ForwardTravelHours,
									ReverseTravelHours,
									LeftScallopMeasurement,
									RightScallopMeasurement, TravelledKms)
	VALUES(@equipmentid,@createdUser,@createdDate,@smu,@tracksagleft,@tracksagright,@dryjointleft,@dryjointright,@extcannonleft,@extcannonright,@impact,@abrasive,@moisture,@packing,@createdDate,@createdUser,@inspectioncomments,@jobsitecomments,	@leftTrackSagComment,			
	@rightTrackSagComment,
	@leftCannonExtComment,
	@rightCannonExtComment,
	@leftTrackSagImage,			
	@rightTrackSagImage,
	@leftCannonExtImage,
	@rightCannonExtImage, 
	@travelForward,
	@travelReverse,
	@leftScallop,
	@rightScallop,
	@travelledKms)

	SET @inspection_auto = CAST(SCOPE_IDENTITY() AS [int])
END

");
        }
        
        public override void Down()
        {
            Sql(@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


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
	@rightCannonExtImage VARBINARY(max),
	@travelForward		INT,
	@travelReverse		INT,
	@leftScallop		DECIMAL,
	@rightScallop		DECIMAL

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
									RightCannonExtensionImage,
									ForwardTravelHours,
									ReverseTravelHours,
									LeftScallopMeasurement,
									RightScallopMeasurement)
	VALUES(@equipmentid,@createdUser,@createdDate,@smu,@tracksagleft,@tracksagright,@dryjointleft,@dryjointright,@extcannonleft,@extcannonright,@impact,@abrasive,@moisture,@packing,@createdDate,@createdUser,@inspectioncomments,@jobsitecomments,	@leftTrackSagComment,			
	@rightTrackSagComment,
	@leftCannonExtComment,
	@rightCannonExtComment,
	@leftTrackSagImage,			
	@rightTrackSagImage,
	@leftCannonExtImage,
	@rightCannonExtImage, 
	@travelForward,
	@travelReverse,
	@leftScallop,
	@rightScallop)

	SET @inspection_auto = CAST(SCOPE_IDENTITY() AS [int])
END

");
        }
    }
}
