namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertLNHTheme : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT [dbo].[ApplicationStyles] ([Name], [IdentityCSSFile], [UCCSSFile], [UCUICSSFile], [GETCSSFile], [GETUICSSFile]) VALUES (N'L&H', N'/Content/Styles/themes/lnh.css', N'/Content/ttdev-scss/themes/lnh.css', N'/Content/scss/themes/lnh.css', N'/GET/Styles/themes/lnh.css', N'/Content/scss/themes/lnh.css')");
        }
        
        public override void Down()
        {
        }
    }
}
