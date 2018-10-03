namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDSystemModelTemplate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemModelTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ModelId = c.Int(nullable: false),
                        CompartTypeId = c.Int(nullable: false),
                        Min = c.Int(nullable: false),
                        Max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LU_COMPART_TYPE", t => t.CompartTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MODEL", t => t.ModelId, cascadeDelete: true)
                .Index(t => new { t.ModelId, t.CompartTypeId }, unique: true, name: "IX_ModelCompartType");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemModelTemplate", "ModelId", "dbo.MODEL");
            DropForeignKey("dbo.SystemModelTemplate", "CompartTypeId", "dbo.LU_COMPART_TYPE");
            DropIndex("dbo.SystemModelTemplate", "IX_ModelCompartType");
            DropTable("dbo.SystemModelTemplate");
        }
    }
}
