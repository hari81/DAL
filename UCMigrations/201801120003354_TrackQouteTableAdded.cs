namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrackQouteTableAdded : DbMigration
    {
        public override void Up()
        {
            /* Table already exist in database
            CreateTable(
                "dbo.TRACK_QUOTE",
                c => new
                    {
                        quote_auto = c.Int(nullable: false, identity: true),
                        quote_name = c.String(maxLength: 50, unicode: false),
                        inspection_auto = c.Int(nullable: false),
                        status_auto = c.Int(nullable: false),
                        due_date = c.DateTime(),
                        notes = c.String(maxLength: 1000, unicode: false),
                        created_date = c.DateTime(),
                        created_user = c.String(maxLength: 50, unicode: false),
                        modified_user = c.String(maxLength: 50, unicode: false),
                        modified_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.quote_auto);
            */
        }
        
        public override void Down()
        {
            //DropTable("dbo.TRACK_QUOTE");
        }
    }
}
