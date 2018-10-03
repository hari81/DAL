namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TT2713SpsModified : DbMigration
    {
        public override void Up()
        {
            Sql(return_compart_attachment);
            Sql(return_track_report_images);
            Sql(store_compart_attachment);
        }
        
        public override void Down()
        {
            Sql(return_compart_attachment_down);
            Sql(return_track_report_images_down);
            Sql(store_compart_attachment_down);
        }

        string return_compart_attachment = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[return_compart_attachment]
@compart_attach_auto bigint = 0  , 
@compartid_auto bigint = 0 , 
@compart_attach_type_auto int = 0 ,
@inspection_auto int =0,
@comparttype_auto BIGINT =0,
@tool_auto INT = -1,
@position INT = 0,
@inspectionDetailId INT = 0
as
begin
-- Images had been stored in COMPART_ATTACH_FILESTREAM which was not correct!! So if there is an image for the inspection detail in the right table will be loaded otherwise will be loaded from the old table which may probably be the incorrect image
IF (@inspectionDetailId > 0 AND (select COUNT(*) from TRACK_INSPECTION_IMAGES where InspectionDetailId = @inspectionDetailId) > 0)
BEGIN
select ID compart_attach_auto, lc.compartid_auto, (CASE WHEN geu.side = 1 then 3 ELSE 4 END)  compart_attach_type_auto , geu.equnit_auto compart_attach_type_name, detailImage.ID attachment_name, detailImage.image_comment comment, detailImage.image_data attachment from TRACK_INSPECTION_IMAGES detailImage
inner JOIN TRACK_INSPECTION_DETAIL tid ON detailImage.InspectionDetailId = tid.inspection_detail_auto
inner JOIN GENERAL_EQ_UNIT geu ON geu.equnit_auto = tid.track_unit_auto
inner JOIN LU_COMPART lc ON geu.compartid_auto = lc.compartid_auto
where InspectionDetailId = @inspectionDetailId
END
ELSE
BEGIN
select compart_attach_auto , att.compartid_auto ,  att.compart_attach_type_auto , catype.compart_attach_type_name , att.attachment_name , att.comment, att.attachment  from COMPART_ATTACH_FILESTREAM  att 
inner join COMPART_ATTACH_TYPE catype on att.compart_attach_type_auto = catype.compart_attach_type_auto
where  (@compart_attach_auto = 0  or att.compart_attach_auto = @compart_attach_auto ) 
and ( @compartid_auto = 0 or  att.compartid_auto = @compartid_auto )   
and (@compart_attach_type_auto = 0 or att.compart_attach_type_auto = @compart_attach_type_auto )
and (@inspection_auto = 0 OR  att.inspection_auto = @inspection_auto )
AND (@comparttype_auto = 0 OR att.comparttype_auto = @comparttype_auto)
AND (@tool_auto = -1 OR att.tool_auto = @tool_auto)
AND (@position = 0 OR att.position = @position)
END

end 
";
        string return_track_report_images = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC return_track_report_images 298,'r'
-- =============================================
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

		SELECT DISTINCT idimg.guid AS ID, CAST(lct.sorder as varchar) +  @position+':'+ cast(geu.pos as varchar)+':' + lc.compart AS [Component], idimg.image_data AS [Data], idimg
		.image_comment + ' ' + tid.comments AS [ImageComments],lct.sorder
		FROM  TRACK_QUOTE tq
			LEFT JOIN TRACK_INSPECTION ti on tq.inspection_auto = ti.inspection_auto
			LEFT JOIN TRACK_INSPECTION_DETAIL tid on ti.inspection_auto = tid.inspection_auto 
			LEFT JOIN InspectionDetails_Side tidSide ON tid.inspection_detail_auto = tidSide.InspectionDetailsId
			inner JOIN TRACK_INSPECTION_IMAGES idimg ON tid.inspection_detail_auto = idimg.InspectionDetailId
			LEFT JOIN GENERAL_EQ_UNIT geu on tid.track_unit_auto = geu.equnit_auto
			left JOIN LU_COMPART lc ON lc.compartid_auto = geu.compartid_auto
			INNER JOIN LU_COMPART_TYPE lct ON lct.comparttype_auto = lc.comparttype_auto
		
		WHERE tq.quote_auto = @quote_auto AND tidSide.Side = @InspectedSide
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
";
        string store_compart_attachment = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[store_compart_attachment]
@compartid_auto bigint , 
@compart_attach_type_auto int ,
@attachment  VARBINARY(max) = null,
@file_name varchar(max) = null,
@created_date datetime = null ,
@created_user bigint = null,
@comments nvarchar(max) = null ,
@inspection_auto int = 0,
@comparttype_auto BIGINT = 0,
@tool_auto INT = 0,
@position INT = 0,
@inspectionDetailId INT = 0,
@result int output 
as 
begin

set @result = 0 ; 

begin try 

-- Changes to save compart images at CompartType level
DECLARE @ATTACH_TYPE NVARCHAR(50)
SELECT @ATTACH_TYPE = compart_attach_type_name FROM COMPART_ATTACH_TYPE WHERE compart_attach_type_auto = @compart_attach_type_auto

IF(@ATTACH_TYPE = 'comparttype_image')
BEGIN
	DELETE FROM COMPART_ATTACH_FILESTREAM WHERE comparttype_auto = @comparttype_auto AND compart_attach_type_auto = @compart_attach_type_auto AND position = @position
	INSERT INTO COMPART_ATTACH_FILESTREAM ([guid], compart_attach_type_auto, user_auto, entry_date, comment,attachment_name, attachment, comparttype_auto, position)
	VALUES (NEWID(), @compart_attach_type_auto , @created_user , @created_date, @comments, @file_name, @attachment, @comparttype_auto, @position) 

	SET @result = @@IDENTITY 
END
ELSE IF(@ATTACH_TYPE = 'compart_testing_point_image')
BEGIN
	DELETE FROM COMPART_ATTACH_FILESTREAM WHERE comparttype_auto = @comparttype_auto AND compart_attach_type_auto = @compart_attach_type_auto AND tool_auto = @tool_auto
	INSERT INTO COMPART_ATTACH_FILESTREAM ([guid], compart_attach_type_auto, user_auto, entry_date, comment,attachment_name, attachment, comparttype_auto, tool_auto)
	VALUES (NEWID(), @compart_attach_type_auto , @created_user , @created_date, @comments, @file_name, @attachment, @comparttype_auto, @tool_auto) 
 
	SET @result = @@IDENTITY 
END
------------------------------------------------------
ELSE
BEGIN
	if exists (select * from COMPART_ATTACH_FILESTREAM where compartid_auto = @compartid_auto and compart_attach_type_auto = @compart_attach_type_auto  and (@inspection_auto = 0 or inspection_auto = @inspection_auto) and (@position = 0 or position = @position ))
	begin

		delete COMPART_ATTACH_FILESTREAM where compartid_auto = @compartid_auto and compart_attach_type_auto = @compart_attach_type_auto and (@position = 0 or position = @position)

	end




	insert into COMPART_ATTACH_FILESTREAM ( guid, compartid_auto, compart_attach_type_auto, user_auto, entry_date,comment,attachment_name, attachment , inspection_auto, position )
	values 
	( NEWID(), @compartid_auto , @compart_attach_type_auto , @created_user , @created_date, @comments, @file_name , @attachment , @inspection_auto, @position) 


	set @result = @@IDENTITY 

	IF (@inspectionDetailId > 0 AND (select COUNT(*) from TRACK_INSPECTION_IMAGES where InspectionDetailId = @inspectionDetailId) > 0 )
	BEGIN
	update TRACK_INSPECTION_IMAGES SET image_data = @attachment where InspectionDetailId = @inspectionDetailId
	END 
	ELSE IF (@inspectionDetailId > 0)
	BEGIN
	INSERT INTO TRACK_INSPECTION_IMAGES ([GUID], inspection_detail_auto, image_data, image_comment, InspectionDetailId )
	VALUES (NEWID(), CONVERT(nchar(10), @inspectionDetailId), @attachment, @comments, @inspectionDetailId)
	END
 
END
end try 

begin catch

set @result = -99  

end catch 

end";

        string return_compart_attachment_down = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[return_compart_attachment]
@compart_attach_auto bigint = 0  , 
@compartid_auto bigint = 0 , 
@compart_attach_type_auto int = 0 ,
@inspection_auto int =0,
@comparttype_auto BIGINT =0,
@tool_auto INT = -1,
@position INT = 0

as
begin

select compart_attach_auto , att.compartid_auto ,  att.compart_attach_type_auto , catype.compart_attach_type_name , att.attachment_name , att.comment, att.attachment  from COMPART_ATTACH_FILESTREAM  att 
inner join COMPART_ATTACH_TYPE catype on att.compart_attach_type_auto = catype.compart_attach_type_auto
where  (@compart_attach_auto = 0  or att.compart_attach_auto = @compart_attach_auto ) 
and ( @compartid_auto = 0 or  att.compartid_auto = @compartid_auto )   
and (@compart_attach_type_auto = 0 or att.compart_attach_type_auto = @compart_attach_type_auto )
and (@inspection_auto = 0 OR  att.inspection_auto = @inspection_auto )
AND (@comparttype_auto = 0 OR att.comparttype_auto = @comparttype_auto)
AND (@tool_auto = -1 OR att.tool_auto = @tool_auto)
AND (@position = 0 OR att.position = @position)


end 
";
        string return_track_report_images_down = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- EXEC return_track_report_images 298,'r'
-- =============================================
ALTER PROCEDURE [dbo].[return_track_report_images] 
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
";
        string store_compart_attachment_down = @"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[store_compart_attachment]
@compartid_auto bigint , 
@compart_attach_type_auto int ,
@attachment  VARBINARY(max) = null,
@file_name varchar(max) = null,
@created_date datetime = null ,
@created_user bigint = null,
@comments nvarchar(max) = null ,
@inspection_auto int = 0,
@comparttype_auto BIGINT = 0,
@tool_auto INT = 0,
@position INT = 0,
@result int output 
as 
begin

set @result = 0 ; 

begin try 

-- Changes to save compart images at CompartType level
DECLARE @ATTACH_TYPE NVARCHAR(50)
SELECT @ATTACH_TYPE = compart_attach_type_name FROM COMPART_ATTACH_TYPE WHERE compart_attach_type_auto = @compart_attach_type_auto

IF(@ATTACH_TYPE = 'comparttype_image')
BEGIN
	DELETE FROM COMPART_ATTACH_FILESTREAM WHERE comparttype_auto = @comparttype_auto AND compart_attach_type_auto = @compart_attach_type_auto AND position = @position
	INSERT INTO COMPART_ATTACH_FILESTREAM ([guid], compart_attach_type_auto, user_auto, entry_date, comment,attachment_name, attachment, comparttype_auto, position)
	VALUES (NEWID(), @compart_attach_type_auto , @created_user , @created_date, @comments, @file_name, @attachment, @comparttype_auto, @position) 
 
	SET @result = @@IDENTITY 
END
ELSE IF(@ATTACH_TYPE = 'compart_testing_point_image')
BEGIN
	DELETE FROM COMPART_ATTACH_FILESTREAM WHERE comparttype_auto = @comparttype_auto AND compart_attach_type_auto = @compart_attach_type_auto AND tool_auto = @tool_auto
	INSERT INTO COMPART_ATTACH_FILESTREAM ([guid], compart_attach_type_auto, user_auto, entry_date, comment,attachment_name, attachment, comparttype_auto, tool_auto)
	VALUES (NEWID(), @compart_attach_type_auto , @created_user , @created_date, @comments, @file_name, @attachment, @comparttype_auto, @tool_auto) 
 
	SET @result = @@IDENTITY 
END
------------------------------------------------------
ELSE
BEGIN
	if exists (select * from COMPART_ATTACH_FILESTREAM where compartid_auto = @compartid_auto and compart_attach_type_auto = @compart_attach_type_auto  and (@inspection_auto = 0 or inspection_auto = @inspection_auto) and (@position = 0 or position = @position ))
	begin

		delete COMPART_ATTACH_FILESTREAM where compartid_auto = @compartid_auto and compart_attach_type_auto = @compart_attach_type_auto and (@position = 0 or position = @position)

	end




	insert into COMPART_ATTACH_FILESTREAM ( guid, compartid_auto, compart_attach_type_auto, user_auto, entry_date,comment,attachment_name, attachment , inspection_auto, position )
	values 
	( NEWID(), @compartid_auto , @compart_attach_type_auto , @created_user , @created_date, @comments, @file_name , @attachment , @inspection_auto, @position) 


	set @result = @@IDENTITY 
END
end try 

begin catch

set @result = -99  

end catch 

end";
    }
}
