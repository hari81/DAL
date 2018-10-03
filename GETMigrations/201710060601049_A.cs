namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A : DbMigration
    {
        public override void Up()
        {
            //Already addded in shared context
            //AddColumn("dbo.ACTION_TAKEN_HISTORY", "GETActionHistoryId", c => c.Long());
            //AddColumn("dbo.GET_EVENTS", "UCActionHistoryId", c => c.Long());
            //CreateIndex("dbo.GET_EVENTS", "UCActionHistoryId");
            //AddForeignKey("dbo.GET_EVENTS", "UCActionHistoryId", "dbo.ACTION_TAKEN_HISTORY", "history_id");
        }
        
        public override void Down()
        {
            //Already addded in shared context
            //DropForeignKey("dbo.GET_EVENTS", "UCActionHistoryId", "dbo.ACTION_TAKEN_HISTORY");
            //DropIndex("dbo.GET_EVENTS", new[] { "UCActionHistoryId" });
            //DropColumn("dbo.GET_EVENTS", "UCActionHistoryId");
            //DropColumn("dbo.ACTION_TAKEN_HISTORY", "GETActionHistoryId");
        }
    }
}
