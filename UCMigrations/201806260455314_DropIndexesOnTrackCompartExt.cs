namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropIndexesOnTrackCompartExt : DbMigration
    {
        public override void Up()
        {
            Sql(@"

IF(
(SELECT COUNT(*)
FROM 
    sys.indexes i
INNER JOIN 
    sys.tables t ON t.object_id = i.object_id
INNER JOIN 
    sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id
INNER JOIN 
    sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
INNER JOIN 
    sys.types ty ON c.system_type_id = ty.system_type_id
WHERE 
    t.name = 'TRACK_COMPART_EXT' and i.Name = 'IX_TRACK_COMPART_EXT') > 0)
	DROP INDEX IX_TRACK_COMPART_EXT ON dbo.TRACK_COMPART_EXT

	IF(
(SELECT COUNT(*)
FROM 
    sys.indexes i
INNER JOIN 
    sys.tables t ON t.object_id = i.object_id
INNER JOIN 
    sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id
INNER JOIN 
    sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
INNER JOIN 
    sys.types ty ON c.system_type_id = ty.system_type_id
WHERE 
    t.name = 'TRACK_COMPART_EXT' and i.Name = 'IX_make_auto') > 0)
	DROP INDEX IX_make_auto ON dbo.TRACK_COMPART_EXT


IF(
(SELECT COUNT(*)
FROM 
    sys.indexes i
INNER JOIN 
    sys.tables t ON t.object_id = i.object_id
INNER JOIN 
    sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id
INNER JOIN 
    sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id
INNER JOIN 
    sys.types ty ON c.system_type_id = ty.system_type_id
WHERE 
    t.name = 'TRACK_COMPART_EXT' and i.Name = 'IX_track_compart_worn_calc_method_auto') > 0)
	DROP INDEX IX_track_compart_worn_calc_method_auto ON dbo.TRACK_COMPART_EXT

");
        }
        
        public override void Down()
        {
        }
    }
}
