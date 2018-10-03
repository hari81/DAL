namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WSREChangesApplied : DbMigration
    {
        public override void Up()
        {/*
            AddColumn("dbo.TRACK_INSPECTION", "CustomerContact", c => c.String(maxLength: 500));
            AddColumn("dbo.TRACK_INSPECTION", "TrammingHours", c => c.Int());
            AddColumn("dbo.TRACK_INSPECTION", "GeneralNotes", c => c.String(maxLength: 1000));*/
        }
        
        public override void Down()
        {/*
            DropColumn("dbo.TRACK_INSPECTION", "GeneralNotes");
            DropColumn("dbo.TRACK_INSPECTION", "TrammingHours");
            DropColumn("dbo.TRACK_INSPECTION", "CustomerContact");*/
        }
    }
}
