namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemIdNewAddedInActionTakenHistory : DbMigration
    {
        public override void Up()
        {/*
            AddColumn("dbo.ACTION_TAKEN_HISTORY", "equnit_auto_new", c => c.Long());
            AddColumn("dbo.ACTION_TAKEN_HISTORY", "system_auto_id_new", c => c.Long());
            AlterColumn("dbo.ACTION_TAKEN_HISTORY", "equnit_auto", c => c.Long());
        */}
        
        public override void Down()
        {/*
            AlterColumn("dbo.ACTION_TAKEN_HISTORY", "equnit_auto", c => c.Long(nullable: false));
            DropColumn("dbo.ACTION_TAKEN_HISTORY", "system_auto_id_new");
            DropColumn("dbo.ACTION_TAKEN_HISTORY", "equnit_auto_new");
        */}
    }
}
