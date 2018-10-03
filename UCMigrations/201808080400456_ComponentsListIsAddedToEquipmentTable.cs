namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentsListIsAddedToEquipmentTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"

	DECLARE @Id BIGINT
	DECLARE @EquipmentId BIGINT

	DECLARE ComponentCursor CURSOR FORWARD_ONLY FOR
	SELECT equnit_auto, equipmentid_auto FROM GENERAL_EQ_UNIT where equipmentid_auto IS NOT NULL 

	OPEN ComponentCursor;
	Fetch next from ComponentCursor INTO @Id, @EquipmentId
	WHILE @@FETCH_STATUS = 0
	BEGIN

	IF (select COUNT(*) from EQUIPMENT where equipmentid_auto = @EquipmentId) = 0
	BEGIN
	update GENERAL_EQ_UNIT SET equipmentid_auto = NULL where equnit_auto = @Id
	END

	FETCH NEXT FROM ComponentCursor INTO @Id, @EquipmentId
	END
	Close ComponentCursor;
	DEALLOCATE ComponentCursor;

");
            CreateIndex("dbo.GENERAL_EQ_UNIT", "equipmentid_auto");
            AddForeignKey("dbo.GENERAL_EQ_UNIT", "equipmentid_auto", "dbo.EQUIPMENT", "equipmentid_auto");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GENERAL_EQ_UNIT", "equipmentid_auto", "dbo.EQUIPMENT");
            DropIndex("dbo.GENERAL_EQ_UNIT", new[] { "equipmentid_auto" });
        }
    }
}
