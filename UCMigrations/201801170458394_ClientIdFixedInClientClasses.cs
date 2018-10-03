namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientIdFixedInClientClasses : DbMigration
    {
        public override void Up()
        {
            /*
            DropForeignKey("dbo.ClientRedirectUris", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientClaims", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientCorsOrigins", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientCustomGrantTypes", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientIdPRestrictions", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientPostLogoutRedirectUris", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientScopes", "Client_Id1", "dbo.Clients");
            DropForeignKey("dbo.ClientSecrets", "Client_Id1", "dbo.Clients");
            DropIndex("dbo.ClientRedirectUris", new[] { "Client_Id1" });
            DropIndex("dbo.ClientClaims", new[] { "Client_Id1" });
            DropIndex("dbo.ClientCorsOrigins", new[] { "Client_Id1" });
            DropIndex("dbo.ClientCustomGrantTypes", new[] { "Client_Id1" });
            DropIndex("dbo.ClientIdPRestrictions", new[] { "Client_Id1" });
            DropIndex("dbo.ClientPostLogoutRedirectUris", new[] { "Client_Id1" });
            DropIndex("dbo.ClientScopes", new[] { "Client_Id1" });
            DropIndex("dbo.ClientSecrets", new[] { "Client_Id1" });
            DropColumn("dbo.ClientRedirectUris", "Client_Id");
            DropColumn("dbo.ClientClaims", "Client_Id");
            DropColumn("dbo.ClientCorsOrigins", "Client_Id");
            DropColumn("dbo.ClientCustomGrantTypes", "Client_Id");
            DropColumn("dbo.ClientIdPRestrictions", "Client_Id");
            DropColumn("dbo.ClientPostLogoutRedirectUris", "Client_Id");
            DropColumn("dbo.ClientScopes", "Client_Id");
            DropColumn("dbo.ClientSecrets", "Client_Id");
            RenameColumn(table: "dbo.ClientRedirectUris", name: "Client_Id1", newName: "Client_Id");
            RenameColumn(table: "dbo.ClientClaims", name: "Client_Id1", newName: "Client_Id");
            RenameColumn(table: "dbo.ClientCorsOrigins", name: "Client_Id1", newName: "Client_Id");
            RenameColumn(table: "dbo.ClientCustomGrantTypes", name: "Client_Id1", newName: "Client_Id");
            RenameColumn(table: "dbo.ClientIdPRestrictions", name: "Client_Id1", newName: "Client_Id");
            RenameColumn(table: "dbo.ClientPostLogoutRedirectUris", name: "Client_Id1", newName: "Client_Id");
            RenameColumn(table: "dbo.ClientScopes", name: "Client_Id1", newName: "Client_Id");
            RenameColumn(table: "dbo.ClientSecrets", name: "Client_Id1", newName: "Client_Id");
            AlterColumn("dbo.ClientRedirectUris", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientClaims", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientCorsOrigins", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientCustomGrantTypes", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientIdPRestrictions", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientPostLogoutRedirectUris", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientScopes", "Client_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientSecrets", "Client_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ClientRedirectUris", "Client_Id");
            CreateIndex("dbo.ClientClaims", "Client_Id");
            CreateIndex("dbo.ClientCorsOrigins", "Client_Id");
            CreateIndex("dbo.ClientCustomGrantTypes", "Client_Id");
            CreateIndex("dbo.ClientIdPRestrictions", "Client_Id");
            CreateIndex("dbo.ClientPostLogoutRedirectUris", "Client_Id");
            CreateIndex("dbo.ClientScopes", "Client_Id");
            CreateIndex("dbo.ClientSecrets", "Client_Id");
            AddForeignKey("dbo.ClientRedirectUris", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientClaims", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientCorsOrigins", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientCustomGrantTypes", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientIdPRestrictions", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientPostLogoutRedirectUris", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientScopes", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClientSecrets", "Client_Id", "dbo.Clients", "Id", cascadeDelete: true);
        */    
        }
        
        public override void Down()
        {
            /*
            DropForeignKey("dbo.ClientSecrets", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientScopes", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientPostLogoutRedirectUris", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientIdPRestrictions", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientCustomGrantTypes", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientCorsOrigins", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientClaims", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.ClientRedirectUris", "Client_Id", "dbo.Clients");
            DropIndex("dbo.ClientSecrets", new[] { "Client_Id" });
            DropIndex("dbo.ClientScopes", new[] { "Client_Id" });
            DropIndex("dbo.ClientPostLogoutRedirectUris", new[] { "Client_Id" });
            DropIndex("dbo.ClientIdPRestrictions", new[] { "Client_Id" });
            DropIndex("dbo.ClientCustomGrantTypes", new[] { "Client_Id" });
            DropIndex("dbo.ClientCorsOrigins", new[] { "Client_Id" });
            DropIndex("dbo.ClientClaims", new[] { "Client_Id" });
            DropIndex("dbo.ClientRedirectUris", new[] { "Client_Id" });
            AlterColumn("dbo.ClientSecrets", "Client_Id", c => c.Int());
            AlterColumn("dbo.ClientScopes", "Client_Id", c => c.Int());
            AlterColumn("dbo.ClientPostLogoutRedirectUris", "Client_Id", c => c.Int());
            AlterColumn("dbo.ClientIdPRestrictions", "Client_Id", c => c.Int());
            AlterColumn("dbo.ClientCustomGrantTypes", "Client_Id", c => c.Int());
            AlterColumn("dbo.ClientCorsOrigins", "Client_Id", c => c.Int());
            AlterColumn("dbo.ClientClaims", "Client_Id", c => c.Int());
            AlterColumn("dbo.ClientRedirectUris", "Client_Id", c => c.Int());
            RenameColumn(table: "dbo.ClientSecrets", name: "Client_Id", newName: "Client_Id1");
            RenameColumn(table: "dbo.ClientScopes", name: "Client_Id", newName: "Client_Id1");
            RenameColumn(table: "dbo.ClientPostLogoutRedirectUris", name: "Client_Id", newName: "Client_Id1");
            RenameColumn(table: "dbo.ClientIdPRestrictions", name: "Client_Id", newName: "Client_Id1");
            RenameColumn(table: "dbo.ClientCustomGrantTypes", name: "Client_Id", newName: "Client_Id1");
            RenameColumn(table: "dbo.ClientCorsOrigins", name: "Client_Id", newName: "Client_Id1");
            RenameColumn(table: "dbo.ClientClaims", name: "Client_Id", newName: "Client_Id1");
            RenameColumn(table: "dbo.ClientRedirectUris", name: "Client_Id", newName: "Client_Id1");
            AddColumn("dbo.ClientSecrets", "Client_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ClientScopes", "Client_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ClientPostLogoutRedirectUris", "Client_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ClientIdPRestrictions", "Client_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ClientCustomGrantTypes", "Client_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ClientCorsOrigins", "Client_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ClientClaims", "Client_Id", c => c.Int(nullable: false));
            AddColumn("dbo.ClientRedirectUris", "Client_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ClientSecrets", "Client_Id1");
            CreateIndex("dbo.ClientScopes", "Client_Id1");
            CreateIndex("dbo.ClientPostLogoutRedirectUris", "Client_Id1");
            CreateIndex("dbo.ClientIdPRestrictions", "Client_Id1");
            CreateIndex("dbo.ClientCustomGrantTypes", "Client_Id1");
            CreateIndex("dbo.ClientCorsOrigins", "Client_Id1");
            CreateIndex("dbo.ClientClaims", "Client_Id1");
            CreateIndex("dbo.ClientRedirectUris", "Client_Id1");
            AddForeignKey("dbo.ClientSecrets", "Client_Id1", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientScopes", "Client_Id1", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientPostLogoutRedirectUris", "Client_Id1", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientIdPRestrictions", "Client_Id1", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientCustomGrantTypes", "Client_Id1", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientCorsOrigins", "Client_Id1", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientClaims", "Client_Id1", "dbo.Clients", "Id");
            AddForeignKey("dbo.ClientRedirectUris", "Client_Id1", "dbo.Clients", "Id");
            */
        }
    }
}
