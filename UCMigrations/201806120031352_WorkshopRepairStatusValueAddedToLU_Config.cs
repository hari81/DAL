namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkshopRepairStatusValueAddedToLU_Config : DbMigration
    {
        public override void Up()
        {
            Sql("insert APPLICATION_LU_CONFIG (variable_key, value_key, description) VALUES ('EnableWorkshopRepairEstimate',1, 'Turn on/off Workshop Repair screen')");
        }
        
        public override void Down()
        {
            Sql("DELETE APPLICATION_LU_CONFIG where variable_key = 'EnableWorkshopRepairEstimate'");
        }
    }
}
