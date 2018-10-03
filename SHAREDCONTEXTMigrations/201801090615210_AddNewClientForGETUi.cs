namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewClientForGETUi : DbMigration
    {
        public override void Up()
        {
            //Sql(sqlCode);
        }
        
        public override void Down()
        {
        }

        string sqlCode = @"
INSERT INTO Clients(Enabled, ClientId, ClientName, RequireConsent, AllowRememberConsent, AllowAccessTokensViaBrowser, LogoutSessionRequired, RequireSignOutPrompt, AllowAccessToAllScopes, IdentityTokenLifetime, AccessTokenLifetime, AuthorizationCodeLifetime, AbsoluteRefreshTokenLifetime, SlidingRefreshTokenLifetime, RefreshTokenUsage, UpdateAccessTokenOnRefresh, RefreshTokenExpiration, AccessTokenType, EnableLocalLogin, IncludeJwtId, AlwaysSendClientClaims, PrefixClientClaims, AllowAccessToAllGrantTypes) VALUES (1,'InfoTrak-Staff-GET','InfoTrak Staff GET as a Client in Identity',0,	1,	1,	1,	0, 1,	0,	0,	300,	3600,	300,	2592000,	1296000,	1,	0,	1,	0,	1,	0,	0,	1,	0)

INSERT INTO ClientRedirectUris(Uri,Client_Id) VALUES ('http://getui.tracktreads.local/account/signInCallback', 2)

update APPLICATION_LU_CONFIG SET value_key = 'http://getui.tracktreads.local/' WHERE variable_key = 'GETUri'

INSERT INTO ClientPostLogoutRedirectUris(Uri,Client_Id) VALUES ('http://getui.tracktreads.local', 2)
";

    }
}
