namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollback_return_GET_IMPLEMENT_COMPARTTYPE : DbMigration
    {
        public override void Up()
        {
            Sql(alterProc1);
        }
        
        public override void Down()
        {
        }

        public const string alterProc1 = @"
/****** Object:  StoredProcedure [dbo].[return_GET_IMPLEMENT_COMPARTTYPE]    Script Date: 9/10/2017 12:59:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PaulN Nguyen
-- Create date: 12/10/16
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[return_GET_IMPLEMENT_COMPARTTYPE] 
	-- Add the parameters for the stored procedure here
	@implement_category_auto bigint,
	@implement_type_auto bigint
AS

	select
		comparttype_auto, comparttype 
	from
		LU_COMPART_TYPE lct
    where
		comparttype_auto not in (
			select comparttype_auto from GET_IMPLEMENT_COMPARTTYPE where implement_auto = @implement_type_auto
		)
		and 
		lct.system_auto IN (
			select system_auto from LU_SYSTEM where system_desc like '%GET%' OR system_desc like '%Body%'
		)
	order by
		lct.comparttype asc

------------------------------------------------------------------

	select 
		gic.implement_comparttype_auto,
		lct.comparttype_auto,
		lct.comparttype
	from
		GET_IMPLEMENT_COMPARTTYPE gic
		inner join LU_COMPART_TYPE lct 
		on lct.comparttype_auto = gic.comparttype_auto
		and 
		lct.system_auto IN (
			select system_auto from LU_SYSTEM where system_desc like '%GET%' OR system_desc like '%Body%'
		)
	where 
		gic.implement_auto = @implement_type_auto
	order by 
		lct.comparttype asc
";
    }
}
