namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrackSagCannonExtInMblInspection : DbMigration
    {
        public override void Up()
        {
            /*
            AddColumn("dbo.Mbl_Track_Inspection", "LeftTrackSagComment", c => c.String());
            AddColumn("dbo.Mbl_Track_Inspection", "LeftTrackSagImage", c => c.Binary());
            AddColumn("dbo.Mbl_Track_Inspection", "RightTrackSagComment", c => c.String());
            AddColumn("dbo.Mbl_Track_Inspection", "RightTrackSagImage", c => c.Binary());
            AddColumn("dbo.Mbl_Track_Inspection", "LeftCannonExtensionComment", c => c.String());
            AddColumn("dbo.Mbl_Track_Inspection", "LeftCannonExtensionImage", c => c.Binary());
            AddColumn("dbo.Mbl_Track_Inspection", "RightCannonExtensionComment", c => c.String());
            AddColumn("dbo.Mbl_Track_Inspection", "RightCannonExtensionImage", c => c.Binary());*/
        }
        
        public override void Down()
        {/*
            DropColumn("dbo.Mbl_Track_Inspection", "RightCannonExtensionImage");
            DropColumn("dbo.Mbl_Track_Inspection", "RightCannonExtensionComment");
            DropColumn("dbo.Mbl_Track_Inspection", "LeftCannonExtensionImage");
            DropColumn("dbo.Mbl_Track_Inspection", "LeftCannonExtensionComment");
            DropColumn("dbo.Mbl_Track_Inspection", "RightTrackSagImage");
            DropColumn("dbo.Mbl_Track_Inspection", "RightTrackSagComment");
            DropColumn("dbo.Mbl_Track_Inspection", "LeftTrackSagImage");
            DropColumn("dbo.Mbl_Track_Inspection", "LeftTrackSagComment");*/
        }
    }
}
