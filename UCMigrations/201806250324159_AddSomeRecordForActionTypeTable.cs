namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeRecordForActionTypeTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO TRACK_ACTION_TYPE(action_type_auto, action_description, compartment_type) VALUES
(42, 'Insert Inspection General', NULL)
INSERT INTO TRACK_ACTION_TYPE(action_type_auto, action_description, compartment_type) VALUES
(43, 'Update Inspection General', NULL)
INSERT INTO TRACK_ACTION_TYPE(action_type_auto, action_description, compartment_type) VALUES
(44, 'Update Equipment Setup', NULL)
");
        }
        
        public override void Down()
        {
            Sql("DELETE TRACK_ACTION_TYPE WHERE action_type_auto IN (42,43,44)");
        }
    }
}
