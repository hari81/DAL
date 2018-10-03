namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecommendationSP : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- exec return_track_operation_4T 0,0,'Track Shoe 36 in ES'
										
ALTER PROCEDURE [dbo].[return_track_operation_4T]
	@op_type_auto bigInt,
	@compartid_auto bigInt,
	@compartment_type varchar(200) =  null	 
 AS

 DECLARE @compartType VARCHAR(25)
	if @compartment_type is not null and @compartment_type != ''
	begin

	SELECT @compartType = lct.comparttype FROM LU_COMPART lc
		INNER JOIN LU_COMPART_TYPE lct on lc.comparttype_auto = lct.comparttype_auto
	WHERE lc.compart = @compartment_type OR lc.compart = REPLACE(@compartment_type,' in','""')

		set @compartment_type = case when @compartment_type like 'Link%' then 'Link'
			when @compartment_type like 'Bushing%' then 'Bushing'
			when @compartment_type like 'Shoe%' then 'Shoe'
			when @compartment_type like 'Idler%' then 'Idler'
			when @compartment_type like 'Carrier Roller%' then 'Carrier Roller'
			when @compartment_type like 'Track Roller%' then 'Track Roller'
			when @compartment_type like 'Track Group%' then 'Track Roller'
			when @compartment_type like 'Sprocket%' then 'Sprocket'
			when @compartment_type like 'Segment%' then 'Segment'
			when @compartment_type like 'Guard%' then 'Guard'
			else NULL
			END
					
		select action_type_auto as op_type_auto, action_description as [description]
		from TRACK_ACTION_TYPE
		where compartment_type = @compartment_type
		--where compartment_type = @compartType
		order by action_description
	end
	else
	begin
		SELECT * FROM TRACK_OPERATION_TYPE
	end

	if @op_type_auto =3
		begin
			SELECT *  FROM LU_COMPART WHERE compartid_auto=@compartid_auto	
		end");
        }
        
        public override void Down()
        {
        }
    }
}
