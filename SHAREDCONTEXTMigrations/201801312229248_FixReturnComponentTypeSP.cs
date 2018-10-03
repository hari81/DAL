namespace DAL.SHAREDCONTEXTMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixReturnComponentTypeSP : DbMigration
    {

        /// <summary>
        /// Change stored procedure used on component setup page to only return component types for undercarriage,
        /// and exclude GET and Dump Body component types. 
        /// </summary>
        public override void Up()
        {
            Sql(@"/****** Object:  StoredProcedure [dbo].[return_comparttype_list_4T]    Script Date: 1/02/2018 9:24:48 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
--=======================================================================================================
-- Modified By:	Nouman | 25-09-2015 | PRN9300 and did formatting and indendation
--Matti: 08/04/2009 - add a new paramater to return compartment types by their system.
-- Modified by Josh on the 12th Feb 2008
-- To include all Modules including HYDRAULIC EQ UNIT and GENERAL EQ UNIT tables
--=======================================================================================================
ALTER PROCEDURE [dbo].[return_comparttype_list_4T] 
	@progid 			INT		= NULL,
	@moduleid			INT		= NULL,
	@equipmentid_auto	BIGINT	= 0,
	@system_auto		SMALLINT= NULL
AS
BEGIN
------------------------------------------------------------------------------------------------------------------------*
IF @system_auto IS NOT NULL
BEGIN
	SELECT     comparttype_auto, comparttypeid, comparttype
	FROM       LU_COMPART_TYPE
	WHERE	   system_auto = @system_auto
	ORDER BY   comparttype ASC
	RETURN
END

IF @equipmentid_auto != 0  AND @equipmentid_auto IS NOT NULL
BEGIN
	SELECT * FROM
	((SELECT DISTINCT compt.comparttype_auto, comparttypeid, comparttype 
		FROM OIL_EQ_UNIT eu ,lu_compart comp,lu_compart_type compt
		WHERE eu.compartid_auto = comp.compartid_auto
			AND comp.comparttype_auto = compt.comparttype_auto
			AND equipmentid_auto = @equipmentid_auto)

	UNION
	
	(
	SELECT DISTINCT compt.comparttype_auto, comparttypeid, comparttype 
		FROM GENERAL_EQ_UNIT geu ,LU_COMPART comp,LU_COMPART_TYPE compt, LU_SYSTEM s
		WHERE geu.compartid_auto = comp.compartid_auto
			AND	comp.comparttype_auto = compt.comparttype_auto
			AND compt.system_auto = s.system_auto
			AND s.system_auto != (SELECT system_auto FROM LU_SYSTEM WHERE system_desc = 'U/C' OR system_desc = 'Undercarriage')
			AND	equipmentid_auto = @equipmentid_auto

	))dd
	ORDER BY dd.comparttype ASC

	RETURN
END
------------------------------------------------------------------------------------------------------------------------- * added by Nadeetha 16 Dec 2006  to get comparttype list for an equipment
IF @progid IS null AND @moduleid IS null
	SELECT     comparttype_auto, comparttypeid, comparttype
	FROM         LU_COMPART_TYPE ct
	INNER JOIN LU_SYSTEM s on s.system_auto = ct.system_auto
	WHERE s.system_desc like '%U/C%'
	ORDER BY comparttype ASC
ELSE IF @progid IS NOT null AND @moduleid IS null
	SELECT      DISTINCT comptype.comparttype_auto, comptype.comparttypeid, comptype.comparttype
	FROM         LU_COMPART_TYPE comptype
	INNER JOIN LU_COMPART comp ON comp.comparttype_auto = comptype.comparttype_auto
	WHERE 	    comp.progid = @progid
	ORDER BY comparttype ASC
ELSE IF @progid IS null AND  @moduleid IS NOT null
	SELECT      DISTINCT comptype.comparttype_auto, comptype.comparttypeid, comptype.comparttype
	FROM         LU_COMPART_TYPE comptype
	INNER JOIN LU_COMPART comp ON comp.comparttype_auto = comptype.comparttype_auto
	INNER JOIN LU_MODULE module ON comp.progid = module.progid
	WHERE 	    module.moduleid = @moduleid
	ORDER BY comparttype ASC
ELSE IF @progid IS NOT null AND  @moduleid IS NOT null
	SELECT      DISTINCT comptype.comparttype_auto, comptype.comparttypeid, comptype.comparttype
	FROM         LU_COMPART_TYPE comptype
	INNER JOIN LU_COMPART comp ON comp.comparttype_auto = comptype.comparttype_auto
	INNER JOIN LU_MODULE module ON comp.progid = module.progid
	WHERE 	    module.moduleid = @moduleid AND comp.progid = @progid
	ORDER BY comparttype ASC

END
");

            // Also update the worn limit menu item link to the correct page name. 
            Sql(@"update menu_l3
set targetpath='track/undercarriagewornlimit.aspx'
where targetpath='track/undercarriagewornlimithidden.aspx'");
        }
        
        public override void Down()
        {
        }
    }
}
