namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_make_list_4T : DbMigration
    {
        public override void Up()
        {
            Sql(return_make_list_4T_modified);
        }
        
        public override void Down()
        {
        }

        string return_make_list_4T_modified = @"

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[return_make_list_4T] 
	@dealership_auto 	bigint=0, -- No longer filtering on this 2/10/2009
	@user_auto 			bigint=0,
	@customer_auto 		bigint=0,
	@crsf_auto 			bigint=0,
	@type_auto 			bigint=0,
	@model_auto 		bigint=0,
	@compart_auto 		bigint=0,
	@list_of_all 		bit = 0,
	@list_type			varchar(50) = 'id',
	@make_auto 			bigint=0,
	@progid				bigint=null

AS

-- 31 July 2006 ( changed Irina)

DECLARE @strSQL		as varchar(8000)
DECLARE @strWhere	as varchar(500)
DECLARE @strOrder	as varchar(500)

DECLARE @status tinyint
SET @status = dbo.fnUserInternalAccessStatus(@user_auto)

-- Nadeetha 4 Oct 2006
DECLARE @strSQL1 as varchar (8000)
-- Rumesh 15 Oct 2008
DECLARE @tmpTbl		as varchar(1000)
SET @tmpTbl  = 'DECLARE @tmpCRSF TABLE(crsf_auto bigint)
                Insert INTO @tmpCRSF SELECT * FROM  dbo.fnCrsfList('+CAST(@user_auto as VARCHAR)+') '

set @strWhere = '  WHERE 1=1 '

SELECT @list_type = value_key  FROM APPLICATION_LU_CONFIG WHERE UPPER(variable_key) = UPPER('MakeOrder')

if(@list_type = 'id')
	set @strOrder = ' ORDER BY m.makeid '
else if(@list_type = 'description' )
	 set @strOrder = ' ORDER BY m.makedesc'
else 
	set @strOrder = ' ORDER BY m.makedesc '

if @list_of_all = 1
	begin
		-- returns full list for  MAKE and Equip setup screens
		
		if @list_type = 'id'			
			set @strSQL = ' SELECT	distinct m.make_auto, m.makeid, m.makedesc ,	m.makeid + '' : '' + m.makedesc as make  , m.Undercarriage'			
		else  if(@list_type = 'description' )	
			set @strSQL = ' SELECT	distinct m.make_auto, m.makeid, m.makedesc ,	m.makedesc + '' : '' + m.makeid as make  , m.Undercarriage'
		else 					
			set @strSQL = ' SELECT	distinct m.make_auto, m.makeid, m.makedesc ,	m.makedesc as make  , m.Undercarriage'
			
		set @strSQL = @strSQL +' FROM 	MAKE m  '		
--print(@strSQL + @strWhere + @strOrder) 
		exec(@strSQL + @strWhere + @strOrder) 

		return
	end	

else if @make_auto != 0 and @make_auto is not null
	begin
		-- return all details for  @model_auto
		SELECT  make_auto, makeid, makedesc, dbs_id, created_date, created_user, modified_date, modified_user, Oil, Components, Undercarriage, Tyre, Rim, Hydraulic, Body
		FROM    MAKE
		WHERE  	make_auto =@make_auto

		return 		
	end 
else
   begin

	if @list_type = 'id'			
		set @strSQL = ' SELECT	distinct m.make_auto, m.makeid, m.makedesc ,	m.makeid + '' : '' + m.makedesc as make  , m.Undercarriage'			
	else  if(@list_type = 'description' )	
		set @strSQL = ' SELECT	distinct m.make_auto, m.makeid, m.makedesc ,	m.makedesc + '' : '' + m.makeid as make  , m.Undercarriage'
	else 					
		set @strSQL = ' SELECT	distinct m.make_auto, m.makeid, m.makedesc ,	m.makedesc as make  , m.Undercarriage'
		
	set @strSQL = @strSQL + '
				FROM    MAKE m INNER JOIN
	                    EQUIPMENT eq INNER JOIN
	                    LU_MMTA mmta ON eq.mmtaid_auto = mmta.mmtaid_auto INNER JOIN
	                    TYPE ty ON mmta.type_auto = ty.type_auto ON m.make_auto = mmta.make_auto  '

	
	if @type_auto <> 0 set @strWhere = @strWhere + ' AND (ty.type_auto = ' + cast(@type_auto as varchar) + ')  '
	if @model_auto <> 0 set @strWhere = @strWhere + ' AND (mmta.model_auto =' + cast (@model_auto as varchar) + ')  '

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
			SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto INNER JOIN BRANCH b on b.branch_auto = crsf.branch_auto INNER JOIN REGION r  ON r.region_auto = b.region_auto ' 
		
	
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
--			if ( @dealership_auto <> 0)
--				SET @strSQL = @strSQL + ' INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto ' 
--			else
				SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
							              INNER JOIN @tmpCRSF uc ON crsf.crsf_auto = uc.crsf_auto ' 
		end
		-- Rumesh 15 09 2008 
		--SET @strWhere = @strWhere + ' AND uc.user_auto =' + cast(@user_auto as varchar) + ' '
	END	
	ELSE IF @status = 1
	BEGIN
		if @customer_auto <> 0
		BEGIN
			SET @strSQL = @strSQL + ' INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto '
		END
		ELSE
		BEGIN
			SET @strSQL = @strSQL + ' INNER JOIN CRSF crsf ON eq.crsf_auto = crsf.crsf_auto 
							          INNER JOIN CUSTOMER cu ON cu.customer_auto = crsf.customer_auto 
									  LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		cu.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar) + ''
		END

		if @customer_auto = 0 OR @customer_auto is null
		SET @strWhere = @strWhere + ' AND  ((cu.labonly <> 1) OR (cu.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =eq.equipmentid_auto))  '
	END
	
	--print  'aa: ' + (@tmpTbl + @strSQL + @strWhere + @strOrder)

	if @progid is not null
	begin
		select distinct m.make_auto, m.makeid, m.makedesc ,	m.makeid + ' : ' + m.makedesc as make  
			FROM    MAKE m INNER JOIN
			LU_MAKE_MODULE lmu ON m.make_auto = lmu.make_auto   
			WHERE lmu.progid= @progid --8  This had 8 Hard coded changed to the value passed
			ORDER BY m.makeid 			
	end
	else
		print (@tmpTbl + @strSQL + @strWhere + @strOrder)
		EXEC (@tmpTbl + @strSQL + @strWhere + @strOrder)
   end


";

    }
}
