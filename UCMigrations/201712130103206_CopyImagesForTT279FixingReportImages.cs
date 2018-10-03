namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CopyImagesForTT279FixingReportImages : DbMigration
    {
        public override void Up()
        {
            //Sql(script);
            /*
             * Commented out because this script execution takes too long and it is not possible to update database with migration
             * It needs to be done manually.
             * */
        }
        
        public override void Down()
        {
        }

        string script = @"
-- Description:
-- Images had been stored in the COMPART_ATTACH_FILESTREAM Table which was WRONG and I fixed it in a ticket previously
-- TT-279 is for copying existing images to the right table wich is TRACK_INSPECTION_DETAIL
-- This script does that!
-- Run once only to copy images from COMPART_ATTACH_FILESTREAM to the TRACK_INSPECTION_DETAIL 
-- It is safe if you run more than once though!

-- Mason 13 Dec 2017 
-- Thanks

DECLARE @CountedTid int
DECLARE @CountedTidImg int
DECLARE @InspectionDetailId BIGINT
DECLARE @InspectionId BIGINT
DECLARE @Side INT
DECLARE @Attachment VARBINARY(MAX)
DECLARE @CompartId BIGINT
DECLARE @Pos INT
DECLARE @Comment NVARCHAR(2000)
DECLARE @GlobalUniqueId UNIQUEIDENTIFIER
	DECLARE inspectionCursor CURSOR FORWARD_ONLY FOR
	select inspection_auto, compart_attach_type_auto side, attachment, compartid_auto, position, comment, [guid] from COMPART_ATTACH_FILESTREAM
	OPEN inspectionCursor;
	FETCH NEXT FROM inspectionCursor INTO @InspectionId, @Side, @Attachment, @CompartId, @Pos, @Comment, @GlobalUniqueId
	WHILE @@FETCH_STATUS = 0 
	BEGIN

    set @CountedTid = (select COUNT(*) from TRACK_INSPECTION_DETAIL tid 
	inner JOIN GENERAL_EQ_UNIT geu ON geu.equnit_auto = tid.track_unit_auto
	inner JOIN InspectionDetails_Side tidSide ON tidSide.InspectionDetailsId = tid.inspection_detail_auto
	where tid.inspection_auto = @InspectionId and (tidSide.Side+2) = @Side and geu.compartid_auto = @CompartId and geu.pos = @Pos)

	IF (@CountedTid = 1)
	BEGIN 
	set @InspectionDetailId = (select tid.inspection_detail_auto from TRACK_INSPECTION_DETAIL tid 
	inner JOIN GENERAL_EQ_UNIT geu ON geu.equnit_auto = tid.track_unit_auto
	inner JOIN InspectionDetails_Side tidSide ON tidSide.InspectionDetailsId = tid.inspection_detail_auto
	where tid.inspection_auto = @InspectionId and (tidSide.Side+2) = @Side and geu.compartid_auto = @CompartId and geu.pos = @Pos)

	if((select COUNT(*) from TRACK_INSPECTION_IMAGES where InspectionDetailId = @InspectionDetailId) = 0)
	INSERT INTO TRACK_INSPECTION_IMAGES ([GUID], inspection_detail_auto, image_data, image_comment, InspectionDetailId) VALUES
	(@GlobalUniqueId, @InspectionDetailId, @Attachment, @Comment, @InspectionDetailId)


	END

	FETCH NEXT FROM inspectionCursor INTO @InspectionId, @Side, @Attachment, @CompartId, @Pos, @Comment, @GlobalUniqueId
	END
	CLOSE inspectionCursor;
	DEALLOCATE inspectionCursor;

";
    }
}
