namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_compart_4T : DbMigration
    {
        public override void Up()
        {
            Sql(sp_delete_compart_4T);
        }
        
        public override void Down()
        {
        }

        string sp_delete_compart_4T = @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Modified by Ken So 22/10/2009
-- @iCount should be -8
--Modified by Ken So 31/10/2008
-- @iCount should be -10, not -13

-- modified 2 Oct  2008 Irina
-- GENERAL_COMPART_MODEL	-- not in use 
-- OIL_EQ_UNIT_COUNT		-- not in use 
-- GENERAL_EQ_UNIT_COUNT  -- not in use 
--=====================================================================

ALTER  PROCEDURE [dbo].[delete_compart_4T] 	
	@compartid_auto int,
	@affected_rowcount int OUTPUT
AS

BEGIN
	DECLARE @iCount INT
	
	SET @iCount = 0

	--can only delete compart not parents of other comparts
	IF EXISTS (SELECT * FROM LU_COMPART WHERE parentid_auto = @compartid_auto)
		BEGIN
			SET @affected_rowcount = 0
		END
	ELSE
		BEGIN
		     --can only delete compart not attached to equipment
		     SELECT  TOP 1 @iCount = 
				  ISNULL(bdr.compartid_auto, -1) +  
				  ISNULL(dclc.lu_compartid_auto, -1) +
				  ISNULL(oeu.compartid_auto, -1) +
				  ISNULL(oeuh.compartid_auto, -1) +
				  ISNULL(geu.compartid_auto, -1) +
				  ISNULL(otc.compartid_auto, -1) +
				  --ISNULL(hh.compartid_auto, -1) +
				  ISNULL(bb.compartid_auto, -1) +
				  --ISNULL(gcv.compartid_auto, -1) +
				  ISNULL(gs.compartid_auto, -1)				  
		    FROM LU_COMPART lu
				LEFT JOIN BL_DEFECT_RECORD bdr ON bdr.compartid_auto = lu.compartid_auto
				LEFT JOIN DA_COMPONENT_LU_COMPART dclc ON dclc.lu_compartid_auto = lu.compartid_auto
				LEFT JOIN OIL_EQ_UNIT oeu ON oeu.compartid_auto = lu.compartid_auto
				LEFT JOIN GENERAL_EQ_UNIT geu ON geu.compartid_auto = lu.compartid_auto
				--LEFT JOIN HYDRAULIC_EQ_UNIT hh ON lu.compartid_auto = hh.compartid_auto
				LEFT JOIN BOWL_EQ_UNIT bb ON lu.compartid_auto = bb.compartid_auto
				LEFT JOIN EQ_UNIT_HISTORY oeuh ON oeuh.compartid_auto = lu.compartid_auto
				LEFT JOIN OIL_TEMPLATE_COMPARTMENT otc ON otc.compartid_auto = lu.compartid_auto
				--LEFT JOIN GET_COMPART_VML gcv ON gcv.compartid_auto = lu.compartid_auto
				LEFT JOIN GET_SAMPLE gs ON gs.compartid_auto = lu.compartid_auto
				
			WHERE lu.compartid_auto = @compartid_auto
			
			--PRINT ('@iCount: ' + CONVERT(VARCHAR, @iCount))
			
			--Modified by Ken So 31/10/2008
			-- @iCount should be -10, not -13
			--IF @iCount = -13 
			--IF @iCount = -10
			--Modified by Ken So 22/10/2009
			-- @iCount should be -8
			IF @iCount = -8
				BEGIN
					delete from GET_COMPART_SIZE_MAPPING where compartid_auto = @compartid_auto
					DELETE FROM TRACK_COMPART_EXT where compartid_auto = @compartid_auto
					DELETE FROM LU_COMPART_USEFUL_LIFE where compartid_auto = @compartid_auto
					DELETE TRACK_COMPART_MODEL_MAPPING WHERE compartid_auto = @compartid_auto
					DELETE FROM	LU_COMPART WHERE compartid_auto = @compartid_auto				
					
					SET @affected_rowcount = @@ROWCOUNT
				END
			ELSE
				SET @affected_rowcount = 0
		END
END

";

    }
}
