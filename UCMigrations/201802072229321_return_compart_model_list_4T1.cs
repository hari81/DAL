namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class return_compart_model_list_4T1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Matti - 17th March 2010
-- change to the internal user status. 0=customer, 1=internal, 2=internal(lab)
-- ==========================================================================================
-- modified by David on 07/07/08 replacing USER_CRSF with USER_CRSF_CUST_EQUIP
-- Created by Josh on the 20th Dec 2006
-- For returning model list from templates table
---------------------------------------------------------------------------------------------------------------------------------------
-- Modified by	 : Joshua Sim
-- Modified on	: 5th Feb 2007
-- Comments 	: To exclude mmta.arrangement_auto = null and app_auto = null
------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 7/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[return_compart_model_list_4T]
	@make int,
	@type int,
	@dealership_auto smallint = 0,
	@user_auto bigint = 0
AS
	DECLARE @str varchar(4000)
	DECLARE @and varchar(4000)
	SET @and = ' where 1=1 ';

	SET @str = 'SELECT DISTINCT MODEL.model_auto, MODEL.modelid, MODEL.modeldesc
	FROM         LU_MMTA 
	INNER JOIN  MODEL 	ON LU_MMTA.model_auto = MODEL.model_auto 
	INNER JOIN  MAKE 	ON LU_MMTA.make_auto = MAKE.make_auto 
	INNER JOIN  TYPE 	ON LU_MMTA.TYPE_auto = TYPE.type_auto 
	INNER JOIN EQUIPMENT ON LU_MMTA.mmtaid_auto = EQUIPMENT.mmtaid_auto 
	--INNER JOIN OIL_EQ_UNIT ON EQUIPMENT.equipmentid_auto = OIL_EQ_UNIT.equipmentid_auto
	INNER JOIN CRSF crsf ON EQUIPMENT.crsf_auto = crsf.crsf_auto 
	INNER JOIN BRANCH b ON b.branch_auto = crsf.branch_auto
	INNER JOIN REGION r  ON r.region_auto = b.region_auto'

	IF(@make is not null)
	BEGIN
		SET @and = @and + ' AND LU_MMTA.make_auto = ''' + cast(@make as varchar)  + ''''
	END

	IF(@type is not null AND @type <> 0)
	BEGIN
		SET @and = @and + ' AND LU_MMTA.type_auto = ''' + cast(@type as varchar) + ''''
	END

	IF(@dealership_auto <> 0)
	BEGIN
		SET @and = @and + ' AND r.dealership_auto=' + cast(@dealership_auto as varchar(10)) + ' '
	END
 
	DECLARE @status tinyint
	SET @status =  2 --dbo.fnUserInternalAccessStatus(@user_auto) -- TT-333 -- 
	IF @status = 0 and @user_auto <> 0
	BEGIN
		set @str = @str + ' INNER JOIN USER_CRSF_CUST_EQUIP uc ON crsf.crsf_auto = uc.crsf_auto '
		SET @and = @and + ' AND uc.user_auto =' + cast(@user_auto as varchar) + ' '
	END
	ELSE IF @status = 1
	BEGIN
		set @str = @str + ' INNER JOIN  CUSTOMER c ON  c.customer_auto = crsf.customer_auto '
		set @str += ' LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		c.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar) + ' '
		SET @and = @and + ' AND ((c.labonly <> 1) OR (c.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =EQUIPMENT.equipmentid_auto)) '
	END

	SET @and = @and + ' ORDER BY MODEL.modelid ASC'
	EXEC(@str + @and)
		--print(@str + @and)
            ");
        }
        
        public override void Down()
        {
            Sql(@"
                SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Matti - 17th March 2010
-- change to the internal user status. 0=customer, 1=internal, 2=internal(lab)
-- ==========================================================================================
-- modified by David on 07/07/08 replacing USER_CRSF with USER_CRSF_CUST_EQUIP
-- Created by Josh on the 20th Dec 2006
-- For returning model list from templates table
---------------------------------------------------------------------------------------------------------------------------------------
-- Modified by	 : Joshua Sim
-- Modified on	: 5th Feb 2007
-- Comments 	: To exclude mmta.arrangement_auto = null and app_auto = null
------------------------------------------------------------------------------------------------------------------------------------------
--By Rumesh MM on 7/11/2007 changed the join of CRSF and REGION to CRSF ,BRANCH and REGION
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALTER PROCEDURE [dbo].[return_compart_model_list_4T]
	@make int,
	@type int,
	@dealership_auto smallint = 0,
	@user_auto bigint = 0
AS
	DECLARE @str varchar(4000)
	DECLARE @and varchar(4000)
	SET @and = ' where 1=1 ';

	SET @str = 'SELECT DISTINCT MODEL.model_auto, MODEL.modelid, MODEL.modeldesc
	FROM         LU_MMTA 
	INNER JOIN  MODEL 	ON LU_MMTA.model_auto = MODEL.model_auto 
	INNER JOIN  MAKE 	ON LU_MMTA.make_auto = MAKE.make_auto 
	INNER JOIN  TYPE 	ON LU_MMTA.TYPE_auto = TYPE.type_auto 
	INNER JOIN EQUIPMENT ON LU_MMTA.mmtaid_auto = EQUIPMENT.mmtaid_auto 
	--INNER JOIN OIL_EQ_UNIT ON EQUIPMENT.equipmentid_auto = OIL_EQ_UNIT.equipmentid_auto
	INNER JOIN CRSF crsf ON EQUIPMENT.crsf_auto = crsf.crsf_auto 
	INNER JOIN BRANCH b ON b.branch_auto = crsf.branch_auto
	INNER JOIN REGION r  ON r.region_auto = b.region_auto'

	IF(@make is not null)
	BEGIN
		SET @and = @and + ' AND LU_MMTA.make_auto = ''' + cast(@make as varchar)  + ''''
	END

	IF(@type is not null AND @type <> 0)
	BEGIN
		SET @and = @and + ' AND LU_MMTA.type_auto = ''' + cast(@type as varchar) + ''''
	END

	IF(@dealership_auto <> 0)
	BEGIN
		SET @and = @and + ' AND r.dealership_auto=' + cast(@dealership_auto as varchar(10)) + ' '
	END
 
	DECLARE @status tinyint
	SET @status = dbo.fnUserInternalAccessStatus(@user_auto) 
	IF @status = 0 and @user_auto <> 0
	BEGIN
		set @str = @str + ' INNER JOIN USER_CRSF_CUST_EQUIP uc ON crsf.crsf_auto = uc.crsf_auto '
		SET @and = @and + ' AND uc.user_auto =' + cast(@user_auto as varchar) + ' '
	END
	ELSE IF @status = 1
	BEGIN
		set @str = @str + ' INNER JOIN  CUSTOMER c ON  c.customer_auto = crsf.customer_auto '
		set @str += ' LEFT JOIN	USER_CRSF_CUST_EQUIP ucce	ON		c.customer_auto = ucce.customer_auto AND ucce.user_auto	=' + cast(@user_auto as varchar) + ' '
		SET @and = @and + ' AND ((c.labonly <> 1) OR (c.labonly = 1 and ucce.level_type=3 AND ucce.equipmentid_auto =EQUIPMENT.equipmentid_auto)) '
	END

	SET @and = @and + ' ORDER BY MODEL.modelid ASC'
	EXEC(@str + @and)
		--print(@str + @and)
            ");
        }
    }
}
