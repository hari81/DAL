namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropConstraint_IX_LU_COMPART_TYPE : DbMigration
    {
        public override void Up()
        {
            Sql(dropQueryStr1);
        }
        
        public override void Down()
        {
        }

        public const string dropQueryStr1 = @"
ALTER TABLE [dbo].[LU_COMPART_TYPE] DROP CONSTRAINT [IX_LU_COMPART_TYPE];
";
    }
}
