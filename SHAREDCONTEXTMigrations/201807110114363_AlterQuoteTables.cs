namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterQuoteTables : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.TRACK_QUOTE",
                c => new
                    {
                        quote_auto = c.Int(nullable: false, identity: true),
                        quote_name = c.String(maxLength: 50),
                        inspection_auto = c.Int(nullable: false),
                        status_auto = c.Int(nullable: false),
                        due_date = c.DateTime(),
                        notes = c.String(maxLength: 1000),
                        created_date = c.DateTime(),
                        created_user = c.String(maxLength: 50),
                        modified_user = c.String(maxLength: 50),
                        modified_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.quote_auto)
                .ForeignKey("dbo.TRACK_INSPECTION", t => t.inspection_auto, cascadeDelete: true)
                .ForeignKey("dbo.TRACK_QUOTE_STATUS", t => t.status_auto, cascadeDelete: true)
                .Index(t => t.inspection_auto)
                .Index(t => t.status_auto);
            
            CreateTable(
                "dbo.TRACK_QUOTE_DETAIL",
                c => new
                    {
                        quote_detail_auto = c.Int(nullable: false, identity: true),
                        quote_auto = c.Int(nullable: false),
                        track_unit_auto = c.String(maxLength: 10),
                        op_type_auto = c.Int(nullable: false),
                        start_smu = c.Int(nullable: false),
                        end_smu = c.Int(nullable: false),
                        part_auto = c.Int(),
                        price = c.Decimal(storeType: "money"),
                        qty = c.Int(),
                        created_date = c.DateTime(),
                        created_user = c.String(maxLength: 50),
                        modified_date = c.DateTime(),
                        modified_user = c.String(maxLength: 50),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.quote_detail_auto)
                .ForeignKey("dbo.TRACK_QUOTE", t => t.quote_auto, cascadeDelete: true)
                .Index(t => t.quote_auto);
            
            CreateTable(
                "dbo.TRACK_QUOTE_STATUS",
                c => new
                    {
                        status_auto = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.status_auto);
            
            CreateTable(
                "dbo.TRACK_QUOTE_STATUS_HISTORY",
                c => new
                    {
                        quote_status_hist_auto = c.Int(nullable: false),
                        quote_auto = c.Int(nullable: false),
                        status_auto = c.Int(nullable: false),
                        created_user = c.String(nullable: false, maxLength: 50),
                        created_date = c.DateTime(nullable: false),
                        comment = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => new { t.quote_status_hist_auto, t.quote_auto, t.status_auto, t.created_user, t.created_date })
                .ForeignKey("dbo.TRACK_QUOTE_STATUS", t => t.status_auto, cascadeDelete: true)
                .Index(t => t.status_auto);
            */
        }
        
        public override void Down()
        {
            /*DropForeignKey("dbo.TRACK_QUOTE_STATUS_HISTORY", "status_auto", "dbo.TRACK_QUOTE_STATUS");
            DropForeignKey("dbo.TRACK_QUOTE", "status_auto", "dbo.TRACK_QUOTE_STATUS");
            DropForeignKey("dbo.TRACK_QUOTE_DETAIL", "quote_auto", "dbo.TRACK_QUOTE");
            DropForeignKey("dbo.TRACK_QUOTE", "inspection_auto", "dbo.TRACK_INSPECTION");
            DropIndex("dbo.TRACK_QUOTE_STATUS_HISTORY", new[] { "status_auto" });
            DropIndex("dbo.TRACK_QUOTE_DETAIL", new[] { "quote_auto" });
            DropIndex("dbo.TRACK_QUOTE", new[] { "status_auto" });
            DropIndex("dbo.TRACK_QUOTE", new[] { "inspection_auto" });
            DropTable("dbo.TRACK_QUOTE_STATUS_HISTORY");
            DropTable("dbo.TRACK_QUOTE_STATUS");
            DropTable("dbo.TRACK_QUOTE_DETAIL");
            DropTable("dbo.TRACK_QUOTE");*/
        }
    }
}
