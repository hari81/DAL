namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFamilyTemplateMEX177 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX LN', 177, 230, 1, 1)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES (N'MEX BU', 177, 231, 0, 1)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX SH', 177, 232, 0, 1)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX ID', 177, 233, 1, 1)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX CR', 177, 234, 1, 4)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX TR', 177, 235, 4, 15)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX SP', 177, 236, 1, 1)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX GU', 177, 237, 1, 1)
GO
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'MEX TE', 177, 240, 0, 0)
GO
");
        }
        
        public override void Down()
        {
        }
    }
}
