namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saveEquipmentPhoto : DbMigration
    {
        public override void Up()
        {
            Sql(updateSP1);
        }
        
        public override void Down()
        {
        }

        public const string updateSP1 = @"
/****** Object:  StoredProcedure [dbo].[SaveEquipmentFromMobileService]    Script Date: 23/08/2018 9:31:18 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Nouman Bhatti
-- Create date: 23-07-2015
-- Description:	Save a new equipment from mobile service to temporary table
--
-- Modified:	Nouman
-- Date:		09-10-2015
-- Reason:		PRN9455 | added customer name and jobsite name
-- =============================================
ALTER PROCEDURE [dbo].[SaveEquipmentFromMobileService] 
	@equip_auto		INT = NULL OUTPUT,	--equipmentid_auto (
	@serialNo		VARCHAR(50),		--serialno
	@unitNo			VARCHAR(50),		--unitno
	@crsfAuto		BIGINT,				--crsf_auto
	@smu			BIGINT,				--smu_at_start, LTD_at_start,currentsmu
	@modelAuto		BIGINT,				--mmtaid_auto (It's actually the model_auto coming from service)
	@createdDate	DATETIME,			--created_date
	@createdUser	VARCHAR(50),		--created_user
	@customer_name	VARCHAR(200),
	@jobsite_name	VARCHAR(200),
	@model			VARCHAR(200) = null,
	@EquipmentPhoto varbinary(max) = null
AS
BEGIN
	--Get CRSF from customer and jobsite
	set @crsfAuto = NULL

	set @crsfAuto = (select top 1 crsf_auto from CRSF cr inner join customer c on cr.customer_auto = c.customer_auto 
	where c.cust_name = @customer_name AND cr.site_name = @jobsite_name)

	if @crsfAuto is null
	set @crsfAuto = (select top 1 crsf_auto from CRSF cr inner join customer c on cr.customer_auto = c.customer_auto 
	where c.cust_name = @customer_name)
		
	if @crsfAuto is null
	set @crsfAuto = (select top 1 crsf_auto from CRSF cr inner join customer c on cr.customer_auto = c.customer_auto 
	where c.cust_name = 'Unknown')

	--Get MMTA from model
	declare @mmtaid_auto int
	set @mmtaid_auto = NULL

	set @mmtaid_auto = (SELECT top 1 mmta.mmtaid_auto FROM LU_MMTA mmta INNER JOIN MODEL mo on mo.model_auto = mmta.model_auto WHERE mo.modeldesc = @model)
	
	if @mmtaid_auto is not null
		set @modelAuto = @mmtaid_auto

	INSERT INTO Mbl_NewEquipment(serialno,unitno,crsf_auto,smu_at_start,LTD_at_start,currentsmu,mmtaid_auto,created_date,created_user,equip_status,vision_link_exist,customer_name,jobsite_name,model, EquipmentPhoto)
	VALUES(@serialNo,@unitNo,@crsfAuto,@smu,@smu,@smu,@modelAuto,@createdDate,@createdUser,1,0,@customer_name,@jobsite_name,@model, @EquipmentPhoto)

	SET @equip_auto = CAST(SCOPE_IDENTITY() AS [int])

	--PRN9508 -- Undo this change when applying the proper
	--Temporary thing for John's presentation | Insert the crsf_auto for Unknow
	--select * from CUSTOMER where cust_name like 'unknown'


	--update Mbl_NewEquipment set crsf_auto = (select top 1 crsf_auto from CRSF cr inner join customer c on cr.customer_auto = c.customer_auto 
	--where c.cust_name = 'Unknown')
	--where equipmentid_auto = @equip_auto
	

	
END

";
    }
}
