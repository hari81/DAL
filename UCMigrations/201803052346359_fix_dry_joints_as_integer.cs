namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_dry_joints_as_integer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_left", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_right", c => c.Decimal(precision: 18, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_right", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_left", c => c.Decimal(precision: 18, scale: 3));
        }
    }
}
