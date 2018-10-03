namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelImageForTT178SPsModified : DbMigration
    {
        public override void Up()
        {
            Sql(store_model_4T_up);
            Sql(return_model_list_4T_up);
        }
        
        public override void Down()
        {
            Sql(store_model_4T_down);
            Sql(return_model_list_4T_down);
        }
        string store_model_4T_up = @"
    SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Rumesh MM on 09-04-2011 
-- Added pricing level and industry
--============================================
-- Prasanna on 2nd Dec 2010
-- create/ update service cycle details against created mmta
--============================================
-- Irina M : 15 Nov 2010 - clean commented text
--============================================

-- Tracy T : 10th Nov 2010 Modelid and Model desc now nvarchar
--============================================
-- 02 Oct 2008 Modified by Irina
-- table PART_MMTA not in use  ( commented  line) 
--==================================================================================
--modified by hong J on 28 Feb 2008
--comments: due to field's name changed s_cycle_auto changed to service_cycle_type_auto
--                              SERVICE_CYCLE_INTERVAL_DISTINCT changed to SERVICE_CYCLE_INTERVAL
--==========================================
-- Updated by Nadeetha 12 Dec 2006 
--  @tt_prog_auto, @gb_prog_auto, @axle_no parameters now goes in to MODEL table instead of LU_MMTA
-- Updated by Yong 25 Oct 2007 
-- add  ispsc in to MODEL table

ALTER PROCEDURE [dbo].[store_model_4T] 
	@model_auto 		bigint = null,
	@make_auto			bigint = null,
	@type_auto			bigint = null,
	@modelid			nvarchar(50) = null,
	@modeldesc			nvarchar(50) = null,	
	@s_cycle_auto		int = null,
	@ispsc				bit = 0,
	@tt_prog_auto		int = null,
	@gb_prog_auto		int = null,
	@axle_no			tinyint = null,
	@expiry_date		datetime = null,
	@modified_user		varchar(50) = null,
	@industry_auto		smallint = null,
	@pricing_level_auto smallint = null,
	@generated_mmtaid_auto	bigint OUTPUT	,
	@modelNote			nvarchar(max) = null,
	@modelImage varbinary(max) = null,
	@UCSystemCost float=0
AS

-- 17 aug 2006 Irina

if @expiry_date is null  set @expiry_date = DATEADD(yy,1,GETDATE())
if @make_auto=0 set @make_auto =null
if @type_auto=0 set @type_auto=null
if @s_cycle_auto=0 set @s_cycle_auto = null

set @modelid = RTRIM(LTRIM(@modelid))
set  @modeldesc = RTRIM(LTRIM(@modeldesc))
set  @modelNote = RTRIM(LTRIM(@modelNote))

declare @intMmtaid_auto int
DECLARE @prev_s_cycle_auto int
declare @old_modelid	nvarchar(50)
declare @old_modeldesc nvarchar(50)
DECLARE @mtmaa_auto int
DECLARE @generated_mmtaid_auto_new int
DECLARE @update_success int

set @generated_mmtaid_auto = 0

if (@make_auto is not null) AND (@type_auto is not null) AND @modelid<>'' AND @modeldesc<>'' AND @s_cycle_auto is not null
   begin
	IF  @model_auto = 0 OR @model_auto is null
	   BEGIN
		--   NEW MODEL ============================================================================================
		if not exists ( SELECT * FROM MODEL 
				WHERE RTRIM(LTRIM(modelid)) = @modelid ) --	AND RTRIM(LTRIM(modeldesc)) = @modeldesc )			  
		   begin	
			-- Model
			INSERT MODEL(modelid, modeldesc, created_user,tt_prog_auto, gb_prog_auto, axle_no, isPsc, equip_reg_industry_auto, model_pricing_level_auto,ModelNote,UCSystemCost,ModelImage)
			VALUES(@modelid, @modeldesc,  @modified_user,@tt_prog_auto, @gb_prog_auto, @axle_no, @ispsc, @industry_auto, @pricing_level_auto,@modelNote,@UCSystemCost, @modelImage)	

			SET @model_auto = @@IDENTITY	
			SET @generated_mmtaid_auto = @model_auto				  
		
			-- MMTAA
			INSERT LU_MMTA(make_auto,type_auto, model_auto, 
				service_cycle_type_auto, expiry_date, --tt_prog_auto, gb_prog_auto, axle_no,
				created_user, created_date)
			VALUES( @make_auto, @type_auto,	@model_auto, 
				@s_cycle_auto, @expiry_date , --@tt_prog_auto, @gb_prog_auto, @axle_no,
				@modified_user, GETDATE() )				
				
			SET @generated_mmtaid_auto_new = @@IDENTITY	
				
			-- setup new service cycle for the created mmta
			EXEC update_service_mmta_details_4T @mmtaid_auto = @generated_mmtaid_auto_new,	@s_cycle_type_auto = @s_cycle_auto,	@userid = @modified_user, @ret_Value = @update_success output

		   end		
	   END		
	ELSE
	  BEGIN
		--   print('--   UPDATE  MODEL ============================================================================================')
		SET @generated_mmtaid_auto = @model_auto

		--  print('--  Find prev. Service_Cycle ') 
		SELECT  @prev_s_cycle_auto=service_cycle_type_auto , @mtmaa_auto= mmtaid_auto
		FROM LU_MMTA 
		WHERE model_auto = @model_auto AND app_auto is null AND arrangement_auto is null		

		
		-- UPDATE MODEL
		--   print('-- Update MODEL ModelId   --  check for existence')
		if not exists (SELECT * FROM MODEL WHERE RTRIM(LTRIM(modelid)) = @modelid ) -- AND  RTRIM(LTRIM(modeldesc)) = @modeldesc )
			UPDATE	MODEL
			SET	modelid 	= @modelid,
				modified_date	= GETDATE()  , 
				modified_user	= @modified_user
			WHERE model_auto = @model_auto				
		
		--print('-- Update MODEL  modeldesc   -- modeldesc  ')		
		UPDATE	MODEL
		SET	modeldesc	= @modeldesc,
			modified_date	= GETDATE()  , 
			modified_user	= @modified_user,
			ModelNote=@modelNote
		WHERE model_auto = @model_auto	

		--   print('-- Update MODEL  tt_prog_auto   -- tt_prog_auto  ')			
		UPDATE	MODEL                                             -- added Nadeetha 
		SET	tt_prog_auto	=@tt_prog_auto,
			gb_prog_auto	=@gb_prog_auto,
			axle_no		=@axle_no,
			ispsc		=@ispsc,
			equip_reg_industry_auto = @industry_auto,
			model_pricing_level_auto = @pricing_level_auto,
			UCSystemCost=@UCSystemCost,
			ModelImage = @modelImage
		WHERE model_auto = @model_auto		
	
		
		--   print('-- UPDATE  LU_MMTA expiry_date  WHERE model_auto = @model_auto	')
		UPDATE	LU_MMTA
		SET	--tt_prog_auto	=@tt_prog_auto,
			--gb_prog_auto	=@gb_prog_auto,
			--axle_no		=@axle_no,
			expiry_date	=@expiry_date,
			modified_date	= GETDATE()  , 
			modified_user	=@modified_user
		WHERE model_auto = @model_auto  AND app_auto is null and arrangement_auto is null

		--    print('-- UPDATE  LU_MMTA make_auto , type_auto   WHERE model_auto = @model_auto	')
		if not exists (SELECT * FROM LU_MMTA WHERE model_auto=@model_auto AND make_auto=@make_auto AND type_auto=@type_auto)
		UPDATE	LU_MMTA
		SET	make_auto	=@make_auto,
			type_auto	=@type_auto,				
			modified_date	= GETDATE()  , 
			modified_user	=@modified_user
		WHERE model_auto = @model_auto			

		--==========================================================================================================
		--   print('-- Update  -s_cycle  ')
		--==========================================================================================================

		-- update service cycle when service type has been changed 
		EXEC update_service_mmta_details_4T @mmtaid_auto = @mtmaa_auto,	@s_cycle_type_auto = @s_cycle_auto,	@userid = @modified_user, @ret_Value = @update_success output

		UPDATE	LU_MMTA
		SET	service_cycle_type_auto=@s_cycle_auto		
		WHERE	model_auto = @model_auto AND app_auto is null and arrangement_auto is null

		-- UPDATE equipment  Parts, Tasts, Service insert HERE
	  END
   end

";

        string store_model_4T_down = @"
        SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Rumesh MM on 09-04-2011 
-- Added pricing level and industry
--============================================
-- Prasanna on 2nd Dec 2010
-- create/ update service cycle details against created mmta
--============================================
-- Irina M : 15 Nov 2010 - clean commented text
--============================================

-- Tracy T : 10th Nov 2010 Modelid and Model desc now nvarchar
--============================================
-- 02 Oct 2008 Modified by Irina
-- table PART_MMTA not in use  ( commented  line) 
--==================================================================================
--modified by hong J on 28 Feb 2008
--comments: due to field's name changed s_cycle_auto changed to service_cycle_type_auto
--                              SERVICE_CYCLE_INTERVAL_DISTINCT changed to SERVICE_CYCLE_INTERVAL
--==========================================
-- Updated by Nadeetha 12 Dec 2006 
--  @tt_prog_auto, @gb_prog_auto, @axle_no parameters now goes in to MODEL table instead of LU_MMTA
-- Updated by Yong 25 Oct 2007 
-- add  ispsc in to MODEL table

ALTER PROCEDURE [dbo].[store_model_4T] 
	@model_auto 		bigint = null,
	@make_auto			bigint = null,
	@type_auto			bigint = null,
	@modelid			nvarchar(50) = null,
	@modeldesc			nvarchar(50) = null,	
	@s_cycle_auto		int = null,
	@ispsc				bit = 0,
	@tt_prog_auto		int = null,
	@gb_prog_auto		int = null,
	@axle_no			tinyint = null,
	@expiry_date		datetime = null,
	@modified_user		varchar(50) = null,
	@industry_auto		smallint = null,
	@pricing_level_auto smallint = null,
	@generated_mmtaid_auto	bigint OUTPUT	,
	@modelNote			nvarchar(max) = null,
	@UCSystemCost float=0
AS

-- 17 aug 2006 Irina

if @expiry_date is null  set @expiry_date = DATEADD(yy,1,GETDATE())
if @make_auto=0 set @make_auto =null
if @type_auto=0 set @type_auto=null
if @s_cycle_auto=0 set @s_cycle_auto = null

set @modelid = RTRIM(LTRIM(@modelid))
set  @modeldesc = RTRIM(LTRIM(@modeldesc))
set  @modelNote = RTRIM(LTRIM(@modelNote))

declare @intMmtaid_auto int
DECLARE @prev_s_cycle_auto int
declare @old_modelid	nvarchar(50)
declare @old_modeldesc nvarchar(50)
DECLARE @mtmaa_auto int
DECLARE @generated_mmtaid_auto_new int
DECLARE @update_success int

set @generated_mmtaid_auto = 0

if (@make_auto is not null) AND (@type_auto is not null) AND @modelid<>'' AND @modeldesc<>'' AND @s_cycle_auto is not null
   begin
	IF  @model_auto = 0 OR @model_auto is null
	   BEGIN
		--   NEW MODEL ============================================================================================
		if not exists ( SELECT * FROM MODEL 
				WHERE RTRIM(LTRIM(modelid)) = @modelid ) --	AND RTRIM(LTRIM(modeldesc)) = @modeldesc )			  
		   begin	
			-- Model
			INSERT MODEL(modelid, modeldesc, created_user,tt_prog_auto, gb_prog_auto, axle_no, isPsc, equip_reg_industry_auto, model_pricing_level_auto,ModelNote,UCSystemCost)
			VALUES(@modelid, @modeldesc,  @modified_user,@tt_prog_auto, @gb_prog_auto, @axle_no, @ispsc, @industry_auto, @pricing_level_auto,@modelNote,@UCSystemCost)	

			SET @model_auto = @@IDENTITY	
			SET @generated_mmtaid_auto = @model_auto				  
		
			-- MMTAA
			INSERT LU_MMTA(make_auto,type_auto, model_auto, 
				service_cycle_type_auto, expiry_date, --tt_prog_auto, gb_prog_auto, axle_no,
				created_user, created_date)
			VALUES( @make_auto, @type_auto,	@model_auto, 
				@s_cycle_auto, @expiry_date , --@tt_prog_auto, @gb_prog_auto, @axle_no,
				@modified_user, GETDATE() )				
				
			SET @generated_mmtaid_auto_new = @@IDENTITY	
				
			-- setup new service cycle for the created mmta
			EXEC update_service_mmta_details_4T @mmtaid_auto = @generated_mmtaid_auto_new,	@s_cycle_type_auto = @s_cycle_auto,	@userid = @modified_user, @ret_Value = @update_success output

		   end		
	   END		
	ELSE
	  BEGIN
		--   print('--   UPDATE  MODEL ============================================================================================')
		SET @generated_mmtaid_auto = @model_auto

		--  print('--  Find prev. Service_Cycle ') 
		SELECT  @prev_s_cycle_auto=service_cycle_type_auto , @mtmaa_auto= mmtaid_auto
		FROM LU_MMTA 
		WHERE model_auto = @model_auto AND app_auto is null AND arrangement_auto is null		

		
		-- UPDATE MODEL
		--   print('-- Update MODEL ModelId   --  check for existence')
		if not exists (SELECT * FROM MODEL WHERE RTRIM(LTRIM(modelid)) = @modelid ) -- AND  RTRIM(LTRIM(modeldesc)) = @modeldesc )
			UPDATE	MODEL
			SET	modelid 	= @modelid,
				modified_date	= GETDATE()  , 
				modified_user	= @modified_user
			WHERE model_auto = @model_auto				
		
		--print('-- Update MODEL  modeldesc   -- modeldesc  ')		
		UPDATE	MODEL
		SET	modeldesc	= @modeldesc,
			modified_date	= GETDATE()  , 
			modified_user	= @modified_user,
			ModelNote=@modelNote
		WHERE model_auto = @model_auto	

		--   print('-- Update MODEL  tt_prog_auto   -- tt_prog_auto  ')			
		UPDATE	MODEL                                             -- added Nadeetha 
		SET	tt_prog_auto	=@tt_prog_auto,
			gb_prog_auto	=@gb_prog_auto,
			axle_no		=@axle_no,
			ispsc		=@ispsc,
			equip_reg_industry_auto = @industry_auto,
			model_pricing_level_auto = @pricing_level_auto,
			UCSystemCost=@UCSystemCost
		WHERE model_auto = @model_auto		
	
		
		--   print('-- UPDATE  LU_MMTA expiry_date  WHERE model_auto = @model_auto	')
		UPDATE	LU_MMTA
		SET	--tt_prog_auto	=@tt_prog_auto,
			--gb_prog_auto	=@gb_prog_auto,
			--axle_no		=@axle_no,
			expiry_date	=@expiry_date,
			modified_date	= GETDATE()  , 
			modified_user	=@modified_user
		WHERE model_auto = @model_auto  AND app_auto is null and arrangement_auto is null

		--    print('-- UPDATE  LU_MMTA make_auto , type_auto   WHERE model_auto = @model_auto	')
		if not exists (SELECT * FROM LU_MMTA WHERE model_auto=@model_auto AND make_auto=@make_auto AND type_auto=@type_auto)
		UPDATE	LU_MMTA
		SET	make_auto	=@make_auto,
			type_auto	=@type_auto,				
			modified_date	= GETDATE()  , 
			modified_user	=@modified_user
		WHERE model_auto = @model_auto			

		--==========================================================================================================
		--   print('-- Update  -s_cycle  ')
		--==========================================================================================================

		-- update service cycle when service type has been changed 
		EXEC update_service_mmta_details_4T @mmtaid_auto = @mtmaa_auto,	@s_cycle_type_auto = @s_cycle_auto,	@userid = @modified_user, @ret_Value = @update_success output

		UPDATE	LU_MMTA
		SET	service_cycle_type_auto=@s_cycle_auto		
		WHERE	model_auto = @model_auto AND app_auto is null and arrangement_auto is null

		-- UPDATE equipment  Parts, Tasts, Service insert HERE
	  END
   end
";

        string return_model_list_4T_up = @"
    SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
--
-- Modified By:	Nouman Bhatti		31-07-2015
-- Reason:		Added the Make and Family with the Make (when @list_of_all = 1 and @list_type = 'id'
*/
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 09-04-2011 returns model_pricing_level_auto & equip_reg_industry_auto
-- ==========================================================================================
-- Matti - 18th March 2010
-- change to the internal user status. 0=customer, 1=internal, 2=internal(lab)
-- ==========================================================================================
--==============================================================================================
-- Tracy T : 2nd Nov 2009
-- The way the Dealership is working needs to be phased out. For Central Server the dealership
-- will allow users to have multiple's so this can no longer be a filter and currently has no true impact
-- So removing the filter
--================================================================================================
-- 23 Feb 2009 Irina  - to return all model by make and type
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 22-09-2009 changed to use the order from APPLICATION_LU_CONFiG
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Modified 15 feb 2008 Irina 
-- mmta.service_cycle_type_auto 
--=============================================================
--Modified by: hong J 5th Nov 2007
--return column isPSC

--Modified Tracy Thompson 8th May 2006
--Added extra parameters for filtering

-- 14 Aug 2006 modified by  Yong Gu
-- add @model_auto to find a spec record
-- add @list_type to define record return type

-- 15 Aug 2006 Irina @list_of_all 	
-- 14 Dec 2006 Nadeetha axle_no,tt_prog_auto,gb_prog_auto from MODEL instead of LU_MMTA

-- 25 Oct 2007 modified by Yong
-- add one more column return for model detail, isPSC
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 12/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

--modified by David on 07/07/08 replacing USER_CRSF with USER_CRSF_CUST_EQUIP


--Test Run exec return_model_list_4t @list_of_all=1,@list_type='id'

ALTER    PROCEDURE [dbo].[return_model_list_4T] 
	@dealership_auto smallint=0, -- not filtering on this now 2/11/2009
	@user_auto 	bigint=0 ,
	@customer_auto 	bigint=0,
	@make_auto 	bigint=0,	
	@type_auto 	bigint=0,
	@crsf_auto 	bigint=0,
	@compart_auto 	bigint=0,
	@list_of_all 	bit = 0,
	@model_auto 	bigint = 0,
	@list_type 	varchar(50) = '',
	@eq_filter	varchar (20) = 'Y' --Added by Jerry for page hydraulic inspec setup

AS

DECLARE @strSQL as varchar(8000)
DECLARE @strWhere as varchar(500)
DECLARE @strOrder as varchar(500)
	-- Rumesh 15 09 2008 
DECLARE @tmpTbl		as varchar(1000)

DECLARE @status tinyint
SET @status = dbo.fnUserInternalAccessStatus(@user_auto)

SET @tmpTbl  = 'DECLARE @tmpCRSF TABLE(crsf_auto bigint)
                Insert INTO @tmpCRSF SELECT * FROM  dbo.fnCrsfList('+CAST(@user_auto as VARCHAR)+') '
set @strWhere = '  WHERE 1=1 '

SELECT @list_type = value_key  FROM APPLICATION_LU_CONFiG WHERE UPPER(variable_key) = UPPER('ModelOrder')

if(@list_type = 'id')
	set @strOrder = ' ORDER BY m.modelid '
else if(@list_type = 'description' )
	 set @strOrder = ' ORDER BY m.modeldesc '
else 
	set @strOrder = ' ORDER BY m.modeldesc '


IF @eq_filter = 'N'
BEGIN
	if @list_type = 'id' 			
		set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modelid + '' : '' + m.modeldesc  as model  , m.modelImage'		
	else  if(@list_type = 'description' )		
		set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc + '' : '' + m.modelid as model  , m.modelImage'
	else 					
		set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc as model  , m.modelImage'		
	--PRN11357
	set @strSQL = @strSQL + ',m.UCSystemCost '
	set @strSQL = @strSQL + '
				FROM    MODEL m INNER JOIN
		                        LU_MMTA mmta ON m.model_auto = mmta.model_auto INNER JOIN
		                        TYPE ty ON mmta.type_auto = ty.type_auto  '



	if @type_auto <> 0 set @strWhere = @strWhere + ' AND (ty.type_auto = ' + cast(@type_auto as varchar) + ')  '
	if @make_auto <> 0 set @strWhere = @strWhere + ' AND (mmta.make_auto = ' + cast( @make_auto as varchar) + ')  ' 
	
	
	EXEC (@strSQL + @strWhere + @strOrder )
	

END
ELSE IF @eq_filter = 'Y'
BEGIN
	if @list_of_all = 1
		begin
			-- returns full list om Models   for Model, MMTA and Equip setup screens
			
			if @list_type = 'id'		
				set @strSQL = ' SELECT	distinct m.model_auto, m.modelid, m.modeldesc ,	m.modelid + '' : '' + m.modeldesc + ''          |             '' + ma.makedesc + '' : '' + t.typedesc as model, m.isPSC , m.modelImage '     --added a column isPSC  by hongJ on 5th Nov 2007			
			else  if(@list_type = 'description' )	
				set @strSQL = ' SELECT	distinct m.model_auto, m.modelid, m.modeldesc ,	m.modeldesc + '' : '' + m.modelid as model, m.isPSC  , m.modelImage '
			else 				
				set @strSQL = ' SELECT	distinct m.model_auto, m.modelid, m.modeldesc ,	m.modeldesc as model, m.isPSC  , m.modelImage '
			--PRN11357
			set @strSQL = @strSQL + ',m.UCSystemCost '
		/*		
			set @strSQL = @strSQL +'   FROM  MODEL m  '
							
	
			if @make_auto<>0 AND @make_auto is not null
			   begin
				set @strSQL = @strSQL +'  INNER JOIN  LU_MMTA mmta ON m.model_auto = mmta.model_auto '
				set @strWhere = @strWhere +  '  AND mmta.make_auto = ' + cast(@make_auto as varchar)
			   end
	      */
			--===23 Feb 2009 Irina ==============================================  
            set @strSQL = @strSQL +'   FROM  MODEL m  
							 INNER JOIN  LU_MMTA mmta ON m.model_auto = mmta.model_auto inner join MAKE ma on ma.make_auto = mmta.make_auto inner join type t on t.type_auto = mmta.type_auto'

			if @make_auto<>0 AND @make_auto is not null			  
				set @strWhere = @strWhere +  '  AND mmta.make_auto = ' + cast(@make_auto as varchar)			  

			if @type_auto<>0 AND @type_auto is not null
			   set @strWhere = @strWhere +  '  AND mmta.type_auto = ' + cast(@type_auto as varchar)	
			--=================================================  
            
			exec(@strSQL + @strWhere + @strOrder) 
	
			return
		end	
	
	else if @model_auto != 0 and @model_auto is not null
		begin
			-- return all details for  @model_auto
			SELECT    m.model_auto, modelid, modeldesc,  track_sag_maximum, track_sag_minimum,
				--m.created_date, m.created_user, m.modified_date, m.modified_user,
				convert (varchar,m.created_date, 106) as created_date , 	m.created_user, 
				convert (varchar,m.modified_date, 106) as modified_date , m.modified_user,
				mmta.make_auto, mmta.type_auto, mmta.service_cycle_type_auto,
				m.tt_prog_auto, m.gb_prog_auto, mmta.expiry_date, m.axle_no, m.ispsc, m.model_pricing_level_auto, m.equip_reg_industry_auto,ModelNote,m.UCSystemCost, m.ModelImage
			FROM    MODEL m
				INNER JOIN  LU_MMTA mmta ON m.model_auto = mmta.model_auto
			WHERE  m.model_auto = @model_auto -- AND mmta.arrangement_auto is null AND mmta.app_auto is null   --->> PRN9495
	
			return 		
		end 
	else
	   begin
	
		
		if @list_type = 'id' 			
			set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modelid + '' : '' + m.modeldesc  as model  , m.modelImage '		
		else  if(@list_type = 'description' )		
			set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc + '' : '' + m.modelid as model  , m.modelImage '
		else 					
			set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc as model  , m.modelImage '		
			--PRN11357
			set @strSQL = @strSQL + ',m.UCSystemCost '
		set @strSQL = @strSQL + '
					FROM    MODEL m INNER JOIN
			                        EQUIPMENT eq INNER JOIN
			                        LU_MMTA mmta ON eq.mmtaid_auto = mmta.mmtaid_auto INNER JOIN
			                        TYPE ty ON mmta.type_auto = ty.type_auto ON m.model_auto = mmta.model_auto '
	
	
	
		if @type_auto <> 0 set @strWhere = @strWhere + ' AND (ty.type_auto = ' + cast(@type_auto as varchar) + ')  '
		if @make_auto <> 0 set @strWhere = @strWhere + ' AND (mmta.make_auto = ' + cast( @make_auto as varchar) + ')  '
	
		if @customer_auto <> 0
		    BEGIN
			SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto ' 
			SET @strWHERE = @strWHERE +  ' AND crsf.customer_auto =' + cast(@customer_auto as varchar(10)) + ' '
		    END 
		
		IF @crsf_auto <> 0
			SET @strWHERE = @strWHERE +  ' AND crsf.crsf_auto =' + cast(@crsf_auto as varchar(10)) + ' ' 

		/*
		IF @dealership_auto <> 0
			BEGIN
				if @customer_auto <> 0
					SET @strSQL = @strSQL + ' INNER JOIN BRANCH b ON crsf.branch_auto = b.branch_auto 
								      INNER JOIN REGION r  ON r.region_auto = b.region_auto ' 
				ELSE
					SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
									  INNER JOIN BRANCH b ON crsf.branch_auto = b.branch_auto 
								      INNER JOIN REGION r  ON r.region_auto = b.region_auto '
			
			
				 SET @strWHERE = @strWhere + ' AND r.dealership_auto=' + cast(@dealership_auto as varchar(10)) + ' '
			END
		*/
		if @compart_auto <> 0 
		    BEGIN
			SET @strSQL = @strSQL + ' INNER JOIN OIL_EQ_UNIT eq_unit ON eq.equipmentid_auto = eq_unit.equipmentid_auto '
			SET @strWhere = @strWhere + ' AND (eq_unit.compartid_auto =' + cast(@compart_auto as varchar) + ') '
		    END
	 
		if @status = 0 and @user_auto <> 0
		BEGIN
			if @customer_auto <> 0
				SET @strSQL = @strSQL + ' INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto '
			else
				begin
--					if @dealership_auto <> 0
--						SET @strSQL = @strSQL + ' INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto ' 
--					else 	
						SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
								  INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto ' 
				end
				
			--SET @strWhere = @strWhere + ' AND uc.user_auto =' + cast(@user_auto as varchar) + ' '
		END
		ELSE IF @status = 1
		BEGIN
			if @customer_auto <> 0 -- already have crsf joined
			BEGIN
				SET @strSQL = @strSQL + ' INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto '
			END
			ELSE -- need both customer and crsf to join
			BEGIN
				SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
										  INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto '
			END
			set @strSQL += ' LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		cu.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar)
			 SET @strWHERE = @strWHERE + ' AND ((cu.labonly <> 1) OR (cu.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =eq.equipmentid_auto))  '
			
		END
		--print(@tmpTbl + @strSQL + @strWhere + @strOrder )
		
		EXEC (@tmpTbl + @strSQL + @strWhere + @strOrder )
		
	
	   end
END

";

        string return_model_list_4T_down = @"
    SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
--
-- Modified By:	Nouman Bhatti		31-07-2015
-- Reason:		Added the Make and Family with the Make (when @list_of_all = 1 and @list_type = 'id'
*/
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 09-04-2011 returns model_pricing_level_auto & equip_reg_industry_auto
-- ==========================================================================================
-- Matti - 18th March 2010
-- change to the internal user status. 0=customer, 1=internal, 2=internal(lab)
-- ==========================================================================================
--==============================================================================================
-- Tracy T : 2nd Nov 2009
-- The way the Dealership is working needs to be phased out. For Central Server the dealership
-- will allow users to have multiple's so this can no longer be a filter and currently has no true impact
-- So removing the filter
--================================================================================================
-- 23 Feb 2009 Irina  - to return all model by make and type
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 22-09-2009 changed to use the order from APPLICATION_LU_CONFiG
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

-- Modified 15 feb 2008 Irina 
-- mmta.service_cycle_type_auto 
--=============================================================
--Modified by: hong J 5th Nov 2007
--return column isPSC

--Modified Tracy Thompson 8th May 2006
--Added extra parameters for filtering

-- 14 Aug 2006 modified by  Yong Gu
-- add @model_auto to find a spec record
-- add @list_type to define record return type

-- 15 Aug 2006 Irina @list_of_all 	
-- 14 Dec 2006 Nadeetha axle_no,tt_prog_auto,gb_prog_auto from MODEL instead of LU_MMTA

-- 25 Oct 2007 modified by Yong
-- add one more column return for model detail, isPSC
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 12/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

--modified by David on 07/07/08 replacing USER_CRSF with USER_CRSF_CUST_EQUIP


--Test Run exec return_model_list_4t @list_of_all=1,@list_type='id'

ALTER    PROCEDURE [dbo].[return_model_list_4T] 
	@dealership_auto smallint=0, -- not filtering on this now 2/11/2009
	@user_auto 	bigint=0 ,
	@customer_auto 	bigint=0,
	@make_auto 	bigint=0,	
	@type_auto 	bigint=0,
	@crsf_auto 	bigint=0,
	@compart_auto 	bigint=0,
	@list_of_all 	bit = 0,
	@model_auto 	bigint = 0,
	@list_type 	varchar(50) = '',
	@eq_filter	varchar (20) = 'Y' --Added by Jerry for page hydraulic inspec setup

AS

DECLARE @strSQL as varchar(8000)
DECLARE @strWhere as varchar(500)
DECLARE @strOrder as varchar(500)
	-- Rumesh 15 09 2008 
DECLARE @tmpTbl		as varchar(1000)

DECLARE @status tinyint
SET @status = dbo.fnUserInternalAccessStatus(@user_auto)

SET @tmpTbl  = 'DECLARE @tmpCRSF TABLE(crsf_auto bigint)
                Insert INTO @tmpCRSF SELECT * FROM  dbo.fnCrsfList('+CAST(@user_auto as VARCHAR)+') '
set @strWhere = '  WHERE 1=1 '

SELECT @list_type = value_key  FROM APPLICATION_LU_CONFiG WHERE UPPER(variable_key) = UPPER('ModelOrder')

if(@list_type = 'id')
	set @strOrder = ' ORDER BY m.modelid '
else if(@list_type = 'description' )
	 set @strOrder = ' ORDER BY m.modeldesc '
else 
	set @strOrder = ' ORDER BY m.modeldesc '


IF @eq_filter = 'N'
BEGIN
	if @list_type = 'id' 			
		set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modelid + '' : '' + m.modeldesc  as model  '		
	else  if(@list_type = 'description' )		
		set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc + '' : '' + m.modelid as model '
	else 					
		set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc as model '		
	--PRN11357
	set @strSQL = @strSQL + ',m.UCSystemCost '
	set @strSQL = @strSQL + '
				FROM    MODEL m INNER JOIN
		                        LU_MMTA mmta ON m.model_auto = mmta.model_auto INNER JOIN
		                        TYPE ty ON mmta.type_auto = ty.type_auto  '



	if @type_auto <> 0 set @strWhere = @strWhere + ' AND (ty.type_auto = ' + cast(@type_auto as varchar) + ')  '
	if @make_auto <> 0 set @strWhere = @strWhere + ' AND (mmta.make_auto = ' + cast( @make_auto as varchar) + ')  ' 
	
	
	EXEC (@strSQL + @strWhere + @strOrder )
	

END
ELSE IF @eq_filter = 'Y'
BEGIN
	if @list_of_all = 1
		begin
			-- returns full list om Models   for Model, MMTA and Equip setup screens
			
			if @list_type = 'id'		
				set @strSQL = ' SELECT	distinct m.model_auto, m.modelid, m.modeldesc ,	m.modelid + '' : '' + m.modeldesc + ''          |             '' + ma.makedesc + '' : '' + t.typedesc as model, m.isPSC '     --added a column isPSC  by hongJ on 5th Nov 2007			
			else  if(@list_type = 'description' )	
				set @strSQL = ' SELECT	distinct m.model_auto, m.modelid, m.modeldesc ,	m.modeldesc + '' : '' + m.modelid as model, m.isPSC  '
			else 				
				set @strSQL = ' SELECT	distinct m.model_auto, m.modelid, m.modeldesc ,	m.modeldesc as model, m.isPSC  '
			--PRN11357
			set @strSQL = @strSQL + ',m.UCSystemCost '
		/*		
			set @strSQL = @strSQL +'   FROM  MODEL m  '
							
	
			if @make_auto<>0 AND @make_auto is not null
			   begin
				set @strSQL = @strSQL +'  INNER JOIN  LU_MMTA mmta ON m.model_auto = mmta.model_auto '
				set @strWhere = @strWhere +  '  AND mmta.make_auto = ' + cast(@make_auto as varchar)
			   end
	      */
			--===23 Feb 2009 Irina ==============================================  
            set @strSQL = @strSQL +'   FROM  MODEL m  
							 INNER JOIN  LU_MMTA mmta ON m.model_auto = mmta.model_auto inner join MAKE ma on ma.make_auto = mmta.make_auto inner join type t on t.type_auto = mmta.type_auto'

			if @make_auto<>0 AND @make_auto is not null			  
				set @strWhere = @strWhere +  '  AND mmta.make_auto = ' + cast(@make_auto as varchar)			  

			if @type_auto<>0 AND @type_auto is not null
			   set @strWhere = @strWhere +  '  AND mmta.type_auto = ' + cast(@type_auto as varchar)	
			--=================================================  
            
			exec(@strSQL + @strWhere + @strOrder) 
	
			return
		end	
	
	else if @model_auto != 0 and @model_auto is not null
		begin
			-- return all details for  @model_auto
			SELECT    m.model_auto, modelid, modeldesc,  track_sag_maximum, track_sag_minimum,
				--m.created_date, m.created_user, m.modified_date, m.modified_user,
				convert (varchar,m.created_date, 106) as created_date , 	m.created_user, 
				convert (varchar,m.modified_date, 106) as modified_date , m.modified_user,
				mmta.make_auto, mmta.type_auto, mmta.service_cycle_type_auto,
				m.tt_prog_auto, m.gb_prog_auto, mmta.expiry_date, m.axle_no, m.ispsc, m.model_pricing_level_auto, m.equip_reg_industry_auto,ModelNote,m.UCSystemCost
			FROM    MODEL m
				INNER JOIN  LU_MMTA mmta ON m.model_auto = mmta.model_auto
			WHERE  m.model_auto = @model_auto -- AND mmta.arrangement_auto is null AND mmta.app_auto is null   --->> PRN9495
	
			return 		
		end 
	else
	   begin
	
		
		if @list_type = 'id' 			
			set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modelid + '' : '' + m.modeldesc  as model  '		
		else  if(@list_type = 'description' )		
			set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc + '' : '' + m.modelid as model  '
		else 					
			set @strSQL = 	'SELECT	DISTINCT m.model_auto, m.modelid , m.modeldesc, 	m.modeldesc as model  '		
			--PRN11357
			set @strSQL = @strSQL + ',m.UCSystemCost '
		set @strSQL = @strSQL + '
					FROM    MODEL m INNER JOIN
			                        EQUIPMENT eq INNER JOIN
			                        LU_MMTA mmta ON eq.mmtaid_auto = mmta.mmtaid_auto INNER JOIN
			                        TYPE ty ON mmta.type_auto = ty.type_auto ON m.model_auto = mmta.model_auto '
	
	
	
		if @type_auto <> 0 set @strWhere = @strWhere + ' AND (ty.type_auto = ' + cast(@type_auto as varchar) + ')  '
		if @make_auto <> 0 set @strWhere = @strWhere + ' AND (mmta.make_auto = ' + cast( @make_auto as varchar) + ')  '
	
		if @customer_auto <> 0
		    BEGIN
			SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto ' 
			SET @strWHERE = @strWHERE +  ' AND crsf.customer_auto =' + cast(@customer_auto as varchar(10)) + ' '
		    END 
		
		IF @crsf_auto <> 0
			SET @strWHERE = @strWHERE +  ' AND crsf.crsf_auto =' + cast(@crsf_auto as varchar(10)) + ' ' 

		/*
		IF @dealership_auto <> 0
			BEGIN
				if @customer_auto <> 0
					SET @strSQL = @strSQL + ' INNER JOIN BRANCH b ON crsf.branch_auto = b.branch_auto 
								      INNER JOIN REGION r  ON r.region_auto = b.region_auto ' 
				ELSE
					SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
									  INNER JOIN BRANCH b ON crsf.branch_auto = b.branch_auto 
								      INNER JOIN REGION r  ON r.region_auto = b.region_auto '
			
			
				 SET @strWHERE = @strWhere + ' AND r.dealership_auto=' + cast(@dealership_auto as varchar(10)) + ' '
			END
		*/
		if @compart_auto <> 0 
		    BEGIN
			SET @strSQL = @strSQL + ' INNER JOIN OIL_EQ_UNIT eq_unit ON eq.equipmentid_auto = eq_unit.equipmentid_auto '
			SET @strWhere = @strWhere + ' AND (eq_unit.compartid_auto =' + cast(@compart_auto as varchar) + ') '
		    END
	 
		if @status = 0 and @user_auto <> 0
		BEGIN
			if @customer_auto <> 0
				SET @strSQL = @strSQL + ' INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto '
			else
				begin
--					if @dealership_auto <> 0
--						SET @strSQL = @strSQL + ' INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto ' 
--					else 	
						SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
								  INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto ' 
				end
				
			--SET @strWhere = @strWhere + ' AND uc.user_auto =' + cast(@user_auto as varchar) + ' '
		END
		ELSE IF @status = 1
		BEGIN
			if @customer_auto <> 0 -- already have crsf joined
			BEGIN
				SET @strSQL = @strSQL + ' INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto '
			END
			ELSE -- need both customer and crsf to join
			BEGIN
				SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
										  INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto '
			END
			set @strSQL += ' LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		cu.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar)
			 SET @strWHERE = @strWHERE + ' AND ((cu.labonly <> 1) OR (cu.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =eq.equipmentid_auto))  '
			
		END
		--print(@tmpTbl + @strSQL + @strWhere + @strOrder )
		
		EXEC (@tmpTbl + @strSQL + @strWhere + @strOrder )
		
	
	   end
END

";
    }
}
