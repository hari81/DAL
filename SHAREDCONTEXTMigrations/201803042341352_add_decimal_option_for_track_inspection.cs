namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_decimal_option_for_track_inspection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TRACK_INSPECTION", "track_sag_left", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.TRACK_INSPECTION", "track_sag_right", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_left", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_right", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.TRACK_INSPECTION", "ext_cannon_left", c => c.Decimal(precision: 18, scale: 3));
            AlterColumn("dbo.TRACK_INSPECTION", "ext_cannon_right", c => c.Decimal(precision: 18, scale: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TRACK_INSPECTION", "ext_cannon_right", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.TRACK_INSPECTION", "ext_cannon_left", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_right", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.TRACK_INSPECTION", "dry_joints_left", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.TRACK_INSPECTION", "track_sag_right", c => c.Decimal(precision: 18, scale: 0));
            AlterColumn("dbo.TRACK_INSPECTION", "track_sag_left", c => c.Decimal(precision: 18, scale: 0));
        }
    }
}
