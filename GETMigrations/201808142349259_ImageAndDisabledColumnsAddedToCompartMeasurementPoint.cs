namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAndDisabledColumnsAddedToCompartMeasurementPoint : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.COMPART_MEASUREMENT_POINT", "Image", c => c.Binary());
            //AddColumn("dbo.COMPART_MEASUREMENT_POINT", "Disabled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.COMPART_MEASUREMENT_POINT", "Disabled");
            //DropColumn("dbo.COMPART_MEASUREMENT_POINT", "Image");
        }
    }
}
