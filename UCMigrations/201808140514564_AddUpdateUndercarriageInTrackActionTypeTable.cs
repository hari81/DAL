namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateUndercarriageInTrackActionTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TRACK_ACTION_TYPE ( action_type_auto, action_description, compartment_type) VALUES ( 45, 'Update Undercarriage Setup', NULL)");
        }
        
        public override void Down()
        {

        }
    }
}
