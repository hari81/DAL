namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityTablesAdded : DbMigration
    {
        public override void Up()
        {
            /* Already exist 
            CreateTable(
                "dbo.ClientClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 250),
                        Value = c.String(nullable: false, maxLength: 250),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                        ClientId = c.String(nullable: false, maxLength: 200),
                        ClientName = c.String(nullable: false, maxLength: 200),
                        ClientUri = c.String(maxLength: 2000),
                        LogoUri = c.String(),
                        RequireConsent = c.Boolean(nullable: false),
                        AllowRememberConsent = c.Boolean(nullable: false),
                        Flow = c.Int(nullable: false),
                        IdentityTokenLifetime = c.Int(nullable: false),
                        AccessTokenLifetime = c.Int(nullable: false),
                        AuthorizationCodeLifetime = c.Int(nullable: false),
                        AbsoluteRefreshTokenLifetime = c.Int(nullable: false),
                        SlidingRefreshTokenLifetime = c.Int(nullable: false),
                        RefreshTokenUsage = c.Int(nullable: false),
                        RefreshTokenExpiration = c.Int(nullable: false),
                        AccessTokenType = c.Int(nullable: false),
                        EnableLocalLogin = c.Boolean(nullable: false),
                        IncludeJwtId = c.Boolean(nullable: false),
                        AlwaysSendClientClaims = c.Boolean(nullable: false),
                        PrefixClientClaims = c.Boolean(nullable: false),
                        AllowClientCredentialsOnly = c.Boolean(nullable: false),
                        UpdateAccessTokenOnRefresh = c.Boolean(nullable: false),
                        AllowAccessToAllScopes = c.Boolean(nullable: false),
                        AllowAccessToAllGrantTypes = c.Boolean(nullable: false),
                        LogoutUri = c.String(),
                        LogoutSessionRequired = c.Boolean(nullable: false),
                        RequireSignOutPrompt = c.Boolean(nullable: false),
                        AllowAccessTokensViaBrowser = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClientCorsOrigins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Origin = c.String(nullable: false, maxLength: 150),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.ClientCustomGrantTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GrantType = c.String(nullable: false, maxLength: 250),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.ClientIdPRestrictions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Provider = c.String(nullable: false, maxLength: 200),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.ClientPostLogoutRedirectUris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uri = c.String(nullable: false, maxLength: 2000),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.ClientRedirectUris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Uri = c.String(nullable: false, maxLength: 2000),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.ClientScopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Scope = c.String(nullable: false, maxLength: 200),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.ClientSecrets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false, maxLength: 250),
                        Type = c.String(maxLength: 250),
                        Description = c.String(maxLength: 2000),
                        Expiration = c.DateTimeOffset(precision: 7),
                        Client_Id = c.Int(nullable: false),
                        Client_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Client_Id1)
                .Index(t => t.Client_Id1);
            
            CreateTable(
                "dbo.Consents",
                c => new
                    {
                        Subject = c.String(nullable: false, maxLength: 200),
                        ClientId = c.String(nullable: false, maxLength: 200),
                        Scopes = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => new { t.Subject, t.ClientId });
            
            CreateTable(
                "dbo.ScopeClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        AlwaysIncludeInIdToken = c.Boolean(nullable: false),
                        Scope_Id = c.Int(nullable: false),
                        Scope_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scopes", t => t.Scope_Id1)
                .Index(t => t.Scope_Id1);
            
            CreateTable(
                "dbo.Scopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Enabled = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        DisplayName = c.String(maxLength: 200),
                        Description = c.String(maxLength: 1000),
                        Required = c.Boolean(nullable: false),
                        Emphasize = c.Boolean(nullable: false),
                        Type = c.Int(nullable: false),
                        IncludeAllClaimsForUser = c.Boolean(nullable: false),
                        ClaimsRule = c.String(maxLength: 200),
                        ShowInDiscoveryDocument = c.Boolean(nullable: false),
                        AllowUnrestrictedIntrospection = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScopeSecrets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1000),
                        Expiration = c.DateTimeOffset(precision: 7),
                        Type = c.String(maxLength: 250),
                        Value = c.String(nullable: false, maxLength: 250),
                        Scope_Id = c.Int(nullable: false),
                        Scope_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Scopes", t => t.Scope_Id1)
                .Index(t => t.Scope_Id1);
            */
        }
        
        public override void Down()
        {
            /*
            DropForeignKey("dbo.ScopeSecrets", "Scope_Id1", "dbo.Scopes");
            DropForeignKey("dbo.ScopeClaims", "Scope_Id1", "dbo.Scopes");
            DropForeignKey("dbo.ClientSecrets", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientScopes", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientRedirectUris", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientPostLogoutRedirectUris", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientIdPRestrictions", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientCustomGrantTypes", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientCorsOrigins", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientClaims", "Client_Id1", "dbo.Clients");
            DropIndex("dbo.ScopeSecrets", new[] { "Scope_Id1" });
            DropIndex("dbo.ScopeClaims", new[] { "Scope_Id1" });
            DropIndex("dbo.ClientSecrets", new[] { "Client_Id1" });
            DropIndex("dbo.ClientScopes", new[] { "Client_Id1" });
            DropIndex("dbo.ClientRedirectUris", new[] { "Client_Id1" });
            DropIndex("dbo.ClientPostLogoutRedirectUris", new[] { "Client_Id1" });
            DropIndex("dbo.ClientIdPRestrictions", new[] { "Client_Id1" });
            DropIndex("dbo.ClientCustomGrantTypes", new[] { "Client_Id1" });
            DropIndex("dbo.ClientCorsOrigins", new[] { "Client_Id1" });
            DropIndex("dbo.ClientClaims", new[] { "Client_Id1" });
            DropTable("dbo.ScopeSecrets");
            DropTable("dbo.Scopes");
            DropTable("dbo.ScopeClaims");
            DropTable("dbo.Consents");
            DropTable("dbo.ClientSecrets");
            DropTable("dbo.ClientScopes");
            DropTable("dbo.ClientRedirectUris");
            DropTable("dbo.ClientPostLogoutRedirectUris");
            DropTable("dbo.ClientIdPRestrictions");
            DropTable("dbo.ClientCustomGrantTypes");
            DropTable("dbo.ClientCorsOrigins");
            DropTable("dbo.Clients");
            DropTable("dbo.ClientClaims");
            */
        }
    }
}
