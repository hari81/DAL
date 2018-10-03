namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ObservationNoteColumnAddedSpsUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "ObservationNote", c => c.String());
            Sql(@"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Brendan - 16th June 2017
-- Added more allowances for special characters
--===========================================
-- Tracy T : 27th Apr 2011 - added option to filter on active warranty
--====================================
-- Irina M 11 March 2011
-- added the ability to show data for inactive customers
--===========================================================================================
-- Tracy T : 10th Nov 2010
-- model now nvarchar, also fixed customer search for nvarchar
--============================
-- Daniel Shi 3 Nov 2010
-- handled apostrophe symbols in query strings
--===========================================================================================
-- Prasanna on 14th Sept 2010 
-- Return only user assigned equipment details on customer login. 
--=================================================
-- Daniel S 24 Aug 2010
-- added a search condition: regno
--=================================================
-- Rumesh MM 2010-08-15
-- Added the sorting functionality to the page
--=================================================
-- Tracy T 28th Apr 2010
-- Found a bug when selecting 'Include Compart' info it only showed compartment if Oil type and Grade existed
-- So changed the joins.
-- =================================================
--Modified 25 Feb 2009 Irina
-- use field equip_status instead of status in EQUIPMENT
-- ===================================================================
--Modified 10th Nov 2008 Tracy Thompson
-- changed from global table to not using temp tables at all
--===================================================================
--Modified 24 Oct 2007 Irina
-- order of fields was changed as it is in use in HTTPHandlers: GetEquipmentSearchDetails
--     8 = crsf_auto; 9 - customer_auto, 10 - equipment_auto
-- ======================================================================================================
ALTER PROCEDURE[dbo].[return_equipment_search_4T]

    @search_serialno varchar(20) = 'contains',
    @search_unitno      varchar(20) = 'contains',
    @search_cust_name   varchar(20) = 'contains',
    @search_custid      varchar(20) = 'contains',
    @search_jobsite     varchar(20) = 'contains',
    @search_modeldesc   varchar(20) = 'contains',
    @search_makedesc    varchar(20) = 'contains',
    @serialno           varchar(50) = null,
    @unitno             varchar(50) = null,
    @cust_name          nvarchar(100) = null,
    @custid             varchar(20) = null,
    @jobsite            varchar(100) = null,
    @modeldesc          nvarchar(50) = null,
    @makedesc           varchar(50) = null,
    @perpage            int,
    @pagenumber         int,
    @search_type        varchar(20) = 'compartment', --Modified by Jerry 27th March 2007, return result filter by compart or equipment
      @oiltypedesc        varchar(50) = null,
	@oilgradedesc varchar(50) = null,
    @search_oiltypedesc varchar(20) = 'contains',
    @search_oilgradedesc varchar(20) = 'contains',
    @csno               varchar(50) = null,
    @search_csn         varchar(20) = 'contains',
    @debug              bit = 0,
    @sortOrder          tinyint = 0,
    @order              tinyint = 0,
    @search_regno       varchar(20) = 'contains',
    @regno              varchar(50) = null,
    @user_auto          bigint = 0,
    @customer_login     bit = 0, --Only when a customer doing a search to filter own equipments only

    @chkInclInactiveCust tinyint = 0, --to show Inactive Customer data

    @chkWarranty        bit = 0, -- if this is on we need to filter by equipment on warranty only
   @template_auto INT = 0
AS


    if @debug = 1 SET NOCOUNT ON

--Allow special characters
    set @serialno = replace(@serialno, '%20', ' ')

    set @serialno = replace(@serialno, '%7E', '~')

    set @serialno = replace(@serialno, '%21', '!')

    set @serialno = replace(@serialno, '%40', '@')

    set @serialno = replace(@serialno, '%23', '#')

    set @serialno = replace(@serialno, '%24', '$')

    set @serialno = replace(@serialno, '%25', '%')

    set @serialno = replace(@serialno, '%5E', '^')

    set @serialno = replace(@serialno, '%26', '&')

    set @serialno = replace(@serialno, '%2A', '*')

    set @serialno = replace(@serialno, '%28', '(')

    set @serialno = replace(@serialno, '%29', ')')


    set @unitno = replace(@unitno, '%20', ' ')

    set @unitno = replace(@unitno, '%7E', '~')

    set @unitno = replace(@unitno, '%21', '!')

    set @unitno = replace(@unitno, '%40', '@')

    set @unitno = replace(@unitno, '%23', '#')

    set @unitno = replace(@unitno, '%24', '$')

    set @unitno = replace(@unitno, '%25', '%')

    set @unitno = replace(@unitno, '%5E', '^')

    set @unitno = replace(@unitno, '%26', '&')

    set @unitno = replace(@unitno, '%2A', '*')

    set @unitno = replace(@unitno, '%28', '(')

    set @unitno = replace(@unitno, '%29', ')')

    --End Special characters

    set @serialno = ltrim(RTRIM(@serialno))

    set @unitno = ltrim(RTRIM(@unitno))


    set @custid = Replace(@custid, '''', '''''')

    set @makedesc = Replace(@makedesc, '''', '''''')

    set @modeldesc = Replace(@modeldesc, '''', '''''')

    set @csno = dbo.fnReplaceCharacters(@csno)


    Declare @strSQL     varchar(MAX)

    Declare @select     varchar(MAX)

    Declare @strWhere   nvarchar(4000)


    Declare @strOrder   varchar(200)

    Declare @strOrderTotal varchar(200)


    Declare @blnwhere   bit
    Declare @pagemin varchar(10)

    Declare @pagemax varchar(10)

    Declare @pagetotal varchar(10)


    set @pagemin = cast(@perpage * (@pagenumber - 1) as varchar)

    set @pagemax = cast((@pagenumber * @perpage) as varchar)

    set @pagetotal = cast((10 * @perpage) as varchar)


    select @strSQL = '', @strWhere = '', @select = ''
    -- 11 March 2011 Irina -

    if @chkInclInactiveCust = 0

        set @strWhere = ' cu.active = 1 '
    else 

        set @strWhere = ' 1=1 '


if (@template_auto <> 0)
                begin
                    declare @equipmentStr nvarchar(max)

                    select @equipmentStr = isnull(equipmentidString, '0') from SELECTION_TEMPLATES where seltemplate_auto = @template_auto
                

    if @equipmentStr <> ''

        set @strWhere = @strWhere
                    + ' and eq.equipmentid_auto in (' + @equipmentStr + ')'

end

    if @chkWarranty = 1

        set @strWhere = @strWhere
                    + ' and ((eq.equipmentid_auto in 
                            (SELECT     equipmentid_auto

                             FROM         WARRANTY_EQUIPMENT

                             WHERE(wty_expired IS NULL)) OR
                       (eq.equipmentid_auto in 

                       (SELECT     equipmentid_auto

                        FROM         WARRANTY_COMPONENT

                        WHERE(wty_expired IS NULL)))))'

--serial number

    if @serialno is not null AND @serialno <> 'null' and @serialno <> ''

    Begin
        set @serialno = dbo.fnReplaceCharacters(@serialno)

        if @search_serialno = 'begins'      set @strWhere = @strWhere + ' AND (eq.serialno LIKE ''' + @serialno + '%'') '

        if @search_serialno = 'ends'        set @strWhere = @strWhere + ' AND (eq.serialno LIKE ''%' + @serialno + ''') '

        if @search_serialno = 'contains'    set @strWhere = @strWhere + ' AND (eq.serialno LIKE ''%' + @serialno + '%'') '

        if @search_serialno = 'equals'      set @strWhere = @strWhere + ' AND ( ltrim(rtrim(eq.serialno)) = ''' + @serialno + ''') '

    End

    --regno

    if @regno is not null and @regno <> '' AND @regno <> 'null' and @regno <> ''

    Begin
        set @regno = dbo.fnReplaceCharacters(@regno)

        if @search_regno = 'begins'         set @strWhere = @strWhere + ' AND (eq.regno LIKE ''' + @regno + '%'') '

        if @search_regno = 'ends'           set @strWhere = @strWhere + ' AND (eq.regno LIKE ''%' + @regno + ''') '

        if @search_regno = 'contains'       set @strWhere = @strWhere + ' AND (eq.regno LIKE ''%' + @regno + '%'') '

        if @search_regno = 'equals'         set @strWhere = @strWhere + ' AND (eq.regno = ''' + @regno + ''') '

    End

    --unit number

    if @unitno is not null   AND @unitno <> 'null' and @unitno <> ''

    Begin
        set @unitno = dbo.fnReplaceCharacters(@unitno)

        if @search_unitno = 'begins'    set @strWhere = @strWhere + ' AND (eq.unitno LIKE ''' + @unitno + '%'') '

        if @search_unitno = 'ends'      set @strWhere = @strWhere + ' AND (eq.unitno LIKE ''%' + @unitno + ''') '

        if @search_unitno = 'contains'  set @strWhere = @strWhere + ' AND (eq.unitno LIKE ''%' + @unitno + '%'') '

        if @search_unitno = 'equals'    set @strWhere = @strWhere + ' AND (eq.unitno = ''' + @unitno + ''') '

    End

    --customer name

    if @cust_name is not null    AND @cust_name <> 'null' and @cust_name <> ''

    Begin
        set @cust_name = dbo.fnReplaceCharacters(@cust_name)

        if @search_cust_name = 'begins'     set @strWhere = @strWhere + ' AND (cu.cust_name LIKE N''' + @cust_name + '%'') '

        if @search_cust_name = 'ends'       set @strWhere = @strWhere + ' AND (cu.cust_name LIKE N''%' + @cust_name + ''') '

        if @search_cust_name = 'contains'   set @strWhere = @strWhere + ' AND (cu.cust_name LIKE N''%' + @cust_name + '%'') '

        if @search_cust_name = 'equals'     set @strWhere = @strWhere + ' AND (cu.cust_name = N''' + @cust_name + ''') '

    End

    --customer id

    if @custid is not null   AND @custid <> 'null' and @custid <> ''

    Begin

        if @search_custid = 'begins'    set @strWhere = @strWhere + ' AND (cu.custid LIKE ''' + @custid + '%'') '

        if @search_custid = 'ends'      set @strWhere = @strWhere + ' AND (cu.custid LIKE ''%' + @custid + ''') '

        if @search_custid = 'contains'  set @strWhere = @strWhere + ' AND (cu.custid LIKE ''%' + @custid + '%'') '

        if @search_custid = 'equals'    set @strWhere = @strWhere + ' AND (cu.custid = ''' + @custid + ''') '

    End

    --job site

    if @jobsite is not null AND @jobsite <> 'null' and @jobsite <> ''

    Begin
        set @jobsite = dbo.fnReplaceCharacters(@jobsite)

        if @search_jobsite = 'begins'   set @strWhere = @strWhere + ' AND (CRSF.site_name LIKE ''' + @jobsite + '%'') '

        if @search_jobsite = 'ends'     set @strWhere = @strWhere + ' AND (CRSF.site_name LIKE ''%' + @jobsite + ''') '

        if @search_jobsite = 'contains' set @strWhere = @strWhere + ' AND (CRSF.site_name LIKE ''%' + @jobsite + '%'') '

        if @search_jobsite = 'equals'   set @strWhere = @strWhere + ' AND (CRSF.site_name = ''' + @jobsite + ''') '

    End

    --modeldesc

    if @modeldesc is not null AND @modeldesc <> 'null' and @modeldesc <> ''

    Begin

        if @search_modeldesc = 'begins'     set @strWhere = @strWhere + ' AND (mod.modeldesc LIKE N''' + @modeldesc + '%'') '

        if @search_modeldesc = 'ends'       set @strWhere = @strWhere + ' AND (mod.modeldesc LIKE N''%' + @modeldesc + ''') '

        if @search_modeldesc = 'contains'   set @strWhere = @strWhere + ' AND (mod.modeldesc LIKE N''%' + @modeldesc + '%'') '

        if @search_modeldesc = 'equals'     set @strWhere = @strWhere + ' AND (mod.modeldesc = N''' + @modeldesc + ''') '

    End

    --makedesc

    if @makedesc is not null AND @makedesc <> 'null' and @makedesc <> ''

    Begin

        if @search_makedesc = 'begins'      set @strWhere = @strWhere + ' AND (mak.makedesc LIKE ''' + @makedesc + '%'') '

        if @search_makedesc = 'ends'        set @strWhere = @strWhere + ' AND (mak.makedesc LIKE ''%' + @makedesc + ''') '

        if @search_makedesc = 'contains'    set @strWhere = @strWhere + ' AND (mak.makedesc LIKE ''%' + @makedesc + '%'') '

        if @search_makedesc = 'equals'      set @strWhere = @strWhere + ' AND (mak.makedesc = ''' + @makedesc + ''')  '

    End

    --user_auto
    --if @customer_login = 1 and @user_auto is not null
    --  set @strWhere = @strWhere-- + 'and eq.equipmentid_auto in (SELECT * FROM dbo.fnEquipment(' + cast(@user_auto as varchar) + ')) '


    DECLARE @status tinyint
    SET @status = dbo.fnUserInternalAccessStatus(@user_auto)

    --IF @status = 1
    --  set @strWhere = @strWhere-- + ' and ((cu.labonly <> 1) OR (cu.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =eq.equipmentid_auto)) '
    --else if @status = 0 and @user_auto <> 0
    --  set @strWhere = @strWhere-- + 'and eq.equipmentid_auto in (SELECT * FROM dbo.fnEquipment(' + cast(@user_auto as varchar) + ')) '--PRN 7233


    IF @search_type = 'compartment'

    BEGIN
        ---- 11 March 2011 Irina -
        set @select = ' eq.serialno, eq.unitno
			, cu.custid + (case when ISNULL(cu.active, 0)= 0 then ''(Inactive)'' else '''' end) as custid
			, cu.cust_name + (case when ISNULL(cu.active, 0)= 0 then ''(Inactive)'' else '''' end) as Customer
			, mak.makedesc, mod.modeldesc
			, oequ.compartsn, lc.compart, lot.oiltypedesc as oil_type, [log].oilgradedesc as oil_grade
			, dbo.CRSF.site_name as location, CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END as status

            , cu.customer_auto, eq.crsf_auto, eq.equipmentid_auto, cu.active  , ISNULL(eq.regno, '''') as [Reg.No] '

		set @strSQL = '   dbo.CRSF INNER JOIN
                dbo.EQUIPMENT AS eq ON CRSF.crsf_auto = eq.crsf_auto INNER JOIN
                dbo.CUSTOMER AS cu ON CRSF.customer_auto = cu.customer_auto INNER JOIN
                dbo.LU_MMTA ON eq.mmtaid_auto = LU_MMTA.mmtaid_auto INNER JOIN
                dbo.MAKE AS mak ON LU_MMTA.make_auto = mak.make_auto INNER JOIN
                dbo.MODEL AS mod ON LU_MMTA.model_auto = mod.model_auto LEFT OUTER JOIN
                dbo.OIL_EQ_UNIT AS oequ INNER JOIN
                dbo.LU_COMPART AS lc ON oequ.compartid_auto = lc.compartid_auto LEFT OUTER JOIN
                dbo.LU_OILTYPE AS lot ON lot.oiltype_auto = oequ.oiltype_auto LEFT OUTER JOIN
                dbo.LU_OILGRADE AS [log] ON[log].oilgrade_auto = oequ.oilgrade_auto ON eq.equipmentid_auto = oequ.equipmentid_auto '
				--LEFT JOIN USER_CRSF_CUST_EQUIP ucce   ON cu.customer_auto = ucce.customer_auto AND ucce.user_auto    = ' + cast(@user_auto as varchar) + ''

		--Modified to filter based on oil type description and oil grade description for compartment
		-- compart serial number
--		print (@select + @strSQL)
		if @csno is not null
		Begin
			if @search_csn = 'begins' 	set @strWhere = @strWhere + ' AND (oequ.compartsn LIKE ''' + @csno + '%'') '
			if @search_csn = 'ends'    	set @strWhere = @strWhere + ' AND (oequ.compartsn LIKE ''%' + @csno + ''') '
			if @search_csn = 'contains' set @strWhere = @strWhere + ' AND (oequ.compartsn LIKE ''%' + @csno + '%'') '
			if @search_csn = 'equals' 	set @strWhere = @strWhere + ' AND (oequ.compartsn = ''' + @csno + ''') '
		End
		
             --oiltypedesc
		if @oiltypedesc is not null
		Begin
			if @search_oiltypedesc = 'begins' 		set @strWhere = @strWhere + ' AND (lot.oiltypedesc LIKE ''' + @oiltypedesc + '%'') '
			if @search_oiltypedesc = 'ends' 		set @strWhere = @strWhere + ' AND (lot.oiltypedesc LIKE ''%' + @oiltypedesc + ''') '
			if @search_oiltypedesc = 'contains' 	set @strWhere = @strWhere + ' AND (lot.oiltypedesc LIKE ''%' + @oiltypedesc + '%'') '
			if @search_oiltypedesc = 'equals' 		set @strWhere = @strWhere + ' AND (lot.oiltypedesc = ''' + @oiltypedesc + ''') '
		End

		--oilgradedesc
		if @oilgradedesc is not null
		Begin
			if @search_oilgradedesc = 'begins' 		set @strWhere = @strWhere + ' AND (log.oilgradedesc LIKE ''' + @oilgradedesc + '%'') '
			if @search_oilgradedesc = 'ends' 		set @strWhere = @strWhere + ' AND (log.oilgradedesc LIKE ''%' + @oilgradedesc + ''') '
			if @search_oilgradedesc = 'contains' 	set @strWhere = @strWhere + ' AND (log.oilgradedesc LIKE ''%' + @oilgradedesc + '%'') '
			if @search_oilgradedesc = 'equals' 		set @strWhere = @strWhere + ' AND (log.oilgradedesc = ''' + @oilgradedesc + ''') '
		End

    END

    ELSE IF @search_type = 'equipment'
	BEGIN
        set @select = ' eq.serialno, eq.unitno
			, cu.custid + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) as custid
			, cu.cust_name + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) as Customer
			, mak.makedesc, mod.modeldesc
			, dbo.CRSF.site_name as location, CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END as status

            , cu.customer_auto, eq.crsf_auto, eq.equipmentid_auto, cu.active , ISNULL(eq.regno, '''') as [Reg.No]'
				
		set @strSQL = '                     

            dbo.EQUIPMENT eq   INNER JOIN

            dbo.CRSF ON eq.crsf_auto = dbo.CRSF.crsf_auto INNER JOIN
            dbo.CUSTOMER cu ON dbo.CRSF.customer_auto = cu.customer_auto INNER JOIN

            dbo.LU_MMTA ON eq.mmtaid_auto = dbo.LU_MMTA.mmtaid_auto INNER JOIN

            dbo.MAKE mak ON LU_MMTA.make_auto = mak.make_auto INNER JOIN

            dbo.MODEL mod ON LU_MMTA.model_auto = mod.model_auto '
			--LEFT JOIN USER_CRSF_CUST_EQUIP ucce   ON cu.customer_auto = ucce.customer_auto AND ucce.user_auto    = ' + cast(@user_auto as varchar) + ''

    END

	--set the order by clause
    set @strOrder = ' ORDER BY eq.serialno ASC, eq.unitno ASC '

	if @sortOrder = 1 and @order = 1

        set @strOrder = ' ORDER BY eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 1 and @order = 2

        set @strOrder = ' ORDER BY eq.serialno DESC, eq.unitno ASC '
	if @sortOrder = 2 and @order = 1

        set @strOrder = ' ORDER BY eq.unitno ASC, eq.serialno ASC '
	if @sortOrder = 2 and @order = 2

        set @strOrder = ' ORDER BY eq.unitno DESC, eq.serialno ASC '
	if @sortOrder = 3 and @order = 1

        set @strOrder = ' ORDER BY cu.custid + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end)  ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 3 and @order = 2

        set @strOrder = ' ORDER BY cu.custid + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 4 and @order = 1

        set @strOrder = ' ORDER BY cu.cust_name + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 4 and @order = 2

        set @strOrder = ' ORDER BY cu.cust_name + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 5 and @order = 1

        set @strOrder = ' ORDER BY mak.makedesc ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 5 and @order = 2

        set @strOrder = ' ORDER BY mak.makedesc DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 6 and @order = 1

        set @strOrder = ' ORDER BY mod.modeldesc ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 6 and @order = 2

        set @strOrder = ' ORDER BY mod.modeldesc DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 7 and @order = 1

        set @strOrder = ' ORDER BY CRSF.site_name ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 7 and @order = 2

        set @strOrder = ' ORDER BY CRSF.site_name DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 8 and @order = 1

        set @strOrder = ' ORDER BY CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END  ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 8 and @order = 2

        set @strOrder = ' ORDER BY CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END  DESC, eq.serialno ASC, eq.unitno ASC '

set @strOrderTotal = ' ORDER BY row desc '

print (@select + @strSQL + @strWhere + @strOrder)

if @debug = 1 

    print('SELECT *  FROM    (
								SELECT distinct TOP '  + @pagemax +  

                                @select + ', ROW_NUMBER() OVER( ' + @strOrder + ' ) AS row 

                                FROM    ' + @strSQL + '

                                WHERE   ' + @strWhere + @strOrder + '
							  ) AS tbl

                      WHERE

                              row > ' +  @pagemin)


    EXEC('SELECT *  FROM    (
                            SELECT distinct TOP '  + @pagemax +  

                            @select + ', ROW_NUMBER() OVER( ' + @strOrder + ' ) AS row 
                            FROM    ' + @strSQL + '
                            WHERE   ' + @strWhere + @strOrder + '
                          ) AS tbl
                  WHERE
                          row > ' +  @pagemin)


    EXEC('SELECT top 1 row FROM    (
                            SELECT distinct TOP '  + @pagetotal +  

                            @select + ', ROW_NUMBER() OVER( ' + @strOrder + ' ) AS row 
                            FROM    ' + @strSQL + '
                            WHERE   ' + @strWhere + '
                          ) AS tbl ' + @strOrderTotal)



");

            Sql(@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--==========================================================================================
--modified by Ken So 19/05/2009
--change track_unit to general_eq_unit
-- 8 May 2009 Irina : compt.comparttype_auto as comparttypeid
-- modified by Yasitha 30/05/2007 (Spec:ECUNDERCARRIAGEVIEW02)
--By Rumesh MM on 12/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
--
-- Modified By:	Nouman | PRN9696, Done formatting and added the condition (ti.last_interp_date is not null)
-- Modified By:	NB | 10-06-16 | PRN10921
--
-- Test Run: Exec return_track_inspection_analyse @evala=1,@evalb=1,@evalc=1,@evalx=1,@pagenumber=1,@perpage=50
--==========================================================================================
					   
ALTER procedure [dbo].[return_track_inspection_analyse]
      @evala			BIT,
      @evalb			BIT,
      @evalc			BIT,
      @evalx			BIT,
      @pagenumber		INT,
      @perpage			INT,
      @status			VARCHAR(12) = NULL,
      @equip_search		VARCHAR(50) = NULL,
      @startdate		DATETIME	= NULL,
      @enddate          DATETIME	= NULL,
      @make_auto		INT = 0,
      @model_auto       INT = 0,
      @type_auto        INT = 0,
      @compartid_auto	INT = 0,
      @customer_auto	BIGINT = 0,
      @crsf_auto        BIGINT = 0,
      @user_auto        BIGINT = 0,
      @dealership_auto  SMALLINT = 0

AS
SET NOCOUNT ON

DECLARE @strTempTblName VARCHAR(100)
DECLARE @str VARCHAR(8000)
DECLARE @str1 VARCHAR(8000)
DECLARE @str2 VARCHAR(8000)
--filter only active customer 
DECLARE @custactive TINYINT
SET @custactive = 1 

--************************************ create temporary table
SET @strTempTblName = '##anpage' + REPLACE(CAST(NEWID() AS VARCHAR(90)), '-', '')
EXEC('CREATE TABLE [dbo].[' + @strTempTblName + '] (
      [id_auto] [int] IDENTITY (1, 1) NOT NULL ,
      [serialno] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
   ) ON [PRIMARY]')

EXEC('ALTER TABLE [dbo].[' + @strTempTblName + '] WITH NOCHECK ADD 
          CONSTRAINT [PK_' + @strTempTblName + '] PRIMARY KEY  CLUSTERED ([id_auto]) ON [PRIMARY]')

EXEC('CREATE  INDEX [PK] ON [dbo].[' + @strTempTblName + ']([id_auto],[serialno]) ON [PRIMARY]')


SET @str1 ='INSERT INTO [dbo].[' + @strTempTblName + '] SELECT DISTINCT aa.serialno FROM '

SET @str  =' SELECT  DISTINCT TOP '  + CAST((10*@perpage) AS VARCHAR) + ' eq.serialno 
			 FROM CRSF 
				INNER JOIN	EQUIPMENT eq ON dbo.CRSF.crsf_auto = eq.crsf_auto 
				INNER JOIN  GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto 
				INNER JOIN  TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto 
				INNER JOIN  TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto 
				INNER JOIN  LU_MMTA mmta ON eq.mmtaid_auto = mmta.mmtaid_auto '
				

--if dbo.fn_return_internal_emp_status(@user_auto) = 0 and @user_auto <> 0 set @str = @str + ' INNER JOIN  USER_CRSF_CUST_EQUIP user_crsf ON crsf.crsf_auto = user_crsf.crsf_auto '

SET @str=@str + 'INNER JOIN LU_COMPART comp ON comp.compartid_auto = geu.compartid_auto   AND comp.progid = 8 '


IF @status='email'		SET @str=@str + 'INNER JOIN TRACK_MESSAGE smsg ON ti.inspection_auto = smsg.inspection_auto '
IF @status='action' 	SET @str=@str + 'INNER JOIN (select ga.* from TRACK_ACTION ga INNER JOIN TRACK_ACTION_TAKEN gat ON gat.action_auto = ga.action_auto) at ON ti.inspection_auto = at.inspection_auto '
IF @status='image' 		SET @str=@str + 'INNER JOIN TRACK_IMAGE img ON ti.inspection_auto = img.inspection_auto '
IF @status='solved' 	SET @str=@str + 'INNER JOIN TRACK_ACTION ps ON ti.inspection_auto = ps.inspection_auto and ps.problem_solved = 1 '
IF @status='confirm' 	SET @str=@str + 'INNER JOIN TRACK_INSPECTION cn ON ti.inspection_auto = cn.inspection_auto and cn.confirmed_date is not null '
IF @status='notconfirm'	SET @str=@str + 'INNER JOIN TRACK_INSPECTION ncn ON ti.inspection_auto = ncn.inspection_auto and ncn.confirmed_date is null '

SET @str=@str + '  WHERE 1=1 and len(isnull(ti.last_interp_user,'''')) > 0 AND ti.released_date IS NOT NULL '

--set @str=@str + '  WHERE 1=1 '

--If the user is a customer need to filter on this
--IF dbo.fn_return_internal_emp_status(@user_auto) = 0 AND @user_auto <> 0  -- the user is not internal employee
--    SET @str = @str + ' AND eq.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(' + CAST(@user_auto AS VARCHAR) + ')) '
--if dbo.fn_return_internal_emp_status(@user_auto) = 0 and @user_auto <> 0 set @str = @str + ' and user_crsf.user_auto = ''' + cast(@user_auto as varchar) + ''' ' + ' AND user_crsf.level_type = 2 '

IF @startdate IS NOT NULL	SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  >= ''' + CONVERT(VARCHAR(8), @startdate, 112) + ''' '
IF @enddate IS NOT NULL		SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  <= ''' + CONVERT(VARCHAR(8), @enddate, 112) + ''' '


IF @equip_search IS NOT NULL AND @equip_search <> ''
   SET @str=@str + ' AND (eq.serialno LIKE ''%' + @equip_search + '%'' OR eq.unitno LIKE ''%' + @equip_search + '%'') '
---------------------------------------------------------------------------------------------------------------------

IF @customer_auto	IS NOT NULL AND @customer_auto <> 0 SET @str=@str + 'AND CRSF.customer_auto = ' + CAST(@customer_auto AS VARCHAR) + ' '
IF @crsf_auto		IS NOT NULL AND @crsf_auto <>0		SET @str=@str + 'AND CRSF.crsf_auto = ' + CAST(@crsf_auto AS VARCHAR) + ' '
IF @type_auto		IS NOT NULL AND @type_auto <> 0     SET @str=@str + 'AND mmta.type_auto = ' + CAST(@type_auto AS VARCHAR) + ' '
IF @make_auto		IS NOT NULL AND @make_auto <> 0     SET @str=@str + 'AND mmta.make_auto = ' + CAST(@make_auto AS VARCHAR) + ' '
IF @model_auto		IS NOT NULL AND @model_auto <> 0    SET @str=@str + 'AND mmta.model_auto = ' + CAST(@model_auto AS VARCHAR) + ' '
IF @compartid_auto	IS NOT NULL AND @compartid_auto <> 0  SET @str=@str + 'AND comp.compartid_auto = ' + CAST(@compartid_auto AS VARCHAR) + ' '
--IF @dealership_auto IS NOT NULL AND @dealership_auto <> 0 SET @str=@str + ' AND r.dealership_auto = ' + CAST(@dealership_auto AS VARCHAR) + ' '        
  
 
--set @str=@str + ' ORDER BY eq.serialno ASC' 
PRINT @str
EXEC(@str1 + '(' + '(' + @str + ')' + ')aa' + ' ORDER BY serialno ')
PRINT(@str1 + '(' + '(' + @str + ')' + ')aa' + ' ORDER BY serialno ')

EXEC('select count(*) as unitscount from [dbo].[' + @strTempTblName + ']')

--************************************ execute delete statement
SET @str = 'DELETE FROM [dbo].[' + @strTempTblName + '] WHERE id_auto <= ' + CAST(@perpage*(@pagenumber-1) AS VARCHAR) + ' OR id_auto > ' + CAST(@perpage*@pagenumber AS VARCHAR)+ ' '
EXEC(@str)
--print @str

--************************************ final select statement
SET @str = 'SELECT * FROM 
				(SELECT DISTINCT equip.equipmentid_auto, ti.inspection_auto, equip.serialno, equip.unitno, mod.modeldesc,cust.cust_name 
				--PRN10921
							,(SELECT STUFF(
											(SELECT  '', '' + CASE WHEN geu.side = 1 THEN ''L ('' + lms.Serialno + '')'' ELSE ''R ('' + lms.Serialno + '')'' END
												FROM LU_Module_Sub lms
													INNER JOIN GENERAL_EQ_UNIT geu ON lms.Module_sub_auto = geu.module_ucsub_auto
													INNER JOIN EQUIPMENT e on geu.equipmentid_auto = e.equipmentid_auto
													INNER JOIN LU_COMPART lc on lc.compartid_auto = geu.compartid_auto
													INNER JOIN LU_COMPART_TYPE lct on lc.comparttype_auto = lct.comparttype_auto
											WHERE e.equipmentid_auto = equip.equipmentid_auto AND lct.comparttype = ''Link'' 
											FOR XML PATH('''')),1,1,'''')) AS [ChainNumber]
				,cust.custid, mak.makedesc,  ti.inspection_date,
							isnull(ti.evalcode,(select max(eval_code) from track_inspection_detail where inspection_auto = tid.inspection_auto)) as eval_code, ti.smu, ps.inspection_auto AS ssolved, 
							atn.action_auto AS saction, smsg.inspection_auto AS smg,case  ISNULL(confirmed_date,0)   when ''1900-01-01 00:00:00.000'' then 0  ELSE 1 end confirmed,
							img.inspection_auto AS simage, cust.customer_auto,  mod.model_auto,CRSF.crsf_auto
							
							

				FROM       MAKE mak 
					INNER JOIN	LU_MMTA ON mak.make_auto = dbo.LU_MMTA.make_auto 
					INNER JOIN  MODEL mod ON dbo.LU_MMTA.model_auto = mod.model_auto 
					INNER JOIN  EQUIPMENT equip ON dbo.LU_MMTA.mmtaid_auto = equip.mmtaid_auto 
					INNER JOIN  CRSF  ON equip.crsf_auto = CRSF.crsf_auto 
					INNER JOIN  CUSTOMER cust ON dbo.CRSF.customer_auto = cust.customer_auto 
					INNER JOIN  GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = equip.equipmentid_auto 
					INNER JOIN  LU_COMPART comp ON comp.compartid_auto = geu.compartid_auto 
					INNER JOIN  LU_COMPART_TYPE compt ON compt.comparttype_auto = comp.comparttype_auto 
					INNER JOIN  TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto 
					INNER JOIN  TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto 
					INNER JOIN  [dbo].[' + @strTempTblName + '] t ON equip.serialno = t.serialno
					
					LEFT OUTER JOIN	TRACK_MESSAGE smsg ON tid.inspection_auto = smsg.inspection_auto 
					LEFT OUTER JOIN TRACK_ACTION at ON tid.inspection_auto = at.inspection_auto AND at.problem_solved = 0  
					LEFT OUTER JOIN (
										SELECT ga.* FROM TRACK_ACTION ga 
											INNER JOIN TRACK_ACTION_TAKEN gat ON gat.action_auto = ga.action_auto 
									) atn ON ti.inspection_auto = atn.inspection_auto  
					LEFT OUTER JOIN TRACK_ACTION ps ON tid.inspection_auto = ps.inspection_auto AND ps.problem_solved = 1 
					LEFT OUTER JOIN	TRACK_IMAGE img ON tid.inspection_auto = img.inspection_auto 
  '
SET @str=@str + 'WHERE 1=1  AND ti.last_interp_date is not null AND ti.released_date IS NOT NULL ' --PRN9696 - added - and ti.last_interp_date is not null

IF(@custactive IS NOT NULL AND @custactive = 1)
	SET @str = @str + 'AND cust.active = 1 '
--IF dbo.fn_return_internal_emp_status(@user_auto) = 0
--	SET @str = @str + ' AND equip.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(' + cast(@user_auto as varchar) + '))'

IF @status IS NOT NULL AND @status <> '0'  and @status <> ''
BEGIN
     IF @status='confirm'		SET @str=@str + 'AND ti.confirmed_date IS NOT NULL ' 
     IF @status='notconfirm'	SET @str=@str + 'AND ti.confirmed_date IS NULL '
     IF @status='action'		SET @str=@str + 'AND atn.action_auto IS NOT NULL '
     IF @status='email'			SET @str=@str + 'AND smsg.inspection_auto IS NOT NULL ' 
     IF @status='solved'		SET @str=@str + 'AND ps.inspection_auto IS NOT NULL '
     IF @status='image'			SET @str=@str + 'AND img.inspection_auto IS NOT NULL '
END

IF @startdate	IS NOT NULL		SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  >= ''' + CONVERT(VARCHAR(8), @startdate, 112) + ''' '
IF @enddate		IS NOT NULL		SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  <= ''' + CONVERT(VARCHAR(8), @enddate, 112) + ''' '
/*
--set @str=@str + 'and (ti.evalcode  = ''A'' or ti.evalcode = ''B'' or ti.evalcode  = ''C'' or ti.evalcode = ''X'') '
set @str=@str + 'and (eval_code = ''A'' or eval_code = ''B'' or eval_code = ''C''  or eval_code = ''X'' or eval_code = ''-'') '

if @evala = 0 set @str=replace(@str,'eval_code = ''A'' or ','')
if @evalb = 0 set @str=replace(@str,'eval_code = ''B'' or ','')
if @evalc = 0 set @str=replace(@str,'eval_code = ''C'' or ','')
--if @evalx = 0 set @str=replace(@str,'or ti.evalcode  = ''X''','')
if @evalx = 0 set @str=replace(@str,'eval_code = ''X'' or ','')
*/

SET @str = @str + '	) aa WHERE (aa.eval_code LIKE ''%-%'' OR aa.eval_code LIKE ''%A%'' OR aa.eval_code LIKE ''%B%'' OR aa.eval_code LIKE ''%C%'' OR aa.eval_code LIKE ''%X%'' ) '	

IF @evala = 0 SET @str = REPLACE(@str,'aa.eval_code LIKE ''%A%'' OR ','')
IF @evalb = 0 SET @str = REPLACE(@str,'aa.eval_code LIKE ''%B%'' OR ','')
IF @evalc = 0 SET @str = REPLACE(@str,'aa.eval_code LIKE ''%C%'' OR ','')
IF @evalx = 0 SET @str = REPLACE(@str,'OR aa.eval_code LIKE ''%X%''','')

SET @str=@str + 'ORDER BY aa.serialno ASC, aa.unitno ASC,  aa.inspection_date DESC '
EXEC(@str)

PRINT @str

EXEC('DROP TABLE [dbo].[' + @strTempTblName + ']')

");
        }
        
        public override void Down()
        {
            DropColumn("dbo.INSPECTION_COMPARTTYPE_RECORD", "ObservationNote");
            Sql(@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Brendan - 16th June 2017
-- Added more allowances for special characters
--===========================================
-- Tracy T : 27th Apr 2011 - added option to filter on active warranty
--====================================
-- Irina M 11 March 2011
-- added the ability to show data for inactive customers
--===========================================================================================
-- Tracy T : 10th Nov 2010
-- model now nvarchar, also fixed customer search for nvarchar
--============================
-- Daniel Shi 3 Nov 2010
-- handled apostrophe symbols in query strings
--===========================================================================================
-- Prasanna on 14th Sept 2010 
-- Return only user assigned equipment details on customer login. 
--=================================================
-- Daniel S 24 Aug 2010
-- added a search condition: regno
--=================================================
-- Rumesh MM 2010-08-15
-- Added the sorting functionality to the page
--=================================================
-- Tracy T 28th Apr 2010
-- Found a bug when selecting 'Include Compart' info it only showed compartment if Oil type and Grade existed
-- So changed the joins.
--=================================================
-- Modified 25 Feb 2009 Irina
-- use field equip_status instead of status in EQUIPMENT
--===================================================================
-- Modified 10th Nov 2008 Tracy Thompson
-- changed from global table to not using temp tables at all
--===================================================================
-- Modified 24 Oct 2007 Irina
-- order of fields was changed as it is in use in HTTPHandlers : GetEquipmentSearchDetails  
--     8 = crsf_auto; 9-customer_auto, 10 - equipment_auto
--======================================================================================================			
ALTER PROCEDURE [dbo].[return_equipment_search_4T]
	@search_serialno	varchar(20)	='contains',
	@search_unitno		varchar(20)	='contains',
	@search_cust_name	varchar(20)	='contains',
	@search_custid		varchar(20)	='contains',
	@search_jobsite		varchar(20)	='contains',
	@search_modeldesc	varchar(20)	='contains',
	@search_makedesc	varchar(20)	='contains',	
	@serialno 			varchar(50)	=null,
	@unitno				varchar(50)	=null,
	@cust_name			nvarchar(100) =null,
	@custid				varchar(20)	=null,
	@jobsite			varchar(100) =null,
	@modeldesc			nvarchar(50)	=null,
	@makedesc			varchar(50)	=null,
	@perpage			int,
	@pagenumber			int,
	@search_type		varchar(20) ='compartment',--Modified by Jerry 27th March 2007, return result filter by compart or equipment
	@oiltypedesc		varchar(50)	=null,
	@oilgradedesc		varchar(50)	=null,
	@search_oiltypedesc	varchar(20)	='contains',
	@search_oilgradedesc varchar(20) ='contains',
    @csno               varchar(50)  = null,
    @search_csn         varchar(20)  = 'contains',
	@debug				bit = 0,
	@sortOrder			tinyint=0,
	@order				tinyint=0,
	@search_regno		varchar(20)	='contains',
	@regno				varchar(50)	=null,
	@user_auto			bigint = 0,
	@customer_login		bit = 0 ,	--Only when a customer doing a search to filter own equipments only
	@chkInclInactiveCust tinyint=0,    -- to show Inactive Customer data
	@chkWarranty		bit = 0,  -- if this is on we need to filter by equipment on warranty only
	@template_auto INT = 0
AS

	if @debug = 1 SET NOCOUNT ON 

--Allow special characters
	set @serialno = replace(@serialno, '%20', ' ')
	set @serialno = replace(@serialno, '%7E', '~')
	set @serialno = replace(@serialno, '%21', '!')
	set @serialno = replace(@serialno, '%40', '@')
	set @serialno = replace(@serialno, '%23', '#')
	set @serialno = replace(@serialno, '%24', '$')
	set @serialno = replace(@serialno, '%25', '%')
	set @serialno = replace(@serialno, '%5E', '^')
	set @serialno = replace(@serialno, '%26', '&')
	set @serialno = replace(@serialno, '%2A', '*')	
	set @serialno = replace(@serialno, '%28', '(')
	set @serialno = replace(@serialno, '%29', ')')
	
	set @unitno = replace(@unitno, '%20', ' ')
	set @unitno = replace(@unitno, '%7E', '~')		
	set @unitno = replace(@unitno, '%21', '!')
	set @unitno = replace(@unitno, '%40', '@')
	set @unitno = replace(@unitno, '%23', '#')
	set @unitno = replace(@unitno, '%24', '$')
	set @unitno = replace(@unitno, '%25', '%')
	set @unitno = replace(@unitno, '%5E', '^')
	set @unitno = replace(@unitno, '%26', '&')
	set @unitno = replace(@unitno, '%2A', '*')
	set @unitno = replace(@unitno, '%28', '(')
	set @unitno = replace(@unitno, '%29', ')')

	--End Special characters

	set @serialno = ltrim(RTRIM(@serialno))
	set @unitno = ltrim(RTRIM(@unitno))

	set @custid =Replace(@custid,'''','''''')
	set @makedesc =Replace(@makedesc,'''','''''')
	set @modeldesc =Replace(@modeldesc,'''','''''')

    set @csno = dbo.fnReplaceCharacters(@csno)
	
	Declare @strSQL 	varchar(MAX)
	Declare @select		varchar(MAX)
	Declare @strWhere	nvarchar(4000)
	
	Declare	@strOrder	varchar(200)
	Declare @strOrderTotal varchar(200)

	Declare @blnwhere	bit
	Declare @pagemin varchar(10)
	Declare @pagemax varchar(10)
	Declare @pagetotal varchar(10)
	
	set @pagemin = cast(@perpage*(@pagenumber-1) as varchar)
	set @pagemax = cast((@pagenumber*@perpage) as varchar) 
	set @pagetotal = cast((10*@perpage) as varchar) 

	select @strSQL='',@strWhere='',@select=''
	-- 11 March 2011 Irina - 
	if @chkInclInactiveCust=0
		set @strWhere = ' cu.active = 1 '
    else 
		set @strWhere = ' 1=1 '


if(@template_auto <> 0)
begin
	declare @equipmentStr  nvarchar(max)
	
	select @equipmentStr = isnull(equipmentidString ,  '0') from SELECTION_TEMPLATES where seltemplate_auto =   @template_auto

	if @equipmentStr <> ''
		set @strWhere = @strWhere 
					+ ' and eq.equipmentid_auto in (' + @equipmentStr + ')'

end
	if @chkWarranty = 1
		set @strWhere = @strWhere 
					+ ' and ((eq.equipmentid_auto in 
							(SELECT     equipmentid_auto
							 FROM         WARRANTY_EQUIPMENT
							 WHERE     (wty_expired IS NULL)) OR 
							(eq.equipmentid_auto in 
							(SELECT     equipmentid_auto
							 FROM         WARRANTY_COMPONENT
							 WHERE     (wty_expired IS NULL)))))'
           
    --serial number
	if @serialno is not null AND @serialno <> 'null' and @serialno <> ''
	Begin
		set @serialno = dbo.fnReplaceCharacters(@serialno)
		if @search_serialno = 'begins' 		set @strWhere = @strWhere + ' AND (eq.serialno LIKE ''' + @serialno + '%'') '
		if @search_serialno = 'ends' 		set @strWhere = @strWhere + ' AND (eq.serialno LIKE ''%' + @serialno + ''') '
		if @search_serialno = 'contains' 	set @strWhere = @strWhere + ' AND (eq.serialno LIKE ''%' + @serialno + '%'') '
		if @search_serialno = 'equals' 		set @strWhere = @strWhere + ' AND ( ltrim(rtrim(eq.serialno)) = ''' + @serialno + ''') '
	End

    --regno
	if @regno is not null and @regno <> '' AND @regno <> 'null' and @regno <> ''
	Begin
		set @regno = dbo.fnReplaceCharacters(@regno)
		if @search_regno = 'begins' 		set @strWhere = @strWhere + ' AND (eq.regno LIKE ''' + @regno + '%'') '
		if @search_regno = 'ends' 			set @strWhere = @strWhere + ' AND (eq.regno LIKE ''%' + @regno + ''') '
		if @search_regno = 'contains' 		set @strWhere = @strWhere + ' AND (eq.regno LIKE ''%' + @regno + '%'') '
		if @search_regno = 'equals' 		set @strWhere = @strWhere + ' AND (eq.regno = ''' + @regno + ''') '
	End

	--unit number
	if @unitno is not null	 AND @unitno <> 'null' and @unitno <> ''
	Begin	
		set @unitno = dbo.fnReplaceCharacters(@unitno)
		if @search_unitno = 'begins' 	set @strWhere = @strWhere + ' AND (eq.unitno LIKE ''' + @unitno + '%'') '
		if @search_unitno = 'ends' 		set @strWhere = @strWhere + ' AND (eq.unitno LIKE ''%' + @unitno + ''') '
		if @search_unitno = 'contains' 	set @strWhere = @strWhere + ' AND (eq.unitno LIKE ''%' + @unitno + '%'') '
		if @search_unitno = 'equals' 	set @strWhere = @strWhere + ' AND (eq.unitno = ''' + @unitno + ''') '
	End

	--customer name
	if @cust_name is not null	 AND @cust_name <> 'null' and @cust_name <> ''
	Begin
		set @cust_name = dbo.fnReplaceCharacters(@cust_name)
		if @search_cust_name = 'begins' 	set @strWhere = @strWhere + ' AND (cu.cust_name LIKE N''' + @cust_name + '%'') '
		if @search_cust_name = 'ends' 		set @strWhere = @strWhere + ' AND (cu.cust_name LIKE N''%' + @cust_name + ''') '
		if @search_cust_name = 'contains' 	set @strWhere = @strWhere + ' AND (cu.cust_name LIKE N''%' + @cust_name + '%'') '
		if @search_cust_name = 'equals' 	set @strWhere = @strWhere + ' AND (cu.cust_name = N''' + @cust_name + ''') '
	End

	--customer id
	if @custid is not null	 AND @custid <> 'null' and @custid <> ''
	Begin
		if @search_custid = 'begins' 	set @strWhere = @strWhere + ' AND (cu.custid LIKE ''' + @custid + '%'') '
		if @search_custid = 'ends' 		set @strWhere = @strWhere + ' AND (cu.custid LIKE ''%' + @custid + ''') '
		if @search_custid = 'contains'	set @strWhere = @strWhere + ' AND (cu.custid LIKE ''%' + @custid + '%'') '
		if @search_custid = 'equals' 	set @strWhere = @strWhere + ' AND (cu.custid = ''' + @custid + ''') '
	End
	
	--job site
	if @jobsite is not null AND @jobsite <> 'null' and @jobsite <> ''
	Begin
		set @jobsite = dbo.fnReplaceCharacters(@jobsite)
		if @search_jobsite = 'begins' 	set @strWhere = @strWhere + ' AND (CRSF.site_name LIKE ''' + @jobsite + '%'') '
		if @search_jobsite = 'ends' 	set @strWhere = @strWhere + ' AND (CRSF.site_name LIKE ''%' + @jobsite + ''') '
		if @search_jobsite = 'contains'	set @strWhere = @strWhere + ' AND (CRSF.site_name LIKE ''%' + @jobsite + '%'') '
		if @search_jobsite = 'equals' 	set @strWhere = @strWhere + ' AND (CRSF.site_name = ''' + @jobsite + ''') '
	End
	
	--modeldesc
	if @modeldesc is not null AND @modeldesc <> 'null' and @modeldesc <> ''
	Begin
		if @search_modeldesc = 'begins' 	set @strWhere = @strWhere + ' AND (mod.modeldesc LIKE N''' + @modeldesc + '%'') '
		if @search_modeldesc = 'ends' 		set @strWhere = @strWhere + ' AND (mod.modeldesc LIKE N''%' + @modeldesc + ''') '
		if @search_modeldesc = 'contains' 	set @strWhere = @strWhere + ' AND (mod.modeldesc LIKE N''%' + @modeldesc + '%'') '
		if @search_modeldesc = 'equals' 	set @strWhere = @strWhere + ' AND (mod.modeldesc = N''' + @modeldesc + ''') '
	End

	--makedesc
	if @makedesc is not null AND @makedesc <> 'null' and @makedesc <> ''
	Begin
		if @search_makedesc = 'begins' 		set @strWhere = @strWhere + ' AND (mak.makedesc LIKE ''' + @makedesc + '%'') '
		if @search_makedesc = 'ends' 		set @strWhere = @strWhere + ' AND (mak.makedesc LIKE ''%' + @makedesc + ''') '
		if @search_makedesc = 'contains' 	set @strWhere = @strWhere + ' AND (mak.makedesc LIKE ''%' + @makedesc + '%'') '
		if @search_makedesc = 'equals' 		set @strWhere = @strWhere + ' AND (mak.makedesc = ''' + @makedesc + ''')  '
	End

	--user_auto 
	if @customer_login = 1 and @user_auto is not null
		set @strWhere = @strWhere + 'and eq.equipmentid_auto in (SELECT * FROM dbo.fnEquipment('+ cast(@user_auto as varchar)+')) '

	DECLARE @status tinyint
	SET @status = dbo.fnUserInternalAccessStatus(@user_auto)

	IF @status = 1
		set @strWhere = @strWhere + ' and ((cu.labonly <> 1) OR (cu.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =eq.equipmentid_auto)) '
	else if @status = 0 and @user_auto <> 0
		set @strWhere = @strWhere + 'and eq.equipmentid_auto in (SELECT * FROM dbo.fnEquipment('+ cast(@user_auto as varchar)+')) ' --PRN 7233

	IF @search_type = 'compartment'
	BEGIN
		---- 11 March 2011 Irina - 
		set @select = ' eq.serialno, eq.unitno
			, cu.custid + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) as custid
			, cu.cust_name + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) as Customer
			, mak.makedesc, mod.modeldesc
			, oequ.compartsn, lc.compart, lot.oiltypedesc as oil_type, [log].oilgradedesc as oil_grade
			, dbo.CRSF.site_name as location, CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END as status
			, cu.customer_auto, eq.crsf_auto, eq.equipmentid_auto, cu.active  , ISNULL(eq.regno, '''') as [Reg. No] '

		set @strSQL = '   dbo.CRSF INNER JOIN
                dbo.EQUIPMENT AS eq ON CRSF.crsf_auto = eq.crsf_auto INNER JOIN
                dbo.CUSTOMER AS cu ON CRSF.customer_auto = cu.customer_auto INNER JOIN
                dbo.LU_MMTA ON eq.mmtaid_auto = LU_MMTA.mmtaid_auto INNER JOIN
                dbo.MAKE AS mak ON LU_MMTA.make_auto = mak.make_auto INNER JOIN
                dbo.MODEL AS mod ON LU_MMTA.model_auto = mod.model_auto LEFT OUTER JOIN
                dbo.OIL_EQ_UNIT AS oequ INNER JOIN
                dbo.LU_COMPART AS lc ON oequ.compartid_auto = lc.compartid_auto LEFT OUTER JOIN
                dbo.LU_OILTYPE AS lot ON lot.oiltype_auto = oequ.oiltype_auto LEFT OUTER JOIN
                dbo.LU_OILGRADE AS [log] ON [log].oilgrade_auto = oequ.oilgrade_auto ON eq.equipmentid_auto = oequ.equipmentid_auto 
				LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		cu.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar) + ''

		--Modified to filter based on oil type description and oil grade description for compartment
		-- compart serial number
--		print (@select + @strSQL)
		if @csno is not null
		Begin
			if @search_csn = 'begins' 	set @strWhere = @strWhere + ' AND (oequ.compartsn LIKE ''' + @csno + '%'') '
			if @search_csn = 'ends'    	set @strWhere = @strWhere + ' AND (oequ.compartsn LIKE ''%' + @csno + ''') '
			if @search_csn = 'contains' set @strWhere = @strWhere + ' AND (oequ.compartsn LIKE ''%' + @csno + '%'') '
			if @search_csn = 'equals' 	set @strWhere = @strWhere + ' AND (oequ.compartsn = ''' + @csno + ''') '
		End
		
             --oiltypedesc
		if @oiltypedesc is not null
		Begin
			if @search_oiltypedesc = 'begins' 		set @strWhere = @strWhere + ' AND (lot.oiltypedesc LIKE ''' + @oiltypedesc + '%'') '
			if @search_oiltypedesc = 'ends' 		set @strWhere = @strWhere + ' AND (lot.oiltypedesc LIKE ''%' + @oiltypedesc + ''') '
			if @search_oiltypedesc = 'contains' 	set @strWhere = @strWhere + ' AND (lot.oiltypedesc LIKE ''%' + @oiltypedesc + '%'') '
			if @search_oiltypedesc = 'equals' 		set @strWhere = @strWhere + ' AND (lot.oiltypedesc = ''' + @oiltypedesc + ''') '
		End

		--oilgradedesc
		if @oilgradedesc is not null
		Begin
			if @search_oilgradedesc = 'begins' 		set @strWhere = @strWhere + ' AND (log.oilgradedesc LIKE ''' + @oilgradedesc + '%'') '
			if @search_oilgradedesc = 'ends' 		set @strWhere = @strWhere + ' AND (log.oilgradedesc LIKE ''%' + @oilgradedesc + ''') '
			if @search_oilgradedesc = 'contains' 	set @strWhere = @strWhere + ' AND (log.oilgradedesc LIKE ''%' + @oilgradedesc + '%'') '
			if @search_oilgradedesc = 'equals' 		set @strWhere = @strWhere + ' AND (log.oilgradedesc = ''' + @oilgradedesc + ''') '
		End 

	END
	ELSE IF @search_type = 'equipment'
	BEGIN
		set @select = ' eq.serialno, eq.unitno
			, cu.custid + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) as custid
			, cu.cust_name + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) as Customer
			, mak.makedesc, mod.modeldesc
			, dbo.CRSF.site_name as location, CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END as status
			,   cu.customer_auto, eq.crsf_auto,eq.equipmentid_auto, cu.active , ISNULL(eq.regno, '''') as [Reg. No]'
				
		set @strSQL = '                     
			dbo.EQUIPMENT eq   INNER JOIN	                           
			dbo.CRSF ON eq.crsf_auto = dbo.CRSF.crsf_auto INNER JOIN
			dbo.CUSTOMER cu ON dbo.CRSF.customer_auto = cu.customer_auto INNER JOIN
			dbo.LU_MMTA ON eq.mmtaid_auto = dbo.LU_MMTA.mmtaid_auto INNER JOIN
			dbo.MAKE mak ON LU_MMTA.make_auto = mak.make_auto INNER JOIN
			dbo.MODEL mod ON LU_MMTA.model_auto = mod.model_auto 
			LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		cu.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar) + ''
	END

	--set the order by clause
	set @strOrder = ' ORDER BY eq.serialno ASC, eq.unitno ASC '

	if @sortOrder = 1 and @order=1
		set @strOrder= ' ORDER BY eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 1 and @order=2
		set @strOrder= ' ORDER BY eq.serialno DESC, eq.unitno ASC '
	if @sortOrder = 2 and @order=1
		set @strOrder= ' ORDER BY eq.unitno ASC, eq.serialno ASC '
	if @sortOrder = 2 and @order=2
		set @strOrder= ' ORDER BY eq.unitno DESC, eq.serialno ASC '
	if @sortOrder = 3 and @order=1
		set @strOrder= ' ORDER BY cu.custid + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end)  ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 3 and @order=2
		set @strOrder= ' ORDER BY cu.custid + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 4 and @order=1
		set @strOrder= ' ORDER BY cu.cust_name + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 4 and @order=2
		set @strOrder= ' ORDER BY cu.cust_name + (case when ISNULL(cu.active,0)=0 then ''(Inactive)'' else '''' end) DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 5 and @order=1
		set @strOrder= ' ORDER BY mak.makedesc ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 5 and @order=2
		set @strOrder= ' ORDER BY mak.makedesc DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 6 and @order=1
		set @strOrder= ' ORDER BY mod.modeldesc ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 6 and @order=2
		set @strOrder= ' ORDER BY mod.modeldesc DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 7 and @order=1
		set @strOrder= ' ORDER BY CRSF.site_name ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 7 and @order=2
		set @strOrder= ' ORDER BY CRSF.site_name DESC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 8 and @order=1
		set @strOrder= ' ORDER BY CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END  ASC, eq.serialno ASC, eq.unitno ASC '
	if @sortOrder = 8 and @order=2
		set @strOrder= ' ORDER BY CASE eq.equip_status WHEN 1 THEN ''In use'' WHEN 2 THEN ''Parked'' WHEN 3 THEN ''Rental'' ELSE ''Not in use'' END  DESC, eq.serialno ASC, eq.unitno ASC '

set @strOrderTotal = ' ORDER BY row desc '

print (@select + @strSQL + @strWhere + @strOrder)

if @debug = 1 
	print('SELECT *  FROM    (
								SELECT distinct TOP '  + @pagemax +  
								@select + ', ROW_NUMBER() OVER( ' + @strOrder + ' ) AS row 
								FROM    ' + @strSQL + '
								WHERE   ' + @strWhere + @strOrder + '
							  ) AS tbl
					  WHERE
							  row > ' +  @pagemin)
							  
	EXEC ('SELECT *  FROM    (
                            SELECT distinct TOP '  + @pagemax +  
							@select + ', ROW_NUMBER() OVER( ' + @strOrder + ' ) AS row 
                            FROM    ' + @strSQL + '
                            WHERE   ' + @strWhere + @strOrder + '
                          ) AS tbl
                  WHERE
                          row > ' +  @pagemin)

	EXEC ('SELECT top 1 row FROM    (
                            SELECT  distinct TOP '  + @pagetotal +  
							@select + ', ROW_NUMBER() OVER( ' + @strOrder + ' ) AS row 
                            FROM    ' + @strSQL + '
                            WHERE   ' + @strWhere + '
                          ) AS tbl ' + @strOrderTotal)


                ");

            Sql(@"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--==========================================================================================
--modified by Ken So 19/05/2009
--change track_unit to general_eq_unit
-- 8 May 2009 Irina : compt.comparttype_auto as comparttypeid
-- modified by Yasitha 30/05/2007 (Spec:ECUNDERCARRIAGEVIEW02)
--By Rumesh MM on 12/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
--
-- Modified By:	Nouman | PRN9696, Done formatting and added the condition (ti.last_interp_date is not null)
-- Modified By:	NB | 10-06-16 | PRN10921
--
-- Test Run: Exec return_track_inspection_analyse @evala=1,@evalb=1,@evalc=1,@evalx=1,@pagenumber=1,@perpage=50
--==========================================================================================
					   
ALTER procedure [dbo].[return_track_inspection_analyse]
      @evala			BIT,
      @evalb			BIT,
      @evalc			BIT,
      @evalx			BIT,
      @pagenumber		INT,
      @perpage			INT,
      @status			VARCHAR(12) = NULL,
      @equip_search		VARCHAR(50) = NULL,
      @startdate		DATETIME	= NULL,
      @enddate          DATETIME	= NULL,
      @make_auto		INT = 0,
      @model_auto       INT = 0,
      @type_auto        INT = 0,
      @compartid_auto	INT = 0,
      @customer_auto	BIGINT = 0,
      @crsf_auto        BIGINT = 0,
      @user_auto        BIGINT = 0,
      @dealership_auto  SMALLINT = 0

AS
SET NOCOUNT ON

DECLARE @strTempTblName VARCHAR(100)
DECLARE @str VARCHAR(8000)
DECLARE @str1 VARCHAR(8000)
DECLARE @str2 VARCHAR(8000)
--filter only active customer 
DECLARE @custactive TINYINT
SET @custactive = 1 

--************************************ create temporary table
SET @strTempTblName = '##anpage' + REPLACE(CAST(NEWID() AS VARCHAR(90)), '-', '')
EXEC('CREATE TABLE [dbo].[' + @strTempTblName + '] (
      [id_auto] [int] IDENTITY (1, 1) NOT NULL ,
      [serialno] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
   ) ON [PRIMARY]')

EXEC('ALTER TABLE [dbo].[' + @strTempTblName + '] WITH NOCHECK ADD 
          CONSTRAINT [PK_' + @strTempTblName + '] PRIMARY KEY  CLUSTERED ([id_auto]) ON [PRIMARY]')

EXEC('CREATE  INDEX [PK] ON [dbo].[' + @strTempTblName + ']([id_auto],[serialno]) ON [PRIMARY]')


SET @str1 ='INSERT INTO [dbo].[' + @strTempTblName + '] SELECT DISTINCT aa.serialno FROM '

SET @str  =' SELECT  DISTINCT TOP '  + CAST((10*@perpage) AS VARCHAR) + ' eq.serialno 
			 FROM CRSF 
				INNER JOIN	EQUIPMENT eq ON dbo.CRSF.crsf_auto = eq.crsf_auto 
				INNER JOIN  GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = eq.equipmentid_auto 
				INNER JOIN  TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto 
				INNER JOIN  TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto 
				INNER JOIN  LU_MMTA mmta ON eq.mmtaid_auto = mmta.mmtaid_auto '
				

--if dbo.fn_return_internal_emp_status(@user_auto) = 0 and @user_auto <> 0 set @str = @str + ' INNER JOIN  USER_CRSF_CUST_EQUIP user_crsf ON crsf.crsf_auto = user_crsf.crsf_auto '

SET @str=@str + 'INNER JOIN LU_COMPART comp ON comp.compartid_auto = geu.compartid_auto   AND comp.progid = 8 '


IF @status='email'		SET @str=@str + 'INNER JOIN TRACK_MESSAGE smsg ON ti.inspection_auto = smsg.inspection_auto '
IF @status='action' 	SET @str=@str + 'INNER JOIN (select ga.* from TRACK_ACTION ga INNER JOIN TRACK_ACTION_TAKEN gat ON gat.action_auto = ga.action_auto) at ON ti.inspection_auto = at.inspection_auto '
IF @status='image' 		SET @str=@str + 'INNER JOIN TRACK_IMAGE img ON ti.inspection_auto = img.inspection_auto '
IF @status='solved' 	SET @str=@str + 'INNER JOIN TRACK_ACTION ps ON ti.inspection_auto = ps.inspection_auto and ps.problem_solved = 1 '
IF @status='confirm' 	SET @str=@str + 'INNER JOIN TRACK_INSPECTION cn ON ti.inspection_auto = cn.inspection_auto and cn.confirmed_date is not null '
IF @status='notconfirm'	SET @str=@str + 'INNER JOIN TRACK_INSPECTION ncn ON ti.inspection_auto = ncn.inspection_auto and ncn.confirmed_date is null '

SET @str=@str + '  WHERE 1=1 and len(isnull(ti.last_interp_user,'''')) > 0 AND ti.released_date IS NOT NULL '

--set @str=@str + '  WHERE 1=1 '

--If the user is a customer need to filter on this
IF dbo.fn_return_internal_emp_status(@user_auto) = 0 AND @user_auto <> 0  -- the user is not internal employee
    SET @str = @str + ' AND eq.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(' + CAST(@user_auto AS VARCHAR) + ')) '
--if dbo.fn_return_internal_emp_status(@user_auto) = 0 and @user_auto <> 0 set @str = @str + ' and user_crsf.user_auto = ''' + cast(@user_auto as varchar) + ''' ' + ' AND user_crsf.level_type = 2 '

IF @startdate IS NOT NULL	SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  >= ''' + CONVERT(VARCHAR(8), @startdate, 112) + ''' '
IF @enddate IS NOT NULL		SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  <= ''' + CONVERT(VARCHAR(8), @enddate, 112) + ''' '


IF @equip_search IS NOT NULL AND @equip_search <> ''
   SET @str=@str + ' AND (eq.serialno LIKE ''%' + @equip_search + '%'' OR eq.unitno LIKE ''%' + @equip_search + '%'') '
---------------------------------------------------------------------------------------------------------------------

IF @customer_auto	IS NOT NULL AND @customer_auto <> 0 SET @str=@str + 'AND CRSF.customer_auto = ' + CAST(@customer_auto AS VARCHAR) + ' '
IF @crsf_auto		IS NOT NULL AND @crsf_auto <>0		SET @str=@str + 'AND CRSF.crsf_auto = ' + CAST(@crsf_auto AS VARCHAR) + ' '
IF @type_auto		IS NOT NULL AND @type_auto <> 0     SET @str=@str + 'AND mmta.type_auto = ' + CAST(@type_auto AS VARCHAR) + ' '
IF @make_auto		IS NOT NULL AND @make_auto <> 0     SET @str=@str + 'AND mmta.make_auto = ' + CAST(@make_auto AS VARCHAR) + ' '
IF @model_auto		IS NOT NULL AND @model_auto <> 0    SET @str=@str + 'AND mmta.model_auto = ' + CAST(@model_auto AS VARCHAR) + ' '
IF @compartid_auto	IS NOT NULL AND @compartid_auto <> 0  SET @str=@str + 'AND comp.compartid_auto = ' + CAST(@compartid_auto AS VARCHAR) + ' '
--IF @dealership_auto IS NOT NULL AND @dealership_auto <> 0 SET @str=@str + ' AND r.dealership_auto = ' + CAST(@dealership_auto AS VARCHAR) + ' '        
  
 
--set @str=@str + ' ORDER BY eq.serialno ASC' 
PRINT @str
EXEC(@str1 + '(' + '(' + @str + ')' + ')aa' + ' ORDER BY serialno ')
PRINT(@str1 + '(' + '(' + @str + ')' + ')aa' + ' ORDER BY serialno ')

EXEC('select count(*) as unitscount from [dbo].[' + @strTempTblName + ']')

--************************************ execute delete statement
SET @str = 'DELETE FROM [dbo].[' + @strTempTblName + '] WHERE id_auto <= ' + CAST(@perpage*(@pagenumber-1) AS VARCHAR) + ' OR id_auto > ' + CAST(@perpage*@pagenumber AS VARCHAR)+ ' '
EXEC(@str)
--print @str

--************************************ final select statement
SET @str = 'SELECT * FROM 
				(SELECT DISTINCT equip.equipmentid_auto, ti.inspection_auto, equip.serialno, equip.unitno, mod.modeldesc,cust.cust_name 
				--PRN10921
							,(SELECT STUFF(
											(SELECT  '', '' + CASE WHEN geu.side = 1 THEN ''L ('' + lms.Serialno + '')'' ELSE ''R ('' + lms.Serialno + '')'' END
												FROM LU_Module_Sub lms
													INNER JOIN GENERAL_EQ_UNIT geu ON lms.Module_sub_auto = geu.module_ucsub_auto
													INNER JOIN EQUIPMENT e on geu.equipmentid_auto = e.equipmentid_auto
													INNER JOIN LU_COMPART lc on lc.compartid_auto = geu.compartid_auto
													INNER JOIN LU_COMPART_TYPE lct on lc.comparttype_auto = lct.comparttype_auto
											WHERE e.equipmentid_auto = equip.equipmentid_auto AND lct.comparttype = ''Link'' 
											FOR XML PATH('''')),1,1,'''')) AS [ChainNumber]
				,cust.custid, mak.makedesc,  ti.inspection_date,
							isnull(ti.evalcode,(select max(eval_code) from track_inspection_detail where inspection_auto = tid.inspection_auto)) as eval_code, ti.smu, ps.inspection_auto AS ssolved, 
							atn.action_auto AS saction, smsg.inspection_auto AS smg,case  ISNULL(confirmed_date,0)   when ''1900-01-01 00:00:00.000'' then 0  ELSE 1 end confirmed,
							img.inspection_auto AS simage, cust.customer_auto,  mod.model_auto,CRSF.crsf_auto
							
							

				FROM       MAKE mak 
					INNER JOIN	LU_MMTA ON mak.make_auto = dbo.LU_MMTA.make_auto 
					INNER JOIN  MODEL mod ON dbo.LU_MMTA.model_auto = mod.model_auto 
					INNER JOIN  EQUIPMENT equip ON dbo.LU_MMTA.mmtaid_auto = equip.mmtaid_auto 
					INNER JOIN  CRSF  ON equip.crsf_auto = CRSF.crsf_auto 
					INNER JOIN  CUSTOMER cust ON dbo.CRSF.customer_auto = cust.customer_auto 
					INNER JOIN  GENERAL_EQ_UNIT geu ON geu.equipmentid_auto = equip.equipmentid_auto 
					INNER JOIN  LU_COMPART comp ON comp.compartid_auto = geu.compartid_auto 
					INNER JOIN  LU_COMPART_TYPE compt ON compt.comparttype_auto = comp.comparttype_auto 
					INNER JOIN  TRACK_INSPECTION_DETAIL tid ON geu.equnit_auto = tid.track_unit_auto 
					INNER JOIN  TRACK_INSPECTION ti ON ti.inspection_auto= tid.inspection_auto 
					INNER JOIN  [dbo].[' + @strTempTblName + '] t ON equip.serialno = t.serialno
					
					LEFT OUTER JOIN	TRACK_MESSAGE smsg ON tid.inspection_auto = smsg.inspection_auto 
					LEFT OUTER JOIN TRACK_ACTION at ON tid.inspection_auto = at.inspection_auto AND at.problem_solved = 0  
					LEFT OUTER JOIN (
										SELECT ga.* FROM TRACK_ACTION ga 
											INNER JOIN TRACK_ACTION_TAKEN gat ON gat.action_auto = ga.action_auto 
									) atn ON ti.inspection_auto = atn.inspection_auto  
					LEFT OUTER JOIN TRACK_ACTION ps ON tid.inspection_auto = ps.inspection_auto AND ps.problem_solved = 1 
					LEFT OUTER JOIN	TRACK_IMAGE img ON tid.inspection_auto = img.inspection_auto 
  '
SET @str=@str + 'WHERE 1=1  AND ti.last_interp_date is not null AND ti.released_date IS NOT NULL ' --PRN9696 - added - and ti.last_interp_date is not null

IF(@custactive IS NOT NULL AND @custactive = 1)
	SET @str = @str + 'AND cust.active = 1 '
IF dbo.fn_return_internal_emp_status(@user_auto) = 0
	SET @str = @str + ' AND equip.equipmentid_auto IN (SELECT * FROM dbo.fnEquipment(' + cast(@user_auto as varchar) + '))'

IF @status IS NOT NULL AND @status <> '0'  and @status <> ''
BEGIN
     IF @status='confirm'		SET @str=@str + 'AND ti.confirmed_date IS NOT NULL ' 
     IF @status='notconfirm'	SET @str=@str + 'AND ti.confirmed_date IS NULL '
     IF @status='action'		SET @str=@str + 'AND atn.action_auto IS NOT NULL '
     IF @status='email'			SET @str=@str + 'AND smsg.inspection_auto IS NOT NULL ' 
     IF @status='solved'		SET @str=@str + 'AND ps.inspection_auto IS NOT NULL '
     IF @status='image'			SET @str=@str + 'AND img.inspection_auto IS NOT NULL '
END

IF @startdate	IS NOT NULL		SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  >= ''' + CONVERT(VARCHAR(8), @startdate, 112) + ''' '
IF @enddate		IS NOT NULL		SET @str = @str + 'AND CONVERT(VARCHAR(8), ti.inspection_date , 112)  <= ''' + CONVERT(VARCHAR(8), @enddate, 112) + ''' '
/*
--set @str=@str + 'and (ti.evalcode  = ''A'' or ti.evalcode = ''B'' or ti.evalcode  = ''C'' or ti.evalcode = ''X'') '
set @str=@str + 'and (eval_code = ''A'' or eval_code = ''B'' or eval_code = ''C''  or eval_code = ''X'' or eval_code = ''-'') '

if @evala = 0 set @str=replace(@str,'eval_code = ''A'' or ','')
if @evalb = 0 set @str=replace(@str,'eval_code = ''B'' or ','')
if @evalc = 0 set @str=replace(@str,'eval_code = ''C'' or ','')
--if @evalx = 0 set @str=replace(@str,'or ti.evalcode  = ''X''','')
if @evalx = 0 set @str=replace(@str,'eval_code = ''X'' or ','')
*/

SET @str = @str + '	) aa WHERE (aa.eval_code LIKE ''%-%'' OR aa.eval_code LIKE ''%A%'' OR aa.eval_code LIKE ''%B%'' OR aa.eval_code LIKE ''%C%'' OR aa.eval_code LIKE ''%X%'' ) '	

IF @evala = 0 SET @str = REPLACE(@str,'aa.eval_code LIKE ''%A%'' OR ','')
IF @evalb = 0 SET @str = REPLACE(@str,'aa.eval_code LIKE ''%B%'' OR ','')
IF @evalc = 0 SET @str = REPLACE(@str,'aa.eval_code LIKE ''%C%'' OR ','')
IF @evalx = 0 SET @str = REPLACE(@str,'OR aa.eval_code LIKE ''%X%''','')

SET @str=@str + 'ORDER BY aa.serialno ASC, aa.unitno ASC,  aa.inspection_date DESC '
EXEC(@str)

PRINT @str

EXEC('DROP TABLE [dbo].[' + @strTempTblName + ']')

");
        }
    }
}
