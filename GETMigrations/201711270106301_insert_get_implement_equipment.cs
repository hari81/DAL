namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insert_get_implement_equipment : DbMigration
    {
        public override void Up()
        {
            Sql(alterProc1);
        }
        
        public override void Down()
        {
        }

        public const string alterProc1 = @"
/****** Object:  StoredProcedure [dbo].[insert_get_implement_equipment]    Script Date: 27/11/2017 12:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Created by PaulN Nguyen
-- Date of creation 9/9/2016
ALTER PROCEDURE [dbo].[insert_get_implement_equipment]
	@impserial		varchar(50),
	@implement_auto	bigint,
	@make_auto		int,
	@installdate		smalldatetime,
	@installsmu		bigint,
	@equipmentid_auto	bigint,
	@created_user		varchar(50),
	@EBLB			decimal(18,2) = null,
	@EBLS			decimal(18,2) = null,
	@CE				decimal(18,2) = null,
	@MB				decimal(18,2) = null,
	@MR				decimal(18,2) = null,
	@linkage		int = null,
	@bwidth			decimal(18,2) = null,
	@BE				decimal(18,2) = null,
	@num			int = null,
	@get_auto		bigint = 0,
	@seglength      decimal(18,2) = null,
	@feet_type_auto bigint = 0,
	@num_feet		varchar(50),
	@start_height   decimal(18,2) = null,
	@end_height     decimal(18,2) = null,
	@return_getauto	int OUTPUT,
	@impsetup_hours bigint = 0

AS
DECLARE @sqlInsert varchar(3000)
DECLARE @sqlValues varchar(3000)
DECLARE @sqlUpdate varchar(3000)
DECLARE @sqlSet	   varchar(3000)
DECLARE @sqlWhere  varchar(3000)

if(@get_auto = 0)
begin
	if exists (select impserial from GET where Upper(impserial)=Upper(@impserial))
		begin
			RAISERROR ('Implement serial number already exists!', 16, 1)
			set @return_getauto = -1
			return @return_getauto
		end
	else
		begin
			set @sqlInsert = 'INSERT INTO GET (impserial, implement_auto, isinuse, equipmentid_auto, installsmu, created_user, created_date, make_auto, num '
			set @sqlValues = 'VALUES ('''+@impserial+''','+cast(@implement_auto as varchar)+', 1,'+cast(@equipmentid_auto as varchar)+','+cast(@installsmu as varchar)+' ,'+cast(@created_user as varchar)+' , '+@installdate+', '+cast(@make_auto as varchar)+' , ' + cast(@num as varchar) + ' '

			if (@linkage is not null)
			begin
				set @sqlInsert = @sqlInsert + ',get_linkage_system_auto'
				set @sqlValues = @sqlValues + ',' + cast(@linkage as varchar)
			end

			if (@bwidth is not  null)
			begin

				set @sqlInsert = @sqlInsert + ',bucket_width'
				set @sqlValues = @sqlValues + ',' + cast(@bwidth as varchar)
			end

			if (@BE is not  null)
			begin
				set @sqlInsert = @sqlInsert + ',base_edge_thickness'
				set @sqlValues = @sqlValues + ',' + cast(@BE as varchar)
			end

			if (@EBLB is not  null)
			begin
				set @sqlInsert = @sqlInsert + ',eb_bottom_thickness'
				set @sqlValues = @sqlValues + ',' + cast(@EBLB as varchar)
			end

			if (@EBLS is not  null)
			begin
				set @sqlInsert = @sqlInsert + ',eb_side_thickness'
				set @sqlValues = @sqlValues + ',' + cast(@EBLS as varchar)
			end

			if (@CE is not  null)
			begin
				set @sqlInsert = @sqlInsert + ',cutting_edge_thickness'
				set @sqlValues = @sqlValues + ',' + cast(@CE as varchar)
			end

			if (@MB is not  null)
			begin
				set @sqlInsert = @sqlInsert + ',mb_bottom_thickness'
				set @sqlValues = @sqlValues + ',' + cast(@MB as varchar)
			end

			if (@MR is not  null)
			begin
				set @sqlInsert = @sqlInsert + ',mb_rear_thickness'
				set @sqlValues = @sqlValues + ',' + cast(@MR as varchar)
			end

			if (@seglength is not null)
			begin
				set @sqlInsert = @sqlInsert + ',segment_length'
				set @sqlValues = @sqlValues + ',' + cast(@seglength as varchar)
			end

			if (@feet_type_auto is not null)
			begin
				set @sqlInsert = @sqlInsert + ',feet_type_auto'
				set @sqlValues = @sqlValues + ',' + cast(@feet_type_auto as varchar)
			end

			if (@num_feet is not null)
			begin
				set @sqlInsert = @sqlInsert + ',num_feet'
				if @num_feet = ''
					set @sqlValues = @sqlValues + ',' + ''''''
				else
					set @sqlValues = @sqlValues + ',' + @num_feet
			end

			if (@start_height is not null)
			begin
				set @sqlInsert = @sqlInsert + ',start_height'
				set @sqlValues = @sqlValues + ',' + cast(@start_height as varchar)
			end

			if (@end_height is not null)
			begin
				set @sqlInsert = @sqlInsert + ',end_height'
				set @sqlValues = @sqlValues + ',' + cast(@end_height as varchar)
			end

			IF (@impsetup_hours IS NOT NULL)
			BEGIN
				SET @sqlInsert = @sqlInsert + ',impsetup_hours'
				SET @sqlValues = @sqlValues + ',' + CAST(@impsetup_hours AS VARCHAR)
			END

			set @sqlInsert = @sqlInsert + ')'
			set @sqlValues = @sqlValues + ')'

			print @sqlInsert
			print @sqlValues
			exec (@sqlInsert+@sqlValues)

			select top 1 @return_getauto = get_auto from [GET] order by 1 desc
			return @return_getauto
		end
end

else
begin
		if exists (select impserial from GET where Upper(impserial)=Upper(@impserial) and get_auto <> @get_auto)
		begin
			RAISERROR ('Implement serial number already exists!', 16, 1)
			set @return_getauto = -1
			return @return_getauto
		end
		else
		begin
			declare @old_impSN varchar(50)
			select @old_impSN = impserial from GET where get_auto = @get_auto
			if @old_impSN <> @impserial
			begin
				update GET
				set impserial = @impserial where get_auto = @get_auto
				
				update GET_UNIT
				set impserial = @impserial where impserial = @old_impSN
				
				update GET_EQ_UNIT
				set impserial = @impserial where impserial = @old_impSN
			end
			set @sqlUpdate = 'Update GET ' --(impserial, implement_auto, isinuse, equipmentid_auto, installsmu, created_user, created_date, make_auto, num '
			set @sqlSet = 'SET installsmu=' + cast(@installsmu as varchar) + ' '

			if (@linkage is not null)
			begin
				set @sqlSet = @sqlSet + ', get_linkage_system_auto=' + cast(@linkage as varchar)
			end

			if (@bwidth is not  null)
			begin
				set @sqlSet = @sqlSet + ', bucket_width=' + cast(@bwidth as varchar)
			end

			if (@BE is not  null)
			begin
				set @sqlSet = @sqlSet + ', base_edge_thickness=' + cast(@BE as varchar)
			end

			if (@EBLB is not  null)
			begin
				set @sqlSet = @sqlSet + ', eb_bottom_thickness=' + cast(@EBLB as varchar)
			end

			if (@EBLS is not  null)
			begin
				set @sqlSet = @sqlSet + ', eb_side_thickness=' + cast(@EBLS as varchar)
			end

			if (@CE is not  null)
			begin
				set @sqlSet = @sqlSet + ', cutting_edge_thickness=' + cast(@CE as varchar)
			end

			if (@MB is not  null)
			begin
				set @sqlSet = @sqlSet + ', mb_bottom_thickness=' + cast(@MB as varchar)
			end

			if (@MR is not  null)
			begin
				set @sqlSet = @sqlSet + ', mb_rear_thickness=' + cast(@MR as varchar)
			end
			
			if (@seglength is not null)
			begin
				set @sqlSet = @sqlSet + ', segment_length=' + cast(@seglength as varchar)
			end

			if (@feet_type_auto is not null)
			begin
				set @sqlSet = @sqlSet + ', feet_type_auto=' + cast(@feet_type_auto as varchar)
			end

			if (@num_feet is not null)
			begin
				if @num_feet = ''
					set @sqlSet = @sqlSet + ', num_feet=' + ''''''
				else
					set @sqlSet = @sqlSet + ', num_feet=' + @num_feet
			end

			if (@start_height is not null)
			begin
				set @sqlSet = @sqlSet + ', start_height=' + cast(@start_height as varchar)
			end

			if (@end_height is not null)
			begin
				set @sqlSet = @sqlSet + ', end_height=' + cast(@end_height as varchar)
			end

			IF (@impsetup_hours IS NOT NULL)
			BEGIN
				SET @sqlSet = @sqlSet + ', impsetup_hours=' + CAST(@impsetup_hours AS VARCHAR)
			END


			set @sqlWhere = ' where get_auto=' + cast(@get_auto as varchar)
			print (@sqlUpdate+@sqlSet+@sqlWhere)
			exec (@sqlUpdate+@sqlSet+@sqlWhere)
			
			set @return_getauto = @get_auto
			return @return_getauto
		end
end




";
    }
}
