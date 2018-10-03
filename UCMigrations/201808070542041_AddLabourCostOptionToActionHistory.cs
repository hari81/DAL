namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLabourCostOptionToActionHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CUSTOMER", "DefaultHourlyRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ACTION_TAKEN_HISTORY", "LabourCostOptions", c => c.Int(nullable: false));
            Sql(@"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Thomas V
-- Create date: 20/03/2017
-- Description:	Stores the details of an action recorded through the action taken screen. Also stores an SMU reading if the smu entered was later than the current. 
-- =============================================
ALTER PROCEDURE [dbo].[record_action_taken] 
	-- Add the parameters for the stored procedure here
	@action_type_auto int,
	@event_date date,
	@cost bigint,
	@comment varchar(1000),
	@equnit_auto bigint,
	@entry_user_auto bigint,
	@smu int,
	@k int,
	@partsCost dec,
	@labourCost dec,
	@miscCost dec,
	@LabourCostOptions int
AS
BEGIN
	DECLARE @equipmentid_auto bigint,
	@equipment_smu int,
	@module_sub_auto bigint,
	@username varchar(50),
	@p11 int = null,
	@current_smu int = 0,
	@component_cmu_based_on_k int = 0

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select @equipmentid_auto = equipmentid_auto from GENERAL_EQ_UNIT where equnit_auto=@equnit_auto
	select @equipment_smu = currentsmu from EQUIPMENT where equipmentid_auto = @equipmentid_auto
	select @module_sub_auto = module_ucsub_auto from GENERAL_EQ_UNIT where equnit_auto=@equnit_auto
	select @username = username from USER_TABLE where user_auto=@entry_user_auto

	exec @current_smu = dbo.return_equipment_smu @equipmentid_auto=@equipmentid_auto
	
	IF @k = 1
	BEGIN
	SET @component_cmu_based_on_k = 0;
	END
	ELSE
	BEGIN
	SET @component_cmu_based_on_k = dbo.get_component_cmu(@equnit_auto);
	END

    -- Insert statements for procedure here
	INSERT INTO ACTION_TAKEN_HISTORY (action_type_auto, event_date, cmu, cost, comment, equnit_auto, entry_user_auto, compartid_auto, equipmentid_auto,equipment_smu,equipment_ltd,entry_date,system_auto_id, partsCost, labourCost, miscCost, LabourCostOptions)
	VALUES (@action_type_auto, @event_date, @component_cmu_based_on_k,@cost,@comment,@equnit_auto,@entry_user_auto,
		(select TOP(1) compartid_auto from GENERAL_EQ_UNIT where equnit_auto=@equnit_auto), 
		@equipmentid_auto, 
		@smu, 
		dbo.fnEquipCurrentLtd(@equipmentid_auto,@smu),
		GETDATE(),
		@module_sub_auto,
		@partsCost,
		@labourCost,
		@miscCost,
		@LabourCostOptions
	);	
	
	if @smu > @current_smu
	begin
		exec store_smu_reading_without_validation_4T_Ext @equipmentid_auto=@equipmentid_auto,@data_source='Record Action Taken',@date_reading=@event_date,@smu_reading=@smu,@distance_reading=NULL,@user=@username,@stype='s',@SecNewHours=NULL,@SecNewDistance=NULL,@SecNewKWHours=NULL,@SecNewFuelBurn=NULL,@ret_Value=@p11 output
	end
END");
        }
        
        public override void Down()
        {
            DropColumn("dbo.ACTION_TAKEN_HISTORY", "LabourCostOptions");
            DropColumn("dbo.CUSTOMER", "DefaultHourlyRate");
        }
    }
}
