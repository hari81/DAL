namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterApplicationLuConfigValueLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.APPLICATION_LU_CONFIG", "value_key", c => c.String(nullable: false, unicode: false));
            Sql(@"insert into Application_Lu_Config VALUES ('UserDisclaimer', '"+ disclaimer + "', 'Disclaimer the user has to accept before using the application. ')");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.APPLICATION_LU_CONFIG", "value_key", c => c.String(nullable: false, maxLength: 1000, unicode: false));
        }

        string disclaimer = "<p>This analysis is intended as an aid in predicting mechanical wear and should be used in conjunction with (and not as a replacement for) normal maintenance routine for machinery care. No responsibility will be accepted for failure of any machinery part or parts of machinery based upon analysis by the application and presented by the TrackTreads web service.</p><p>The machinery owner assumes responsibility for the proper maintenance and care of the subject machinery.</p><p>The information provided by you in conjunction with this web service is private and confidential.</p><p>Accounts are provided in confidence. Account log in details should be stored in a safe and secure location, should only be used by the account owner, and should not be shared to others.</p><p>The customer’s data is on the cloud with only the Customer’s Administrator having the ability to setup customer’s users with access to the customer’s data. This data is not accessible to any other customer or supplier. TrackTreads will aggregate anonymous data at Mine-site Type level to provide performance data and to improve the service. No equipment details or customers will be attached to the data.</p><p>TrackTreads’ Support staff may access a customer’s data set for the purposes of resolving a support issue or training with this customers users. More details under the privacy policy [hyperlink to PP].</p><p>The customer will not try to reverse assemble or reverse compile or directly/indirectly allow a third party to reverse assemble the software Any unauthorised use, alteration, modification, reproduction, publication, disclosure or transfer of the Licensed Software will entitle the Licensor to any available equitable remedy against the Licensee.</p><p>By signing in to this application, you acknowledge you have understood and accept the statements, terms and conditions and privacy policy stated above.</p>";
    }
}
