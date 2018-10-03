namespace DAL.UCMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifySPstore_compart_4T : DbMigration
    {
        public override void Up()
        {
            Sql(@"

/****** Object:  StoredProcedure [dbo].[store_compart_4T]    Script Date: 9/05/2018 12:34:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Daniel Shi on 19 Nov 2010
-- added duplication test when update
--===============================================================
-- Rumesh MM on 29-07-2009 fixed the decimal conversion bug when reading from the xml
-- 7 Oct 2008 Modified  Irina
-- fields names changed rebuil_cost, remove_install_cost instead of labour_hrs, labour_cost
--===============================================================
-- modified  by  Yong 2 Nov 2007
-- for struct update 

--Modified by: Hanson Chan
--Modified date: 23/10/07
--Comment: add transaction

--Modified by: Dave W
--Modified date: 06 March 2008
--Modified reason: structure update

--Modified by: hong J on 16 Sep 2008
--hrs_to_remove, hrs_to_install, hrs_to_rebuild and labour_hrs changed from int to decimal(18,2)

ALTER  PROCEDURE [dbo].[store_compart_4T]
	@xmlDoc varchar(7000),	
	@affected_compartid_auto	int OUTPUT
AS
	DECLARE @idoc	int
	DECLARE @userid int
	DECLARE @username	varchar(50)
	DECLARE @compartid	varchar(20)
	DECLARE @compart	VARCHAR(50)
	DECLARE @compartid_auto int
	DECLARE @progrid		int	
	DECLARE @parentid_auto	int
	DECLARE @readAsEval BIT = 0
	--new paramter for PRN 7933
	declare @all_applied_models varchar(1000)
	declare @make_auto int,@tools_auto	int,@budget_life int

    EXEC sp_xml_preparedocument @idoc  OUTPUT, @xmlDoc
		
	SELECT  @compartid_auto = compartid_auto,
			@compartid		= compartid,
			@compart		= compart,
			@progrid		= progid,
			@parentid_auto  = parentid_auto,
			@userid			= userid,
			@readAsEval		= ReadAsEval			
			FROM OPENXML(@idoc , '/ROOT', 3) 
			WITH (	compartid_auto	int,
					compartid		varchar (20),
					compart			varchar(50),
					progid			int,
					parentid_auto	int,
					userid			varchar(50),
					ReadAsEval		bit
					)
	select @all_applied_models=model_ids,
		@make_auto		= nullif(nullif(make_auto,''),0),
		@tools_auto		= nullif(nullif(tool_auto,''),0),
		@budget_life	= nullif(nullif(budget_life,''),0)
		FROM OPENXML(@idoc , '/ROOT/TRACK_EXT', 3) 
			WITH (	model_ids	varchar(1000),
				make_auto	int,
				tool_auto	int,
				budget_life int) 
 
	declare @is_get bit
	declare @size int
	declare @limit_new decimal(18,2)
	declare @limit_worn decimal(18,2)
	declare @max_qty int	

	select  @is_get=is_get, @size = size,@limit_new = limit_new,@limit_worn =limit_worn,@max_qty = max_qty	
	FROM OPENXML(@idoc , '/ROOT/GET_SIZE', 3) WITH ( is_get bit,size int,limit_new decimal(18,2),limit_worn decimal(18,2),max_qty int) 

	SELECT @username = username FROM USER_TABLE WHERE user_auto = @userid
	begin tran updateLuCompart
	
	if @compartid_auto = 0
		begin
			--IF NOT EXISTS (SELECT * FROM LU_COMPART WHERE compartid = @compartid)
			IF  EXISTS (SELECT * FROM LU_COMPART WHERE compartid = @compartid AND progid = @progrid AND allow_duplicate = 0)
				set @affected_compartid_auto = 0
			ELSE
			begin
				--allow_duplicate is always 1 as per document. I confirmed with samuel.PRN 7933
				INSERT INTO LU_COMPART
					(   compartid,	compart,	smcs_code,	modifier_code,	
						progid,	parentid_auto,	sumpcapacity,
						max_rebuilt,
						oilsample_interval,	oilchg_interval,
						insp_item,	insp_interval,	insp_uom,
						comparttype_auto,
						created_date,	created_user,modified_date, modified_user,						
						compart_note, positionid_auto, allow_duplicate, AcceptEvalAsReading )
				SELECT  compartid,
						compart,
						CASE smcs_code	WHEN '' THEN NULL ELSE smcs_code END,
						CASE modifier_code	WHEN '' THEN NULL ELSE modifier_code	END,
						progid,
						CASE parentid_auto	WHEN '' THEN NULL ELSE parentid_auto END,
						CASE sumpcapacity WHEN '' THEN 0 ELSE sumpcapacity	END,
						CASE max_rebuilt WHEN '' THEN 20	ELSE max_rebuilt END,
						CASE oilsample_interval	WHEN '' THEN 0 	ELSE oilsample_interval	END,
						CASE oilchg_interval WHEN '' THEN 0 ELSE oilchg_interval END,
						CASE insp_item	WHEN '' THEN NULL ELSE insp_item END,
						CASE insp_interval	WHEN '' THEN NULL ELSE insp_interval END,
						CASE insp_uom WHEN '' THEN NULL ELSE insp_uom END,
						comparttype_auto,
						GETDATE(),
						CASE @username WHEN '' THEN NULL ELSE @username END,						
						GETDATE(),
						CASE @username WHEN '' THEN NULL ELSE @username END,						
						CASE note WHEN '' THEN NULL ELSE note END,
						positionid_auto,
						allow_duplicate, ReadAsEval
				FROM OPENXML(@idoc , '/ROOT', 3) 
				WITH (	compartid_auto			int				,
						compartid				varchar (20)	,
						compart					varchar (50)	,
						smcs_code				int				,
						modifier_code			varchar (20)	,
						progid					tinyint			,
						parentid_auto			int				,
						sumpcapacity			int		,
						max_rebuilt				int		,
						oilsample_interval		smallint		,
						oilchg_interval			smallint		,
						insp_item				bit				,
						insp_interval			smallint		,
						insp_uom				smallint		,
						comparttype_auto		int				,
						note					varchar (1000)  ,
						positionid_auto			INT				,
						allow_duplicate			BIT				,
						ReadAsEval BIT
							) XMLCompart 
				WHERE XMLCompart.compartid_auto NOT IN (SELECT compartid_auto FROM LU_COMPART)
			
				if @@error<>0 goto err		
		
				set @affected_compartid_auto = @@identity
				
				--new code for mapping model PRN 7933
				--insert all models applied to undercarriage
				if isnull(@affected_compartid_auto,0) > 0
				begin				
					--first delete if it is not exist in new list
					delete from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto and model_auto not in(select Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,','))
					if @@error<>0 goto err	
					--now insert new if it is not already into table.
					insert into TRACK_COMPART_MODEL_MAPPING(compartid_auto,model_auto)
					select @affected_compartid_auto,Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,',') where Data not in (select model_auto from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto) 
					 if @@error<>0 goto err	
				end
				--insert new extra fields for under carriage PRN 7933
				if isnull(@affected_compartid_auto,0) > 0
				begin
					INSERT INTO [dbo].[TRACK_COMPART_EXT]
						   ([compartid_auto]
						   ,[make_auto]
						   ,[tools_auto]
						   ,[budget_life])
					 VALUES
						   (@affected_compartid_auto
						   ,@make_auto
						   ,@tools_auto
						   ,@budget_life)
				end

			end	
		end
	else	
		begin
			
			--SELECT * FROM LU_COMPART WHERE compartid = @compartid And compartid_auto <> @compartid_auto AND allow_duplicate = 0
			
			IF @@ROWCOUNT > 0
				set @affected_compartid_auto = 0
			ELSE
			begin
					UPDATE LU_COMPART 
					SET LU_COMPART.compartid				= XMLCompart.compartid,
						LU_COMPART.compart					= XMLCompart.compart,	
						LU_COMPART.smcs_code				= XMLCompart.smcs_code,	
						LU_COMPART.modifier_code			= XMLCompart.modifier_code,			
						LU_COMPART.progid					= XMLCompart.progid,		
						LU_COMPART.parentid_auto			= XMLCompart.parentid_auto,				
						LU_COMPART.sumpcapacity				= XMLCompart.sumpcapacity,		
						LU_COMPART.max_rebuilt				= XMLCompart.max_rebuilt,
						LU_COMPART.oilsample_interval		= XMLCompart.oilsample_interval,
						LU_COMPART.oilchg_interval			= XMLCompart.oilchg_interval,
						LU_COMPART.insp_item				= XMLCompart.insp_item,
						LU_COMPART.insp_interval			= XMLCompart.insp_interval,
						LU_COMPART.insp_uom					= XMLCompart.insp_uom,
						LU_COMPART.comparttype_auto			= XMLCompart.comparttype_auto,
						LU_COMPART.modified_date			= GETDATE(),
						LU_COMPART.modified_user			= @username,
						LU_COMPART.compart_note				= XMLCompart.note,
						LU_COMPART.positionid_auto			= XMLCompart.positionid_auto,
						LU_COMPART.allow_duplicate 			= XMLCompart.allow_duplicate,
						LU_COMPART.AcceptEvalAsReading		= XMLCompart.ReadAsEval
					FROM OPENXML(@idoc , '/ROOT', 3) 
					WITH (	compartid_auto			int				,
							compartid				varchar (20)	,
							compart					varchar (50)	,
							smcs_code				int				,
							modifier_code			varchar (20)	,
							progid					tinyint			,
							parentid_auto			int				,
							sumpcapacity			int		,
							max_rebuilt				int		,
							oilsample_interval		smallint		,
							oilchg_interval			smallint		,
							insp_item				bit				,
							insp_interval			smallint		,
							insp_uom				smallint		,
							comparttype_auto		int				,
							note					varchar (1000)  ,
							positionid_auto			INT				,
							allow_duplicate			BIT				,
							ReadAsEval				BIT	
							) XMLCompart
					WHERE LU_COMPART.compartid_auto = XMLCompart.compartid_auto

					if @@error<>0 goto err
					
					set @affected_compartid_auto = @compartid_auto
					
						--new code for mapping model
						if isnull(@affected_compartid_auto,0) > 0
						begin				
							--first delete if it is not exist in new list
							delete from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto and model_auto not in(select Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,','))
							if @@error<>0 goto err	
							--now insert new if it is not already into table.
							insert into TRACK_COMPART_MODEL_MAPPING(compartid_auto,model_auto)
							select @affected_compartid_auto,Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,',') where Data not in (select model_auto from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto) 
							 if @@error<>0 goto err	
						end

						--insert new extra fields for under carriage PRN 7933
						if isnull(@affected_compartid_auto,0) > 0
						begin	
							if (select count(*) from [TRACK_COMPART_EXT] where [compartid_auto]=@affected_compartid_auto) > 0
							begin
								UPDATE [dbo].[TRACK_COMPART_EXT]
								   SET [make_auto] = @make_auto
									  ,[tools_auto] = @tools_auto
									  ,[budget_life] = @budget_life
								 WHERE [compartid_auto] = @affected_compartid_auto

							end
							else
							begin
									INSERT INTO [dbo].[TRACK_COMPART_EXT]
									   ([compartid_auto]
									   ,[make_auto]
									   ,[tools_auto]
									   ,[budget_life])
								 VALUES
									   (@affected_compartid_auto
									   ,@make_auto
									   ,@tools_auto
									   ,@budget_life)
							end
						end
			end
		end
		
	if ( @is_get = 1 and isnull(@affected_compartid_auto, 0) <> 0 and isnull(@size, 0) > 0)
	exec dbo.GET_COMPART_SIZE_store @size_auto=0, @size = @size , @limit_new = @limit_new , @limit_worn = @limit_worn , @max_qty = @max_qty , @compartid_auto = @affected_compartid_auto

	IF isnull(@affected_compartid_auto, 0) <> 0
		BEGIN
			SELECT * FROM LU_COMPART_USEFUL_LIFE WHERE compartid_auto = @affected_compartid_auto
			IF @@ROWCOUNT > 0
				DELETE FROM LU_COMPART_USEFUL_LIFE WHERE compartid_auto = @affected_compartid_auto
		
			INSERT INTO LU_COMPART_USEFUL_LIFE
			(	compartid_auto, 
				useful_life_type,
				useful_life,
				rebuild_cost,
				remove_install_cost,
				part_cost,	other_cost,
				hrs_to_remove,	hrs_to_install,	hrs_to_rebuild
			)
			SELECT	
				@affected_compartid_auto,
				useful_life_type,
				CASE useful_life WHEN '' THEN 0 	ELSE useful_life	END as useful_life,
				rebuild_cost,
				remove_install_cost,
				part_cost,	other_cost,
				CAST(hrs2remove as decimal(18,2)),	CAST(hrs2install as decimal(18,2)),	CAST(hrs2rebuild as decimal(18,2))				
			FROM OPENXML(@idoc , '/ROOT/USEFUL_LIFE', 3) 
				WITH (	useful_life_type		tinyint	,
						useful_life				int		,
						rebuild_cost			money	,
						remove_install_cost		money,
						part_cost				money	,
						other_cost				money	,
						hrs2remove				money,
						hrs2install				money,
						hrs2rebuild				money) XMLCompart
				
			if @@error<>0 goto err
		
		END
	
	commit tran updateLuCompart
		
	EXEC sp_xml_removedocument @idoc

	
	return --@affected_compartid_auto

err:
rollback tran updateLuCompart
return



");
        }
        
        public override void Down()
        {
            Sql(@"

/****** Object:  StoredProcedure [dbo].[store_compart_4T]    Script Date: 9/05/2018 9:01:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Daniel Shi on 19 Nov 2010
-- added duplication test when update
--===============================================================
-- Rumesh MM on 29-07-2009 fixed the decimal conversion bug when reading from the xml
-- 7 Oct 2008 Modified  Irina
-- fields names changed rebuil_cost, remove_install_cost instead of labour_hrs, labour_cost
--===============================================================
-- modified  by  Yong 2 Nov 2007
-- for struct update 

--Modified by: Hanson Chan
--Modified date: 23/10/07
--Comment: add transaction

--Modified by: Dave W
--Modified date: 06 March 2008
--Modified reason: structure update

--Modified by: hong J on 16 Sep 2008
--hrs_to_remove, hrs_to_install, hrs_to_rebuild and labour_hrs changed from int to decimal(18,2)

ALTER  PROCEDURE [dbo].[store_compart_4T]
	@xmlDoc varchar(7000),	
	@affected_compartid_auto	int OUTPUT
AS
	DECLARE @idoc	int
	DECLARE @userid int
	DECLARE @username	varchar(50)
	DECLARE @compartid	varchar(20)
	DECLARE @compart	VARCHAR(50)
	DECLARE @compartid_auto int
	DECLARE @progrid		int	
	DECLARE @parentid_auto	int

	--new paramter for PRN 7933
	declare @all_applied_models varchar(1000)
	declare @make_auto int,@tools_auto	int,@budget_life int

    EXEC sp_xml_preparedocument @idoc  OUTPUT, @xmlDoc
		
	SELECT  @compartid_auto = compartid_auto,
			@compartid		= compartid,
			@compart		= compart,
			@progrid		= progid,
			@parentid_auto  = parentid_auto,
			@userid			= userid			
			FROM OPENXML(@idoc , '/ROOT', 3) 
			WITH (	compartid_auto	int,
					compartid		varchar (20),
					compart			varchar(50),
					progid			int,
					parentid_auto	int,
					userid			varchar(50)
					)
	select @all_applied_models=model_ids,
		@make_auto		= nullif(nullif(make_auto,''),0),
		@tools_auto		= nullif(nullif(tool_auto,''),0),
		@budget_life	= nullif(nullif(budget_life,''),0)
		FROM OPENXML(@idoc , '/ROOT/TRACK_EXT', 3) 
			WITH (	model_ids	varchar(1000),
				make_auto	int,
				tool_auto	int,
				budget_life int) 
 
	declare @is_get bit
	declare @size int
	declare @limit_new decimal(18,2)
	declare @limit_worn decimal(18,2)
	declare @max_qty int	

	select  @is_get=is_get, @size = size,@limit_new = limit_new,@limit_worn =limit_worn,@max_qty = max_qty	
	FROM OPENXML(@idoc , '/ROOT/GET_SIZE', 3) WITH ( is_get bit,size int,limit_new decimal(18,2),limit_worn decimal(18,2),max_qty int) 

	SELECT @username = username FROM USER_TABLE WHERE user_auto = @userid
	begin tran updateLuCompart
	
	if @compartid_auto = 0
		begin
			--IF NOT EXISTS (SELECT * FROM LU_COMPART WHERE compartid = @compartid)
			IF  EXISTS (SELECT * FROM LU_COMPART WHERE compartid = @compartid AND progid = @progrid AND allow_duplicate = 0)
				set @affected_compartid_auto = 0
			ELSE
			begin
				--allow_duplicate is always 1 as per document. I confirmed with samuel.PRN 7933
				INSERT INTO LU_COMPART
					(   compartid,	compart,	smcs_code,	modifier_code,	
						progid,	parentid_auto,	sumpcapacity,
						max_rebuilt,
						oilsample_interval,	oilchg_interval,
						insp_item,	insp_interval,	insp_uom,
						comparttype_auto,
						created_date,	created_user,modified_date, modified_user,						
						compart_note, positionid_auto, allow_duplicate )
				SELECT  compartid,
						compart,
						CASE smcs_code	WHEN '' THEN NULL ELSE smcs_code END,
						CASE modifier_code	WHEN '' THEN NULL ELSE modifier_code	END,
						progid,
						CASE parentid_auto	WHEN '' THEN NULL ELSE parentid_auto END,
						CASE sumpcapacity WHEN '' THEN 0 ELSE sumpcapacity	END,
						CASE max_rebuilt WHEN '' THEN 20	ELSE max_rebuilt END,
						CASE oilsample_interval	WHEN '' THEN 0 	ELSE oilsample_interval	END,
						CASE oilchg_interval WHEN '' THEN 0 ELSE oilchg_interval END,
						CASE insp_item	WHEN '' THEN NULL ELSE insp_item END,
						CASE insp_interval	WHEN '' THEN NULL ELSE insp_interval END,
						CASE insp_uom WHEN '' THEN NULL ELSE insp_uom END,
						comparttype_auto,
						GETDATE(),
						CASE @username WHEN '' THEN NULL ELSE @username END,						
						GETDATE(),
						CASE @username WHEN '' THEN NULL ELSE @username END,						
						CASE note WHEN '' THEN NULL ELSE note END,
						positionid_auto,
						allow_duplicate
				FROM OPENXML(@idoc , '/ROOT', 3) 
				WITH (	compartid_auto			int				,
						compartid				varchar (20)	,
						compart					varchar (50)	,
						smcs_code				int				,
						modifier_code			varchar (20)	,
						progid					tinyint			,
						parentid_auto			int				,
						sumpcapacity			int		,
						max_rebuilt				int		,
						oilsample_interval		smallint		,
						oilchg_interval			smallint		,
						insp_item				bit				,
						insp_interval			smallint		,
						insp_uom				smallint		,
						comparttype_auto		int				,
						note					varchar (1000)  ,
						positionid_auto			INT				,
						allow_duplicate			BIT	) XMLCompart 
				WHERE XMLCompart.compartid_auto NOT IN (SELECT compartid_auto FROM LU_COMPART)
			
				if @@error<>0 goto err		
		
				set @affected_compartid_auto = @@identity
				
				--new code for mapping model PRN 7933
				--insert all models applied to undercarriage
				if isnull(@affected_compartid_auto,0) > 0
				begin				
					--first delete if it is not exist in new list
					delete from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto and model_auto not in(select Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,','))
					if @@error<>0 goto err	
					--now insert new if it is not already into table.
					insert into TRACK_COMPART_MODEL_MAPPING(compartid_auto,model_auto)
					select @affected_compartid_auto,Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,',') where Data not in (select model_auto from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto) 
					 if @@error<>0 goto err	
				end
				--insert new extra fields for under carriage PRN 7933
				if isnull(@affected_compartid_auto,0) > 0
				begin
					INSERT INTO [dbo].[TRACK_COMPART_EXT]
						   ([compartid_auto]
						   ,[make_auto]
						   ,[tools_auto]
						   ,[budget_life])
					 VALUES
						   (@affected_compartid_auto
						   ,@make_auto
						   ,@tools_auto
						   ,@budget_life)
				end

			end	
		end
	else	
		begin
			
			--SELECT * FROM LU_COMPART WHERE compartid = @compartid And compartid_auto <> @compartid_auto AND allow_duplicate = 0
			
			IF @@ROWCOUNT > 0
				set @affected_compartid_auto = 0
			ELSE
			begin
					UPDATE LU_COMPART 
					SET LU_COMPART.compartid				= XMLCompart.compartid,
						LU_COMPART.compart					= XMLCompart.compart,	
						LU_COMPART.smcs_code				= XMLCompart.smcs_code,	
						LU_COMPART.modifier_code			= XMLCompart.modifier_code,			
						LU_COMPART.progid					= XMLCompart.progid,		
						LU_COMPART.parentid_auto			= XMLCompart.parentid_auto,				
						LU_COMPART.sumpcapacity				= XMLCompart.sumpcapacity,		
						LU_COMPART.max_rebuilt				= XMLCompart.max_rebuilt,
						LU_COMPART.oilsample_interval		= XMLCompart.oilsample_interval,
						LU_COMPART.oilchg_interval			= XMLCompart.oilchg_interval,
						LU_COMPART.insp_item				= XMLCompart.insp_item,
						LU_COMPART.insp_interval			= XMLCompart.insp_interval,
						LU_COMPART.insp_uom					= XMLCompart.insp_uom,
						LU_COMPART.comparttype_auto			= XMLCompart.comparttype_auto,
						LU_COMPART.modified_date			= GETDATE(),
						LU_COMPART.modified_user			= @username,
						LU_COMPART.compart_note				= XMLCompart.note,
						LU_COMPART.positionid_auto			= XMLCompart.positionid_auto,
						LU_COMPART.allow_duplicate 			= XMLCompart.allow_duplicate
						
					FROM OPENXML(@idoc , '/ROOT', 3) 
					WITH (	compartid_auto			int				,
							compartid				varchar (20)	,
							compart					varchar (50)	,
							smcs_code				int				,
							modifier_code			varchar (20)	,
							progid					tinyint			,
							parentid_auto			int				,
							sumpcapacity			int		,
							max_rebuilt				int		,
							oilsample_interval		smallint		,
							oilchg_interval			smallint		,
							insp_item				bit				,
							insp_interval			smallint		,
							insp_uom				smallint		,
							comparttype_auto		int				,
							note					varchar (1000)  ,
							positionid_auto			INT				,
							allow_duplicate			BIT	) XMLCompart
					WHERE LU_COMPART.compartid_auto = XMLCompart.compartid_auto

					if @@error<>0 goto err
					
					set @affected_compartid_auto = @compartid_auto
					
						--new code for mapping model
						if isnull(@affected_compartid_auto,0) > 0
						begin				
							--first delete if it is not exist in new list
							delete from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto and model_auto not in(select Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,','))
							if @@error<>0 goto err	
							--now insert new if it is not already into table.
							insert into TRACK_COMPART_MODEL_MAPPING(compartid_auto,model_auto)
							select @affected_compartid_auto,Data from dbo.fn_tbl_SplitStringReturnTable(@all_applied_models,',') where Data not in (select model_auto from TRACK_COMPART_MODEL_MAPPING where compartid_auto=@affected_compartid_auto) 
							 if @@error<>0 goto err	
						end

						--insert new extra fields for under carriage PRN 7933
						if isnull(@affected_compartid_auto,0) > 0
						begin	
							if (select count(*) from [TRACK_COMPART_EXT] where [compartid_auto]=@affected_compartid_auto) > 0
							begin
								UPDATE [dbo].[TRACK_COMPART_EXT]
								   SET [make_auto] = @make_auto
									  ,[tools_auto] = @tools_auto
									  ,[budget_life] = @budget_life
								 WHERE [compartid_auto] = @affected_compartid_auto

							end
							else
							begin
									INSERT INTO [dbo].[TRACK_COMPART_EXT]
									   ([compartid_auto]
									   ,[make_auto]
									   ,[tools_auto]
									   ,[budget_life])
								 VALUES
									   (@affected_compartid_auto
									   ,@make_auto
									   ,@tools_auto
									   ,@budget_life)
							end
						end
			end
		end
		
	if ( @is_get = 1 and isnull(@affected_compartid_auto, 0) <> 0 and isnull(@size, 0) > 0)
	exec dbo.GET_COMPART_SIZE_store @size_auto=0, @size = @size , @limit_new = @limit_new , @limit_worn = @limit_worn , @max_qty = @max_qty , @compartid_auto = @affected_compartid_auto

	IF isnull(@affected_compartid_auto, 0) <> 0
		BEGIN
			SELECT * FROM LU_COMPART_USEFUL_LIFE WHERE compartid_auto = @affected_compartid_auto
			IF @@ROWCOUNT > 0
				DELETE FROM LU_COMPART_USEFUL_LIFE WHERE compartid_auto = @affected_compartid_auto
		
			INSERT INTO LU_COMPART_USEFUL_LIFE
			(	compartid_auto, 
				useful_life_type,
				useful_life,
				rebuild_cost,
				remove_install_cost,
				part_cost,	other_cost,
				hrs_to_remove,	hrs_to_install,	hrs_to_rebuild
			)
			SELECT	
				@affected_compartid_auto,
				useful_life_type,
				CASE useful_life WHEN '' THEN 0 	ELSE useful_life	END as useful_life,
				rebuild_cost,
				remove_install_cost,
				part_cost,	other_cost,
				CAST(hrs2remove as decimal(18,2)),	CAST(hrs2install as decimal(18,2)),	CAST(hrs2rebuild as decimal(18,2))				
			FROM OPENXML(@idoc , '/ROOT/USEFUL_LIFE', 3) 
				WITH (	useful_life_type		tinyint	,
						useful_life				int		,
						rebuild_cost			money	,
						remove_install_cost		money,
						part_cost				money	,
						other_cost				money	,
						hrs2remove				money,
						hrs2install				money,
						hrs2rebuild				money) XMLCompart
				
			if @@error<>0 goto err
		
		END
	
	commit tran updateLuCompart
		
	EXEC sp_xml_removedocument @idoc

	
	return --@affected_compartid_auto

err:
rollback tran updateLuCompart
return


");
        }
    }
}
