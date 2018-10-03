namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrackSparesReportStoredProc : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE [dbo].[return_track_report_images_trackspares] 
	@quote_auto INT,
	@position VARCHAR(1)
AS
BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @pos INT
	SELECT @pos = CASE @position WHEN 'L' THEN 3 ELSE 4 END

	--SELECT TOP 4 guid AS ID, @position+':'+ cast(tii.position as varchar)+':' + comp.compart AS [Component], tii.attachment AS [Data], tii.comment AS [ImageComments]
	--FROM  TRACK_QUOTE tq
	--	INNER JOIN COMPART_ATTACH_FILESTREAM tii ON tii.inspection_auto = tq.inspection_auto
	--	INNER JOIN LU_COMPART comp ON tii.compartid_auto = comp.compartid_auto
	--WHERE tq.quote_auto = @quote_auto AND tii.compart_attach_type_auto = @pos

	DECLARE @side INT
	SELECT @side = CASE @position WHEN 'L' THEN 1 ELSE 2 END

	IF (SELECT COUNT(*)	FROM  TRACK_QUOTE tq
			INNER JOIN COMPART_ATTACH_FILESTREAM tii ON tii.inspection_auto = tq.inspection_auto
			INNER JOIN LU_COMPART comp ON tii.compartid_auto = comp.compartid_auto
			--PRN100039
			LEFT JOIN TRACK_INSPECTION ti on tq.inspection_auto = ti.inspection_auto
			LEFT JOIN TRACK_INSPECTION_DETAIL tid on ti.inspection_auto = tid.inspection_auto 
			LEFT JOIN GENERAL_EQ_UNIT geu on ti.equipmentid_auto = geu.equipmentid_auto and geu.equnit_auto = tid.track_unit_auto AND geu.compartid_auto = tii.compartid_auto 
		WHERE tq.quote_auto = @quote_auto AND tii.compart_attach_type_auto = @pos AND geu.side = @side
		) > 0

	BEGIN

		--SELECT DISTINCT TOP 4 guid AS ID, @position+':'+ cast(tii.position as varchar)+':' + comp.compart AS [Component], tii.attachment AS [Data], tii.comment + ' ' + tid.comments AS [ImageComments]
		SELECT DISTINCT guid AS ID, CAST(lct.sorder as varchar) +  @position+':'+ cast(tii.position as varchar)+':' + comp.compart AS [Component], tii.attachment AS [Data], tii.comment + ' ' + tid.comments AS [ImageComments],lct.sorder
		FROM  TRACK_QUOTE tq
			INNER JOIN COMPART_ATTACH_FILESTREAM tii ON tii.inspection_auto = tq.inspection_auto
			INNER JOIN LU_COMPART comp ON tii.compartid_auto = comp.compartid_auto
			--PRN100039
			LEFT JOIN TRACK_INSPECTION ti on tq.inspection_auto = ti.inspection_auto
			LEFT JOIN TRACK_INSPECTION_DETAIL tid on ti.inspection_auto = tid.inspection_auto 
			LEFT JOIN GENERAL_EQ_UNIT geu on ti.equipmentid_auto = geu.equipmentid_auto and geu.equnit_auto = tid.track_unit_auto AND geu.compartid_auto = tii.compartid_auto AND geu.pos = tii.position
			INNER JOIN LU_COMPART_TYPE lct ON lct.comparttype_auto = comp.comparttype_auto
		
		WHERE tq.quote_auto = @quote_auto AND tii.compart_attach_type_auto = @pos AND geu.side = @side 

		UNION

		SELECT DISTINCT NEWID()  AS ID, CAST(lct.sorder as varchar) +  @position +':'+ cast(geu.pos as varchar)+':' + comp.compart AS [Component], NULL AS [Data], tid.comments AS [ImageComments],lct.sorder
		FROM  TRACK_QUOTE tq
			INNER JOIN TRACK_INSPECTION ti on tq.inspection_auto = ti.inspection_auto
			INNER JOIN TRACK_INSPECTION_DETAIL tid on ti.inspection_auto = tid.inspection_auto 
			INNER JOIN GENERAL_EQ_UNIT geu on ti.equipmentid_auto = geu.equipmentid_auto and geu.equnit_auto = tid.track_unit_auto 
			INNER JOIN LU_COMPART comp ON geu.compartid_auto = comp.compartid_auto 
			INNER JOIN LU_COMPART_TYPE lct ON lct.comparttype_auto = comp.comparttype_auto
		WHERE tq.quote_auto = @quote_auto AND geu.side = @side AND tid.comments <> '' AND tid.comments IS NOT NULL
		AND comp.compartid_auto NOT IN (SELECT compartid_auto FROM COMPART_ATTACH_FILESTREAM WHERE inspection_auto = ti.inspection_auto)
		ORDER BY  Component asc
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
        }
        
        public override void Down()
        {
        }
    }
}
