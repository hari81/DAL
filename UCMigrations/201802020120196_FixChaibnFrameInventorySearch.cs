namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixChaibnFrameInventorySearch : DbMigration
    {
        public override void Up()
        {

            Sql(@"
/****** Object:  StoredProcedure [dbo].[spGetStockExchangeListBySystem]    Script Date: 2/02/2018 12:08:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery1.sql|7|0|C:\Users\MasonS\AppData\Local\Temp\~vsAB51.sql
-- =============================================
-- Modified:	NB | 15-11-16 | PRN11710
-- Author:		NB | 22-08-16 | PRN10086
--
-- Test Run:	exec spGetStockExchangeListBySystem 
-- =============================================
ALTER PROCEDURE [dbo].[spGetStockExchangeListBySystem] 
	-- Add the parameters for the stored procedure here
	@customer_auto 	bigint=0,
	@crsf_auto 		bigint=0,
	@make_auto      bigint=0,
	@model_auto     bigint=0,
	@moduleid       bigint=0,
	@system_auto    bigint=0,
	@status_list	varchar(100)='1,2,3,4,5,6,101,102,103',
	@system_sn		varchar(100)=''
AS

	Declare @str varchar(4000)
	Declare @whr varchar(1000)
	Declare @order varchar(1000)

	IF ISNULL(@status_list, '') = ''
		SET @status_list = '1,2,3,4,5,6,101,102,103'

	--Get the eval
	

	-- add additional ',' to @status_list string to simplify the query
	SET @status_list = ',' + @status_list + ','

	--set @str = 'SELECT * FROM ('

	--SET @str = 'SELECT lms.Module_sub_auto, lms.Serialno,md.modeldesc,CONVERT(VARCHAR(11),lms.CreatedDate,106) ,(select max()) as average , ''A'' as eval,'''' as status
	SET @str = 'SELECT lms.Module_sub_auto,c.cust_name,mk.makedesc,md.modeldesc, lms.Serialno,
					crsf.site_name, cs.[Description] component_status_desc,aa.type,crsf.crsf_auto,c.customer_auto, system_condition.condition, lms.system_LTD_on_removal, (CASE WHEN aa.type = ''Chain'' AND actions_counted.turns_count > 0 THEN ''YES'' WHEN aa.type = ''Chain'' AND actions_counted.turns_count = 0 THEN ''NO'' WHEN aa.type = ''Chain'' AND actions_counted.turns_count = '''' THEN ''NO'' END) AS ChainIsTurned
					FROM LU_Module_Sub lms
						INNER JOIN MAKE mk ON lms.make_auto = mk.make_auto
						INNER JOIN MODEL md ON lms.model_auto = md.model_auto
						INNER JOIN CRSF crsf ON lms.crsf_auto = crsf.crsf_auto 
						INNER JOIN Customer c ON c.customer_auto = crsf.customer_auto
						LEFT JOIN SYSTEM_STATUS cs ON lms.status=cs.Id 
						INNER JOIN (SELECT DISTINCT lms.Module_sub_auto, CASE WHEN lct.comparttype in (''Link'',''Bushing'',''Shoe'') then ''Chain'' ELSE ''Frame'' END AS [type] 
									FROM LU_MODULE_Sub lms
										INNER JOIN GENERAL_EQ_UNIT geu on lms.Module_sub_auto = geu.module_ucsub_auto
										INNER JOIN LU_COMPART lc on geu.compartid_auto=lc.compartid_auto
										INNER JOIN LU_COMPART_TYPE lct on lc.comparttype_auto = lct.comparttype_auto) aa on lms.Module_sub_auto = aa.Module_sub_auto'
						--INNER JOIN COMPONENT_STATUS cs ON '
						
		/*set @str = @str + ' LEFT JOIN (SELECT DISTINCT lms.Module_sub_auto, evaluated_comps.eavlCode condition FROM LU_Module_Sub lms
LEFT JOIN
(SELECT * FROM GENERAL_EQ_UNIT comps
INNER JOIN	(SELECT MAX(equip_ins.inspection_date) latest_date,t_ins_detail.track_unit_auto, COUNT(equip_ins.inspection_auto) AS count_inspection, MAX(t_ins_detail.eval_code) AS eavlCode 
	FROM TRACK_INSPECTION_DETAIL t_ins_detail
	INNER JOIN TRACK_INSPECTION equip_ins ON equip_ins.inspection_auto = t_ins_detail.inspection_auto
	GROUP BY t_ins_detail.track_unit_auto) 
	AS last_inspect ON comps.equnit_auto = last_inspect.track_unit_auto) evaluated_comps ON evaluated_comps.module_ucsub_auto = lms.Module_sub_auto) AS system_condition ON lms.Module_sub_auto = system_condition.Module_sub_auto'
	*/

	set @str = @str + ' LEFT JOIN (SELECT Module_sub_auto, component.equnit_auto, (SELECT TOP 1 eval_code FROM [dbo].fnGetLatestInspectionDetailOfEquipment(component.equnit_auto) ORDER BY eval_code DESC) AS condition FROM LU_Module_Sub lms
INNER JOIN GENERAL_EQ_UNIT as component ON component.module_ucsub_auto = lms.Module_sub_auto) system_condition ON system_condition.Module_sub_auto = lms.Module_sub_auto';

set @str = @str + ' LEFT JOIN (SELECT lmsForActionType.Module_sub_auto lms_id, SUM(CASE WHEN act_view.action_type_auto = 9 OR act_view.action_type_auto=12 then 1 ELSE 0 END) turns_count FROM LU_Module_Sub lmsForActionType
INNER JOIN vw_action_taken_history_old_new act_view ON act_view.system_auto_id = lmsForActionType.Module_sub_auto 
GROUP BY lmsForActionType.Module_sub_auto) actions_counted ON actions_counted.lms_id = lms.Module_sub_auto '


		SET @whr = ' WHERE lms.equipmentid_auto is NULL AND lms.Module_sub_auto NOT IN (SELECT DISTINCT isnull(module_ucsub_auto,0) FROM GENERAL_EQ_UNIT where equipmentid_auto IS not null ) '

		--set @whr = @whr + ') AS allRows WHERE allRows.rn = 1'
			

	if @customer_auto is not null AND @customer_auto<>0
		SET @whr= @whr + ' AND c.customer_auto = ' + cast(@customer_auto as varchar)

	if @crsf_auto is not null AND @crsf_auto<>0
		SET @whr= @whr + ' AND crsf.crsf_auto = ' + cast(@crsf_auto as varchar)

	if @make_auto is not null AND @make_auto<>0
		SET @whr= @whr + ' AND mk.make_auto = ' + cast(@make_auto as varchar)

	if @model_auto is not null AND @model_auto<>0
		SET @whr= @whr + ' AND md.model_auto = ' + cast(@model_auto as varchar)

	if @system_sn IS NOT NULL AND @system_sn <> ''
		SET @whr= @whr + ' AND lms.Serialno LIKE ''%' + @system_sn + '%'''

	--if @moduleid is not null AND @moduleid<>0
	--	SET @whr= @whr + ' AND eq.moduleid = ' + cast(@moduleid as varchar)

	--if @system_auto is not null AND @system_auto<>0
	--	SET @whr= @whr + ' AND ls.system_auto = ' + cast(@system_auto as varchar)

	-- component status
	SET @whr = @whr + ' AND (ISNULL(lms.Status, 0) = 0 OR ''' + @status_list + ''' like ''%'' + CAST(ISNULL(lms.Status, 0) AS VARCHAR) + '',%'' OR ''' + @status_list + ''' like ''%,'' + CAST(ISNULL(lms.Status, 0) AS VARCHAR) + ''%'' )'

	--SET @order= ' ORDER BY component '
	--select @str + @whr
	print ( @str + @whr + @order)
	exec ( @str + @whr + @order)
");
        }
        
        public override void Down()
        {
        }
    }
}
