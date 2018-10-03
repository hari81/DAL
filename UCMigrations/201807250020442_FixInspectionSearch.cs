namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixInspectionSearch : DbMigration
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
			INNER JOIN LU_MMTA mmta on mmta.mmtaid_auto=eq.mmtaid_auto
			INNER JOIN TYPE type on mmta.type_auto = type.type_auto
			where ti.evalcode is not null and type.typedesc != ''Rope Shovel'' '


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


exec(@tmpStrSQL)");
        }
        
        public override void Down()
        {
        }
    }
}
