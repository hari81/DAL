namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompartMappingTable : DbMigration
    {
        public override void Up()
        {
            /* Table Exist in database
            CreateTable(
                "dbo.TRACK_COMPART_MODEL_MAPPING",
                c => new
                    {
                        compart_model_mapping_auto = c.Int(nullable: false, identity: true),
                        compartid_auto = c.Int(nullable: false),
                        model_auto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.compart_model_mapping_auto)
                .ForeignKey("dbo.LU_COMPART", t => t.compartid_auto, cascadeDelete: true)
                .ForeignKey("dbo.MODEL", t => t.model_auto, cascadeDelete: true)
                .Index(t => t.compartid_auto)
                .Index(t => t.model_auto);
            */
        }
        
        public override void Down()
        {
            /*
            DropForeignKey("dbo.TRACK_COMPART_MODEL_MAPPING", "model_auto", "dbo.MODEL");
            DropForeignKey("dbo.TRACK_COMPART_MODEL_MAPPING", "compartid_auto", "dbo.LU_COMPART");
            DropIndex("dbo.TRACK_COMPART_MODEL_MAPPING", new[] { "model_auto" });
            DropIndex("dbo.TRACK_COMPART_MODEL_MAPPING", new[] { "compartid_auto" });
            DropTable("dbo.TRACK_COMPART_MODEL_MAPPING");
            */
        }
    }
}
