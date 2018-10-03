namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WSREFixForeignKey : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.LU_Module_Sub", new[] { "Make_make_auto" });
            DropIndex("dbo.LU_Module_Sub", new[] { "Model_model_auto" });
            DropColumn("dbo.LU_Module_Sub", "make_auto");
            DropColumn("dbo.LU_Module_Sub", "model_auto");
            RenameColumn(table: "dbo.LU_Module_Sub", name: "Make_make_auto", newName: "make_auto");
            RenameColumn(table: "dbo.LU_Module_Sub", name: "Model_model_auto", newName: "model_auto");
            AlterColumn("dbo.LU_Module_Sub", "make_auto", c => c.Int());
            AlterColumn("dbo.LU_Module_Sub", "model_auto", c => c.Int());
            CreateIndex("dbo.LU_Module_Sub", "make_auto");
            CreateIndex("dbo.LU_Module_Sub", "model_auto");
            Sql(@"	SET NOCOUNT ON;

	DECLARE @SystemId BIGINT
	DECLARE @EquipmentId BIGINT
	DECLARE modifyingSystemsCursor CURSOR FORWARD_ONLY FOR
    SELECT lms.Module_sub_auto, lms.equipmentid_auto FROM LU_Module_Sub lms
	where lms.model_auto = -1 OR lms.model_auto IS NULL
	OPEN modifyingSystemsCursor;
	FETCH NEXT FROM modifyingSystemsCursor INTO @SystemId, @EquipmentId
	WHILE @@FETCH_STATUS = 0 
	BEGIN 

	if @EquipmentId IS NOT NULL
	BEGIN
	
	DECLARE @mmtaId BIGINT
	DECLARE @makeId BIGINT
	DECLARE @modelId BIGINT

	select @mmtaId = mmtaid_auto from EQUIPMENT where equipmentid_auto = @EquipmentId

	select @makeId = make_auto,
	@modelId = model_auto
	 from LU_MMTA
	where mmtaid_auto = @mmtaId

	update LU_Module_Sub SET
	 make_auto = @makeId, 
	 model_auto = @modelId
	 where Module_sub_auto = @SystemId

	END

	FETCH NEXT FROM modifyingSystemsCursor INTO @SystemId, @EquipmentId
	END --WHILE modifyingSystemsCursor
	CLOSE modifyingSystemsCursor;
	DEALLOCATE modifyingSystemsCursor;");
        }
        
        public override void Down()
        {
            DropIndex("dbo.LU_Module_Sub", new[] { "model_auto" });
            DropIndex("dbo.LU_Module_Sub", new[] { "make_auto" });
            AlterColumn("dbo.LU_Module_Sub", "model_auto", c => c.Long());
            AlterColumn("dbo.LU_Module_Sub", "make_auto", c => c.Long());
            RenameColumn(table: "dbo.LU_Module_Sub", name: "model_auto", newName: "Model_model_auto");
            RenameColumn(table: "dbo.LU_Module_Sub", name: "make_auto", newName: "Make_make_auto");
            AddColumn("dbo.LU_Module_Sub", "model_auto", c => c.Long());
            AddColumn("dbo.LU_Module_Sub", "make_auto", c => c.Long());
            CreateIndex("dbo.LU_Module_Sub", "Model_model_auto");
            CreateIndex("dbo.LU_Module_Sub", "Make_make_auto");
        }
    }
}
