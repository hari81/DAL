namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuEntitiesAdded : DbMigration
    {
        public override void Up()
        {
            /* Tables already exist!! no need to be created
            CreateTable(
                "dbo.LU_MODULE_GROUP",
                c => new
                    {
                        moduleid = c.Byte(nullable: false),
                        moduledesc = c.String(nullable: false, maxLength: 50, unicode: false),
                        sorder = c.Byte(),
                        active = c.Boolean(nullable: false),
                        have_component = c.Boolean(nullable: false),
                        comp_tbl_name = c.String(maxLength: 50, unicode: false),
                        login_targetpath = c.String(maxLength: 400, unicode: false),
                        _default = c.Boolean(name: "default"),
                        homepage_name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.moduleid);
            
            CreateTable(
                "dbo.MENU_L1",
                c => new
                    {
                        menu_L1_auto = c.Int(nullable: false, identity: true),
                        moduleid = c.Byte(),
                        label = c.String(maxLength: 100, unicode: false),
                        targetpath = c.String(maxLength: 100, unicode: false),
                        object_auto = c.Int(),
                        sorder = c.Short(),
                        active = c.Boolean(nullable: false),
                        tooltip = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.menu_L1_auto)
                .ForeignKey("dbo.LU_MODULE_GROUP", t => t.moduleid)
                .Index(t => t.moduleid);
            
            CreateTable(
                "dbo.MENU_L2",
                c => new
                    {
                        menu_L2_auto = c.Int(nullable: false, identity: true),
                        menu_L1_auto = c.Int(),
                        moduleid = c.Byte(),
                        label = c.String(maxLength: 100, unicode: false),
                        targetpath = c.String(maxLength: 100, unicode: false),
                        object_auto = c.Int(),
                        sorder = c.Short(),
                        active = c.Boolean(nullable: false),
                        tooltip = c.String(maxLength: 500, unicode: false),
                        new_window = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.menu_L2_auto)
                .ForeignKey("dbo.LU_MODULE_GROUP", t => t.moduleid)
                .ForeignKey("dbo.MENU_L1", t => t.menu_L1_auto)
                .Index(t => t.menu_L1_auto)
                .Index(t => t.moduleid);
            
            CreateTable(
                "dbo.MENU_L3",
                c => new
                    {
                        menu_L3_auto = c.Int(nullable: false, identity: true),
                        menu_L2_auto = c.Int(),
                        moduleid = c.Byte(),
                        label = c.String(maxLength: 100, unicode: false),
                        targetpath = c.String(maxLength: 100, unicode: false),
                        object_auto = c.Int(),
                        sorder = c.Short(),
                        active = c.Boolean(nullable: false),
                        tooltip = c.String(maxLength: 500, unicode: false),
                        new_window = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.menu_L3_auto)
                .ForeignKey("dbo.LU_MODULE_GROUP", t => t.moduleid)
                .ForeignKey("dbo.MENU_L2", t => t.menu_L2_auto)
                .Index(t => t.menu_L2_auto)
                .Index(t => t.moduleid);
            
            CreateTable(
                "dbo.USER_GROUP_OBJECT",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        group_auto = c.Int(nullable: false),
                        object_auto = c.Int(nullable: false),
                        created_date = c.DateTime(),
                        created_user_auto = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USER_GROUP", t => t.group_auto, cascadeDelete: true)
                .Index(t => t.group_auto);
            
            AddColumn("dbo.USER_MODULE_ACCESS", "LU_MODULE_GROUP_moduleid", c => c.Byte());
            CreateIndex("dbo.USER_MODULE_ACCESS", "LU_MODULE_GROUP_moduleid");
            AddForeignKey("dbo.USER_MODULE_ACCESS", "LU_MODULE_GROUP_moduleid", "dbo.LU_MODULE_GROUP", "moduleid");
            */
        }
        
        public override void Down()
        {
            /*
            DropForeignKey("dbo.USER_GROUP_OBJECT", "group_auto", "dbo.USER_GROUP");
            DropForeignKey("dbo.USER_MODULE_ACCESS", "LU_MODULE_GROUP_moduleid", "dbo.LU_MODULE_GROUP");
            DropForeignKey("dbo.MENU_L3", "menu_L2_auto", "dbo.MENU_L2");
            DropForeignKey("dbo.MENU_L3", "moduleid", "dbo.LU_MODULE_GROUP");
            DropForeignKey("dbo.MENU_L2", "menu_L1_auto", "dbo.MENU_L1");
            DropForeignKey("dbo.MENU_L2", "moduleid", "dbo.LU_MODULE_GROUP");
            DropForeignKey("dbo.MENU_L1", "moduleid", "dbo.LU_MODULE_GROUP");
            DropIndex("dbo.USER_GROUP_OBJECT", new[] { "group_auto" });
            DropIndex("dbo.USER_MODULE_ACCESS", new[] { "LU_MODULE_GROUP_moduleid" });
            DropIndex("dbo.MENU_L3", new[] { "moduleid" });
            DropIndex("dbo.MENU_L3", new[] { "menu_L2_auto" });
            DropIndex("dbo.MENU_L2", new[] { "moduleid" });
            DropIndex("dbo.MENU_L2", new[] { "menu_L1_auto" });
            DropIndex("dbo.MENU_L1", new[] { "moduleid" });
            DropColumn("dbo.USER_MODULE_ACCESS", "LU_MODULE_GROUP_moduleid");
            DropTable("dbo.USER_GROUP_OBJECT");
            DropTable("dbo.MENU_L3");
            DropTable("dbo.MENU_L2");
            DropTable("dbo.MENU_L1");
            DropTable("dbo.LU_MODULE_GROUP"); */
        }
    }
}
