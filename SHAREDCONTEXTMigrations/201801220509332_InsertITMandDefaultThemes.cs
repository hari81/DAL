namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertITMandDefaultThemes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT [dbo].[ApplicationStyles] ([Name], [IdentityCSSFile], [UCCSSFile], [UCUICSSFile], [GETCSSFile], [GETUICSSFile]) VALUES (N'Default', N'/Content/Styles/themes/default.css', N'/Content/ttdev-scss/themes/default.css', N'/Content/scss/themes/default.css', N'/GET/Styles/themes/default.css', N'/Content/scss/themes/default.css')
                    INSERT [dbo].[ApplicationStyles] ([Name], [IdentityCSSFile], [UCCSSFile], [UCUICSSFile], [GETCSSFile], [GETUICSSFile]) VALUES (N'ITM', N'/Content/Styles/themes/itm.css', N'/Content/ttdev-scss/themes/itm.css', N'/Content/scss/themes/itm.css', N'/GET/Styles/themes/itm.css', N'/Content/scss/themes/itm.css')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
