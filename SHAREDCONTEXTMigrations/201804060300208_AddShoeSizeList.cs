namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoeSizeList : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            insert INTO SHOE_SIZE VALUES 
 ('12.0"" (305 mm)', 305)
,('13.0"" (330 mm)', 330)
,('14.0"" (355 mm)', 355)
,('15.0"" (380 mm)', 380)
,('16.0"" (405 mm)', 405)
,('16.9"" (430 mm)', 430)
,('17.0"" (432 mm)', 432)
,('17.7"" (450 mm)', 450)
,('18.0"" (460 mm)', 460)
,('18.9"" (480 mm)', 480)
,('19.7"" (500 mm)', 500)
,('20.0"" (510 mm)', 510)
,('21.0"" (530 mm)', 530)
,('21.7"" (550 mm)', 550)
,('22.0"" (560 mm)', 560)
,('23.0"" (585 mm)', 585)
,('23.6"" (600 mm)', 600)
,('24.0"" (610 mm)', 610)
,('25.0"" (635 mm)', 635)
,('25.6"" (650 mm)', 650)
,('26.0"" (660 mm)', 660)
,('26.5"" (675 mm)', 675)
,('27.0"" (685 mm)', 685)
,('27.5"" (700 mm)', 700)
,('27.6"" (700 mm)', 700)
,('28.0"" (710 mm)', 710)
,('29.0"" (750 mm)', 750)
,('29.5"" (750 mm)', 750)
,('30.0"" (760 mm)', 760)
,('30.3"" (770 mm)', 770)
,('31.0"" (786 mm)', 786)
,('31.1"" (790 mm)', 790)
,('31.5"" (800 mm)', 800)
,('32.0"" (810 mm)', 810)
,('33.0"" (840 mm)', 840)
,('33.5"" (850 mm)', 850)
,('34.0"" (860 mm)', 860)
,('35.0"" (900 mm)', 900)
,('35.4"" (900 mm)', 900)
,('36.0"" (915 mm)', 915)
,('38.0"" (965 mm)', 965)
,('39.0"" (990 mm)', 990)
,('39.4"" (1000 mm)', 1000)
,('40.0"" (1015 mm)', 1015)
,('41.3"" (1050 mm)', 1050)
");
        }
        
        public override void Down()
        {
        }
    }
}