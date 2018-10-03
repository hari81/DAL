namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeEquipmentRankingTable : DbMigration
    {
        public override void Up()
        {
            /*CreateTable(
                "dbo.LU_EQUIPMENT_RANKING",
                c => new
                    {
                        ranking_auto = c.Byte(nullable: false, identity: true),
                        ranking = c.String(nullable: false, maxLength: 50),
                        rorder = c.Byte(nullable: false),
                        color = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ranking_auto);*/
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.LU_EQUIPMENT_RANKING");
        }
    }
}
