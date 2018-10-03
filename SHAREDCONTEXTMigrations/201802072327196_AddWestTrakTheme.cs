namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWestTrakTheme : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT [dbo].[ApplicationStyles] ([Name], [IdentityCSSFile], [UCCSSFile], [UCUICSSFile], [GETCSSFile], [GETUICSSFile]) VALUES (N'West-Trak', N'/Content/Styles/themes/west-trak.css', N'/Content/ttdev-scss/themes/west-trak.css', N'/Content/scss/themes/west-trak.css', N'/GET/Styles/themes/west-trak.css', N'/Content/scss/themes/west-trak.css')");
        }
        
        public override void Down()
        {
        }
    }
}
