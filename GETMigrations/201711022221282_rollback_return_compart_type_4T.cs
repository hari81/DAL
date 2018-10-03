namespace DAL.GETMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollback_return_compart_type_4T : DbMigration
    {
        public override void Up()
        {
            Sql(alterProc1);
        }

        public override void Down()
        {
        }

        public const string alterProc1 = @"
/****** Object:  StoredProcedure [dbo].[return_compart_type_4T]    Script Date: 2/11/2017 5:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--==============================================================================================
--Matti: 1 April 2009
--added system_desc to the returned data.. required a left join to LU_SYSTEM.
--==============================================================================================
--Matti: 31 March 2009
--add a new field to the return data (system_auto). foreign key field to LU_SYSTEM.
--add new paramater @comparttype_auto to get details for specific compart type.
--==============================================================================================
--Modified by: hongJ
--Modified on: 2nd May 2008
--comments: return full list of compart types 
--==============================================================================================
ALTER PROCEDURE [dbo].[return_compart_type_4T]
	@comparttype_auto   int = null
AS

IF @comparttype_auto IS NOT NULL AND @comparttype_auto <> 0
	SELECT   comparttype_auto, comparttypeid, comparttype, protected, ct.system_auto, system_desc,comparttype_shortkey
	FROM	 LU_COMPART_TYPE ct
			 LEFT JOIN LU_SYSTEM sys ON ct.system_auto = sys.system_auto
	WHERE	 comparttype_auto = @comparttype_auto
	ORDER BY ct.sorder, comparttypeid
ELSE
	SELECT   comparttype_auto, comparttypeid, comparttype, protected, ct.system_auto, system_desc,comparttype_shortkey
	FROM	 LU_COMPART_TYPE ct
			 LEFT JOIN LU_SYSTEM sys ON ct.system_auto = sys.system_auto
	ORDER BY ct.sorder, comparttypeid

";
    }
}

