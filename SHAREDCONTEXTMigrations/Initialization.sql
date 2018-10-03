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
VALUES (N'201709180016327_AutomaticMigration', N'DAL.SHAREDCONTEXTMigrations.Configuration',  0x1F8B0800000000000400ECBDDD92E3B8D12878BF11FB0E1D73B9F11D7757DBE3633BC67B425DA5EED637F5674935E3B9625014AB4437456AF853D5755E6D2FF691F615162025910412402608526ABB63227A540432F1974864261299FFDFFFF3FFFEF4BFBE6EE337CF61964769F2F71F2EFEF0EE87376112A4EB2879FAFB0F65F1F83FFEF2C3FFFABFFFCFFFE3A7E97AFBF5CD2F877A7FE4F5186492FFFD874D51ECFEF6F66D1E6CC2AD9FFF611B05599AA78FC51F8274FBD65FA76FDFBF7BF7D7B717176F4386E20786EBCD9B9FE6655244DBB0FA83FD79992641B82B4A3FBE49D7619CEFBFB3924585F5CDADBF0DF39D1F847FFFE16A72FDC39B491CF9ACE945183FFEF0C64F92B4F00BD6B1BF3DE4E1A2C8D2E469B1631FFC78F9BA0B59BD473FCEC37D87FFD654C7F6FDDD7BDEF7B70DE0015550E645BA2522BCF8E37E32DE8AE05653FAC371B2D8744DD9B416AF7CD4D594FDFD87491084797E1D3E87D55CFCF0466CF36F9771C64BAA89FD8350FDBFDEB08FFF755C76461DFCBFFF7A7359C64599857F4FC2B2C8FCF8BFDEDC97AB380A7E0E5F97E99730F97B52C671BB5FAC67ACACF3817DBACFD25D9815AFF3F011EE6D3E5BFFF0E66D17CF5B11D1118D06473DC05952FCF1FD0F6F6E59E7FC551C1EC9A235198B22CDC24F6112667E11AEEFFDA20833B6AAB375584DACD41BA16DFEEFA13546876C0FFDF0E6C6FF7A1D264FC5E6EF3FB09F3FBCF9187D0DD7872FFB1E3C2411DB720CA8C8CA506AE4D67F8E9EAAFE09CD316ACFEAE1DEF8BBFC8737F330AEAAE59B68576F0E71413D11E463966EE7692CCF9B50D35BA46516F0C1A5A8EA4B3F7B0A8BEE507E7ADB90A79668C54EEA69B65B7B6C92EDB46E43AF1282B188B5640D7B7E59A4AD26FFFC27A0493D9AABD08FD9643392933AAF07AC5715EE830132CB1FE950E1EF65B4DBF2B959D381057237AF13760F4B0C7AC84D7CD895C84D7CD8F3D8B15CCE171FC101F0024DAF8162A9AB501D72FF1E16CBBB9BE91CEEE3BE50D74FB88ADC57453D6A7F9BAD05F6B829D6F4595949EAB5BA26B5DFD37F3CCCEE6FA6B74BB0DBC7524DAF5575A44E2B2B52FBFCB060EBB59C7CB89E829D6E8A35BD565692BAADAE09F51B7D70D61B507F5CF23A631F922D864D3D1E55BC7EC083517730110FC7200B7917BC35FBF780E98AFD5E465B342C3FA73542E58FEF0C3225AAA35BA6F13D46963D3D028FD2D53C2A422FD14BDA3FBE3335054ADA504B799185D5D655B5F547D76DBD1FA9B17255662B4D5B17EEDADAA579C14134ADBD77471C79D122621B3A448F2B48CBA4C85E876E6B9745695671AEBA9D0F293B45FCC404B6CAFC24D8886C0C2199E7DEBFD2553540B2A0DC9E167ACB9B345E7B59B84BB3C2E326A2D8DBF9D19A38EC0A49943CA75110327EF69AB7BA70F167E300824DB82E634645FE76C7FEF7252A88ED175C94260FBD16BFC88A8528E2D687C687572E5674909997EE236B6AB25E674C1419D1885109F693F974A2D61C78A957CB3682D2702C81F585A6D84695F196BFDDC3D2E0B1B4422EEB324D11DCAF5639594EAD8E589D8E056A5692FDA629814C354649B902E77A8E5749E06A9959A8282DA3B2122C3383356DE6D06037B3D0589533ECCA2CD6DA296611BFAA781A399FB1A05EC27E033F96C4CF9BD48A2648D984C8AC77AC5D3B73949D05CC0F8AE839944E336BDB95DEDE83E1DAE09E9199BAFD76A9593862BBF08A27D92E2D69C16ABBA8A48D01B74BD5A45103B312E7B5B4A661D5B8C3182437E0B0B6BBB56859900C3716C79A63535CCBE64F2536F47581DB1B8A46FAEF416444BECCDB3590B75937B63D12F2FC4537E4A11A8E12BE364C05D9EEC8078478D1B2F5A3D8C5100C53B54993B096160CA6851FDD359794DB95D6C6E5C68CF1E87F1D6F64BCB191C6B54D57513C8215A8B2A35DF43210121AD219EC5C356432D6A1655403958F66A8EB6BA3C3D9DFFBDBE7B0D316F1138F6EF689FDE4A9F49FBA22DC87D782CEC10BC6BAF941CBE406AF4C229DC9FAC2C9DC9619535F02D0CA47ECFA4B183D6D8A517A1D57C0A3345531F0311A7A4EE3723BCEA2EFB8751043614EB6552594B0268BE668B2154A9EA3F0C50912BAFEEC460B170FED28CB0B2F4E9FA2A42FAAD83F60EA754FF9FD8ED35D57B35DE1ED186EEAD5C3F4D98F2716301F2C602E2D60FE498459DC2C88106CDAD2220C1851F5DD1641BADDF9894E7670A4C8D45B8F11581987ADCBAE4A063075314EB3CA4B583201212EBAC264ED3DF2DB1CD20457601D158F02B8F1B37590EEA83799FE8BFFCAAF75B3C26AF356E0BC792BE0A2F0834D5F6AAA763353E77651987797984A96D66E9365160352A661D1D2BCFFF1B24A99589A0AF7C198D6B76CAC5EB0612272E855969134A35E064709633BD17A7FBE55FA00A5075DF09A028B684B26A2EA8C3D0C613F242A8E233893BAB3D71DC4E20C97C38BFA3E8A7CDBE0B399AB4E6A2FC83D3FE8CE22761D6AFB525A6C00610EA5C5D195AB7558303E25702B0CD597DBADCF1AB4067CCAD27247E3E45BEE9AAC3F6C9CB8AD94F98E71C2FEC723772E61683C7FBD0544503DEC2C9F1E9CB1A76BC0BF82D8956DBAF2E22808937C70AF1FDED43A7CE69E255ACBB4A59784A8D2677EF0C52BD3EDE00267F8BBB709FDB890CF39835FFCE24FEFDE79F78BC5DC9B3C2CEF683EF50DECF4E6FEF64E4BFCC220EBD9234D66E017FA35736472F20BE9AC1A72D94AB60BB3C0CFB2C86F8E14E4EADD1FCC56FCB6C3FB47996A4D72CE3D7FEE6EEEBD59F2CCB800170E6609E34C817755F16CF8AAAFE5366D00069DB2B530D2E5201A90EA40C3B1DDDD729FF5EBD9C72966A0EDDACA9135954C4369D5A4F6BD7924605CA14E55B0D7AD1ABA2EB7AB51FBDBBC0F983C5CCD96DEE7D96279F79BA9EB2A2870147065DD801410F663C3D09158DB3016131D0935C94E64978BDF16CBE90DAAEB4265F8C145BB8EAEE3DD8AC33ABFED5B0461E051403E6EBAC140F55D8CE9C266501784515D5087756137AEABE9E47A3A5F7CD62D5353C76B3B710863016BC15E8A70D501DC147B3E4BD22D814BC745FD596DF0CED2018FED3F63F3C057F2C21ED06326FC9DDFCB78E6260DE6E7D05F57D2DF7E19C220DAFA4C11BECFD8AF7DA488BFFCF06611F81CA5510D67A270E2B10F4C432B5A426A5FB4E1B31F9B1C24C44B2F416FC05DAC3261DA233E6E6664CAFEBAB23037828EFBD62E9A9FA6B7D3F9E49AB150EFE176063FC814EAE0456B12A0C42969D054E6B99C4F2E7FF6967777D7E0989B62FC70B130D248D180C33D5A75AF2E699EB4D207893E4A247AD61F1E42F5B18F8B3D3BB673B8EC008F7880D80749A86ECC3200D4C225648F2B4F06B7A1F03B212F4AF2C28FE3C62C8A65D7F9B6F4B861A986274D57F8BBD7037AEB7FF5B270554671FBB0E0D77E64CFCF7CE74545B8958C475688B89DFFD98F853E21205B664E14D0A8BE037D9C1CC6751DE8E5E5B0DF755EA2B70422EE22D09BBC7AAD5BF6BC13E57818B7FCBD65E0FD54F2DF765CC75B877930C252F95F2C1E8A6E7988343AD89E57B0A525EDB2035890E68557FD245FDF7551848FEC80F21E9928C04E5CAD2AF0D7A32A6064869D26FC47C682066D6197A52B7F15C5EC4065ED04ECC875A5D3749AD946499AF1E7D07E94F1369F2B84833455268777CFEB815B62304119FBADDBEBBE4BB34B05EE6138B1A34663C4D47FF6B388B3108F3307EACD757D6BCE493EF073F243F2EAFAEF9DC7F5E7E364A54C34455E1C32366D0FFBDE0696893471B1B6156982CD973BB25B1103AA150C2EFE2E79DF5B960B3C8E79B88BFD807A8156017664303CE0C728F1938007A9B4EEF4AF7E96F909392E84623F5E0CC22B1BFCEFDDE1AFD66A407E52DD8A5AA9409B2F13EEDFCBFAF3D16ED3D78F823D58FB43C4EE604C2A4D3886DA3FBFF098305E3AB3B9D5CC6155AE99EEEFC5D16348EBDCB6242A94CDF4F5ED79ED5FE995415EAE2CC29ABCE64C43F2AE975768E6E6F0DE7B240B9D781D6067DFC34EC375453D88D1D615D583E2E5C6BE5795C85D7CA8C63C99C386D3A6D893EC524D77D5B5241B9AA6AA9DFD7376BBB89F5E2E6777B7DED5743999C1C650A95B2A58F51A28408CCBA282EB77DF74E08135E518EE97DA95BFDF2709ACEA30397D6F94269578D6178BD5DD08D813F866868EAAF4E36BF91424E2594685F651AC6BC7AB49BDD596939FA7B7B5F3C91C7689812A6A1C9210D5E510B408182AEFB3B9F4421D32A62BACCE4934CC250ED515CC704D63986534CB8549CA106C1E80199B016FA2BC9265220B46DC861D8B21FB15F7C2077D31DDA07305013614532DA71DD1DEEAC2A791F52D83ADBAF0A147BADDA2AFE60C88AA770D8E22B1BBBC7E33DC03DA62E3175E8E3AC60D4D3D515593EF84FAABE73DBD6E5EBA185414815252399CCC941C7A270F201648E92508A284437F59B059B5E72CA23A6E643DBD696B2DEA805915B552AAE5C1A7B6E8F1628250F8BB18C1FAAAB4F81594210D6B28A9A5A85594A0DC7B4583ED2AFDA3CDB5710333FB4CA305C5E3C32F8C6EDEA9FC5D3717D8D96172BEEBE600AA4598457E7CC34387CCBBDEAC76C2C27FA6AEDFEFE843E9FA8AE3927CA81B728D88FA7DB744935764609DDEE6598E46A747CC269E5537536B60D3878A27F0AF14B4140B274B929EE38E7DE715836ABC71460C6FC974D753B45B395545BBA2E559329C53279BDD67A6483D661DAF42845BE5B6F09D68D05B3FFB1216F49017A12FC5D7C2C0A53B6F93E5FC95054F7940BA9565A0EB88FB003553856C316B87B1182EE18B75DC17DB902F7BB7DCAA619A061E66556C80E0358843A595CE40BA6C2DFC8421B1EB41DD7536721258BB512AECDED120A75EEED760879649B095B564FF4AC96A85B983AB2ECBC58F8E2C857B8701FA3AA2F35E19262A0DFC5118EE8E091A1B3F0FBD9A119128BE0DCBC9C10ED8860C8EC0464F1382FFD03ADC65ADBE2023D53029A4D8A4FAD0CF2E16AA0C4C4FE64EEE30FF3D2A20DC5A25AC0AFEF276C249163E3991000DFDCDB2346B531BCAE3FC310E43F06EC540D7BBEA218F1FF04CE2449FBBAB0F0B0F218FBBD9196BDF8B92202EDB1ED6D8107AD5D2D343FDD5C142D9A2F788A1D70F9AFD8E5249ACC63C3F78F2C2AFBB4879516370572CB355CAAF556C1C2993224B632F7F95261C01CC4E8A64ED675E3D6E122C3B749864C4051B1E3190AA3F24A957F5DC0F0AEF91BB9F7AF5B6106410BC9C24A2CBF7C26D75CB24498BE6E199318AC292154E5B09BE7670B57B9953C3725660E1389C7B357B2743AE6B877BFA5095B34655006444D662AF1255FF3E1DF6410B139AF7F90977D0A747CF0C591FD63C2020D3ADBD28FF9C96991C4F9386E34AD0972CD1FCFCAB8BCE5CEEF95C4F341FCB30FE5066E4E390912B43E521C255F0A405584F718E96BF621900F551CD1E12F7887DA7DA8CBEBC5456AA017AB7C73CD0D81F19817A2B46A1C3221FA8F7B534126663E1A652C5E1A5CA40FBF9807EC8CD77686338023FB43028291E1A199262EA38A30C2BCFA64017B2EAA8A1ED107AC4B0A30B36A4C92F9FAE3E789D13B0EFB01AB4E209ED0E333BB4EF1EE60BF788C503D81DE6CB3D25B9C2CCE4BA5A9CE34D2C8826E70EB095E1B9DBFCCD83E08568D9053296FA7DB61747C917A61E47C023437266930661B4ADF26FA3F46D93DFC1F5DD27C3C57CBB22743DDF944BBE4A6025AACFD5A7E9127E74D760AFAB409DE3259A6E55C5CEDEC5A19D19D41DB27D057773B384F373EFCB1A7E9C0B4FDF8452E8C99B5885EA6C7133F91976B3E0058A9E094552B7C4F2417C159B75D13928AA6B6916DA852B62E54D0CEF0DBE6AF57BDA45B9F25A8E22DDB507AA800400D5B372B9B14E4B0E0E415F1397A0BCC780CCE13F1BE4EAE89FAA3A1AE27119FBB3CDDE51CF8158CDB1DD88F68F6AEC3C883AC063390FB97D9EB11F02F7CFD15F890FE2167468DD85D7E72E4B59E56D9EC6CFE4EC28753F5C5E04BFECC37304B11FC9D1D530573DA4BB12B6B3CA476FFF0ACAE0DCE0244959186D99229A879EBF75376769F625CD98C2A0BD89739383F4FB1DF59019DBB19EB9040540EDA50B680956C71593D8CD314547F7737D0A6D83883EC957E9A0BB80BBA389698FF555FAF80EA6AC69C6FCC3C4C27BC0ED81CAF85E5236C988902CDF321C20831A21ADCD3EE40DD9C9EF3B8B75DED53AF452F285678D6E3DF924C90AAB32E0DEC92FD1BA49F9D437C2D28A3BD2856BD6AB6213055F12A63FB8421DAEBC555A30A63C086A1E11D03DE2A02C0A7E1932CC8C6C879B11869AEDBCCC3DE236D119B29AB911F0008A1CA5DDA4DC9278781E3ED54FDAAB465D4DF78E47C5CBBB7B1CE7525B03767B4381942807370B6C397636FDDD035AF4770F69D7DF47EEA758BCCA3EFE885B8072EB71F0C1CF8ADA636F13464F1B6791F4AA3CBE4E313260B6479F4A317A3342D22CCA9DB769DFE311C31D60B514C31D805A33E95C11102E25BCD9CDFDF5B442613023F3CA6A80764823753D20509BA632D598DC20994F2757B3DB4F1EFBAD7887DA6D54A8DF1D8CA21A381655DD5EC64DF5AC1B5548106E6CBD323A06CEB5542F2504A369994DC34E0C87583DD92039F1E7E6A2BF841DAAF499CD4C1C7BA6874AEF7FFCF3308F3523F6DB0B93E7284B93765825BBE170B39EE7B399E939C17EB08912F1690DD5E0DCBB1BDC7B316A3FABB243F318FB72D0677208AF4EAE0D8B5EF48EA3641BBE4A77FA0D77D0C931FC10A722E5DC6EA21421CE6DB0553516D5F98700369C8A180C16AE15700BB39BC927F8CA5EDB291D2EE4CCA851D0E64783A7B744012FBD59A280E0BE4B145889824B004DF07417B240F590BF7D74826AD29F8F6AD28F2739403245E203E7C117D192CAB8925F736940243DF3D278D153C26852BE881EFC8476A7588E78404127B3DD1147998DBB0F8BE9FC9749053F9F2E1EAE970BE564808D2A9174E782020B9E452404BD0F217044E63308001BFB08CAC29C61CE2DCF9F2EF409D4D9FEAC275DF1302435FD3A40E7059B30F862C1C5DC49C9A3ED3B8805596D5C5B0EA4978CA1161518BA93800604390F1EDA464368615173DE7625ECCA6360C0154701F6753381168DC65F2BA0D105FCCA546F29DBB760C7E2AC147E8E66ABDE6E93B65E0247899FBDE2A2380E25998CC0190C3B05C9575C6C17AA2432BA08029CC0D4BD423EC4DD6D9956D31A75EEE2FD5F06313CB7B759CCC3D2F5DFB9DCB3F799AEE10EB139DD1E5E86C3DA7CEA39BDF5C29F626AE8EFC7D9888AC2CECFFCFACA8A7B31F4C3D5EAD82887A31B23C6B01665924103619926CD4F83E47E329FDC4C97D3B99A4381B5A9336481039E221B44BDE50BC5842198190438361F13B7329597D158813B7ED6B46B787DC42F145D481BCE2FAB4EB573C0EBAA3E5BD092BB5C32396339B9D5883F9A5E8168D093034053A70542D15F38028745E22447B8B11949907247FFC4DA7E2AC28FCF489CC93263B124C9F326DFC5FEAB57BD82737AEFE34A2470BF6B8962806EE35BED5AA5C3A17ED32AC0C657620E579887004C756A335BB54687ED5B75F06B5DF3F67477727B1B3B940FAC5EF780FD65ADB6CE313A887EABECAB8DBD353AE91CA83B81900BC21DE1AB5E0152DD4FD809143BC003BD6FB0F2B9AC7245408F33CD0F2DFC9D1416D5FCC2CD452A066DE461AA83CCF79790CEBB1AE49E7A8F6299F0E4FEFE7A7639511A905AE5DE91D9B51261C9C572E22BA08E75A22B75441E5220265151D2C46AC276511F880998BBF677380493ED6CDDDC5D4DAFE1BEF012B033ED02B9379D52723828654E4E9E1D13E84CFBBB9C5FB35DD82F6D779BF60DE1799AAAA3C7E739F27FEA09AE3839864CD0BDDB39798D4F3D5F773B83B6FAFEC71F076999F1606096290C58175FCE82F94A194D350CDA6AD3D46C4EBF5B789DD165DD4672244BBA58A1D3AD9C7B8A9DC2DB3546BA1AC6B0B3CABD1122757C1734871134ADA2B3047EEFD0AC77512CA1D0435C1E9E3150C3FB3FF048BD01D3D522BFC9EB87845DBE66549039392ADAE7D775E6978C5912E13EA4EB571388ADE44D88322A1E4DAA28A42E4E4E94CC0D764877486A85DC2AE62877979DCC97DEF49FB06DAB6A02A82AF450AA01F755AED6EB6807FAA53FE72580B10FFD43CE99ED8E077A08BFDA060A53E1D1BFE874270EEC5B76947AD52A7B0FE30B16A99E56E5BA0EC82465063734D799F097344B78D4FDC0ABD300F694A7F704A9B2141CE855BB0D75F5A028BEEACA6E033ADBF00ED0B6D0BFA35D0CBFDECD6FBDCBC9F5A577335D7EBEBB82157E2D887E705458D9704045603721CBBB3BD8F6D21463060AD7530C4A51B9EFD5C67123196F37F635C7BFAFEFF24DFA7D3D85EF0EC0EF75268B61F4B07DD3E32B80F996E911423E4C4480C75AD3C93A9083852E23E7EECDD2A76611EB6C3FC469B90E1FA9093BD9FA81B13A11FDDD43EA3CDBDDA88C9B285EA7BBA273DD8C08E2CCF844B48BA9AAD423EFAFBF4D4B29500BF65A9C9EB130252B7C4F595AEEF43610E3E41759699CFBF02BF71D08D71DA9CC10A4EC1D1AA931443801E99E1739BA65ADB025AF89BFD5310A4791E5CAED2EF0777E50317BBD79DD24AE7FF5B270554671D10F511AC5B9CF099A674EE58F48E2DEF882CD932364DCA1C58B8A906AF2A8E1E02E20205BE12E5140DFAD87EEBBBA4A5FE2BD579FE8D4675E90464FF4B2F4C5163428B805939151CB39121AAF8BE10ACDE6E56A8C560F9A340F98A63D5FDC243FC821F74C836875305E1E228D78F9EB76C7B40A5D7CB70B37DDAD04CF7A82E822539A57C1CE6CC42D3F8ED3176F5DEED8B05BFB149F0483A7895D7B4A2DC52CA640B97B890695CBCFB3EB2B6F3EBDDE5F22CE1646CB0A0802DA56809A906F86AE3AD5507BB4D4709D59FDBCA1DD2A00018F46AAA81D8C5C9BFE1AE1763A9F5C7BD37F780FB733E3BA48D5C15108B5744310AB5A98F00FA8F83FB03F76AB925C1F1C81584D3704A96E8F31281D5D843A5EDBB602DB1CBBB5B41647A12AD56AC5400F813E2AF0870FA87128C1542B02D5362C0C08425D1F065D3BFD1218180C038E0CAAAA1B16587F98CB2627B66ECD5070D74F4413F2F5EC863192CB097148222C62745D10FC40053867639E2D6FACC75CC1D2C6CC40ACC6CCE17A5D332A7682C9CAAC001BDBE43C9323B31BCDCC33E39B0977A6E5FBCAC477598B8C52C306D7096EB553815ABFF36863ADA3240ECB7C3567A59659A30F94F60C6306D44F1CD60C47273DF7DA9A6D4917B72B1B88EF1B52F647B2D94FE2B1C194C6DE38A222D6990794B12948F6E7198F0C72E517C730E33DA260887359DBD8AE5C3C49A9BAB9D4DB662C27C48173421F9D53C731D41A2A5A7E618468BADFD6F75E5B5177C38DEC3DD1E1A9BEB0C7783AF19AA3BB38B1E9B6F56A6A40FB32BBDB34315B3E79738E6E5FA8EFF478D3861B62BBBB35AD19C99B25CFEC1048B357F68B1B35BDABB0F0A318769514085903ACDC2A4A18499247030E643E73C40C0CC3EA693EC3A9D14EFC76340339811AAD6C5DAD462341F0031D5B8DC6744450A39120566356A9D1E631B702405C4D979399CEDB4CAAEBB5CF3C71A4BADA8A73590BE2E070561126C531B90B7B5A1FE5CAD5358EB651E105BE1B776510E5E89E6C2E5EDB57C3527A2213B16D222F4A1EE33A8CC67D1A193251346E2B7F4460CE63F6E5C221C2CAC7210877854BA4552FDF0FD14B6748B783ADD2D6F52A6D8758A5ADEB55DA0EB14AFEFA5F8CDF7A3CA3AC2B94D5A847F6F1EF7F4980F6FC57484543BB92F797DFD00EE68811F63FEB2B81CCF2AC67B06773D647C5D6F559DFA0FC7ED6D7897ED78CE56DBC247C71C5A35E7822F01AEBC53B6FC799AABBF3A985FCFD90C8FF3824F23F0D89FCC72191FF7948E4FF7348E47F1912F95F87447EF16E50EC83EED10B079B744881C6D203C046A0699B3C4614682C8D3336028D6A84448106B0D460641909EC84792CD79599B87F3ACB0E9EB10416A7F9026A89A54C22DCE370C48505D99F58C8AD6DE03F5679AA9303936BC5C070DE0E4FDB6CBCAE116E6BEADB19E2733EB685738FAD7E5E668FAD349FD8B77DFFAA9F3C556848B03C82401FF82CE4CF15B8E3B65DDB7DE0F7B94C756EF97F32BAE563FC04046AE3272C9EE2D07B7513E5D5B517D975FEE172F19A17E1B6E3740180F572CE961CA855E7463BEE2D0A0488818B83A39EEC951F85EEC6536EE20062BE7FA86B2A2E5894D56D22C9A4EB320EBD45B95206983CD6C0AC120A0092BE1050D4155ACCAE7497B4400315807975783DF4DA5495FBDE78E18681581F2C8CF9DACBD52AA1246487F779D87503AE00DD88C4D59DBD313584026C742FC32B0B2FC32B9390E84ED4FDF4D0B4F6A98C649F4892688E719F110432CC895FE70C5B0FE21A58E336276277E4E3789CBEDA8FC6E4683DE8953EF938C55EE50BA7AFD5B617CE56739CFC63E5B1B7F8BEE59C9DBC76EAAE8460ACCDBF08B3C88F13DDF6353ADED5544F54E4F623DE75C2A0A0B48CC5CD03491ABF24D667F83DBFE06F8D0B3F8E49A0D7CB2B5BD0BD7FF28757D25C68BD9A0DC3640454D2F4BB1AC4A6313631A4D9087F2FA3DD160C558308B092E58F742828F81D020A4A176106E30FFBAD1AABA22FD8ACC0019648608CBE727D3A5B270A3D0F3EA0331BBC77D24A5E69E51EDFA54C78C9C26DDA0D0D42A04B6FBFD519BFF5834D5B7040E1D973888A857B397D27D623E100D3A4DCCE9275F8D5D59BAB6358558436DBAAABD25F8F55C0C409503DB20A5EC52A32F6B5AEA6EA262F35F4B0AA32A4DFE5409602FDA84CCAAB95E4569BBFEA19D78B6D4DCD6FEEF1D7D092196C42248A59934AD3E88BE5210F33373D71F2FE8AA12AFDF85A8E1C7B1E8FDAD41973F6669FC9CFD35BEFF36CB1BCE379C9A0EC0D4045EFE172F1DB6239BDF1AE671F3B3636736D39B18E19C4221804C9128AE0C77A1B678765637BF9B098CED9B03F5CC366CDA6583DDDAA3A52779515FBA55C14EC074CC98ED6463E0B438DCE73C55E58316108C918AFD4EA79762365B930DE906CED58C34DC730DF733417E070605254092217ED11124125D1870AEFD46A4D35579FD075A3B7CFC6B8CE1A066B01D5C5E0ABBF8D1227E10DEDF22747AE72B7E6DB9276FFCFD4E1117C2B4CCABEAB5083F5557EEE3F79712B5272DFC8B30DD62C7ADA0C80967756B0090C16615318CC58CDAEB357EF5FFCC54EEE74695A689DAECD234F915EE5F670D9DB06ABD3CEE6BB2C0DBE84C5A874746C7454328AB63B3F10631F1B9E23AD323F8F9E4312D0368D727EE4928058D7BEB43CEE70BDE3513F3983FF35F469D16ECBC0C0B8DDCC78DD8CAB8C892633FE371251394893C728DBDA76F5083D4A67633F2FEA677E3BABEEB6E147E9F0DEE3D37439FFDE2C3460AE08E234A844D25E371EB833B06698FDAE5E919B9631BD64F8048A2F2DA65527B430CC7541BBF8FDEF74954745E85D3262305C16B920852C8C433FB7DCD547E0D5EBF0A4D4D21B102EB86EDC587E2F99146F93199E871A609A5FE254966AA1752A4CD546EBCFB523B0B53B6F8D65E933ED7C8F0A6FF595AD0806C3AFEC6588B1FD4A50D669D6C1A1B56EF734E351D79206A1A96A67BC9A909D442752FFB515CD5E939DDAA3067871E9F58A1CA6E31BC7EE92600C6D939318D9FC3E0636FF14C635A72FA1F62360CC989D533C478159D67272421E1B349DC86E24A17673CDF8B0B203D3A5D98C6EBD3C8D9FC32645182EF5C3B89A4F0F15ED9CF3D0A0CE8AFA04D530D809C4D66B1891AF2AAB2AD8A9BAFE98CF24A82720F241C4447D8E5B9D078749C79F0A35C489CE8682CB89FD4E88368AB1CE09C2E18442548F01E29E7DF03961FE7D3A60B09DB93AF0FC833A6848B9F7D7A32E8470AB3D577B5C5FD1DE09A386999B99B1DB3E8D10B2D960F3ECD6F54F946DB7F29C6D25D3A2B237059AB1589CCB284689AF8D766C36D2A0D94073D9711421ADDD56F0D1466CF32D69A28A287333F5DD4275F621F40EE2D54FB4815AEF062CF70EF4F2609C6DC35B76923FD82E6D356FDE852996EA8341CF77C81F451555FC07F2C6D5A949F6EF4DAC8EFC1E19922D7339F37CB809CD1CBD03B2701B6EED2D13466FA384DA39C607B761CEB849FBEA0B9B01B27EEA224C3D228DED31DFA58A5118DA15324F7A762F9DDA7DC83769567C09F5F7286EE54642502DAB9C7CBAE4598AF47DB6671C9C69CF78D64160639F796CDC4732B27F5A0B63E96C896F44642CC2B0D87879F4BF87F7F34862ADD64888A7F3E20C133BC222ADDFE07F5C7EEC3D718DA85093E47F07493EF5DA80362F680FB36127ACDFE5E4FAD2BB992E3FDF5D59C4136E419F414461B6D3026FCBB848BAB6E4A628A4633CC63074C4957ADDF381072E418C8A62304963F0B08AAB0402825EB2C8CDDDD5D418C5B2AA34F64669BFE1A7EE07F0FDFFC0FA74D5A656931E266447D5AEC17E3D4CCB451513B19B8B1EA3AC3DADECE0FCAF71D8D2D630207AEB38D56431E625EE3724F034CF1598AE1F6DCB2D49376D414709193ACAEF1797548B44C51DB8C46EA5892B998B01D2A75A0BEA86765914F0C09F71F82C376BEE70F50ACBCBC2272F4AD68CCBCB9133CD386E78476ED3A2DFD98DF15F3CC4E8BC34DD90E93414ED63E89BE5043CF3AB33CE3BD6680EF44E81745A774BFB394B216C00A750F87B58B74F60D636DAB387CA58C9DAEB7B0A5B5AD2CFF606F8DB3DD2189BB7B3B4AEE254326621A162CE3CE8B0EBF0D1673BDFEB3E2BA53842EBD8E2C1F02972C5F67759856917F6E28955B086CBF9E2A377F9B058D6E1884C3C1282199B67D6373B791E3DD9FA0CC9183A6B3B200755DD4A51D952B5486E5059858EEB15ADAE96B6DAB7931875E34B18EEBC97A8D87855E37479EF5BE18FD42B4C75F661B64FD5315F845DECD5B585A02F50258925A96B92F32533F8BB9BE91CECF5A1D0831957D3736D45C9C0AAAFEDF65108D80418524E5F13B704F601E60831830C6B61A8AA8D20E4623D1A7C706816437B1784B15C500773D1CF72DF6C16FD997DA837BA034FF790227BEF50CE3887D797AC59AD8E630ECC69A96AF0A4A106233E3697884DD3799185A1EE66CD4DDCD3BAAD725566ABFE46554453BB342F0C8102DEBB516BEA49F4B5961C77E30AB83F4ED6CBB71B3F879BEA7A6A8496B6E92AD20628BC70136881B7F5E87F1D654C3CBD50DC6B5FA1630CF573B3C78EE8C8953D9E3889EEE594BC1AD8DC8F6E66E4BBF16600E34DB573D26C6B38239DC48B587988D3D821EFE607E0FBC14F404B0F75A8CB8C59C6FCFE62CCB3BBDBE6F0D3D56D743CC1E1D0E4B8024433BB63091287164712280ECDF9EB7516E679DF6DB0CBA2AD9FBD7AB19F3C95AD348C188B521E0669B2B6028D72CF0FAA19F376FEAB85B732F73AD6283806039ABF4A93F895DA644B6CB4B8620568858E653F591ED3C9B6B4F8FF71FA949AD423B46A66387722C6DBA2A0203B51B0457DC9BD32B3488FB12AF32861FBC1ABDDD8B512B08B6D1805DC83EC4BE7A906928E182817E3984A9054A24018F83995FC85E17A7A677797F17BD8E206EDA70CD00DF88F78175DF6E723D358A4EC657AA8C5267D89A36D54F4E67F79C838584B93C13E96E0601DC58402B8F1B37590EEA80CE87EBFF997AFDA77494EE8FB324D0A26688DD256C5CCBCE9D7200CD7CD0BA69E843559FCE9DD3BEF689C9E3C2CEF48241625CF6914709FAE115C4B38733E1283B32C7557219BAA8C1B6BCDF1CE0DD470483505A67530507CB9622BB88DF290745E3DB21E4EBA32CE08F9169A2903ADDD4DF191B23AA9F0A072C9AA0D56B2B2CB4BF706C3DDFA881726B83B22F46818594D8280ADF58DBF83D3FB360D0A75A11174AA68FADEADD7CB1BA04D39FAFB84A6E6D8370A5D8640BD50A0B01377F709B77A91D50DFFBD7B493A2F6E317E00C64B58988EAD588848C15A3EE3FE92B269AED355B886EE16AF5D8DCCF1CC3CA2352D6A2EA1ACA49B65979CA21BD903E35829029C2ACC90BDB3A58CA12FFFC0BCF8F10F3987F3208B76E304E96D071C29F4C2B3ADBADD3F5B9444511E0CAA8A65A38230C41E5382F5DA4F8D9BC6E4E16AB6AC91FE66DA5430D4D83BAB72C59A94EBC836BE8D8460AC7B7EB719549CBC8171E41CF81885F1099CB45721B7055D6EFCE449C734868A3AE23FB2F51FAF750752896ADF83020A5C5927AB28207AB91C55E8AFA693EBE97CF119E92DDC54FFE6F25D0EAC1A38DAEFEB46CCB388B8D08B909BB5F5DAD5050A066BC12E8C70D55EC7EBE4FEFE7A7639A94EEDE97C7E37F7AEEF3E992817041A3D3D9905FD4623E66BB5F156D8F94FA1F916C74D1A8D2C4BF50E116EDAC90B3FF8C25F5AEA06F517ABC6AC88BC8A1871FB714622F223D0D844FEEC6711A7CFFA0A884AEE5DE8B1459E673F2E4D4DE3C39B92D93E522B1C92EE0EB11226CBE5E4F2B3F771763D5D2CE7D3C98DD129590578A23083FBB4F6FD220D76918CC5869FCA86E97FAA7EDB850BB479CAA3899C66062ED2D4E6AD7777AE5526193BD1CB70A2544E0F7629AF46CAE654CF4A65BD311CB38EEC454D83EE2F00F589180C82469A476DDE0803A98DE05DFE549B39A16B1DB99EA7618AADCB1E0AA0FC688904DDEF9909341324E67EC2E8B10097E8C9DB47360143AD1B36F6F0919E34047EBA2D22DD925A6D304B0BAEF7707B30B1CC11A6DB4EF513D86C93A8F036755E2E7BBBAD8C642C89679BAE4B26F3EFFBD0DF8252E3EBA8CE60904C4B310A9123AECF73EAC6198F511C53AF8F5737F460342D04564F111AF0F07773D004013A0B576514AFBB3183CD7D664242E1C7B15587EB5E32E6EAEDB1D026DEF383A2F42DBC3DCDE2A0AB27303E9374E9F4F82D3D48F9661EF9349B83EF58F2F6E86EAEEB25CDE3B4611275A66A2FA265225DA74159A5D9F4FC64ED455BD6159DFFB6CDE56775B16ACCEB21019CE4CAB38EF2DE27B39D02CDE8D79FFBCC74E13E339D17B313DDC1914A1814D207A2F0A378F824AF87E62CB8C9000988B88BBED7F1D11FCA87F9C5CF323F295EBD20F6A3AD3E47B3A3775D8E982FA52D27D7F4E7713862867D95BE306660786A4B6E07CDDB3F4D6FA7F3C9B547548F14602752937AA94767E5D2D2437BB1D38472DDC5841BA18A6FC183ECDE7A7A81DC8C3D647F9E7965AFB0F4D31AB98DD38B5A4FBE6C5F02D588124632CF7E2CF4090159A65B12D0B79775F5FC9FF21F8C7DFD4339A0B7E95E1DE8BE72B4D8EE1EE377BF7B3D2FA27AAAE3FBD9AB2E464750E7BED829D636F18D2D4D2307302E927AD54FF263CF2E8ACAC5CF7B6492383B715D09B99D262A37BE415BD865E9CA5F45313B50593B41D1F888F44DD7D269661B2569C68E889D1F65BCCDE70AE1204D95491E6C426EC25C0FDC12CF3751C67EA17FE548599A5D2AF01EC3891D35811830F58FFE219C391049BF3E746C5F38D7A1D7DF55793A8E939532D1D4D8E71A9231797BD8F736B08CFBC6C5DA9AFB6EBEDC915F1333A0D9F18E77C9FB5E316B2A8E79B88B5BEE5714C08E048707FC18257E12447E6CDFE95FF71A771F86DCECC78B41786583FFBD3BFCD55A0DC84FAA6B7F2B1568F365C263F3B0FE7CB4DBF44CFEA8EDB390F687736DA98DB4419955982A0F3357ACBC660EAB72CD13C4C5D16348EB1CD15E6D7832A5074ED50AB4ADCB084680EC911801BEA22C0320019FD8138241056D266F553DCD6BBBBCD74BBBDC918B05D674B227568367055FB8BED137498BCDFD15EE6EABD0C0E6E53E563E55D6CA9A75F5CB59D9C631D6E2DBA972BCC7FD4D65E92AE7061BE5D50B952F5B74A1CF05FA5E60CCC3A2DCF5EB45C6C4CF6DE8E72DB50F1B8F881D144C12F3E26A5392E6AE4AA26701C7F30639D34EF7269FC12D165C49DC324A0BF41BCDCC28A9C10B892C0FF374A1A9F96FF95E81AFC389DE2B609B36D8E5518F13DEFFF8E701DF26701A99FEC2CE4394B054D71CFD92E9B9F6A9B0BB646A038F75C9E4E8D122EC1F60716E5493E02807A1D12B0B2900BA5433C8C768C0FD05ACAEBA2D76164D4215614EE1145E9F7BBDF69D02CD583B502B2A5B6C4526C339D882B859E84B6EAD5C2968723BC29CCE53AC1F9B87D18CEF29D69FD4F2BEBACAB744ABB39BFBEB2991568F30A3BF35DFEEE2B03FAD2AD08CC91AFF4318E2EC76713FAD0D7CDE2FB3E9AFD32B0C99C950A313DAD1409B7BCF51F812AE6D494D85682C62D39B9A4F13FB673F11430B7FB3DBE5747E3F9F2EEBE0014CA0BBC1EA590AD0138882AD33CD4202449F8867A77A99D59C8BF77F1924CDD47ED69C286BFAB7C1EE48FDEEC3623AFF651F2463B6401DE622CCD8C4AD302A53A91C639B1E90DC0D97316622B53392EDDD3EDADE82965EB0352227D43EB8D97571F9797AC328F692A6D103606313BBDAAC4DA577A4817C40926F7AE0CC095B75FF3E0201AABD33FED9AF330734BF0DC6F51BBA9EDD4C3E4D695BA10239DD36E84BFC23DFBC0F183F645516053BBB0EE4D2EFF5982BD9CA8DEF364F3A627257B0B93644EF92A3A5C2BB9C2CA79F10EF7A6488D319390246AB4FF6D10F9488C6DA35C7660D2460BCCDB313E40FADF36BBE13E81187E6F34D9A152631D174C5E8D267E7FAC13B78E24CE64601AA5BFB441172225BFB0BEDC19843D23FB4ABBB581E284573DDB403964BB69BF37C71AD248494280E590772B0F4859B8C96D06D97A54FCD225A3D3CBA0E1FED3C746D62B41C20B567BB13196213C5EB745748F1680CABCDF844B46B92272327E491F7D7DFB653A2A1A6A339022DFC6CC93E5E4F595AEEBC7E938FB99B0FBF72A352B8EEB8471B2EE9DFA191126EFE8D48DDAA77D8BCCC4EFCD0CAED2EF0777E10358F1FECDECE368F708B7E88D228CE7D4ED0AA07B4747CC1E6C91132F50B610CDCE80F82CF3F10CF59C46FC029B0E94BBC8EF25DECBF76A280A016A47EEE513DCECDD2175BD0A0C8AB34EF9CD1E8C6EB62B842B379B91AA3D5915F5DE7E24A9ACFDACDEB3AF34B26F47BFB5B0F2F7FDDEE9866A1B368B8CA07947BC71894B631586DC42D3F8ED3176F5DEED8B05BFB149BA6B4F093B59FAD3DA596828847E7275FAA4CD596118A75A601827B39E837EB646993F0C5ABB2D05AF8CC93C108FEFDCAB8A35D85591D9417A8E789AA791366D45C5B0ABF8B00E91573171C28C59870CA98BB2D91D4D2A680166A9D5B1578CB4E543CFBCB1A172C9D6A5EA01F493CD04051693544CEDC11A0E84CB997F0D64367B5D4AEB986925099BF6C17194685DF4609B5738C0B6E43CEC33B1736C833B94EF54E0E4ADB48202ABE409305C027C9B4540795E1D994F7C36D6E44F1FC1AE3D813436A134E4ADB630FED34DBAE7BBA7BA4BED747237B2C1EDAC53DCF722365D676D3192D5C6DF736DA13B9EF609DB5BCD8B3A5F69B3A4AC0A25C799FEB48EA08B29781C6A6FF7D0F7868834D64EB2A0E22196B272CC22CF2E37E8F6E31F6E4C5CD0389EE2F89F5197EDB803DD7CB2B5BD0CBDA5CF7E195740EEFA1AE2C04B74B7B2D7EDA2728E6A58338ED1832995A463B09B2FCD1429605E21DA0246F39741D22C91342D842B3CC9B55ECED6961522744E17E3079C1286B6BE29C3AD8D1236694726E479D4ADD2F3B99AB046194F466C83BFCEF19C70C578703661C7365D0FE9E724C30776B80489CEE367C399E5E18EED6AE7FB2B7AE0A7F2210283F4A6188CAFC844456DD6E0B9FD28FD6318AA85D0DF5183717015007E4F4E228F9E2855FA3BCA0B370B7D9EA7307D2AF9DA5F1B08863B7DBA188BE366554DE3685643650735D9A1C638000510BD6C041F2D93A0A1BCF36C073B8F61EB38E93034674CEBE086F8C3116DAFDC5170F925D50E0D29DB7C9728F7D6232004DDB62A06BFE66ABE5C6816C31F393A711BC808A2A56B74DD2AEC4CEFABF0F2D5E354C5A743E8F7E128476D0FB6659AFAD1BA5C2EEA38752334CEDC10E2D9360633FE7A984FC35BF31B7591DEE7DA173677095AD7D6FF6A0AF639C06FE3806D3320B367E1E7AF5EEA789A02DD8758B29D3806DD6EF08EC32FFD13ADC65ADBEA046C160B661B1498777D42D038363B5237FE0EF8E75CEBB9A854F23445C0CB32CCD04B77DF37DE7631CC2614C0CD4B8AB92E1F84110EEA857B3571F161E42297043CF6BDF8B92202EDB590AF06E5D3C7721F90AF931CAAAE3E9C9B3173BFA41B3DF512A292098141E4F4CBCDE45965620FE803FE2D1D65F8338B4B45C1565B64ABDADDC7B8CE52C29B234F6F25730A0B301989D11FCE2DEABE78EE86DC685192E8B44095D5C4F52AFEAB91F14DE230F03EFD55B4B101BF0A28D882EDF2F4875B9290978E6E199318AF28D154E5B81B9F6E3B50BAB7CF0015EDBB868E45EAD089321D7FB38C6E4A12A678D2AB3CB88AC255525AAFE7D3AEC83162634FF04DC6951295F42D607C6065EB92AEB45F9E7B46C8462ECB921E0B812541C4B343FFFEAA233977B3ED713CDC7328C3F9419F94865E4CA501D74379DE4CEDF0962F31F70B43C38F800A88F9AF190B847EC3BD544F3E5A5320A0DD0BB3DE681C6FEC808D45B310A1D16F940BDAFA591301B0B37952A0E196306DACF07F4436EBE431BC311F8A1854149F1D0C89014B309FDB8D830AC3CE01F5DC89A2CFEF4EE9DD74AA5FEB0BCA3F91DB1214D7EF974F5C1EB9C807D87D5A0154F687798D9A17DF7305FB8472C1EC0EE305FEE29C9156626D7D5E21C6F6241B4127780AD6CC5DDE66F1EBC6EC055CB2E90B1B46FB0A2ED2EB5D4ECEB7B79B6CD0DCE0FEFDDD8AFFF95AEF2A830C6FE71D45AE5F4357C33BBC0EB95BC7A777C198970DCA0FA6008F9C8919E1802D419652F875D20B4D160602F8B760A6C44FDD63B766487144E164ED3AF5B3AAA0D78B34E482DEEA6416729C85D25947691C8FEDF39F9FCF754EF8A9DF33DD5BB72477DCFAC0E827DCFACFE3DB3BABAA9EF99D595F5BF6756C7C37ECFACFE3DB3FAF7CCEADF33ABAB3A47B4C00D925B9C9B2DAA2DE7357C0363EA10614E974F88F88283FA5825FCEA33C9838B79485BC7BE57B57640B560F4486F42D6A7877A93709CB0DE0A837D6E1827D937E4B47526FBB4DE97D9955657B39DDC7FF2E25624DCBE91451BAC59F4B419002DEFAC60261A4C9914063356B3EBECD5FB571AF12C702E97A685D6E9DA845FB9C4C0767DE2B4BB2DB44EBBFB98B1FF791CBBCBDE36589D7636678A63C01F0D8D49F6C74647A5FA68BB636A3FC990E2AF323F6F6596C185BA4EA3BC6859315040BBAE3AF1EF15D3364893C728DB5A1B230FD0A3743664B2B7E9E584D04E1D4483F84C9C4710E5A7FCAF61E35C875A76E3C30E37F3503763C8A1F1FE4727416EABF759D595C1CE8A44DAF0A31189375E1003C4EB2E47D10BD635631EE1F9491930E69AE8DE41B969E7A5B5BF30A64339BFAEBEFE7FEF5D1E78349E31C4EA2C8C433FB7E4A547E0953E3AA09B03B75174F65B65841C57BF976961BCA0E96577F0AEC2C2E7264FBAF9610F7A422BC4BAEA00DEAE6063C0A8B51A9A87C7D1031151B78AF1CCBE058CA2FC2789223030DC54DECBECD199C73ED60FA229C58DF1435AA1312C2E0827D3AE5593389312598CD34E4D4A03B56517126A2F9D0C2EC36EB877ADC728372FB347BFE367898A24FCAF3AF1CCA6EDA48B1BE0D7EA3ED71A3E0B79D208EEC76ED7761F78C45168E5B7883ED396F3C9E5CFDEE4F290E11C974F17861AFB24F3894751947B6B88351959BDEFCABA7DEC413FE7358D911C1D22CE06B476CD2181F40952A63E98103939EA368B579B67C4DD29F292F085044E9D23EBCB38A3CAF9275771F374371428D0B377C8FB1E7E42312F4462761953A5EDE8D34771AB8FAB43DCF75FEFE6B7DEF5EC66B6F43ECF9693CBCF33DC71A7861FFBE06B924F7157C726CB8DB78978B8C9C832F82A126D5F9D849C3DD5C1C15B0F8D0BD0607407EA315E5D1E78799CEEB09AC51FCD17B11903778B73DFCFCA16DA0EB5E2A8AF3DF1F6DFBE3FDFDD4C968B07EBEDBB873F9BEDFB858DA1C84BD7DBB78BF6FBF6ADF698D7BD01ECBB256A9CF5C670BC7DBFB319C7780FF35A45A5E8E4937235BB7D31F7678DD7B3E987CFD3F9DC9A371E109C0D738CA370B509B3CC357714F07E678FDFD9CE09A49BABE9E47A3A5F7C9EDDD7FB6F81DBB812D8D8DB751DB2C1673CB3D77E3BD9ED4E059ABE3711D8CDE85B64095D59C0043630F6F6BA51CC0C7F1CDE3C3DFD0769531CAB9F5B6601F7C1F3DD5CC6E5DB2A71A1D6D8F26D6D9AB3A5FC1EFB9BB8696EEEAEA6D7A47DD386187BEBB4DFC452378D32DDD340DBE53BE19F07E14FF23C0DA26A39F7282FE78B8FDE643E9D78FC974087D364FDA64E0EDAADD6E40EADC7CBF3931E6BB071D7091DA380F5E0EF3FFC5FD2A894688F99B8BB68458CEFFEF0870B0929DB18217FFB15F9F1659AE46CAB317154DE455112443B3FD6B62F4081BB4F9755E6EDB119B1E42ADCF1584F49A19DD6DEED1F9B11D882698E7E7ADB221004DD543962F9AF5C4F384D3D25E5D459D011EBAC468DA41E991EED49471E187AED5AF7AC7D09489E034C2FB41D18818284184A9545C59B25CF0C3BCFCC5A7BFDED3DFED4F445C202519F1400AA4B2D17E25CFE74975C857158846F26D53D2D5B033F0FFC35E024C17AE9A6DB10656B676B1892B79A6B0C29EAE359E17783D5AC123A388362618DB157F67E43CBC9CFD35BEFF36CB1BC9BFFD678113101F4E354B94310B0D0BE80C046DA1C981E435BE2F00CFCBA720B19640B10261343579B3AC5B307260CC5D33D61C230BDAAD7EE64C4DE8A5C5A8FEBFAEE9392BAA1CA10391FEBC934AC963040E400E5B5FA390CD9E94689E45FA637F1786AD3CD8AABCE8C227F2CBDBB0F8BE9FC9749358AF974F170BD5C78E2F7D9CDE4939ABB92B0C0F207888042A6B43E00F40B0F792821C262C23064958539EB2F9CB09E2845584CA78B1E8E4FF4F2A00EE487A435250204A9F7A17175BB08F2566CB16108DC384318CA49573CD74FB590EE09DC3897CE7A3812813792CFEC76713FAD0F291B42A72052113C84834AF8A47E9CC506B099390C9999DFD3D1B681CDCC3AEAE7489B6176737F3DBD01460812A68E0A499854DB014242DD0EB48E28F603665F3ADC105693778A1D6135B9A88E6E7771C8C57E399AFBE936473392FBC97C72335D4EE7F571084E835915B041A8DC2A102EF25EB1E99062CB68E664C08DD363463164B9F37964201E3D971BC4FB6F9F1EF3EDA6BBA7DF3A4DC925932E97935B8398454375AAED027545B551A01938C916D1CCDF796D0ECDEC7E5BDB42757CDA1E28747C2711BDBE95D3C47E3ACF4A187373989C8F20A6A44F1D312A2702DE00545A57A22710F480A46C1A3D86009E4227B7AEE6B9EADB99D1B9F77C3AB99ADD7EF2D8EFF96F480EDD817144842AEC000DAA3A3F063705873E2A051A268AA8A19EFEEE938D49EDF5D2AD36C07D678516E673835F71B68774C2CBCDF6147C43D79ACD002A3708F352F36A440A12C7E5C4EB43E811407CD3C30C0FE8E001CFCB09C9B03D19986E1C27E974CE4AF7F7D7B3CBDA747EFDE0DDDC2C276AE724B92EE88CD454233A89420D00A475E8E7405E43EA516296D4DFEDFA53946622FAF661049A3AF4F8B82FD467A35C15A228C582EB4809400C312915DB74444BEAE1619671BB2D7C17FC493D170E7A31023DDD4C7E9E628849A8075112AF42644A22D61390916260A8D56B52F8F5A020C51C603A503FDED676632C12329D6FED4A58E23152CEC9CE31683423538CC5D1756A42615D3E448BB8FC3CBBBE620AEAF5FE1C9E2D96BA734C03A638D3F6102389EC862E2A9E2DF0EAEC9F5A55BF06853A776725620A313464CCA04D3A3A119386E9D4E5268AD79775CF4E26EDD70F61977777D7962F78B008208A6F60892730BAD133797A439D24D431DA0447EE41CED49944F7EC5C289A6FD4EA0FFD659D168A46BB03716B7D0F35CCBA35FA51A81B9EBB9391343C5198EE2C5977CE818CBB21ABA6FF540B1D3A200B063C341DCB7D04C8581EFDE054AC9CBB9310B17296B0BD39A947B77220ADD06B97130B92EEC25359344AB6D036682455618023532D3C3D6740C0F034E20D07DF0445CF9637BD289AC18F4BD1BC410A45F3019E8EA25BD3735E14DD9AC66F8EA25B6E1F57D3E564C624A6ADFF149A543F15989A7E25082BED4FD9AE928C455FABA19C3A71F382A10F74EA2A2A159B260FD3B926B157AD239E4C54E646C53AEDFAA25C354669ED1513505F75CF74AC4A098DA46A837257E02E5092A13798D5767A3F6E580157FD199DF6B43E1B725532C50D6708167B06D0E9E2352FC2ED80CE1BEA09C210C41E3467A08EE993EAC3514FD499B043D5918BA305D56941255CC3898E6B1473B0C302C520046A989BD3D2AC610E319D7BB83C31218B0206139DA275A81ADA8592A4897820E286515004026A27EC895DDE6B0E5481C5ECCA643C87817AA801363A40D524E45D8D5A40771217664ACE4C03684F9D8DFC9F9FD8567E08A3D5F983C7D432D0AD124E4DBA13F2EB2B5353CAEDDE19C890FAAA711A3034A1CF5049A551E37439E8D229CC2B1D224273B8CE3420B86A2F76DA9D733D718E6546812680C843DD334F68A21C75EA74A4895717B0084622D833541AA833742614DD4B753853E23E0CA4B945A18A97AD3B007BB956A726201A565234DA91CAA9442BF76CEC2B19CC32F5EED3C89EA678CF252DD4D9F9999E97E7126AEE30A4339083692FF7A553BB96B60622466947508A180C9C48C85A5BA3AA0DF0C5AC36BEBC7B3A548CFB7444A89824371D1A970C5B3FF93FEAB0461A984108516A047E1BD2EDFCE0A4A81AFAE96851354FDF223156693F5A9483201301444F8A604E16243D8A0D69C9717842548C9BB0EA6ED2B59867C8559746E78B871091D5F43E7CA88907C7B920D0A1B824D8164C9DE088C6E099BAF93829EBD44DDEB7C841855768E8F778101C8D60CDD7D9DAB6CEE9659D6E324E47ADBA69C3F4EADEE77372461A10FE0D870EE8DCD4F9B37AC08199B8D35174AF571CE7C679AD5E7220E107111DBE81971CC4E939174AB67FCEF1CD10B5EE3107127E5CA23E9FC71CC4E93943A226BEE8380BA206067339B9BEF46EA6CBCF7757E4F7A47844EA4B31150EABA71F840E9DFC41297DF2505755D5C3A13DB1792F699678811F07DE362C36A9839D613BCF03F67DAC9840F8DD01572705991A444057F4EB845B413F5318A2711883A817F19E3A1AD1CDDDD5F4DA1CB7AA5D0B24485E8114B9AA8371FCD055D08050EB95AE43078E06E0F0FBB73F862CB037546BE9A55D093CC38957091D7CA3130B341AD4C1E4E492001A7BEFD6478D3C2CF9E5A996590D32404C6BD94FCDECD937789461D5B8310B3E50C461D53CB9EAD208A4F8B098CEBDCBF9E2A377F9B058D6EF43ABBF9594A884800811AA4CF1D153370619F679B70773CA337605A5B366F9637F0A342E41EFAE8C407957A11F8759BE8976D528EE6EA67375FC03A832446F4DBD912CF460C720DADC170EC42675F3832186061EBEC14193A66E3E5C74645CC27CC8C36C1204619EDFF83B1475762168246A30C8A85B01E84DE8F9E054078FFB54A407CFCF37427F877DE38187A78A3AB450101DAA38928E04F58D40646875FE5B11236A025007639917E936CCFA9FD3A8E972D2A551C912C71415F529A4686088AA164EC50E0D233E15ED59F3C273A03A70E798E30EE9C146D3544E1D8C08D7A9D13568DCEA7C435A74D37724735401908C3906F6A86CE354FCD134E8135A72EC99E4995060E7C9FEE719E3FDF3DF5A5BEA7AF651ED638C8005534D01602369DD981E9F282D1A613231E4B589F22A443C9C67119FD30A3F61985ED56B77264148F82500488BCA2B1314B8292409F9D107B259806E313B6D900025A6B9C1D0CA3E2888A31B1FD21CBAEADEA9F837FA7608056DCBC34D7903516D9FEE06893437A766C97D6E946AA6FCB9EEDDE9725A42C37AB85CFCB6584E6F2CE4900EE8B72086743B7C8AE09EF8793C35B98373F50D0820E2436D6D305AA8329CF35CFBFE7D201A067B075D60A5DB5D9A0C2B3BEB660AA98B2591932CE9EA39C1F4E338576743A0D4585348F8F325E3B38D51459CD95392BD83E854B503B2B67B63199197930FD7D3CA17959E790F8B406958AE6029CA22BAC53349BB479D210CF194B98B8B10EA4C627AC6CD8527E3EDC280EE6E8D063E2504955E0761DDEADE9D480C314ED7C988579E9B6F895A1BDF0A14A76D553F373A6D770D2052B58B8F7B0A0566E924E4094C09A61F772F49989D9E341B53F8E4E18A893E9582AAB6201B21071104144DE9AE96BBC3199C18F5937112BAD44F5AEF2E9D8A4CB1E7BDF91AEF947CF43CAEEC8CD37562C2FD56CF7B9CD55705706EB47A7ABBAE69A64E42A6D626DCB3A1528A97AD016E9063FF0C7D6D91D3701A82ECE96B7B46C73D341475EE2513208D380DB7BEC6C6CE9A402FCE8E422F2824BA4DD7D16314AEBDB3A0D5ABE9E47A3A5F7C66DBAC454E5AC2014194F4D9D4263BE4C20DA9687378C9C29E98B52319998CB5CBF7ADF1589CC3AE12E2ECC4D4F3F0F535CED76938AFB59BEFA929B63A2E78F7D5EF6D0E35C01736C0D3681DF36C909178A5BB970B5207C6A3176922314D5F66A15F84EB0FAF27556B8E5DC7BCCF92EB6229C7F42E0BC07CB23759EA516296D5CD7B7DCD84F4EEC4182E7D55AFAFC3E730E6CB8725303D18E8CAD78518CB8B4FDFCF53512E6EFA30F4236052240FC57BF2A1E6CBA263A7639BFB006593E57272F9B9F62B17BE7D9C5D4F17CBF974A28E4F4AC202B25A190195F392BAA0898D2E8F7A20F66C3367289EB98F79E817851F6C1CBD3EB09A5ED7BD1D27526F3B81C121CC56EB9B2E48AF0154119F57842206EA35356A4C5C315C545EE47C10E8C4598A15E4ACB9EA9A73D29D3298E295C1140C22CCF65D596CFC2C5CF3AFE157B6E4F533763F49D2A242F03776605DC6597514720FC55276DDE6581761A1383F7F7853D7D0492E12AD76518A12848450AC60C0574BE91296FA3302D69B3096A540B02FC360A9372E8CA52E33CD4B4BB594E7A45568EA8DDE0552EEA1BEBEA135C9E559C22FD540F4BFE5D80774B8EB07674007BF9191A918AC66C02DF824C858852B7C2C3A085353861BF0F5DD27F530AB42E3CAC2AB69EE0167A3B39BFBEB693535ED576E103A4555441B0DA518DB80AB22DAB8FBC076DE2F757A98F974F170CD53E2814D8035892DECB3901AF1EFEBD1B0233A8EEB31B460DAAEEB0030ED3540EC689EDC4C97D3B96A308ABAB4562ED94C2C27B7CAA586AB1ADA6826819D2957B3DB4F1EFB0DF222654D430BC778B712C663898977DCDF5FCF2E2B52008FFAA6D888AA0E462EA1A83F1B608180E11222A08E797A8E022F3443C742C4010526D1028F56B026B28576666225F27625D4BCD609BC15135A1792D647CC5B63582AB1BA6D5B553A117C5B5575545BC073284533404D6A0BD5C2417C465913C104D2751987DEA25C295841ABDC249476FCD8646C6DC72F13FFAB044BAE851CDFC344DC5C29B33F4545E2D422E6148973A2C737A1E3AAE54C03C64325345B3B64ECD530B743153C4E855E23D530638453654298E19A7446D1C9008361151D00D301572737904FB8FABBA9B7F0E0F19AA2E44C04EB8C5235D3D1738C47281F38C722038EF66317194DFB850869CB28664CAE83D6DABA2F04D43A975011B33C6DC71D7865DA35F06299379DCFEFE62AED0EAE47C05E6DEBDB8F3313F6563DA42C0398D595220D5097D68ACA1803D532524BFD22586D3A906AE0E9EF52A59701756886184D7F9535114A92BAC79D528AF26ED2D891D81444DB2E44E099FE3255AB7D8742341EE320E56A78DC3A6B115C0D8FFBA881EA71B7AA9114EC85F7CB6CFAEB143A94551551F899AE7F3F6782F85E33BFB9D12CA6B236D16453A583365B6CEA6A08DC8BCBCFD31B067369241EB026A9059DCD46AA85366FB02362FA09663D502592E0689417A982284E08C58AB8BA7DD32DA66871DE3EB095499B6BEA9944D755ECEDB3564FEA6BD7C7280EF3220BFD2D24D16AAB23DABA0D5F8E967005FE6E151C4EF3DD83AA2202FFB20ADFD1E8A20AEC72350BDCFBDB166413C7DA14E959C74C54156D2D339F675CBC9A51AC334710DB367FBE63CC6AF14069F30862DBE6F56CFAE13393B3298D3630A8565BEEE615BCDA5204D444B5C0F6840173AB060AE33E8B9D1E69B79280B775E50DDCD5D6399ADEB42A8937B64016A7AEAF50A7E2D12BE3389CCEC5B07497AFC47370B410F0C81E79DDF161C75EFBDCB05FB972F0AD2A865E373595C3870E3D2DA2E1C62FAA2C863B6B79766808D44326E18166D67014F5680C9A7DD2D53E7D59C0C086E2FDBDBC181830F5AC20A0A189C75CF093DB51CC797BF8BD27593405D4361D7956C17AEAE141D5A17953EA8F666CC0EC68FC0F6CB80278EBEE296ECB21AE4041A0DBA8043C305740F90FF46814580B9C5341EF65917B741C9D7145D4B0E87951A240AC036901D40D21E65EE5306237FB90B70B75154838F4934441A55A158C034FBF86475F25D02B463D5678996848F4D345C2A55A288C3757CF96152B85F2F1B25C2AC8ABC833B9362956CC069761FA2C502AD70FE340E5A6078A7524788B395F4DD0B18BBC8E1016EBF903908DB67650DBAA55C3F8C4396694169BCF029525EBB2D87A4E59E7196E3CF520E1D552D6D74F89722CF0BC1BA758898F308FCEB782E01A6A22F76E752C4975A06CA74F850E983DACE76B1F2D9A75093411093530BA2EAFE84267AEF0C0C4E474E8B59F9E6EE872360745973B991C7A0CBD937301C2E3CA8C2278AFD4EED0806D0AA8A6B111C9B541DB53C7AD5A677302F00193A372E7A6CFCAA191E374835B03A8A51E835C199A12C5104C987494E2603AB877BA612EC42AEAEE0B35A15980BCE1B538C618BF667774CA0DBDD6EC07DCB0C7DA00875BBACBCFB3EBABA393FEDE6303DC0C3A082D396B00159B44E1D64041AC3052631E26D0E7B3794540BFA441C3AAA7028B029A6DF50308BB264E702123F44D7C1E629C7201003D095D3877932BE0D550B2E6154CAF69049E19696751AE8F1AAC04E6660E65B4C0149A5F52399C41F1F50F613205508B09E86218628A85168CB36D780C35CCC4574FA1EC269E83F69B168661E089E72D50261E7A19663BF172C6A8D9D67F0A35C79D12C234092A40F5EC1A9FAB515A51CEB0F9C99A9D9AD2B839B6245E585781AAEAD50C0042A5B5281FCFA1900E2CC0779B55E9FB402DEC48547ABFEDCCA8F47FE1E1A1E38951EE07D35CA192096A866B4A26E860464DE9FFE86CC162BAE1379CAABE5D40134F45A19E1F22266831706F527BB53AEAFA28E97076A5D11314F5E96708071BFA9CAADA806CCCB8E7C5B6737A701B031EF2AAA6550D621AB512523DB9F06B65126E25A56ADF2D3B20D2EE081054DA012090506738083AA5116877B2F49339DC34A24E3F342C79F8A833D0C53C9FF8245476A2A5F0E0F96D0B8ACE115BCAD3C0BCB7ADA6A9261B8C34D2CF808B3279E90170565694C9CBC27A7B3A9357AB17928BBA760EC5DAA8818A9EED4E664FCAE10C5DA8EA1F82F59A3739CA8676E2A4EAA8418A506EA64EC20ADFB9E88388F49ABC4308CE63C7B57327D6460D5200D2CF9CF9F58B06B376F69C131D1C2DC5447B2014965820606794082287A7141528A6D7FC0A3764985B411004357808D2CDB4829847BD186C6F0FCC9D8AB63E6E5762EE54E85379B23B15651FCC772A58508B0930DFA9F49DE293DFA9607AA6B853C182F69B16C59D8AC3893FE59D4A077D2B4217E56E9680C3A4EDE051A9B52C150E84B245687E24BE5439EBA0D64251D3E007849A579C4BD1E9E6A87EEEAEF1ACEA54D00CA35D0F9C0828FC9C06C5A0DE5507C15835EA4EB986F25BD5C04D6592D53B08061D71EBA64FB25DE91C6FA5DAEAC1A8815C38E4CA5634B3B5CCC1BC81A96B55811ED495D52354C2409386099D88C43E5C50842690A27708CD08FA1980F5D44381AA4373D489F2A8991A101F342BAAF092BD66464C26A19D1E5D762FD59814A9BDFA4D94220F579B42F549322C428CECA71F4E0A0E051CD102A887A98503839128088380159A404C74D43ED368243C5555CC208D44479CB4F1E90D5C27AD678F0182C89CB57E3E6EF8FF685E3F4D4366AA53D6C5080766BAA38A1B27A03C30B08BF8DE0878198400538F18013D5CD41AA19D319E5B75EFB8B9F80D0FC5E413A184C4BA2FA810983C24CC1700C876D45170F4C9861C1136460DC10112890EA39CB821EF13A92C605F04BF45E45C77A188C3EF000F37CBDD664670D914EF7355DEAC603DF5E0A0EAAE23B5A9BC5A9B102503CD11C1B5070B8A1F35C1B1A7CFE49E855B4F93908FFECE0D0D6B9037112894C22D984BD0AE8913BC7313FAA60F37A8AE8C1EBC3EB4A0DD848E1C46B0D57AC720A19DAF764DD4C05A006E66AA8D1098268D6DA5DF1CA9727F68A74B01841A280CEB661215B8B57A8036E589A3A945EC58B482A584713D85A3A950ADD68D52A5B22E6A704609923E5FA34B8BEDB691164C13086EA0482BA6C5149ED69269E809F866C708633D70F0558E9B39059FDE0C39A9AD50EDED1128A613AE6D182D08A49C42752A2A2C66D50CC229ABFB11A3D1C4A9AE8CA311A391D382EE4E70A1C389976355468BAF0A35B703873AAA08F1FABB8523F4D0B4716CC970DD02544374DF70CD829E86B18DDC15B2EBF0398C79EE05C4FC182034D6222D206890EA42186262E9D18FB295F6BE40ADBC719EF0AD9DAB0EA03D12020D3551F080F42A23D0932FA9418D43B139A59F955FA698A449F01F57B8649AA0D4F361065638629AB249515B31FAC313E6F7A7B73596CB3429FC2809B363D94F6F17C126DCFAFB0F3FBD6555827057947E7C93AEC3383F14B08DB68B92A7BC81DC7F79B3D8F90127A4FFB1F8E1CDD76D9CE47FFF615314BBBFBD7D9B57A8F33F6CA3204BF3F4B1F843906EDFFAEBF4EDFB77EFFEFAF6E2E2EDB6C6F136E8B09F9F84DE1E5B2AD2CC7F0A8552D634EBE9C728CB8B2BBFF0577ECED6E672BD95AA2D367E16AEF987F06BD125819F8EB37C680B64B21093E470BCEC00C87FEF9D5426D722CF15E19B69FCC846C6536355830CD5AC54C6C0702C023FF6B3FB2CDD8559F1AAE8FB6CCDA6258DCB6DA22E1749568D9DFFDBC5577F9131FCF45618A238876FA54914E85A5C1CD4D2194F37FDC2E9C111EB6642A09AD80E9CB86652217EC14A2EA9F965917631B63EE371354639B183DD123CC6A0CC8B740BF6502822E0CCF247085FF3198F2B3CA4AE8BD6004AB9148F59D886865D0ACFEA89B698C22153BFB12020C47682C1C658FA614833F48B70EDADD9BF6217DB25748C65A50F4218EB123CC66DBA8E1E23B0934291054EB99B42111E671E15A19748C751EB331117CF7BC9252F09DBA1C00ADF7B25C2F7748CE5AACC5610C27D0111DF2ECD8B205D4333D81491472D914DFB3B115B909649C1139F4AF88E25788CBB2C4A33C658BAD89AAF784CABCC4F820DC0193A05845D9C7BFF4A57D5B8006E2316DACD21801928C6E3DEA4F1DACBC25D9A151EC310C5DECE8F84534C5587D84A943CA7511032B6F39A030D748B09B3C3F4942ABA56EE6F77EC7F5F2271F74315F0F80B6ED59067BDF5992A7AC162174DE4BAACCF850FAF5CA814114A8578BC1FCB389EACD719135BBA383B056725C4D489406D2419101229CE2860F5320D5B17A560D394E1578B037571D55F08DC940128E462A1E834A2BB1F14D1B370121DBE9D17152A223420A81082C452210CAB5D19054313CB881C5296E15A9FCF66A5B45774069B821214634FD0008FA1F37320F1583F7CA36191D7B9F94A613B79FEB216F94DFD0D8F254A0ADE741C6E775D549D02829D605B256EEF1807B6402E77EDC8366912D6DC5C16CAA5422ADEA4DCAE44DDAB5B82C7F8E87F55F55328A2E184FAD8FE4E513857512C69AFF537828058E96917825078F848C5236A82164A20A4FF91553F58EBB352F8005D8FAAE6811A9E8D7297326D264A13481CE916E171C67EF254FA4FD0992714118E3CC659C2CC2FCA2C642A91A871C8A5148355C6C4AE0052F484223CCE97307ADA1440473B0584190D93A76203E0EB14D0C458005BEB331ED73347002D4AA780626E601A0FBCCC4211F1DC62D085C8263B05843147E18B8069FF898623947190B8004D58579E21FC32D08BD3A728110E91760165FF1FA00063A854F8DD0C8CC6E9D00C9CED0A6F9731F2EFE26B7DC6E39A3EFBF1A48B67FF8986E3838CE30315C7A58CE3928AE39F328E7F52702C6E165D0CD5073C3C5B81B40803467E22FB3B7EA6080ADB9D9F4882C2FE236153575B765BC5D517151BB18CD2BB38CD2AC7075043964A09425698AC3D26050B72D6F12B1113A0A9B4BF13B16DFC6C1DA43BD140DF2D221C032FFE2BBF29C80A80ED488544BCBC530AAC4D11016751F8C14640B6FF46BA93480AA62CEDA230173749BBE4B4F796651643F684E35702D5A4C230AB0F9423799532F93805EF33A442C2D1C4A6C60B364CAA0FBDCA9C9066026F806B504437C67EA3F55E64A8341C5184032AD8E2AFF74911892617752DA258749882FD9400B291548368E4E1A04C69C95E77F2010294136E4016B5AFA9443F9D02C28EF3D97255629617E49E1F006BABA8423758A5C50614FD9B22B2EA0D9E57767782EBEA212874C6744B28268FEDD6673D818EAD6E111DE75396963B18E7BE88249D70F3AD249DD41F297DCB77EC341209BEF599764BCD403C7FBD151522A1088F73964F0F4E4FD3B5A8D64A8524839D17474198E4B2D5AE29A0E15B87CFFC5A5814F2842282E926F3832F5E996E059B4DF399E258E66D423F2E0401A2F599E04AB6F8D3BB77DEFD6231F7260FCB3BC1914C2CB4C23BBDB9BF5523DE97523866212DCBE11B0D0B7C56774B48AB52B27D91057E9645BE78AAC9A578CCF7071B64C2FEF4FE51A6A21C0A56389BDB2F6A3803C3DD25051BE63E93864FC9DB042AA2F93F84BF73639E2722697D261835427FCD062C98340E1F09E6DB344B3CF681B1CF422267A9903056264402973FADCF04AE9AA6B1346BC78F8493899D10197F0A2074AAFD1D8F0D728E51FBC49C68579A53B4E8F7A1011EB1F38C180CBB05F4A96E0ACEC151BB323165305EB18C8C354F4084394926E3960B2F4A983217C7A2E028961124D16DE9F123B98615C451A18C74C2EA1003C50499CFFFEA65E1AA8C6251E26B175074AE7CE7454528C87BADCF545C5C53633C12C2772C22E294C4D1E6EB29AF0FDC5F710C717930C425C77E0B7B8924E2754B68182BFFE93297111E0B88F81897FD5D96C13B25F431AFC33C1009A85B44D9CD5F20537AEB33699D43C882D9FE4E91CE2A56C2D65114D09AEF746C419A175EF553246FB8866D0BE1233BC2BD47261A9759A86B48A868D99EFFC8181BA239A19E656BBB2C5DF9AB2866F209C315306945D32454D9B2DD6D94A419F774F7A38CE37D8E72A6CB69DA560158B65F26075FF535AA79457DCBD65985A08C7DC94CABAC4472EB919C7948524C243F6FA1E927CF3E53F657317F28213A0B0A45D4D3D1E31B2CF073D16A2816522D54EF3CAEDA4146AA430915E3C53B35CEA68C8CF5BD06EB7B3A56263CC6C55A275B8AC58415DB7CB9130DD0876F242C4D96EA251FA8A4E52BAA90DA9887BBD80F44E9A3F59D880D10A9DBDF49D83E46899F04911F2B870FD420B5F0AB9F657E223EF3EA14F4E67317284647721255E0788F6A89E4469AD56460E2DD8A4A74974CF88D8858485AE309F70D63FDF9087350A802E5F6913F5FF194260AA89C262BA70947507B65161E53FB4A4055002B5179ECAA5C3F8585175721966536DB29268C615B0AFDE51F2873202D594A5BA3DA47C72B83BC5CC182BD584C90195E73A6DD7BD7CB2BB50104AE72369641633C5C8381FE407E50C86D8C415E0F3F8C01FED8A8F4A8B15D40B8FEAA8E603930C3E1EB50C6647D7F640377FB3B095BE9C7D7125F687FC7635B4685F8DC62FFE96CB60432D98421AE0F0209627FE0D0A8267B13E5D53D97F4DABAF59DE67A9D26AAB77D7229E596881F5CB269ADFDFD5B3A735CF97838BFFBA87C75148FFEA4C253DF7C0C77537384E577080AB475910D4EA63BAA705645D4F502F645EB3BD11B4F63C886CA6DB12B684C59892C73713089AF89656773A4186398EB0F93A3B394A59465801F46CA3A362AA2E9147C97B26AA84598457E7CC39F65CD219F0EA8FCBB0C67DE70F4BDA682C4EC3335ECF8875C5E518C78F5D47C2538F5335943C473F84671F9CD832CDA15D27D43A780822F8B9ED929F2988917DBDD1282A9605BF8E032740A281793D9971012DF3A05047CA1AF7826DA2DC1634C77DE26CBB96F178F89D4C5299691B0AE237E77242E4CA780842F939F0E345F097B42F162C8EEB110FC4EC8E689D0DE95A5EA06E840B32F21EDFECA7139780DE250A5B3292B1176215B4F3F6138E0EE03C5E45961130ACE49F5DDAEA7124AA990A0FCD476574993687F27633BF40744D91412C5F3BD63A84AF6EF16E371733715E1F275FF098F636F200548A85B42B93A7517222A4E035F3EB89AAF842B83320B367E1E7A357B15EE0BC4423BBC9C3ED488EB520BCC32D508451638655B8B504491077699D4C3E347129E6D586C529143349F09925320FB3E1FBE9DD245EE3F370A402551833E72DD12CA25E993ECDFF544938DC32C4B33C04DBEF98CC7F51887A0D0D9FE4EA0E05DE518EC073CE8BF40C8DD223CCEAB0F0B0FD64EBA2514C7662F4A82B8949D99BA25244991D1012433B50B08AB5205166184A17CB50ED720D1A112B73D56F63B4AC16BF97601AD97E1D75D04DA35A542C2257699AD526E5A84E2A80A6514C376526469ECE5AF1029C8A504CC7ECCE44C3FF3EA7914108B8594F9E5422297E2785000B9CF503945D2F3AA41FB41E13D726F09AF6601A0E066ACDCA7DD7CAFB454B65E48A24782B8EC036A0E1440BDFAA1D41E4D75A94E220A576BA9908A979F714ABCAD42C2FECABDFA4007C364B78B08A74CED1408A9B99D12076B8921672B2D58C6A3D6BC4C751DB48A1867BBA60B4E8568B25395C07BFD847B21425CB75342B1E2B09EAD799C8132DD7A51FE392D459D5151C5BE8D2BD0F4A0AE65DFD2CFBF22C673AC64DFCEE5FE38D537D4D4B26FE96319C61F4AD151595D8B660B63783CF0C1AF5448C3CB9D9DB5B8A50A1656376503700D8B16B4C350D7EA3716D9C8ADAE856FE9CB4B657B578E062A2763D7CE97AA0E41E36154EEAD1899AB1B5154B169433B184D35AAC41E66EA66E01AFD5A90E94B5D8B6C65F6B45C455989DE8E990BE86BD25B34ED205D3D7A6B085A3754A5B789A0476D4D7C8B75A01906C9A3B502D20D544EF04DA8C2C3341E32AAC834620D8A6F45E04D7EF974F5C103E40DA9D0062F2C3341E536D8990874F73017236CCAC536B86189052AB7C17EB9A73C15F6A69C24D9D7523A47B3106FDDE4524BCCF00D9CA28A6DEF6F1E646F41B846CF51189AE956C3B7553F07F5E228F9E2855FA56B27A0D80E77B4AD3243C9164365A5B3F144DA7B705FDF7DB2F521074011BE483A60D594EF7DB895CEDDE7E3C1BBEF10771D027B5A17D0F1C9515FDB0504B37996AEE2709BA7F13310D3B85D44EDA37C63DAFE8EC7F6B27FE318C47E2448984211F5D204BA2FA1B94D25E5A3B7779717B0896514C378B46562571E7AFE560C01DE2D22CC619A7D4933767E89F7589D82EF17BD689C1617BD278BA8651345CB2E7216C19DF409BCFA7DB2B8F865A7697D13DB45D5FA4CC2C5385E085E488965E770BA30A12229C5F8A2C78F144EE630320D03920294EEBF1146563F40959CD5DADFBFF32B344E878E29F5EBEAE40B4F15D47AC7226F64B012BE9D551970DFE397682D8694ED961030726FAD70CDBA546CA2E04B22E5F5042B10F6F9CA5BA545916E55F8C10A24FC3CD48B06BB584C31D61405B7CFE9A6475587408FA619022B90F0B3DD9769B08BC576F4281B3BE5D25E740934A0AA4450B84B0167F5817289F4543F0EAC325B895747DD328206C2A370E4D03EEF96903142DD148AC838158425975274912CDA81E3EF96903182CBD42D22E3548C5F2E255C8D706F3F85DFBF5846A275EFB1CA712F10FCFE2B4957CC0A6F5365879334C65609818FF35C3200BEF6778ACCCA0FD9A75294B9DADF89D27451EEBC8D6C8116CBCE49C7F16637F7D7D3CAEA3EBB5DDC4F2BA3928DE2834284D38690A83422F03E6816A48D888524D1FA002A8B9A52214D3074A3D26DF9EB51F8AA4828C2E34C9FC38C290E1EF0064428A2DCB3B3DF5E983C47599AC8811480629AC9C693739AB73E5354B2601325A25271F84830ECF54EB1CEFD4B22F9814AEB33C57FDC17AFCFAB2F04462C452E0E89018BA5DB0AE2BD844D5EEB1332D92608534F268B418464B23854633359CEF69A9067305B14CB290CB27A462BB39C4EC1985B298302346616D1191D45A419EA906BAC807ACA5157A3AD8A173D258CE6D7F2EA3425EED9D50959CCDD87C574FECBA4BA139C4F170FD7CB85158741E04132181426F5BEC8CBB8801E65744BAC28DB29C74A57FC9575F54E14EA2E508CC7ED059B30F82252F1F1E3D912E0EC66F2891E050785C582F81478F48A21C49B6CB2BCBB27E4164579BB4DAA21B843F1B9D2496F0EE580351178D2903BBD05ACC46A4B24310FC9A1ED6FBB0ACD5F019FAAFDCC6C1C3D78141E5D0F7BC769B9D65087E5CECFFCDA14C1AD9382315828B3EA2DC010E5D2F322CE66C9EF27F3C9CD74399DDB314614262C49E2708DBBCE0DA4EC1726969DEB1A5FB2236739B9B594CE3188E82BAC41A53148718F5250B011CBCE843D0044D32D213D14621AFAAB57B98049AF83DA45674386CD19339F4EAE66B79F3CF6DB22EE31120F8208D198CC3685C32B995091C55A5FF3ACAC23D26D54BBE4DFC66271FDE0DDDC2C2764EA53C021A84D09A9B4153A0F1678AE59CC1497C856F7C79567F193CA17502E2560DE416FFD9BAF147F8C7142E729C3A0588640F9EE8DE7CE1B2FC83DE50617CBCE866B4EEEEFAF679795D9829E6ABB056CF3DA44073DFC96E5BD5B4B6888E90D763BE039C9E1238974E081750ACE86686E263FD3CD1C1010824A60B0514E4427DED31C42A691E62B414358E5922C77F8F69DE3A3713AE6F830C1754B08187DF1BED527DDB54A69048939048FD98C04BF9CF6773CB607FE4E3760125AE48B919885223CCEE5AB98E9B5FE82C73017DFAECD692FD63EBFAE33BF8C23614BB73EE3717D48D74208EDFACBD9B0FAE57C72F973E5D831992FBDE93FE92F988C1810870002875213D9C703AB1345875F211D425587E42B3140361B97A75991A63164596B7FA778E02B32FF59E6FCEBAE00CFCD5AA585F4EAF0B9C62553009CCD2EBA7E3810AF8D7942018AB3502881C725E523A402A1052E10134969DFB2635A8EA0DBFA4C162F32009F5084C729C5FAA6C6F7CED22771C20FDFF058AEC34731BA7AF585648257BDB8148AE8386174246ADA44F13ADDC9A4D9FA4EA083322EA29D98EAA6F94A70398BBE866B7F9B96A20B5EA7C0C620ECF2416D908AE258FD85E09E99A5E54E526C9AAF24E35818707D433E9684220B9C720C05A188CCBF145642B9948839794DD81F00D24301814396DB5DE0EFFC2012335E774B2822CD57AF4E332DBACBB60B084E29519CFB9C7A796C62EE7B22E83F5039097BB07952A3EE16D22E7DBCA8080545A4F5998A0BECA15044C429BD7B6CBE7E3737A0713A3437ACD297787F170CDC12CBA536E2B797A52F2A49BB2EB3C21A14DC20C24851BA835756B26E272F57C6668E75C85CBB7A9A0472EC7D0981BB02AB9893D76E73B03B1CFCDBBDFC75BB2BD2AD283C6AEA914C5E87E18256AF6E21419E4BF3EAD5112C258A85040B7D1CA72FDEBADCB181CB819AC442C2DA153E0FCFBBF674EA92B212C1D7D73A3EF40993C373230DFBA7F6C3B8066F78CC59E27178104A301A936A0DFAE534BDAF7492CB9A0244545221C154CBF513055AB1ECECA8637977776DE92E6B4641A0091D9261C841B5623624B04CD3584474F846C04248CDAA9C13EE127CE517C29BD4D667C20CD5629C9C25B75340ECDB5292085A9FCF667BD4766E4E9496667608146D5F8781750665853DD9CA38EDC95A6BEB3311976C856B7D3EB3E53EF0A25FEFE6B7DEF5EC66B6F42E277DEF59F4C8C8572E267404BB7E1C6D231E5FDA7C1103563FF59D4CDD45E56D8A544A10E42326993FC6B5BFE77D1A89763FA89C843D8FD9970B09E9E133B1A74598F1246E32BE7611BD7FEFE1FEBDB7ED9F8CAF5D4450E80DAB039593B043ABB3B5599DAD7A75B6B6ABB38557676BB33A5BF5EA6C6D57C75FFFABCC0B8F47E61254BC760141BDE3A31294B9FAD3F91F1EB3E58DBBC30340D6E7F000D1910F8FA880021D22AAFFFB1E1EFB4C8D6CDF6CBC24144C7852211EEF0B0FD257435EBCE3B9058350E47C8A2A566DBC37B7F1BE6F1B7F34B7F1C7BE6DFCC9DCC69FFAB6F1A3B98D1FFBB6F167731B7FEEDBC6FF34B7F13FFBB6F117731B7FE9DBC65FCD6DFCB56F1B17EF309BB0772B98ADDE7BAF5F2036FB857EB79FF4E86DBD76BC9A2E27335B9DDD88077DE02230E96EFC0E2FCDC2C28F20D55E558776AF38C41BF0FAE42C9348AD54B60A89B60447360E30869E45F4BC4AB0D9EF09C9AD562A24783A3CFB90DDA4F599A080F1A8941E5BC8BCCC1EA558547229C9A7E95FB5D7051015532AA4F879149E16375881B2FAFC6693DFD700B8A5425ABFB5B8C10A24391848A961934C43204DCEDAB5B45B57B0E2019B2867FC117AB5ABAC44706ABF5C5451D445C37BFBFBF99E54D55D073D5000128FCD49A5C2A434E75F0976FC2BCAEA7D7A10E1EB2F5667D89027651563652DDDA8B4BF53B18101FD8422C2B5CA718C57D510A56B31A0FC6CF6057FBA9DAECB38F416E5CAEAC9B8121AB1070CF0AA19DFC3E4E50A2039A910BF928B2A398B988FA8F98AC7B4EF04E4782C14117A77F320748C7F205C278AF09734789E4ECFAF8247F26C2752573A6504AFEA3A433988552C235F9D7E109C355B9F4F770DBB00127D2DC889BE6A08B953EDEFA45590A69E247D0D964E28C8F247C8F4D87C3ECD33A2F30D137170AB9469A35B42C7286EA7F67792FE978B91F80EDFF0588098E9E458E9FB2C409CCD3001852907A9E439ACA862B133BC3D37F38BC20F36B2FCA1AD4892CA38B3AC430F423905C10AD439E362C03429B7B3641D7E85664CA87036F20E534E7E5B2CA737DEF5EC23DDE5AA566CAEF9D309BAB0A30356CA96BD5CAC60FD4CA79DA9304D2AF955C4D47C25688D7998491AE3FE1BB53F32876B7F27612BFDF85A7A2CD3FE3E8C1BD9A90296092A49EE2DA2B54496E67865283488AD81458455C172930E96133752245A03EB2F67B3A0A231A1B75DC38141E3F4090F86934AC3AFFE364AC4370BCD573B2B8ACBB07752964A627A4A6EEE868DE0541BB80B49AD3657E6FE93174BAF70C5321BAC999CF94A2AB4ED2D288529AA58F7DDD048B70EBE9575F6EAFD8BFB70E5C0C44B85567881A9974BF1981F7924D32A7485DC61B1CC062BD05DA990B04B77595A256954120A5CC3A205359928AA50ACAA3B3F90CCA9F53782EBDA2AF37339E8F9F12B455F8DF2A214DF63375F09B76C6C03497795C78FC4D757FE2A0E7F0D7DE1D0108AF038CB40E6CF876F542C7260AEF6778AB5E6FC5FB90669F218655BB89742990D56A0A742191E6BECE745ED09BA037A2B97DA61967B2C9792EFCF812B966E09A1AF6900646F68BE12CE9D9AD18926FED667CACE61AC29598BDB66FF91E60924FBFD90E6A767C6B7FF4E57795484DE255B1AE16C108A2856BE38F47370930945163857AF0A8C2B9225B2255EC3D7FB60053CFEDF4B26E7029A47FB3BCDC321F09384A71491441BA9D00A2F20DCC8A5542BCDE7DABF00361EB50ACF4C999EF451A46160B412AD02578A172AE5D9B7539C8752C8F7DDC942BE9BF8937099AB2BAA5098C41E12E413DD323BACF2E545B78CE4C4C504BFAD97A7F1B398894C2C3BA9C8E45CAC3BB7502367C06ABCE5E4E7693F8603A320B21D1512C3A62EFC2FA18605B58BC90CC31963EB7446C17A9A424BBC22D7910A2DF10211B6E562326E399E57A7E0DBD4FD4E1EDE9207D9B0C843644280D8CA66146A15B67ACE55DD41AB02DBC055486EB4033C274B7CF1C57CFD85B619CE3EDF5E6B6997BFDDD3AFAF0DF034E2823118D67DA8507F35AC22A8EAA1C80AA71223C908EB24C015F7192C2AB77B49523C7CB61496603F26A9FCB4E2DD30713BDDC529E5811B45C3D2E11B49257010ABD675CCD46D94C863DB7FC363790AD9C9012789178AC83E5C40CCB1760161EB1F43B7A978155481D05F21149A324792A69E1523F3F24D9A155FC25735EB6D6A9CD391C7132A1E0E9DC5C307EBA30F83077704E2306976C17151611776B8C6A985AC220C8B8D9747FF5B0C28D4FA4E10D90447CB84E455F92240BF90A0D98916892E09876FDFAE09C3400D20199CD14E0742655C4EAE2FBD9BE9F2F3DD958B401E1A746813091EA1DE7163F80C0F96EDCBAA140AE06CC8E8E6EE6A4A7F800E4221884201A7D9DE0E1F0D54505262AEC347221E203557F399405DD5E360284C6BB7842034AE5418BB25045DFF6B1C4AD2ECF1E3B769F0FAD60FA9C6558DA94CD1B6DC423CA8536C853B4AB4B80FC504A534BF5F5C0ABA68FD89FA94880B504AD6D02A24A9322A8623141170F6CCCB56B7BACBA280BFC28FC3670D3F846A119D7FBD2CE48909D6650E27AF5656C2B773C3FB7A2BC5426F7D263C8ED83F9DBF946CF2DD92B3396DAD74314BC58BA665B97C5107D916E946450E219FB2CDD7EF070F1AA7DBD4956A438F15B5ACE21452EA5B9F89B8D8E727A8835221C10F2E7CF4CBB8F0A457029D82B361330F8BE9DCBB9C2F3E7A970F8BA537FDC7C3EC9ECC763048106C08874635F1B5353DCFA327E8565B2E25B823C2767C2BF37DC08EC2740BE2138A282CC6DD43EEE11EF6D4B2867CF1D3FE8EC7F6250C77DE4B546CBCAA4F5D9452E1BF1F737573C974AA140D6C7BDFDD4CE7F4C40C0A40047351838EBA5519A07497BAFF46C30298935A9F89B898781E86A2FAD12EA0E22B5765B682F0ED0B88F8764C36979F640845E431CB325EEB3B115BC0EFFD32F106A853421DF3264DC001D7DF89D8B6E92A12AF623B05447C8FFE570059F5958889078E8B015CFBEF847B0F4953A466CBEA6CEB2A4F9866DBEFCB89B7050E33277ED7551CEA2A15F5A6D91662CEC7028216B0F22056DFFA6CC5A1DF2B59342D943DC9254BDB2FC63C626E49529E2062855EF8A1F14B356C5B509D5962054BFC9A334CAE623D4BF09926945B62579F71520D821EBE07F5D7EB2CCC85AB63A990E2ED136DFDEC9569F1C9532905B1954B2977DC419AAC1588A5428AC1DBF3836A06BD9DFF0A845104CA69DE371A81562A252876FE2A4D62812C8E1FEDE42885CC2D14F7A363551B703502E5D58BE3156126BEF9138A08739C3EA580C4DFFA4C389B22C62AA30072F6138A48D4F5927B65A6B811E994117843994709DBF75EED7126F006B190B0D3027ED9FE05701DED96903072298E49E649252E84812FDE3328AA58CF8627399C8115F0F8EBB7938C0402D9B9512CC363657F3E3205430C89DBFA8CC7B5D8A42F55BE1531C663EB3B858F33462DE931CD572226408F697F2762DBF8D93A4877624AF46E116115F68C47CE51D82DC163BC4C9382C98C00C66E09C50B8E31456FFA3508C3B5E8882D96E1B14E167F7AF7CE3B587FBCC9C3F2AE8B1AAC40D8F9C9731A052190B3B95B42E3F5329BA760B80AFD38CCF24DB4139F06774B08AB7D08EF0A0599930A09B45EAEEEB3701B8939B5DADF09BED9651C4F2039B253703666D0663172B225B481B5B085EA80C7A3A95B499CB9254A32772F52A0B0FDA7B359E3EEF34FAB3B7D1306CC05BF1987CE56C01F42C237B97229CD0A91D68F2BB368A77CAFDE2927FBE6D6E2B6EAB551ABF46C28A6BAF6BCE169C4270F57B3A5F779C64EA6DFC864834383A01D2C22ED8DE2A45C838973A4C273B8A9946D955413A5CB1BE3C7288C058EBBFF44501D42AE705C6EFC44B457744B089BF791896410C24EC1D96CAACAB5E06A3AB99ECE179F6D3D1CD4F058E7061D06D54CF70B54EC9212D7C7831E321D888567B3F693FBFBEBD9E5A43AFBA6F3F9DDDCBBBEFB44A6001416041D20F128D50D811A88D712BD39DBCE7F0A653B54F395C0BFB32C15A3BCD69F08EA035334BF702F63517D687D3F4B3AAC5E7BDF7E9CF5A3432516221D6AF0A866FED9CF221E5A51B642754BF06BF9ECC72588EEF899C2A91432A541983C953FCCFEE9D364B99C5C7EF63ECEAEA78BE57C3AA127594663C278CCE0711984F07DC205F59BC96E05C20B9652E487F517B29AE0F841E77031195CA68B14265FDF5BA0D669A490B0BA94914FB2F677D21CC8376D1681349B9422C0358D54688357859266AC1C26FADC2ECD2399D9365FCF95D35A19641038E8DCD52AE6CB083B17C22113B8BAD6D9ACFCF41FDEC3EDC17C31B7B1A768E151861403068DA5439F7214AC4072A8E279F3F658405F62A99C8A1D784CBBFF7AEAB37AC0046BC7EBDEAD9F300DE9686D54F45F579730DF0D3CE07427165AE10D7F979FB700C578DC59B82AA3782D3D1D6E7F279D723C0F179CF5A35542A1113E22653645A09840259E5F25438288A25B34BE5413F84C44833AD6FAFE6FE80CFA2D38D636DB8DB30EED7E6C2AD8EE76298925506CC317EB84181E145D4EAA40D0FED3A0AC228A7B7EB2F6AAECC3C27D305CE38C6495E3954B7565478F7669C440BBF851E1309EA99E32CCACA28AC5B9BD8F681DEE235A7B311383B40DAAEB932F2F5D87CFAD5379E720CA63191DABC4C83A05647CCE02DB725F3B0F70C36B7F2760F3B3CC4F8A572F88FD682B091340F12939F8BF7FE46FA52B49FAC2B88CA843365FCF860F7F9ADE4EE7936BAFAFEE88C483E0C9684C065D52A9439E97F634986536175F76359F69B76907895F745814CB08775A1A45C35ECBE0E152F7DA9428C9B50A6896442F929CB25B9FA9B8784A242949B45044C459A650F7AAAFFFA69C7F8817E60E4F93839D507696ED96D03082A9F73A05447C8C13FE0E2A254DC999D80EF6B3565D6BC213BA2FA2708A2F60B4ACE63389861C46E5736B253A407199D5AB7E8A5B07AE61DB42E568E53D32115ECA9FA8AD68D95EE58785684EA867D9DA2E4B57FE2A8A999CC2700585E8D961AC6CD9EE364AD28C9D5F3B3FCA38DEE72897AEA1500096ED97491E6C426ECA5EA39A57D4B76C9D5508CAD897C2D62B2B916EF4A4CB3C921423E5F5CE1579BD8D1E269C93295C4CEA22EAC9AB78A02515126EE5AB4087EFAA10AEC2C57CA7848AF1E29D1A675346C6FA5E83F53D1D2B3BC2E262AD3BE1C462C28A6DBEDC49E121F6DF48589A3CF5CB0C4A3DABA8426A631EEE62C917ADFD9D880D10D7DBDF49D83E46899F04911F2B870FD420B5F0EBDEBE22216E0A7AF3B90B14A3BB70D0D27B544BA47003594D0626DEADA844F7C6005567A990B4C63CB5E433EBCF479883421528BEA5597DA1A0305140E536B70E419955882AD742D5CD835089CA6357E59AE71A88A34730E677A7983006F19627A0DDEA0CF7982755AE5A6AB95E43F92AC9C66BAAD57AEF0F5106708E09A0F88C2C9AF6774A1A5894E5D2E21EA9A6C85C49ABB9ED3D4BE24B3E7AED82B35A2FEE2976773BBD5D5AAD98121AB9661A78D51C1F92ACD48C549D84A55D7E1AFB04EF09DC3F32FF5BE5DC46A9BB805454198FFBBBF78BD9CBF5795894828AD62DA1C848BF7BDBD0CF01A345AB80326626EDF8B11787C953B11147DD2D23DD5B2620CA4E0141F2C922516DD87F22494F85641A3B7E2468EEC126DC322A0DB47B585D8BC68BCF3E3364CD03AD9EEAA841D1BCF7FBA39C932EFCF41776F0D9494A302872E155C04A0BCC73EDCC245FC0B60B4EF35EC3B5A74C3524E8FD47EBFB093C257B6B15DC2B295B83F76D42D1196E919E42AA090969DBD888ACCD21A6DC4A8A2A34617338B198095C920446DE56162CE4F4A477F453EC437A4A2434D2D3A0317AD0A8494F51C5C65752EB8849C42AF91C137D8CFF73497676737F3DED4BB24A243492D5A0512A55C79CD0CA25505439856AFE1F4866B3DBC5FDB436B679BFCCA6BF4EE9593E716890A4864164B603E7DE7314BE84D0AD86B2D2E9EDCD2E65E9FDD06409B1537066A4B89CCEEFE7D3651D6A82C96637D63A1512179A2891D80CBA032C2B5A9DA84E330D39D36CB68AC784DD92F176DA09A9F9EEC3623AFF651F3565B6B03BBF4D4890F46B46734A63B57CC3A2BA5A51125EED8FA3F2BBB574BB557ADD5A3D86F926CC978BCBCFD31B4627973DB574041E24E9A2309DDE40DDE0D0E13F9FE0306EF27A1C3C44FE093B8EFCD306D76F30AEDFCE76A7CC6E269FE8A1411038C83B4481655C9A751B86665516053B570E542026FD904AC7177A786C7AC049A0F5F96CE8F6A8BF7B9793E5F493CDFB34330A04D56290980D0A013B849FE02827CA4A04F23800CA4B2B1459E09433100B451638F34D9A159ACEB6CACF8620AF1FBC83E3C8644E9734F4E008423421309CCBC33C38845E13ED3F9371819868865B9EEF47CA45D5FA4C7E269601F884223CCE4D261C09D5078A3B45FA244EF8E11B1ECB75F8284C75FD85EAD00ABBE1768BE83861743477DE285EA73B99345BDF097450C645B413534C365F2967EFD770ED6FE524349D0282B9E1786EE8CE14FABE163D94EA2F040B7796963BE99961F39560A1FECA4D26E11A7037168A2C70CA37DB42D139683EAE736BE6E57617F83B3F88C4F70CDD128ADBE2E19DB5309B9D0282C36114E73EA75EC5CB69A89C843DD83CA951770B69A6BFFFAC67E3671D44EA1B0918B24A5FE27594EF62FF1508162397521F6B544FBBB3F4057AA9D19459610D8ABC4A142CA7205156B26E272F57C6668E75C85CDBE1A3FD1C58C59CBC769BD775E697711478FB3B032F7FDDEE8A544CBAA8AB479885DCFBFFDB7BB7E6C671A441F4AF54D4D39E131B5397EE9E9D6FA2FB44A86455595F49B64792BB679E1014055BECE245CD8B5DDE8DFDEF07004911242EC48D94ECF24BB74B001309209148E4F598E594BDBABA8DA70FD6F2C2307904BBE28026CEA67FEA366AEC5DEEC53B2FDD01D97349D849C31DCE8B710C220778BB459B8E251A067E8F71DDB863F808482DC38EF1A4F959D74D9D0546FF3EBC6BFE59A821CC523D2BC0D0564898A57A1E4A662EBF156827EA2623984288E3DF1438D5424E9E2C8C4EA0FED950C0E187FF31EDA715C9867900BB7BF0E317503770A5FE6D6CA58F6BE54314C4ECDCAADFB49CE12288F92B6BDCE834691CADB24830E7F2A61B4C042411AFE27530173C4451CCB27E66AA0AA264676260F83DCEE9FA33F732957DAC76E1597995BA6453C72F85E147FC1EBA1AD96E81EBE657537F03C0E7B0C24E2617821B73DBE9487C59C6DAAF8B2DB82CAB1F98D07A3F1435A2578123DA93EA5B9C33601FF0BC8DB91DD4F77C0DD3C00BBB5751F3AB06A4E56D0708FE41FDFB69F7FBA9DEF7683861AEA16E9B86B567732184DA6DD3986B5D1ABB33E3E6676D58178C60D86AD0802779C077DBD4A1CEA40961D9562D7C59F167AAEFDB3113652A9919269649B33B9EB8D3FCAC230A9F6BF24581B42515AE4E742F2CB721A80878521624C27E3B598E8E49A47D3DE80053B825F4C009DF03AEEADE0D5699EFB5AEDE6B5D3D178E78AF75F59E455D3DCCD6AEE0E3F17A3762B332008AAC550E4248FA8325B1CFB8527766207563D1A40BA7FE4D432688728F3BC956C369641FB2CEDC5CDEED167588657A5D1006F13700BF075D3F164EB33A6CD36C26627869F00077E02EED7A1FB45B7464C9F41B3788B6D5A001AF34F1E01CE85D1796568B8697C901ECD30CA09FD0FDD2792275DBB4A0EE70C412E3C6D16AD082977AF13D648055BF6AA930535E201DFDBBCE85CDB31234BFEAF8839204F4048DAE4B28DDA241CD0156C3FA500096D3AC8D2D9A281757F2BB19A60C48A651833396F943991C09F4EFDAD06A7CB8209B4675B8A197E17A58DE0E1BD45962E2346B58B293BC5B77ADFA495B2BC321A1768BC68C13DF639976F3AB867056A4FEDECB202859554746EB369AC1DD319716DB6A0099DDE94E93014CD64FB4D3A473171E5206C3E38F5A702298EF93EEA96E7ED690BF7CD6C1BDFEEDD52B5019A643AFC014DEB39540EEF5E46198A649CA6E2CF5B386E938845C718BFE5D83DE0EA48494E7FBF0D039579D267598179FD680FF2269B7689C300F04B11F166CD98B768B968C842B7E72EDBA4D838E413F2577D83D10495FFC1E5A7428846D0E15FD1D245C9F40BA410F4BF8FD1070753C4CA3D60BF721C0F9EA9FFC100A6DF2A24E1A0ABA22DD2620E22E49B74D474D15E7691282EC899FF2ADDBAA01D90B7185D11494FBD501DC6DD4D9472CEE61792CE05ACA79ED3A321B2093F6FC1CDCE1FCFDA064355C11ACB7B3CDB859452CC4C8CD93CD153F718983D21A083EB2C243F83EEBEBABEB4B2EB03F318DFA3EEA3B315CAA51CBDDA8540B711D8DE8268DDBAC4A5ACD79B0B65A1CECA50A391BBD675938E237545F5F07A32ACC93EEE98253290CD9EA7A4A9FF40C22CCD045F084955220C82E93A2FB921474311FE382AB4410F7321FE9EB1F0AF33976321F675A5DA7F2819A5EE6237D2E60F8A9E896CE12F7D2D36A2138B5B685556DB51AF5E0E264FC52D84C0703FD9970007E0F8311A4D310F7B29B0BAB4616F7521FE9DB23D16E0B67C36BD7862E5D2F511F8D9715A272B045642E1E44D0C5640CE96424DD742576988A87E1F7B01B81A52F712F6D7D319072156127FD71FAB980BCA7FE887D2748D64F7F34055AEFE9AA3FA6023D4A7BAA8FB8875E98EFD197388D2847BAE1B5AB439FAC7F7EFFBEC98C0D26B79BEB367C7E0F1DDF561F4C7EFF72F10970E40DA6D1042E5F66E2B59B404722D0F5ED6A2D027E6C3681CD975878ED26D0A715E589A037ED5A927D29A56330EBAEFD8C6D3584CCB7A509BA9862BFBC054CFA697E0FCB59F40CD3EE66E64111448784ABE41476D2E179599E448883C51E93C1A3DDA40EF3CF649B05392F8D5BBB45D3A396E34CABA5D7F581DCDD88DB410BBED41B8DD77E6E6E645F6657B3D564816E04707B35D70F5F5203A3EE52D60B48E2D2C47735B7A861EADEABB6C940D36121AD063D6F4857495E48E20A9E4F58AB41D3C96C1057BF6AFDB398BB2D999E3318D64F55E126DDA0E56E9BB6E30C37C4A5DBA6BBDBE79E86C79D79DCBD097F08E3F810467CF78960E05F4046949C667D6C893F261FDDAA4987539E6B784E5D9F9CF588687ED787468A90933FBB84C9EF613A02BC43F72EB8F38290935C44D2D1703CEF0EB12485E13AFD0C473BA4C9D6DB0621122A102C1F89189221799D0DC78D823849D1FD7DF08214C32DC574C9D8A20F0CC72F621CAA8C8356774AC30BFA1B8E8E3AF845E831393F849D3444ECA4EBEC97E8992F0226F36AA0E76A742CE7893959E731D66ED2BDD7003E60F8D9C8BBDAA8465D03F07B80930EF1ACBF758B2EC40FEFC5309B366DA81F25503FEA43455758550A5974C3759B35766CFFED3AE800AC7FD382323F3E083778A2AC9E91DF456B8C153C841EE3B94CFDAE098DF35CA17FD782F63988BDD80FBC50387D4E0FAD11FEF0D2D48BBBB9445B0DD67CEE8312A3FBE060A48F4A237DD41B8990411FEF1674D2E2DD83A4DB435B39C19536103E9FF91C94D741036F924E0408150ABC763D59B92C91529B14488567566AE676D2E5B1DB6287EBF8B1C98A39CD1A7360222DF494C351995FA3F071860DAE58DE6D3E2BB519614CA061D3464AB33E208A2AB37E30B287FF1081B4C3A97DE0770FC9CDDDE751F3AB9ED2A39A1EFB68671AB5D43E8CAE47CFDE601FC7539EECCCBB07219355BFDB6602350DEEF742B055A329B65CF5A3A08B31EE3D83B4FB682812D327F06712E032A5ECC2338D4670394BCFB6EA9C277CB5C73136283118338D46703918B3AD1A3E2A29FA1FC0105884BB6D265039E8328D1ADC003DAD7D1CFE2B246D7E0F8311C4842DE8A2C12BA383E77716A5FE4D1D8AB74DBD8CAD9876FC55477808B29C512635BFEA087A9C17C8C1E0D1F10C22CDFC24BE0BD2888F65A7CD042A07D34E9B06FF40C22E2750ECF8AB06D5E1E4DB5845F307ECBAAC769AD461BA894E2CBF60EB58D1BFAB4323C1C3C4FA73108516B75ACD20B37BCCB6EAED32E0E6AE69B768E0EA2CDE7857B2CCAE869FFA5967A71193EBFAC91F7F5487F3C890F0A326E5DA5667FFEFCA97032782EBDC329D261D654408BD8CCB963A4D0630B74F02885B2D2510F520A8A8B2337B6E0775F87F1549CEB375D1BF9FF503185CC0DC0B4227EF60012CC3E7B0109ACACB907C2A7F1CB7FA185194D3B777F98A11E8AD98469D13C5718935F07E25D510D00F3EDA3FAF9BE6856934868BCD0752D865078D757598B2AEBADD78E28D7EF53EEC660B10A164457AC7A8FCD9560DD9384DFE2C2B8FED593F5FA651EF6D2885CDEDA043A9B8BA0F76E3E7C0661AF5F096C2E676D0520B732E16D96D7222FEBF594DA65FC164BA995F5F5914395703A3C0F55501099F082236EC99B1E02003BB24EEAA14EB1FCF418D3A8C6763E940C4732A7AC917634524825C0C6CABE92E81183ECA76AA6C1F4F512DB42B995A945CE5301529F53D33857EF519FBF26D35BC2C55D173494A646B8564B368E926CF52F72E3AE9655D57C3FAE37A750516F3E57C032EE79BC9F4726E786DAB0354BEC07540CA997CED71DA545E03FB00671A0E2459317A3E39F5E55AA2899F1BBCDC396CABAE761F6461D22D23D66ED1B161A6117ACA7020B65BB471247A46364517DBAA8DAB0032DB7AFE07FBEBF572B259DFBA3BD8028036075B0852FB607F4B222FCF0A9D83DDFEE4E51E6C72CA00CF78D76ED185581E0A1EC4BAE595F968E16AC17CFAD695E44AE19475E4B5EBAFB1083AAFFDFC19E7623EFB74395BADDC714E11441BD62986A9CD3BC3006EF730E515B550FDE6E572CF57CEF48CC5A28BD964315BAD2FE737E5A9591B9EE95E38CA27590192D0140DBD10A6D93E38546790257441170D2D07AF72B5A75FB67ACB83B3D587E3F3E0F806708689E13E33FDC849CFDAEC5F76674CF8BDF2D99240185FB79E45A4F42EA3166A7E7E3D95E7767E86E11E273D95CBEB8BD9C2EE60CA40289F4D3910C9663A0CD77E3D46AFC7487C8C265996F801711064CE52E346547A1165601DEC2028497B7EB5BE999556E78BD966325F7C78DB3947DA9F77CF101F00E73CEF3A4BAE3932D878E93DE4D581337691120EA5EA3B85F7ED382DF7335E27057ABBA8CE98813EEF3852723B684D699AC43B1210F9669E5D1561F8DBDB3B2FCCA0D355FDF51D97DAA93EF56941D82028314CBB5D8EC7B1FAE5F8EFACFE0113B1770F97985767CD776B524A9DAC67861EA6109713DEC1CFB81EC485977B5B2F836597B76F6E7042821D4C7F7BBB7ECA7218FD0D77F8DBFAAF701A06C41C5C77587A717007B37C937C83F16F6F3FBE7FFF8FB76F2661E065382F5E78F7F6CDF7288CB37F9669CD70C8494EA6FEDBDB7D9E1FFEF9EE5D59DF3DFB5B14F869922577F9DF10437AE7ED92771FDF7FF8E9DD870FEFE02E7AD7FDBC02AB04E5FD7FD550B26CD77243A4AEE18ACA26BE0FB36C011F60887F6D13E7AF5F214333352DADE01D1F04870C7F7DD705F46B87D87930F01FF8E0E71593FA02116D60E3F28D97E730452B3ADF41329FB76F30F562BFFA2305BF930E87FF5B0F103F78B88C51FA3F22EFFBFF4343CAD36EF02BCDF7A5AB7A8BAEAB724A88523393456D4130595106C080CB49D5A32D47D906F764A02E15FF731EEFE0F7DFDEFE1FF2E13FDFCCFF0D8EDFFECF37D7586DFBCF37EFDFFC5F6D0C2E8EDA88CE541530A0BF1521C1D2028BC33191A1E14AB4BEB742A4A9CEA98F44FDAD0D02EC63561B8F2E081B743ACC459F4218001AB4AACC33A6ABF567134E21ACC5DACF238484E29A41488F862EAC96CF52090AFF9D0798A7EB9E14DA5BA984555D076FDF2CBDEF0B18DFE7FBDFDEFEF25E1772E735648766E719E4124F2A4F6AFB3AECC035038CEBDE23195F06FA272BD01F87815D6C8B742B05FDC110F421C9F2522727DEC58FA62B42919A601B8D00FB49816BC43B067D48832425CCA46607B92E081CCEE6EF5B4CA5C35194984006EA84C172F6A4BB60B688ED937087D3B5E184CB08207A601DBC6067B15E0460103F24B856DBCE7BCA6A5859E485A1C96CAB846E20F3A203FADFB720B7408F7259D6BB9F8F1FDA4809A518D8110E34EFA669799F7C7AC2D2F77C6720F77420D84CE833EA3DD9ED5224BA0CF9D6C1720B98AC661373E105CDD94A8269BE1F568CC103C919F77B6D9865622781A0FCCCE47EEC9FFE00051CC05636069BFFDCCC8C694C180EA148637CDEE49AC0C828B4346672D5AA6B29D6B315D84C3E2D8C96957AF4EBAEA8505F308462A2B931FB17531968DF1E7D30E20459F62845D6042AF19889D1D586B385AA1E4CCE933EC211CDEAB8294980FB248625F7EE13897F31831D17D156FE62D297B5EFBCEF03E18C210F8171946C83D0F58B833CBF3EC88F9621D48FAEA1B69E730A17B712810DF390A3DF706EDE599DD79BA3C75B9549D3F689137AF17D8163E3693879103F9948DF39E271F8E6285248022BA5EC4A5FBB8B7362FAD2479D12968F90E4C4728E60483E740F97F03AE7501FB08571806D3AE0E78E120168D37C9972288579C39F4D6E525C63CD1A8086906D2FA6736E2A6C42056182A4361B3024931381E2549BFBAA197681677AC03931088733D6E8CC1EBC7062F9FD27CBEFA796DFFFDBE2FBF5726DF1F5214D729291C4E68C116FA7587AFD1B88EEE5A12D7326370F2CCEC5AD26A184494A1C1ADA7280B15612C63B8084698BA527205A6F1E532068B1777E72B051737B8FDE5359B2DD09CF20E0306A4E80E53864D98640098F418FA94300330921B9B433AA4CAC48C33EA154890692CCEE86DC2648A24D3AC6044364A202E7D5DF23991B02A26D48521B73421023F618ECAA1B9CBC332C116C432C49BEA44A3B2A2582463DE36A056C611EC1A15741FA7410B3691560D335200E3BF63A600FED4459CCC5CF80E7B776C5688F4BF55192EF8562AFC62BD4F6BD58391AB638B3E9C92CA2C84318B984759F26C5C1FA36AC12D0C8ADCF065A90EC806BF55A49132481281237BD5D2414FD55909967B3DAC167B6131A0D95508A12EC0FEFC338736DFCC69077F0011B4B1B1947C384C6D15094499F70894397A23AFC0B9425BC2D76A4ACD17DB35EAFAAF2DC365C8802365BDE5C1DA1C50E9EE13E2EA6A4A1D35785D9BD109D6D4D810B64FB5E9A065E73EB18ECD04DAD73C3C607F0AF2261BD3D9CDA75AF9737601E3FA0238AC58FD2DBBC4A6D6AE4D26AE2C5CADAD05D9B88AA8A3A46C6FAE3B756BEABC794A6953C02FD80A4B4B849D15F19711DFFF00F3471DFC3203FEA920D93E1749861A854A2E500F6BA3C92E954DF5BB3FACCC6908D881DFDEBC2C1FBC8D81144EEFF61634C9756BB563BCA923254FD67BAF5F1E0875BEA88AC2D99B502C7F4C8B2FDB515C7A06A4EBBBCABBA95A7ED28BF5BD9D766E53985826DC0B5EA9E8B754D8AF6F563D5737319B65348DB4EFDD594D1B683339C0ADCA5A27E400DB8534D7DBB84B654196B60E28D0EC7223B961A340C0AF1E7BF28191BFFB3800161C2683D52537E55D7E376BA474D696E63A5021DE26D0C842EC46D77EEF8A5B78D9F0DD202DB25D42889E19315DC4E256D57600F9C6AD9C388AF4A85B247185A50247B84917DAADEAAC5FE1D12190F5273A16F1E1186203A45B2CDB596DDB2D8C690DAB5B04B307761E219026A0A60DB83FAE80014A7CEB595A45D55B936DF387E456B1B78C742D676405A52A719104EB16A1B704D896A37778C4FD7A2767513F874D9692BA08212D3762CAF5D56DA92F4D93AD2E62E049CB2D1C6228EB040F430B713A75AB439EA384BBBDDDBBFD907D713E5949EB6413523092CC0627361C88FD555C435412CF0EEBC1895F0715A66115CCDD7564A9E09B9BB8C50A83FB51A7F3CCDA568EE7DFA57555085172EC4EC4309CA26C81B0FFA21AC2D552DA1CDE4EBEC0A5CCED79BEBD57F4C4ED43EC888B926303859F4B7C39E30B6468D9E2EB5FBBD15B1416CE262743CFA4A8EE68A3153BCD017BD596684B6E7802BED92445FAFBBD2C4054418FD65A655E2A9E3073313E8812B0B5139C00B90A2A91680C8C25B933871A3126A458D9CB25AEA5B77C20F294FC5F23127ACFAE8B9F2B2A49EE3B48C2E7DEAEB57A9E7F452CF1AA681172E71ACCAAAED5E60C23E9E890C35FBD7EDFC66C914625436694B13302BD9B5A5B788EB039B913D6EEC0DAEC29BD165EF1C28B1FC04879C52663BB259A3457840D7C75D9A4476374714E59EA1699FFAD48A01445E8A4BBDBBF0F4861E130567082A39807D9A610F229C32C642078300ED026CE26876CA1CA59476E17694EBC8598485ABE08ACAE78120662916C194F8B1FA4F7E0805EF2ECD8387B6D28B114847089653452B67078746CB1A58A5E6CCAC9587259C1A373B60446CAE7C069D5019F648C8E44749FFD158691F1D508630AB8DEEE325F13DF7F7CFA1C05032084A366971A0684898525C8072411E4760B486C2C84EB283879442C828FC030958F93EE9C992A20BB6F0FB323918B8A9BF06233BC493C8D61D1727132690C27B1DD95609B5344D529A7E4CFD7EEE4208FBD46C4AD47C208E9C9E5FD6C932B61D5E7C5A03953786FED9D8792088FDB0A07D5B4CE26B09393809192E131A20EA701867EB161AFA3B48764E268B1183DF0F0147256882595EA4DB042BF2ECEDCB719E2621C89E326B505E88A43F2F05E5B259F9F561E90DCB5A384CD9C1D32C4E0099282E947787CDFBA03CAE1D61C95C9AEB82CF2AA99FE844DB62B113F4BBF05BD3703382B37750E953C0771A55092D697F6E13625297BBDCB9C83AEB6765C27407A076A51B9783B516EEA3F5BB8C85ECEEB921843D00D6F5C1A7401B5F365E8C3DC19CA42C203574713873914420C82E9322152531308177C13C83AD417EFDC33592D3EA027108F27301C34F456A25F1A00384C0028590419C7BCED421090F83DD394718EAA8AF1973AC13CECD81F6F3DB2351C88E30816AA49196EB0E9D0FB0450764DCC1469A5D2991C2F454633920BCDAEB73242E540F37268BA8C71CEF8CD5238E4AFDF5A063126599A1028D82F317DABEEFCA04134783AF8394156BB40293DFBF5C7C022D51C2F52A34C374C5A0E14642D2D1F5ED6A3DFC405D0967B891A615E10E351292D54B111D0FB9B6B5FFB4A0B9B102B5115CDED21E620E91B4075B46B0813088BF01F83D10463328A63E6D800511298CA2AFC1D2F5C95D5C7F317128A97C54CD7C495A1F0FEB463262B1361DDF60EC31D263943406EDC2C3EA9026A8739425E18355E6B712276BDBDA6315C4E5875E204A45A0AE53B7D530237229EE40E58FDC675BD6D7C8061112943208BCC872D192F45B8229556EE0D04FE3FE6AFC33C753238F8D91A3DF3D344D5C730F392174AED931BAD64AA39B630FBC0017E822BEE4F63AE273BB32905410174DFA3F03B6E7248D0482E13A315D15BD67EF81F4CA901CE25906A4C6DF70E10A2AE0C0F6D6DC163E76FF7C0C764D2647D7B1A6B8E639803B8478BE0FFC6F31551CCE7946B82DD826396204A30C85B3460C3F905FE43956A68DB382D1782B888642C73A1D7E209AC8FB32A1EA0B5E1CF2763F485C4416D74406EFCB902E32FE50CB7CC0690DB2362F31F1242CC1B4713587C35097C9FAE56970B09F5905C67A66151C1733BBC3FE5FF9D3C1854700A2517047D55E76E922BF27158C06E3E5B868C2A02320608841DC176A19CED42022A13D2F0E60DF36433B8C3A44AF1D305FDE2C6644DF3DBF5ADFCC887ACAE409141C53E318BE841800433E889AB19C286EB8AF3885174BFD9D5D840F8EC8EB5A5A4C1C599307B4BE61087A9DF73FFEF2776DE0BB00FD0D60FC10A4494C87949B608A952C80AE9C6B0224F2FC7D10431B10B62860678E800E20300172177AA26C4D8AB90A1AC5805110845D1CB959E8BE168FC369C7AFAF7E301E87794B935DC9369D4115FCD7AA225144300DFCF615FAF7E315FACBE8849C4AB3A9B94A77D1617E8A1A17A7D74DA377931194C2FD2304647521E17D04C17D8CE8D9AA30881663D16208D79FD6B3D5EF13628A5BCDD6B78BCDDA841FA4302BC23C336406EDAFC791768C88C42169245B1C354A46E24C5C011906805DD2F33DF4BFE910A93195CD97932F4625D1CB8785E1751375CBE00E425F424256D84FFA5B5794050EFB24A7AD6FDB20F6D2279769213ADB6BC43D3867417783E5C7C9F53E53A3C92EC80F1FFF61B57B210EE8B7955774EBD15ABF995FF4093FA31BE4E0A55EF9E2C55A2D5D4CDA5FDB19089B498DC36F285ABB99AC26CBD966B632623CDD25D4253AC916B826BC66A83EDF9DBFFFECF484376B3D45EC7D33B9329310D1031F3BBD19CB88DDEF4759EAF33858F63BCE534265E889F8048883CE006F8BE66258CD2617F3AB2F00FD6D9674B3799AD5CEF6902A76A97F4FC8A03D234D2BF562D52EE2457F6B45A1C33C4C17B760B9DC4C4C88A595674A97364449AA5C938271846C6F6CAC624D4F6E451695F18F5F5A21C058E19423849F5CA4A425CE9CF7ACBB968121D03BB4A3821BE714953CBBD5C73681CEEE534F29E62E50D32ABC3A4639C4D3CF808843B9F1C8BFB959CCA713539B407316B4FDF185A7C8796AECC341C7895015669F80F6F1177D1B002E30DE5917775BBD9C7C357AA1533797F6E5CABDF486B85A9DEF3006DA1F31A12F836F33F7B5965F39AE638EEBC077D9F7ACE2B2EC8A351D2B66D82470B87554657BF394DA7CBEB28ABEB97CDAA55E1106BE058C4FC94EBD9493323BDEAC26D3AFC4383F596DC0ECDF46A11775CE9BB21A24FC6E1A882182D3F64970CDB8CFA6FCEF708F33A5C44549129AD98F9A2F6DC6775310AA4D42A4463AAE0606CAF49216C9A1A420D5E7ADA389A84EA599CEB34DD3FA3A4FE19918ECF8A93B73EBC0752C396511BA99E9AC90260145A5D89082BEECA4FA2EEC96A96AD3E4BED907D352C30B7827123A949020A5ED749F9A62385233A9BE5CB60FC25D72A0E01AC7D216611E1C421BA1E42EF80E775E9414424F4E4527676711847E622565DDA74971A05E26B19B4D83DFB1FE1BC9E9F4E5C2759D6BBCCFCD07A163BE5D0F523135633566F77B3BCF1D0C2C7E8ABD48CAC50CC2118AE8E07B07CF0F9AEAA5BC63A628557D0765C9D1DC1A56128499878F0B4E1A8A9D25421720FDFDBD3B78D8D803821CDA3C574A180A182903A362B54CE1BCEA175CE2B94D1EC3CA12DB32C49AEE4E23248334797408CDCFB12604C1A00CE2DC25B01C232BB6CE87A8DF0C3898432E86E867CBC864F6732551B1D649D4AE41207B8A0EE80291869D7CD0C79408CCE542D88A74FC82CC26D6B3304C1EC1AE38A0F95307D52CB10A4E06BA03FC27939918C5CBFAEA4E055F6B7BD07F4A378985B1E5C5AEE4DD20EFC91B22F74FCBDD986B3B28743EB7D1684CF15BC11891F6D71A829A361D6CAEAF17E6AE93674802E66B6EB0DC1C55739284FA63975FD90D6C58898FB341D8A7F5C2CB3DEA2E50F6A8E46C48296F3929814850DB5057F51025074BB5383E1846FA70B495A62AF0E65355E7260110BD67993A5C5A6965F43E37B44DFC71BDBA028BF972BE01D38903330551E4864114E074A96E2C165C9063A84E4F6DB92897C1C282D0F9DE0A997D8024DABBB0F478BC49824639D69370E0276D113A0059887EF930E000E4198E2BFE0C390899C5C7316631D820D168BB1E0DBDEBD118BB1E0DBDEBD118BBEEEDFE44DC05E0F440430D4156C9FD234C78B9CD374BA7975B9047AE2FB706E4EBE536F2E556151E43676A0F62F83814D13FE29C61E5281FDEE3625B3E1C8EA152837D1C73B09FC61CECE73107FB65CCC1FE3EE660FF6BCCC1FE31E660FF35E6601FDE8F3ADAA83CE4836B26A279A753718B17B3CD646EA442A063B660EE05A6FA04119C012FEE330A542EAFDE220EF8BE0DCA97F711821D365CDD8EA2839DB57F9D42191851F23DD57C60717DEE28575DE7E3E054592D2514AB80D27EA0E2EC7E00115C56A47754F6223317AA3F4B379056CA40A368A81CB88396426C44C536251778B983D6AD25C0D528FEAC6F74EC5023BE144C2852DD904C58C43E4067B913D26B6601BC9DAE4902EA3953A645815F341F0FE098CA5C72C4726414993FBF30301D5D0CED0FFEE5B619C33A81A8F4FA8D1DF8B695D94776CE4C3525BC4E0E363B5BD2710D2EC812E89BC65808C3385C2F935D1142B02EB626D45C7D9D155B43598D01302C9DAF3B35E0B9ACD7C04A544DA3ED4C6CC002D7CB5B3B1E3AB50580EB6F79242F1F2ED66007ABAA36EC0456654EFDF464B1BA8A2659A5656AD51632596702C0052A6895ED9676C412286A8E8AD99D036982892C3204C3A46F30ACD6DE755F364687B847BA209C1A96D59942472A6BF2B2098CE3FA6509E854D05CA01F0DDC07CBF226982B21D904C9F309E5EA6B7974EACAEAE886F2FC3D2D479801AE786699992EB36536E5CCF1E7B3B888C8F155F7B55096264A017C81E30D46F7A91A4C60307F91F4BD4794C69F1011D068FCFA53ABF16F33989ABDC7C8870EE6EEC4810A812ABC70218EB31CD4D74C3D8F5747E8CFC01ABDC38C4E531792D1F1E201B17BC664963441D6C3660BF9EAEA0F404169ACE2D0A8077E0455C58BCF377F6E05FCE0772F0A629DD8959324B4A3CAF099C83D487272AB8FEE2DFE61123052AA2933EF1E8454806E8F32D4629454A3D48FE5643A42A19B08A9CE4C061963973E813FB1AF5A36E8A650C30CBA2B7738FF28C9DB31E46C9A51069D4C76481352D26E300A3B8E301C8105D1C1F3A571AF4A5E76DBD4CBA854DEC621EF4990E5456A0D07CDE91B65CA349E160E02C3DDFF809E750064E1F76573D0DFBD12A6668AB797134BEB27F15D9046AEF03C42738F69E86579E9ED7A70822B0DCF3DB695059D6BE1E9EA95F49722F1FBAB13E883DD959C525ED0DDE48421D6163BCE84F748B1134E1215A55514663756F9FABF936D16E41087B345BD9A43EDE9A530845EE6E8541E816D9F1C530CF548103919189933FF2A90746E9FEA168708A177583CA8A8440D33A8AC546AA72E4BEF070B05DD11C260CA8089B122C0B3510278232900CEC8F7AE9A32223074FA708CBCC2AD60C08B2AE8BD1C449F8DD3B01BCC4D191D92F551DF086449F820AC76756279CBA154789E79508C9805D84CBECE6C5846EE7D83968C83063120FB10B1299594F26ED9463961F9B1D387A7C322F4A1F73DD44C189C574B304D4EB12889E1D329CFB62B0E64900B13E72C31AD024402C2887D9ACA45A37B1E0560063C93671307177B4C420123017AB0B27014996CFE736394CC84CDAF6748208C8BCB90B48107D34974A90B5BE365A6666FB1CD5D8584A99CF8C5AB53518F54E1D01DC9098F759994D341A6519C4431B679F01EFA52CB2A69FE9DE43B8D82D86E2EF710F1FF6E256E93D461A50F16BFFE88E6959C31A93D6D5CA43A39CDD8EA3EA6D9611B14B37D92E6DF608FD6C79D0051D7A0C7B7C3FAF693F10D519774C7CB62EEEACD87D2A581172B4AE410E67B9005FFDBB1C1243EBA30BA0EF2791C0C32BA7C02B9B5FFE56621D5CED1EE36E1C674B29882E56C73797DE128E5065B6B409733E81630D03D7972F02A32BE8D88BEBCBE9819C543D3AEE7BA4B2AA83AE8BC00141EA62777B94909280C96562DB8029C93F8D276925143C1EC7EEB0C94F73D84947866084555DDA1554BF0C7CD16DDF842216610444564215C52B082D8125690DDACA736CF1AC219B01CE24A0A17F01A4D38C2AA5DEA933AA4818F03B443F8D041C87476C43314A41027ABDF2171B113E76C0A7689D1BDA232645B5967EBD0E729A530B593D8D4050CC3178585B2691C2D53BF7AC9E4F641C006A86C788E7AEEE7CBF7114373A14FD886C9D6098CD04BEFADB1D9C13BAF08D1BBBBF1FA56516728F381DBF56C05A6ABF56730BD5D6FC0EC5FB7F31B13BE50AA25B32CB837351EB210DAD375CD28848A5405EDC2F15BBB92346420732C5ADFDB61228ADC55C1A2FED62674F8CC22994B3984B626188AF6DF203C80C720DF97E8D9094ACF820BF71B2A546A44324006F0B1C20CEF7A395B1999DEDA4757DBEE263BF9CE15A968B0BE828506B20B4E654B6B60549221A94346123B8472875F93EA2E0474B12DD2AD86824219F201C9F1EECB2456EBE1B18F0E1738FBD840953E0DB21CFB241E04E728D906A174953FE8471960C077DEF721F0C509C84229BA668916FA8E8711B647BE442A5939B0A1A914DD7B2DE07EDAA71321FE248D740ADB2A3D5FB640E5FA316489F88AF8E8FA8ED0F5F8116087385488555A035E64ED219C2F447B8CC12ECD7A84012FCF66A106BA44EB0186B94C6BE8DE6E97C22CB321CD431A445EFA04422FBE2FA8C4A786CF9B0CFA49BC73052DC880E793250407EFC9D25F053B99C8A46CCD07A1B74DE2F0C9061F4AD8B256B97368CEBE02355971801E1B914DC6A230B94F7ACB3919E480DA0588CD057EEEC26C8768E3310345EA223DD8B6C882189D4A503A48C999B0414CB48FEDDEDF5A3E882645727D624647F2784C2E7AE87B99CDE9EACC1A50BE510EE2D5D05EFBB4DF1CCF26F28BB9130BFAE71D7A3FB0C959F5C0ACF7C923293162C59133881828F5EE3071CDC3205A6F0C532068DB767E72B0E17337151FD93CB145EF2CEFC16912E7483A1B0234E17A60F6DD8770D738EA3AA6BBC9FAE7F7EF41AD760293DBCDB51D0506F14312F810F0DE8246C70F33EF23EF8FC88DAE07E002A2A549B37D70D0CF38457F6BA5CD3E661CE5E740D33C17C516ED7E1434359B4C7C8151EF495B7A1B220B59B382263ACDF6DEE9AA34853BEF5A9D79C5D1391A11FBF5634CDFA9CACA69F2DD10256EDB717C8606FA3AC8CBDC4ECF42E0D2BD4EC819B69DA7C16180540B7488136DAF31923A95778A984997B81EF5E4F662BE019773C4D3FF63B25DC42C34297681698C1703605863429FA14E139C1397B7D35B72EF0218BAF639D9422CA74FF7E86D2D57751B9858BC3B44062E40EBF9195CCC268BD96A7D69E6627086B5BB4F4F79BBE3B5ABC9AB95776E7273B3984F27E4529AAD56D72BB0B8FE62949CD260FF82C1F304BBD0CC1F90A4ACA0F2D0CF8892A6498FA6DF2099367A437DC37EAD5274FFD10BD9888048D4EBD5E7B91101213C038C4DA96DD025A5F6D74E59F5831716BD70BBF638C5E3AD2A38B9DAAD3AE664B2D94CA697E0F37C315B6F56B389519DD73A74A34CAE6E17A4DC06322C53B82F1AC623ABAA6311C8661F94E8A0B401B7C69B1146F5EEF05F0DEA017B0C1C1B372E47B1D290E8D7DDA4F51B268F5D53BCA057F56E6211654A2358566D92E47DD2BC78932CA079A33BBFD80E1BB44CD1C0391D965CD0C9EB9C0793433F4E83EA66FF02B757F5937965FA6666EBD719BC9BFB8AE00D1073876B4D55233B783D97009BAB8A17D5621B6BEDD68F57FF6E294D56E8EE4032F651CBE324968782E9C43DA70107FFD2F5D767C1A5705B04E18E8A2E349D675591C6C924CB9939AB0DE6E34C5C85E7C20EDBB95A5DB999794886B03D14CFC60BEC79F8D435E70CF307FB93D63EB8D645D91AA655E6480756750577895F9074B0C08B7780D8E4D4BD334CF4D9C4FA6094B4AC29A965957D54006624B5769502145629404188E4031757B5642EA626155295C78925CC532B4FA201CA3A0520767A012DAF174796FE472F4DBD387F027EE80511E8A9286A6291E2703E57BE862E13050C7F2B399AF545F218973859805566855F6657B3D56401DCBD53ACDE27E765D3D35008C9DF123AAF924CAAFA34A8638356AD165F295F1F43CA77290EE3C47595DC6FFDA4C34A1610501E8926CE6925105CDA812AB869F10E398022896CE13CB39CD2671E5552EB80681F3267E144443E6F550AE278EC2AF3028055F1C0A166DEF56BB65A4A62B471FDE8F9E6E2196A9FEDC59D5AA28684454540FEB4F2706E8323BE13E00E49C85405272341B40597F84DB8077B4893ADB70D42747923E07EDE187D5DE7EF6B0D1B057192A20BE7E00529C6E1810C30CAD0459CF97B88B597BB9147C609E48AD0A3D2F11AEDDF2191B13425C1812A886A08E268D2C69CC7E2EC94F79E8BB880325FD67B92ABAF067317269E212074E93803F5D10128746184F9CEDD85B1FF766DE5B48F0034757A3769BBD29C19BC153C84946F88299096106B06E473107BB11F78A19B89FD513DFC5DDD310D23F9E0EE2668807EB4044A76D135CB23C65637AFC4FD375C45E90161F5D99EED20B1AB54DF326F662B05AE5FA4042EF1EF19EA762AD9D3B6D8E134CBA1B8D0B912EAB6BA7045DF6F155089929DD3C25FC0544877956B4F68E02DFC6E966CA729BB7072700B357DB9C599557040C612C740D57D687704AEE2EFEF3FBBF24CA893AE5F5FCDAE3636D9D64BE661976B9D8631E02ABB785762946D557DC936C33A26BEC9C58E111A2ACF9C99CC2B8131837971B0C12945C26704BD8C7A799A040223968C442A1092E363B1C2241BB735149CF8D5EE215D29AFDCAA5BF0E33442D4E8CBCEA2FECD3A4821A1926D9DB74FF54F1FB5C95DC9A7FA27ED2B5AD1A1FAE32F7F77785BCF7E47378A994DFDA1B4FD9B9990E88F8735212978DA5AD5F4D355EC3EA87875A92A9E7B5D76DB3288AE141A1711446C50490A55BC297C6C3937B2131BD0B59DD0D430582B5A17801996EAC5C29A21F98B2B69AB933D7FEACE37FDE83264E72A64C7E0F860C6721572B0E1999D9CFA8CE865BEBC59CC4CE9A5293067452F0230C333891F8435CCAFD637B35233017E9FCFFE9819552A6AD43D197808E02334AD4E240434EC862BABAB4695ACAA05185A24985F6D66AB9BD56C53C67B22D160692AFB569297B9402064D2E72AFDAAC89A1F3EFEC314AE1B81582D7ACB968EAE3FAD67ABDFABA0E1F9DAE8D61028957429A95F37E59A9E68A5A7331A286DBCB43792118996609C50D2A02A91F5F472B644F433B57B9E883541BA64A4A453724D49CDA08E9C31FB2C43836CBCD816F96F1B346A20FF1988873524385F4EBE18C58F76F7CF9CE88637D8388E12DE16798E386EBD498DBB0DFC3E44709881A73F4E22D91B6FEDCC31FDF88002D3C966F6C5D027BD7902F968DBEFCDE36785800624B1E348BD56410385F311786FF94AA3EBB7864E4A49F7E2FFE1EFAE1851BB9AB4450C7B60FA0C9304040C56335AAADB372849A25BFA5751F9432AA1376E80E6B1A529709F3A7D9FDAE4813EA4C97DB30FA66EDF0B7867EF17641FD65EC3915F20FA3E5041B84B0EB93C805F890A8A300F0EA148A452BBCCBEC39D17D169974D5C758EB7820B4F1D2B4BF77D9A1407D053E2587FD3E077FCFA85BB96AB568F09C77C100D3B9169EA4CBE44AF9EB1E7F8BD5D053AD54A31DAA6FC223AF8DEC1F383C6F5D338A8AA09D0CAAD6125419879F8B8280558A982F4F7F7EEE0F5C59029477D9D6B08D999673A78267923B6C963B80BB243E83DB522B64D77A7F48825115F69F2E8109A9F67A4A8156659D225B01C232BB6CE8718324E2F6B6D9BC11AEF9F76A95784810F2AED30C89EA203BA40B21E54B557216B12C5B9491D662F1C22B24C1EC1AE38A0F95307D5A40643EEC53B2FDD01FE93C9309190177F23D5839CE4F9133FF62D1CFFF81E58FA25F1E023200539ACDD1A2D8198B86A1A3EE86D33D351D29FE1BB9E2F3F0EF4B2C783E93CC374616BB02BB527BE2D6745CFE89C3C052CD84A7F49DE13CA252E5F8C0E9EC158C28FED185B8FDE63BCC77814C47673B98779043117B3ACC55615897291B4AF1100FA2C5126172E1BF8649FA697287C7B7343BBBB1C1C395AD95A0546F1B4A94753F4EAD617294AC59F6DA5B0B6150E74D9941B54550C32CE4C0ACB32D26D5D6CC1659941D584DA2A28385A6E1F983AF571810C4B776B98065ED8933A4C7F07D7CB5B3B3A9BDA024018380B6E5F6C2E9CC13A56F4B2E0F5158C0B0732CBD4E1F36CE634F9D654C183CC200DEACC5528AF9F66772E04BD6ED8A2B1200B5DE49E35921A94D9ED721B828AE22665A26EEC78808B3E7B9151986AC15662913D11EDAA370C514A41560AC2D462FCE31667D00379EE35155CE9445F4B2A2882D0E26357F0F178E159050E09BC51B81F6547714DA133BEE814BB4651EEE9E0415D7E0ABDC9548FD9F3143E28936801F4AAFE06E0F7001B8E7599B5E3EA7E59474E76E437536F9153A0ADCD547D32190938EA51669DDC8966611F0C5170D5382EAB5119A4644584F20077E02E4D225BC930FDD609B832D4C1550A7C9C7432B704951CC03ECD00FA09DD78366F1804688723102813B8394A695FF94703678B9CE4BF7451682276A35EAEF27B12C4EC280B2FBC17FBD011B80A31344F77685903AB125E599754A8E0D4B8D9010BBD0CA7E5F776D88AE98226B0095D6A983629AB58A93B1C504698F8DE009ACC0243C9202899918D844841DA51378A0D282755386B60D6C50776F0905208999C4A88C4A87C9F38F6182DFC3E375F032FD4575F288778A6F0DE753222520596DE7753DBD95D087B63D195A8F04052E87BBE0F0F3666C18B4F6BA0F244D0A7E99D0782D80F0B3AABB0993F0E2EE0E3C26E7917A4E416BB07EE6424B7D0D0DF41B27332598C18FC7E081C697870F86D8093993EF92174A2C4CA8B749B8028B1F6FDF293384F9310644F9C94889AA0BC10571D4A41B91156EE4758FEC2D252103B790AC5092013F5FC1CDCE154ADA064001D71C75C1EEB82CFAABD26E6D2B660EB04FD2EFCD634DC8CE0ECDD51FA96BA48D4587BA9EE9CB83864A0D451D883DA551912EDD74AB80FD62F2316B23B815F087B00ACEB834B8136BE7E388EA5A6B9F0214213F1BE27ACD90041769914CD13C5E4E2EEC0BB601EA2D620BFFEE11AC96975013804F9B980E1A722B59281D0014260EB07F8916838A9937188A169EA643C0CCE943AC250478DC998639D706E0EB485DF1E890273840954238DB45C77E87C802D3A20E30E36D2EC4A8912A6A71ACB01E1D519F847E242F57063B2887ACCF1CE583DE2A8D45F0F3A2651EEA117E67B340A4E7E662B3D4FD63FBF7F0FA84AB9B79B6B4B6F3BB40293DFBF5C7C022D51C2F52A34C374C5A0E14642D2D1F5ED6A3DFC405D0967B891A615E10E351292D54B111D0FB9B6B5C0B4A0B9B1C3B4115CDE022A25A54324EDC1D236EF203A248E146465483CE25C7DFE401FF5AD477F26DB2CC8FBB3091980264E8E8E611E7CE0B668ECE11839AAEDC2A4EB7FD429F0EBB8B02FDFF1479A4187EF5B44978255E84F85EA2B2224702DB2AA4CECC4F9D22E31C39954CE7558FA7490F2CC3F4E51E5B34E40F15AC3F8DC6B18BFD60836B03FBDD6087EAD116C3DF46B8DE0D71AC10A805E6B04F70278AD11AC08EEB546F06B8D606531EE47AD113C4E955BACAD21871A34DCCBAE9A8C66E8956E9419FCEE216109CBA78AEA9A0AABF201A4AB8431AEC261A35F5003775C07D5C78D6ED91127C527C495B7D434D73D2104264FCDF29467DE3D08A9B4C73DBCC4629434B8DF8F300C9E4C4715E6E6C1DB99C92063ECD227F06712E0DA59436E0A35CCA0BB02BFE3AB3E8EB17964C0E950C30C3A9DBB14FD0FE0D1869C4D33CAA093C9D023D7C7C18B831D98E308C39D97203A78FE71894CF53EDE36F532AA448C715EF424C8724A0D630AE7D07E5CBCECB4C37E12DF0569E44C375B43738F294442371D18C3DEC2DA848773B9E2EE7FC0C611D374BBFBA3B5F4A75CC2A44B94F093A76AE717265196C44C727053F69E8237CCCE8381327FA8C45F1AA4FCD895ACD7757458E1235E194BE30CF5813E52D46FA87714D72B55F9FABF2B7F089CCFCAB99C9DC2107A9923FE7604B6EDC9F0A87F95362F9E8AD2BB2B61942AE6AF22C935ED44568F767001732F082DDFEE3B0244FD356EF2EC2FDF137AAE1D470F4685BE24B734FACD475BE9DD331BA5F20D56515B290B5AEB68AE3370A87E6056DD4AFBA0E0512A52C429C167F6709C71CA7D1F682C1799C6AA0BD9A52CB6C74EB100515856A47794B9C12C29F39F65419D3DED696B32CFEFC414EB085A0A71390AEC2AEF022F77D004F78D9EDBA0F2ADB1594DA65FC1645A578C36AFD6EA6972FC2003BB243650BF7A6E78DF717C73473391F6D6DC37C51E50E9336301C05D3A3BC1ED62A29328F1C99FECC3CFDB0B0D62F86801CC6EA51DD994FA5F623F9BE46054D3F76B803A6F7FBBD7F429BE15315B27FEA1FD6DDCBD8ACAFBAD2ED8F2C7F50A97B45FCE37E072BE994C2FE726375D53710A7B1336556BC03EC0994503C36CBD8A60A9151AAC84ABA38705166EA5B939542B0DE018FA2C4C9A1A313D72F84FFA36C514811B768C6A1E442F4767EF19682E8EC7B13F715FAF9793CDFAD6E989FB96445E9E15AE4F5C1BEC0F77E2C831006D73926B2A2DC7286975E013F7CA394ECA39C4FB423266B4AA740DB53BAE47B2E7868BF9ECD3E56CB572CA0EC3006EF7304D5DF3C30EDC1F8E21BE32927360249A87EE623659CC56EBCBF94D79E4D626476D07116669B60F0ED551303B5902306D75BBEBB3E45917D3DC5A43F0ED21B8D28C9DE61DFE935B4DEDEC5F16C4DCE75B3B7E918288D414D478F8BF542A3F4FE274761A35A97C797D315B58103A1D4AA94BE22A85A97E20F6FB8312E624CB123F20BE48D500D3D5FA3398AC661380FFEA50E52CDEBD592561D5AD1E7D0DC3BBBF953F2CCBBA93818FC6FAEDEDFBBFFDED0333A1360C321403A8FAB50DEDFF6540A1930071644CE085D324CE90288C16823D3641EC07072FA431EF74E29E2E592D9D7747A8DD960B78C0397CE29C99A4F59847D09DA3DEB70CBFBEA3B65961F771BD6FB2FB9974FBCBBAE0CCD695BF6A13422F3139DC7E4E4573D97E50F6384B42501A533ADC0834D0C95E435EF5601E3F20E8B8E26BE97655B95C8929A49B0387DE5EA6ADBDD31FBACBF4EB757C014398C337136263438BE965BEB7E358D51102422A93CEA3457EF29E83D0A53467908052E449823448537D87E598CC799984C6A0D9CAB36333F93ABB0297F3F5E67AF59FC6CF0389589F67424AE57DDB22077E877168B60E025D50D6F39246DB2D83D02477E22AE4B02F0B36036E15500DBA6CCD5165E072AD4F468654EAC672E916D75F847477ECDCDA57EAD72E85892F506A340EE1929F07219006594526D117F3AA4E1BA205B6187B94BB7503AE3FAD67ABDF2704FDD56C7DBBD8AC41F7F7F972F245CCB104503A77ACA08F3A55F191920D52F518E882E44F4865F753982194F8E5DFB5A84E619F0C51189FF858AAE32EA99820A40467456916043D0CB5A99159B2C57564C8920F406B3A04AF84C94824D78861F3ABF5CDACE4DB26A4C703C49008BFD3732745EEAC5408A13F48651C8254C06324729C2F6F16B325871CFBD7B843263C480C9DF03BE9D1A333C2774891DC799D8222CD8F46740821A9BE7E46C4D990E4CD643559CE36B355794F73C9B65F4CE402648994DF4B8F4A2518AA1C8AC18547FE245528E5E0E1F40C38E722D6CD5953ACEA561A63737A626D5AA64878DA4CAE7AAEF631C994879B6424AAD30F409ABD1B77F64429BADE4D19E85897FCD9B3CF73B9F02DD9E7F95CF66AABDA26932E2DB8A03223727647594ABB760F1DD839ACC85886C1E8BC6D359B5CCCAFBE00F4775725EF8E5E44C3D120857D9E3FB528ADB60001EA6D717A5B045A35B19DD6A1154281DC9EBFDD419504CFC4E0D050016B43B3A182EE5C9C583B67F59A31D6CE4ECB4B23AAF6F454863F7E713A93FBCDCD623E2D35818B5BB05C6E2642F2A2FAB60D94F4EF5A2E43F58834B4E36FC318C3295C5576C83B1CEC0983BBB006038E400F15AA4DF942F19DA3B179321AD0645A8EE840674BA228F79CF0072DD6D433EA08B4B09C7C9DA91002EED7DABCF2072D4E701A2A20882A6D4653326734022863C2A4238F45047D378312059CD74530F2D66BF19B136F39C2B58E019D5ECE1717E8E5B4A82484F9BA9B6EA9B587D567DD6D3CFE3C9A8728C61DFDA77CF62D589145D867A8CBA65E0295FDEFAD02A9E713CA9BA70A1AD37D10EEA6252E27934FCB109BCDF5F5C2D083B901D02200FA673D2FF7B3F63FA6A6A574C53409FD4EEA784CF038171AC3E785FC436E56D026AC81D91D85328FD3D1CD2F8BF464FB25187C83063F07726B275C98FD5B7CB99AB1B141088E459AC5A8D5FA72C8AD67BF24639FD47F4F4871548A8FE9C421F1C92E502906624AEA767CA94425DB12111A4CF290B3A5B2F96679622AC318285119E9F8035019B325CF81CA289F818BD9663247977FE4DDC3BE6700F3198714387DB41E080C142296ACE523D57D06A437765E2ABBAE9C595F9712D9C9ABA0D3540B289F172713E2B03EA72C6FB82EB640A0D833D76F2AD84D8EA3334A33AAE5A599D8DAD37335FCE8F422B5E21A6EEE40D2FEFA29CB61C49872E99F0733D0E8ED74D5BD29366A4167D4F454862EBB9F09335262F7F6F4A67B0D9A5FB82F82A26C2EE1DBE98909AC7BED66601DECA088D23E9C8114C6C7B8EDF426E8F223C86082B92BE9CE049B0ED4D13CE133613DBFE853E93A21CF5168937B067E70F2643E3DB19EB7CEBED1FA074EC5D1438513D6A9BBDDA0AB0B698D2D025B370FC80327EACEDAF22A3DBA77AF78F1CD863F0517132FA1848D49F99729212953E64017E8E8412BDAD47B1E212A0212527F1E0C4C4DE7F44238131AB3BE86CF89DC2AB94BA4F31ED053E35CE9EB248A7F339A926230B2279ABA67C6B939A29DDA33E3F4EE679AEE19A7763AA3C84E9AD0D18EE6642158C659379F3DC99864D0EC1F7E5CA2A1FEC4FF11274D704A35CCA87C9075E30BA31BF99A3F13C221399B456BC8DF6A267D33D36642418AE4E89C6A34723A975BE726ABB319D99E3AC5739BE3D45994F03FD7B79F382B3920E3E10EDE81CCEFF3F2D850FF4618A3312E517582061C477F28F8D9BF4671D84771DC7878A2672451ABFB3C9FCB3BEE3C1C9E4F477E665ECFE7C6CD8C3C9F9DDE93E7ECF97C2ED465E0FEFC6C084DE6FC3C0EA19D81F3F319129AAA07F459101A6716D3C9620A96B3CDE5F58576449108501F99B4BA1AA8E54F7D9BF64C494939CE16A0F5BDD00711CCF7C9C9AE5D43ACC6CA24A04E9FEA59255EB0D03772960233923B75BE82AA00635F8E0ADCAB4D50E52F679DA582A0A8B409C22A92BAFA0BF53C15D221C7B80B2B75A974DF195594815674E45D57D61839D37E2AEFF9A9759E4D263CB9B3C630B911AD7C619E7FF48D917FCC9904E0DCAE672B520E134C6FD79B32626BF8E2A8BC515B30F91D5E42C954EECCAC871F81522EA017C234DB070782F9F572B612C795369D5BDB4AFF3C8EAF4985699B608F3F0E4250D42455F6B5E9CE5743ABABC3EB69B918755C82BACD603AF17D98654BEFE090AAFAD8507BD81603EA34BD284A912DF7F9D24B4DDFA09F859A7280677367E91C75BFC8F22482E929EFAE3E1446251F3566A3453867CE684E452FFA7CE61C28852B138F9DCBE09CD8CD09DF56C62CE74CDE57CDC35C91ED38A6A213339E53528E3EF339139AE1D67BA76A1D3CD77AEFA7AD8070EA7AEFFA65104E5CEFBD1D1E8A75CAFD4B280CAF65B4CD6CAB7645783B221F207A57DDA7B18AA175A3A836A66C152C4EC5EF94F5D84E88413366EE140AEE53F32F232D77C9C22E4B0C4E57CD854760B7D3F57FD69BD9F2F9DEA7A7CA41756A4AD4CC4275E26BB413B9254F726611E23694063D890E49CC13DA3A2D03D5C4D30F7B43527C1C382891D79E9FCAC8C72FCE86D874B31A9C1FFD9D5FB8FA2969D22A6A9DB8C049F1184BB9B6997C5ACC0C2B573400587558F5B3FA4BE2BCCB56507352D9E02273A1B4B52F5B81352F27E3801DFABABEEA55991810D40BBC694F436BDA57ECB9D056630F75CAA906212C6DB3F97326294D9BFAF5630CD3D39353A3DD9DDC5E20B98DBCAAC4BA35A777A0606CAEF9A1D3E5E5908DCA069820702A327A1637DE690D02A7A1336D2BC0B9DC786AFAB27321AD53E9C64E42549A0AB1B3A1281D3F2EA757DE3939579C84628CDD2ACEE8B2E3CD419C635D9B7E9E917FCEF322A128D9057701DC81B3A0A58BD964315BAD2FE73740B48C6778BD75506791A1DB5E18CD51537B6E1C4BCD05EC6C88ECC4CE63A721317DB7B153531861C218EFD12E3FA518B0E74C05CA4161D3147A39DC7D7A3AA9507DA40015BF7617F17BA7F6671F3966CFC08FFDC4D17A25BA0BF80043BC39AAC4D1F9ACEDE9D26DFB212EA1EEAC5536BFF38DA0D6CA90E4D7C1E0748CA9CA9931D96C26D3CBD28BB4F3DBE7F962B6DEAC66137116280E146EC2C356BB515A451627C93874AF61D81C675E4ACCA74A73E3E5B9E7EF1D79992A6E9B0394C6C94B46E723AD336650BFC95292753F95A5743548AB416321863C5C2232067D8D0D76967A43B81516E33B27AC19FA267F42DFE4E80B981EDDC076F0739066F985977B5B2F63DDFDF0576B98F399F5DB376507D9D5BBF6F730F27E7BBBDBA2896EBC2DE7A6CA3844D61EB77B7F32C3763BF046EDF6E919B314369991CA9F79F0CB1605A8608298910074D526825F35AB0C521E67FE20659B7090B2B96F4FA82719BB1F5423772FA8F6BEC9C8DD99D809CAFB73272DFFA40741C6DB904189E9C14382E9D4B72E6D571B761DDAEDA279536E477D23F21DC85916C0EDC6E503DC9E3D58740CAECCF09D76DEB81DE373EF884D48233B5AD3261D49757117D75FC44B4A1A250B49DA7BA9954FA142AAEC471D5F80F3E5CD624696940E2FE18D23E82A185CD05B01A386B87B31E2771561C4EFAD80D1F527C4F57E2F53B1AF66EBDB05AEE2C14588DB53840FB7B3263A55F5A25E64AA7E2AA8545DF510515810B595505B021E7149D742F6810E056BAC0EF511123127CBD966B6122D93A0AF10337E773DA4A668B137932B212DF3BB2AA044F5EEC1A85961241D5DCCAFBE00F437F76E12F6E4E123ECDC83CE31B72033FCB18537DCB1B1EFA6B8B959CCA713013F6BB572EF0ABA43CF5065C656668CF2671EF0B2A5072A27F72A3304A70F6F3C4EB7FECD393E4B79FB736C146CD1B15D416CE596B6E00AACDC9E22918DDB59111DBA569D1013BA930C09BA9FD29E974520059B5D368A77B96CD7A2AD6EE6FD1E32EB76EFA7B8EE17A6D89174EDEAD891EE5AD8912F94B0E304270910E3F414E3C4E9AC8B0EA134DE3523ECA9844EDD5981AB27BB2284605D6C05BC9D6A177178AA4BCF80B40720331ADDC87D60B77C207B2F5041B57AF6FE1474E45E9F82BE9ADBAEB0DF6A1BAD38F2443EEAA477C489FE6875D576E99875A7BE91EB7ECA17615D5050721DD65DE49762DD4B7D6481928AE9D133AE92C24A58C18C373CBFA7000D7E67FDBBA0559341E536687DA0781FB4BEE993FFCA04EBAC0058FECE9500CBA6BEC9F3175EBCCAEA2A49C69191AF9C64BA09D5944CCF3E51EB98798F15B08E4D5CB1EAD8DA33021D0FC58C4137F246A1E3C1F4789460CFD83EFD1C4A653745A13C621D5CA7A35CF5D7EEAB4259B4A7229FA8E81E427AA23BA93FF5C06CB5BA5E89F483FC7E3DCF3FBAAB062284EF5E7D9EF72142F5EB4384EAAAF88EE118B685CF194E5FD9AB86D35D0F2991E585D74B0111C5C352A65110ABE5991EFCE3D1E9A47E46A722FD1DA74FCFC9ACBBE9195E247317F65430C428AF059602C4ABD06A1569BFD4674EA9A1FB94DA0A9A6CC50105879E6E140FA574BC71D7D9EF33B136B16E148D53B72B8FD3BB8E6C37F9D89AAB5A7D24B331F1BBF560A16E79A23E3A6A3CE55850DD7AB0A07A6A6995D7E0F7F9EC8F194F0C1675ECD728377D9570D9CC5637ABD9665229A3974B09590A7B8BB1127CA069B821257DFBED36653715B34DD953018BF5F472B644DF4C7B4F10B7A708176E672D7464F61BA6573F1A6AFACDC65680449AD917FE35C4EB24373C34FDB41EB7BD6F5A95A7ACEE835AED31ADFC90567DD3CB7856BB5930A83A8F6AE9EF40952BB04F15D8F4EB5509365DFBDEE5DB105415A127A59BE25D10C22C4FA117F19EEBD2EEDC57BCF40B05ECAEE0E3D111438051BB8B088B762FB591FB3D72441D2558E8FAE7E0CF36249155A3081560C27613E1C1F634C0A2F26C5244E6D85B15A7E3073ACA05D91D22EAD8AB6650BF41847693CB397E83CD758C33C74FB40C34C7AF4C31FD7A8DEEABF5AD0EA6C74FB4303D7E658AE9623EFB74395BF114640ADF68E1DA7CA6842C15624BBE171B9B383DC588713A2BA183584D0F1A540FF1F05427A561AB729CF291DB9DC483B7FB75C6A79C95392EB26575B73754A7AEA32CA7FE5B3B5882F2E14503F07D74992F5AFEB9C7CFF8AEB7EFDA53509D5E195E82FECA84F3A3BAF4A04B0B5E0DBA3CF9497F710C26D8D59FF478D7B2D3D703209EA0400C2073EDB9CD99909B5E0FE47205B51C89F597969B1EBAEBC5CB2EA8CA67E2E9CBDC7EC9AC55DC78DB0BCA735D2E17B0DD62BD605DA562A9EC665788DB4F3C01465B439017AA5C78CB4929F2E945E429E34D8E20D72D14087C347947500780EC084ADD5EABA3A8E4C32A85DB7AF373A1F29FF1D64BCB2EC911FDDE55157FAB3C71E94AEA2DA1C5D6182E23CF915A7739B560C81743E6307E5C0D15E7EF335B66AEFFB1782EFC75D603225F0E59ACC0713D54FCFE87DB42D3A5E63954833E2770C18A9BC0EA5978992B79B3F22A5EE14A9B2A60CB1A0EF1CEB781EB5EAEBD013C28275C7A89333E0FB4D8B1DE318331207A0350A76236E744F1E249F0D759D85F3AE5EEBC8C96C868F1AD29B313C1D1477DEDEEEE16A5275285C0500D3BB1790D213CB94FEF4E8F615E400A8B6635B9F2ED289B1C2F01A9A3C971C353CBEFDB2DF6CA80B60355193BC479FC73BA495EA76C7051F93C15470DB5BEEFC43E916F45814DFA53AE2035CE0D5C22E6F47282B00D8D184C16C752F5CCB4DB458C2E1DC94530E5456A9D628212CA6DB5BB9CDAE0445A5B22A697F3C5C53148ABF2ADE012ACEC0BE9443A16FF7A2E021B3EA3D79484A81D359A2AF166FACBD40475E96B8895BF154F9E0D4823F315879A9DA94AB8B314DDB0BCDEB5EB7C30E482F1E30F5B64268928B45A1A4E9CA87465D8FE432D8C30189602228B6F75B82CDD60468D15EA7C3ACE62F1A33B39EBD613A539CC1292884BB325C49F8EBE845408AA7C0979A1A4A64BC844858279E4DD4309D3177ED13765615C2B35DBDE205539DC76802A1FAE20DAD44C166E3CC728B98C2F10F3BA0EF302E206CA1E652C71FCABED12889E7D9C5ECE916FC16003770900FA67C75317526FDF6A28566974BC400E0FA4C1D2F1E392454BF181B788BA20C6E74DF288EE52CFA4169FED8EB5AFE717128954D0FF475CBADAA18213D42D5A3DF1277D0B3861B5B2B238762184760C3B03471095EE80BADAD82A9057EB0375FA921296F232292FB4BBA551BA1794BF1D6FC14E754188F8112D61AB7331EAAB6165FA532D17ADBD52D240C83F185ADB35A606829A29E370285D979ECADDCE16C5C245D26E39D8A421D2F560BA0FB520A2AC281D18824C27564B52A7F63EA2295D916E6FA529319EC23D3954EC16D69A42F87955FA0885FBD580F4224B2A538352CA1063B55C1D05BD8AAD81FBC9CB3436D074AEA20A96F61F6A89C657050BA7D9AF0A56FD749CC53A9D2A58651D04AA60D54F475FC293A8825BE0A924553AB61B0D185ACBC249CC255A18497AAD131F76624E575A4C414F9726F8134CBF0C4493B81BB43A48264B27452B67CBCB7936A2C7412D0B8A66D66A97EC495770511109079C56E3AFC52A0F64DE5D4CEF61EC1C56EA0E83E5E025A31386488A3B4B4434ED684959C23D024129819EFE523439EC409D348F6B32E4F6134F87CDAB472641FF2C93703B79FFCA2514E5F4B39A74B7948D74E6F2A26CCEA6CFAFD1535281BCF28E410C6DB5AAFCC2ECBC885AE9078EF6F42C8E4633D35E1A11751D643946A40E2EEF931AC87BBE18E6FE3815853417653F8908FB0EB4242352093728BA5B1988E34EADF0997882EE63A9C7F3376F5BF3B048C947B6CF4429FC52D5CEC888A96C6B7FFCB5DD16B8A23715C156EDC331696E6CC997BB029D0CF78AEBD6FE6ACC451BC32BA89B3943E412C5ED378895A82D3E8C96F7A13B410D43B8EAA7C32FD769CDBA4D89467DFF7CE56F7BA4A35679C94626E2168E64AC0DE7E19FDF590A79A21671E7C1166AB42349CDAD95825EBA0A74CFA19640FBD96B377951067AE93A083E1A6A49E4A9F7DB02BD3C91BEA3A5523830CA32B8E5D28C266F5373EB9575847D875A8631A4197A528A7A9EBE4F865A8E53BDE57BE6CB755EEEFDE6452E129583914657B03CFCDE832E0C5B5DA401212919624733BD0A2071E7C116634C3D32A6350C55988591340E267C0D9481F188798FFE97D3CDA975684C6D1E01B6800F30C4A94A1566DFF3854435D0FEB0AD15E8B69DC9F2D4A674AAA40CE8FC46D7BBE1D08A1600F9C34C502AE7F81CEBA97D2383C7D603E2419594F6317200EAA6ADEF78210A7C7FFABE929ADD4589F76B137C5F267D093C09288DE5FAF55D09659AC4E8291DC3F4D8F6EBBB325B70F503FA277A797BF77099EC6098915F7F7DB72AD0D7112CFF7501B3E0BE01F12B821997E1370DD0BACF3CBE4B6ED2E4005332031AA3BA4BDD5C3B86A0B7FECECBBD499A07779E9FA3667CF282F8FEED9BDFBDB0C0427FB485BB797C5DE48722475386D1366C65E9FFF59D7CFC5FDF3138FF7A7DC0FFCA5C4C01A119A029C0EBF8531184BB23DE9FBD30EB30211188295AFD2F10FD5EEE658EFE0FEF9F8E90AE92581150B57C17F000E31D7A0D6D60740811B0EC3A5E7B0FD00437C40E17F0DEF39FD0EF0FC10E5FD72220FD1BD15EF65F2F02EF3EF5A2AC82D17C8FFE896878177DFFFFFE7FE044E8F8135E0900 , N'6.1.3-40302')

