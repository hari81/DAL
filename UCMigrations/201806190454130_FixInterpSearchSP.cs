namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixInterpSearchSP : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET ANSI_NULLS ON
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
											WHERE e.equipmentid_auto = equip.equipmentid_auto AND lct.comparttype = ''Link'' AND lc.compartid_auto not in (select ChildCompartId from COMPART_PARENT_RELATION)
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

EXEC('DROP TABLE [dbo].[' + @strTempTblName + ']')");
        }
        
        public override void Down()
        {
        }
    }
}
