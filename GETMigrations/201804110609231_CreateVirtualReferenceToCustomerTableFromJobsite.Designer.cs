// <auto-generated />
namespace DAL.GETMigrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class CreateVirtualReferenceToCustomerTableFromJobsite : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(CreateVirtualReferenceToCustomerTableFromJobsite));
        
        string IMigrationMetadata.Id
        {
            get { return "201804110609231_CreateVirtualReferenceToCustomerTableFromJobsite"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
