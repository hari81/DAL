CREATE TABLE [dbo].[AccessLevelTypes] (
    [AccessLevelTypesId] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    CONSTRAINT [PK_dbo.AccessLevelTypes] PRIMARY KEY ([AccessLevelTypesId])
)
CREATE TABLE [dbo].[UserAccessMaps] (
    [UserAccessMapId] [int] NOT NULL IDENTITY,
    [user_auto] [bigint] NOT NULL,
    [DealershipId] [int],
    [customer_auto] [bigint],
    [crsf_auto] [bigint],
    [equipmentid_auto] [bigint],
    [AccessLevelTypeId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.UserAccessMaps] PRIMARY KEY ([UserAccessMapId])
)
CREATE TABLE [dbo].[CRSF] (
    [crsf_auto] [bigint] NOT NULL IDENTITY,
    [customer_auto] [bigint] NOT NULL,
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [site_name] [nvarchar](500),
    [site_street] [nvarchar](300),
    [site_street2] [nvarchar](300),
    [site_suburb] [nvarchar](100),
    [site_postcode] [varchar](20),
    [site_state] [nvarchar](50),
    [site_country] [nvarchar](50),
    [priority] [bit],
    [branch_auto] [int],
    [cs_jobsite_auto] [bigint],
    [site_country_auto] [int],
    [hold_report_until_paid] [bit],
    [hold_invoice_days] [smallint],
    [schedule_sample_kit] [bit],
    [type_auto] [int],
    [DealerId] [int] NOT NULL,
    [CreatedByUserId] [bigint],
    [FullAddress] [nvarchar](max),
    CONSTRAINT [PK_dbo.CRSF] PRIMARY KEY ([crsf_auto])
)
CREATE TABLE [dbo].[CRSF_AREA] (
    [crsf_area_auto] [bigint] NOT NULL IDENTITY,
    [area] [varchar](200) NOT NULL,
    [parentid_auto] [bigint],
    [crsf_auto] [bigint],
    [active] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.CRSF_AREA] PRIMARY KEY ([crsf_area_auto])
)
CREATE TABLE [dbo].[CRSF_TYPE] (
    [crsf_type_auto] [int] NOT NULL IDENTITY,
    [type_name] [varchar](50),
    CONSTRAINT [PK_dbo.CRSF_TYPE] PRIMARY KEY ([crsf_type_auto])
)
CREATE TABLE [dbo].[USER_TABLE] (
    [user_auto] [bigint] NOT NULL IDENTITY,
    [userid] [varchar](50) NOT NULL,
    [username] [varchar](100) NOT NULL,
    [passwd] [varchar](100) NOT NULL,
    [internalemp] [bit] NOT NULL,
    [email] [varchar](100),
    [phone_area_code] [varchar](5),
    [phone_number] [varchar](20),
    [fax_area_code] [varchar](5),
    [fax_number] [varchar](20),
    [mobile] [varchar](20),
    [street1] [varchar](500),
    [street2] [varchar](500),
    [suburb] [varchar](200),
    [postcode] [varchar](20),
    [state] [varchar](50),
    [country] [varchar](50),
    [position_auto] [int],
    [language_auto] [tinyint] NOT NULL,
    [temperature_unit] [varchar](1),
    [currency_auto] [int] NOT NULL,
    [weight_unit] [varchar](1),
    [length_unit] [varchar](1),
    [area_unit] [varchar](1),
    [volume_unit] [varchar](1),
    [pressure_unit] [varchar](10),
    [interpreter] [bit] NOT NULL,
    [viewr] [bit] NOT NULL,
    [viewe] [bit] NOT NULL,
    [active] [bit] NOT NULL,
    [first_login] [bit] NOT NULL,
    [last_login_date] [datetime],
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [rpt_print] [bit],
    [EvalA] [bit],
    [EvalB] [bit],
    [EvalC] [bit],
    [EvalX] [bit],
    [SMS] [bit],
    [protected] [bit] NOT NULL,
    [company] [varchar](100),
    [login_moduleid] [tinyint],
    [colorscheme_auto] [smallint],
    [send_fax] [bit],
    [send_email] [bit],
    [send_hardcopy] [bit],
    [away_start_date] [datetime],
    [away_end_date] [datetime],
    [attach] [bit] NOT NULL,
    [print_copies] [tinyint] NOT NULL,
    [customer_auto] [bigint],
    [url_auto] [tinyint],
    [sos] [bit] NOT NULL,
    [laboratory_auto] [tinyint],
    [must_change_password] [bit],
    [invalid_login_count] [tinyint],
    [invalid_login_start_time] [datetime],
    [last_password_change] [datetime],
    [password_encrypted] [bit],
    [CS_UserAuto] [bigint],
    [can_create_cs_account] [bit],
    [internalother] [bit],
    [country_auto] [int],
    [detail_email] [tinyint],
    [summary_email] [tinyint],
    [summary_group] [tinyint],
    [comment] [nvarchar](1000),
    [suspended] [bit] NOT NULL,
    [branded_admin] [bit],
    [IsEquipmentEdit] [bit] NOT NULL,
    [mob_license] [nvarchar](50),
    [mob_device_id] [nvarchar](max),
    [track_uom] [varchar](50),
    [eq_health] [bit],
    [AS400_PSSR_AUTO] [bigint],
    [AS400_PSSR_EMPNO] [nchar](10),
    [cat_id] [varchar](50),
    [cat_password] [varchar](50),
    [eq_undercarriage] [bit],
    [Position_name_Quote] [nvarchar](max),
    CONSTRAINT [PK_dbo.USER_TABLE] PRIMARY KEY ([user_auto])
)
CREATE TABLE [dbo].[COMP_Inventory_Inspec_Details] (
    [Id] [bigint] NOT NULL IDENTITY,
    [equnit_Id] [bigint] NOT NULL,
    [reading] [decimal](18, 2),
    [worn_percentage] [decimal](18, 2),
    [eval_code] [char](1),
    [tool_Id] [int],
    [InsertDate] [datetime],
    [UserId] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.COMP_Inventory_Inspec_Details] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[GENERAL_EQ_UNIT] (
    [equnit_auto] [bigint] NOT NULL IDENTITY,
    [equipmentid_auto] [bigint],
    [compartid_auto] [int] NOT NULL,
    [compartsn] [varchar](50),
    [date_installed] [datetime],
    [smu_at_install] [bigint],
    [eq_smu_at_install] [bigint],
    [max_rebuild] [smallint] NOT NULL,
    [insp_item] [bit] NOT NULL,
    [insp_interval] [smallint],
    [insp_uom] [smallint],
    [created_user] [varchar](50),
    [created_date] [datetime],
    [modified_user] [varchar](50),
    [modified_date] [datetime],
    [compart_note] [varchar](1000),
    [comp_status] [tinyint] NOT NULL,
    [comp_uniq_id] [uniqueidentifier] NOT NULL,
    [compart_descr] [varchar](50),
    [make_auto] [int],
    [model_auto] [int],
    [rebuild_no] [smallint],
    [rebuild_cost_builder] [bit],
    [rebuild_cost_before_failure] [money],
    [rebuild_cost_after_failure] [money],
    [rebuild_cost_probability_factor] [decimal](18, 2),
    [rebuild_cost_minor_repair_provision] [decimal](18, 2),
    [rebuild_cost_unscheduled_provision] [decimal](18, 2),
    [rebuild_cost_calculated] [money],
    [pos] [tinyint],
    [side] [tinyint],
    [variable_comp] [bit],
    [create_forecast] [bit],
    [track_0_worn] [float],
    [track_100_worn] [float],
    [track_120_worn] [float],
    [eq_ltd_at_install] [bigint],
    [chkOil] [bit],
    [chkInspectionTracking] [bit],
    [chkReplace] [bit],
    [chkRebuild] [bit],
    [chkFinancialTracking] [bit],
    [chkWarranty] [bit],
    [rebuild_cost_calculated1] [money],
    [rebuild_cost_calculated2] [money],
    [replace_cost_calculated] [money],
    [positionid_auto] [bigint],
    [chkActivateForecast] [bit],
    [parent_equnit_auto] [int],
    [component_current_value] [decimal](18, 2),
    [track_budget_life] [int],
    [cmu] [bigint],
    [cost] [decimal](18, 2),
    [module_ucsub_auto] [bigint],
    [system_LTD_at_install] [bigint],
    CONSTRAINT [PK_dbo.GENERAL_EQ_UNIT] PRIMARY KEY ([equnit_auto])
)
CREATE TABLE [dbo].[COMPONENT_LIFE] (
    [Id] [bigint] NOT NULL IDENTITY,
    [ComponentId] [bigint] NOT NULL,
    [ActionId] [bigint] NOT NULL,
    [UserId] [bigint] NOT NULL,
    [ActionDate] [datetime] NOT NULL,
    [ActualLife] [int] NOT NULL,
    [Title] [nvarchar](max),
    CONSTRAINT [PK_dbo.COMPONENT_LIFE] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[ACTION_TAKEN_HISTORY] (
    [history_id] [bigint] NOT NULL IDENTITY,
    [action_type_auto] [int] NOT NULL,
    [event_date] [date] NOT NULL,
    [cmu] [int] NOT NULL,
    [cost] [bigint] NOT NULL,
    [comment] [varchar](1000),
    [equnit_auto] [bigint] NOT NULL,
    [entry_user_auto] [bigint] NOT NULL,
    [compartid_auto] [int] NOT NULL,
    [equipmentid_auto] [bigint] NOT NULL,
    [equipment_smu] [int] NOT NULL,
    [equipment_ltd] [int] NOT NULL,
    [entry_date] [date] NOT NULL,
    [last_modified_date] [date],
    [last_modified_user_auto] [bigint],
    [system_auto_id] [bigint],
    CONSTRAINT [PK_dbo.ACTION_TAKEN_HISTORY] PRIMARY KEY ([history_id])
)
CREATE TABLE [dbo].[EQUIPMENT_LIFE] (
    [Id] [bigint] NOT NULL IDENTITY,
    [EquipmentId] [bigint] NOT NULL,
    [ActionId] [bigint] NOT NULL,
    [UserId] [bigint] NOT NULL,
    [ActionDate] [datetime] NOT NULL,
    [SerialMeterReading] [int] NOT NULL,
    [ActualLife] [int] NOT NULL,
    [Title] [nvarchar](max),
    CONSTRAINT [PK_dbo.EQUIPMENT_LIFE] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[EQUIPMENT] (
    [equipmentid_auto] [bigint] NOT NULL IDENTITY,
    [serialno] [varchar](50) NOT NULL,
    [unitno] [varchar](50) NOT NULL,
    [description] [varchar](50),
    [derived_from] [bigint],
    [mmtaid_auto] [int] NOT NULL,
    [market_auto] [tinyint],
    [measure_unit] [tinyint],
    [op_hrs_per_day] [int],
    [op_dist_uom] [tinyint],
    [op_range] [varchar](50),
    [start_date] [datetime],
    [end_date] [datetime],
    [smu_at_start] [bigint],
    [service_cycle_type_auto] [int],
    [distance_at_start] [bigint],
    [smu_at_end] [bigint],
    [distance_at_end] [bigint],
    [currentsmu] [bigint],
    [currentdistance] [bigint],
    [last_reading_date] [datetime],
    [notes] [varchar](5000),
    [LTD_at_start] [bigint],
    [crsf_auto] [bigint] NOT NULL,
    [location] [varchar](50),
    [purchase_op_hrs] [int],
    [purchase_op_dist] [int],
    [purchase_date] [datetime],
    [purchase_cost] [money],
    [deprate] [int],
    [depmethod] [varchar](10),
    [uccode] [varchar](10),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [equip_status] [int] NOT NULL,
    [regno] [varchar](50),
    [errorcode] [smallint],
    [fleet_auto] [bigint],
    [update_accept] [bit],
    [DBS_serialno] [varchar](10),
    [da_inclusion] [bit],
    [status_auto] [smallint],
    [first_reg_start_date] [datetime],
    [reg_start_date] [datetime],
    [period_auto] [smallint],
    [reg_expiry_date] [datetime],
    [turbo_mod_auto] [int],
    [control_sys_auto] [int],
    [calendar_period] [int],
    [recurring_int_auto] [tinyint],
    [no_contract_fcast_date_at_start] [datetime],
    [no_contract_fcast_s_cycle_auto_at_end] [int],
    [no_contract_fcast_s_cycle_auto_at_start] [int],
    [no_contract_fcast_smu_at_start] [bigint],
    [track_make_auto] [int],
    [track_code_auto] [bigint],
    [cs_equip_auto] [bigint],
    [dtd_at_start] [bigint],
    [no_contract_fcast_smu_at_end] [bigint],
    [no_contract_fcast_LTD_at_start] [bigint],
    [no_contract_fcast_LTD_at_end] [bigint],
    [no_contract_fcast_date_at_end] [datetime],
    [ranking_auto] [tinyint],
    [secondary_uom_isHours] [bit],
    [secondary_uom_isDistance] [bit],
    [secondary_uom_isKWHours] [bit],
    [secondary_uom_isCalendar] [bit],
    [secondary_uom_isFuelBurn] [bit],
    [smu_sec_reading] [decimal](20, 2),
    [smu_ltd_sec_reading] [decimal](20, 2),
    [distance_sec_reading] [decimal](20, 2),
    [distance_ltd_sec_reading] [decimal](20, 2),
    [distance_sec_reading_uom] [tinyint],
    [kw_hrs_sec_reading] [decimal](20, 2),
    [kw_hrs_ltd_sec_reading] [decimal](20, 2),
    [fuel_burn_sec_reading] [decimal](20, 2),
    [fuel_burn_ltd_sec_reading] [decimal](20, 2),
    [calender_sec_reading] [decimal](20, 2),
    [calender_sec_reading_uom] [tinyint],
    [current_smu_sec_reading] [decimal](20, 2),
    [current_distance_sec_reading] [decimal](20, 2),
    [current_kw_hrs_sec_reading] [decimal](20, 2),
    [current_fuel_burn_sec_reading] [decimal](20, 2),
    [current_calender_sec_reading] [decimal](20, 2),
    [health_review_auto] [int],
    [AS400_EQUIPMENT_AUTO] [bigint],
    [Sec_AVGDB_Hours] [decimal](20, 2),
    [Sec_AVGDB_Distance] [decimal](20, 2),
    [Sec_AVGDB_KWHOURS] [decimal](20, 2),
    [Sec_AVGDB_FuelBurn] [decimal](20, 2),
    [Sec_AVGDB_Calender] [decimal](20, 2),
    [no_fcast_Sec_Smu] [bigint],
    [no_fcast_Sec_distance] [bigint],
    [no_fcast_Sec_SMU_ltd] [bigint],
    [no_fcast_Sec_distance_ltd] [bigint],
    [vision_link_exist] [bit] NOT NULL,
    [vision_link_import_date] [datetime],
    CONSTRAINT [PK_dbo.EQUIPMENT] PRIMARY KEY ([equipmentid_auto])
)
CREATE TABLE [dbo].[ACTION_LOG] (
    [action_auto] [bigint] NOT NULL IDENTITY,
    [equipmentid_auto] [bigint] NOT NULL,
    [action_desc] [varchar](500) NOT NULL,
    [action_date] [datetime] NOT NULL,
    [problemsolved] [bit],
    [actioncost] [money],
    [warrantyclaim] [bit],
    [status] [smallint],
    [manuf_comments] [varchar](500),
    [reimburse_amt] [money],
    [workorderno] [varchar](20),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    CONSTRAINT [PK_dbo.ACTION_LOG] PRIMARY KEY ([action_auto])
)
CREATE TABLE [dbo].[GET] (
    [get_auto] [int] NOT NULL IDENTITY,
    [impserial] [varchar](50) NOT NULL,
    [implement_auto] [bigint],
    [equipmentid_auto] [bigint] NOT NULL,
    [isinuse] [bit],
    [make_auto] [int],
    [makeid] [varchar](50),
    [installsmu] [bigint],
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [get_linkage_system_auto] [smallint],
    [bucket_width] [decimal](18, 2),
    [base_edge_thickness] [decimal](18, 2),
    [eb_bottom_thickness] [decimal](18, 2),
    [eb_side_thickness] [decimal](18, 2),
    [cutting_edge_thickness] [decimal](18, 2),
    [mb_bottom_thickness] [decimal](18, 2),
    [mb_rear_thickness] [decimal](18, 2),
    [bucket_width_uom] [varchar](20),
    [base_edge_thickness_uom] [varchar](20),
    [num] [int],
    [segment_length] [decimal](18, 2),
    [plates_width] [int],
    [plates_length] [int],
    [plates_thickness] [int],
    [strips_width] [int],
    [strips_length] [int],
    [strips_thickness] [int],
    [feet_type_auto] [bigint],
    [num_feet] [varchar](50),
    [start_height] [decimal](18, 2),
    [end_height] [decimal](18, 2),
    [image_guid] [uniqueidentifier],
    [impsetup_hours] [bigint],
    CONSTRAINT [PK_dbo.GET] PRIMARY KEY ([get_auto])
)
CREATE TABLE [dbo].[GET_IMPLEMENT_INSPECTION] (
    [inspection_auto] [int] NOT NULL IDENTITY,
    [inspection_date] [datetime] NOT NULL,
    [get_auto] [int] NOT NULL,
    [meter_reading] [int] NOT NULL,
    [overall_notes] [varchar](256) NOT NULL,
    [dirty_environment] [int] NOT NULL,
    [work_area] [int] NOT NULL,
    [machine] [int] NOT NULL,
    [area] [int] NOT NULL,
    [condition] [int] NOT NULL,
    [flag] [bit] NOT NULL,
    [eval] [int] NOT NULL,
    [ltd] [int] NOT NULL,
    [user_auto] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.GET_IMPLEMENT_INSPECTION] PRIMARY KEY ([inspection_auto])
)
CREATE TABLE [dbo].[GET_COMPONENT_INSPECTION] (
    [inspection_auto] [int] NOT NULL IDENTITY,
    [get_component_auto] [int] NOT NULL,
    [measurement] [numeric](16, 5) NOT NULL,
    [flag] [bit] NOT NULL,
    [replace] [bit] NOT NULL,
    [comment] [varchar](256),
    [inspection_date] [datetime] NOT NULL,
    [implement_inspection_auto] [int] NOT NULL,
    [flag_ignored] [bit] NOT NULL,
    [ltd] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GET_COMPONENT_INSPECTION] PRIMARY KEY ([inspection_auto])
)
CREATE TABLE [dbo].[GET_OBSERVATION_RESULTS] (
    [results_auto] [int] NOT NULL IDENTITY,
    [inspection_auto] [int] NOT NULL,
    [observations_auto] [int] NOT NULL,
    [checked] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.GET_OBSERVATION_RESULTS] PRIMARY KEY ([results_auto])
)
CREATE TABLE [dbo].[GET_OBSERVATION_IMAGE] (
    [image_auto] [int] NOT NULL IDENTITY,
    [results_auto] [int] NOT NULL,
    [observation_photo] [varbinary](max),
    CONSTRAINT [PK_dbo.GET_OBSERVATION_IMAGE] PRIMARY KEY ([image_auto])
)
CREATE TABLE [dbo].[GET_OBSERVATIONS] (
    [observations_auto] [int] NOT NULL IDENTITY,
    [observation] [varchar](128) NOT NULL,
    [observation_list_auto] [int] NOT NULL,
    [active] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.GET_OBSERVATIONS] PRIMARY KEY ([observations_auto])
)
CREATE TABLE [dbo].[GET_IMPLEMENT_INSPECTION_IMAGE] (
    [image_auto] [int] NOT NULL IDENTITY,
    [inspection_auto] [int] NOT NULL,
    [parameter_type] [int] NOT NULL,
    [inspection_photo] [varbinary](max),
    CONSTRAINT [PK_dbo.GET_IMPLEMENT_INSPECTION_IMAGE] PRIMARY KEY ([image_auto])
)
CREATE TABLE [dbo].[GET_INSPECTION_PARAMETERS] (
    [parameter_type] [int] NOT NULL IDENTITY,
    [parameter_desc] [varchar](64) NOT NULL,
    CONSTRAINT [PK_dbo.GET_INSPECTION_PARAMETERS] PRIMARY KEY ([parameter_type])
)
CREATE TABLE [dbo].[GET_INSPECTION_CONSTANTS] (
    [constants_auto] [int] NOT NULL IDENTITY,
    [parameter_type] [int] NOT NULL,
    [inspect_desc] [varchar](64) NOT NULL,
    [display_order] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GET_INSPECTION_CONSTANTS] PRIMARY KEY ([constants_auto])
)
CREATE TABLE [dbo].[IMPLEMENT_READING_ENTRY] (
    [implement_reading_entry_auto] [int] NOT NULL IDENTITY,
    [inspection_date] [datetime] NOT NULL,
    [implement_id] [int] NOT NULL,
    [ltd] [int] NOT NULL,
    CONSTRAINT [PK_dbo.IMPLEMENT_READING_ENTRY] PRIMARY KEY ([implement_reading_entry_auto])
)
CREATE TABLE [dbo].[LU_MMTA] (
    [mmtaid_auto] [int] NOT NULL IDENTITY,
    [make_auto] [int] NOT NULL,
    [model_auto] [int] NOT NULL,
    [type_auto] [int] NOT NULL,
    [arrangement_auto] [int],
    [app_auto] [smallint],
    [service_cycle_type_auto] [int],
    [expiry_date] [datetime] NOT NULL,
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [cs_mmtaid_auto] [int],
    CONSTRAINT [PK_dbo.LU_MMTA] PRIMARY KEY ([mmtaid_auto])
)
CREATE TABLE [dbo].[APPLICATION] (
    [app_auto] [smallint] NOT NULL IDENTITY,
    [appid] [varchar](50) NOT NULL,
    [appdesc] [varchar](255) NOT NULL,
    [cs_app_auto] [int],
    CONSTRAINT [PK_dbo.APPLICATION] PRIMARY KEY ([app_auto])
)
CREATE TABLE [dbo].[MAKE] (
    [make_auto] [int] NOT NULL IDENTITY,
    [makeid] [varchar](50) NOT NULL,
    [makedesc] [varchar](50) NOT NULL,
    [dbs_id] [varchar](50),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [cs_make_auto] [int],
    [cat] [bit] NOT NULL,
    [Oil] [bit],
    [Components] [bit],
    [Undercarriage] [bit],
    [Tyre] [bit],
    [Rim] [bit],
    [Hydraulic] [bit],
    [Body] [bit],
    CONSTRAINT [PK_dbo.MAKE] PRIMARY KEY ([make_auto])
)
CREATE TABLE [dbo].[TRACK_COMPART_EXT] (
    [track_compart_ext_auto] [bigint] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [make_auto] [int],
    [tools_auto] [int],
    [budget_life] [int],
    [track_compart_worn_calc_method_auto] [int],
    CONSTRAINT [PK_dbo.TRACK_COMPART_EXT] PRIMARY KEY ([track_compart_ext_auto])
)
CREATE TABLE [dbo].[LU_COMPART] (
    [compartid_auto] [int] NOT NULL IDENTITY,
    [compartid] [varchar](20) NOT NULL,
    [compart] [varchar](50) NOT NULL,
    [smcs_code] [int],
    [modifier_code] [varchar](20),
    [hrs] [int],
    [progid] [tinyint] NOT NULL,
    [Left] [bit],
    [parentid_auto] [int],
    [parentid] [varchar](10),
    [childoptid] [smallint],
    [multiple] [bit],
    [fixedamount] [int],
    [implement_auto] [bigint],
    [core] [bit],
    [group_id] [nvarchar](10),
    [expected_life] [numeric](18, 0),
    [expected_cost] [numeric](18, 0),
    [comparttype_auto] [int] NOT NULL,
    [companyname] [varchar](50),
    [sumpcapacity] [smallint] NOT NULL,
    [max_rebuilt] [smallint] NOT NULL,
    [oilsample_interval] [smallint] NOT NULL,
    [oilchg_interval] [smallint] NOT NULL,
    [insp_item] [bit],
    [insp_interval] [smallint],
    [insp_uom] [smallint],
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [bowldisplayorder] [smallint],
    [track_comp_row] [smallint],
    [track_comp_cts_maintype] [varchar](5),
    [track_comp_cts_subtype] [varchar](5),
    [compart_note] [varchar](1000),
    [sorder] [int],
    [hydraulic_inspect_symptoms] [varchar](100),
    [cs_compart_auto] [int],
    [positionid_auto] [int],
    [allow_duplicate] [bit],
    [standard_compartid_auto] [bigint],
    [ranking_auto] [int],
    CONSTRAINT [PK_dbo.LU_COMPART] PRIMARY KEY ([compartid_auto])
)
CREATE TABLE [dbo].[COMPART_PARENT_RELATION] (
    [Id] [int] NOT NULL IDENTITY,
    [ParentCompartId] [int],
    [ChildCompartId] [int] NOT NULL,
    CONSTRAINT [PK_dbo.COMPART_PARENT_RELATION] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[COMPART_TOOL_IMAGE] (
    [Id] [int] NOT NULL IDENTITY,
    [CompartId] [int] NOT NULL,
    [ToolId] [int] NOT NULL,
    [Title] [nvarchar](max),
    [ImageData] [varbinary](max),
    [CreatedDate] [datetime] NOT NULL,
    [ImageType] [nvarchar](max),
    CONSTRAINT [PK_dbo.COMPART_TOOL_IMAGE] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[TRACK_TOOL] (
    [tool_auto] [int] NOT NULL,
    [tool_name] [varchar](50) NOT NULL,
    [tool_code] [nvarchar](10),
    CONSTRAINT [PK_dbo.TRACK_TOOL] PRIMARY KEY ([tool_auto])
)
CREATE TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_CAT] (
    [track_compart_worn_limit_cat_auto] [int] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [track_tools_auto] [int] NOT NULL,
    [hi_inflectionPoint] [decimal](18, 3),
    [hi_slope1] [decimal](18, 3),
    [hi_intercept1] [decimal](18, 3),
    [hi_slope2] [decimal](18, 3),
    [hi_intercept2] [decimal](18, 3),
    [mi_inflectionPoint] [decimal](18, 3),
    [mi_slope1] [decimal](18, 3),
    [mi_intercept1] [decimal](18, 3),
    [mi_slope2] [decimal](18, 3),
    [mi_intercept2] [decimal](18, 3),
    [adjust_base] [decimal](18, 3),
    [slope] [int],
    CONSTRAINT [PK_dbo.TRACK_COMPART_WORN_LIMIT_CAT] PRIMARY KEY ([track_compart_worn_limit_cat_auto])
)
CREATE TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_ITM] (
    [track_compart_worn_limit_itm_auto] [int] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [track_tools_auto] [int] NOT NULL,
    [start_depth_new] [decimal](18, 3),
    [wear_depth_10_percent] [decimal](18, 3),
    [wear_depth_20_percent] [decimal](18, 3),
    [wear_depth_30_percent] [decimal](18, 3),
    [wear_depth_40_percent] [decimal](18, 3),
    [wear_depth_50_percent] [decimal](18, 3),
    [wear_depth_60_percent] [decimal](18, 3),
    [wear_depth_70_percent] [decimal](18, 3),
    [wear_depth_80_percent] [decimal](18, 3),
    [wear_depth_90_percent] [decimal](18, 3),
    [wear_depth_100_percent] [decimal](18, 3),
    [wear_depth_110_percent] [decimal](18, 3),
    [wear_depth_120_percent] [decimal](18, 3),
    CONSTRAINT [PK_dbo.TRACK_COMPART_WORN_LIMIT_ITM] PRIMARY KEY ([track_compart_worn_limit_itm_auto])
)
CREATE TABLE [dbo].[TRACK_INSPECTION_DETAIL] (
    [inspection_detail_auto] [int] NOT NULL IDENTITY,
    [inspection_auto] [int] NOT NULL,
    [track_unit_auto] [bigint] NOT NULL,
    [tool_auto] [int],
    [reading] [decimal](18, 2) NOT NULL,
    [worn_percentage] [decimal](18, 2) NOT NULL,
    [eval_code] [char](1),
    [hours_on_surface] [int],
    [projected_hours] [int],
    [ext_projected_hours] [int],
    [remaining_hours] [int],
    [ext_remaining_hours] [int],
    [comments] [nvarchar](400),
    [worn_percentage_120] [decimal](18, 2),
    [track_unit_history_auto] [bigint],
    [UCSystemId] [bigint],
    CONSTRAINT [PK_dbo.TRACK_INSPECTION_DETAIL] PRIMARY KEY ([inspection_detail_auto])
)
CREATE TABLE [dbo].[TRACK_INSPECTION_IMAGES] (
    [ID] [bigint] NOT NULL IDENTITY,
    [GUID] [uniqueidentifier],
    [inspection_detail_auto] [nchar](10),
    [image_data] [varbinary](max),
    [image_comment] [nvarchar](max),
    [InspectionDetailId] [int],
    CONSTRAINT [PK_dbo.TRACK_INSPECTION_IMAGES] PRIMARY KEY ([ID])
)
CREATE TABLE [dbo].[LU_Module_Sub] (
    [Module_sub_auto] [bigint] NOT NULL IDENTITY,
    [Serialno] [nvarchar](50) NOT NULL,
    [Module_progid] [int],
    [SMU] [bigint],
    [CMU] [bigint],
    [SMU_at_install] [bigint],
    [LTD_at_install] [bigint],
    [CreatedBy] [int],
    [CreatedDate] [datetime],
    [Status] [int],
    [StatusDate] [datetime],
    [LTD] [bigint],
    [equipmentid_auto] [bigint],
    [crsf_auto] [bigint],
    [make_auto] [bigint],
    [model_auto] [bigint],
    [type_auto] [bigint],
    [modifiedDate] [datetime],
    [modifiedBy] [int],
    [reason] [nvarchar](100),
    [notes] [nvarchar](200),
    [system_LTD_on_removal] [bigint],
    [equipment_LTD_at_attachment] [bigint],
    [installation_status] [int],
    [systemTypeEnumIndex] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LU_Module_Sub] PRIMARY KEY ([Module_sub_auto])
)
CREATE TABLE [dbo].[UCSYSTEM_LIFE] (
    [Id] [bigint] NOT NULL IDENTITY,
    [SystemId] [bigint] NOT NULL,
    [ActionId] [bigint] NOT NULL,
    [UserId] [bigint] NOT NULL,
    [ActionDate] [datetime] NOT NULL,
    [ActualLife] [int] NOT NULL,
    [Title] [nvarchar](max),
    CONSTRAINT [PK_dbo.UCSYSTEM_LIFE] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[InspectionDetails_Side] (
    [InspectionDetailsId] [int] NOT NULL,
    [Side] [int] NOT NULL,
    [TRACK_INSPECTION_DETAIL1_inspection_detail_auto] [int],
    CONSTRAINT [PK_dbo.InspectionDetails_Side] PRIMARY KEY ([InspectionDetailsId])
)
CREATE TABLE [dbo].[TRACK_INSPECTION] (
    [inspection_auto] [int] NOT NULL IDENTITY,
    [equipmentid_auto] [bigint] NOT NULL,
    [examiner] [varchar](50) NOT NULL,
    [inspection_date] [datetime] NOT NULL,
    [smu] [int],
    [evalcode] [char](1),
    [notes] [varchar](1000),
    [track_sag_left] [decimal](18, 0),
    [track_sag_right] [decimal](18, 0),
    [track_sag_left_status] [varchar](50),
    [track_sag_right_status] [varchar](50),
    [dry_joints_left] [decimal](18, 0),
    [dry_joints_right] [decimal](18, 0),
    [frame_ext_left] [decimal](18, 0),
    [frame_ext_right] [decimal](18, 0),
    [sprocket_left_status] [varchar](50),
    [sprocket_right_status] [varchar](50),
    [impact] [smallint],
    [abrasive] [smallint],
    [moisture] [smallint],
    [packing] [smallint],
    [allowableWear] [smallint],
    [uccode] [varchar](50),
    [uccodedesc] [varchar](255),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [confirmed_date] [datetime],
    [confirmed_user] [varchar](50),
    [last_interp_date] [datetime],
    [last_interp_user] [varchar](50),
    [eval_comment] [nvarchar](2000),
    [location] [varchar](100),
    [docket_no] [varchar](50),
    [ucbrand] [varchar](50),
    [wear] [tinyint],
    [ltd] [int],
    [Jobsite_Comms] [nvarchar](2000),
    [released_date] [datetime],
    [released_by] [varchar](100),
    [inspection_comments] [nvarchar](max),
    [quote_auto] [int],
    [ext_cannon_left] [decimal](18, 0),
    [ext_cannon_right] [decimal](18, 0),
    [ActionHistoryId] [bigint],
    CONSTRAINT [PK_dbo.TRACK_INSPECTION] PRIMARY KEY ([inspection_auto])
)
CREATE TABLE [dbo].[TRACK_ACTION] (
    [action_auto] [int] NOT NULL IDENTITY,
    [inspection_auto] [int] NOT NULL,
    [action_recommandation] [varchar](1000),
    [recommanded_by] [varchar](50),
    [recommanded_on] [datetime],
    [problem_solved] [bit],
    [created_user] [varchar](50),
    [created_date] [datetime],
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    CONSTRAINT [PK_dbo.TRACK_ACTION] PRIMARY KEY ([action_auto])
)
CREATE TABLE [dbo].[TRACK_ACTION_TAKEN] (
    [action_taken_auto] [int] NOT NULL IDENTITY,
    [action_auto] [int] NOT NULL,
    [action_taken_on] [datetime] NOT NULL,
    [action_taken_by] [varchar](50) NOT NULL,
    [action_taken_desc] [varchar](1000),
    [action_cost] [money],
    [created_date] [datetime],
    [created_user] [varchar](50),
    CONSTRAINT [PK_dbo.TRACK_ACTION_TAKEN] PRIMARY KEY ([action_taken_auto])
)
CREATE TABLE [dbo].[LU_COMPART_PARTS] (
    [compartment_part_auto] [int] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [name] [varchar](max),
    [active] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.LU_COMPART_PARTS] PRIMARY KEY ([compartment_part_auto])
)
CREATE TABLE [dbo].[LU_COMPART_TYPE] (
    [comparttype_auto] [int] NOT NULL IDENTITY,
    [comparttypeid] [varchar](10) NOT NULL,
    [comparttype] [varchar](100) NOT NULL,
    [sorder] [int],
    [protected] [bit] NOT NULL,
    [modified_user_auto] [bigint],
    [modified_date] [datetime],
    [implement_auto] [bigint],
    [multiple] [bit],
    [max_no] [int],
    [progid] [tinyint],
    [fixedamount] [int],
    [min_no] [int],
    [getmesurement] [bit],
    [system_auto] [smallint],
    [cs_comparttype_auto] [int],
    [standard_compart_type_auto] [bigint],
    [comparttype_shortkey] [varchar](10),
    CONSTRAINT [PK_dbo.LU_COMPART_TYPE] PRIMARY KEY ([comparttype_auto])
)
CREATE TABLE [dbo].[LU_GET_COMPART_SUB_TYPE] (
    [get_compart_sub_auto] [smallint] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [teeth_size] [varchar](50),
    [nl] [decimal](18, 2),
    [wl] [decimal](18, 2),
    [series] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [compart] [varchar](50),
    CONSTRAINT [PK_dbo.LU_GET_COMPART_SUB_TYPE] PRIMARY KEY ([get_compart_sub_auto])
)
CREATE TABLE [dbo].[TRACK_COMPART_WORN_CALC_METHOD] (
    [track_compart_worn_calc_method_auto] [int] NOT NULL,
    [track_compart_worn_calc_method_name] [varchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.TRACK_COMPART_WORN_CALC_METHOD] PRIMARY KEY ([track_compart_worn_calc_method_auto])
)
CREATE TABLE [dbo].[MODEL] (
    [model_auto] [int] NOT NULL IDENTITY,
    [modelid] [nvarchar](50) NOT NULL,
    [modeldesc] [nvarchar](50) NOT NULL,
    [tt_prog_auto] [tinyint],
    [gb_prog_auto] [tinyint],
    [axle_no] [tinyint],
    [created_date] [datetime] NOT NULL,
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [track_sag_maximum] [int],
    [track_sag_minimum] [int],
    [isPSC] [bit],
    [model_size_auto] [smallint],
    [cs_model_auto] [int],
    [cat] [bit],
    [model_pricing_level_auto] [smallint],
    [equip_reg_industry_auto] [smallint],
    [ModelNote] [nvarchar](max),
    [UCSystemCost] [decimal](18, 2),
    CONSTRAINT [PK_dbo.MODEL] PRIMARY KEY ([model_auto])
)
CREATE TABLE [dbo].[TYPE] (
    [type_auto] [int] NOT NULL IDENTITY,
    [typeid] [varchar](50) NOT NULL,
    [typedesc] [varchar](50) NOT NULL,
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [cs_type_auto] [int],
    [blob_auto] [int],
    [blob_large_auto] [int],
    [default_smu] [bigint],
    CONSTRAINT [PK_dbo.TYPE] PRIMARY KEY ([type_auto])
)
CREATE TABLE [dbo].[USER_CRSF_CUST_EQUIP] (
    [user_assign_auto] [bigint] NOT NULL IDENTITY,
    [user_auto] [bigint] NOT NULL,
    [customer_auto] [bigint] NOT NULL,
    [crsf_auto] [bigint],
    [equipmentid_auto] [bigint],
    [level_type] [tinyint],
    [keep_with_equip] [bit],
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [modified_user_auto] [bigint],
    CONSTRAINT [PK_dbo.USER_CRSF_CUST_EQUIP] PRIMARY KEY ([user_assign_auto])
)
CREATE TABLE [dbo].[CUSTOMER] (
    [customer_auto] [bigint] NOT NULL IDENTITY,
    [custid] [varchar](200) NOT NULL,
    [cust_name] [nvarchar](400) NOT NULL,
    [cust_street] [nvarchar](100),
    [cust_suburb] [nvarchar](50),
    [cust_postcode] [varchar](20),
    [cust_state] [nvarchar](50),
    [cust_country] [nvarchar](50),
    [cust_phone] [nvarchar](50),
    [cust_mobile] [varchar](15),
    [cust_fax] [nvarchar](50),
    [cust_email] [varchar](100),
    [note] [nvarchar](1000),
    [customer_auto_main] [bigint],
    [companyname] [varchar](500),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [cust_formid] [varchar](20),
    [db_custid] [varchar](20),
    [cust_street2] [nvarchar](100),
    [active] [bit] NOT NULL,
    [cust_billing_street] [nvarchar](100),
    [cust_billing_street2] [nvarchar](100),
    [cust_billing_suburb] [nvarchar](50),
    [cust_billing_postcode] [varchar](20),
    [cust_billing_state] [nvarchar](50),
    [cust_billing_country] [nvarchar](50),
    [billing_address] [bit] NOT NULL,
    [primary_language] [tinyint],
    [second_language] [tinyint],
    [is_account_payment] [bit],
    [cs_customer_auto] [bigint],
    [labonly] [bit],
    [cust_country_auto] [int],
    [cust_billing_country_auto] [int],
    [payment_terms] [int],
    [logo_name] [varchar](200),
    [district_auto] [tinyint],
    [cs_ws_url_auto] [bigint],
    [business_system] [nvarchar](150),
    [ic_workorder] [bit],
    [ic_component_forecast] [bit],
    [business_system_key] [nvarchar](max),
    [quote_discount] [decimal](5, 2),
    [ProfileID] [bigint],
    [Showlimits] [bit] NOT NULL,
    [send_fax] [bit],
    [send_email] [bit],
    [send_hardcopy] [bit],
    [Payment_Type] [nvarchar](50),
    [Contact_Type] [nvarchar](50),
    [terms_Exceeded] [decimal](5, 2),
    [AS400_CUSTOMER_AUTO] [bigint],
    [invoice_note] [nvarchar](max),
    [logo] [image],
    [DealershipId] [int] NOT NULL,
    [CreatedByUserId] [bigint],
    [subPremise] [int],
    [fullAddress] [nvarchar](max),
    CONSTRAINT [PK_dbo.CUSTOMER] PRIMARY KEY ([customer_auto])
)
CREATE TABLE [dbo].[Dealerships] (
    [DealershipId] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    [Owner] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.Dealerships] PRIMARY KEY ([DealershipId])
)
CREATE TABLE [dbo].[TRACK_ACTION_TYPE] (
    [action_type_auto] [int] NOT NULL,
    [action_description] [varchar](100),
    [compartment_type] [varchar](200),
    CONSTRAINT [PK_dbo.TRACK_ACTION_TYPE] PRIMARY KEY ([action_type_auto])
)
CREATE TABLE [dbo].[EQUIPMENT_AUDIT_HISTOY] (
    [equipAudit_auto] [bigint] NOT NULL IDENTITY,
    [equipmentid_auto] [bigint] NOT NULL,
    [date] [datetime] NOT NULL,
    [user_auto] [bigint] NOT NULL,
    [field] [varchar](50) NOT NULL,
    [beforeChange] [varchar](100) NOT NULL,
    [afterChange] [varchar](100) NOT NULL,
    CONSTRAINT [PK_dbo.EQUIPMENT_AUDIT_HISTOY] PRIMARY KEY ([equipAudit_auto])
)
CREATE TABLE [dbo].[USER_DEALERSHIP] (
    [Id] [int] NOT NULL IDENTITY,
    [user_auto] [bigint] NOT NULL,
    [dealership_auto] [int] NOT NULL,
    CONSTRAINT [PK_dbo.USER_DEALERSHIP] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[APPLICATION_ERROR_LOG] (
    [id] [bigint] NOT NULL IDENTITY,
    [date] [datetime],
    [pagename] [varchar](2000),
    [error] [varchar](5000),
    [stacktrace] [varchar](8000),
    CONSTRAINT [PK_dbo.APPLICATION_ERROR_LOG] PRIMARY KEY ([id])
)
CREATE TABLE [dbo].[APPLICATION_LU_CONFIG] (
    [variable_key] [varchar](50) NOT NULL,
    [value_key] [varchar](1000) NOT NULL,
    [description] [varchar](1000),
    CONSTRAINT [PK_dbo.APPLICATION_LU_CONFIG] PRIMARY KEY ([variable_key])
)
CREATE TABLE [dbo].[COMPART_ATTACH_FILESTREAM] (
    [compart_attach_auto] [bigint] NOT NULL IDENTITY,
    [guid] [uniqueidentifier] NOT NULL,
    [compartid_auto] [bigint],
    [comparttype_auto] [bigint],
    [tool_auto] [int],
    [compart_attach_type_auto] [int],
    [user_auto] [bigint],
    [entry_date] [datetime],
    [comment] [nvarchar](2000),
    [attachment_name] [varchar](100),
    [attachment] [varbinary](max),
    [inspection_auto] [int],
    [position] [int],
    CONSTRAINT [PK_dbo.COMPART_ATTACH_FILESTREAM] PRIMARY KEY ([compart_attach_auto])
)
CREATE TABLE [dbo].[COMPART_ATTACH_TYPE] (
    [compart_attach_type_auto] [int] NOT NULL,
    [compart_attach_type_name] [varchar](max) NOT NULL,
    CONSTRAINT [PK_dbo.COMPART_ATTACH_TYPE] PRIMARY KEY ([compart_attach_type_auto])
)
CREATE TABLE [dbo].[EQ_UNIT_HISTORY] (
    [equnit_history_auto] [bigint] NOT NULL IDENTITY,
    [module_equnit_auto] [bigint] NOT NULL,
    [moduleid] [smallint] NOT NULL,
    [compartid_auto] [int],
    [equipmentid_auto] [bigint],
    [component_management_type_auto] [smallint],
    [management_date] [datetime],
    [management_eq_smu] [bigint],
    [rebuild_no] [smallint],
    [install_date] [datetime],
    [eq_smu_at_install] [bigint],
    [c_actual_auto] [bigint],
    [comment] [varchar](500),
    [cause_auto] [int],
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [management_comp_smu] [bigint],
    [management_eq_LTD] [bigint],
    [component_status_id] [int],
    [documents_and_images] [int],
    CONSTRAINT [PK_dbo.EQ_UNIT_HISTORY] PRIMARY KEY ([equnit_history_auto])
)
CREATE TABLE [dbo].[EQUIPMENT_ACTIONS] (
    [equipment_action_auto] [bigint] NOT NULL IDENTITY,
    [equipment_recommendation_list_auto] [bigint] NOT NULL,
    [action_auto] [bigint] NOT NULL,
    [action_details] [nvarchar](max),
    [action_date] [datetime],
    [action_cost] [money],
    [work_order] [nvarchar](50),
    [warranty_claim_no] [nvarchar](100),
    [created_user] [nvarchar](50),
    [created_date] [datetime] NOT NULL,
    [modified_date] [datetime],
    [modified_user] [nvarchar](50),
    [Downtime] [nvarchar](50),
    CONSTRAINT [PK_dbo.EQUIPMENT_ACTIONS] PRIMARY KEY ([equipment_action_auto])
)
CREATE TABLE [dbo].[GENERAL_EQ_UNIT_HISTORY] (
    [equnit_auto] [bigint] NOT NULL IDENTITY,
    [equipmentid_auto] [bigint],
    [compartid_auto] [int] NOT NULL,
    [compartsn] [varchar](50),
    [date_installed] [datetime],
    [smu_at_install] [bigint],
    [max_rebuild] [smallint] NOT NULL,
    [insp_item] [bit] NOT NULL,
    [insp_interval] [smallint],
    [insp_uom] [smallint],
    [created_user] [varchar](50),
    [created_date] [datetime],
    [modified_user] [varchar](50),
    [modified_date] [datetime],
    [compart_note] [varchar](1000),
    [comp_status] [tinyint] NOT NULL,
    [comp_uniq_id] [uniqueidentifier] NOT NULL,
    [eq_smu_at_install] [bigint],
    [compart_descr] [varchar](50),
    [make_auto] [int],
    [model_auto] [int],
    [rebuild_no] [smallint],
    [rebuild_cost_builder] [bit],
    [rebuild_cost_before_failure] [money],
    [rebuild_cost_after_failure] [money],
    [rebuild_cost_probability_factor] [decimal](18, 2),
    [rebuild_cost_minor_repair_provision] [decimal](18, 2),
    [rebuild_cost_unscheduled_provision] [decimal](18, 2),
    [rebuild_cost_calculated] [money],
    [pos] [tinyint],
    [side] [tinyint],
    [variable_comp] [bit],
    [create_forecast] [bit],
    [track_0_worn] [float],
    [track_100_worn] [float],
    [track_120_worn] [float],
    [eq_ltd_at_install] [bigint],
    [chkOil] [bit],
    [chkInspectionTracking] [bit],
    [chkReplace] [bit],
    [chkRebuild] [bit],
    [chkFinancialTracking] [bit],
    [chkWarranty] [bit],
    [rebuild_cost_calculated1] [money],
    [rebuild_cost_calculated2] [money],
    [replace_cost_calculated] [money],
    [positionid_auto] [bigint],
    [chkActivateForecast] [bit],
    [parent_equnit_auto] [int],
    [component_current_value] [decimal](18, 2),
    [track_budget_life] [int],
    [cmu] [bigint],
    [action_type_auto] [int],
    [oequnit_auto] [bigint],
    [inspection_auto] [bigint],
    [cost] [decimal](18, 2),
    [module_ucsub_auto] [bigint],
    CONSTRAINT [PK_dbo.GENERAL_EQ_UNIT_HISTORY] PRIMARY KEY ([equnit_auto])
)
CREATE TABLE [dbo].[GET_ACTIONS] (
    [actions_auto] [int] NOT NULL IDENTITY,
    [action_name] [nvarchar](64) NOT NULL,
    CONSTRAINT [PK_dbo.GET_ACTIONS] PRIMARY KEY ([actions_auto])
)
CREATE TABLE [dbo].[GET_COMPONENT] (
    [get_component_auto] [int] NOT NULL IDENTITY,
    [make_auto] [int],
    [get_auto] [int] NOT NULL,
    [observation_list_auto] [int],
    [cmu] [int] NOT NULL,
    [install_date] [datetime],
    [ltd_at_setup] [int] NOT NULL,
    [req_measure] [bit],
    [initial_length] [int],
    [worn_length] [int],
    [price] [money],
    [part_no] [varchar](50),
    [schematic_component_auto] [int],
    [active] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.GET_COMPONENT] PRIMARY KEY ([get_component_auto])
)
CREATE TABLE [dbo].[GET_CONFIG] (
    [variable_key] [varchar](32) NOT NULL,
    [value_key] [varchar](32),
    [description] [varchar](256),
    CONSTRAINT [PK_dbo.GET_CONFIG] PRIMARY KEY ([variable_key])
)
CREATE TABLE [dbo].[GET_EVENTS] (
    [events_auto] [bigint] NOT NULL IDENTITY,
    [user_auto] [bigint] NOT NULL,
    [action_auto] [int] NOT NULL,
    [event_date] [datetime] NOT NULL,
    [comment] [nvarchar](64),
    [cost] [numeric](18, 2) NOT NULL,
    [recorded_date] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.GET_EVENTS] PRIMARY KEY ([events_auto])
)
CREATE TABLE [dbo].[GET_EVENTS_COMPONENT] (
    [component_events_auto] [bigint] NOT NULL IDENTITY,
    [get_component_auto] [bigint] NOT NULL,
    [ltd] [int] NOT NULL,
    [events_auto] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.GET_EVENTS_COMPONENT] PRIMARY KEY ([component_events_auto])
)
CREATE TABLE [dbo].[GET_EVENTS_EQUIPMENT] (
    [equipment_events_auto] [bigint] NOT NULL IDENTITY,
    [equipment_auto] [bigint] NOT NULL,
    [smu] [int] NOT NULL,
    [ltd] [int] NOT NULL,
    [events_auto] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.GET_EVENTS_EQUIPMENT] PRIMARY KEY ([equipment_events_auto])
)
CREATE TABLE [dbo].[GET_EVENTS_IMPLEMENT] (
    [implement_events_auto] [bigint] NOT NULL IDENTITY,
    [get_auto] [bigint] NOT NULL,
    [ltd] [int] NOT NULL,
    [events_auto] [bigint] NOT NULL,
    CONSTRAINT [PK_dbo.GET_EVENTS_IMPLEMENT] PRIMARY KEY ([implement_events_auto])
)
CREATE TABLE [dbo].[GET_INSPECTIONS_VIEWED] (
    [inspections_viewed_auto] [bigint] NOT NULL IDENTITY,
    [inspection_auto] [bigint] NOT NULL,
    [user_auto] [bigint] NOT NULL,
    [viewed_date] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.GET_INSPECTIONS_VIEWED] PRIMARY KEY ([inspections_viewed_auto])
)
CREATE TABLE [dbo].[GET_INTERPRETATION_COMMENTS] (
    [comment_auto] [bigint] NOT NULL IDENTITY,
    [user_auto] [bigint] NOT NULL,
    [comment] [nvarchar](128) NOT NULL,
    [comment_date] [datetime] NOT NULL,
    [inspection_auto] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GET_INTERPRETATION_COMMENTS] PRIMARY KEY ([comment_auto])
)
CREATE TABLE [dbo].[GET_OBSERVATION_LIST] (
    [observation_list_auto] [int] NOT NULL IDENTITY,
    [name] [varchar](128) NOT NULL,
    [create_user] [int] NOT NULL,
    [create_date] [datetime] NOT NULL,
    [active] [bit] NOT NULL,
    CONSTRAINT [PK_dbo.GET_OBSERVATION_LIST] PRIMARY KEY ([observation_list_auto])
)
CREATE TABLE [dbo].[GET_SCHEMATIC_COMPONENT] (
    [schematic_component_auto] [int] NOT NULL IDENTITY,
    [schematic_auto] [int] NOT NULL,
    [comparttype_auto] [int] NOT NULL,
    [active] [bit] NOT NULL,
    [positionX] [int] NOT NULL,
    [positionY] [int] NOT NULL,
    CONSTRAINT [PK_dbo.GET_SCHEMATIC_COMPONENT] PRIMARY KEY ([schematic_component_auto])
)
CREATE TABLE [dbo].[GET_SCHEMATIC_IMAGE] (
    [schematic_auto] [int] NOT NULL IDENTITY,
    [attachment] [varbinary](max),
    [button_positions] [text],
    [comment] [varchar](100),
    [file_name] [varchar](50),
    CONSTRAINT [PK_dbo.GET_SCHEMATIC_IMAGE] PRIMARY KEY ([schematic_auto])
)
CREATE TABLE [dbo].[IMPLEMENT_CATEGORY] (
    [implement_category_auto] [int] NOT NULL IDENTITY,
    [category_name] [nvarchar](32) NOT NULL,
    [category_desc] [nvarchar](128) NOT NULL,
    [category_shortname] [nvarchar](16) NOT NULL,
    CONSTRAINT [PK_dbo.IMPLEMENT_CATEGORY] PRIMARY KEY ([implement_category_auto])
)
CREATE TABLE [dbo].[LU_GET_COMPART] (
    [compartid_auto] [int] NOT NULL IDENTITY,
    [compartid] [varchar](20) NOT NULL,
    [compart] [varchar](50) NOT NULL,
    [smcs_code] [int],
    [modifier_code] [varchar](20),
    [hrs] [int],
    [progid] [tinyint] NOT NULL,
    [Left] [bit],
    [parentid_auto] [int],
    [parentid] [varchar](10),
    [childoptid] [smallint],
    [multiple] [bit],
    [fixedamount] [int],
    [implement_auto] [bigint],
    [core] [bit],
    [group_id] [nvarchar](10),
    [expected_life] [numeric](18, 0),
    [expected_cost] [numeric](18, 0),
    [comparttype_auto] [int] NOT NULL,
    [companyname] [varchar](50),
    [sumpcapacity] [smallint] NOT NULL,
    [max_rebuilt] [smallint] NOT NULL,
    [oilsample_interval] [smallint] NOT NULL,
    [oilchg_interval] [smallint] NOT NULL,
    [insp_item] [bit],
    [insp_interval] [smallint],
    [insp_uom] [smallint],
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [bowldisplayorder] [smallint],
    [track_comp_row] [smallint],
    [track_comp_cts_maintype] [varchar](5),
    [track_comp_cts_subtype] [varchar](5),
    [compart_note] [varchar](1000),
    [sorder] [int],
    [hydraulic_inspect_symptoms] [varchar](100),
    [cs_compart_auto] [int],
    [positionid_auto] [int],
    [allow_duplicate] [bit],
    [standard_compartid_auto] [bigint],
    [ranking_auto] [int],
    [compartcategory_auto] [int],
    [price] [varchar](250),
    [new_limit] [int],
    [worn_limit] [int],
    [req_measure] [bit],
    CONSTRAINT [PK_dbo.LU_GET_COMPART] PRIMARY KEY ([compartid_auto])
)
CREATE TABLE [dbo].[LU_GET_COMPART_TYPE] (
    [comparttype_auto] [int] NOT NULL IDENTITY,
    [comparttypeid] [varchar](10) NOT NULL,
    [comparttype] [varchar](100) NOT NULL,
    [sorder] [int],
    [protected] [bit],
    [modified_user_auto] [bigint],
    [modified_date] [datetime],
    [implement_auto] [bigint],
    [multiple] [bit],
    [max_no] [int],
    [progid] [tinyint],
    [fixedamount] [int],
    [min_no] [int],
    [getmesurement] [bit],
    [system_auto] [smallint],
    [cs_comparttype_auto] [int],
    [standard_compart_type_auto] [bigint],
    [comparttype_shortkey] [varchar](10),
    CONSTRAINT [PK_dbo.LU_GET_COMPART_TYPE] PRIMARY KEY ([comparttype_auto])
)
CREATE TABLE [dbo].[LU_IMPLEMENT] (
    [implement_auto] [bigint] NOT NULL IDENTITY,
    [implementdescription] [varchar](50),
    [parentID] [bigint],
    [schematic_auto_multiple] [varchar](50),
    [implement_category_auto] [int] NOT NULL,
    CONSTRAINT [PK_dbo.LU_IMPLEMENT] PRIMARY KEY ([implement_auto])
)
CREATE TABLE [dbo].[LU_Module_Sub_History] (
    [Module_sub_his_auto] [bigint] NOT NULL IDENTITY,
    [Serialno] [nvarchar](50),
    [SMU] [bigint],
    [CMU] [bigint],
    [SMU_at_install] [bigint],
    [LTD_at_install] [bigint],
    [CreatedBy] [int],
    [CreatedDate] [datetime],
    [Compartid_auto] [bigint],
    [Equipmentid_auto] [bigint],
    [Comment] [nvarchar](500),
    [Equnit_auto] [bigint],
    [crsf_auto] [bigint],
    [make_auto] [bigint],
    [model_auto] [bigint],
    [type_auto] [bigint],
    CONSTRAINT [PK_dbo.LU_Module_Sub_History] PRIMARY KEY ([Module_sub_his_auto])
)
CREATE TABLE [dbo].[Mbl_CompartAttach_filestream] (
    [guid] [uniqueidentifier] NOT NULL,
    [compart_attach_auto] [bigint] NOT NULL,
    [compartid_auto] [bigint],
    [comparttype_auto] [bigint],
    [tool_auto] [int],
    [compart_attach_type_auto] [int],
    [user_auto] [bigint],
    [entry_date] [datetime],
    [comment] [varchar](1000),
    [attachment_name] [varchar](100),
    [attachment] [varbinary](max),
    [inspection_auto] [int],
    [position] [int],
    CONSTRAINT [PK_dbo.Mbl_CompartAttach_filestream] PRIMARY KEY ([guid], [compart_attach_auto])
)
CREATE TABLE [dbo].[Mbl_NewEquipment] (
    [equipmentid_auto] [bigint] NOT NULL,
    [serialno] [varchar](50) NOT NULL,
    [unitno] [varchar](50) NOT NULL,
    [mmtaid_auto] [int] NOT NULL,
    [crsf_auto] [bigint] NOT NULL,
    [equip_status] [int] NOT NULL,
    [vision_link_exist] [bit] NOT NULL,
    [description] [varchar](50),
    [derived_from] [bigint],
    [market_auto] [tinyint],
    [measure_unit] [tinyint],
    [op_hrs_per_day] [int],
    [op_dist_uom] [tinyint],
    [op_range] [varchar](50),
    [start_date] [datetime],
    [end_date] [datetime],
    [smu_at_start] [bigint],
    [distance_at_start] [bigint],
    [smu_at_end] [bigint],
    [distance_at_end] [bigint],
    [currentsmu] [bigint],
    [currentdistance] [bigint],
    [last_reading_date] [datetime],
    [notes] [varchar](5000),
    [LTD_at_start] [bigint],
    [location] [varchar](50),
    [purchase_op_hrs] [int],
    [purchase_op_dist] [int],
    [purchase_date] [datetime],
    [purchase_cost] [money],
    [deprate] [int],
    [depmethod] [varchar](10),
    [uccode] [varchar](10),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [regno] [varchar](50),
    [errorcode] [smallint],
    [fleet_auto] [bigint],
    [update_accept] [bit],
    [DBS_serialno] [varchar](10),
    [da_inclusion] [bit],
    [status_auto] [smallint],
    [first_reg_start_date] [datetime],
    [reg_start_date] [datetime],
    [period_auto] [smallint],
    [reg_expiry_date] [datetime],
    [service_cycle_type_auto] [int],
    [turbo_mod_auto] [int],
    [control_sys_auto] [int],
    [calendar_period] [int],
    [recurring_int_auto] [tinyint],
    [no_contract_fcast_date_at_start] [datetime],
    [no_contract_fcast_s_cycle_auto_at_end] [int],
    [no_contract_fcast_s_cycle_auto_at_start] [int],
    [no_contract_fcast_smu_at_start] [bigint],
    [track_make_auto] [int],
    [track_code_auto] [bigint],
    [cs_equip_auto] [bigint],
    [dtd_at_start] [bigint],
    [no_contract_fcast_smu_at_end] [bigint],
    [no_contract_fcast_LTD_at_start] [bigint],
    [no_contract_fcast_LTD_at_end] [bigint],
    [no_contract_fcast_date_at_end] [datetime],
    [ranking_auto] [tinyint],
    [secondary_uom_isHours] [bit],
    [secondary_uom_isDistance] [bit],
    [secondary_uom_isKWHours] [bit],
    [secondary_uom_isCalendar] [bit],
    [secondary_uom_isFuelBurn] [bit],
    [smu_sec_reading] [decimal](20, 2),
    [smu_ltd_sec_reading] [decimal](20, 2),
    [distance_sec_reading] [decimal](20, 2),
    [distance_ltd_sec_reading] [decimal](20, 2),
    [distance_sec_reading_uom] [tinyint],
    [kw_hrs_sec_reading] [decimal](20, 2),
    [kw_hrs_ltd_sec_reading] [decimal](20, 2),
    [fuel_burn_sec_reading] [decimal](20, 2),
    [fuel_burn_ltd_sec_reading] [decimal](20, 2),
    [calender_sec_reading] [decimal](20, 2),
    [calender_sec_reading_uom] [tinyint],
    [current_smu_sec_reading] [decimal](20, 2),
    [current_distance_sec_reading] [decimal](20, 2),
    [current_kw_hrs_sec_reading] [decimal](20, 2),
    [current_fuel_burn_sec_reading] [decimal](20, 2),
    [current_calender_sec_reading] [decimal](20, 2),
    [health_review_auto] [int],
    [AS400_EQUIPMENT_AUTO] [bigint],
    [Sec_AVGDB_Hours] [decimal](20, 2),
    [Sec_AVGDB_Distance] [decimal](20, 2),
    [Sec_AVGDB_KWHOURS] [decimal](20, 2),
    [Sec_AVGDB_FuelBurn] [decimal](20, 2),
    [Sec_AVGDB_Calender] [decimal](20, 2),
    [no_fcast_Sec_Smu] [bigint],
    [no_fcast_Sec_distance] [bigint],
    [no_fcast_Sec_SMU_ltd] [bigint],
    [no_fcast_Sec_distance_ltd] [bigint],
    [vision_link_import_date] [datetime],
    [customer_name] [varchar](200),
    [jobsite_name] [varchar](200),
    [model] [varchar](200),
    [pc_equipmentid_auto] [bigint],
    [pc_inspection_auto] [int],
    CONSTRAINT [PK_dbo.Mbl_NewEquipment] PRIMARY KEY ([equipmentid_auto], [serialno], [unitno], [mmtaid_auto], [crsf_auto], [equip_status], [vision_link_exist])
)
CREATE TABLE [dbo].[Mbl_NewGENERAL_EQ_UNIT] (
    [equnit_auto] [bigint] NOT NULL,
    [compartid_auto] [int] NOT NULL,
    [max_rebuild] [smallint] NOT NULL,
    [insp_item] [bit] NOT NULL,
    [comp_status] [tinyint] NOT NULL,
    [equipmentid_auto] [bigint],
    [compartsn] [varchar](50),
    [date_installed] [datetime],
    [smu_at_install] [bigint],
    [insp_interval] [smallint],
    [insp_uom] [smallint],
    [created_user] [varchar](50),
    [created_date] [datetime],
    [modified_user] [varchar](50),
    [modified_date] [datetime],
    [compart_note] [varchar](1000),
    [eq_smu_at_install] [bigint],
    [compart_descr] [varchar](50),
    [make_auto] [int],
    [model_auto] [int],
    [rebuild_no] [smallint],
    [rebuild_cost_builder] [bit],
    [rebuild_cost_before_failure] [money],
    [rebuild_cost_after_failure] [money],
    [rebuild_cost_probability_factor] [decimal](18, 2),
    [rebuild_cost_minor_repair_provision] [decimal](18, 2),
    [rebuild_cost_unscheduled_provision] [decimal](18, 2),
    [rebuild_cost_calculated] [money],
    [pos] [tinyint],
    [side] [tinyint],
    [variable_comp] [bit],
    [create_forecast] [bit],
    [track_0_worn] [float],
    [track_100_worn] [float],
    [track_120_worn] [float],
    [eq_ltd_at_install] [bigint],
    [chkOil] [bit],
    [chkInspectionTracking] [bit],
    [chkReplace] [bit],
    [chkRebuild] [bit],
    [chkFinancialTracking] [bit],
    [chkWarranty] [bit],
    [rebuild_cost_calculated1] [money],
    [rebuild_cost_calculated2] [money],
    [replace_cost_calculated] [money],
    [positionid_auto] [bigint],
    [chkActivateForecast] [bit],
    [parent_equnit_auto] [int],
    [component_current_value] [decimal](18, 2),
    [track_budget_life] [int],
    [cmu] [bigint],
    [module_ucsub_auto] [bigint],
    CONSTRAINT [PK_dbo.Mbl_NewGENERAL_EQ_UNIT] PRIMARY KEY ([equnit_auto], [compartid_auto], [max_rebuild], [insp_item], [comp_status])
)
CREATE TABLE [dbo].[Mbl_Track_Inspection] (
    [inspection_auto] [int] NOT NULL,
    [equipmentid_auto] [bigint] NOT NULL,
    [examiner] [varchar](50) NOT NULL,
    [inspection_date] [datetime] NOT NULL,
    [smu] [int],
    [notes] [varchar](1000),
    [track_sag_left] [decimal](18, 0),
    [track_sag_right] [decimal](18, 0),
    [track_sag_left_status] [varchar](50),
    [track_sag_right_status] [varchar](50),
    [dry_joints_left] [decimal](18, 0),
    [dry_joints_right] [decimal](18, 0),
    [ext_cannon_left] [decimal](18, 0),
    [ext_cannon_right] [decimal](18, 0),
    [frame_ext_left] [decimal](18, 0),
    [frame_ext_right] [decimal](18, 0),
    [sprocket_left_status] [varchar](50),
    [sprocket_right_status] [varchar](50),
    [impact] [smallint],
    [abrasive] [smallint],
    [moisture] [smallint],
    [packing] [smallint],
    [created_date] [datetime],
    [created_user] [varchar](50),
    [confirmed_date] [datetime],
    [confirmed_user] [varchar](50),
    [evalcode] [char](1),
    [allowableWear] [smallint],
    [uccode] [varchar](50),
    [uccodedesc] [varchar](255),
    [last_interp_date] [datetime],
    [last_interp_user] [varchar](50),
    [eval_comment] [varchar](1000),
    [location] [varchar](100),
    [docket_no] [varchar](50),
    [ucbrand] [varchar](50),
    [wear] [tinyint],
    [ltd] [int],
    [Jobsite_Comms] [varchar](1000),
    [released_date] [datetime],
    [released_by] [varchar](100),
    [inspection_comments] [varchar](max),
    [quote_auto] [int],
    CONSTRAINT [PK_dbo.Mbl_Track_Inspection] PRIMARY KEY ([inspection_auto], [equipmentid_auto], [examiner], [inspection_date])
)
CREATE TABLE [dbo].[Mbl_Track_Inspection_Detail] (
    [inspection_detail_auto] [int] NOT NULL,
    [inspection_auto] [int] NOT NULL,
    [track_unit_auto] [bigint] NOT NULL,
    [reading] [decimal](18, 2) NOT NULL,
    [worn_percentage] [decimal](18, 2) NOT NULL,
    [worn_percentage_120] [decimal](18, 2) NOT NULL,
    [tool_auto] [int],
    [eval_code] [char](1),
    [hours_on_surface] [int],
    [projected_hours] [int],
    [ext_projected_hours] [int],
    [remaining_hours] [int],
    [ext_remaining_hours] [int],
    [comments] [varchar](200),
    CONSTRAINT [PK_dbo.Mbl_Track_Inspection_Detail] PRIMARY KEY ([inspection_detail_auto], [inspection_auto], [track_unit_auto], [reading], [worn_percentage], [worn_percentage_120])
)
CREATE TABLE [dbo].[TRACK_ACTION_COMPONENT] (
    [action_auto] [int] NOT NULL,
    [is_done] [bit] NOT NULL,
    [equipmentid_auto] [int],
    [compartid_auto] [int],
    [eq_smu] [int],
    [inspection_auto] [int],
    [track_unit_auto] [int],
    [action_type_auto] [int],
    [compartid_auto_new] [int],
    [smu] [int],
    [budget_life] [int],
    [comment] [varchar](4000),
    [action_date] [datetime],
    [action_user] [varchar](50),
    [created_date] [datetime],
    [created_user] [varchar](50),
    [modified_date] [datetime],
    [modified_user] [varchar](50),
    [cmu] [int],
    [cost] [money],
    [side] [int],
    CONSTRAINT [PK_dbo.TRACK_ACTION_COMPONENT] PRIMARY KEY ([action_auto], [is_done])
)
CREATE TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_HITACHI] (
    [track_compart_worn_limit_hitachi_auto] [int] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [track_tools_auto] [int] NOT NULL,
    [impact_slope] [decimal](18, 3),
    [normal_slope] [decimal](18, 3),
    [impact_intercept] [decimal](18, 3),
    [normal_intercept] [decimal](18, 3),
    CONSTRAINT [PK_dbo.TRACK_COMPART_WORN_LIMIT_HITACHI] PRIMARY KEY ([track_compart_worn_limit_hitachi_auto])
)
CREATE TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_KOMATSU] (
    [track_compart_worn_limit_komatsu_auto] [int] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [track_tools_auto] [int] NOT NULL,
    [slope_impact] [decimal](18, 3),
    [slope_normal] [decimal](18, 3),
    [impact_slope] [decimal](18, 3),
    [normal_slope] [decimal](18, 3),
    [impact_intercept] [decimal](18, 3),
    [normal_intercept] [decimal](18, 3),
    [impact_secondorder] [decimal](18, 3),
    [normal_secondorder] [decimal](18, 3),
    CONSTRAINT [PK_dbo.TRACK_COMPART_WORN_LIMIT_KOMATSU] PRIMARY KEY ([track_compart_worn_limit_komatsu_auto])
)
CREATE TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_LIEBHERR] (
    [track_compart_worn_limit_liebherr_auto] [int] NOT NULL IDENTITY,
    [compartid_auto] [int] NOT NULL,
    [track_tools_auto] [int] NOT NULL,
    [impact_slope] [decimal](18, 3),
    [normal_slope] [decimal](18, 3),
    [impact_intercept] [decimal](18, 3),
    [normal_intercept] [decimal](18, 3),
    CONSTRAINT [PK_dbo.TRACK_COMPART_WORN_LIMIT_LIEBHERR] PRIMARY KEY ([track_compart_worn_limit_liebherr_auto])
)
CREATE TABLE [dbo].[TRACK_DEALERSHIP_LIMITS] (
    [dealership_limit_auto] [bigint] NOT NULL IDENTITY,
    [a_limit] [int],
    [b_limit] [int],
    [c_limit] [int],
    [compartid_auto] [int],
    [modified_date] [datetime],
    [modified_user] [varchar](30),
    CONSTRAINT [PK_dbo.TRACK_DEALERSHIP_LIMITS] PRIMARY KEY ([dealership_limit_auto])
)
CREATE TABLE [dbo].[TRACK_EQ_LIMITS] (
    [equipmentid_auto] [bigint] NOT NULL,
    [smcs_code] [int],
    [a_limit] [int],
    [b_limit] [int],
    [c_limit] [int],
    [modified_date] [datetime],
    [modified_user] [varchar](30),
    [compartid_auto] [int],
    CONSTRAINT [PK_dbo.TRACK_EQ_LIMITS] PRIMARY KEY ([equipmentid_auto])
)
CREATE TABLE [dbo].[TRACK_MODEL_LIMITS] (
    [model_auto] [bigint] NOT NULL,
    [a_limit] [int],
    [b_limit] [int],
    [c_limit] [int],
    [modified_date] [datetime],
    [modified_user] [varchar](30),
    [compartid_auto] [int],
    CONSTRAINT [PK_dbo.TRACK_MODEL_LIMITS] PRIMARY KEY ([model_auto])
)
CREATE INDEX [IX_user_auto] ON [dbo].[UserAccessMaps]([user_auto])
CREATE INDEX [IX_DealershipId] ON [dbo].[UserAccessMaps]([DealershipId])
CREATE INDEX [IX_customer_auto] ON [dbo].[UserAccessMaps]([customer_auto])
CREATE INDEX [IX_crsf_auto] ON [dbo].[UserAccessMaps]([crsf_auto])
CREATE INDEX [IX_equipmentid_auto] ON [dbo].[UserAccessMaps]([equipmentid_auto])
CREATE INDEX [IX_AccessLevelTypeId] ON [dbo].[UserAccessMaps]([AccessLevelTypeId])
CREATE INDEX [IX_type_auto] ON [dbo].[CRSF]([type_auto])
CREATE INDEX [IX_CreatedByUserId] ON [dbo].[CRSF]([CreatedByUserId])
CREATE INDEX [IX_crsf_auto] ON [dbo].[CRSF_AREA]([crsf_auto])
CREATE INDEX [IX_equnit_Id] ON [dbo].[COMP_Inventory_Inspec_Details]([equnit_Id])
CREATE INDEX [IX_tool_Id] ON [dbo].[COMP_Inventory_Inspec_Details]([tool_Id])
CREATE INDEX [IX_UserId] ON [dbo].[COMP_Inventory_Inspec_Details]([UserId])
CREATE INDEX [IX_compartid_auto] ON [dbo].[GENERAL_EQ_UNIT]([compartid_auto])
CREATE INDEX [IX_ComponentId] ON [dbo].[COMPONENT_LIFE]([ComponentId])
CREATE INDEX [IX_ActionId] ON [dbo].[COMPONENT_LIFE]([ActionId])
CREATE INDEX [IX_UserId] ON [dbo].[COMPONENT_LIFE]([UserId])
CREATE INDEX [IX_action_type_auto] ON [dbo].[ACTION_TAKEN_HISTORY]([action_type_auto])
CREATE INDEX [IX_EquipmentId] ON [dbo].[EQUIPMENT_LIFE]([EquipmentId])
CREATE INDEX [IX_ActionId] ON [dbo].[EQUIPMENT_LIFE]([ActionId])
CREATE INDEX [IX_UserId] ON [dbo].[EQUIPMENT_LIFE]([UserId])
CREATE INDEX [IX_mmtaid_auto] ON [dbo].[EQUIPMENT]([mmtaid_auto])
CREATE INDEX [IX_track_make_auto] ON [dbo].[EQUIPMENT]([track_make_auto])
CREATE INDEX [IX_equipmentid_auto] ON [dbo].[ACTION_LOG]([equipmentid_auto])
CREATE INDEX [IX_equipmentid_auto] ON [dbo].[GET]([equipmentid_auto])
CREATE INDEX [IX_get_auto] ON [dbo].[GET_IMPLEMENT_INSPECTION]([get_auto])
CREATE INDEX [IX_implement_inspection_auto] ON [dbo].[GET_COMPONENT_INSPECTION]([implement_inspection_auto])
CREATE INDEX [IX_inspection_auto] ON [dbo].[GET_OBSERVATION_RESULTS]([inspection_auto])
CREATE INDEX [IX_observations_auto] ON [dbo].[GET_OBSERVATION_RESULTS]([observations_auto])
CREATE INDEX [IX_results_auto] ON [dbo].[GET_OBSERVATION_IMAGE]([results_auto])
CREATE INDEX [IX_inspection_auto] ON [dbo].[GET_IMPLEMENT_INSPECTION_IMAGE]([inspection_auto])
CREATE INDEX [IX_parameter_type] ON [dbo].[GET_IMPLEMENT_INSPECTION_IMAGE]([parameter_type])
CREATE INDEX [IX_parameter_type] ON [dbo].[GET_INSPECTION_CONSTANTS]([parameter_type])
CREATE INDEX [IX_implement_id] ON [dbo].[IMPLEMENT_READING_ENTRY]([implement_id])
CREATE INDEX [IX_make_auto] ON [dbo].[LU_MMTA]([make_auto])
CREATE INDEX [IX_model_auto] ON [dbo].[LU_MMTA]([model_auto])
CREATE INDEX [IX_type_auto] ON [dbo].[LU_MMTA]([type_auto])
CREATE INDEX [IX_app_auto] ON [dbo].[LU_MMTA]([app_auto])
CREATE INDEX [IX_compartid_auto] ON [dbo].[TRACK_COMPART_EXT]([compartid_auto])
CREATE INDEX [IX_make_auto] ON [dbo].[TRACK_COMPART_EXT]([make_auto])
CREATE INDEX [IX_tools_auto] ON [dbo].[TRACK_COMPART_EXT]([tools_auto])
CREATE INDEX [IX_track_compart_worn_calc_method_auto] ON [dbo].[TRACK_COMPART_EXT]([track_compart_worn_calc_method_auto])
CREATE INDEX [IX_comparttype_auto] ON [dbo].[LU_COMPART]([comparttype_auto])
CREATE INDEX [IX_ParentCompartId] ON [dbo].[COMPART_PARENT_RELATION]([ParentCompartId])
CREATE INDEX [IX_ChildCompartId] ON [dbo].[COMPART_PARENT_RELATION]([ChildCompartId])
CREATE INDEX [IX_CompartId] ON [dbo].[COMPART_TOOL_IMAGE]([CompartId])
CREATE INDEX [IX_ToolId] ON [dbo].[COMPART_TOOL_IMAGE]([ToolId])
CREATE INDEX [IX_compartid_auto] ON [dbo].[TRACK_COMPART_WORN_LIMIT_CAT]([compartid_auto])
CREATE INDEX [IX_track_tools_auto] ON [dbo].[TRACK_COMPART_WORN_LIMIT_CAT]([track_tools_auto])
CREATE INDEX [IX_compartid_auto] ON [dbo].[TRACK_COMPART_WORN_LIMIT_ITM]([compartid_auto])
CREATE INDEX [IX_track_tools_auto] ON [dbo].[TRACK_COMPART_WORN_LIMIT_ITM]([track_tools_auto])
CREATE INDEX [IX_inspection_auto] ON [dbo].[TRACK_INSPECTION_DETAIL]([inspection_auto])
CREATE INDEX [IX_track_unit_auto] ON [dbo].[TRACK_INSPECTION_DETAIL]([track_unit_auto])
CREATE INDEX [IX_tool_auto] ON [dbo].[TRACK_INSPECTION_DETAIL]([tool_auto])
CREATE INDEX [IX_UCSystemId] ON [dbo].[TRACK_INSPECTION_DETAIL]([UCSystemId])
CREATE INDEX [IX_InspectionDetailId] ON [dbo].[TRACK_INSPECTION_IMAGES]([InspectionDetailId])
CREATE INDEX [IX_equipmentid_auto] ON [dbo].[LU_Module_Sub]([equipmentid_auto])
CREATE INDEX [IX_SystemId] ON [dbo].[UCSYSTEM_LIFE]([SystemId])
CREATE INDEX [IX_ActionId] ON [dbo].[UCSYSTEM_LIFE]([ActionId])
CREATE INDEX [IX_UserId] ON [dbo].[UCSYSTEM_LIFE]([UserId])
CREATE INDEX [IX_InspectionDetailsId] ON [dbo].[InspectionDetails_Side]([InspectionDetailsId])
CREATE INDEX [IX_TRACK_INSPECTION_DETAIL1_inspection_detail_auto] ON [dbo].[InspectionDetails_Side]([TRACK_INSPECTION_DETAIL1_inspection_detail_auto])
CREATE INDEX [IX_equipmentid_auto] ON [dbo].[TRACK_INSPECTION]([equipmentid_auto])
CREATE INDEX [IX_ActionHistoryId] ON [dbo].[TRACK_INSPECTION]([ActionHistoryId])
CREATE INDEX [IX_inspection_auto] ON [dbo].[TRACK_ACTION]([inspection_auto])
CREATE INDEX [IX_action_auto] ON [dbo].[TRACK_ACTION_TAKEN]([action_auto])
CREATE INDEX [IX_compartid_auto] ON [dbo].[LU_COMPART_PARTS]([compartid_auto])
CREATE INDEX [IX_compartid_auto] ON [dbo].[LU_GET_COMPART_SUB_TYPE]([compartid_auto])
CREATE INDEX [IX_user_auto] ON [dbo].[USER_CRSF_CUST_EQUIP]([user_auto])
CREATE INDEX [IX_customer_auto] ON [dbo].[USER_CRSF_CUST_EQUIP]([customer_auto])
CREATE INDEX [IX_crsf_auto] ON [dbo].[USER_CRSF_CUST_EQUIP]([crsf_auto])
CREATE INDEX [IX_equipmentid_auto] ON [dbo].[USER_CRSF_CUST_EQUIP]([equipmentid_auto])
CREATE INDEX [IX_modified_user_auto] ON [dbo].[USER_CRSF_CUST_EQUIP]([modified_user_auto])
CREATE INDEX [IX_DealershipId] ON [dbo].[CUSTOMER]([DealershipId])
CREATE INDEX [IX_Owner] ON [dbo].[Dealerships]([Owner])
CREATE INDEX [IX_user_auto] ON [dbo].[EQUIPMENT_AUDIT_HISTOY]([user_auto])
CREATE INDEX [IX_user_auto] ON [dbo].[USER_DEALERSHIP]([user_auto])
CREATE INDEX [IX_compart_attach_type_auto] ON [dbo].[COMPART_ATTACH_FILESTREAM]([compart_attach_type_auto])
CREATE INDEX [IX_comparttype_auto] ON [dbo].[LU_GET_COMPART]([comparttype_auto])
ALTER TABLE [dbo].[UserAccessMaps] ADD CONSTRAINT [FK_dbo.UserAccessMaps_dbo.Dealerships_DealershipId] FOREIGN KEY ([DealershipId]) REFERENCES [dbo].[Dealerships] ([DealershipId])
ALTER TABLE [dbo].[UserAccessMaps] ADD CONSTRAINT [FK_dbo.UserAccessMaps_dbo.CUSTOMER_customer_auto] FOREIGN KEY ([customer_auto]) REFERENCES [dbo].[CUSTOMER] ([customer_auto])
ALTER TABLE [dbo].[UserAccessMaps] ADD CONSTRAINT [FK_dbo.UserAccessMaps_dbo.EQUIPMENT_equipmentid_auto] FOREIGN KEY ([equipmentid_auto]) REFERENCES [dbo].[EQUIPMENT] ([equipmentid_auto])
ALTER TABLE [dbo].[UserAccessMaps] ADD CONSTRAINT [FK_dbo.UserAccessMaps_dbo.USER_TABLE_user_auto] FOREIGN KEY ([user_auto]) REFERENCES [dbo].[USER_TABLE] ([user_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[UserAccessMaps] ADD CONSTRAINT [FK_dbo.UserAccessMaps_dbo.CRSF_crsf_auto] FOREIGN KEY ([crsf_auto]) REFERENCES [dbo].[CRSF] ([crsf_auto])
ALTER TABLE [dbo].[UserAccessMaps] ADD CONSTRAINT [FK_dbo.UserAccessMaps_dbo.AccessLevelTypes_AccessLevelTypeId] FOREIGN KEY ([AccessLevelTypeId]) REFERENCES [dbo].[AccessLevelTypes] ([AccessLevelTypesId]) ON DELETE CASCADE
ALTER TABLE [dbo].[CRSF] ADD CONSTRAINT [FK_dbo.CRSF_dbo.CRSF_TYPE_type_auto] FOREIGN KEY ([type_auto]) REFERENCES [dbo].[CRSF_TYPE] ([crsf_type_auto])
ALTER TABLE [dbo].[CRSF] ADD CONSTRAINT [FK_dbo.CRSF_dbo.USER_TABLE_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [dbo].[USER_TABLE] ([user_auto])
ALTER TABLE [dbo].[CRSF_AREA] ADD CONSTRAINT [FK_dbo.CRSF_AREA_dbo.CRSF_crsf_auto] FOREIGN KEY ([crsf_auto]) REFERENCES [dbo].[CRSF] ([crsf_auto])
ALTER TABLE [dbo].[COMP_Inventory_Inspec_Details] ADD CONSTRAINT [FK_dbo.COMP_Inventory_Inspec_Details_dbo.GENERAL_EQ_UNIT_equnit_Id] FOREIGN KEY ([equnit_Id]) REFERENCES [dbo].[GENERAL_EQ_UNIT] ([equnit_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[COMP_Inventory_Inspec_Details] ADD CONSTRAINT [FK_dbo.COMP_Inventory_Inspec_Details_dbo.TRACK_TOOL_tool_Id] FOREIGN KEY ([tool_Id]) REFERENCES [dbo].[TRACK_TOOL] ([tool_auto])
ALTER TABLE [dbo].[COMP_Inventory_Inspec_Details] ADD CONSTRAINT [FK_dbo.COMP_Inventory_Inspec_Details_dbo.USER_TABLE_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[USER_TABLE] ([user_auto])
ALTER TABLE [dbo].[GENERAL_EQ_UNIT] ADD CONSTRAINT [FK_dbo.GENERAL_EQ_UNIT_dbo.LU_COMPART_compartid_auto] FOREIGN KEY ([compartid_auto]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto])
ALTER TABLE [dbo].[COMPONENT_LIFE] ADD CONSTRAINT [FK_dbo.COMPONENT_LIFE_dbo.ACTION_TAKEN_HISTORY_ActionId] FOREIGN KEY ([ActionId]) REFERENCES [dbo].[ACTION_TAKEN_HISTORY] ([history_id]) ON DELETE CASCADE
ALTER TABLE [dbo].[COMPONENT_LIFE] ADD CONSTRAINT [FK_dbo.COMPONENT_LIFE_dbo.GENERAL_EQ_UNIT_ComponentId] FOREIGN KEY ([ComponentId]) REFERENCES [dbo].[GENERAL_EQ_UNIT] ([equnit_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[COMPONENT_LIFE] ADD CONSTRAINT [FK_dbo.COMPONENT_LIFE_dbo.USER_TABLE_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[USER_TABLE] ([user_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[ACTION_TAKEN_HISTORY] ADD CONSTRAINT [FK_dbo.ACTION_TAKEN_HISTORY_dbo.TRACK_ACTION_TYPE_action_type_auto] FOREIGN KEY ([action_type_auto]) REFERENCES [dbo].[TRACK_ACTION_TYPE] ([action_type_auto])
ALTER TABLE [dbo].[EQUIPMENT_LIFE] ADD CONSTRAINT [FK_dbo.EQUIPMENT_LIFE_dbo.EQUIPMENT_EquipmentId] FOREIGN KEY ([EquipmentId]) REFERENCES [dbo].[EQUIPMENT] ([equipmentid_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[EQUIPMENT_LIFE] ADD CONSTRAINT [FK_dbo.EQUIPMENT_LIFE_dbo.ACTION_TAKEN_HISTORY_ActionId] FOREIGN KEY ([ActionId]) REFERENCES [dbo].[ACTION_TAKEN_HISTORY] ([history_id]) ON DELETE CASCADE
ALTER TABLE [dbo].[EQUIPMENT_LIFE] ADD CONSTRAINT [FK_dbo.EQUIPMENT_LIFE_dbo.USER_TABLE_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[USER_TABLE] ([user_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[EQUIPMENT] ADD CONSTRAINT [FK_dbo.EQUIPMENT_dbo.LU_MMTA_mmtaid_auto] FOREIGN KEY ([mmtaid_auto]) REFERENCES [dbo].[LU_MMTA] ([mmtaid_auto])
ALTER TABLE [dbo].[EQUIPMENT] ADD CONSTRAINT [FK_dbo.EQUIPMENT_dbo.MAKE_track_make_auto] FOREIGN KEY ([track_make_auto]) REFERENCES [dbo].[MAKE] ([make_auto])
ALTER TABLE [dbo].[ACTION_LOG] ADD CONSTRAINT [FK_dbo.ACTION_LOG_dbo.EQUIPMENT_equipmentid_auto] FOREIGN KEY ([equipmentid_auto]) REFERENCES [dbo].[EQUIPMENT] ([equipmentid_auto])
ALTER TABLE [dbo].[GET] ADD CONSTRAINT [FK_dbo.GET_dbo.EQUIPMENT_equipmentid_auto] FOREIGN KEY ([equipmentid_auto]) REFERENCES [dbo].[EQUIPMENT] ([equipmentid_auto])
ALTER TABLE [dbo].[GET_IMPLEMENT_INSPECTION] ADD CONSTRAINT [FK_dbo.GET_IMPLEMENT_INSPECTION_dbo.GET_get_auto] FOREIGN KEY ([get_auto]) REFERENCES [dbo].[GET] ([get_auto])
ALTER TABLE [dbo].[GET_COMPONENT_INSPECTION] ADD CONSTRAINT [FK_dbo.GET_COMPONENT_INSPECTION_dbo.GET_IMPLEMENT_INSPECTION_implement_inspection_auto] FOREIGN KEY ([implement_inspection_auto]) REFERENCES [dbo].[GET_IMPLEMENT_INSPECTION] ([inspection_auto])
ALTER TABLE [dbo].[GET_OBSERVATION_RESULTS] ADD CONSTRAINT [FK_dbo.GET_OBSERVATION_RESULTS_dbo.GET_OBSERVATIONS_observations_auto] FOREIGN KEY ([observations_auto]) REFERENCES [dbo].[GET_OBSERVATIONS] ([observations_auto])
ALTER TABLE [dbo].[GET_OBSERVATION_RESULTS] ADD CONSTRAINT [FK_dbo.GET_OBSERVATION_RESULTS_dbo.GET_COMPONENT_INSPECTION_inspection_auto] FOREIGN KEY ([inspection_auto]) REFERENCES [dbo].[GET_COMPONENT_INSPECTION] ([inspection_auto])
ALTER TABLE [dbo].[GET_OBSERVATION_IMAGE] ADD CONSTRAINT [FK_dbo.GET_OBSERVATION_IMAGE_dbo.GET_OBSERVATION_RESULTS_results_auto] FOREIGN KEY ([results_auto]) REFERENCES [dbo].[GET_OBSERVATION_RESULTS] ([results_auto])
ALTER TABLE [dbo].[GET_IMPLEMENT_INSPECTION_IMAGE] ADD CONSTRAINT [FK_dbo.GET_IMPLEMENT_INSPECTION_IMAGE_dbo.GET_INSPECTION_PARAMETERS_parameter_type] FOREIGN KEY ([parameter_type]) REFERENCES [dbo].[GET_INSPECTION_PARAMETERS] ([parameter_type])
ALTER TABLE [dbo].[GET_IMPLEMENT_INSPECTION_IMAGE] ADD CONSTRAINT [FK_dbo.GET_IMPLEMENT_INSPECTION_IMAGE_dbo.GET_IMPLEMENT_INSPECTION_inspection_auto] FOREIGN KEY ([inspection_auto]) REFERENCES [dbo].[GET_IMPLEMENT_INSPECTION] ([inspection_auto])
ALTER TABLE [dbo].[GET_INSPECTION_CONSTANTS] ADD CONSTRAINT [FK_dbo.GET_INSPECTION_CONSTANTS_dbo.GET_INSPECTION_PARAMETERS_parameter_type] FOREIGN KEY ([parameter_type]) REFERENCES [dbo].[GET_INSPECTION_PARAMETERS] ([parameter_type])
ALTER TABLE [dbo].[IMPLEMENT_READING_ENTRY] ADD CONSTRAINT [FK_dbo.IMPLEMENT_READING_ENTRY_dbo.GET_implement_id] FOREIGN KEY ([implement_id]) REFERENCES [dbo].[GET] ([get_auto])
ALTER TABLE [dbo].[LU_MMTA] ADD CONSTRAINT [FK_dbo.LU_MMTA_dbo.APPLICATION_app_auto] FOREIGN KEY ([app_auto]) REFERENCES [dbo].[APPLICATION] ([app_auto])
ALTER TABLE [dbo].[LU_MMTA] ADD CONSTRAINT [FK_dbo.LU_MMTA_dbo.MAKE_make_auto] FOREIGN KEY ([make_auto]) REFERENCES [dbo].[MAKE] ([make_auto])
ALTER TABLE [dbo].[LU_MMTA] ADD CONSTRAINT [FK_dbo.LU_MMTA_dbo.MODEL_model_auto] FOREIGN KEY ([model_auto]) REFERENCES [dbo].[MODEL] ([model_auto])
ALTER TABLE [dbo].[LU_MMTA] ADD CONSTRAINT [FK_dbo.LU_MMTA_dbo.TYPE_type_auto] FOREIGN KEY ([type_auto]) REFERENCES [dbo].[TYPE] ([type_auto])
ALTER TABLE [dbo].[TRACK_COMPART_EXT] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_EXT_dbo.TRACK_TOOL_tools_auto] FOREIGN KEY ([tools_auto]) REFERENCES [dbo].[TRACK_TOOL] ([tool_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[TRACK_COMPART_EXT] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_EXT_dbo.LU_COMPART_compartid_auto] FOREIGN KEY ([compartid_auto]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[TRACK_COMPART_EXT] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_EXT_dbo.TRACK_COMPART_WORN_CALC_METHOD_track_compart_worn_calc_method_auto] FOREIGN KEY ([track_compart_worn_calc_method_auto]) REFERENCES [dbo].[TRACK_COMPART_WORN_CALC_METHOD] ([track_compart_worn_calc_method_auto])
ALTER TABLE [dbo].[TRACK_COMPART_EXT] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_EXT_dbo.MAKE_make_auto] FOREIGN KEY ([make_auto]) REFERENCES [dbo].[MAKE] ([make_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[LU_COMPART] ADD CONSTRAINT [FK_dbo.LU_COMPART_dbo.LU_COMPART_TYPE_comparttype_auto] FOREIGN KEY ([comparttype_auto]) REFERENCES [dbo].[LU_COMPART_TYPE] ([comparttype_auto])
ALTER TABLE [dbo].[COMPART_PARENT_RELATION] ADD CONSTRAINT [FK_dbo.COMPART_PARENT_RELATION_dbo.LU_COMPART_ChildCompartId] FOREIGN KEY ([ChildCompartId]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[COMPART_PARENT_RELATION] ADD CONSTRAINT [FK_dbo.COMPART_PARENT_RELATION_dbo.LU_COMPART_ParentCompartId] FOREIGN KEY ([ParentCompartId]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto])
ALTER TABLE [dbo].[COMPART_TOOL_IMAGE] ADD CONSTRAINT [FK_dbo.COMPART_TOOL_IMAGE_dbo.TRACK_TOOL_ToolId] FOREIGN KEY ([ToolId]) REFERENCES [dbo].[TRACK_TOOL] ([tool_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[COMPART_TOOL_IMAGE] ADD CONSTRAINT [FK_dbo.COMPART_TOOL_IMAGE_dbo.LU_COMPART_CompartId] FOREIGN KEY ([CompartId]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_CAT] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_WORN_LIMIT_CAT_dbo.TRACK_TOOL_track_tools_auto] FOREIGN KEY ([track_tools_auto]) REFERENCES [dbo].[TRACK_TOOL] ([tool_auto])
ALTER TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_CAT] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_WORN_LIMIT_CAT_dbo.LU_COMPART_compartid_auto] FOREIGN KEY ([compartid_auto]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto])
ALTER TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_ITM] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_WORN_LIMIT_ITM_dbo.TRACK_TOOL_track_tools_auto] FOREIGN KEY ([track_tools_auto]) REFERENCES [dbo].[TRACK_TOOL] ([tool_auto])
ALTER TABLE [dbo].[TRACK_COMPART_WORN_LIMIT_ITM] ADD CONSTRAINT [FK_dbo.TRACK_COMPART_WORN_LIMIT_ITM_dbo.LU_COMPART_compartid_auto] FOREIGN KEY ([compartid_auto]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto])
ALTER TABLE [dbo].[TRACK_INSPECTION_DETAIL] ADD CONSTRAINT [FK_dbo.TRACK_INSPECTION_DETAIL_dbo.LU_Module_Sub_UCSystemId] FOREIGN KEY ([UCSystemId]) REFERENCES [dbo].[LU_Module_Sub] ([Module_sub_auto])
ALTER TABLE [dbo].[TRACK_INSPECTION_DETAIL] ADD CONSTRAINT [FK_dbo.TRACK_INSPECTION_DETAIL_dbo.TRACK_INSPECTION_inspection_auto] FOREIGN KEY ([inspection_auto]) REFERENCES [dbo].[TRACK_INSPECTION] ([inspection_auto])
ALTER TABLE [dbo].[TRACK_INSPECTION_DETAIL] ADD CONSTRAINT [FK_dbo.TRACK_INSPECTION_DETAIL_dbo.TRACK_TOOL_tool_auto] FOREIGN KEY ([tool_auto]) REFERENCES [dbo].[TRACK_TOOL] ([tool_auto])
ALTER TABLE [dbo].[TRACK_INSPECTION_DETAIL] ADD CONSTRAINT [FK_dbo.TRACK_INSPECTION_DETAIL_dbo.GENERAL_EQ_UNIT_track_unit_auto] FOREIGN KEY ([track_unit_auto]) REFERENCES [dbo].[GENERAL_EQ_UNIT] ([equnit_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[TRACK_INSPECTION_IMAGES] ADD CONSTRAINT [FK_dbo.TRACK_INSPECTION_IMAGES_dbo.TRACK_INSPECTION_DETAIL_InspectionDetailId] FOREIGN KEY ([InspectionDetailId]) REFERENCES [dbo].[TRACK_INSPECTION_DETAIL] ([inspection_detail_auto])
ALTER TABLE [dbo].[LU_Module_Sub] ADD CONSTRAINT [FK_dbo.LU_Module_Sub_dbo.EQUIPMENT_equipmentid_auto] FOREIGN KEY ([equipmentid_auto]) REFERENCES [dbo].[EQUIPMENT] ([equipmentid_auto])
ALTER TABLE [dbo].[UCSYSTEM_LIFE] ADD CONSTRAINT [FK_dbo.UCSYSTEM_LIFE_dbo.LU_Module_Sub_SystemId] FOREIGN KEY ([SystemId]) REFERENCES [dbo].[LU_Module_Sub] ([Module_sub_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[UCSYSTEM_LIFE] ADD CONSTRAINT [FK_dbo.UCSYSTEM_LIFE_dbo.ACTION_TAKEN_HISTORY_ActionId] FOREIGN KEY ([ActionId]) REFERENCES [dbo].[ACTION_TAKEN_HISTORY] ([history_id]) ON DELETE CASCADE
ALTER TABLE [dbo].[UCSYSTEM_LIFE] ADD CONSTRAINT [FK_dbo.UCSYSTEM_LIFE_dbo.USER_TABLE_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[USER_TABLE] ([user_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[InspectionDetails_Side] ADD CONSTRAINT [FK_dbo.InspectionDetails_Side_dbo.TRACK_INSPECTION_DETAIL_TRACK_INSPECTION_DETAIL1_inspection_detail_auto] FOREIGN KEY ([TRACK_INSPECTION_DETAIL1_inspection_detail_auto]) REFERENCES [dbo].[TRACK_INSPECTION_DETAIL] ([inspection_detail_auto])
ALTER TABLE [dbo].[InspectionDetails_Side] ADD CONSTRAINT [FK_dbo.InspectionDetails_Side_dbo.TRACK_INSPECTION_DETAIL_InspectionDetailsId] FOREIGN KEY ([InspectionDetailsId]) REFERENCES [dbo].[TRACK_INSPECTION_DETAIL] ([inspection_detail_auto])
ALTER TABLE [dbo].[TRACK_INSPECTION] ADD CONSTRAINT [FK_dbo.TRACK_INSPECTION_dbo.EQUIPMENT_equipmentid_auto] FOREIGN KEY ([equipmentid_auto]) REFERENCES [dbo].[EQUIPMENT] ([equipmentid_auto])
ALTER TABLE [dbo].[TRACK_INSPECTION] ADD CONSTRAINT [FK_dbo.TRACK_INSPECTION_dbo.ACTION_TAKEN_HISTORY_ActionHistoryId] FOREIGN KEY ([ActionHistoryId]) REFERENCES [dbo].[ACTION_TAKEN_HISTORY] ([history_id])
ALTER TABLE [dbo].[TRACK_ACTION] ADD CONSTRAINT [FK_dbo.TRACK_ACTION_dbo.TRACK_INSPECTION_inspection_auto] FOREIGN KEY ([inspection_auto]) REFERENCES [dbo].[TRACK_INSPECTION] ([inspection_auto])
ALTER TABLE [dbo].[TRACK_ACTION_TAKEN] ADD CONSTRAINT [FK_dbo.TRACK_ACTION_TAKEN_dbo.TRACK_ACTION_action_auto] FOREIGN KEY ([action_auto]) REFERENCES [dbo].[TRACK_ACTION] ([action_auto])
ALTER TABLE [dbo].[LU_COMPART_PARTS] ADD CONSTRAINT [FK_dbo.LU_COMPART_PARTS_dbo.LU_COMPART_compartid_auto] FOREIGN KEY ([compartid_auto]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto])
ALTER TABLE [dbo].[LU_GET_COMPART_SUB_TYPE] ADD CONSTRAINT [FK_dbo.LU_GET_COMPART_SUB_TYPE_dbo.LU_COMPART_compartid_auto] FOREIGN KEY ([compartid_auto]) REFERENCES [dbo].[LU_COMPART] ([compartid_auto])
ALTER TABLE [dbo].[USER_CRSF_CUST_EQUIP] ADD CONSTRAINT [FK_dbo.USER_CRSF_CUST_EQUIP_dbo.CRSF_crsf_auto] FOREIGN KEY ([crsf_auto]) REFERENCES [dbo].[CRSF] ([crsf_auto])
ALTER TABLE [dbo].[USER_CRSF_CUST_EQUIP] ADD CONSTRAINT [FK_dbo.USER_CRSF_CUST_EQUIP_dbo.CUSTOMER_customer_auto] FOREIGN KEY ([customer_auto]) REFERENCES [dbo].[CUSTOMER] ([customer_auto])
ALTER TABLE [dbo].[USER_CRSF_CUST_EQUIP] ADD CONSTRAINT [FK_dbo.USER_CRSF_CUST_EQUIP_dbo.EQUIPMENT_equipmentid_auto] FOREIGN KEY ([equipmentid_auto]) REFERENCES [dbo].[EQUIPMENT] ([equipmentid_auto])
ALTER TABLE [dbo].[USER_CRSF_CUST_EQUIP] ADD CONSTRAINT [FK_dbo.USER_CRSF_CUST_EQUIP_dbo.USER_TABLE_user_auto] FOREIGN KEY ([user_auto]) REFERENCES [dbo].[USER_TABLE] ([user_auto])
ALTER TABLE [dbo].[USER_CRSF_CUST_EQUIP] ADD CONSTRAINT [FK_dbo.USER_CRSF_CUST_EQUIP_dbo.USER_TABLE_modified_user_auto] FOREIGN KEY ([modified_user_auto]) REFERENCES [dbo].[USER_TABLE] ([user_auto])
ALTER TABLE [dbo].[CUSTOMER] ADD CONSTRAINT [FK_dbo.CUSTOMER_dbo.Dealerships_DealershipId] FOREIGN KEY ([DealershipId]) REFERENCES [dbo].[Dealerships] ([DealershipId]) ON DELETE CASCADE
ALTER TABLE [dbo].[Dealerships] ADD CONSTRAINT [FK_dbo.Dealerships_dbo.USER_TABLE_Owner] FOREIGN KEY ([Owner]) REFERENCES [dbo].[USER_TABLE] ([user_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[EQUIPMENT_AUDIT_HISTOY] ADD CONSTRAINT [FK_dbo.EQUIPMENT_AUDIT_HISTOY_dbo.USER_TABLE_user_auto] FOREIGN KEY ([user_auto]) REFERENCES [dbo].[USER_TABLE] ([user_auto])
ALTER TABLE [dbo].[USER_DEALERSHIP] ADD CONSTRAINT [FK_dbo.USER_DEALERSHIP_dbo.USER_TABLE_user_auto] FOREIGN KEY ([user_auto]) REFERENCES [dbo].[USER_TABLE] ([user_auto]) ON DELETE CASCADE
ALTER TABLE [dbo].[COMPART_ATTACH_FILESTREAM] ADD CONSTRAINT [FK_dbo.COMPART_ATTACH_FILESTREAM_dbo.COMPART_ATTACH_TYPE_compart_attach_type_auto] FOREIGN KEY ([compart_attach_type_auto]) REFERENCES [dbo].[COMPART_ATTACH_TYPE] ([compart_attach_type_auto])
ALTER TABLE [dbo].[LU_GET_COMPART] ADD CONSTRAINT [FK_dbo.LU_GET_COMPART_dbo.LU_GET_COMPART_TYPE_comparttype_auto] FOREIGN KEY ([comparttype_auto]) REFERENCES [dbo].[LU_GET_COMPART_TYPE] ([comparttype_auto])
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201709180011248_AutomaticMigration', N'DAL.GETMigrations.Configuration',  0x1F8B0800000000000400ECBDDD92E3B8D12878BF11FB0E1D73B9F11D7757DBE3633BC67B425DA5EED637F5674935E3B9625014AB4437456AF853D5755E6D2FF691F615162025910412402608526ABB63227A540432F1974864261299FFDFFFF3FFFEF4BFBE6EE337CF61964769F2F71F2EFEF0EE87376112A4EB2879FAFB0F65F1F83FFEF2C3FFFABFFFCFFFE3A7E97AFBF5CD2F877A7FE4F5186492FFFD874D51ECFEF6F66D1E6CC2AD9FFF611B05599AA78FC51F8274FBD65FA76FDFBF7BF7D7B717176F4386E20786EBCD9B9FE6655244DBB0FA83FD79992641B82B4A3FBE49D7619CEFBFB3924585F5CDADBF0DF39D1F847FFFE16A72FDC39B491CF9ACE945183FFEF0C64F92B4F00BD6B1BF3DE4E1A2C8D2E469B1631FFC78F9BA0B59BD473FCEC37D87FFD654C7F6FDDD7BDEF7B70DE0015550E645BA2522BCF8E37E32DE8AE05653FAC371B2D8744DD9B416AF7CD4D594FDFD87491084797E1D3E87D55CFCF0466CF36F9771C64BAA89FD8350FDBFDEB08FFF755C76461DFCBFFF7A7359C64599857F4FC2B2C8FCF8BFDEDC97AB380A7E0E5F97E99730F97B52C671BB5FAC67ACACF3817DBACFD25D9815AFF3F011EE6D3E5BFFF0E66D17CF5B11D1118D06473DC05952FCF1FD0F6F6E59E7FC551C1EC9A235198B22CDC24F6112667E11AEEFFDA20833B6AAB375584DACD41BA16DFEEFA13546876C0FFDF0E6C6FF7A1D264FC5E6EF3FB09F3FBCF9187D0DD7872FFB1E3C2411DB720CA8C8CA506AE4D67F8E9EAAFE09CD316ACFEAE1DEF8BBFC8737F330AEAAE59B68576F0E71413D11E463966EE7692CCF9B50D35BA46516F0C1A5A8EA4B3F7B0A8BEE507E7ADB90A79668C54EEA69B65B7B6C92EDB46E43AF1282B188B5640D7B7E59A4AD26FFFC27A0493D9AABD08FD9643392933AAF07AC5715EE830132CB1FE950E1EF65B4DBF2B959D381057237AF13760F4B0C7AC84D7CD895C84D7CD8F3D8B15CCE171FC101F0024DAF8162A9AB501D72FF1E16CBBB9BE91CEEE3BE50D74FB88ADC57453D6A7F9BAD05F6B829D6F4595949EAB5BA26B5DFD37F3CCCEE6FA6B74BB0DBC7524DAF5575A44E2B2B52FBFCB060EBB59C7CB89E829D6E8A35BD565692BAADAE09F51B7D70D61B507F5CF23A631F922D864D3D1E55BC7EC083517730110FC7200B7917BC35FBF780E98AFD5E465B342C3FA73542E58FEF0C3225AAA35BA6F13D46963D3D028FD2D53C2A422FD14BDA3FBE3335054ADA504B799185D5D655B5F547D76DBD1FA9B17255662B4D5B17EEDADAA579C14134ADBD77471C79D122621B3A448F2B48CBA4C85E876E6B9745695671AEBA9D0F293B45FCC404B6CAFC24D8886C0C2199E7DEBFD2553540B2A0DC9E167ACB9B345E7B59B84BB3C2E326A2D8DBF9D19A38EC0A49943CA75110327EF69AB7BA70F167E300824DB82E634645FE76C7FEF7252A88ED175C94260FBD16BFC88A8528E2D687C687572E5674909997EE236B6AB25E674C1419D1885109F693F974A2D61C78A957CB3682D2702C81F585A6D84695F196BFDDC3D2E0B1B4422EEB324D11DCAF5639594EAD8E589D8E056A5692FDA629814C354649B902E77A8E5749E06A9959A8282DA3B2122C3383356DE6D06037B3D0589533ECCA2CD6DA296611BFAA781A399FB1A05EC27E033F96C4CF9BD48A2648D984C8AC77AC5D3B73949D05CC0F8AE839944E336BDB95DEDE83E1DAE09E9199BAFD76A9593862BBF08A27D92E2D69C16ABBA8A48D01B74BD5A45103B312E7B5B4A661D5B8C3182437E0B0B6BBB56859900C3716C79A63535CCBE64F2536F47581DB1B8A46FAEF416444BECCDB3590B75937B63D12F2FC4537E4A11A8E12BE364C05D9EEC8078478D1B2F5A3D8C5100C53B54993B096160CA6851FDD359794DB95D6C6E5C68CF1E87F1D6F64BCB191C6B54D57513C8215A8B2A35DF43210121AD219EC5C356432D6A1655403958F66A8EB6BA3C3D9DFFBDBE7B0D316F1138F6EF689FDE4A9F49FBA22DC87D782CEC10BC6BAF941CBE406AF4C229DC9FAC2C9DC9619535F02D0CA47ECFA4B183D6D8A517A1D57C0A3345531F0311A7A4EE3723BCEA2EFB8751043614EB6552594B0268BE668B2154A9EA3F0C50912BAFEEC460B170FED28CB0B2F4E9FA2A42FAAD83F60EA754FF9FD8ED35D57B35DE1ED186EEAD5C3F4D98F2716301F2C602E2D60FE498459DC2C88106CDAD2220C1851F5DD1641BADDF9894E7670A4C8D45B8F11581987ADCBAE4A063075314EB3CA4B583201212EBAC264ED3DF2DB1CD20457601D158F02B8F1B37590EEA83799FE8BFFCAAF75B3C26AF356E0BC792BE0A2F0834D5F6AAA763353E77651987797984A96D66E9365160352A661D1D2BCFFF1B24A99589A0AF7C198D6B76CAC5EB0612272E855969134A35E064709633BD17A7FBE55FA00A5075DF09A028B684B26A2EA8C3D0C613F242A8E233893BAB3D71DC4E20C97C38BFA3E8A7CDBE0B399AB4E6A2FC83D3FE8CE22761D6AFB525A6C00610EA5C5D195AB7558303E25702B0CD597DBADCF1AB4067CCAD27247E3E45BEE9AAC3F6C9CB8AD94F98E71C2FEC723772E61683C7FBD0544503DEC2C9F1E9CB1A76BC0BF82D8956DBAF2E22808937C70AF1FDED43A7CE69E255ACBB4A59784A8D2677EF0C52BD3EDE00267F8BBB709FDB890CF39835FFCE24FEFDE79F78BC5DC9B3C2CEF683EF50DECF4E6FEF64E4BFCC220EBD9234D66E017FA35736472F20BE9AC1A72D94AB60BB3C0CFB2C86F8E14E4EADD1FCC56FCB6C3FB47996A4D72CE3D7FEE6EEEBD59F2CCB800170E6609E34C817755F16CF8AAAFE5366D00069DB2B530D2E5201A90EA40C3B1DDDD729FF5EBD9C72966A0EDDACA9135954C4369D5A4F6BD7924605CA14E55B0D7AD1ABA2EB7AB51FBDBBC0F983C5CCD96DEE7D96279F79BA9EB2A2870147065DD801410F663C3D09158DB3016131D0935C94E64978BDF16CBE90DAAEB4265F8C145BB8EAEE3DD8AC33ABFED5B0461E051403E6EBAC140F55D8CE9C266501784515D5087756137AEABE9E47A3A5F7CD62D5353C76B3B710863016BC15E8A70D501DC147B3E4BD22D814BC745FD596DF0CED2018FED3F63F3C057F2C21ED06326FC9DDFCB78E6260DE6E7D05F57D2DF7E19C220DAFA4C11BECFD8AF7DA488BFFCF06611F81CA5510D67A270E2B10F4C432B5A426A5FB4E1B31F9B1C24C44B2F416FC05DAC3261DA233E6E6664CAFEBAB23037828EFBD62E9A9FA6B7D3F9E49AB150EFE176063FC814EAE0456B12A0C42969D054E6B99C4F2E7FF6967777D7E0989B62FC70B130D248D180C33D5A75AF2E699EB4D207893E4A247AD61F1E42F5B18F8B3D3BB673B8EC008F7880D80749A86ECC3200D4C225648F2B4F06B7A1F03B212F4AF2C28FE3C62C8A65D7F9B6F4B861A986274D57F8BBD7037AEB7FF5B270554671FBB0E0D77E64CFCF7CE74545B8958C475688B89DFFD98F853E21205B664E14D0A8BE037D9C1CC6751DE8E5E5B0DF755EA2B70422EE22D09BBC7AAD5BF6BC13E57818B7FCBD65E0FD54F2DF765CC75B877930C252F95F2C1E8A6E7988343AD89E57B0A525EDB2035890E68557FD245FDF7551848FEC80F21E9928C04E5CAD2AF0D7A32A6064869D26FC47C682066D6197A52B7F15C5EC4065ED04ECC875A5D3749AD946499AF1E7D07E94F1369F2B84833455268777CFEB815B62304119FBADDBEBBE4BB34B05EE6138B1A34663C4D47FF6B388B3108F3307EACD757D6BCE493EF073F243F2EAFAEF9DC7F5E7E364A54C34455E1C32366D0FFBDE0696893471B1B6156982CD973BB25B1103AA150C2EFE2E79DF5B960B3C8E79B88BFD807A8156017664303CE0C728F1938007A9B4EEF4AF7E96F909392E84623F5E0CC22B1BFCEFDDE1AFD66A407E52DD8A5AA9409B2F13EEDFCBFAF3D16ED3D78F823D58FB43C4EE604C2A4D3886DA3FBFF098305E3AB3B9D5CC6155AE99EEEFC5D16348EBDCB6242A94CDF4F5ED79ED5FE995415EAE2CC29ABCE64C43F2AE975768E6E6F0DE7B240B9D781D6067DFC34EC375453D88D1D615D583E2E5C6BE5795C85D7CA8C63C99C386D3A6D893EC524D77D5B5241B9AA6AA9DFD7376BBB89F5E2E6777B7DED5743999C1C650A95B2A58F51A28408CCBA282EB77DF74E08135E518EE97DA95BFDF2709ACEA30397D6F94269578D6178BD5DD08D813F866868EAAF4E36BF91424E2594685F651AC6BC7AB49BDD596939FA7B7B5F3C91C7689812A6A1C9210D5E510B408182AEFB3B9F4421D32A62BACCE4934CC250ED515CC704D63986534CB8549CA106C1E80199B016FA2BC9265220B46DC861D8B21FB15F7C2077D31DDA07305013614532DA71DD1DEEAC2A791F52D83ADBAF0A147BADDA2AFE60C88AA770D8E22B1BBBC7E33DC03DA62E3175E8E3AC60D4D3D515593EF84FAABE73DBD6E5EBA185414815252399CCC941C7A270F201648E92508A284437F59B059B5E72CA23A6E643DBD696B2DEA805915B552AAE5C1A7B6E8F1628250F8BB18C1FAAAB4F81594210D6B28A9A5A85594A0DC7B4583ED2AFDA3CDB5710333FB4CA305C5E3C32F8C6EDEA9FC5D3717D8D96172BEEBE600AA4598457E7CC34387CCBBDEAC76C2C27FA6AEDFEFE843E9FA8AE3927CA81B728D88FA7DB744935764609DDEE6598E46A747CC269E5537536B60D3878A27F0AF14B4140B274B929EE38E7DE715836ABC71460C6FC974D753B45B395545BBA2E559329C53279BDD67A6483D661DAF42845BE5B6F09D68D05B3FFB1216F49017A12FC5D7C2C0A53B6F93E5FC95054F7940BA9565A0EB88FB003553856C316B87B1182EE18B75DC17DB902F7BB7DCAA619A061E66556C80E0358843A595CE40BA6C2DFC8421B1EB41DD7536721258BB512AECDED120A75EEED760879649B095B564FF4AC96A85B983AB2ECBC58F8E2C857B8701FA3AA2F35E19262A0DFC5118EE8E091A1B3F0FBD9A119128BE0DCBC9C10ED8860C8EC0464F1382FFD03ADC65ADBE2023D53029A4D8A4FAD0CF2E16AA0C4C4FE64EEE30FF3D2A20DC5A25AC0AFEF276C249163E3991000DFDCDB2346B531BCAE3FC310E43F06EC540D7BBEA218F1FF04CE2449FBBAB0F0B0F218FBBD9196BDF8B92202EDB1ED6D8107AD5D2D343FDD5C142D9A2F788A1D70F9AFD8E5249ACC63C3F78F2C2AFBB4879516370572CB355CAAF556C1C2993224B632F7F95261C01CC4E8A64ED675E3D6E122C3B749864C4051B1E3190AA3F24A957F5DC0F0AEF91BB9F7AF5B6106410BC9C24A2CBF7C26D75CB24498BE6E199318AC292154E5B09BE7670B57B9953C3725660E1389C7B357B2743AE6B877BFA5095B34655006444D662AF1255FF3E1DF6410B139AF7F90977D0A747CF0C591FD63C2020D3ADBD28FF9C96991C4F9386E34AD0972CD1FCFCAB8BCE5CEEF95C4F341FCB30FE5066E4E390912B43E521C255F0A405584F718E96BF621900F551CD1E12F7887DA7DA8CBEBC5456AA017AB7C73CD0D81F19817A2B46A1C3221FA8F7B534126663E1A652C5E1A5CA40FBF9807EC8CD77686338023FB43028291E1A199262EA38A30C2BCFA64017B2EAA8A1ED107AC4B0A30B36A4C92F9FAE3E789D13B0EFB01AB4E209ED0E333BB4EF1EE60BF788C503D81DE6CB3D25B9C2CCE4BA5A9CE34D2C8826E70EB095E1B9DBFCCD83E08568D9053296FA7DB61747C917A61E47C023437266930661B4ADF26FA3F46D93DFC1F5DD27C3C57CBB22743DDF944BBE4A6025AACFD5A7E9127E74D760AFAB409DE3259A6E55C5CEDEC5A19D19D41DB27D057773B384F373EFCB1A7E9C0B4FDF8452E8C99B5885EA6C7133F91976B3E0058A9E094552B7C4F2417C159B75D13928AA6B6916DA852B62E54D0CEF0DBE6AF57BDA45B9F25A8E22DDB507AA800400D5B372B9B14E4B0E0E415F1397A0BCC780CCE13F1BE4EAE89FAA3A1AE27119FBB3CDDE51CF8158CDB1DD88F68F6AEC3C883AC063390FB97D9EB11F02F7CFD15F890FE2167468DD85D7E72E4B59E56D9EC6CFE4EC28753F5C5E04BFECC37304B11FC9D1D530573DA4BB12B6B3CA476FFF0ACAE0DCE0244959186D99229A879EBF75376769F625CD98C2A0BD89739383F4FB1DF59019DBB19EB9040540EDA50B680956C71593D8CD314547F7737D0A6D83883EC957E9A0BB80BBA389698FF555FAF80EA6AC69C6FCC3C4C27BC0ED81CAF85E5236C988902CDF321C20831A21ADCD3EE40DD9C9EF3B8B75DED53AF452F285678D6E3DF924C90AAB32E0DEC92FD1BA49F9D437C2D28A3BD2856BD6AB6213055F12A63FB8421DAEBC555A30A63C086A1E11D03DE2A02C0A7E1932CC8C6C879B11869AEDBCCC3DE236D119B29AB911F0008A1CA5DDA4DC9278781E3ED54FDAAB465D4DF78E47C5CBBB7B1CE7525B03767B4381942807370B6C397636FDDD035AF4770F69D7DF47EEA758BCCA3EFE885B8072EB71F0C1CF8ADA636F13464F1B6791F4AA3CBE4E313260B6479F4A317A3342D22CCA9DB769DFE311C31D60B514C31D805A33E95C11102E25BCD9CDFDF5B442613023F3CA6A80764823753D20509BA632D598DC20994F2757B3DB4F1EFBAD7887DA6D54A8DF1D8CA21A381655DD5EC64DF5AC1B5548106E6CBD323A06CEB5542F2504A369994DC34E0C87583DD92039F1E7E6A2BF841DAAF499CD4C1C7BA6874AEF7FFCF3308F3523F6DB0B93E7284B93765825BBE170B39EE7B399E939C17EB08912F1690DD5E0DCBB1BDC7B316A3FABB243F318FB72D0677208AF4EAE0D8B5EF48EA3641BBE4A77FA0D77D0C931FC10A722E5DC6EA21421CE6DB0553516D5F98700369C8A180C16AE15700BB39BC927F8CA5EDB291D2EE4CCA851D0E64783A7B744012FBD59A280E0BE4B145889824B004DF07417B240F590BF7D74826AD29F8F6AD28F2739403245E203E7C117D192CAB8925F736940243DF3D278D153C26852BE881EFC8476A7588E78404127B3DD1147998DBB0F8BE9FC9749053F9F2E1EAE970BE564808D2A9174E782020B9E452404BD0F217044E63308001BFB08CAC29C61CE2DCF9F2EF409D4D9FEAC275DF1302435FD3A40E7059B30F862C1C5DC49C9A3ED3B8805596D5C5B0EA4978CA1161518BA93800604390F1EDA464368615173DE7625ECCA6360C0154701F6753381168DC65F2BA0D105FCCA546F29DBB760C7E2AC147E8E66ABDE6E93B65E0247899FBDE2A2380E25998CC0190C3B05C9575C6C17AA2432BA08029CC0D4BD423EC4DD6D9956D31A75EEE2FD5F06313CB7B759CCC3D2F5DFB9DCB3F799AEE10EB139DD1E5E86C3DA7CEA39BDF5C29F626AE8EFC7D9888AC2CECFFCFACA8A7B31F4C3D5EAD82887A31B23C6B01665924103619926CD4F83E47E329FDC4C97D3B99A4381B5A9336481039E221B44BDE50BC5842198190438361F13B7329597D158813B7ED6B46B787DC42F145D481BCE2FAB4EB573C0EBAA3E5BD092BB5C32396339B9D5883F9A5E8168D093034053A70542D15F38028745E22447B8B11949907247FFC4DA7E2AC28FCF489CC93263B124C9F326DFC5FEAB57BD82737AEFE34A2470BF6B8962806EE35BED5AA5C3A17ED32AC0C657620E579887004C756A335BB54687ED5B75F06B5DF3F67477727B1B3B940FAC5EF780FD65ADB6CE313A887EABECAB8DBD353AE91CA83B81900BC21DE1AB5E0152DD4FD809143BC003BD6FB0F2B9AC7245408F33CD0F2DFC9D1416D5FCC2CD452A066DE461AA83CCF79790CEBB1AE49E7A8F6299F0E4FEFE7A7639511A905AE5DE91D9B51261C9C572E22BA08E75A22B75441E5220265151D2C46AC276511F880998BBF677380493ED6CDDDC5D4DAFE1BEF012B033ED02B9379D52723828654E4E9E1D13E84CFBBB9C5FB35DD82F6D779BF60DE1799AAAA3C7E739F27FEA09AE3839864CD0BDDB39798D4F3D5F773B83B6FAFEC71F076999F1606096290C58175FCE82F94A194D350CDA6AD3D46C4EBF5B789DD165DD4672244BBA58A1D3AD9C7B8A9DC2DB3546BA1AC6B0B3CABD1122757C1734871134ADA2B3047EEFD0AC77512CA1D0435C1E9E3150C3FB3FF048BD01D3D522BFC9EB87845DBE66549039392ADAE7D775E6978C5912E13EA4EB571388ADE44D88322A1E4DAA28A42E4E4E94CC0D764877486A85DC2AE62877979DCC97DEF49FB06DAB6A02A82AF450AA01F755AED6EB6807FAA53FE72580B10FFD43CE99ED8E077A08BFDA060A53E1D1BFE874270EEC5B76947AD52A7B0FE30B16A99E56E5BA0EC82465063734D799F097344B78D4FDC0ABD300F694A7F704A9B2141CE855BB0D75F5A028BEEACA6E033ADBF00ED0B6D0BFA35D0CBFDECD6FBDCBC9F5A577335D7EBEBB82157E2D887E705458D9704045603721CBBB3BD8F6D21463060AD7530C4A51B9EFD5C67123196F37F635C7BFAFEFF24DFA7D3D85EF0EC0EF75268B61F4B07DD3E32B80F996E911423E4C4480C75AD3C93A9083852E23E7EECDD2A76611EB6C3FC469B90E1FA9093BD9FA81B13A11FDDD43EA3CDBDDA88C9B285EA7BBA273DD8C08E2CCF844B48BA9AAD423EFAFBF4D4B29500BF65A9C9EB130252B7C4F595AEEF43610E3E41759699CFBF02BF71D08D71DA9CC10A4EC1D1AA931443801E99E1739BA65ADB025AF89BFD5310A4791E5CAED2EF0777E50317BBD79DD24AE7FF5B270554671D10F511AC5B9CF099A674EE58F48E2DEF882CD932364DCA1C58B8A906AF2A8E1E02E20205BE12E5140DFAD87EEBBBA4A5FE2BD579FE8D4675E90464FF4B2F4C5163428B805939151CB39121AAF8BE10ACDE6E56A8C560F9A340F98A63D5FDC243FC821F74C836875305E1E228D78F9EB76C7B40A5D7CB70B37DDAD04CF7A82E822539A57C1CE6CC42D3F8ED3176F5DEED8B05BFB149F0483A7895D7B4A2DC52CA640B97B890695CBCFB3EB2B6F3EBDDE5F22CE1646CB0A0802DA56809A906F86AE3AD5507BB4D4709D59FDBCA1DD2A00018F46AAA81D8C5C9BFE1AE1763A9F5C7BD37F780FB733E3BA48D5C15108B5744310AB5A98F00FA8F83FB03F76AB925C1F1C81584D3704A96E8F31281D5D843A5EDBB602DB1CBBB5B41647A12AD56AC5400F813E2AF0870FA87128C1542B02D5362C0C08425D1F065D3BFD1218180C038E0CAAAA1B16587F98CB2627B66ECD5070D74F4413F2F5EC863192CB097148222C62745D10FC40053867639E2D6FACC75CC1D2C6CC40ACC6CCE17A5D332A7682C9CAAC001BDBE43C9323B31BCDCC33E39B0977A6E5FBCAC477598B8C52C306D7096EB553815ABFF36863ADA3240ECB7C3567A59659A30F94F60C6306D44F1CD60C47273DF7DA9A6D4917B72B1B88EF1B52F647B2D94FE2B1C194C6DE38A222D6990794B12948F6E7198F0C72E517C730E33DA260887359DBD8AE5C3C49A9BAB9D4DB662C27C48173421F9D53C731D41A2A5A7E618468BADFD6F75E5B5177C38DEC3DD1E1A9BEB0C7783AF19AA3BB38B1E9B6F56A6A40FB32BBDB34315B3E79738E6E5FA8EFF478D3861B62BBBB35AD19C99B25CFEC1048B357F68B1B35BDABB0F0A318769514085903ACDC2A4A18499247030E643E73C40C0CC3EA693EC3A9D14EFC76340339811AAD6C5DAD462341F0031D5B8DC6744450A39120566356A9D1E631B702405C4D979399CEDB4CAAEBB5CF3C71A4BADA8A73590BE2E070561126C531B90B7B5A1FE5CAD5358EB651E105BE1B776510E5E89E6C2E5EDB57C3527A2213B16D222F4A1EE33A8CC67D1A193251346E2B7F4460CE63F6E5C221C2CAC7210877854BA4552FDF0FD14B6748B783ADD2D6F52A6D8758A5ADEB55DA0EB14AFEFA5F8CDF7A3CA3AC2B94D5A847F6F1EF7F4980F6FC57484543BB92F797DFD00EE68811F63FEB2B81CCF2AC67B06773D647C5D6F559DFA0FC7ED6D7897ED78CE56DBC247C71C5A35E7822F01AEBC53B6FC799AABBF3A985FCFD90C8FF3824F23F0D89FCC72191FF7948E4FF7348E47F1912F95F87447EF16E50EC83EED10B079B744881C6D203C046A0699B3C4614682C8D3336028D6A84448106B0D460641909EC84792CD79599B87F3ACB0E9EB10416A7F9026A89A54C22DCE370C48505D99F58C8AD6DE03F5679AA9303936BC5C070DE0E4FDB6CBCAE116E6BEADB19E2733EB685738FAD7E5E668FAD349FD8B77DFFAA9F3C556848B03C82401FF82CE4CF15B8E3B65DDB7DE0F7B94C756EF97F32BAE563FC04046AE3272C9EE2D07B7513E5D5B517D975FEE172F19A17E1B6E3740180F572CE961CA855E7463BEE2D0A0488818B83A39EEC951F85EEC6536EE20062BE7FA86B2A2E5894D56D22C9A4EB320EBD45B95206983CD6C0AC120A0092BE1050D4155ACCAE7497B4400315807975783DF4DA5495FBDE78E18681581F2C8CF9DACBD52AA1246487F779D87503AE00DD88C4D59DBD313584026C742FC32B0B2FC32B9390E84ED4FDF4D0B4F6A98C649F4892688E719F110432CC895FE70C5B0FE21A58E336276277E4E3789CBEDA8FC6E4683DE8953EF938C55EE50BA7AFD5B617CE56739CFC63E5B1B7F8BEE59C9DBC76EAAE8460ACCDBF08B3C88F13DDF6353ADED5544F54E4F623DE75C2A0A0B48CC5CD03491ABF24D667F83DBFE06F8D0B3F8E49A0D7CB2B5BD0BD7FF28757D25C68BD9A0DC3640454D2F4BB1AC4A6313631A4D9087F2FA3DD160C558308B092E58F742828F81D020A4A176106E30FFBAD1AABA22FD8ACC0019648608CBE727D3A5B270A3D0F3EA0331BBC77D24A5E69E51EDFA54C78C9C26DDA0D0D42A04B6FBFD519BFF5834D5B7040E1D973888A857B397D27D623E100D3A4DCCE9275F8D5D59BAB6358558436DBAAABD25F8F55C0C409503DB20A5EC52A32F6B5AEA6EA262F35F4B0AA32A4DFE5409602FDA84CCAAB95E4569BBFEA19D78B6D4DCD6FEEF1D7D092196C42248A59934AD3E88BE5210F33373D71F2FE8AA12AFDF85A8E1C7B1E8FDAD41973F6669FC9CFD35BEFF36CB1BCE379C9A0EC0D4045EFE172F1DB6239BDF1AE671F3B3636736D39B18E19C4221804C9128AE0C77A1B678765637BF9B098CED9B03F5CC366CDA6583DDDAA3A52779515FBA55C14EC074CC98ED6463E0B438DCE73C55E58316108C918AFD4EA79762365B930DE906CED58C34DC730DF733417E070605254092217ED11124125D1870AEFD46A4D35579FD075A3B7CFC6B8CE1A066B01D5C5E0ABBF8D1227E10DEDF22747AE72B7E6DB9276FFCFD4E1117C2B4CCABEAB5083F5557EEE3F79712B5272DFC8B30DD62C7ADA0C80967756B0090C16615318CC58CDAEB357EF5FFCC54EEE74695A689DAECD234F915EE5F670D9DB06ABD3CEE6BB2C0DBE84C5A874746C7454328AB63B3F10631F1B9E23AD323F8F9E4312D0368D727EE4928058D7BEB43CEE70BDE3513F3983FF35F469D16ECBC0C0B8DDCC78DD8CAB8C892633FE371251394893C728DBDA76F5083D4A67633F2FEA677E3BABEEB6E147E9F0DEE3D37439FFDE2C3460AE08E234A844D25E371EB833B06698FDAE5E919B9631BD64F8048A2F2DA65527B430CC7541BBF8FDEF74954745E85D3262305C16B920852C8C433FB7DCD547E0D5EBF0A4D4D21B102EB86EDC587E2F99146F93199E871A609A5FE254966AA1752A4CD546EBCFB523B0B53B6F8D65E933ED7C8F0A6FF595AD0806C3AFEC6588B1FD4A50D669D6C1A1B56EF734E351D79206A1A96A67BC9A909D442752FFB515CD5E939DDAA3067871E9F58A1CA6E31BC7EE92600C6D939318D9FC3E0636FF14C635A72FA1F62360CC989D533C478159D67272421E1B349DC86E24A17673CDF8B0B203D3A5D98C6EBD3C8D9FC32645182EF5C3B89A4F0F15ED9CF3D0A0CE8AFA04D530D809C4D66B1891AF2AAB2AD8A9BAFE98CF24A82720F241C4447D8E5B9D078749C79F0A35C489CE8682CB89FD4E88368AB1CE09C2E18442548F01E29E7DF03961FE7D3A60B09DB93AF0FC833A6848B9F7D7A32E8470AB3D577B5C5FD1DE09A386999B99B1DB3E8D10B2D960F3ECD6F54F946DB7F29C6D25D3A2B237059AB1589CCB284689AF8D766C36D2A0D94073D9711421ADDD56F0D1466CF32D69A28A287333F5DD4275F621F40EE2D54FB4815AEF062CF70EF4F2609C6DC35B76923FD82E6D356FDE852996EA8341CF77C81F451555FC07F2C6D5A949F6EF4DAC8EFC1E19922D7339F37CB809CD1CBD03B2701B6EED2D13466FA384DA39C607B761CEB849FBEA0B9B01B27EEA224C3D228DED31DFA58A5118DA15324F7A762F9DDA7DC83769567C09F5F7286EE54642502DAB9C7CBAE4598AF47DB6671C9C69CF78D64160639F796CDC4732B27F5A0B63E96C896F44642CC2B0D87879F4BF87F7F34862ADD64888A7F3E20C133BC222ADDFE07F5C7EEC3D718DA85093E47F07493EF5DA80362F680FB36127ACDFE5E4FAD2BB992E3FDF5D59C4136E419F414461B6D3026FCBB848BAB6E4A628A4633CC63074C4957ADDF381072E418C8A62304963F0B08AAB0402825EB2C8CDDDD5D418C5B2AA34F64669BFE1A7EE07F0FDFFC0FA74D5A656931E266447D5AEC17E3D4CCB451513B19B8B1EA3AC3DADECE0FCAF71D8D2D630207AEB38D56431E625EE3724F034CF1598AE1F6DCB2D49376D414709193ACAEF1797548B44C51DB8C46EA5892B998B01D2A75A0BEA86765914F0C09F71F82C376BEE70F50ACBCBC2272F4AD68CCBCB9133CD386E78476ED3A2DFD98DF15F3CC4E8BC34DD90E93414ED63E89BE5043CF3AB33CE3BD6680EF44E81745A774BFB394B216C00A750F87B58B74F60D636DAB387CA58C9DAEB7B0A5B5AD2CFF606F8DB3DD2189BB7B3B4AEE254326621A162CE3CE8B0EBF0D1673BDFEB3E2BA53842EBD8E2C1F02972C5F67759856917F6E28955B086CBF9E2A377F9B058D6E1884C3C1282199B67D6373B791E3DD9FA0CC9183A6B3B200755DD4A51D952B5486E5059858EEB15ADAE96B6DAB7931875E34B18EEBC97A8D87855E37479EF5BE18FD42B4C75F661B64FD5315F845DECD5B585A02F50258925A96B92F32533F8BB9BE91CECF5A1D0831957D3736D45C9C0AAAFEDF65108D80418524E5F13B704F601E60831830C6B61A8AA8D20E4623D1A7C706816437B1784B15C500773D1CF72DF6C16FD997DA837BA034FF790227BEF50CE3887D797AC59AD8E630ECC69A96AF0A4A106233E3697884DD3799185A1EE66CD4DDCD3BAAD725566ABFE46554453BB342F0C8102DEBB516BEA49F4B5961C77E30AB83F4ED6CBB71B3F879BEA7A6A8496B6E92AD20628BC70136881B7F5E87F1D654C3CBD50DC6B5FA1630CF573B3C78EE8C8953D9E3889EEE594BC1AD8DC8F6E66E4BBF16600E34DB573D26C6B38239DC48B587988D3D821EFE607E0FBC14F404B0F75A8CB8C59C6FCFE62CCB3BBDBE6F0D3D56D743CC1E1D0E4B8024433BB63091287164712280ECDF9EB7516E679DF6DB0CBA2AD9FBD7AB19F3C95AD348C188B521E0669B2B6028D72CF0FAA19F376FEAB85B732F73AD6283806039ABF4A93F895DA644B6CB4B8620568858E653F591ED3C9B6B4F8FF71FA949AD423B46A66387722C6DBA2A0203B51B0457DC9BD32B3488FB12AF32861FBC1ABDDD8B512B08B6D1805DC83EC4BE7A906928E182817E3984A9054A24018F83995FC85E17A7A677797F17BD8E206EDA70CD00DF88F78175DF6E723D358A4EC657AA8C5267D89A36D54F4E67F79C838584B93C13E96E0601DC58402B8F1B37590EEA80CE87EBFF997AFDA77494EE8FB324D0A26688DD256C5CCBCE9D7200CD7CD0BA69E843559FCE9DD3BEF689C9E3C2CEF48241625CF6914709FAE115C4B38733E1283B32C7557219BAA8C1B6BCDF1CE0DD470483505A67530507CB9622BB88DF290745E3DB21E4EBA32CE08F9169A2903ADDD4DF191B23AA9F0A072C9AA0D56B2B2CB4BF706C3DDFA881726B83B22F46818594D8280ADF58DBF83D3FB360D0A75A11174AA68FADEADD7CB1BA04D39FAFB84A6E6D8370A5D8640BD50A0B01377F709B77A91D50DFFBD7B493A2F6E317E00C64B58988EAD588848C15A3EE3FE92B269AED355B886EE16AF5D8DCCF1CC3CA2352D6A2EA1ACA49B65979CA21BD903E35829029C2ACC90BDB3A58CA12FFFC0BCF8F10F3987F3208B76E304E96D071C29F4C2B3ADBADD3F5B9444511E0CAA8A65A38230C41E5382F5DA4F8D9BC6E4E16AB6AC91FE66DA5430D4D83BAB72C59A94EBC836BE8D8460AC7B7EB719549CBC8171E41CF81885F1099CB45721B7055D6EFCE449C734868A3AE23FB2F51FAF750752896ADF83020A5C5927AB28207AB91C55E8AFA693EBE97CF119E92DDC54FFE6F25D0EAC1A38DAEFEB46CCB388B8D08B909BB5F5DAD5050A066BC12E8C70D55EC7EBE4FEFE7A7639A94EEDE97C7E37F7AEEF3E992817041A3D3D9905FD4623E66BB5F156D8F94FA1F916C74D1A8D2C4BF50E116EDAC90B3FF8C25F5AEA06F517ABC6AC88BC8A1871FB714622F223D0D844FEEC6711A7CFFA0A884AEE5DE8B1459E673F2E4D4DE3C39B92D93E522B1C92EE0EB11226CBE5E4F2B3F771763D5D2CE7D3C98DD129590578A23083FBB4F6FD220D76918CC5869FCA86E97FAA7EDB850BB479CAA3899C66062ED2D4E6AD7777AE5526193BD1CB70A2544E0F7629AF46CAE654CF4A65BD311CB38EEC454D83EE2F00F589180C82469A476DDE0803A98DE05DFE549B39A16B1DB99EA7618AADCB1E0AA0FC688904DDEF9909341324E67EC2E8B10097E8C9DB47360143AD1B36F6F0919E34047EBA2D22DD925A6D304B0BAEF7707B30B1CC11A6DB4EF513D86C93A8F036755E2E7BBBAD8C642C89679BAE4B26F3EFFBD0DF8252E3EBA8CE60904C4B310A9123AECF73EAC6198F511C53AF8F5737F460342D04564F111AF0F07773D004013A0B576514AFBB3183CD7D664242E1C7B15587EB5E32E6EAEDB1D026DEF383A2F42DBC3DCDE2A0AB27303E9374E9F4F82D3D48F9661EF9349B83EF58F2F6E86EAEEB25CDE3B4611275A66A2FA265225DA74159A5D9F4FC64ED455BD6159DFFB6CDE56775B16ACCEB21019CE4CAB38EF2DE27B39D02CDE8D79FFBCC74E13E339D17B313DDC1914A1814D207A2F0A378F824AF87E62CB8C9000988B88BBED7F1D11FCA87F9C5CF323F295EBD20F6A3AD3E47B3A3775D8E982FA52D27D7F4E7713862867D95BE306660786A4B6E07CDDB3F4D6FA7F3C9B547548F14602752937AA94767E5D2D2437BB1D38472DDC5841BA18A6FC183ECDE7A7A81DC8C3D647F9E7965AFB0F4D31AB98DD38B5A4FBE6C5F02D588124632CF7E2CF4090159A65B12D0B79775F5FC9FF21F8C7DFD4339A0B7E95E1DE8BE72B4D8EE1EE377BF7B3D2FA27AAAE3FBD9AB2E464750E7BED829D636F18D2D4D2307302E927AD54FF263CF2E8ACAC5CF7B6492383B715D09B99D262A37BE415BD865E9CA5F45313B50593B41D1F888F44DD7D269661B2569C68E889D1F65BCCDE70AE1204D95491E6C426EC25C0FDC12CF3751C67EA17FE548599A5D2AF01EC3891D35811830F58FFE219C391049BF3E746C5F38D7A1D7DF55793A8E939532D1D4D8E71A9231797BD8F736B08CFBC6C5DA9AFB6EBEDC915F1333A0D9F18E77C9FB5E316B2A8E79B88B5BEE5714C08E048707FC18257E12447E6CDFE95FF71A771F86DCECC78B41786583FFBD3BFCD55A0DC84FAA6B7F2B1568F365C263F3B0FE7CB4DBF44CFEA8EDB390F687736DA98DB4419955982A0F3357ACBC660EAB72CD13C4C5D16348EB1CD15E6D7832A5074ED50AB4ADCB084680EC911801BEA22C0320019FD8138241056D266F553DCD6BBBBCD74BBBDC918B05D674B227568367055FB8BED137498BCDFD15EE6EABD0C0E6E53E563E55D6CA9A75F5CB59D9C631D6E2DBA972BCC7FD4D65E92AE7061BE5D50B952F5B74A1CF05FA5E60CCC3A2DCF5EB45C6C4CF6DE8E72DB50F1B8F881D144C12F3E26A5392E6AE4AA26701C7F30639D34EF7269FC12D165C49DC324A0BF41BCDCC28A9C10B892C0FF374A1A9F96FF95E81AFC389DE2B609B36D8E5518F13DEFFF8E701DF26701A99FEC2CE4394B054D71CFD92E9B9F6A9B0BB646A038F75C9E4E8D122EC1F60716E5493E02807A1D12B0B2900BA5433C8C768C0FD05ACAEBA2D76164D4215614EE1145E9F7BBDF69D02CD583B502B2A5B6C4526C339D882B859E84B6EAD5C2968723BC29CCE53AC1F9B87D18CEF29D69FD4F2BEBACAB744ABB39BFBEB2991568F30A3BF35DFEEE2B03FAD2AD08CC91AFF4318E2EC76713FAD0D7CDE2FB3E9AFD32B0C99C950A313DAD1409B7BCF51F812AE6D494D85682C62D39B9A4F13FB673F11430B7FB3DBE5747E3F9F2EEBE0014CA0BBC1EA590AD0138882AD33CD4202449F8867A77A99D59C8BF77F1924CDD47ED69C286BFAB7C1EE48FDEEC3623AFF651F2463B6401DE622CCD8C4AD302A53A91C639B1E90DC0D97316622B53392EDDD3EDADE82965EB0352227D43EB8D97571F9797AC328F692A6D103606313BBDAAC4DA577A4817C40926F7AE0CC095B75FF3E0201AABD33FED9AF330734BF0DC6F51BBA9EDD4C3E4D695BA10239DD36E84BFC23DFBC0F183F645516053BBB0EE4D2EFF5982BD9CA8DEF364F3A627257B0B93644EF92A3A5C2BB9C2CA79F10EF7A6488D319390246AB4FF6D10F9488C6DA35C7660D2460BCCDB313E40FADF36BBE13E81187E6F34D9A152631D174C5E8D267E7FAC13B78E24CE64601AA5BFB441172225BFB0BEDC19843D23FB4ABBB581E284573DDB403964BB69BF37C71AD248494280E590772B0F4859B8C96D06D97A54FCD225A3D3CBA0E1FED3C746D62B41C20B567BB13196213C5EB745748F1680CABCDF844B46B92272327E491F7D7DFB653A2A1A6A339022DFC6CC93E5E4F595AEEBC7E938FB99B0FBF72A352B8EEB8471B2EE9DFA191126EFE8D48DDAA77D8BCCC4EFCD0CAED2EF0777E10358F1FECDECE368F708B7E88D228CE7D4ED0AA07B4747CC1E6C91132F50B610CDCE80F82CF3F10CF59C46FC029B0E94BBC8EF25DECBF76A280A016A47EEE513DCECDD2175BD0A0C8AB34EF9CD1E8C6EB62B842B379B91AA3D5915F5DE7E24A9ACFDACDEB3AF34B26F47BFB5B0F2F7FDDEE9866A1B368B8CA07947BC71894B631586DC42D3F8ED3176F5DEED8B05BFB149BA6B4F093B59FAD3DA596828847E7275FAA4CD596118A75A601827B39E837EB646993F0C5ABB2D05AF8CC93C108FEFDCAB8A35D85591D9417A8E789AA791366D45C5B0ABF8B00E91573171C28C59870CA98BB2D91D4D2A680166A9D5B1578CB4E543CFBCB1A172C9D6A5EA01F493CD04051693544CEDC11A0E84CB997F0D64367B5D4AEB986925099BF6C17194685DF4609B5738C0B6E43CEC33B1736C833B94EF54E0E4ADB48202ABE409305C027C9B4540795E1D994F7C36D6E44F1FC1AE3D813436A134E4ADB630FED34DBAE7BBA7BA4BED747237B2C1EDAC53DCF722365D676D3192D5C6DF736DA13B9EF609DB5BCD8B3A5F69B3A4AC0A25C799FEB48EA08B29781C6A6FF7D0F7868834D64EB2A0E22196B272CC22CF2E37E8F6E31F6E4C5CD0389EE2F89F5197EDB803DD7CB2B5BD0CBDA5CF7E195740EEFA1AE2C04B74B7B2D7EDA2728E6A58338ED1832995A463B09B2FCD1429605E21DA0246F39741D22C91342D842B3CC9B55ECED6961522744E17E3079C1286B6BE29C3AD8D1236694726E479D4ADD2F3B99AB046194F466C83BFCEF19C70C578703661C7365D0FE9E724C30776B80489CEE367C399E5E18EED6AE7FB2B7AE0A7F2210283F4A6188CAFC844456DD6E0B9FD28FD6318AA85D0DF5183717015007E4F4E228F9E2855FA3BCA0B370B7D9EA7307D2AF9DA5F1B08863B7DBA188BE366554DE3685643650735D9A1C638000510BD6C041F2D93A0A1BCF36C073B8F61EB38E93034674CEBE086F8C3116DAFDC5170F925D50E0D29DB7C9728F7D6232004DDB62A06BFE66ABE5C6816C31F393A711BC808A2A56B74DD2AEC4CEFABF0F2D5E354C5A743E8F7E128476D0FB6659AFAD1BA5C2EEA38752334CEDC10E2D9360633FE7A984FC35BF31B7591DEE7DA173677095AD7D6FF6A0AF639C06FE3806D3320B367E1E7AF5EEA789A02DD8758B29D3806DD6EF08EC32FFD13ADC65ADBEA046C160B661B1498777D42D038363B5237FE0EF8E75CEBB9A854F23445C0CB32CCD04B77DF37DE7631CC2614C0CD4B8AB92E1F84110EEA857B3571F161E42297043CF6BDF8B92202EDB590AF06E5D3C7721F90AF931CAAAE3E9C9B3173BFA41B3DF512A292098141E4F4CBCDE45965620FE803FE2D1D65F8338B4B45C1565B64ABDADDC7B8CE52C29B234F6F25730A0B301989D11FCE2DEABE78EE86DC685192E8B44095D5C4F52AFEAB91F14DE230F03EFD55B4B101BF0A28D882EDF2F4875B9290978E6E199318AF28D154E5B81B9F6E3B50BAB7CF0015EDBB868E45EAD089321D7FB38C6E4A12A678D2AB3CB88AC255525AAFE7D3AEC83162634FF04DC6951295F42D607C6065EB92AEB45F9E7B46C8462ECB921E0B812541C4B343FFFEAA233977B3ED713CDC7328C3F9419F94865E4CA501D74379DE4CEDF0962F31F70B43C38F800A88F9AF190B847EC3BD544F3E5A5320A0DD0BB3DE681C6FEC808D45B310A1D16F940BDAFA591301B0B37952A0E196306DACF07F4436EBE431BC311F8A1854149F1D0C89014B309FDB8D830AC3CE01F5DC89A2CFEF4EE9DD74AA5FEB0BCA3F91DB1214D7EF974F5C1EB9C807D87D5A0154F687798D9A17DF7305FB8472C1EC0EE305FEE29C9156626D7D5E21C6F6241B4127780AD6CC5DDE66F1EBC6EC055CB2E90B1B46FB0A2ED2EB5D4ECEB7B79B6CD0DCE0FEFDDD8AFFF95AEF2A830C6FE71D45AE5F4357C33BBC0EB95BC7A777C198970DCA0FA6008F9C8919E1802D419652F875D20B4D160602F8B760A6C44FDD63B766487144E164ED3AF5B3AAA0D78B34E482DEEA6416729C85D25947691C8FEDF39F9FCF754EF8A9DF33DD5BB72477DCFAC0E827DCFACFE3DB3BABAA9EF99D595F5BF6756C7C37ECFACFE3DB3FAF7CCEADF33ABAB3A47B4C00D925B9C9B2DAA2DE7357C0363EA10614E974F88F88283FA5825FCEA33C9838B79485BC7BE57B57640B560F4486F42D6A7877A93709CB0DE0A837D6E1827D937E4B47526FBB4DE97D9955657B39DDC7FF2E25624DCBE91451BAC59F4B419002DEFAC60261A4C9914063356B3EBECD5FB571AF12C702E97A685D6E9DA845FB9C4C0767DE2B4BB2DB44EBBFB98B1FF791CBBCBDE36589D7636678A63C01F0D8D49F6C74647A5FA68BB636A3FC990E2AF323F6F6596C185BA4EA3BC6859315040BBAE3AF1EF15D3364893C728DB5A1B230FD0A3743664B2B7E9E584D04E1D4483F84C9C4710E5A7FCAF61E35C875A76E3C30E37F3503763C8A1F1FE4727416EABF759D595C1CE8A44DAF0A31189375E1003C4EB2E47D10BD635631EE1F9491930E69AE8DE41B969E7A5B5BF30A64339BFAEBEFE7FEF5D1E78349E31C4EA2C8C433FB7E4A547E0953E3AA09B03B75174F65B65841C57BF976961BCA0E96577F0AEC2C2E7264FBAF9610F7A422BC4BAEA00DEAE6063C0A8B51A9A87C7D1031151B78AF1CCBE058CA2FC2789223030DC54DECBECD199C73ED60FA229C58DF1435AA1312C2E0827D3AE5593389312598CD34E4D4A03B56517126A2F9D0C2EC36EB877ADC728372FB347BFE367898A24FCAF3AF1CCA6EDA48B1BE0D7EA3ED71A3E0B79D208EEC76ED7761F78C45168E5B7883ED396F3C9E5CFDEE4F290E11C974F17861AFB24F3894751947B6B88351959BDEFCABA7DEC413FE7358D911C1D22CE06B476CD2181F40952A63E98103939EA368B579B67C4DD29F292F085044E9D23EBCB38A3CAF9275771F374371428D0B377C8FB1E7E42312F4462761953A5EDE8D34771AB8FAB43DCF75FEFE6B7DEF5EC66B6F43ECF9693CBCF33DC71A7861FFBE06B924F7157C726CB8DB78978B8C9C832F82A126D5F9D849C3DD5C1C15B0F8D0BD0607407EA315E5D1E78799CEEB09AC51FCD17B11903778B73DFCFCA16DA0EB5E2A8AF3DF1F6DFBE3FDFDD4C968B07EBEDBB873F9BEDFB858DA1C84BD7DBB78BF6FBF6ADF698D7BD01ECBB256A9CF5C670BC7DBFB319C7780FF35A45A5E8E4937235BB7D31F7678DD7B3E987CFD3F9DC9A371E109C0D738CA370B509B3CC357714F07E678FDFD9CE09A49BABE9E47A3A5F7C9EDDD7FB6F81DBB812D8D8DB751DB2C1673CB3D77E3BD9ED4E059ABE3711D8CDE85B64095D59C0043630F6F6BA51CC0C7F1CDE3C3DFD0769531CAB9F5B6601F7C1F3DD5CC6E5DB2A71A1D6D8F26D6D9AB3A5FC1EFB9BB8696EEEAEA6D7A47DD386187BEBB4DFC452378D32DDD340DBE53BE19F07E14FF23C0DA26A39F7282FE78B8FDE643E9D78FC974087D364FDA64E0EDAADD6E40EADC7CBF3931E6BB071D7091DA380F5E0EF3FFC5FD2A894688F99B8BB68458CEFFEF0870B0929DB18217FFB15F9F1659AE46CAB317154DE455112443B3FD6B62F4081BB4F9755E6EDB119B1E42ADCF1584F49A19DD6DEED1F9B11D882698E7E7ADB221004DD543962F9AF5C4F384D3D25E5D459D011EBAC468DA41E991EED49471E187AED5AF7AC7D09489E034C2FB41D18818284184A9545C59B25CF0C3BCFCC5A7BFDED3DFED4F445C202519F1400AA4B2D17E25CFE74975C857158846F26D53D2D5B033F0FFC35E024C17AE9A6DB10656B676B1892B79A6B0C29EAE359E17783D5AC123A388362618DB157F67E43CBC9CFD35BEFF36CB1BC9BFFD678113101F4E354B94310B0D0BE80C046DA1C981E435BE2F00CFCBA720B19640B10261343579B3AC5B307260CC5D33D61C230BDAAD7EE64C4DE8A5C5A8FEBFAEE9392BAA1CA10391FEBC934AC963040E400E5B5FA390CD9E94689E45FA637F1786AD3CD8AABCE8C227F2CBDBB0F8BE9FC9749358AF974F170BD5C78E2F7D9CDE4939ABB92B0C0F207888042A6B43E00F40B0F792821C262C23064958539EB2F9CB09E2845584CA78B1E8E4FF4F2A00EE487A435250204A9F7A17175BB08F2566CB16108DC384318CA49573CD74FB590EE09DC3897CE7A3812813792CFEC76713FAD0F291B42A72052113C84834AF8A47E9CC506B099390C9999DFD3D1B681CDCC3AEAE7489B6176737F3DBD01460812A68E0A499854DB014242DD0EB48E28F603665F3ADC105693778A1D6135B9A88E6E7771C8C57E399AFBE936473392FBC97C72335D4EE7F571084E835915B041A8DC2A102EF25EB1E99062CB68E664C08DD363463164B9F37964201E3D971BC4FB6F9F1EF3EDA6BBA7DF3A4DC925932E97935B8398454375AAED027545B551A01938C916D1CCDF796D0ECDEC7E5BDB42757CDA1E28747C2711BDBE95D3C47E3ACF4A187373989C8F20A6A44F1D312A2702DE00545A57A22710F480A46C1A3D86009E4227B7AEE6B9EADB99D1B9F77C3AB99ADD7EF2D8EFF96F480EDD817144842AEC000DAA3A3F063705873E2A051A268AA8A19EFEEE938D49EDF5D2AD36C07D678516E673835F71B68774C2CBCDF6147C43D79ACD002A3708F352F36A440A12C7E5C4EB43E811407CD3C30C0FE8E001CFCB09C9B03D19986E1C27E974CE4AF7F7D7B3CBDA747EFDE0DDDC2C276AE724B92EE88CD454233A89420D00A475E8E7405E43EA516296D4DFEDFA53946622FAF661049A3AF4F8B82FD467A35C15A228C582EB4809400C312915DB74444BEAE1619671BB2D7C17FC493D170E7A31023DDD4C7E9E628849A8075112AF42644A22D61390916260A8D56B52F8F5A020C51C603A503FDED676632C12329D6FED4A58E23152CEC9CE31683423538CC5D1756A42615D3E448BB8FC3CBBBE620AEAF5FE1C9E2D96BA734C03A638D3F6102389EC862E2A9E2DF0EAEC9F5A55BF06853A776725620A313464CCA04D3A3A119386E9D4E5268AD79775CF4E26EDD70F61977777D7962F78B008208A6F60892730BAD133797A439D24D431DA0447EE41CED49944F7EC5C289A6FD4EA0FFD659D168A46BB03716B7D0F35CCBA35FA51A81B9EBB9391343C5198EE2C5977CE818CBB21ABA6FF540B1D3A200B063C341DCB7D04C8581EFDE054AC9CBB9310B17296B0BD39A947B77220ADD06B97130B92EEC25359344AB6D036682455618023532D3C3D6740C0F034E20D07DF0445CF9637BD289AC18F4BD1BC410A45F3019E8EA25BD3735E14DD9AC66F8EA25B6E1F57D3E564C624A6ADFF149A543F15989A7E25082BED4FD9AE928C455FABA19C3A71F382A10F74EA2A2A159B260FD3B926B157AD239E4C54E646C53AEDFAA25C354669ED1513505F75CF74AC4A098DA46A837257E02E5092A13798D5767A3F6E580157FD199DF6B43E1B725532C50D6708167B06D0E9E2352FC2ED80CE1BEA09C210C41E3467A08EE993EAC3514FD499B043D5918BA305D56941255CC3898E6B1473B0C302C520046A989BD3D2AC610E319D7BB83C31218B0206139DA275A81ADA8592A4897820E286515004026A27EC895DDE6B0E5481C5ECCA643C87817AA801363A40D524E45D8D5A40771217664ACE4C03684F9D8DFC9F9FD8567E08A3D5F983C7D432D0AD124E4DBA13F2EB2B5353CAEDDE19C890FAAA711A3034A1CF5049A551E37439E8D229CC2B1D224273B8CE3420B86A2F76DA9D733D718E6546812680C843DD334F68A21C75EA74A4895717B0084622D833541AA833742614DD4B753853E23E0CA4B945A18A97AD3B007BB956A726201A565234DA91CAA9442BF76CEC2B19CC32F5EED3C89EA678CF252DD4D9F9999E97E7126AEE30A4339083692FF7A553BB96B60622466947508A180C9C48C85A5BA3AA0DF0C5AC36BEBC7B3A548CFB7444A89824371D1A970C5B3FF93FEAB0461A984108516A047E1BD2EDFCE0A4A81AFAE96851354FDF223156693F5A9483201301444F8A604E16243D8A0D69C9717842548C9BB0EA6ED2B59867C8559746E78B871091D5F43E7CA88907C7B920D0A1B824D8164C9DE088C6E099BAF93829EBD44DDEB7C841855768E8F778101C8D60CDD7D9DAB6CEE9659D6E324E47ADBA69C3F4EADEE77372461A10FE0D870EE8DCD4F9B37AC08199B8D35174AF571CE7C679AD5E7220E107111DBE81971CC4E939174AB67FCEF1CD10B5EE3107127E5CA23E9FC71CC4E93943A226BEE8380BA206067339B9BEF46EA6CBCF7757E4F7A47844EA4B31150EABA71F840E9DFC41297DF2505755D5C3A13DB1792F699678811F07DE362C36A9839D613BCF03F67DAC9840F8DD01572705991A444057F4EB845B413F5318A2711883A817F19E3A1AD1CDDDD5F4DA1CB7AA5D0B24485E8114B9AA8371FCD055D08050EB95AE43078E06E0F0FBB73F862CB037546BE9A55D093CC38957091D7CA3130B341AD4C1E4E492001A7BEFD6478D3C2CF9E5A996590D32404C6BD94FCDECD937789461D5B8310B3E50C461D53CB9EAD208A4F8B098CEBDCBF9E2A377F9B058D6EF43ABBF9594A884800811AA4CF1D153370619F679B70773CA337605A5B366F9637F0A342E41EFAE8C407957A11F8759BE8976D528EE6EA67375FC03A832446F4DBD912CF460C720DADC170EC42675F3832186061EBEC14193A66E3E5C74645CC27CC8C36C1204619EDFF83B1475762168246A30C8A85B01E84DE8F9E054078FFB54A407CFCF37427F877DE38187A78A3AB450101DAA38928E04F58D40646875FE5B11236A025007639917E936CCFA9FD3A8E972D2A551C912C71415F529A4686088AA164EC50E0D233E15ED59F3C273A03A70E798E30EE9C146D3544E1D8C08D7A9D13568DCEA7C435A74D37724735401908C3906F6A86CE354FCD134E8135A72EC99E4995060E7C9FEE719E3FDF3DF5A5BEA7AF651ED638C8005534D01602369DD981E9F282D1A613231E4B589F22A443C9C67119FD30A3F61985ED56B77264148F82500488BCA2B1314B8292409F9D107B259806E313B6D900025A6B9C1D0CA3E2888A31B1FD21CBAEADEA9F837FA7608056DCBC34D7903516D9FEE06893437A766C97D6E946AA6FCB9EEDDE9725A42C37AB85CFCB6584E6F2CE4900EE8B72086743B7C8AE09EF8793C35B98373F50D0820E2436D6D305AA8329CF35CFBFE7D201A067B075D60A5DB5D9A0C2B3BEB660AA98B2591932CE9EA39C1F4E338576743A0D4585348F8F325E3B38D51459CD95392BD83E854B503B2B67B63199197930FD7D3CA17959E790F8B406958AE6029CA22BAC53349BB479D210CF194B98B8B10EA4C627AC6CD8527E3EDC280EE6E8D063E2504955E0761DDEADE9D480C314ED7C988579E9B6F895A1BDF0A14A76D553F373A6D770D2052B58B8F7B0A0566E924E4094C09A61F772F49989D9E341B53F8E4E18A893E9582AAB6201B21071104144DE9AE96BBC3199C18F5937112BAD44F5AEF2E9D8A4CB1E7BDF91AEF947CF43CAEEC8CD37562C2FD56CF7B9CD55705706EB47A7ABBAE69A64E42A6D626DCB3A1528A97AD016E9063FF0C7D6D91D3701A82ECE96B7B46C73D341475EE2513208D380DB7BEC6C6CE9A402FCE8E422F2824BA4DD7D16314AEBDB3A0D5ABE9E47A3A5F7C66DBAC454E5AC2014194F4D9D4263BE4C20DA9687378C9C29E98B52319998CB5CBF7ADF1589CC3AE12E2ECC4D4F3F0F535CED76938AFB59BEFA929B63A2E78F7D5EF6D0E35C01736C0D3681DF36C909178A5BB970B5207C6A3176922314D5F66A15F84EB0FAF27556B8E5DC7BCCF92EB6229C7F42E0BC07CB23759EA516296D5CD7B7DCD84F4EEC4182E7D55AFAFC3E730E6CB8725303D18E8CAD78518CB8B4FDFCF53512E6EFA30F4236052240FC57BF2A1E6CBA263A7639BFB006593E57272F9B9F62B17BE7D9C5D4F17CBF974A28E4F4AC202B25A190195F392BAA0898D2E8F7A20F66C3367289EB98F79E817851F6C1CBD3EB09A5ED7BD1D27526F3B81C121CC56EB9B2E48AF0154119F57842206EA35356A4C5C315C545EE47C10E8C4598A15E4ACB9EA9A73D29D3298E295C1140C22CC8ECEAF4BFE29FCCAD6BB7EC3EE27495A54D07F63A7D5659C55E720774F2C65BF6D8E7211168AC3F38737750D9DD822116A17A5283E4808C50A067CB5882E61A93F2360BD09E3570A04FB320C967AD7C258EA32D3BCB4F44A794E5A85A6DEE8FD1FE51EEAEB1B5A93FC9D25FC520D44FF5B5E7D4087BB4E700674F00319998AC16A06DC8243828C55B8BFC7A28396A9F50E1E37E2EBBB4FEA715685C6A58597D3DC03CE446737F7D7D36A6EDA6FDC20748AAA88361A5231B6015745B471F7816DBD5FEAE430F3E9E2E19A27C4039B006B125BD8E72035E2DFD7A36147741CD76368C1B45DD70160DA6B80D8C13CB9992EA773D560147569AD5CB299584E6E954B0D5735B4D14C023B54AE66B79F3CF61B6446CA9A86168ED16E258CC71213EFB8BFBF9E5D56A4009EF54DB111551D8A5C42517F36C002E1C22544401DF3F41CC55D68868E8588130A4CA1059EAD604D640BEDBCC44AE4ED4AA879ADD3772B26B42E24AD8F98B5C6B0546275DBB6AA6422F8B6AAEAA8B680C7508A66809AD416AA8583F88CB2268209A4EB320EBD45B952B08256B9492AED78B1C9D8DA6E5F26FE5749965C0D39BE8689B8B152667F8A8AC4A945CC2912E7448F6F42C7550B9A068C874A68B676C8D7AB616E872A789C0AC546AA61C60827CA8430C335E98CA293FF05C32A3A00A6038E87EA874EC97DCE035377D9982068BCB2283913C16AA354CD74F81CE3110367CE3156A10149FBB58B8CA6FD4484B46B608A01EAA035B7EE1301B5DA2554C4AC4FDB73075E9A760DBC64E64DE7F3BBB94AC183EB11B0573BFBF6E3CC84BD550F29CE007675A55403D4A5B5A232C840B58CD4523F09569B0FA41A78FABB54A966401D9A3146D35F654D849EA4EE71A794A2BF9B9476243605D1B60B1178A6BF4CD59ADFA1108DC73848B91A1E77CB28A4C38DB71DB5808E4AA81E77AB1A49C75E78BFCCA6BF4EA173595511859FA9FBF773268BEF95F39B1BCD622A6B13AD36553E68B3D1A6AE86C0BDB8FC3CBD61309746E2016B925AD0996DA45A680B073B22A69F60D6035522C98E4691912A8BE2E450AC94ABDB37DD628A22E7ED235B9914BAA69E497A5DC5DE3E6DF5A4BE777D8CE2302FB2D0DF4232ADB63AA2ADDBF0E5680D57E0EF56C1E134DF3FA82A22F02FABF81D8D3AAAC02E57B3C0BDBF71413671AC4D919E75CC4455D1D638F379C6C5AB19C5407304B16DF3E73BC6AC160F94368F20B66D5ECFA61F3E33399BD26803836AB5E56F5EC1AB8D45404D540B6C4F1830B76AA030EED3D8E991762B09785B77DEC07D6D9DA4E94DAB92786B0BA471EA3A0B752A1EDD328EC3E95C0E4B97F94A3C074F0B018FEC92D71D1F76ECB5D30DFB952B07DFAA62E8755353397CE8D0D3221A6EFCA2CA62B8B796678786403D64121E68660D47518FC6A0D9275DEFD397058C6C28DEE1CB8B810153CF0A021A9A78CC253FB91DC59CB787DF7B924553406DD3916715ACA71E1E541D9AB7B6638266B64074C0F4687C106CD80278F3EE296ECC21B64041A0DBA9043C305B40F910F46814580B9C6341EF65917B741C9D7145D4B0E87951A240AC036901D40D21E65EE5346237FB90C70B75154838F4934441A55A158C134FBF86475F25D033463D5678996848F4D345C2A55A288C4757CF96152B85F2F3B25C2AC8B3C833B9372956CC069761FA2C502AD70FE344E5A6078A7524788C395F4DD0B98BBC8E1016EBF903908DB67650DBAA55C3F8C5396694169BCF029525EBB2D87A4E59E7196E3CF520E1D552D6D74F89722CF0BC1BA758898F308FCEB782E01E6A22F76E752C4975A06CA74F850E983DACF76B1F359A7509B411093530BA2EAFE84469AE10C1D4E474ECB5B39E6EEC72420745973BC91CFA8CBD93770142E4CA922238B0D44ED180790AA8A63113C9B541F353C7B95A677602F00193A372EAA6CFCAA191F6BAC99302D4528F41AE0C4D896208264C3A4A7161D4E44EEA86C910ABA8FB2FD484A601728AD7E218650234FBA3536EE8B66647E0C63DD616385CD55D7E9E5D5F1D9DF5F76E1BE076D04168095A03A8D8260ADF060A6285A51AF340813E9FCD6B02FA4D0D1A563D155814D06CAB1F42D83571825B19A16FE23311E3940B00E849E8C2B99B5C01AF869235AF617A4D23F0DC483B8B727DD4602530377328A305A6D0FCA2CAE10C8AAF80089329805A4C4017C310532CB4609C6DC3A3A86126BE7A126537F11CB4DFB4300C034F3C6F8132F1D00B31DB8997F346CDB6FE53A839EE9410A6495001AA67D7F86C8DD28A7286CD4FD7EC1495C6D7B1E5D70C6B2B5055BDA20140A8F416E5233A14D2A125F86EBB2A9D1FA8851D8A4AF7B79D1A9509407881E87862941BC23457A89C829AE19A720A3A98515316403A5FB0986EF831A7AA6F17D0C45351A8E78788095A0CDCE3D45EAD8EBA3E4A3A9C5D691405457DFA21C2C1863EA8AA36204333EE9DB1ED9C1E9CC78017BDAA6955839846AD84544F2EFC6C99845B49A9DA07CC0E88B43B02049576000824D4190E824E6904DA9D2CFD640E378DA8D30F0D4B1E3EEA0C7431CF273E09959D68693C787EDB82A273C496F63430EF6DEB69AAC906438EF4B3E0A26C5E7A009C991565F3B230DF9ECEE6D5EA85E4A8AE9D43B1366AA0A27FBB93D99352394397AAFAE760BDE64D0EB7A19D38A93A6A9022949BA993B0C2972EFA6822BD26EF1089F3D871EDDC89B551831480F433677E03A3C1AC9D3DE74407874D31D11E0885251608D8192582C8E12945458CE935BFC21519E65A1004410D1E827433AD20E6516F06DBDB0373A9A2AD8FDB95984B15FA549EEC5245D907F3A50A16D46202CC972A7DA7F8E4972A989E292E55B0A0FDA64571A9E270E24F79A9D241DF0AD545B99C25E030693B78546A2D4B8503A16C119A1F892F55DE3AA8B550D4343802A1E615E75374BA39AA1FBD6B5CAB3A1534C368D70327621F9F4E37151D1C83FA571D2463D5B03BE51AD26F550377551D554FB779DA18061D72EBB24FB25EE9DC6FA5DAEAC1A8819CB8E5CA8634B3C1CCC1C481496C55111FD495D52354C240B38609A288C43E5C748426A2A2D78ADF28CF16584F3D14A83A34479D708F9AA901F141B3D28CC1E5D488A925B4F3A34BF4A51A9422CB57BF9952A4E46A93A83E658645B091FDFCC3F9C1A1D0235A00F530B570605812156510D04233888994DA671E8D94A7AA8A19A491EAA8B3363EC5810BA575F0314010F9B3D6DDC7CD11309EF34FD39299EE947531028299F2C832C709680F0CF3223E3D021E0921C0D42346400F17C34668678C9757DDBB6E2E84C34331F9462821B16E0C2A04264F09F34500B21D75481C7DFA2147848D5146708044A2C3A8286EC8FB447A0BD817C17F1139D75D28E2F03BC0C3CD72B799115C37C57B5D95572B584F3D38A8BAEBB86D2AEFD6265EC940734470F1C182E2474D70F0E933B967E1DED3A4E8A33F7843C31A244E040AA5780B6617B46BE2040FDE84BEE9830FAA2BA307AF0F346837A12307156CB5DE314A68E7AB5D1335B016809B996A2304A649635FE93747AA4C20DAE95200A1060AC3BA9944056EAD1EA04D80E2686A113B16AD6029615C4FE1682A54AB75A354A9AC8B1A9C5182A4CFD7E8D262BB6DA415D304821B28D292693185A735661A7A02BEDD31C2580F1C7C9DE3664EC12738434E6A2B707B7B048AE9846B1B460B0229A7509D980A8B5935837012EB7EC468B471AA2BE368C468E5B4A0BB135CEA70E2E55895B1E3AB42CDFDC0A18E2A5EBCFE76E1083D346D1C5B32DCB800D510DD37DCB4A0A7616C237785EC3A7C0E639E8901313F06088DB5480B081AA4BA1086F0587AF4A36CA5BD4F502B8B9C277C6B67AE03688F8440434D143C20BDCA08F4E44B6A50E3586C4EF067E59F29A66C12FCC815AE992628F57C9881150E99A6DC52D4568C7EF184F9FDE96D8DE5324D0A3F4AC2EC58F6D3DB45B009B7FEFEC34F6F599520DC15A51FDFA4EB30CE0F056CA3EDA2E4296F20F75FDE2C767EC009E97F2C7E78F3751B27F9DF7FD814C5EE6F6FDFE615EAFC0FDB28C8D23C7D2CFE10A4DBB7FE3A7DFBFEDDBBBFBEBDB878BBAD71BC0D3AECE727A1B7C7968A34F39F42A19435CD7AFA31CAF2E2CA2FFC959FB3B5B95C6FA56A6CEEF85FE1D7A2BBFE3F1DA7F8D010C861210EC9E178D90190FFDE7BA94CAE45862BC23773F8910D8B67C9AA4618AAF9A88C81E158047EEC67F759BA0BB3E255D1F7D99ACD491A97DB445D2ED2AB1A3BFFB78BAFFE2263F8E9AD3044710EDF4A932810B5B838A8A5331E6DFA85D38323D6CD844035B11D3871CDA442FC82955C4CF3CB22ED626C7DC6E36A2C726207BB25788C419917E916ECA15044C099E58F10BEE6331E5778C86217AD019472291EB3B00D0DBB149ED5136D31854BA67E63414088ED04838DB1F4C39066E817E1DA5BB37FC52EB64BE818CB4A198430D625788CDB741D3D46602785220B9C723785223CCE3C2A422F918EA3D667222E9E02938B5D12B6438115BEF74A84EFE918CB5599AD2084FB0222BE5D9A1741BA8666B029228F5A229BF67722B6202D9382E74095F01D4BF018775994668CB174B1355FF19856999F041B8033740A08BB38F7FE95AEAA7101DC462CB49B430033508CC7BD49E3B59785BB342B3C86218ABD9D1F09A798AA0EB19528794EA320646CE735071AE81613668729295588ADDCDFEED8FFBE44E2EE872AE0F117DCA421CF7AEB3355F482C52E9AC875599F0B1F5EB9502922940AF1783F96713C59AF3326B67471760ACE4A88A97382DA48322024529C51C0EA651AB62E4AC1A629C3AF1607EAE2AABF10B8290350C8C542D16944773F28A267E1243A7C3B2F2A5484694050210489A5421856BB320A8626961139A42CC3B53E9FCD4A69EFE70C36052528C69EA0011E43E7E740E2B17EF846C322AF73F395C276F2FC652DF29BFA1B1E4B9414BCE938DCEEBAA83A05043BC1B6CAE1DE310E6C81B4EEDA916DD224ACB9B92C944B8554BC49B95D89BA57B7048FF1D1FFAAEAA75044C309F5B1FD9DA270AEA258D25EEB6F0401B1D2D32E04A1F0F0918A47D4042D944048FF23AB7EB0D667A5F001BA1E55CD03353C1BE52E65DA4C94269038D22DC2E38CFDE4A9F49FA0334F28221C798CB384995F9459C8542251E3904B2906AB8C895D01A4E80945789C2F61F4B429808E760A08331A264FC506C0D729A089B100B6D6673CAE678E005A944E01C5DCC0341E78998522E2B9C5A00B914D760A08638EC21701D3FE130D4728E32071019AB0AE3C43F84DA017A74F51221C22ED02CAFE3F4001C650A9F0BB19188DD3A11938DB15DE2E63E4DFC5D7FA8CC7357DF6E34917CFFE130DC70719C7072A8E4B19C72515C73F651CFFA4E058DC2CBA18AA0F7878B6026911068CFC44F677FC4C1114B63B3F910485FD47C2A6AEB6ECB60AAE2F2A366219A577719A555E0FA0862C951284AC30597B4C0A16E4ACE35722264053697F2762DBF8D93A4877A281BE5B4438065EFC577E53901500DB910A897879A714589B2202CEA2F0838D806CFF8D742791144C59DA45612E6E9276C969EF2DCB2C86EC09C7AF04AA498561561F2847F22A65F2710ADE67488584A3894D8D176C98541F7A953921CD04DE00D7A0886E8CFD46EBBDC8506938A2080754B0C55FEF9322124D2EEA5A44B1E83005FB29016423A906D1C8C34199D292BDEEE403042827DC802C6A4753897E3A05841DE7B3E5AAC42C2FC83D3F00D65651856EB04A8B0D28FA374564D51B3CAFECEE04D7D52B50E88CE996504C1EDBADCF7A021D5BDD223ACEA72C2D7730CE7D11493AE1E65B493AA93F52FA96EFD86924127CEB33ED969A8178FE7A2B2A4442111EE72C9F1E9C9EA66B51AD950A49063B2F8E8230C965AB5D5340C3B70E9FF9B5B028E4094504D34DE6075FBC32DD0A369BE633C5B1CCDB847E5C080244EB33C1956CF1A777EFBCFBC562EE4D1E9677822399586885777A737FAB46BC2FA570CC425A96C3371A16F8ACEE969056A564FB220BFC2C8B7CF154934BF198EF0F36C884FDE9FDA34C453914AC7036B75FD4580686BB4B0A36CC7D260D9F92B7095444F37F087FE7C63C4F44D2FA4C306A84FE9A0D5830691C3E12CCB7699678EC03639F8544CE522161AC4C88042E7F5A9F095C354D6369D68E1F0927133B2132FE0E40E854FB3B1E1BE41CA3F68939D1AE34E769D1EF43033C62E7193118760BE853DD149C83A3766562CA60BC6219196B9E800873924CC62D175E9430652E8E45C1512C2348A2DBD2E347720D2B88A34219E984D521068A09329FFFD5CBC25519C5A2C4D72EA0E85CF9CE8B8A5090F75A9FA9B8B8A6C6782484EF5844C42989A3CDD7535E1FB8BFE218E2F260884B8EFD16F61249C4EB96D03056FED3652E233C1610F1312EFBBB2C83774AE8635E8779201250B788B29BBF40A6F4D667D23A879005B3FD9D229D55AC84ADA328A035DFE9D882342FBCEAA748DE700DDB16C24776847B8F4C342EB350D79050D1B23DFF9131364473423DCBD67659BAF25751CCE413862B60D28AA649A8B265BBDB284933EEE9EE4719C7FB1CE54C97D3B4AD02B06CBF4C0EBEEA6B54F38AFA96ADB30A4119FB9299565989E4D62339F390A498487EDE42D34F9E7DA6ECAF62FE50427416148AA8A7A3C73758E0E7A2D5502CA45AA8DE795CB5838C5487122AC68B776A9C4D1919EB7B0DD6F774AC4C788C8BB54EB6148B092BB6F972271AA00FDF48589A54D54B3E5049CB575421B5310F77B11F88D247EB3B111B2052B7BF93B07D8C123F09223F560E1FA8416AE1573FCBFC447CE6D529E8CDE72E508C8EE424AAC0F11ED512C98D34ABC9C0C4BB1595E82E99F01B11B190B4C613EE1BC6FAF311E6A05005CAED237FBEE2294D1450394D564E138EA0F6CA2C3CA6F69580AA0056A2F2D855B97E0A0B2FAEE22BCB6CB6534C18C3B614FACB3F50E6405AB294B646B58F8E570679B982057BB1982033BCE64CBBF7AE97576A03085CE56C2C83C660B80603FD81FCA078DB1883BC1E7E1803FCB151E95163BB8070FD551DC1726086C3D7A18CC9FAFEC806EEF67712B6D28FAF25BED0FE8EC7B68C0AF1B9C5FED3D96C0964A609435C1F0412C4FEC0A1514DF626CAAB7B2EE9B575EB3BCDF53A4D546FFBE452CA2D113FB864D35AFBFBB774E6B8F2F1707EF751F9EA281EFD4985A7BEF918EEA6E608CBEF101468EB221B9C4C7754E1AC8AA8EB05EC8BD677A2379EC6900D95DB6257D098B21259E6E260125F13CBCEE648310630D71F264767294B29CB003F8C94756C5444D329F82E65D5508B308BFCF8863FCB9A433E1D50F97719CEBCE1E83E47CA7482988DA6861DFF94CB2B9211EF9E9AAF04AF7E266C88780EDF283EBF799045BB42BA70E81450F065D1333B461E33F166BB5B42B0156C0B1F5C864E01E56632FB1242F25BA780802FF415EF44BB25788CE9CEDB643977EEE24191BA38C53212D675C42F8FC485E91490F065F2DB81E62B614F289E0CD9BD16821F0AD9BC11DAFBB254DD003D68F625A4DD5F792E07AF411CAA94366525C22E64EBE9270C07DC7DA0983C2B6C42C139A9BEDBF55442291512B49FDAF02AA912EDEF646C87FE80289B42A27CBEF70C5509FFDD623C6EEEA722DCBEEE3FE171EC2DA40009754B2877A7EE6244C569E0CB0757F39570675066C1C6CF43AF66AFC2858158688797D3871A715D6A8159A61AA1C802A76C6C118A28F2C02E937A78FC48C2B30D8B4D2A7288E63341720A64E7E7C3B753FAC8FDE78601A8246AD049AE5B42B9257D921DBC9E68B27198656906F8C9379FF1B81EE310143ADBDF0914BCAB3C83FD8087FC1708B95B84C779F561E1C1DA49B784E2D9EC45491097B23753B7842429323A8064A676016155AAC8228C3094CFD6E11A243A54E2B6C7CA7E4729782FDF2EA0F532FCBA8B40C3A65448B8C52EB355CA6D8B502055A18C62D94E8A2C8DBDFC152205B99480D98F999CE9675E3D8F0262B19032BF5C48E4521C8F0A20F7192AA7487A5E35683F28BC47EE2EE1D52C0014DC8C95FBB49BEF9596CAD80B49F44810977D40CD8102A8573F94DAA3A92ED54B44E16B2D1552F1F2334E89B75548D85FB9571FE8609CEC7611E194A9BD022135B753E2602D31E46CA505CB78D49A97A9AE835611E36CD774C1A9104D76AA1278AF9F70374488EB764A28561CD6B3350F3450A65B2FCA3FA7A5A8332AAAD8B771059A1ED4B5EC5BFAF957C4788E95ECDBB9DC1FA7FA869A5AF62D7D2CC3F843297A2AAB6BD16C610C8F07BEF8950A6978B9B7B316B754C1C2EAA66C00AE61D1827618EA5AFDC6221BB9D5B5F02D7D79A96CEFCAD140E564ECDAF952D521683C8CCABD15237375238A2A366D6807A3A94695D8C34CDD0C5CA35F0B327DA96B91ADCC9E96AB282BD1DB3173017D4D7A8BA61DA4AB476F0D41EB86AAF43611F4A8AD896FB18E34C32079B85640BA81CA09CE09557C98C64546159A46AC4171AE08BCC92F9FAE3E7880BC2115DAE0856526A8DC063B1381EE1EE662884DB9D806372CB140E536D82FF794A7C2DE949324FB5A4AE76816E2AD9B5C6A8919BE815354B1EDFDCD83EC2E08D7E8390A4333DD6AF8B6EAF7A05E1C255FBCF0AB74ED0414DBE18EB6556A28D962A8AC7436AE487B17EEEBBB4FB64EE40028C2174907AC9AF2BD13B7D2BBFB7C5C78F71DE2AE43604FEB023A3E39EC6BBB806036CFD2551C6EF3347E06821AB78BA87D946F4CDBDFF1D85EF68F1C83D88F04095328A25E9A40F72534B7A9A47CF4F6FEF20236B18C62188FB64CECCA43CFDF8A31C0BB4584394CB32F69C6CE2FF11EAB53F0FDA2178DD3E2A2F76421B56CC268D985CE22B8933E8157BF4F1617BFEC34AD6F62BBA85A9F49B818C70BC10B29B1EC1C4E17265424A51860F4F891C2C91C86A661405284D2FD37C2C8EA17A892B35AFBFB777E85C6E9D031A57E5E9D7CE1B9825A0F59E48D0C56C2B7B32A03EE7BFC12ADC598B2DD120246EEAD15AE59978A4D147C49A4C49E6005C23E5F79ABB428D2AD0A3F5881849FC77AD160178B29C69AA2E0F639DDF4A8EA10E8D134436005127EB6FB320D76B1D88E1E6563A75CDA8B2E81065495080A7729E0AC3E502E919EEAD781556A2BF1EAA85B46D04078188E1CDAE7DD123246A89B421119A782B0E4528A2E92453B70FCDD1232467099BA45649C8AF1CBA584AB11EEEDA7F0FB17CB48B4EE3D5649EE0582DF7F25E98A59E16DAAF47092C6D82A21F0719E4C06C0D7FE4E9159F921FB548A3257FB3B519A2ECA9DB7912DD062D939E938DEECE6FE7A5A59DD67B78BFB696554B2517C508870DA1012954604DE47CD82B411B190245A1F406551532AA409866E54BA2D7F3E0A5F150945789CE9739831C5C103DE800845947B76F6DB0B93E7284B13399202504C33D9787252F3D6678A4A166CA244542A0E1F0986BDDE39D6B97F49243F50697DA6F88FFBE2F579F585C088A5D0C5213162B1745B41BC97B0496C7D4226DB4461EAC9643188904C16876A6C26CBD95E13F30C668B6239854156CF686596D32918732B655084C6CC223CA3A39034431D728D15504F39EA6AB455F1A2A784D1FC5A5E9DA6C43DBB3A218BB9FBB098CE7F99547782F3E9E2E17AB9B0E230083C480683C2A4DE17791917D0A38C6E8915653BE558E98ABFB2AEDE8942DD058AF1B8BD6013065F442A3E7E3C5B029CDD4C3ED1C3E0A0B058109F028F5E318478934D9A77F784DCA2286FB749350477283E573AE9CDA11CB026024F1A72A7B78095586D8924E62139B4FD6D57A1F92BE073B59F998DA3078FC2A3EB61EF382DD71AEAB0DCF9995F9B22B8755230060B6556BD0518A25C7A5EC4D92CF9FD643EB9992EA7733BC688C28425491CAE71D7B98194FDC2C4B2735DE34B76E42C27B796D23906117D8535A8340629EE510A0A3662D999B0078068BA25A487424C437FF52A1730E97550BBE86CC8B03963E6D3C9D5ECF693C77E5B043E46E24110211A93D9A6707825132AD258EB6B9E957544BA8D6A97FCDB582CAE1FBC9B9BE5844C7D0A3804B5292195B642E7C102CF358D99E212D9EAFEB8F22C7E52F902CAA504CC3BE8AD7FF395E28F314EE83C651814CB1028DFBDF1DC79E305B9A7DCE062D9D970CDC9FDFDF5ECB2325BD0E3DEB6806D5E9BE8A087DFB2BC776B090D31BFC16E073C27397C24910E3CB04EC1D910CDCDE467BA9903024250090C36CA89E8C47B9A43C834D27C256808AB5C92E50EDFBE737C344EC71C1F26B86E0901A32FDEB7FAA4BB56298F203189E0319D91E097D3FE8EC7F6C0DFE9064C428B7C3112B35084C7B97C1553BDD65FF018E6E2DBB539EDC5DAE7D775E69771246CE9D6673CAE0FE95A08A15D7F391B56BF9C4F2E7FAE1C3B26F3A537FD27FD05931103E21040E0506A22FB786075A6E8F02BA443A8EA907C25064867E3F2342BD234862C6BEDEF140F7C45EA3FCBA47FDD15E0C959ABBC905E1D3ED7B8640A80B3D945D70F07E2B5314F284071160A25F0B8A47C845420B4C005622229ED5B764CCB11745B9FC9E24506E0138AF038A558DFD4F8DE59FA244EF8E11B1ECB75F8284657AFBE904CF0AA179742111D278C8E444D9B285EA73B99345BDF097450C645B41373DD345F092E67D1D770ED6FD35274C1EB14D818845D3EA80D52511CABBF10DC33B3B4DC498A4DF395641C0B03AE6FC8C792506481538EA1201491F997C24A2897123127AF09FB03407A282070C872BB0BFC9D1F4462CAEB6E0945A4F9EAD579A64577D97601C129258A739F532F8F4DCC7D4F04FD072A27610F364F6AD4DD42DAA58F1715A1A088B43E5371813D148A8838A5778FCDD7EFE606344E87E68655FA12EFEF82815B62B9D446FCF6B2F4452569D765565883821B4418294A77F0CA4AD6EDE4E5CAD8CCB10E996B574F93408EBD2F217057601573F2DA6D0E7687837FBB97BF6E7745BA1585474D3D92C9EB305CD0EAD52D24C873695EBD3A82A544B19060A18FE3F4C55B973B3670395093584858BBC2E7E179D79E4E5D525622F8FA5AC7873E6176786EA461FFD47E18D7E00D8F394D3C0E0F4209466352AD41BFA4A6F7954E72595380884A2A24986AB97EA2402B969D1D752CEFEEAE2DDD65CD280834A143320C39A856CC860496691A8B880EDF085808B9599573C25D82AFFC427893DAFA4C98A15A8C93D3E4760A887D5B4A1241EBF3D96C8FDACECD89D2D2CC0E81A2EDEB30B0CEA0ACB0275B19A73D596B6D7D26E292AD70ADCF67B6DC075EF4EBDDFCD6BB9EDDCC96DEE5A4EF3D8B1E19F9CAC5848E60D78FA36DC4E34B9B2F62C0EAA7BE93A9BBA8BC4D914A09827CC424F3C7B8F6F7BC4F23D1EE079593B0E731FB7221213D7C26F6B408339EC44DC6D72EA2F7EF3DDCBFF7B6FD93F1B58B080ABD6175A07212766875B636ABB355AFCED67675B6F0EA6C6D5667AB5E9DADEDEAF8EB7F9579E1F1C85C828AD72E20A8777C548232577F3AFFC363B6BC71777800C8FA1C1E203AF2E1111550A04344F57FDFC3639FA991ED9B8D978482094F2AC4E37DE141FA6AC88B773CB760108A9C4F51C5AA8DF7E636DEF76DE38FE636FED8B78D3F99DBF853DF367E34B7F163DF36FE6C6EE3CF7DDBF89FE636FE67DF36FE626EE32F7DDBF8ABB98DBFF66DE3E21D6613F66E05B3D57BEFF50BC466BFD0EFF6931EBDADD78E57D3E56466ABB31BF1A00F5C0426DD8DDFE1A55958F811A4DAABEAD0EE158778035E9F9C6512A995CA5621D196E0C8C601C6D0B3889E570936FB3D21B9D54A85044F87671FB29BB43E1314301E95D2630B9997D9A3148B4A2E25F934FDABF6BA00A2624A85143F8FC2D3E2062B50569FDF6CF2FB1A00B75448EBB71637588124070329356C926908A4C959BB9676EB0A563C6013E58C3F42AF769595084EED978B2A8ABA68786F7F3FDF93AABAEBA0070A40E2B139A9549894E6FC2BC18E7F4559BD4F0F227CFDC5EA0C1BF2A4AC62ACACA51B95F6772A3630A09F5044B856398EF1AA1AA2742D06949FCDBEE04FB7D3751987DEA25C593D19574223F680015E35E37B98BC5C01242715E2577251256711F311355FF198F69D801C8F852242EF6E1E848EF10F84EB4411FE9206CFD3E9F955F0489EED44EA4AA78CE0555D672807B18A65E4ABD30F82B366EBF3E9AE611740A2AF0539D1570D2177AAFD9DB40AD2D493A4AFC1D2090559FE08991E9BCFA7794674BE61220E6E95326D744BE818C5EDD4FE4ED2FF723112DFE11B1E0B10339D1C2B7D9F0588B31926A030E520953C8715552C7686B7E7667E51F8C146963FB415495219679675E84128A72058813A675C0C9826E57696ACC3AFD08C0915CE46DE61CAC96F8BE5F4C6BB9E7DA4BB5CD58ACD357F3A41177674C04AD9B2978B15AC9FE9B43315A64925BF8A989AAF04AD310F334963DC7FA3F647E670EDEF246CA51F5F4B8F65DADF8771233B55C0324125C9BD45B496C8D21CAF0C8506B135B088B02A586ED2C172E2468A446B60FDE56C16543426F4B66B3830689C3EE1C1705269F8D5DF4689F866A1F96A67457119F64ECA52494C4FC9CDDDB0119C6A037721A9D5E6CADC7FF262E915AE5866833593335F4985B6BD05A5304515EBBE1B1AE9D6C1B7B2CE5EBD7F711FAE1C9878A9D00A2F30F572291EF3238F645A85AE903B2C96D96005BA2B151276E92E4BAB248D4A42816B58B4A0261345158A5575E7079239B5FE46705D5B657E2E073D3F7EA5E8AB515E94E27BECE62BE1968D6D20E9AEF2F891F8FACA5FC5E1AFA12F1C1A42111E6719C8FCF9F08D8A450ECCD5FE4EB1D69CFF2BD7204D1EA36C0BF75228B3C10AF45428C3638DFDBCA83D4177406FE5523BCC728FE552F2FD3970C5D22D21F4350D80EC0DCD57C2B953333AD1C4DFFA4CD9398C35256B71DBEC3FD23C8164BF1FD2FCF4CCF8F6DFE92A8F8AD0BB644B239C0D4211C5CA17877E0E6E32A1C802E7EA55817145B244B6C46BF87A1FAC80C7FF7BC9E45C40F3687FA77938047E92F09422926823155AE105841BB9946AA5F95CFB17C0C6A356E19929D3933E8A340C8C56A255E04AF142A53CFB768AF3500AF9BE3B59C877137F122E737545150A93D843827CA25B668755BEBCE896919CB898E0B7F5F2347E16339189652715999C8B75E7166AE40C588DB79CFC3CEDC770601444B6A34262D8D485FF25D4B0A07631996138636C9DCE28584F53688957E43A52A1255E20C2B65C4CC62DC7F3EA147C9BBADFC9C35BF2201B1679884C08105BD98C42ADC256CFB9AA3B6855601BB80AC98D7680E764892FBE98AFBFD036C3D9E7DB6B2DEDF2B77BFAF5B5019E465C3006C3BA0F15EAAF865504553D1459E154622419619D04B8E23E8345E5762F498A87CF96C212ECC724959F56BC1B266EA7BB38A53C70A368583A7C23A9040E62D5BA8E99BA8D12796CFB6F782C4F213B39E024F14211D9870B8839D62E206CFD63E83615AF822A10FA2B844253E648D2D4B362645EBE49B3E24BF8AA66BD4D8D733AF27842C5C3A1B378F8607DF461F0E08E401C26CD2E382E2AECC20ED738B590558461B1F1F2E87F8B01855ADF09229BE0689990BC2A5F04E81712343BD122D125E1F0EDDB356118A801248333DAE940A88CCBC9F5A577335D7EBEBB7211C843830E6D22C123D43B6E0C9FE1C1B27D599542019C0D19DDDC5D4DAFE919DC2A309BAC5C309C667F3B7C3550414999B90E1F897880DC5CCD67027955AF83A138ADDD1282D4B85261EC961094FDAF712889B3C78FDFA6C5EB5B3FA51A5F35A63345DB720B31A14EB115EE28D1E23E1413B4D2FC7E712928A3F527EA5B222E41295943AB90A4CBA8188E5044C0D933315BDDEA2E8B02FE0C3F0E9F35FC10AA45F4FEF5B29067265897399CBD5A5909DFCE0DEFEBAD140CBDF599F03A62FF76FE5232CA774BCEE6B8E5AA0FFDB4B554BD687A96CB37759075916E56E410F231DB7CFD7EF2A071BA4D5EA936F55851CB2A4E21B5BEF599888B7D7E823A2815123CE1C247BF8C0B4F7A27D029381B3EF3B098CEBDCBF9E2A377F9B0587AD37F3CCCEEC96C078304C186706854135FDBD3F33C7A82EEB5E5528243226CC9B732E007EC2C4CB7203EA188C262DC3DE51EEE694F2D6CC8573FEDEF786C5FC270E7BD44C5C6ABFAD4452915FEFB315737D74CA74AD2C0B6F7DDCD744E17700E9036191994A0A3EE5506285DA7EEBFD1B00016A5D667222E26A087A1A880B40BA8F8CA5599AD207CFB0222BE1D93CEE55719421179CCB290D7FA4EC416F0ABBF4CBC04EA9450C7BC491370C0F57722B66DBA8AC4DBD84E0111DFA3FF1540567D2562E2B1E36200D7FE3BE1EA43D215A909B33ADBBA4A15A6D9F6FB72E28581C3E489DF951587CA4A45BD69B68598F3B180A006AC3C88D5B73E5B71E8F74A164D8B664FF2CAD2F68B318F98DB9294278858A1177E68FC520DDB1654679658C112BFE60C93AB58CF127CA609E596D8D5679C5483A088EF41FDF53A0B73E1F6582AA438FC445B3F7B656A7CF2544A716CE552CA357790266B0562A99062F2F6FCA09A416FE7BF02911481729A038E46A0954A099A9DBF4A9358208BE3473B394A21730BC5FDE858D5065C8D4079F5E278459889CFFE8422C21CA74F2920F1B73E13CEA688B1CA2880FCFD84221275BDE45E9929EE443A6504DE50E651C2F6BD573B9D09BC412C24ECB480DFB77F01BC47BB25248C5C8A63927952890B61E08B370D8A2AD6B3E1493E6760053CFEFAF924238140F66F14CBF058D99F8F4CC110A3E2B63EE3712D36E94B9572450CF3D8FA4EE1E38C514B7A4CF3958809D063DADF89D8367EB60ED29D9815BD5B4458853DE391D314764BF0182FD3A460322380B15B427184634CD19B7E0DC2702DFA628B6578AC93C59FDEBDF30ED61F6FF2B0BCEBA2062B10767EF29C464108A46DEE96D078BDCCE62918AE423F0EB37C13EDC4D7C1DD12C26A1F22BC4271E6A44202AD97ABFB2CDC46625AADF677827B7619C713488EEC149C8D1DB4590CBA25B481B5B085EA80C7A3A95B499CB9254A32772F52ACB0FDA7B359E3EE0B501B176B2306CC0DBF1987CE56C0DF42C257B97229CD0A91D6EF2BB368A77CB2DE2927BBE7D6E2B6EAC151ABF46C28A6BAF7BCE199C4270F57B3A5F779C64EA6DFC864834383A01D2C22ED95E2A45C83B973A4C273B8AA946D955413A5CB2BE3C7288C058EBBFF44501D42AE705C6EFC44B457744B089BF791896410C24EC1D96CAACAB7E06A3AB99ECE179F6D5D1CD4F058EF061D06D54CF78B55EC9212D7C7831E321D888567B3F693FBFBEBD9E5A43AFBA6F3F9DDDCBBBEFB44A6001416041D20F128D50D811A88D712BD39DBCE7F0A653B54F395C0BFB32C1503BDD69F08EA035334BF703F63517D687D3F4B3AAC1E7CDF7E9CF5A3432516221D6AF0A866FED9CF221E5D51B642754BF06BF9ECC72588EEF899C2A91432A541983C9543CCFEF5D364B99C5C7EF63ECEAEA78BE57C3AA1E7594663C278CCE0711984F07DCE05F5B3C96E05C21B9652E487F517B29AE0F84DE77061195C668C14265FDF5BA0D669A490B0BA94914FB2F677D21CC8376D16B1349BAC22C0358D54688357859266AC1C2600DD2ECD2399D9365FCF95D35A19641038E8DCD52AECCB083B17C22113B8BAD6D9ACFCF41FDEC3EDC17C31B7B1A768E151861403068DA5439F7514AC4072A8E2A9F3F658406762A99C8A1D784EBBFF7AEAB37AC01C6BC7EBDEAD9F300DE9686D54F45F579730DF0D3CE07427165AE10D7F97DFB700C578DC59B82AA3782D3D1E6E7F279D723C15179CF8A35542A1113E22654245A09840259E5FE5438288A25B34BE5413F84C44833AD6FAFE6FE80CFA2D38D636DB8DB30EED7E6C2AD8EE76298F25506CC317EB9C181E14604EAA40D0FED3A0AC828A7B7EB2F6AA04C4C27D305CE38C6495E3954B7565470F7869C440BBF851E1309EA99E32D2ACA28AC5B9BD0F6A1DEE835A7B311383B40DAAEB932F2F5D47D0ADB379E720CA63191DABC4C83A05647CCE62DB725F3B0F70C36B7F2760F3B3CC4F8A572F88FD682B091340F12939F8BF7FF06FA52B49FAC2B88CA843365FCF860F7F9ADE4EE7936BAFAFEE88C483E0C9684C065D52A9439E97F634986536175F76359F69B76907895F745814CB08775A1A45C35ECBE01153F7DA9428C9B50A6896442F929CB25B9FA9B8785624294FB45044C459A650F7AAAFFFA69C7F8827E60E4F93839D507696ED96D03082D9F73A05447C8C13FE0E2A254DC999D80EF6B3565D6BC213BA2FA2708A2F60BCACE63389861CC6E5736B253A407199D5AB7E8A5B07AE61DB42E568E53D32115E4AA1A8AD68D95EE58785684EA867D9DA2E4B57FE2A8A999CC2700585E8D961AC6CD9EE364AD28C9D5F3B3FCA38DEE72897AEA1500096ED97491E6C426ECA5EA39A57D4B76C9D5508CAD89722D72B2B916EF4A4CB3C921423A5F6CE15A9BD8D1E269C93295C4CEA22EAC9AB78A02515126EE5AB5087EFAA28AEC2C57CA7848AF1E29D1A675346C6FA5E83F53D1D2B3BC2E262AD3BE1C462C28A6DBEDC49E121F6DF48589A54F5CB0CCA3EABA8426A631EEE62C917ADFD9D880D10D7DBDF49D83E46899F04911F2B870FD420B5F0EBDEBE22216E0A7AF3B90B14A3BB70D0D27B544BA47003594D0626DEADA844F7C6005567A990B4C63CBBE433EBCF479883421528BEA5597DA1A0305140E536B70E419955882AD742D5CD835089CA6357E59AA71B88A34730EC77A7983006F19627A0DDEA0CF7982755AE5A6AB95E43F92AC9C66BAAD57AEF0F5106709A09A0F88C2C9AF6774A1A5894E5D2E21EA9A6C85C49ABB9ED3D4BE24B3E7AED82B35A2FEE2976773BBD5D5AAD98121AB9661A78D51C1FF2ACD48C549D87A55D7E1AFB04EF09DC3F32FF5BE5DC46A9BB805454198FFBBBF78BD9CBF5795894828AD62DA1C848BF7BDBD0CF01A345AB80326626EDF8B11787C953B11147DD2D23DD5B2620CA4E0141F2C922516DD87F22494F85641A3B7E2468EEC126DC322A0DB47B585D8BC68BCF3E3964CD03AD9EEAA841D1BCF7FBA39C932EFCF41776F0D9494A302872E155C04A0BCC73EDCC245FC0B60B4EF35EC3B5A74C3524E8FD47EBFB093C257B6B15DC2B295B83F76D42D1196E919E42AA090969DBD888ACCD21A6DC4A8A2A34617338B198095C920446DE56162CE4F4A477F453EC437A4A2434D2D3A0317AD0A8494F51C5C65752EB8849C42AF91C137D8CFF73497676737F3DED4BB24A243492D5A0512A55C7B4D0CA25505439856AFE1F4866B3DBC5FDB436B679BFCCA6BF4EE9893E716890A4864164B603E7DE7314BE84D0AD86B2D2E9EDCD2E65E9FDD06409B1537066A4B89CCEEFE7D3651D6A82C96637D63A1512179A2891D80CBA032C2B5A9DA84E530D39D36CB68AC784DD92F176DA09A9F9EEC3623AFF651F3565B6B03BBF4D4890F46B46734A63B57CC3A2BA5A51125EED8FA3F2BBB574BB557ADD5A3D86F926CC978BCBCFD31B4627973DB574041E24E9A2309DDE40DDE0D0E13F9FE0306EF27A1C3C44FE093B8EFCD306D76F30AEDFCE76A7CC6E269FE8A1411038C83B4481655C9A751B86665516053B570E542026FD904AC7177A786C7AC049A0F5F96CE8F6A8BF7B9793E5F493CDFB34330A04D56290980D0A013B849FE02827CA4A04F23800CA4B2B1459E09453100B451638F34D9A159ACEB6CACF8620AF1FBC83E3C8644E9734F4E008423421309CCBC33C38845E13ED3F9371819868865B9EEF47CA45D5FA4C7E269601F884223CCE4D261C09D5078A3B45FA244EF8E11B1ECB75F8284C75FD85EAD00ABBE1768BE83861743477DE285EA73B99345BDF097450C645B413534C365F2967EFD770ED6FE524349D0282B9E1786EE8CE14FABE163D94EA2F040B7796963BE99961F39560A1FECA4D26E11A7037168A2C70CA37DB42D139683EAE736BE6E57617F83B3F88C4F70CDD128ADBE2E19DB5309B9D0282C36114E73EA75EC5CB69A89C843DD83CA951770B69A6BFFFAC67E3671D44EA1B0918B24A5FE27594EF62FF1508162397521F6B544FBBB3F4057AA9D19459610D8ABC4A142CA7205156B26E272F57C6668E75C85CDBE1A3FD1C58C59CBC769BD775E697711478FB3B032F7FDDEE8A544CBAA8AB479885DC3B4639958F2EB1F0F48FB5FEFFF6DEADB9711C6910FD2B15F5B4E7C4C6D4A5BB67E79BE83E112A5955D65792ED91E4EE99270445C116BB7851F362977763FFFB01405204890B712325BBFCD2ED12C0440248241279F5C2307904BBE28026CEA67FEA366AEC5DEEC53B2FDD01D97349D849C31DCE8B710C220778BB459B8E251A067E8F71DDB863F808482DC38EF1A4F959D74D9D0546FF3EBC6BFE59A821CC523D2BC0D0564898A57A1E4A662EBF156827EA2623984288E3DF1438D5424E9E2C8C4EA0FED950C0E187FF31EDA715C9867900BB7BF0E317503770A5FE6D6CA58F6BE54314C4ECDCAADFB49CE12288F92B6BDCE834691CADB24830E7F2A61B4C042411AFE27530173C4451CCB27E66AA0AA264676260F83DCEE9FA33F732957DAC76E1597995BA6453C72F85E147FC1EBA1AD96E81EBE657537F03C0E7B0C24E2617821B73DBE9487C59C6DAAF8B2DB82CAB1F98D07A3F1435A2578123DA93EA5B9C33601FF0BC8DB91DD4F77C0DD3C00BBB5751F3AB06A4E56D0708FE41FDFB69F7FBA9DEF7683861AEA16E9B86B567732184DA6DD3986B5D1ABB33E3E6676D58178C60D86AD0802779C077DBD4A1CEA40961D9562D7C59F167AAEFDB3113652A9919269649B33B9EB8D3FCAC230A9F6BF24581B42515AE4E742F2CB721A80878521624C27E3B598E8E49A47D3DE80053B825F4C009DF03AEEADE0D5699EFB5AEDE6B5D3D178E78AF75F59E455D3DCCD6AEE0E3F17A3762B332008AAC550E4248FA8325B1CFB8527766207563D1A40BA7FE4D432688728F3BC956C369641FB2CEDC5CDEED167588657A5D1006F13700BF075D3F164EB33A6CD36C26627869F00077E02EED7A1FB45B7464C9F41B3788B6D5A001AF34F1E01CE85D1796568B8697C901ECD30CA09FD0FDD2792275DBB4A0EE70C412E3C6D16AD082977AF13D648055BF6AA930535E201DFDBBCE85CDB31234BFEAF8839204F4048DAE4B28DDA241CD0156C3FA500096D3AC8D2D9A281757F2BB19A60C48A651833396F943991C09F4EFDAD06A7CB8209B4675B8A197E17A58DE0E1BD45962E2346B58B293BC5B77ADFA495B2BC321A1768BC68C13DF639976F3AB867056A4FEDECB202859554746EB369AC1DD319716DB6A0099DDE94E93014CD64FB4D3A473171E5206C3E38F5A702298EF93EEA96E7ED690BF7CD6C1BDFEEDD52B5019A643AFC014DEB39540EEF5E46198A649CA6E2CF5B386E938845C718BFE5D83DE0EA48494E7FBF0D039579D267598179FD680FF2269B7689C300F04B11F166CD98B768B968C842B7E72EDBA4D838E413F2577D83D10495FFC1E5A7428846D0E15FD1D245C9F40BA410F4BF8FD1070753C4CA3D60BF721C0F9EA9FFC100A6DF2A24E1A0ABA22DD2620E22E49B74D474D15E7691282EC899FF2ADDBAA01D90B7185D11494FBD501DC6DD4D9472CEE61792CE05ACA79ED3A321B2093F6FC1CDCE1FCFDA064355C11ACB7B3CDB859452CC4C8CD93CD153F718983D21A083EB2C243F83EEBEBABEB4B2EB03F318DFA3EEA3B315CAA51CBDDA8540B711D8DE8268DDBAC4A5ACD79B0B65A1CECA50A391BBD675938E237545F5F07A32ACC93EEE98253290CD9EA7A4A9FF40C22CCD045F084955220C82E93A2FB921474311FE382AB4410F7321FE9EB1F0AF33976321F675A5DA7F2819A5EE6237D2E60F8A9E896CE12F7D2D36A2138B5B685556DB51AF5E0E264FC52D84C0703FD9970007E0F8311A4D310F7B29B0BAB4616F7521FE9DB23D16E0B67C36BD7862E5D2F511F8D9715A272B045642E1E44D0C5640CE96424DD742576988A87E1F7B01B81A52F712F6D7D319072156127FD71FAB980BCA7FE887D2748D64F7F34055AEFE9AA3FA6023D4A7BAA8FB8875E98EFD197388D2847BAE1B5AB439FAC7F7EFFBEC98C0D26B79BEB367C7E0F1DDF561F4C7EFF72F10970E40DA6D1042E5F66E2B59B404722D0F5ED6A2D027E6C3681CD975878ED26D0A715E589A037ED5A927D29A56330EBAEFD8C6D3584CCB7A509BA9862BFBC054CFA697E0FCB59F40CD3EE66E64111448784ABE41476D2E179599E448883C51E93C1A3DDA40EF3CF649B05392F8D5BBB45D3A396E34CABA5D7F581DCDD88DB410BBED41B8DD77E6E6E645F6657B3D564816E04707B35D70F5F5203A3EE52D60B48E2D2C47735B7A861EADEABB6C940D36121AD063D6F4857495E48E20A9E4F58AB41D3C96C1057BF6AFDB398BB2D999E3318D64F55E126DDA0E56E9BB6E30C37C4A5DBA6BBDBE79E86C79D79DCBD097F08E3F810467CF78960E05F4046949C667D6C893F261FDDAA4987539E6B784E5D9F9CF588687ED787468A90933FBB84C9EF613A02BC43F72EB8F38290935C44D2D1703CEF0EB12485E13AFD0C473BA4C9D6DB0621122A102C1F89189221799D0DC78D823849D1FD7DF08214C32DC574C9D8A20F0CC72F621CAA8C8356774AC30BFA1B8E8E3AF845E831393F849D3444ECA4EBEC97E8992F0226F36AA0E76A742CE7893959E731D66ED2BDD7003E60F8D9C8BBDAA8465D03F07B80930EF1ACBF758B2EC40FEFC5309B366DA81F25503FEA43455758550A5974C3759B35766CFFED3AE800AC7FD382323F3E083778A2AC9E91DF456B8C153C841EE3B94CFDAE098DF35CA17FD782F63988BDD80FBC50387D4E0FAD11FEF0D2D48BBBB9445B0DD67CEE8312A3FBE060A48F4A237DD41B8990411FEF1674D2E2DD83A4DB435B39C19536103E9FF91C94D741036F924E0408150ABC763D59B92C91529B14488567566AE676D2E5B1DB6287EBF8B1C98A39CD1A7360222DF494C351995FA3F071860DAE58DE6D3E2BB519614CA061D3464AB33E208A2AB37E30B287FF1081B4C3A97DE0770FC9CDDDE751F3AB9ED2A39A1EFB68671AB5D43E8CAE47CFDE601FC7539EECCCBB07219355BFDB6602350DEEF742B055A329B65CF5A3A08B31EE3D83B4FB682812D327F06712E032A5ECC2338D4670394BCFB6EA9C277CB5C73136283118338D46703918B3AD1A3E2A29FA1FC0105884BB6D265039E8328D1ADC003DAD7D1CFE2B246D7E0F8311C4842DE8A2C12BA383E77716A5FE4D1D8AB74DBD8CAD9876FC55477808B29C512635BFEA087A9C17C8C1E0D1F10C22CDFC24BE0BD2888F65A7CD042A07D34E9B06FF40C22E2750ECF8AB06D5E1E4DB5845F307ECBAAC769AD461BA894E2CBF60EB58D1BFAB4323C1C3C4FA73108516B75ACD20B37BCCB6EAED32E0E6AE69B768E0EA2CDE7857B2CCAE869FFA5967A71193EBFAC91F7F5487F3C890F0A326E5DA5667FFEFCA97032782EBDC329D261D654408BD8CCB963A4D0630B74F02885B2D2510F520A8A8B2337B6E0775F87F1549CEB375D1BF9FF503185CC0DC0B4227EF60012CC3E7B0109ACACB907C2A7F1CB7FA185194D3B777F98A11E8AD98469D13C5718935F07E25D510D00F3EDA3FAF9BE6856934868BCD0752D865078D757598B2AEBADD78E28D7EF53EEC660B10A164457AC7A8FCD9560DD9384DFE2C2B8FED593F5FA651EF6D2885CDEDA043A9B8BA0F76E3E7C0661AF5F096C2E676D0520B732E16D96D7222FEBF594DA65FC164BA995F5F5914395703A3C0F55501099F082236EC99B1E02003BB24EEAA14EB1FCF418D3A8C6763E940C4732A7AC917634524825C0C6CABE92E81183ECA76AA6C1F4F512DB42B995A945CE5301529F53D33857EF519FBF26D35BC2C55D173494A646B8564B368E926CF52F72E3AE9655D57C3FAE37A750516F3E57C032EE79BC9F4726E786DAB0354BEC07540CA997CED71DA545E03FB00671A0E2459317A3E39F5E55AA2899F1BBCDC396CABAE761F6461D22D23D66ED1B161A6117ACA7020B65BB471247A46364517DBAA8DAB0032DB7AFE07FBEBF572B259DFBA3BD8028036075B0852FB607F4B222FCF0A9D83DDFEE4E51E6C72CA00CF78D76ED185581E0A1EC4BAE595F968E16AC17CFAD695E44AE19475E4B5EBAFB1083AAFFDFC19E7623EFB74395BADDC714E11441BD62986A9CD3BC3006EF730E515B550FDE6E572CF57CEF48CC5A28BD964315BAD2FE737E5A9591B9EE95E38CA27590192D0140DBD10A6D93E38546790257441170D2D07AF72B5A75FB67ACB83B3D587E3F3E0F806708689E13E33FDC849CFDAEC5F76674CF8BDF2D99240185FB79E45A4F42EA3166A7E7E3D95E7767E86E11E273D95CBEB8BD9C2EE60CA40289F4D3910C9663A0CD77E3D46AFC7487C8C265996F801711064CE52E346547A1165601DEC2028497B7EB5BE999556E78BD966325F7C78DB3947DA9F77CF101F00E73CEF3A4BAE3932D878E93DE4D581337691120EA5EA3B85F7ED382DF7335E27057ABBA8CE98813EEF3852723B684D699AC43B1210F9669E5D1561F8DBDB3B2FCCA0D355FDF51D97DAA93EF56941D82028314CBB5D8EC7B1FAE5F8EFACFE0113B1770F97985767CD776B524A9DAC67861EA6109713DEC1CFB81EC485977B5B2F836597B76F6E7042821D4C7F7BBB7ECA7218FD0D77F8DBFAAF701A06C41C5C77587A717007B37C937C83F16F6F3FBE7FFF8FB76F2661E065382F5E78F7F6CDF7288CB37F9669CD70C8494EA6FEDBDB7D9E1FFEF9EE5D59DF3DFB5B14F869922577F9DF10437AE7ED92771FDF7FF8E9DD870FEFE02E7AD7FDBC02AB04E5FD7FD550B26CD77243A4AEE18ACA26BE0FB36C011F60887F6D13E7AF5F214333352DADE01D1F04870C7F7DD705F46B87D87930F01FF8E0E71593FA02116D60E3F28D97E730452B3ADF41329FB76F30F562BFFA2305BF930E87FF5B0F103F78B88C51FA3F22EFFBFF4343CAD36EF02BCDF7A5AB7A8BAEAB724A88523393456D4130595106C080CB49D5A32D47D906F764A02E15FF731EEFE0F7DFDEFE1FF2E13FDFCCFF0D8EDFFECF37D7586DFBCF37EFDFFC5F6D0C2E8EDA88CE541530A0BF1521C1D2028BC33191A1E14AB4BEB742A4A9CEA98F44FDAD0D02EC63561B8F2E081B743ACC459F4218001AB4AACC33A6ABF567134E21ACC5DACF238484E29A41488F862EAC96CF52090AFF9D0798A7EB9E14DA5BA984555D076FDF2CBDEF0B18DFE7FBDFDEFEF25E1772E735648766E719E4124F2A4F6AFB3AECC035038CEBDE23195F06FA272BD01F87815D6C8B742B05FDC110F421C9F2522727DEC58FA62B42919A601B8D00FB49816BC43B067D48832425CCA46607B92E081CCEE6EF5B4CA5C35194984006EA84C172F6A4BB60B688ED937087D3B5E184CB08207A601DBC6067B15E0460103F24B856DBCE7BCA6A5859E485A1C96CAB846E20F3A203FADFB720B7408F7259D6BB9F8F1FDA4809A518D8110E34EFA669799F7C7AC2D2F77C6720F77420D84CE833EA3DD9ED5224BA0CF9D6C1720B98AC661373E105CDD94A8269BE1F568CC103C919F77B6D9865622781A0FCCCE47EEC9FFE00051CC05636069BFFDCCC8C694C180EA148637CDEE49AC0C828B4346672D5AA6B29D6B315D84C3E2D8C96957AF4EBAEA8505F308462A2B931FB17531968DF1E7D30E20459F62845D6042AF19889D1D586B385AA1E4CCE933EC211CDEAB8294980FB248625F7EE13897F31831D17D156FE62D297B5EFBCEF03E18C210F8171946C83D0F58B833CBF3EC88F9621D48FAEA1B69E730A17B712810DF390A3DF706EDE599DD79BA3C75B9549D3F689137AF17D8163E3693879103F9948DF39E271F8E6285248022BA5EC4A5FBB8B7362FAD2479D12968F90E4C4728E60483E740F97F03AE7501FB08571806D3AE0E78E120168D37C9972288579C39F4D6E525C63CD1A8086906D2FA6736E2A6C42056182A4361B3024931381E2549BFBAA197681677AC03931088733D6E8CC1EBC7062F9FD27CBEFA796DFFFDBE2FBF5726DF1F5214D729291C4E68C116FA7587AFD1B88EEE5A12D7326370F2CCEC5AD26A184494A1C1ADA7280B15612C63B8084698BA527205A6F1E532068B1777E72B051737B8FDE5359B2DD09CF20E0306A4E80E53864D98640098F418FA94300330921B9B433AA4CAC48C33EA154890692CCEE86DC2648A24D3AC6044364A202E7D5DF23991B02A26D48521B73421023F618ECAA1B9CBC332C116C432C49BEA44A3B2A2582463DE36A056C611EC1A15741FA7410B3691560D335200E3BF63A600FED4459CCC5CF80E7B776C5688F4BF55192EF8562AFC62BD4F6BD58391AB638B3E9C92CA2C84318B984759F26C5C1FA36AC12D0C8ADCF065A90EC806BF55A49132481281237BD5D2414FD55909967B3DAC167B6131A0D95508A12EC0FEFC338736DFCC69077F0011B4B1B1947C384C6D15094499F70894397A23AFC0B9425BC2D76A4ACD17DB35EAFAAF2DC365C8802365BDE5C1DA1C50E9EE13E2EA6A4A1D35785D9BD109D6D4D810B64FB5E9A065E73EB18ECD04DAD73C3C607F0AF2261BD3D9CDA75AF9737601E3FA0238AC58FD2DBBC4A6D6AE4D26AE2C5CADAD05D9B88AA8A3A46C6FAE3B756BEABC794A6953C02FD80A4B4B849D15F19711DFFF00F3471DFC3203FEA920D93E1749861A854A2E500F6BA3C92E954DF5BB3FACCC6908D881DFDEBC2C1FBC8D81144EEFF61634C9756BB563BCA923254FD67BAF5F1E0875BEA88AC2D99B502C7F4C8B2FDB515C7A06A4EBBBCABBA95A7ED28BF5BD9D766E53985826DC0B5EA9E8B754D8AF6F563D5737319B65348DB4EFDD594D1B683339C0ADCA5A27E400DB8534D7DBB84B654196B60E28D0EC7223B961A340C0AF1E7BF28191BFFB3800161C2683D52537E55D7E376BA474D696E63A5021DE26D0C842EC46D77EEF8A5B78D9F0DD202DB25D42889E19315DC4E256D57600F9C6AD9C388AF4A85B247185A50247B84917DAADEAAC5FE1D12190F5273A16F1E1186203A45B2CDB596DDB2D8C690DAB5B04B307761E219026A0A60DB83FAE80014A7CEB595A45D55B936DF387E456B1B78C742D676405A52A719104EB16A1B704D896A37778C4FD7A2767513F874D9692BA08212D3762CAF5D56DA92F4D93AD2E62E049CB2D1C6228EB040F430B713A75AB439EA384BBBDDDBBFD907D713E5949EB6413523092CC0627361C88FD555C435412CF0EEBC1895F0715A66115CCDD7564A9E09B9BB8C50A83FB51A7F3CCDA568EE7DFA57555085172EC4EC4309CA26C81B0FFA21AC2D552DA1CDE4EBEC0A5CCED79BEBD57F4C4ED43EC888B926303859F4B7C39E30B6468D9E2EB5FBBD15B1416CE262743CFA4A8EE68A3153BCD017BD596684B6E7802BED92445FAFBBD2C4054418FD65A655E2A9E3073313E8812B0B5139C00B90A2A91680C8C25B933871A3126A458D9CB25AEA5B77C20F294FC5F23127ACFAE8B9F2B2A49EE3B48C2E7DEAEB57A9E7F452CF1AA681172E71ACCAAAED5E60C23E9E890C35FBD7EDFC66C914625436694B13302BD9B5A5B788EB039B913D6EEC0DAEC29BD165EF1C28B1FC04879C52663BB259A3457840D7C75D9A4476374714E59EA1699FFAD48A01445E8A4BBDBBF0F4861E130567082A39807D9A610F229C32C642078300ED026CE26876CA1CA59476E17694EBC8598485ABE08ACAE78120662916C194F8B1FA4F7E0805EF2ECD8387B6D28B114847089653452B67078746CB1A58A5E6CCAC9587259C1A373B60446CAE7C069D5019F648C8E44749FFD158691F1D508630AB8DEEE325F13DF7F7CFA1C05032084A366971A0684898525C8072411E4760B486C2C84EB283879442C828FC030958F93EE9C992A20BB6F0FB323918B8A9BF06233BC493C8D61D1727132690C27B1DD95609B5344D529A7E4CFD7EEE4208FBD46C4AD47C208E9C9E5FD6C932B61D5E7C5A03953786FED9D8792088FDB0A07D5B4CE26B09393809192E131A20EA701867EB161AFA3B48764E268B1183DF0F0147256882595EA4DB042BF2ECEDCB719E2621C89E326B505E88A43F2F05E5B259F9F561E90DCB5A384CD9C1D32C4E0099282E947787CDFBA03CAE1D61C95C9AEB82CF2AA99FE844DB62B113F4BBF05BD3703382B37750E953C0771A55092D697F6E13625297BBDCB9C83AEB6765C27407A076A51B9783B516EEA3F5BB8C85ECEEB921843D00D6F5C1A7401B5F365E8C3DC19CA42C203574713873914420C82E9322152531308177C13C83AD417EFDC33592D3EA027108F27301C34F456A25F1A00384C0028590419C7BCED421090F83DD394718EAA8AF1973AC13CECD81F6F3DB2351C88E30816AA49196EB0E9D0FB0450764DCC1469A5D2991C2F454633920BCDAEB73242E540F37268BA8C71CEF8CD5238E4AFDF5A063126599A1028D82F317DABEEFCA04134783AF8394156BB40293DFBF5C7C022D51C2F52A34C374C5A0E14642D2D1F5ED6A3DFC405D0967B891A615E10E351292D54B111D0FB9B6B5FFB4A0B9B102B5115CDED21E620E91B4075B46B0813088BF01F83D10463328A63E6D800511298CA2AFC1D2F5C95D5C7F317128A97C54CD7C495A1F0FEB463262B1361DDF60EC31D263943406EDC2C3EA9026A8739425E18355E6B712276BDBDA6315C4E5875E204A45A0AE53B7D530237229EE40E58FDC675BD6D7C8061112943208BCC872D192F45B8229556EE0D04FE3FE6AFC33C753238F8D91A3DF3D344D5C730F392174AED931BAD64AA39B630FBC0017E822BEE4F63AE273BB32905410174DFA3F03B6E7248D0482E13A315D15BD67EF81F4CA901CE25906A4C6DF70E10A2AE0C0F6D6DC163E76FF7C0C764D2647D7B1A6B8E639803B8478BE0FFC6F31551CCE7946B82DD826396204A30C85B3460C3F905FE43956A68DB382D1782B888642C73A1D7E209AC8FB32A1EA0B5E1CF2763F485C4416D74406EFCB902E32FE50CB7CC0690DB2362F31F1242CC1B4713587C35097C9FAE56970B09F5905C67A66151C1733BBC3FE5FF9D3C1854700A2517047D55E76E922BF27158C06E3E5B868C2A02320608841DC176A19CED42022A13D2F0E60DF36433B8C3A44AF1D305FDE2C6644DF3DBF5ADFCC887ACAE409141C53E318BE841800433E889AB19C286EB8AF3885174BFD9D5D840F8EC8EB5A5A4C1C599307B4BE61087A9DF73FFEF2776DE0BB00FD0D60FC10A4494C87949B608A952C80AE9C6B0224F2FC7D10431B10B62860678E800E20300172177AA26C4D8AB90A1AC5805110845D1CB959E8BE168FC369C7AFAF7E301E87794B935DC9369D4115FCD7AA225144300DFCF615FAF7E315FACBE8849C4AB3A9B94A77D1617E8A1A17A7D74DA377931194C2FD2304647521E17D04C17D8CE8D9AA30881663D16208D79FD6B3D5EF13628A5BCDD6B78BCDDA841FA4302BC23C336406EDAFC791768C88C42169245B1C354A46E24C5C011906805DD2F33DF4BFE910A93195CD97932F4625D1CB8785E1751375CBE00E425F424256D84FFA5B5794050EFB24A7AD6FDB20F6D2279769213ADB6BC43D3867417783E5C7C9F53E53A3C92EC80F1FFF61B57B210EE8B7955774EBD15ABF995FF4093FA31BE4E0A55EF9E2C55A2D5D4CDA5FDB19089B498DC36F285ABB99AC26CBD966B632623CDD25D4253AC916B826BC66A83EDF9DBFFFECF484376B3D45EC7D33B9329310D1031F3BBD19CB88DDEF4759EAF33858F63BCE534265E889F8048883CE006F8BE66258CD2617F3AB2F00FD6D9674B3799AD5CEF6902A76A97F4FC8A03D234D2BF562D52EE2457F6B45A1C33C4C17B760B9DC4C4C88A595674A97364449AA5C938271846C6F6CAC624D4F6E451695F18F5F5A21C058E19423849F5CA4A425CE9CF7ACBB968121D03BB4A3821BE714953CBBD5C73681CEEE534F29E62E50D32ABC3A4639C4D3CF808843B9F1C8BFB959CCA713539B407316B4FDF185A7C8796AECC341C7895015669F80F6F1177D1B002E30DE5917775BBD9C7C357AA1533797F6E5CABDF486B85A9DEF3006DA1F31A12F836F33F7B5965F39AE638EEBC077D9F7ACE2B2EC8A351D2B66D82470B87554657BF394DA7CBEB28ABEB97CDAA55E1106BE058C4FC94EBD9493323BDEAC26D3AFC4383F596DC0ECDF46A11775CE9BB21A24FC6E1A882182D3F64970CDB8CFA6FCEF708F33A5C44549129AD98F9A2F6DC6775310AA4D42A4463AAE0606CAF49216C9A1A420D5E7ADA389A84EA599CEB34DD3FA3A4FE19918ECF8A93B73EBC0752C396511BA99E9AC90260145A5D89082BEECA4FA2EEC96A96AD3E4BED907D352C30B7827123A949020A5ED749F9A62385233A9BE5CB60FC25D72A0E01AC7D216611E1C421BA1E42EF80E775E9414424F4E4527676711847E622565DDA74971A05E26B19B4D83DFB1FE1BC9E9F4E5C2759D6BBCCFCD07A163BE5D0F523135633566F77B3BCF1D0C2C7E8ABD48CAC50CC2118AE8E07B07CF0F9AEAA5BC63A628557D0765C9D1DC1A56128499878F0B4E1A8A9D25421720FDFDBD3B78D8D803821CDA3C574A180A182903A362B54CE1BCEA175CE2B94D1EC3CA12DB32C49AEE4E23248334797408CDCFB12604C1A00CE2DC25B01C232BB6CE87A8DF0C3898432E86E867CBC864F6732551B1D649D4AE41207B8A0EE80291869D7CD0C79408CCE542D88A74FC82CC26D6B3304C1EC1AE38A0F95307D52CB10A4E06BA03FC27939918C5CBFAEA4E055F6B7BD07F4A378985B1E5C5AEE4DD20EFC91B22F74FCBDD986B3B28743EB7D1684CF15BC11891F6D71A829A361D6CAEAF17E6AE93674802E66B6EB0DC1C55739284FA63975FD90D6C58898FB341D8A7F5C2CB3DEA2E50F6A8E46C48296F3929814850DB5057F51025074BB5383E1846FA70B495A62AF0E65355E7260110BD67993A5C5A6965F43E37B44DFC71BDBA028BF972BE01D38903330551E4864114E074A96E2C165C9063A84E4F6DB92897C1C282D0F9DE0A997D8024DABBB0F478BC49824639D69370E0276D113A0059887EF930E000E4198E2BFE0C390899C5C7316631D820D168BB1E0DBDEBD118BB1E0DBDEBD118BBEEEDFE44DC05E0F440430D4156C9FD234C78B9CD374BA7975B9047AE2FB706E4EBE536F2E556151E43676A0F62F83814D13FE29C61E5281FDEE3625B3E1C8EA152837D1C73B09FC61CECE73107FB65CCC1FE3EE660FF6BCCC1FE31E660FF35E6601FDE8F3ADAA83CE4836B26A279A753718B17B3CD646EA442A063B660EE05A6FA04119C012FEE330A542EAFDE220EF8BE0DCA97F711821D365CDD8EA2839DB57F9D42191851F23DD57C60717DEE28575DE7E3E054592D2514AB80D27EA0E2EC7E00115C56A47754F6223317AA3F4B379056CA40A368A81CB88396426C44C536251778B983D6AD25C0D528FEAC6F74EC5023BE144C2852DD904C58C43E4067B913D26B6601BC9DAE4902EA3953A645815F341F0FE098CA5C72C4726414993FBF30301D5D0CED0FFEE5B619C33A81A8F4FA8D1DF8B695D94776CE4C3525BC4E0E363B5BD2710D2EC812E89BC65808C3385C2F935D1142B02EB626D45C7D9D155B43598D01302C9DAF3B35E0B9ACD7C04A544DA3ED4C6CC002D7CB5B3B1E3AB50580EB6F79242F1F2ED66007ABAA36EC0456654EFDF464B1BA8A2659A5656AD51632596702C0052A6895ED9676C412286A8E8AD99D036982892C3204C3A46F30ACD6DE755F364687B847BA209C1A96D59942472A6BF2B2098CE3FA6509E854D05CA01F0DDC07CBF226982B21D904C9F309E5EA6B7974EACAEAE886F2FC3D2D479801AE786699992EB36536E5CCF1E7B3B888C8F155F7B55096264A017C81E30D46F7A91A4C60307F91F4BD4794C69F1011D068FCFA53ABF16F33989ABDC7C8870EE6EEC4810A812ABC70218EB31CD4D74C3D8F5747E8CFC01ABDC38C4E531792D1F1E201B17BC664963441D6C3660BF9EAEA0F404169ACE2D0A8077E0455C58BCF377F6E05FCE0772F0A629DD8959324B4A3CAF099C83D487272AB8FEE2DFE61123052AA2933EF1E8454806E8F32D4629454A3D48FE5643A42A19B08A9CE4C061963973E813FB1AF5A36E8A650C30CBA2B7738FF28C9DB31E46C9A51069D4C76481352D26E300A3B8E301C8105D1C1F3A571AF4A5E76DBD4CBA854DEC621EF4990E5456A0D07CDE91B65CA349E160E02C3DDFF809E750064E1F76573D0DFBD12A6668AB797134BEB27F15D9046AEF03C42738F69E86579E9ED7A70822B0DCF3DB695059D6BE1E9EA95F49722F1FBAB13E883DD959C525ED0DDE48421D6163BCE84F748B1134E1215A55514663756F9FABF936D16E41087B345BD9A43EDE9A530845EE6E8541E816D9F1C530CF548103919189933FF2A90746E9FEA168708A177583CA8A8440D33A8AC546AA72E4BEF070B05DD11C260CA8089B122C0B3510278232900CEC8F7AE9A32223074FA708CBCC2AD60C08B2AE8BD1C449F8DD3B01BCC4D191D92F551DF086449F820AC76756279CBA154789E79508C9805D84CBECE6C5846EE7D83968C83063120FB10B1299594F26ED9463961F9B1D387A7C322F4A1F73DD44C189C574B304D4EB12889E1D329CFB62B0E64900B13E72C31AD024402C2887D9ACA45A37B1E0560063C93671307177B4C420123017AB0B27014996CFE736394CC84CDAF6748208C8BCB90B48107D34974A90B5BE365A6666FB1CD5D8584A99CF8C5AB53518F54E1D01DC9098F759994D341A6519C4431B679F01EFA52CB2A69FE9DE43B8D82D86E2EF710F1FF6E256E93D461A50F16BFFE88E6959C31A93D6D5CA43A39CDD8EA3EA6D9611B14B37D92E6DF608FD6C79D0051D7A0C7B7C3FAF693F10D519774C7CB62EEEACD87D2A581172B4AE410E67B9005FFDBB1C1243EBA30BA0EF2791C0C32BA7C02B9B5FFE56621D5CED1EE36E1C674B29882E56C73797DE128E5065B6B409733E81630D03D7972F02A32BE8D88BEBCBE9819C543D3AEE7BA4B2AA83AE8BC00141EA62777B94909280C96562DB8029C93F8D276925143C1EC7EEB0C94F73D84947866084555DDA1554BF0C7CD16DDF842216610444564215C52B082D8125690DDACA736CF1AC219B01CE24A0A17F01A4D38C2AA5DEA933AA4818F03B443F8D041C87476C43314A41027ABDF2171B113E76C0A7689D1BDA232645B5967EBD0E729A530B593D8D4050CC3178585B2691C2D53BF7AC9E4F641C006A86C788E7AEEE7CBF7114373A14FD886C9D6098CD04BEFADB1D9C13BAF08D1BBBBF1FA56516728F381DBF56C05A6ABF56730BD5D6FC0EC5FB7F31B13BE50AA25B32CB837351EB210DAD375CD28848A5405EDC2F15BBB92346420732C5ADFDB61228ADC55C1A2FED62674F8CC22994B3984B626188AF6DF203C80C720DF97E8D9094ACF820BF71B2A546A44324006F0B1C20CEF7A395B1999DEDA4757DBEE263BF9CE15A968B0BE828506B20B4E654B6B60549221A94346123B8472875F93EA2E0474B12DD2AD86824219F201C9F1EECB2456EBE1B18F0E1738FBD840953E0DB21CFB241E04E728D906A174953FE8471960C077DEF721F0C509C84229BA668916FA8E8711B647BE442A5939B0A1A914DD7B2DE07EDAA71321FE248D740ADB2A3D5FB640E5FA316489F88AF8E8FA8ED0F5F8116087385488555A035E64ED219C2F447B8CC12ECD7A84012FCF66A106BA44EB0186B94C6BE8DE6E97C22CB321CD431A445EFA04422FBE2FA8C4A786CF9B0CFA49BC73052DC880E793250407EFC9D25F053B99C8A46CCD07A1B74DE2F0C9061F4AD8B256B97368CEBE02355971801E1B914DC6A230B94F7ACB3919E480DA0588CD057EEEC26C8768E3310345EA223DD8B6C882189D4A503A48C999B0414CB48FEDDEDF5A3E882645727D624647F2784C2E7AE87B99CDE9EACC1A50BE510EE2D5D05EFBB4DF1CCF26F28BB9130BFAE71D7A3FB0C959F5C0ACF7C923293162C59133881828F5EE3071CDC3205A6F0C532068DB767E72B0E17337151FD93CB145EF2CEFC16912E7483A1B0234E17A60F6DD8770D738EA3AA6BBC9FAE7F7EF41AD760293DBCDB51D0506F14312F810F0DE8246C70F33EF23EF8FC88DAE07E002A2A549B37D70D0CF38457F6BA5CD3E661CE5E740D33C17C516ED7E1434359B4C7C8151EF495B7A1B220B59B382263ACDF6DEE9AA34853BEF5A9D79C5D1391A11FBF5634CDFA9CACA69F2DD10256EDB717C8606FA3AC8CBDC4ECF42E0D2BD4EC819B69DA7C16180540B7488136DAF31923A95778A984997B81EF5E4F662BE019773C4D3FF63B25DC42C34297681698C1703605863429FA14E139C1397B7D35B72EF0218BAF639D9422CA74FF7E86D2D57751B9858BC3B44062E40EBF9195CCC268BD96A7D69E6627086B5BB4F4F79BBE3B5ABC9AB95776E7273B3984F27E4529AAD56D72BB0B8FE62949CD260FF82C1F304BBD0CC1F90A4ACA0F2D0CF8892A6498FA6DF2099367A437DC37EAD5274FFD10BD9888048D4EBD5E7B91101213C038C4DA96DD025A5F6D74E59F5831716BD70BBF638C5E3AD2A38B9DAAD3AE664B2D94CA697E0F37C315B6F56B389519DD73A74A34CAE6E17A4DC06322C53B82F1AC623ABAA6311C8661F94E8A0B401B7C69B1146F5EEF05F0DEA017B0C1C1B372E47B1D290E8D7DDA4F51B268F5D53BCA057F56E6211654A2358566D92E47DD2BC78932CA079A33BBFD80E1BB44CD1C0391D965CD0C9EB9C0793433F4E83EA66FF02B757F5937965FA6666EBD719BC9BFB8AE00D1073876B4D55233B783D97009BAB8A17D5621B6BEDD68F57FF6E294D56E8EE4032F651CBE324968782E9C43DA70107FFD2F5D767C1A5705B04E18E8A2E349D675591C6C924CB9939AB0DE6E34C5C85E7C20EDBB95A5DB999794886B03D14CFC60BEC79F8D435E70CF307FB93D63EB8D645D91AA655E6480756750577895F9074B0C08B7780D8E4D4BD334CF4D9C4FA6094B4AC29A965957D54006624B5769502145629404188E4031757B5642EA626155295C78925CC532B4FA201CA3A0520767A012DAF174796FE472F4DBD387F027EE80511E8A9286A6291E2703E57BE862E13050C7F2B399AF545F218973859805566855F6657B3D56401DCBD53ACDE27E765D3D35008C9DF123AAF924CAAFA34A8638356AD165F295F1F43CA77290EE3C47595DC6FFDA4C34A1610501E8926CE6925105CDA812AB869F10E398022896CE13CB39CD2671E5552EB80681F3267E144443E6F550AE278EC2AF3028055F1C0A166DEF56BB65A4A62B471FDE8F9E6E2196A9FEDC59D5AA28684454540FEB4F2706E8323BE13E00E49C85405272341B40597F84DB8077B4893ADB70D42747923E07EDE187D5DE7EF6B0D1B057192A20BE7E00529C6E1810C30CAD0459CF97B88B597BB9147C609E48AD0A3D2F11AEDDF2191B13425C1812A886A08E268D2C69CC7E2EC94F79E8BB880325FD67B92ABAF067317269E212074E93803F5D10128746184F9CEDD85B1FF766DE5B48F0034757A3769BBD29C19BC153C84946F88299096106B06E473107BB11F78A19B89FD513DFC5DDD310D23F9E0EE2668807EB4044A76D135CB23C65637AFC4FD375C45E90161F5D99EED20B1AB54DF326F662B05AE5FA4042EF1EF19EA762AD9D3B6D8E134CBA1B8D0B912EAB6BA7045DF6F155089929DD3C25FC0544877956B4F68E02DFC6E966CA729BB7072700B357DB9C599557040C612C740D57D687704AEE2EFEF3FBBF24CA893AE5F5FCDAE3636D9D64BE661976B9D8631E02ABB785762946D557DC936C33A26BEC9C58E111A2ACF9C99CC2B8131837971B0C12945C26704BD8C7A799A040223968C442A1092E363B1C2241BB735149CF8D5EE215D29AFDCAA5BF0E33442D4E8CBCEA2FECD3A4821A1926D9DB74FF54F1FB5C95DC9A7FA27ED2B5AD1A1FAE32F7F77785BCF7E47378A994DFDA1B4FD9B9990E88F8735212978DA5AD5F4D355EC3EA87875A92A9E7B5D76DB3288AE141A1711446C50490A55BC297C6C3937B2131BD0B59DD0D430582B5A17801996EAC5C29A21F98B2B69AB933D7FEACE37FDE83264E72A64C7E0F860C6721572B0E1999D9CFA8CE865BEBC59CC4CE9A5293067452F0230C333891F8435CCAFD637B35233017E9FCFFE9819552A6AD43D197808E02334AD4E240434EC862BABAB4695ACAA05185A24985F6D66AB9BD56C53C67B22D160692AFB569297B9402064D2E72AFDAAC89A1F3EFEC314AE1B81582D7ACB968EAE3FAD67ABDFABA0E1F9DAE8D61028957429A95F37E59A9E68A5A7331A286DBCB43792118996609C50D2A02A91F5F472B644F433B57B9E883541BA64A4A453724D49CDA08E9C31FB2C43836CBCD816F96F1B346A20FF1988873524385F4EBE18C58F76F7CF9CE88637D8388E12DE16798E386EBD498DBB0DFC3E44709881A73F4E22D91B6FEDCC31FDF88002D3C966F6C5D027BD7902F968DBEFCDE36785800624B1E348BD56410385F311786FF94AA3EBB7864E4A49F7E2FFE1EFAE1851BB9AB4450C7B60FA0C9304040C56335AAADB372849A25BFA5751F9432AA1376E80E6B1A529709F3A7D9FDAE4813EA4C97DB30FA66EDF0B7867EF17641FD65EC3915F20FA3E5041B84B0EB93C805F890A8A300F0EA148A452BBCCBEC39D17D169974D5C758EB7820B4F1D2B4BF77D9A1407D053E2587FD3E077FCFA85BB96AB568F09C77C100D3B9169EA4CBE44AF9EB1E7F8BD5D053AD54A31DAA6FC223AF8DEC1F383C6F5D338A8AA09D0CAAD6125419879F8B8280558A982F4F7F7EEE0F5C59029477D9D6B08D999673A78267923B6C963B80BB243E83DB522B64D77A7F48825115F69F2E8109A9F67A4A8156659D225B01C232BB6CE8718324E2F6B6D9BC11AEF9F76A95784810F2AED30C89EA203BA40B21E54B557216B12C5B9491D662F1C22B24C1EC1AE38A0F95307D5A40643EEC53B2FDD01FE93C9309190177F23D5839CE4F9133FF62D1CFFF81E58FA25F1E023200539ACDD1A2D8198B86A1A3EE86D33D351D29FE1BB9E2F3F0EF4B2C783E93CC374616BB02BB527BE2D6745CFE89C3C052CD84A7F49DE13CA252E5F8C0E9EC158C28FED185B8FDE63BCC77814C47673B98779043117B3ACC55615897291B4AF1100FA2C5126172E1BF8649FA697287C7B7343BBBB1C1C395AD95A0546F1B4A94753F4EAD617294AC59F6DA5B0B6150E74D9941B54550C32CE4C0ACB32D26D5D6CC1659941D584DA2A28385A6E1F983AF571810C4B776B98065ED8933A4C7F07D7CB5B3B3A9BDA024018380B6E5F6C2E9CC13A56F4B2E0F5158C0B0732CBD4E1F36CE634F9D654C183CC200DEACC5528AF9F66772E04BD6ED8A2B1200B5DE49E35921A94D9ED721B828AE22665A26EEC78808B3E7B9151986AC15662913D11EDAA370C514A41560AC2D462FCE31667D00379EE35155CE9445F4B2A2882D0E26357F0F178E159050E09BC51B81F6547714DA133BEE814BB4651EEE9E0415D7E0ABDC9548FD9F3143E28936801F4AAFE06E0F7001B8E7599B5E3EA7E59474E76E437536F9153A0ADCD547D32190938EA51669DDC8966611F0C5170D5382EAB5119A4644584F20077E02E4D225BC930FDD609B832D4C1550A7C9C7432B704951CC03ECD00FA09DD78366F1804688723102813B8394A695FF94703678B9CE4BF7451682276A35EAEF27B12C4EC280B2FBC17FBD011B80A31344F77685903AB125E599754A8E0D4B8D9010BBD0CA7E5F776D88AE98226B0095D6A983629AB58A93B1C504698F8DE009ACC0243C9202899918D844841DA51378A0D282755386B60D6C50776F0905208999C4A88C4A87C9F38F6182DFC3E375F032FD4575F288778A6F0DE753222520596DE7753DBD95D087B63D195A8F04052E87BBE0F0F3666C18B4F6BA0F244D0A7E99D0782D80F0B3AABB0993F0E2EE0E3C26E7917A4E416BB07EE6424B7D0D0DF41B27332598C18FC7E081C697870F86D8093993EF92174A2C4CA8B749B8028B1F6FDF293384F9310644F9C94889AA0BC10571D4A41B91156EE4758FEC2D252103B790AC5092013F5FC1CDCE154ADA064001D71C75C1EEB82CFAABD26E6D2B660EB04FD2EFCD634DC8CE0ECDD51FA96BA48D4587BA9EE9CB83864A0D451D883DA551912EDD74AB80FD62F2316B23B815F087B00ACEB834B8136BE7E388EA5A6B9F0214213F1BE27ACD90041769914CD13C5E4E2EEC0BB601EA2D620BFFEE11AC96975013804F9B980E1A722B59281D0014260EB07F8916838A9937188A169EA643C0CCE943AC250478DC998639D706E0EB485DF1E890273840954238DB45C77E87C802D3A20E30E36D2EC4A8912A6A71ACB01E1D519F847E242F57063B2887ACCF1CE583DE2A8D45F0F3A2651EEA117E67B340A4E7E662B3D4FD63FBF7F0FA84AB9B79B6B4B6F3BB40293DFBF5C7C022D51C2F52A34C374C5A0E14642D2D1F5ED6A3DFC405D0967B891A615E10E351292D54B111D0FB9B6B5C0B4A0B9B1C3B4115CDE022A25A54324EDC1D236EF203A248E146465483CE25C7DFE401FF5AD477F26DB2CC8FBB3091980264E8E8E611E7CE0B668ECE11839AAEDC2A4EB7FD429F0EBB8B02FDFF1479A4187EF5B44978255E84F85EA2B2224702DB2AA4CECC4F9D22E31C39954CE7558FA7490F2CC3F4E51E5B34E40F15AC3F8DC6B18BFD60836B03FBDD6087EAD116C3DF46B8DE0D71AC10A805E6B04F70278AD11AC08EEB546F06B8D606531EE47AD113C4E955BACAD21871A34DCCBAE9A8C66E8956E9419FCEE216109CBA78AEA9A0AABF201A4AB8431AEC261A35F5003775C07D5C78D6ED91127C527C495B7D434D73D2104264FCDF29467DE3D08A9B4C73DBCC4629434B8DF8F300C9E4C4715E6E6C1DB99C92063ECD227F06712E0DA59436E0A35CCA0BB02BFE3AB3E8EB17964C0E950C30C3A9DBB14FD0FE0D1869C4D33CAA093C9D023D7C7C18B831D98E308C39D97203A78FE71894CF53EDE36F532AA448C715EF424C8724A0D630AE7D07E5CBCECB4C37E12DF0569E44C375B43738F294442371D18C3DEC2DA848773B9E2EE7FC0C611D374BBFBA3B5F4A75CC2A44B94F093A76AE717265196C44C727053F69E8237CCCE8381327FA8C45F1AA4FCD895ACD7757458E1235E194BE30CF5813E52D46FA87714D72B55F9FABF2B7F089CCFCAB99C9DC2107A9923FE7604B6EDC9F0A87F95362F9E8AD2BB2B61942AE6AF22C935ED44568F767001732F082DDFEE3B0244FD356EF2EC2FDF137AAE1D470F4685BE24B734FACD475BE9DD331BA5F20D56515B290B5AEB68AE3370A87E6056DD4AFBA0E0512A52C429C167F6709C71CA7D1F682C1799C6AA0BD9A52CB6C74EB100515856A47794B9C12C29F39F65419D3DED696B32CFEFC414EB085A0A71390AEC2AEF022F77D004F78D9EDBA0F2ADB1594DA65FC1645A578C36AFD6EA6972FC2003BB243650BF7A6E78DF717C73473391F6D6DC37C51E50E9336301C05D3A3BC1ED62A29328F1C99FECC3CFDB0B0D62F86801CC6EA51DD994FA5F623F9BE46054D3F76B803A6F7FBBD7F429BE15315B27FEA1FD6DDCBD8ACAFBAD2ED8F2C7F50A97B45FCE37E072BE994C2FE726375D53710A7B1336556BC03EC0994503C36CBD8A60A9151AAC84ABA38705166EA5B939542B0DE018FA2C4C9A1A313D72F84FFA36C514811B768C6A1E442F4767EF19682E8EC7B13F715FAF9793CDFAD6E989FB96445E9E15AE4F5C1BEC0F77E2C831006D73926B2A2DC7286975E013F7CA394ECA39C4FB423266B4AA740DB53BAE47B2E7868BF9ECD3E56CB572CA0EC3006EF7304D5DF3C30EDC1F8E21BE32927360249A87EE623659CC56EBCBF94D79E4D626476D07116669B60F0ED551303B5902306D75BBEBB3E45917D3DC5A43F0ED21B8D28C9DE61DFE935B4DEDEC5F16C4DCE75B3B7E918288D414D478F8BF542A3F4FE274761A35A97C797D315B58103A1D4AA94BE22A85A97E20F6FB8312E624CB123F20BE48D500D3D5FA3398AC661380FFEA50E52CDEBD592561D5AD1E7D0DC3BBBF953F2CCBBA93818FC6FAEDEDFBBFFDED0333A1360C321403A8FAB50DEDFF6540A1930071644CE085D324CE90288C16823D3641EC07072FA431EF74E29E2E592D9D7747A8DD960B78C0397CE29C99A4F59847D09DA3DEB70CBFBEA3B65961F771BD6FB2FB9974FBCBBAE0CCD695BF6A13422F3139DC7E4E4573D97E50F6384B42501A533ADC0834D0C95E435EF5601E3F20E8B8E26BE97655B95C8929A49B0387DE5EA6ADBDD31FBACBF4EB757C014398C337136263438BE965BEB7E358D51102422A93CEA3457EF29E83D0A53467908052E449823448537D87E598CC799984C6A0D9CAB36333F93ABB0297F3F5E67AF59FC6CF0389589F67424AE57DDB22077E877168B60E025D50D6F39246DB2D83D02477E22AE4B02F0B36036E15500DBA6CCD5165E072AD4F468654EAC672E916D75F847477ECDCDA57EAD72E85892F506A340EE1929F07219006594526D117F3AA4E1BA205B6187B94BB7503AE3FAD67ABDF2704FDD56C7DBBD8AC41F7F7F972F245CCB104503A77ACA08F3A55F191920D52F518E882E44F4865F753982194F8E5DFB5A84E619F0C51189FF858AAE32EA99820A40467456916043D0CB5A99159B2C57564C8920F406B3A04AF84C94824D78861F3ABF5CDACE4DB26A4C703C49008BFD3732745EEAC5408A13F48651C8254C06324729C2F6F16B325871CFBD7B843263C480C9DF03BE9D1A333C2774891DC799D8222CD8F46740821A9BE7E46C4D990E4CD643559CE36B355794F73C9B65F4CE402648994DF4B8F4A2518AA1C8AC18547FE245528E5E0E1F40C38E722D6CD5953ACEA561A63737A626D5AA64878DA4CAE7AAEF631C994879B6424AAD30F409ABD1B77F64429BADE4D19E85897FCD9B3CF73B9F02DD9E7F95CF66AABDA26932E2DB8A03223727647594ABB760F1DD839ACC85886C1E8BC6D359B5CCCAFBE00F4775725EF8E5E44C3D120857D9E3FB528ADB60001EA6D717A5B045A35B19DD6A1154281DC9EBFDD419504CFC4E0D050016B43B3A182EE5C9C583B67F59A31D6CE4ECB4B23AAF6F454863F7E713A93FBCDCD623E2D35818B5BB05C6E2642F2A2FAB60D94F4EF5A2E43F58834B4E36FC318C3295C5576C83B1CEC0983BBB006038E400F15AA4DF942F19DA3B179321AD0645A8EE840674BA228F79CF0072DD6D433EA08B4B09C7C9DA91002EED7DABCF2072D4E701A2A20882A6D4653326734022863C2A4238F45047D378312059CD74530F2D66BF19B136F39C2B58E019D5ECE1717E8E5B4A82484F9BA9B6EA9B587D567DD6D3CFE3C9A8728C61DFDA77CF62D589145D867A8CBA65E0295FDEFAD02A9E713CA9BA70A1AD37D10EEA6252E27934FCB109BCDF5F5C2D083B901D02200FA673D2FF7B3F63FA6A6A574C53409FD4EEA784CF038171AC3E785FC436E56D026AC81D91D85328FD3D1CD2F8BF464FB25187C83063F07726B275C98FD5B7CB99AB1B141088E459AC5A8D5FA72C8AD67BF24639FD47F4F4871548A8FE9C421F1C92E502906624AEA767CA94425DB12111A4CF290B3A5B2F96679622AC318285119E9F8035019B325CF81CA289F818BD9663247977FE4DDC3BE6700F3198714387DB41E080C142296ACE523D57D06A437765E2ABBAE9C595F9712D9C9ABA0D3540B289F172713E2B03EA72C6FB82EB640A0D833D76F2AD84D8EA3334A33AAE5A599D8DAD37335FCE8F422B5E21A6EEE40D2FEFA29CB61C49872E99F0733D0E8ED74D5BD29366A4167D4F454862EBB9F09335262F7F6F4A67B0D9A5FB82F82A26C2EE1DBE98909AC7BED66601DECA088D23E9C8114C6C7B8EDF426E8F223C86082B92BE9CE049B0ED4D13CE133613DBFE853E93A21CF5168937B067E70F2643E3DB19EB7CEBED1FA074EC5D1438513D6A9BBDDA0AB0B698D2D025B370FC80327EACEDAF22A3DBA77AF78F1CD863F0517132FA1848D49F99729212953E64017E8E8412BDAD47B1E212A0212527F1E0C4C4DE7F44238131AB3BE86CF89DC2AB94BA4F31ED053E35CE9EB248A7F339A926230B2279ABA67C6B939A29DDA33E3F4EE679AEE19A7763AA3C84E9AD0D18EE6642158C659379F3DC99864D0EC1F7E5CA2A1FEC4FF11274D704A35CCA87C9075E30BA31BF99A3F13C221399B456BC8DF6A267D33D36642418AE4E89C6A34723A975BE726ABB319D99E3AC5739BE3D45994F03FD7B79F382B3920E3E10EDE81CCEFF3F2D850FF4618A3312E517582061C477F28F8D9BF4671D84771DC7878A2672451ABFB3C9FCB3BEE3C1C9E4F477E665ECFE7C6CD8C3C9F9DDE93E7ECF97C2ED465E0FEFC6C084DE6FC3C0EA19D81F3F319129AAA07F459101A6716D3C9620A96B3CDE5F58576449108501F99B4BA1AA8E54F7D9BF64C494939CE16A0F5BDD00711CCF7C9C9AE5D43ACC6CA24A04E9FEA59255EB0D03772960233923B75BE82AA00635F8E0ADCAB4D50E52F679DA582A0A8B409C22A92BAFA0BF53C15D221C7B80B2B75A974DF195594815674E45D57D61839D37E2AEFF9A9759E4D263CB9B3C630B911AD7C619E7FF48D917FCC9904E0DCAE672B520E134C6FD79B32626BF8E2A8BC515B30F91D5E42C954EECCAC871F81522EA017C234DB070782F9F572B612C795369D5BDB4AFF3C8EAF4985699B608F3F0E4250D42455F6B5E9CE5743ABABC3EB69B918755C82BACD603AF17D98654BEFE090AAFAD8507BD81603EA34BD284A912DF7F9D24B4DDFA09F859A7280677367E91C75BFC8F22482E929EFAE3E1446251F3566A3453867CE684E452FFA7CE61C28852B138F9DCBE09CD8CD09DF56C62CE74CDE57CDC35C91ED38A6A213339E53528E3EF339139AE1D67BA76A1D3CD77AEFA7AD8070EA7AEFFA65104E5CEFBD1D1E8A75CAFD4B280CAF65B4CD6CAB7645783B221F207A57DDA7B18AA175A3A836A66C152C4EC5EF94F5D84E88413366EE140AEE53F32F232D77C9C22E4B0C4E57CD854760B7D3F57FD69BD9F2F9DEA7A7CA41756A4AD4CC4275E26BB413B9254F726611E23694063D890E49CC13DA3A2D03D5C4D30F7B43527C1C382891D79E9FCAC8C72FCE86D874B31A9C1FFD9D5FB8FA2969D22A6A9DB8C049F1184BB9B6997C5ACC0C2B573400587558F5B3FA4BE2BCCB56507352D9E02273A1B4B52F5B81352F27E3801DFABABEEA55991810D40BBC694F436BDA57ECB9D056630F75CAA906212C6DB3F97326294D9BFAF5630CD3D39353A3DD9DDC5E20B98DBCAAC4BA35A777A0606CAEF9A1D3E5E5908DCA069820702A327A1637DE690D02A7A1336D2BC0B9DC786AFAB27321AD53E9C64E42549A0AB1B3A1281D3F2EA757DE3939579C84628CDD2ACEE8B2E3CD419C635D9B7E9E917FCEF322A128D9057701DC81B3A0A58BD964315BAD2FE73740B48C6778BD75506791A1DB5E18CD51537B6E1C4BCD05EC6C88ECC4CE63A721317DB7B153531861C218EFD12E3FA518B0E74C05CA4161D3147A39DC7D7A3AA9507DA40015BF7617F17BA7F6671F3966CFC08FFDC4D17A25BA0BF80043BC39AAC4D1F9ACEDE9D26DFB212EA1EEAC5536BFF38DA0D6CA90E4D7C1E0748CA9CA9931D96C26D3CBD28BB4F3DBE7F962B6DEAC66137116280E146EC2C356BB515A451627C93874AF61D81C675E4ACCA74A73E3E5B9E7EF1D79992A6E9B0394C6C94B46E723AD336650BFC95292753F95A5743548AB416321863C5C2232067D8D0D76967A43B81516E33B27AC19FA267F42DFE4E80B981EDDC076F0739066F985977B5B2F63DDFDF0576B98F399F5DB376507D9D5BBF6F730F27E7BBBDBA2896EBC2DE7A6CA3844D61EB77B7F32C3763BF046EDF6E919B314369991CA9F79F0CB1605A8608298910074D526825F35AB0C521E67FE20659B7090B2B96F4FA82719BB1F5423772FA8F6BEC9C8DD99D809CAFB73272DFFA40741C6DB904189E9C14382E9D4B72E6D571B761DDAEDA279536E477D23F21DC85916C0EDC6E503DC9E3D58740CAECCF09D76DEB81DE373EF884D48233B5AD3261D49757117D75FC44B4A1A250B49DA7BA9954FA142AAEC471D5F80F3E5CD624696940E2FE18D23E82A185CD05B01A386B87B31E2771561C4EFAD80D1F527C4F57E2F53B1AF66EBDB05AEE2C14588DB53840FB7B3263A55F5A25E64AA7E2AA8545DF510515810B595505B021E7149D742F6810E056BAC0EF511123127CBD966B6122D93A0AF10337E773DA4A668B137932B212DF3BB2AA044F5EEC1A85961241D5DCCAFBE00F437F76E12F6E4E123ECDC83CE31B72033FCB18537DCB1B1EFA6B8B959CCA713013F6BB572EF0ABA43CF5065C656668CF2671EF0B2A5072A27F72A3304A70F6F3C4EB7FECD393E4B79FB736C146CD1B15D416CE596B6E00AACDC9E22918DDB59111DBA569D1013BA930C09BA9FD29E974520059B5D368A77B96CD7A2AD6EE6FD1E32EB76EFA7B8EE17A6D89174EDEAD891EE5AD8912F94B0E304270910E3F414E3C4E9AC8B0EA134DE3523ECA9844EDD5981AB27BB2284605D6C05BC9D6A177178AA4BCF80B40720331ADDC87D60B77C207B2F5041B57AF6FE1474E45E9F82BE9ADBAEB0DF6A1BAD38F2443EEAA477C489FE6875D576E99875A7BE91EB7ECA17615D5050721DD65DE49762DD4B7D6481928AE9D133AE92C24A58C18C373CBFA7000D7E67FDBBA0559341E536687DA0781FB4BEE993FFCA04EBAC0058FECE9500CBA6BEC9F3175EBCCAEA2A49C69191AF9C64BA09D5944CCF3E51EB98798F15B08E4D5CB1EAD8DA33021D0FC58C4137F246A1E3C1F4789460CFD83EFD1C4A653745A13C621D5CA7A35CF5D7EEAB4259B4A7229FA8E81E427AA23BA93FF5C06CB5BA5E89F483FC7E3DCF3FBAAB062284EF5E7D9EF72142F5EB4384EAAAF88EE118B685CF194E5FD9AB86D35D0F2991E585D74B0111C5C352A65110ABE5991EFCE3D1E9A47E46A722FD1DA74FCFC9ACBBE9195E247317F65430C428AF059602C4ABD06A1569BFD4674EA9A1FB94DA0A9A6CC50105879E6E140FA574BC71D7D9EF33B136B16E148D53B72B8FD3BB8E6C37F9D89AAB5A7D24B331F1BBF560A16E79A23E3A6A3CE55850DD7AB0A07A6A6995D7E0F7F9EC8F194F0C1675ECD728377D9570D9CC5637ABD9665229A3974B09590A7B8BB1127CA069B821257DFBED36653715B34DD953018BF5F472B644DF4C7B4F10B7A708176E672D7464F61BA6573F1A6AFACDC65680449AD917FE35C4EB24373C34FDB41EB7BD6F5A95A7ACEE835AED31ADFC90567DD3CB7856BB5930A83A8F6AE9EF40952BB04F15D8F4EB5509365DFBDEE5DB105415A127A59BE25D10C22C4FA117F19EEBD2EEDC57BCF40B05ECAEE0E3D111438051BB8B088B762FB591FB3D72441D2558E8FAE7E0CF36249155A3081560C27613E1C1F634C0A2F26C5244E6D85B15A7E3073ACA05D91D22EAD8AB6650BF41847693CB397E83CD758C33C74FB40C34C7AF4C31FD7A8DEEABF5AD0EA6C74FB4303D7E658AE9623EFB74395BF114640ADF68E1DA7CA6842C15624BBE171B9B383DC588713A2BA183584D0F1A540FF1F05427A561AB729CF291DB9DC483B7FB75C6A79C95392EB26575B73754A7AEA32CA7FE5B3B5882F2E14503F07D74992F5AFEB9C7CFF8AEB7EFDA53509D5E195E82FECA84F3A3BAF4A04B0B5E0DBA3CF9497F710C26D8D59FF478D7B2D3D703209EA0400C2073EDB9CD99909B5E0FE47205B51C89F597969B1EBAEBC5CB2EA8CA67E2E9CBDC7EC9AC55DC78DB0BCA735D2E17B0DD62BD605DA562A9EC665788DB4F3C01465B439017AA5C78CB4929F2E945E429E34D8E20D72D14087C347947500780EC084ADD5EABA3A8E4C32A85DB7AF373A1F29FF1D64BCB2EC911FDDE55157FAB3C71E94AEA2DA1C5D6182E23CF915A7739B560C81743E6307E5C0D15E7EF335B66AEFFB1782EFC75D603225F0E59ACC0713D54FCFE87DB42D3A5E63954833E2770C18A9BC0EA5978992B79B3F22A5EE14A9B2A60CB1A0EF1CEB781EB5EAEBD013C28275C7A89333E0FB4D8B1DE318331207A0350A76236E744F1E249F0D759D85F3AE5EEBC8C96C868F1AD29B313C1D1477DEDEEEE16A5275285C0500D3BB1790D213CB94FEF4E8F615E400A8B6635B9F2ED289B1C2F01A9A3C971C353CBEFDB2DF6CA80B60355193BC479FC73BA495EA76C7051F93C15470DB5BEEFC43E916F45814DFA53AE2035CE0D5C22E6F47282B00D8D184C16C752F5CCB4DB458C2E1DC94530E5456A9D628212CA6DB5BB9CDAE0445A5B22A697F3C5C53148ABF2ADE012ACEC0BE9443A16FF7A2E021B3EA3D79484A81D359A2AF166FACBD40475E96B8895BF154F9E0D4823F315879A9DA94AB8B314DDB0BCDEB5EB7C30E482F1E30F5B64268928B45A1A4E9CA87465D8FE432D8C30189602228B6F75B82CDD60468D15EA7C3ACE62F1A33B39EBD613A539CC1292884BB325C49F8EBE845408AA7C0979A1A4A64BC844858279E4DD4309D3177ED13765615C2B35DBDE205539DC76802A1FAE20DAD44C166E3CC728B98C2F10F3BA0EF302E206CA1E652C71FCABED12889E7D9C5ECE916FC16003770900FA67C75317526FDF6A28566974BC400E0FA4C1D2F1E392454BF181B788BA20C6E74DF288EE52CFA4169FED8EB5AFE717128954D0FF475CBADAA18213D42D5A3DF1277D0B3861B5B2B238762184760C3B03471095EE80BADAD82A9057EB0375FA921296F232292FB4BBA551BA1794BF1D6FC14E754188F8112D61AB7331EAAB6165FA532D17ADBD52D240C83F185ADB35A606829A29E370285D979ECADDCE16C5C245D26E39D8A421D2F560BA0FB520A2AC281D18824C27564B52A7F63EA2295D916E6FA529319EC23D3954EC16D69A42F87955FA0885FBD580F4224B2A538352CA1063B55C1D05BD8AAD81FBC9CB3436D074AEA20A96F61F6A89C657050BA7D9AF0A56FD749CC53A9D2A58651D04AA60D54F475FC293A8825BE0A924553AB61B0D185ACBC249CC255A18497AAD131F76624E575A4C414F9726F8134CBF0C4493B81BB43A48264B27452B67CBCB7936A2C7412D0B8A66D66A97EC495770511109079C56E3AFC52A0F64DE5D4CEF61EC1C56EA0E83E5E025A31386488A3B4B4434ED684959C23D024129819EFE523439EC409D348F6B32E4F6134F87CDAB472641FF2C93703B79FFCA2514E5F4B39A74B7948D74E6F2A26CCEA6CFAFD1535281BCF28E410C6DB5AAFCC2ECBC885AE9078EF6F42C8E4633D35E1A11751D643946A40E2EEF931AC87BBE18E6FE3815853417653F8908FB0EB4242352093728BA5B1988E34EADF0997882EE63A9C7F3376F5BF3B048C947B6CF4429FC52D5CEC888A96C6B7FFCB5DD16B8A23715C156EDC331696E6CC997BB029D0CF78AEBD6FE6ACC451BC32BA89B3943E412C5ED378895A82D3E8C96F7A13B410D43B8EAA7C32FD769CDBA4D89467DFF7CE56F7BA4A35679C94626E2168E64AC0DE7E19FDF590A79A21671E7C1166AB42349CDAD95825EBA0A74CFA19640FBD96B377951067AE93A083E1A6A49E4A9F7DB02BD3C91BEA3A5523830CA32B8E5D28C266F5373EB9575847D875A8631A4197A528A7A9EBE4F865A8E53BDE57BE6CB755EEEFDE6452E129583914657B03CFCDE832E0C5B5DA401212919624733BD0A2071E7C116634C3D32A6350C55988591340E267C0D9481F188798FFE97D3CDA975684C6D1E01B6800F30C4A94A1566DFF3854435D0FEB0AD15E8B69DC9F2D4A674AAA40CE8FC46D7BBE1D08A1600F9C34C502AE7F81CEBA97D2383C7D603E2419594F6317200EAA6ADEF78210A7C7FFABE929ADD4589F76B137C5F267D093C09288DE5FAF55D09659AC4E8291DC3F4D8F6EBBB325B70F503FA277A797BF77099EC6098915F7F7DB72AD0D7112CFF7501B3E0BE01F12B821997E1370DD0BACF3CBE4B6ED2E4005332031AA3BA4BDD5C3B86A0B7FECECBBD499A07779E9FA3667CF282F8FEED9BDFBDB0C0427FB485BB797C5DE48722475386D1366C65E9FFF59D7CFC5FDF3138FF7A7DC0FFCA5C4C01A119A029C0EBF8531184BB23DE9FBD30EB30211188295AFD2F10FD5EEE658EFE0FEF9F8E90AE92581150B57C17F000E31D7A0D6D60740811B0EC3A5E7B0FD00437C40E17F0DEF39FD0EF0FC10E5FD72220FD1BD15EF65F2F02EF3EF5A2AC82D17C8FFE896878177DFFFFFE7FDA0D072A235E0900 , N'6.1.3-40302')

