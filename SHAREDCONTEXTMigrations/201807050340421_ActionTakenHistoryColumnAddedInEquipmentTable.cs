namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActionTakenHistoryColumnAddedInEquipmentTable : DbMigration
    {
        public override void Up()
        {/*
            AddColumn("dbo.EQUIPMENT", "ActionTakenHistoryId", c => c.Long());
            CreateIndex("dbo.EQUIPMENT", "ActionTakenHistoryId");
            AddForeignKey("dbo.EQUIPMENT", "ActionTakenHistoryId", "dbo.ACTION_TAKEN_HISTORY", "history_id");
        */}
        
        public override void Down()
        {/*
            DropForeignKey("dbo.EQUIPMENT", "ActionTakenHistoryId", "dbo.ACTION_TAKEN_HISTORY");
            DropIndex("dbo.EQUIPMENT", new[] { "ActionTakenHistoryId" });
            DropColumn("dbo.EQUIPMENT", "ActionTakenHistoryId");
        */}
    }
}
