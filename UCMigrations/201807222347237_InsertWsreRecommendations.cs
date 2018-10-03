namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertWsreRecommendations : DbMigration
    {
        public override void Up()
        {
            Sql(@"insert into WSREComponentRecommendations VALUES ('Repair Dry Joints',230)
  insert into WSREComponentRecommendations VALUES('Turn Pins & Bushings', 230)
  insert into WSREComponentRecommendations VALUES('Repair Dry Joints', 231)
  insert into WSREComponentRecommendations VALUES('Turn Pins & Bushings', 231)
  insert into WSREComponentRecommendations VALUES('Adjust Tension', 231)
  insert into WSREComponentRecommendations VALUES('Regrouser', 232)
  insert into WSREComponentRecommendations VALUES('Replace with New', 232)
  insert into WSREComponentRecommendations VALUES('Replace with New', 231)
  insert into WSREComponentRecommendations VALUES('Replace with New', 230)");
        }
        
        public override void Down()
        {
        }
    }
}
