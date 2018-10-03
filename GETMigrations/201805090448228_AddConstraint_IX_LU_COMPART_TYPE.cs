namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraint_IX_LU_COMPART_TYPE : DbMigration
    {
        public override void Up()
        {
            Sql(addConstraintQuery1);
        }
        
        public override void Down()
        {
        }

        public const string addConstraintQuery1 = @"
ALTER TABLE [dbo].[LU_COMPART_TYPE] ADD  CONSTRAINT [IX_LU_COMPART_TYPE] UNIQUE NONCLUSTERED 
(
	[comparttypeid] ASC,
	[comparttype] ASC,
    [system_auto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
";
    }
}
