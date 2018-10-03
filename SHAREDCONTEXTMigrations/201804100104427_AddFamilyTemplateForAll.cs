namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFamilyTemplateForAll : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC LN',169,230,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC BU',169,231,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC SH',169,232,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC ID',169,233,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC CR',169,234,1,4)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC TR',169,235,4,15)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC SP',169,236,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC TE',169,240,0,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'EXC GU',169,237,0,1)

INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP LN',170,230,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP BU',170,231,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP SH',170,232,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP ID',170,233,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP CR',170,234,1,3)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP TR',170,235,4,10)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP SP',170,236,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP TE',170,240,0,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'FP GU',170,237,0,1)

INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI LN',172,230,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI BU',172,231,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI SH',172,232,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI ID',172,233,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI CR',172,234,1,3)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI TR',172,235,4,15)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI SP',172,236,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI TE',172,240,0,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DRI GU',172,237,0,1)

INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP LN',184,230,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP BU',184,231,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP SH',184,232,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP ID',184,233,1,2)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP CR',184,234,0,3)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP TR',184,235,4,10)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP SP',184,236,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP TE',184,240,0,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'PIP GU',184,237,0,1)

INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO LN',197,230,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO BU',197,231,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO SH',197,232,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO ID',197,233,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO CR',197,234,0,3)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO TR',197,235,4,10)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO SP',197,236,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO TE',197,240,0,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'DOZO GU',197,237,0,1)

INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH LN',198,230,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH BU',198,231,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH SH',198,232,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH ID',198,233,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH CR',198,234,1,4)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH TR',198,235,4,10)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH SP',198,236,1,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH TE',198,240,0,1)
INSERT [dbo].[SystemFamilyTemplate] ([Name], [FamilyId], [CompartTypeId], [Min], [Max]) VALUES ( N'CH GU',198,237,0,1)
");
        }
        
        public override void Down()
        {
        }
    }
}
