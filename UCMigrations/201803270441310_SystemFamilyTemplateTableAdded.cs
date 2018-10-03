namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemFamilyTemplateTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SystemFamilyTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FamilyId = c.Int(nullable: false),
                        CompartTypeId = c.Int(nullable: false),
                        Min = c.Int(nullable: false),
                        Max = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LU_COMPART_TYPE", t => t.CompartTypeId, cascadeDelete: true)
                .ForeignKey("dbo.TYPE", t => t.FamilyId, cascadeDelete: true)
                .Index(t => new { t.FamilyId, t.CompartTypeId }, unique: true, name: "IX_FamilyCompartType");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemFamilyTemplate", "FamilyId", "dbo.TYPE");
            DropForeignKey("dbo.SystemFamilyTemplate", "CompartTypeId", "dbo.LU_COMPART_TYPE");
            DropIndex("dbo.SystemFamilyTemplate", "IX_FamilyCompartType");
            DropTable("dbo.SystemFamilyTemplate");
        }
    }
}
