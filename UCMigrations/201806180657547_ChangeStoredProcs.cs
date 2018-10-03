namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStoredProcs : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Batch submitted through debugger: SQLQuery4.sql|7|0|C:\Users\noumanb\AppData\Local\Temp\~vs84D2.sql


-- ==========================================================================================
-- Modified:		Nouman | 21-12-2015 | PRN9509
-- Modified By:		Nouman | 28-10-2015 | PRN9462 - Added Examiner and status
-- Suling - 13 Feb 2014
-- Change to make it work for fileter Inspection Search
-- Test Run:		Exec return_track_inspection_search_4t

-- ==========================================================================================
ALTER PROCEDURE [dbo].[return_track_inspection_search_4T]

	@cust_name		varchar(100)	=null,
	@search_cust_name	varchar(20)	='contains',

	@serialno 		varchar(50)	=null,
	@search_serialno	varchar(20)	='contains',
	
	@jobsite		varchar(100)	=null,
	@search_jobsite		varchar(20)	='contains',

	@unitno		varchar(50)	=null,
	@search_unitno		varchar(20)	='contains',
	
	@docketNo		varchar(50)	=null,
	@search_docketNo	varchar(20)	='contains',

	@perpage		tinyint,
	@pagenumber		tinyint,
	@user_auto		bigint,

	--PRN9462
	@examiner		varchar(50)=null,
	@search_examiner		varchar(50)='contains',
	@status			varchar(5)='',
	--PRN9509
	@startDate			DATETIME,
	@endDate			DATETIME,
	@orderby	nvarchar(20) ='',
	@orderdir   bit =0 

AS

if @orderby='location' set @orderby='site_name'
if @orderby='docketno' set @orderby='docket_no'
if @orderby='inspectdate' set @orderby='inspection_date'
if @orderby='meterread' set @orderby='smu'

if @orderby = ''  set @orderby  = 'customer_auto'

if @orderdir is null set @orderdir=0

	set @cust_name = dbo.fnReplaceCharacters(@cust_name)

	set @serialno = dbo.fnReplaceCharacters(@serialno)

	set @jobsite = dbo.fnReplaceCharacters(@jobsite)

	set @unitno = dbo.fnReplaceCharacters(@unitno)

	set @docketNo = dbo.fnReplaceCharacters(@docketNo)

	set @examiner = dbo.fnReplaceCharacters(@examiner)
	
	Declare @strSQL 	varchar(8000)
	Declare @strWhere	varchar(4000)
	Declare	@strOrder	varchar(200)
	Declare @blnwhere	bit

	set @strWhere = ''
	
    --customer name
	if @cust_name is not null
	Begin
		if @search_cust_name = 'begins' 	set @strWhere = @strWhere + '(cu.cust_name LIKE ''' + @cust_name + '%'') AND '
		if @search_cust_name = 'ends' 		set @strWhere = @strWhere + '(cu.cust_name LIKE ''%' + @cust_name + ''') AND '
		if @search_cust_name = 'contains' 	set @strWhere = @strWhere + '(cu.cust_name LIKE ''%' + @cust_name + '%'') AND '
		if @search_cust_name = 'equals' 	set @strWhere = @strWhere + '(cu.cust_name = ''' + @cust_name + ''') AND '
	End     
 
	--serial number
	if @serialno is not null
	Begin
		if @search_serialno = 'begins' 		set @strWhere = @strWhere + '(eq.serialno LIKE ''' + @serialno + '%'') AND '
		if @search_serialno = 'ends' 		set @strWhere = @strWhere + '(eq.serialno LIKE ''%' + @serialno + ''') AND '
		if @search_serialno = 'contains' 	set @strWhere = @strWhere + '(eq.serialno LIKE ''%' + @serialno + '%'') AND '
		if @search_serialno = 'equals'		set @strWhere = @strWhere + '(eq.serialno = ''' + @serialno + ''') AND '
	End

	--job site
	if @jobsite is not null
	Begin
		if @search_jobsite = 'begins' 	set @strWhere = @strWhere + '(CRSF.site_name LIKE ''' + @jobsite + '%'') AND '
		if @search_jobsite = 'ends' 	set @strWhere = @strWhere + '(CRSF.site_name LIKE ''%' + @jobsite + ''') AND '
		if @search_jobsite = 'contains'	set @strWhere = @strWhere + '(CRSF.site_name LIKE ''%' + @jobsite + '%'') AND '
		if @search_jobsite = 'equals' 	set @strWhere = @strWhere + '(CRSF.site_name = ''' + @jobsite + ''') AND '
	End
	
	--unit number
	if @unitno is not null	
	Begin	
		if @search_unitno = 'begins' 	set @strWhere = @strWhere + '(eq.unitno LIKE ''' + @unitno + '%'') AND '
		if @search_unitno = 'ends'		set @strWhere = @strWhere + '(eq.unitno LIKE ''%' + @unitno + ''') AND '
		if @search_unitno = 'contains' 	set @strWhere = @strWhere + '(eq.unitno LIKE ''%' + @unitno + '%'') AND '
		if @search_unitno = 'equals' 	set @strWhere = @strWhere + '(eq.unitno = ''' + @unitno + ''') AND '
	End

	--docket number
	if @docketNo is not null	
	Begin	
		if @search_docketNo = 'begins'		set @strWhere = @strWhere + '(ti.docket_no LIKE ''' + @docketNo + '%'') AND '
		if @search_docketNo = 'ends' 		set @strWhere = @strWhere + '(ti.docket_no LIKE ''%' + @docketNo + ''') AND '
		if @search_docketNo = 'contains' 	set @strWhere = @strWhere + '(ti.docket_no LIKE ''%' + @docketNo + '%'') AND '
		if @search_docketNo = 'equals'		set @strWhere = @strWhere + '(ti.docket_no = ''' + @docketNo + ''') AND '
	End

	--PRN9462
	--Examiner
	if @examiner is not null 
	begin
		if @search_examiner = 'begins'		set @strWhere = @strWhere + '(ti.examiner LIKE ''' + @examiner + '%'') AND '
		if @search_examiner = 'ends' 		set @strWhere = @strWhere + '(ti.examiner LIKE ''%' + @examiner + ''') AND '
		if @search_examiner = 'contains' 	set @strWhere = @strWhere + '(ti.examiner LIKE ''%' + @examiner + '%'') AND '
		if @search_examiner = 'equals'		set @strWhere = @strWhere + '(ti.examiner = ''' + @examiner + ''') AND '
	end
	
	IF OBJECT_ID('tempdb..##Temp') IS NOT NULL
	BEGIN
		DROP TABLE ##Temp
	END
	
	CREATE TABLE [dbo].[##Temp] (
		[id_auto] [int] IDENTITY (1, 1) NOT NULL ,		
		[inspect_auto] [bigint],
		[cust_name] [varchar] (100),
		[jobsite]   [varchar] (100),
		[serialno] [varchar] (50),
		[unitno] [varchar] (50),
		[docketno] [varchar] (50),
		[customer_auto] [bigint],
		[crsf_auto] [bigint],
		[equipmentid_auto] [bigint],
		[inspectdate] [datetime],
		[meterread] [int],
		[Inspector]	[varchar](100), --PRN9462
		[Status] [varchar](20)
		)

	--set @strSQL = 'SELECT cu.custid, cu.cust_name, eq.serialno, eq.unitno, mod.modeldesc, mak.makedesc, cu.customer_auto, eq.crsf_auto, eq.equipmentid_auto
	set @strSQL = 'INSERT INTO [dbo].[##Temp]
					SELECT    DISTINCT TOP '  + cast((@pagenumber*@perpage) as varchar) + ' ti.inspection_auto, cu.cust_name, CRSF.site_name, eq.serialno, eq.unitno,
			ti.docket_no, cu.customer_auto, crsf.crsf_auto, eq.equipmentid_auto,ti.inspection_date, ti.smu,ti.examiner
			,case when (select count(*) from TRACK_QUOTE q where q.inspection_auto = ti.inspection_auto) > 0 then ''Interpreted'' else ''Inspected'' end  as [Status]
			FROM                    
			EQUIPMENT eq   INNER JOIN	                           
			CRSF ON eq.crsf_auto = CRSF.crsf_auto INNER JOIN
			CUSTOMER cu ON CRSF.customer_auto = cu.customer_auto INNER JOIN
			GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto inner join 
			TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto inner join 
    
			TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto
			where ti.evalcode is not null  '


	--if dbo.fn_return_internal_emp_status(@user_auto) = 0 and @user_auto <> 0  -- the user is not internal employee
	--	set @strSQL = @strSQL + ' and eq.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(' + cast(@user_auto as varchar) + ')) '

--	set @strWhere = @strWhere + ' cu.active = 1 AND '
	SET @strWhere = @strWhere + ' ti.inspection_date BETWEEN ''' + CONVERT(VARCHAR, @startDate, 120) + ''' AND ''' +  CONVERT(VARCHAR, @endDate, 120)  + ''' AND '
	set @strWhere = 'AND ' + @strWhere;

	--truncate the sql statement
	if right(@strWhere, 6) = 'WHERE '
		set @strWhere = substring(@strWhere,1,datalength(@strWhere) - 6)
	else if right(@strWhere, 4) = 'AND '
		set @strWhere = substring(@strWhere,1,datalength(@strWhere) - 4)

	--set the order by clause
	set @strOrder = ' ORDER BY ' + @orderby + Case When @orderdir=0 Then ' ASC ' Else ' Desc ' End
	print(@strSQL + @strWhere + @strOrder)
	exec(@strSQL + @strWhere + @strOrder)


	declare @tmpStrSQL nvarchar(max)  =  replace(@strSQL,'INSERT INTO [dbo].[##Temp]',' ')
	set @tmpStrSQL= REPLACE(@tmpStrSQL,' TOP '  + cast((@pagenumber*@perpage) as varchar) , ' ' )
	set @tmpStrSQL = 'Select count(*) as TotalRows from ( ' + @tmpStrSQL + @strWhere + ' ) as tbl'
	print @tmpStrSQL
	
	exec('select count(*) as unitscount from [dbo].[##Temp] ')
	set @strSQL = 'DELETE FROM [dbo].[##Temp]  WHERE id_auto <= ' + cast(@perpage*(@pagenumber-1) as varchar) + ' '

			exec(@strSQL)

if @status = ''
begin
	EXEC('SELECT inspect_auto, cust_name, jobsite as location, serialno, unitno, docketno, inspectdate, meterread, customer_auto, crsf_auto, equipmentid_auto,Inspector,Status FROM  [dbo].[##Temp]')
end
else if @status = '0'
begin
	EXEC('SELECT inspect_auto, cust_name, jobsite as location, serialno, unitno, docketno, inspectdate, meterread, customer_auto, crsf_auto, equipmentid_auto,Inspector,Status FROM  [dbo].[##Temp] WHERE status = ''Inspected''  ')
end
else if @status = '1'
begin
	EXEC('SELECT inspect_auto, cust_name, jobsite as location, serialno, unitno, docketno, inspectdate, meterread, customer_auto, crsf_auto, equipmentid_auto,Inspector,Status FROM  [dbo].[##Temp] WHERE status = ''Interpreted''  ')
end
	EXEC('drop table  [dbo].[##Temp]')


exec(@tmpStrSQL)
");

            Sql(@"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[return_equipment_list_4T] 
	@dealership_auto	bigint=1,
	@user_auto		bigint=1,
	@orderby		varchar(50)='SerialNo',
	@customer_auto	bigint=3499,
	@crsf_auto		bigint=18518,
	@make_auto		bigint=0,
	@type_auto		bigint=0,
	@model_auto		bigint=0,
	@compartid_auto	bigint=0,
	@compartsn		varchar(50)='',
	@serialno		varchar(50)='',
	@unitno			varchar(50)='',
	@fleet_auto		bigint=0,
	@modelOrderBy	tinyint=0,
    @jobsiteChange  tinyint=0,
	@searchType		varchar(20)='contains',
	@debug			bit=1,
	@module		varchar(50)='undercarriage'	--PRN11789 - changed to undercarriage from get
AS
	DECLARE	@strSQL 	varchar(8000)
	DECLARE	@strSQL2 	varchar(8000)
	DECLARE	@strWHERE	varchar(500)
	DECLARE	@strWHERE2	varchar(500)
	DECLARE	@strORDERBY	varchar(500)

	SET @strWHERE = ' WHERE cust.active=1 '
	SET @strORDERBY = ' ORDER BY '

	IF @modelOrderBy = 1
		SET @strORDERBY = @strORDERBY + ' mo.model_auto, '

	SET @strSQL =  'SELECT DISTINCT  e.equipmentid_auto, serialno, unitno, mo.model_auto, mo.modeldesc, cust.cust_name
					, cust.customer_auto,  m.makedesc,1 as region_auto '
    
	if @searchType = 'fleet_assigned'
		SET @strSQL = @strSQL + ' , [fleet_list_order] ' 

    IF(@compartsn <> '')
		SET @strSQL = @strSQL + ' , oeu.compartsn, oeu.compartid_auto ' 
		 
	IF (@jobsiteChange != 0)
		SET @strSQL = @strSQL + ' , t.typedesc, a.modified_date, a.username as modified_user ' 

	SET @strSQL = @strSQL + ' , crsf.crsf_auto, serialno + '' : '' + unitno as equipment_serial,  e.unitno + '' : '' + e.serialno as equipment_unit, isnull(regno,'''') as regno '

   	IF @searchType = 'fleet_not_assigned'
		SET @strORDERBY = @strORDERBY + ' unitno ASC'
	else if @orderby <> ''
	    SET @strORDERBY = @strORDERBY + @orderby + '  ASC'
	ELSE
		SET @strORDERBY = @strORDERBY + ' serialno ASC'

	SET @strSQL = @strSQL + ' FROM      EQUIPMENT e 
			INNER JOIN CRSF				ON e.crsf_auto			= CRSF.crsf_auto
            INNER JOIN CUSTOMER cust	ON cust.customer_auto	= CRSF.customer_auto
			INNER JOIN LU_MMTA	mmta	ON e.mmtaid_auto		= mmta.mmtaid_auto 
			INNER JOIN MODEL	mo		ON mmta.model_auto		= mo.model_auto 
            INNER JOIN MAKE		m		ON m.make_auto			= mmta.make_auto			
            LEFT OUTER JOIN MODULE_REGISTRATION_EQUIPMENT mre on mre.equipmentid_auto =  e.equipmentid_auto '

	if @searchType = 'fleet_assigned'
		SET @strSQL = @strSQL + ' inner JOIN [FLEET_EQUIPMENT_ORDER]	feo	 ON e.equipmentid_auto = feo.equipmentid_auto and feo.fleet_auto = ' + cast(@fleet_auto as varchar) + ' '

	IF(@compartid_auto <> 0 OR @compartsn <> '')
			SET @strSQL = @strSQL + ' LEFT JOIN OIL_EQ_UNIT			oeu		ON e.equipmentid_auto = oeu.equipmentid_auto 
									  LEFT OUTER JOIN LU_COMPART	comp	ON oeu.compartid_auto = comp.compartid_auto '
			
    IF (@jobsiteChange != 0)
		SET @strSQL = @strSQL + ' 
			INNER JOIN TYPE t on t.type_auto = mmta.type_auto
            left join (select ejh.equipmentid_auto, ejh.modified_date, u.username from equip_jobsite_history ejh left join USER_TABLE u on u.user_auto=ejh.modified_user 
						where ejh.equip_jobsite_auto in (select max(equip_jobsite_auto) from equip_jobsite_history group by equipmentid_auto)) a on a.equipmentid_auto=e.equipmentid_auto '
	
	if @module is not null and @module <> 'all' and @module <> ''
		SET @strWHERE = @strWHERE + ' AND (mre.'  + @module + ' = 1 or mre.'  + @module + ' is null) '
	IF @crsf_auto <> 0
		SET @strWHERE = @strWHERE + ' AND CRSF.crsf_auto = '  + cast(@crsf_auto as varchar(12)) + ' '
	ELSE IF @customer_auto <> 0
		SET @strWHERE = @strWHERE + ' AND CRSF.customer_auto = '  + cast(@customer_auto as varchar(12)) + ' '		
	--ELSE IF @dealership_auto <> 0
		--SET @strWHERE = @strWHERE + ' AND r.dealership_auto  = '  + cast(@dealership_auto as varchar(12)) + ' '		
	
	IF @make_auto <> 0
		SET @strWHERE = @strWHERE + ' AND mmta.make_auto  = '  + cast(@make_auto as varchar(12)) + ' '		
	IF @type_auto <> 0
		SET @strWHERE = @strWHERE + ' AND mmta.type_auto  = '  + cast(@type_auto as varchar(12)) + ' '		
	IF @model_auto <> 0
		SET @strWHERE = @strWHERE + ' AND mmta.model_auto  = '  + cast(@model_auto as varchar(12)) + ' '	
	IF @compartid_auto <> 0
		SET @strWHERE = @strWHERE + ' AND comp.compartid_auto  = '  + cast(@compartid_auto as varchar(12)) + ' '	

	IF @searchType = 'begins'
		BEGIN
			if @unitno <> 'serialORunit_for_JSON'
			begin
				IF @serialno <> ''
					SET @strWHERE = @strWHERE + ' AND e.serialno  like '''  + @serialno + '%''  '	
				IF @unitno <> ''
					SET @strWHERE = @strWHERE + ' AND e.unitno  like '''  + @unitno + '%''  '
				IF @compartsn <> ''
					SET @strWHERE = @strWHERE + ' AND oeu.compartsn  like '''  + @compartsn + '%''  '
			end
			Else
			Begin
				SET @strWHERE = @strWHERE + ' AND (e.serialno  like ''%'  + @serialno + '%''  OR  e.unitno  like ''%'  + @serialno + '%'' )  '	
				IF @compartsn <> ''
					SET @strWHERE = @strWHERE + ' AND oeu.compartsn  like '''  + @compartsn + '%''  '
			End		
		END
	else if @searchType = 'fleet_not_assigned'
		begin
			SET @strWHERE = @strWHERE + ' AND (e.serialno  like ''%'  + @serialno + '%'' or e.unitno like ''%' + @serialno + '%'') '	
		end
	ELSE
		BEGIN
			if @unitno <> 'serialORunit_for_JSON'
			begin
				IF @serialno <> ''
					SET @strWHERE = @strWHERE + ' AND e.serialno  like ''%'  + @serialno + '%''  '	
				IF @unitno <> ''
					SET @strWHERE = @strWHERE + ' AND e.unitno  like ''%'  + @unitno + '%''  '	
				IF @compartsn <> ''
					SET @strWHERE = @strWHERE + ' AND oeu.compartsn  like '''  + @compartsn + '%''  '	
			end
			Else
			Begin
				SET @strWHERE = @strWHERE + ' AND (e.serialno  like ''%'  + @serialno + '%''  OR  e.unitno  like ''%'  + @serialno + '%'' )  '	
				IF @compartsn <> ''
					SET @strWHERE = @strWHERE + ' AND oeu.compartsn  like '''  + @compartsn + '%''  '
			End
		END

	IF @fleet_auto <>0 
		BEGIN
			IF @fleet_auto <>-1
				SET @strWHERE = @strWHERE + ' AND e.fleet_auto  = '  + cast(@fleet_auto as varchar(12)) + ' '	
			ELSE
				SET @strWHERE = @strWHERE + ' AND e.fleet_auto  is null '	
		END
	
	DECLARE @branded_admin BIT
	DECLARE @status tinyint
	SET @status = dbo.fnUserInternalAccessStatus(@user_auto)
	SELECT @branded_admin = ut.branded_admin FROM USER_TABLE ut WHERE ut.user_auto = @user_auto
	
	--IF ((@status = 0 AND @user_auto<>0) OR @branded_admin = 1)
    --BEGIN
	--	 SET @strWHERE = @strWHERE + ' AND e.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(' + cast(@user_auto as varchar) + ')) '
    --END
	
	--IF (@status = 1) 
    --BEGIN
	--	set @strSQL += ' LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		cust.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar)
	--	 SET @strWHERE = @strWHERE + ' AND ((cust.labonly <> 1) OR (cust.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =e.equipmentid_auto))  '
    --END

	IF(@module = 'tyre')
		SET @strWHERE = @strWHERE + ' AND e.equip_status = 1'

	IF @debug = 1	PRINT (@strSQL + @strWHERE + @strORDERBY)

	EXEC (@strSQL + @strWHERE + @strORDERBY)
");
        }
        
        public override void Down()
        {
        }
    }
}
