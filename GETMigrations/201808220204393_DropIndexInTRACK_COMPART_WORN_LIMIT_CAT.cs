namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropIndexInTRACK_COMPART_WORN_LIMIT_CAT : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_CAT", "IX_TRACK_COMPART_WORN_LIMIT_CAT");
            DropIndex("dbo.TRACK_COMPART_WORN_LIMIT_ITM", "IX_TRACK_COMPART_WORN_LIMIT_ITM");
        }
        
        public override void Down()
        {
        }
    }
}
