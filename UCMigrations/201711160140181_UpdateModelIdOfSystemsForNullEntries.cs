namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public partial class UpdateModelIdOfSystemsForNullEntries : DbMigration
    {
        /// <summary>
        /// This is to update existing invalid system's make and model id with current equipment make and model in database
        /// </summary>
        public override void Up()
        {
            Sql(modifyingSystems);
            /*
             * * Changed the following code because of using _context issue in production
            using (var _context = new UndercarriageContext())
            {
                var modifyingSystems = _context.LU_Module_Sub.Where(m => m.model_auto == null).ToList();
                foreach (var sys in modifyingSystems)
                {
                    if (sys.equipmentid_auto == null)
                        continue;
                    var equipment = _context.EQUIPMENTs.Find(sys.equipmentid_auto);
                    if (equipment == null)
                        continue;
                    sys.make_auto = equipment.LU_MMTA.make_auto;
                    sys.model_auto = equipment.LU_MMTA.model_auto;
                    _context.Entry(sys).State = System.Data.Entity.EntityState.Modified;
                }
                try
                {
                    _context.SaveChanges();
                    //All saved cortrrectly!
                }
                catch
                {
                    //Error occured!
                }
            }
            */
        }
        public override void Down()
        {
        }
        string modifyingSystems = @"
        	SET NOCOUNT ON;

	DECLARE @SystemId BIGINT
	DECLARE @EquipmentId BIGINT
	DECLARE modifyingSystemsCursor CURSOR FORWARD_ONLY FOR
    SELECT lms.Module_sub_auto, lms.equipmentid_auto FROM LU_Module_Sub lms
	where lms.model_auto = -1 OR lms.model_auto IS NULL
	OPEN modifyingSystemsCursor;
	FETCH NEXT FROM modifyingSystemsCursor INTO @SystemId, @EquipmentId
	WHILE @@FETCH_STATUS = 0 
	BEGIN 

	if @EquipmentId IS NOT NULL
	BEGIN
	
	DECLARE @mmtaId BIGINT
	DECLARE @makeId BIGINT
	DECLARE @modelId BIGINT

	select @mmtaId = mmtaid_auto from EQUIPMENT where equipmentid_auto = @EquipmentId

	select @makeId = make_auto,
	@modelId = model_auto
	 from LU_MMTA
	where mmtaid_auto = @mmtaId

	update LU_Module_Sub SET
	 make_auto = @makeId, 
	 model_auto = @modelId
	 where Module_sub_auto = @SystemId

	END

	FETCH NEXT FROM modifyingSystemsCursor INTO @SystemId, @EquipmentId
	END --WHILE modifyingSystemsCursor
	CLOSE modifyingSystemsCursor;
	DEALLOCATE modifyingSystemsCursor;
";
    }
}
