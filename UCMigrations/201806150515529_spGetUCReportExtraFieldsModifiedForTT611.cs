namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spGetUCReportExtraFieldsModifiedForTT611 : DbMigration
    {
        public override void Up()
        {
            Sql(@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetUCReportExtraFields]
	@quote_auto	INT
AS
BEGIN

--DECLARE @family NVARCHAR(100)
--SELECT @family = REPLACE(t.typedesc,' ','') FROM track_quote tq
--	INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
--	INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
--	INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
--	INNER JOIN [TYPE] t ON t.type_auto = mmta.type_auto
--WHERE tq.quote_auto = @quote_auto


DECLARE @report_name	VARCHAR(80)
DECLARE @top_left_logo	VARCHAR(80)
DECLARE @top_right_logo	VARCHAR(80)



SELECT @top_left_logo = isnull(frl.top_left_logo_img,'--'), @top_right_logo = isnull(frl.top_right_logo_img,'--')
FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON ti.inspection_auto = tq.inspection_auto
		INNER JOIN EQUIPMENT e ON ti.equipmentid_auto = e.equipmentid_auto
		INNER JOIN CRSF crsf ON e.crsf_auto = crsf.crsf_auto
		INNER JOIN CUSTOMER c ON crsf.customer_auto = c.customer_auto
		left JOIN FLUID_REPORT_CUSTOMER_LOGO frcl ON c.customer_auto = frcl.customer_auto
		left JOIN FLUID_REPORT_LOGO frl ON frcl.logo_auto = frl.logo_auto
where tq.quote_auto = @quote_auto

--SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtUndercarriageReport' 
SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtTTUndercarriageReport' -- HARDCODING CHANGE FOR TT -- I know it is ugly but no way for now
IF (@report_name <> 'CTS_Summary.rpt' AND  @report_name <> 'UC_TTSummary.rpt')
BEGIN
	IF datalength(@top_left_logo) <= 2 AND datalength(@top_right_logo) <= 2
BEGIN
	SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtUndercarriageReport'
END  
ELSE 
	SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtUndercarriageBrandedReport'
END


 IF @report_name = 'UC_TTSummary.rpt' OR  @report_name = 'CTS_Summary.rpt' 
BEGIN
		SELECT distinct tq.quote_auto
	,ISNULL(frl.top_right_logo_img,'default.png') AS [TopRightLogo]	
	--,ISNULL(dei.overall_evaluation,'X') AS [OverallEval]
	,isnull(ti.evalcode,(select max(eval_code) from track_inspection_detail where inspection_auto = ti.inspection_auto)) as OverallEval
	,ISNULL((SELECT TOP(1) file_data FROM EQ_UNIT_ATTACHMENTS_FILESTREAM where equipmentid_auto = e.equipmentid_auto),(SELECT top(1) UCReportImg1 FROM track_ucreport_defaultimages)) as img1,
	ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = t.blob_auto),(SELECT top(1) UCReportImg2 FROM track_ucreport_defaultimages)) as img2, 
	ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = t.blob_auto),(SELECT top(1) UCReportImg2 FROM track_ucreport_defaultimages)) as img3,
	cu.customer_auto
	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END
ELSE IF @report_name = 'UCAppraisalReport.rpt'
BEGIN
	SELECT distinct tq.quote_auto
	,'default.png' AS [TopRightLogo]	
	--,ISNULL(dei.overall_evaluation,'X') AS [OverallEval]
	,ISNULL(ti.evalcode,(SELECT MAX(eval_code) FROM track_inspection_detail WHERE inspection_auto = ti.inspection_auto)) AS OverallEval
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 10)) AS img1
	--,(SELECT UCReportImg1 FROM itm_ucreport_defaultimages) as img1
	,(SELECT UCReportImg2 FROM itm_ucreport_defaultimages) AS img2, cu.customer_auto
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 11)) AS img3
	--,ISNULL(ISNULL((SELECT TOP 1 file_data FROM EQ_UNIT_ATTACHMENTS_FILESTREAM WHERE equipmentid_auto=e.equipmentid_auto ORDER BY equnit_attachment_auto DESC),(SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = bf.blob_auto)),(SELECT UCReportImg1 FROM itm_ucreport_defaultimages)) AS img1,
	--ISNULL(ISNULL((SELECT TOP 1 file_data FROM (SELECT TOP 2 * FROM EQ_UNIT_ATTACHMENTS_FILESTREAM  WHERE equipmentid_auto=e.equipmentid_auto ORDER BY equnit_attachment_auto DESC) x ORDER BY equnit_attachment_auto),(SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = bf.blob_auto)),(SELECT UCReportImg2 FROM itm_ucreport_defaultimages)) AS img2	

	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END
ELSE IF @report_name = 'UCAppraisalReportBranded1.rpt'
BEGIN
	SELECT distinct tq.quote_auto
	,ISNULL(frl.top_right_logo_img,'default.png') AS [TopRightLogo]	
	,ISNULL(ti.evalcode,(SELECT MAX(eval_code) FROM track_inspection_detail WHERE inspection_auto = ti.inspection_auto)) AS OverallEval
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 10)) AS img1
	,(SELECT UCReportImg2 FROM itm_ucreport_defaultimages) AS img2
	,ISNULL(frl.top_left_logo_img,'') AS [TopLeftLogo], cu.customer_auto	
	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END ELSE IF @report_name = 'UCAppraisalReportWest-Track.rpt'
BEGIN
	SELECT distinct tq.quote_auto
	,ISNULL(frl.top_right_logo_img,'default.png') AS [TopRightLogo]	
	,ISNULL(ti.evalcode,(SELECT MAX(eval_code) FROM track_inspection_detail WHERE inspection_auto = ti.inspection_auto)) AS OverallEval
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 10)) AS img1
	,(SELECT UCReportImg2 FROM itm_ucreport_defaultimages) AS img2
	,ISNULL(frl.top_left_logo_img,'') AS [TopLeftLogo], cu.customer_auto
	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END

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
ALTER PROCEDURE [dbo].[spGetUCReportExtraFields]
	@quote_auto	INT
AS
BEGIN

--DECLARE @family NVARCHAR(100)
--SELECT @family = REPLACE(t.typedesc,' ','') FROM track_quote tq
--	INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
--	INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
--	INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
--	INNER JOIN [TYPE] t ON t.type_auto = mmta.type_auto
--WHERE tq.quote_auto = @quote_auto


DECLARE @report_name	VARCHAR(80)
DECLARE @top_left_logo	VARCHAR(80)
DECLARE @top_right_logo	VARCHAR(80)



SELECT @top_left_logo = isnull(frl.top_left_logo_img,'--'), @top_right_logo = isnull(frl.top_right_logo_img,'--')
FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON ti.inspection_auto = tq.inspection_auto
		INNER JOIN EQUIPMENT e ON ti.equipmentid_auto = e.equipmentid_auto
		INNER JOIN CRSF crsf ON e.crsf_auto = crsf.crsf_auto
		INNER JOIN CUSTOMER c ON crsf.customer_auto = c.customer_auto
		left JOIN FLUID_REPORT_CUSTOMER_LOGO frcl ON c.customer_auto = frcl.customer_auto
		left JOIN FLUID_REPORT_LOGO frl ON frcl.logo_auto = frl.logo_auto
where tq.quote_auto = @quote_auto

--SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtUndercarriageReport' 
SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtTTUndercarriageReport' -- HARDCODING CHANGE FOR TT -- I know it is ugly but no way for now
IF (@report_name <> 'CTS_Summary.rpt' AND  @report_name <> 'UC_TTSummary.rpt')
BEGIN
	IF datalength(@top_left_logo) <= 2 AND datalength(@top_right_logo) <= 2
BEGIN
	SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtUndercarriageReport'
END  
ELSE 
	SELECT @report_name = report_display_desc FROM FLUID_REPORT_LU_REPORTS	WHERE report_tool_name = 'rtUndercarriageBrandedReport'
END





IF @report_name = 'CTS_Summary.rpt' 
BEGIN

	SELECT distinct tq.quote_auto
	,ISNULL(frl.top_right_logo_img,'default.png') AS [TopRightLogo]	
	--,ISNULL(dei.overall_evaluation,'X') AS [OverallEval]
	,isnull(ti.evalcode,(select max(eval_code) from track_inspection_detail where inspection_auto = ti.inspection_auto)) as OverallEval
	, isnull(e.EquipmentPhoto
	,isnull((select Top 1 file_data from EQ_UNIT_ATTACHMENTS_FILESTREAM Where equipmentid_auto=e.equipmentid_auto ORDER BY equnit_attachment_auto DESC),(select UCReportImg1 from track_ucreport_defaultimages))) as img1
	, isnull(e.EquipmentPhoto
	,isnull((SELECT TOP 1 file_data FROM (select Top 2 * from EQ_UNIT_ATTACHMENTS_FILESTREAM  Where equipmentid_auto=e.equipmentid_auto ORDER BY equnit_attachment_auto DESC) x ORDER BY equnit_attachment_auto),(select UCReportImg2 from track_ucreport_defaultimages))) as img2, 
	NULL as img3,
	cu.customer_auto
	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
	WHERE tq.quote_auto = @quote_auto 
END
ELSE IF @report_name = 'UC_TTSummary.rpt'
BEGIN
		SELECT distinct tq.quote_auto
	,ISNULL(frl.top_right_logo_img,'default.png') AS [TopRightLogo]	
	--,ISNULL(dei.overall_evaluation,'X') AS [OverallEval]
	,isnull(ti.evalcode,(select max(eval_code) from track_inspection_detail where inspection_auto = ti.inspection_auto)) as OverallEval
	,ISNULL((SELECT TOP(1) file_data FROM EQ_UNIT_ATTACHMENTS_FILESTREAM where equipmentid_auto = e.equipmentid_auto),(SELECT top(1) UCReportImg1 FROM track_ucreport_defaultimages)) as img1,
	ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = t.blob_auto),(SELECT top(1) UCReportImg2 FROM track_ucreport_defaultimages)) as img2, 
	ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = t.blob_auto),(SELECT top(1) UCReportImg2 FROM track_ucreport_defaultimages)) as img3,
	cu.customer_auto
	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END
ELSE IF @report_name = 'UCAppraisalReport.rpt'
BEGIN
	SELECT distinct tq.quote_auto
	,'default.png' AS [TopRightLogo]	
	--,ISNULL(dei.overall_evaluation,'X') AS [OverallEval]
	,ISNULL(ti.evalcode,(SELECT MAX(eval_code) FROM track_inspection_detail WHERE inspection_auto = ti.inspection_auto)) AS OverallEval
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 10)) AS img1
	--,(SELECT UCReportImg1 FROM itm_ucreport_defaultimages) as img1
	,(SELECT UCReportImg2 FROM itm_ucreport_defaultimages) AS img2, cu.customer_auto
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 11)) AS img3
	--,ISNULL(ISNULL((SELECT TOP 1 file_data FROM EQ_UNIT_ATTACHMENTS_FILESTREAM WHERE equipmentid_auto=e.equipmentid_auto ORDER BY equnit_attachment_auto DESC),(SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = bf.blob_auto)),(SELECT UCReportImg1 FROM itm_ucreport_defaultimages)) AS img1,
	--ISNULL(ISNULL((SELECT TOP 1 file_data FROM (SELECT TOP 2 * FROM EQ_UNIT_ATTACHMENTS_FILESTREAM  WHERE equipmentid_auto=e.equipmentid_auto ORDER BY equnit_attachment_auto DESC) x ORDER BY equnit_attachment_auto),(SELECT filedata FROM BLOB_FAMILYIMAGE WHERE blob_auto = bf.blob_auto)),(SELECT UCReportImg2 FROM itm_ucreport_defaultimages)) AS img2	

	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END
ELSE IF @report_name = 'UCAppraisalReportBranded1.rpt'
BEGIN
	SELECT distinct tq.quote_auto
	,ISNULL(frl.top_right_logo_img,'default.png') AS [TopRightLogo]	
	,ISNULL(ti.evalcode,(SELECT MAX(eval_code) FROM track_inspection_detail WHERE inspection_auto = ti.inspection_auto)) AS OverallEval
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 10)) AS img1
	,(SELECT UCReportImg2 FROM itm_ucreport_defaultimages) AS img2
	,ISNULL(frl.top_left_logo_img,'') AS [TopLeftLogo], cu.customer_auto	
	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END ELSE IF @report_name = 'UCAppraisalReportWest-Track.rpt'
BEGIN
	SELECT distinct tq.quote_auto
	,ISNULL(frl.top_right_logo_img,'default.png') AS [TopRightLogo]	
	,ISNULL(ti.evalcode,(SELECT MAX(eval_code) FROM track_inspection_detail WHERE inspection_auto = ti.inspection_auto)) AS OverallEval
	,ISNULL((SELECT filedata FROM BLOB_FAMILYIMAGE_LARGE WHERE blob_auto = t.blob_large_auto),(SELECT FileData FROM BLOB_FAMILYIMAGE_LARGE where blob_auto = 10)) AS img1
	,(SELECT UCReportImg2 FROM itm_ucreport_defaultimages) AS img2
	,ISNULL(frl.top_left_logo_img,'') AS [TopLeftLogo], cu.customer_auto
	FROM TRACK_QUOTE tq
		INNER JOIN TRACK_INSPECTION ti ON tq.inspection_auto = ti.inspection_auto
		INNER JOIN EQUIPMENT e ON e.equipmentid_auto = ti.equipmentid_auto
		INNER JOIN CRSF crsf ON crsf.crsf_auto = e.crsf_auto
		INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto
		LEFT JOIN FLUID_REPORT_CUSTOMER_LOGO frcl on cu.customer_auto = frcl.customer_auto
		LEFT JOIN FLUID_REPORT_LOGO frl on frl.logo_auto = frcl.logo_auto
		LEFT JOIN DB_EQUIPMENT_INTERPRETATION dei ON e.equipmentid_auto = dei.equipmentid_auto
		INNER JOIN LU_MMTA mmta ON e.mmtaid_auto = mmta.mmtaid_auto
		INNER JOIN [TYPE] t on mmta.type_auto = t.type_auto
		LEFT JOIN BLOB_FAMILYIMAGE bf ON t.blob_auto = bf.blob_auto
	WHERE tq.quote_auto = @quote_auto 
END

END

");
        }
    }
}
