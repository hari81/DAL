namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModuleRegistrationEquipmentTable : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.MODULE_REGISTRATION_EQUIPMENT",
                c => new
                    {
                        module_reg_auto = c.Long(nullable: false, identity: true),
                        equipmentid_auto = c.Long(nullable: false),
                        pm_servicing = c.Boolean(),
                        pm_servicing_last_reg_date = c.DateTime(),
                        backlog = c.Boolean(),
                        backlog_last_reg_date = c.DateTime(),
                        scheduler = c.Boolean(),
                        scheduler_last_reg_date = c.DateTime(),
                        trakalerts = c.Boolean(),
                        trakalerts_last_reg_date = c.DateTime(),
                        component_manager = c.Boolean(),
                        component_manager_last_reg_date = c.DateTime(),
                        tyre = c.Boolean(),
                        tyre_last_reg_date = c.DateTime(),
                        general_inspection = c.Boolean(),
                        general_inspection_last_reg_date = c.DateTime(),
                        get = c.Boolean(),
                        get_last_reg_date = c.DateTime(),
                        undercarriage = c.Boolean(),
                        undercarriage_last_reg_date = c.DateTime(),
                        body_bowl = c.Boolean(),
                        body_bowl_last_reg_date = c.DateTime(),
                        modified_user = c.String(maxLength: 50),
                        rail = c.Boolean(),
                        rail_last_reg_date = c.DateTime(),
                        dashboard = c.Boolean(),
                        dashboard_last_reg_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.module_reg_auto);*/
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.MODULE_REGISTRATION_EQUIPMENT");
        }
    }
}
