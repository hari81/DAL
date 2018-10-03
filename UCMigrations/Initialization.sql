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
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201709172352511_AutomaticMigration', N'DAL.UCMigrations.Configuration',  0x1F8B0800000000000400ECBDDD92E3B8D12878BF11FB0E1D73B9F11D7757DBE3633BC67B425DA5EED637F5674935E3B9625014AB4437456AF853D5755E6D2FF691F615162025910412402608526ABB63227A540432F1974864261299FFDFFFF3FFFEF4BFBE6EE337CF61964769F2F71F2EFEF0EE87376112A4EB2879FAFB0F65F1F83FFEF2C3FFFABFFFCFFFE3A7E97AFBF5CD2F877A7FE4F5186492FFFD874D51ECFEF6F66D1E6CC2AD9FFF611B05599AA78FC51F8274FBD65FA76FDFBF7BF7D7B717176F4386E20786EBCD9B9FE6655244DBB0FA83FD79992641B82B4A3FBE49D7619CEFBFB3924585F5CDADBF0DF39D1F847FFFE16A72FDC39B491CF9ACE945183FFEF0C64F92B4F00BD6B1BF3DE4E1A2C8D2E469B1631FFC78F9BA0B59BD473FCEC37D87FFD654C7F6FDDD7BDEF7B70DE0015550E645BA2522BCF8E37E32DE8AE05653FAC371B2D8744DD9B416AF7CD4D594FDFD87491084797E1D3E87D55CFCF0466CF36F9771C64BAA89FD8350FDBFDEB08FFF755C76461DFCBFFF7A7359C64599857F4FC2B2C8FCF8BFDEDC97AB380A7E0E5F97E99730F97B52C671BB5FAC67ACACF3817DBACFD25D9815AFF3F011EE6D3E5BFFF0E66D17CF5B11D1118D06473DC05952FCF1FD0F6F6E59E7FC551C1EC9A235198B22CDC24F6112667E11AEEFFDA20833B6AAB375584DACD41BA16DFEEFA13546876C0FFDF0E6C6FF7A1D264FC5E6EF3FB09F3FBCF9187D0DD7872FFB1E3C2411DB720CA8C8CA506AE4D67F8E9EAAFE09CD316ACFEAE1DEF8BBFC8737F330AEAAE59B68576F0E71413D11E463966EE7692CCF9B50D35BA46516F0C1A5A8EA4B3F7B0A8BEE507E7ADB90A79668C54EEA69B65B7B6C92EDB46E43AF1282B188B5640D7B7E59A4AD26FFFC27A0493D9AABD08FD9643392933AAF07AC5715EE830132CB1FE950E1EF65B4DBF2B959D381057237AF13760F4B0C7AC84D7CD895C84D7CD8F3D8B15CCE171FC101F0024DAF8162A9AB501D72FF1E16CBBB9BE91CEEE3BE50D74FB88ADC57453D6A7F9BAD05F6B829D6F4595949EAB5BA26B5DFD37F3CCCEE6FA6B74BB0DBC7524DAF5575A44E2B2B52FBFCB060EBB59C7CB89E829D6E8A35BD565692BAADAE09F51B7D70D61B507F5CF23A631F922D864D3D1E55BC7EC083517730110FC7200B7917BC35FBF780E98AFD5E465B342C3FA73542E58FEF0C3225AAA35BA6F13D46963D3D028FD2D53C2A422FD14BDA3FBE3335054ADA504B799185D5D655B5F547D76DBD1FA9B17255662B4D5B17EEDADAA579C14134ADBD77471C79D122621B3A448F2B48CBA4C85E876E6B9745695671AEBA9D0F293B45FCC404B6CAFC24D8886C0C2199E7DEBFD2553540B2A0DC9E167ACB9B345E7B59B84BB3C2E326A2D8DBF9D19A38EC0A49943CA75110327EF69AB7BA70F167E300824DB82E634645FE76C7FEF7252A88ED175C94260FBD16BFC88A8528E2D687C687572E5674909997EE236B6AB25E674C1419D1885109F693F974A2D61C78A957CB3682D2702C81F585A6D84695F196BFDDC3D2E0B1B4422EEB324D11DCAF5639594EAD8E589D8E056A5692FDA629814C354649B902E77A8E5749E06A9959A8282DA3B2122C3383356DE6D06037B3D0589533ECCA2CD6DA296611BFAA781A399FB1A05EC27E033F96C4CF9BD48A2648D984C8AC77AC5D3B73949D05CC0F8AE839944E336BDB95DEDE83E1DAE09E9199BAFD76A9593862BBF08A27D92E2D69C16ABBA8A48D01B74BD5A45103B312E7B5B4A661D5B8C3182437E0B0B6BBB56859900C3716C79A63535CCBE64F2536F47581DB1B8A46FAEF416444BECCDB3590B75937B63D12F2FC4537E4A11A8E12BE364C05D9EEC8078478D1B2F5A3D8C5100C53B54993B096160CA6851FDD359794DB95D6C6E5C68CF1E87F1D6F64BCB191C6B54D57513C8215A8B2A35DF43210121AD219EC5C356432D6A1655403958F66A8EB6BA3C3D9DFFBDBE7B0D316F1138F6EF689FDE4A9F49FBA22DC87D782CEC10BC6BAF941CBE406AF4C229DC9FAC2C9DC9619535F02D0CA47ECFA4B183D6D8A517A1D57C0A3345531F0311A7A4EE3723BCEA2EFB8751043614EB6552594B0268BE668B2154A9EA3F0C50912BAFEEC460B170FED28CB0B2F4E9FA2A42FAAD83F60EA754FF9FD8ED35D57B35DE1ED186EEAD5C3F4D98F2716301F2C602E2D60FE498459DC2C88106CDAD2220C1851F5DD1641BADDF9894E7670A4C8D45B8F11581987ADCBAE4A063075314EB3CA4B583201212EBAC264ED3DF2DB1CD20457601D158F02B8F1B37590EEA83799FE8BFFCAAF75B3C26AF356E0BC792BE0A2F0834D5F6AAA763353E77651987797984A96D66E9365160352A661D1D2BCFFF1B24A99589A0AF7C198D6B76CAC5EB0612272E855969134A35E064709633BD17A7FBE55FA00A5075DF09A028B684B26A2EA8C3D0C613F242A8E233893BAB3D71DC4E20C97C38BFA3E8A7CDBE0B399AB4E6A2FC83D3FE8CE22761D6AFB525A6C00610EA5C5D195AB7558303E25702B0CD597DBADCF1AB4067CCAD27247E3E45BEE9AAC3F6C9CB8AD94F98E71C2FEC723772E61683C7FBD0544503DEC2C9F1E9CB1A76BC0BF82D8956DBAF2E22808937C70AF1FDED43A7CE69E255ACBB4A59784A8D2677EF0C52BD3EDE00267F8BBB709FDB890CF39835FFCE24FEFDE79F78BC5DC9B3C2CEF683EF50DECF4E6FEF64E4BFCC220EBD9234D66E017FA35736472F20BE9AC1A72D94AB60BB3C0CFB2C86F8E14E4EADD1FCC56FCB6C3FB47996A4D72CE3D7FEE6EEEBD59F2CCB800170E6609E34C817755F16CF8AAAFE5366D00069DB2B530D2E5201A90EA40C3B1DDDD729FF5EBD9C72966A0EDDACA9135954C4369D5A4F6BD7924605CA14E55B0D7AD1ABA2EB7AB51FBDBBC0F983C5CCD96DEE7D96279F79BA9EB2A2870147065DD801410F663C3D09158DB3016131D0935C94E64978BDF16CBE90DAAEB4265F8C145BB8EAEE3DD8AC33ABFED5B0461E051403E6EBAC140F55D8CE9C266501784515D5087756137AEABE9E47A3A5F7CD62D5353C76B3B710863016BC15E8A70D501DC147B3E4BD22D814BC745FD596DF0CED2018FED3F63F3C057F2C21ED06326FC9DDFCB78E6260DE6E7D05F57D2DF7E19C220DAFA4C11BECFD8AF7DA488BFFCF06611F81CA5510D67A270E2B10F4C432B5A426A5FB4E1B31F9B1C24C44B2F416FC05DAC3261DA233E6E6664CAFEBAB23037828EFBD62E9A9FA6B7D3F9E49AB150EFE176063FC814EAE0456B12A0C42969D054E6B99C4F2E7FF6967777D7E0989B62FC70B130D248D180C33D5A75AF2E699EB4D207893E4A247AD61F1E42F5B18F8B3D3BB673B8EC008F7880D80749A86ECC3200D4C225648F2B4F06B7A1F03B212F4AF2C28FE3C62C8A65D7F9B6F4B861A986274D57F8BBD7037AEB7FF5B270554671FBB0E0D77E64CFCF7CE74545B8958C475688B89DFFD98F853E21205B664E14D0A8BE037D9C1CC6751DE8E5E5B0DF755EA2B70422EE22D09BBC7AAD5BF6BC13E57818B7FCBD65E0FD54F2DF765CC75B877930C252F95F2C1E8A6E7988343AD89E57B0A525EDB2035890E68557FD245FDF7551848FEC80F21E9928C04E5CAD2AF0D7A32A6064869D26FC47C682066D6197A52B7F15C5EC4065ED04ECC875A5D3749AD946499AF1E7D07E94F1369F2B84833455268777CFEB815B62304119FBADDBEBBE4BB34B05EE6138B1A34663C4D47FF6B388B3108F3307EACD757D6BCE493EF073F243F2EAFAEF9DC7F5E7E364A54C34455E1C32366D0FFBDE0696893471B1B6156982CD973BB25B1103AA150C2EFE2E79DF5B960B3C8E79B88BFD807A8156017664303CE0C728F1938007A9B4EEF4AF7E96F909392E84623F5E0CC22B1BFCEFDDE1AFD66A407E52DD8A5AA9409B2F13EEDFCBFAF3D16ED3D78F823D58FB43C4EE604C2A4D3886DA3FBFF098305E3AB3B9D5CC6155AE99EEEFC5D16348EBDCB6242A94CDF4F5ED79ED5FE995415EAE2CC29ABCE64C43F2AE975768E6E6F0DE7B240B9D781D6067DFC34EC375453D88D1D615D583E2E5C6BE5795C85D7CA8C63C99C386D3A6D893EC524D77D5B5241B9AA6AA9DFD7376BBB89F5E2E6777B7DED5743999C1C650A95B2A58F51A28408CCBA282EB77DF74E08135E518EE97DA95BFDF2709ACEA30397D6F94269578D6178BD5DD08D813F866868EAAF4E36BF91424E2594685F651AC6BC7AB49BDD596939FA7B7B5F3C91C7689812A6A1C9210D5E510B408182AEFB3B9F4421D32A62BACCE4934CC250ED515CC704D63986534CB8549CA106C1E80199B016FA2BC9265220B46DC861D8B21FB15F7C2077D31DDA07305013614532DA71DD1DEEAC2A791F52D83ADBAF0A147BADDA2AFE60C88AA770D8E22B1BBBC7E33DC03DA62E3175E8E3AC60D4D3D515593EF84FAABE73DBD6E5EBA185414815252399CCC941C7A270F201648E92508A284437F59B059B5E72CA23A6E643DBD696B2DEA805915B552AAE5C1A7B6E8F1628250F8BB18C1FAAAB4F81594210D6B28A9A5A85594A0DC7B4583ED2AFDA3CDB5710333FB4CA305C5E3C32F8C6EDEA9FC5D3717D8D96172BEEBE600AA4598457E7CC34387CCBBDEAC76C2C27FA6AEDFEFE843E9FA8AE3927CA81B728D88FA7DB744935764609DDEE6598E46A747CC269E5537536B60D3878A27F0AF14B4140B274B929EE38E7DE715836ABC71460C6FC974D753B45B395545BBA2E559329C53279BDD67A6483D661DAF42845BE5B6F09D68D05B3FFB1216F49017A12FC5D7C2C0A53B6F93E5FC95054F7940BA9565A0EB88FB003553856C316B87B1182EE18B75DC17DB902F7BB7DCAA619A061E66556C80E0358843A595CE40BA6C2DFC8421B1EB41DD7536721258BB512AECDED120A75EEED760879649B095B564FF4AC96A85B983AB2ECBC58F8E2C857B8701FA3AA2F35E19262A0DFC5118EE8E091A1B3F0FBD9A119128BE0DCBC9C10ED8860C8EC0464F1382FFD03ADC65ADBE2023D53029A4D8A4FAD0CF2E16AA0C4C4FE64EEE30FF3D2A20DC5A25AC0AFEF276C249163E3991000DFDCDB2346B531BCAE3FC310E43F06EC540D7BBEA218F1FF04CE2449FBBAB0F0B0F218FBBD9196BDF8B92202EDB1ED6D8107AD5D2D343FDD5C142D9A2F788A1D70F9AFD8E5249ACC63C3F78F2C2AFBB4879516370572CB355CAAF556C1C2993224B632F7F95261C01CC4E8A64ED675E3D6E122C3B749864C4051B1E3190AA3F24A957F5DC0F0AEF91BB9F7AF5B6106410BC9C24A2CBF7C26D75CB24498BE6E199318AC292154E5B09BE7670B57B9953C3725660E1389C7B357B2743AE6B877BFA5095B34655006444D662AF1255FF3E1DF6410B139AF7F90977D0A747CF0C591FD63C2020D3ADBD28FF9C96991C4F9386E34AD0972CD1FCFCAB8BCE5CEEF95C4F341FCB30FE5066E4E390912B43E521C255F0A405584F718E96BF621900F551CD1E12F7887DA7DA8CBEBC5456AA017AB7C73CD0D81F19817A2B46A1C3221FA8F7B534126663E1A652C5E1A5CA40FBF9807EC8CD77686338023FB43028291E1A199262EA38A30C2BCFA64017B2EAA8A1ED107AC4B0A30B36A4C92F9FAE3E789D13B0EFB01AB4E209ED0E333BB4EF1EE60BF788C503D81DE6CB3D25B9C2CCE4BA5A9CE34D2C8826E70EB095E1B9DBFCCD83E08568D9053296FA7DB61747C917A61E47C023437266930661B4ADF26FA3F46D93DFC1F5DD27C3C57CBB22743DDF944BBE4A6025AACFD5A7E9127E74D760AFAB409DE3259A6E55C5CEDEC5A19D19D41DB27D057773B384F373EFCB1A7E9C0B4FDF8452E8C99B5885EA6C7133F91976B3E0058A9E094552B7C4F2417C159B75D13928AA6B6916DA852B62E54D0CEF0DBE6AF57BDA45B9F25A8E22DDB507AA800400D5B372B9B14E4B0E0E415F1397A0BCC780CCE13F1BE4EAE89FAA3A1AE27119FBB3CDDE51CF8158CDB1DD88F68F6AEC3C883AC063390FB97D9EB11F02F7CFD15F890FE2167468DD85D7E72E4B59E56D9EC6CFE4EC28753F5C5E04BFECC37304B11FC9D1D530573DA4BB12B6B3CA476FFF0ACAE0DCE0244959186D99229A879EBF75376769F625CD98C2A0BD89739383F4FB1DF59019DBB19EB9040540EDA50B680956C71593D8CD314547F7737D0A6D83883EC957E9A0BB80BBA389698FF555FAF80EA6AC69C6FCC3C4C27BC0ED81CAF85E5236C988902CDF321C20831A21ADCD3EE40DD9C9EF3B8B75DED53AF452F285678D6E3DF924C90AAB32E0DEC92FD1BA49F9D437C2D28A3BD2856BD6AB6213055F12A63FB8421DAEBC555A30A63C086A1E11D03DE2A02C0A7E1932CC8C6C879B11869AEDBCCC3DE236D119B29AB911F0008A1CA5DDA4DC9278781E3ED54FDAAB465D4DF78E47C5CBBB7B1CE7525B03767B4381942807370B6C397636FDDD035AF4770F69D7DF47EEA758BCCA3EFE885B8072EB71F0C1CF8ADA636F13464F1B6791F4AA3CBE4E313260B6479F4A317A3342D22CCA9DB769DFE311C31D60B514C31D805A33E95C11102E25BCD9CDFDF5B442613023F3CA6A80764823753D20509BA632D598DC20994F2757B3DB4F1EFBAD7887DA6D54A8DF1D8CA21A381655DD5EC64DF5AC1B5548106E6CBD323A06CEB5542F2504A369994DC34E0C87583DD92039F1E7E6A2BF841DAAF499CD4C1C7BA6874AEF7FFCF3308F3523F6DB0B93E7284B93765825BBE170B39EE7B399E939C17EB08912F1690DD5E0DCBB1BDC7B316A3FABB243F318FB72D0677208AF4EAE0D8B5EF48EA3641BBE4A77FA0D77D0C931FC10A722E5DC6EA21421CE6DB0553516D5F98700369C8A180C16AE15700BB39BC927F8CA5EDB291D2EE4CCA851D0E64783A7B744012FBD59A280E0BE4B145889824B004DF07417B240F590BF7D74826AD29F8F6AD28F2739403245E203E7C117D192CAB8925F736940243DF3D278D153C26852BE881EFC8476A7588E78404127B3DD1147998DBB0F8BE9FC9749053F9F2E1EAE970BE564808D2A9174E782020B9E452404BD0F217044E63308001BFB08CAC29C61CE2DCF9F2EF409D4D9FEAC275DF1302435FD3A40E7059B30F862C1C5DC49C9A3ED3B8805596D5C5B0EA4978CA1161518BA93800604390F1EDA464368615173DE7625ECCA6360C0154701F6753381168DC65F2BA0D105FCCA546F29DBB760C7E2AC147E8E66ABDE6E93B65E0247899FBDE2A2380E25998CC0190C3B05C9575C6C17AA2432BA08029CC0D4BD423EC4DD6D9956D31A75EEE2FD5F06313CB7B759CCC3D2F5DFB9DCB3F799AEE10EB139DD1E5E86C3DA7CEA39BDF5C29F626AE8EFC7D9888AC2CECFFCFACA8A7B31F4C3D5EAD82887A31B23C6B01665924103619926CD4F83E47E329FDC4C97D3B99A4381B5A9336481039E221B44BDE50BC5842198190438361F13B7329597D158813B7ED6B46B787DC42F145D481BCE2FAB4EB573C0EBAA3E5BD092BB5C32396339B9D5883F9A5E8168D093034053A70542D15F38028745E22447B8B11949907247FFC4DA7E2AC28FCF489CC93263B124C9F326DFC5FEAB57BD82737AEFE34A2470BF6B8962806EE35BED5AA5C3A17ED32AC0C657620E579887004C756A335BB54687ED5B75F06B5DF3F67477727B1B3B940FAC5EF780FD65ADB6CE313A887EABECAB8DBD353AE91CA83B81900BC21DE1AB5E0152DD4FD809143BC003BD6FB0F2B9AC7245408F33CD0F2DFC9D1416D5FCC2CD452A066DE461AA83CCF79790CEBB1AE49E7A8F6299F0E4FEFE7A7639511A905AE5DE91D9B51261C9C572E22BA08E75A22B75441E5220265151D2C46AC276511F880998BBF677380493ED6CDDDC5D4DAFE1BEF012B033ED02B9379D52723828654E4E9E1D13E84CFBBB9C5FB35DD82F6D779BF60DE1799AAAA3C7E739F27FEA09AE3839864CD0BDDB39798D4F3D5F773B83B6FAFEC71F076999F1606096290C58175FCE82F94A194D350CDA6AD3D46C4EBF5B789DD165DD4672244BBA58A1D3AD9C7B8A9DC2DB3546BA1AC6B0B3CABD1122757C1734871134ADA2B3047EEFD0AC77512CA1D0435C1E9E3150C3FB3FF048BD01D3D522BFC9EB87845DBE66549039392ADAE7D775E6978C5912E13EA4EB571388ADE44D88322A1E4DAA28A42E4E4E94CC0D764877486A85DC2AE62877979DCC97DEF49FB06DAB6A02A82AF450AA01F755AED6EB6807FAA53FE72580B10FFD43CE99ED8E077A08BFDA060A53E1D1BFE874270EEC5B76947AD52A7B0FE30B16A99E56E5BA0EC82465063734D799F097344B78D4FDC0ABD300F694A7F704A9B2141CE855BB0D75F5A028BEEACA6E033ADBF00ED0B6D0BFA35D0CBFDECD6FBDCBC9F5A577335D7EBEBB82157E2D887E705458D9704045603721CBBB3BD8F6D21463060AD7530C4A51B9EFD5C67123196F37F635C7BFAFEFF24DFA7D3D85EF0EC0EF75268B61F4B07DD3E32B80F996E911423E4C4480C75AD3C93A9083852E23E7EECDD2A76611EB6C3FC469B90E1FA9093BD9FA81B13A11FDDD43EA3CDBDDA88C9B285EA7BBA273DD8C08E2CCF844B48BA9AAD423EFAFBF4D4B29500BF65A9C9EB130252B7C4F595AEEF43610E3E41759699CFBF02BF71D08D71DA9CC10A4EC1D1AA931443801E99E1739BA65ADB025AF89BFD5310A4791E5CAED2EF0777E50317BBD79DD24AE7FF5B270554671D10F511AC5B9CF099A674EE58F48E2DEF882CD932364DCA1C58B8A906AF2A8E1E02E20205BE12E5140DFAD87EEBBBA4A5FE2BD579FE8D4675E90464FF4B2F4C5163428B805939151CB39121AAF8BE10ACDE6E56A8C560F9A340F98A63D5FDC243FC821F74C836875305E1E228D78F9EB76C7B40A5D7CB70B37DDAD04CF7A82E822539A57C1CE6CC42D3F8ED3176F5DEED8B05BFB149F0483A7895D7B4A2DC52CA640B97B890695CBCFB3EB2B6F3EBDDE5F22CE1646CB0A0802DA56809A906F86AE3AD5507BB4D4709D59FDBCA1DD2A00018F46AAA81D8C5C9BFE1AE1763A9F5C7BD37F780FB733E3BA48D5C15108B5744310AB5A98F00FA8F83FB03F76AB925C1F1C81584D3704A96E8F31281D5D843A5EDBB602DB1CBBB5B41647A12AD56AC5400F813E2AF0870FA87128C1542B02D5362C0C08425D1F065D3BFD1218180C038E0CAAAA1B16587F98CB2627B66ECD5070D74F4413F2F5EC863192CB097148222C62745D10FC40053867639E2D6FACC75CC1D2C6CC40ACC6CCE17A5D332A7682C9CAAC001BDBE43C9323B31BCDCC33E39B0977A6E5FBCAC477598B8C52C306D7096EB553815ABFF36863ADA3240ECB7C3567A59659A30F94F60C6306D44F1CD60C47273DF7DA9A6D4917B72B1B88EF1B52F647B2D94FE2B1C194C6DE38A222D6990794B12948F6E7198F0C72E517C730E33DA260887359DBD8AE5C3C49A9BAB9D4DB662C27C48173421F9D53C731D41A2A5A7E618468BADFD6F75E5B5177C38DEC3DD1E1A9BEB0C7783AF19AA3BB38B1E9B6F56A6A40FB32BBDB34315B3E79738E6E5FA8EFF478D3861B62BBBB35AD19C99B25CFEC1048B357F68B1B35BDABB0F0A318769514085903ACDC2A4A18499247030E643E73C40C0CC3EA693EC3A9D14EFC76340339811AAD6C5DAD462341F0031D5B8DC6744450A39120566356A9D1E631B702405C4D979399CEDB4CAAEBB5CF3C71A4BADA8A73590BE2E070561126C531B90B7B5A1FE5CAD5358EB651E105BE1B776510E5E89E6C2E5EDB57C3527A2213B16D222F4A1EE33A8CC67D1A193251346E2B7F4460CE63F6E5C221C2CAC7210877854BA4552FDF0FD14B6748B783ADD2D6F52A6D8758A5ADEB55DA0EB14AFEFA5F8CDF7A3CA3AC2B94D5A847F6F1EF7F4980F6FC57484543BB92F797DFD00EE68811F63FEB2B81CCF2AC67B06773D647C5D6F559DFA0FC7ED6D7897ED78CE56DBC247C71C5A35E7822F01AEBC53B6FC799AABBF3A985FCFD90C8FF3824F23F0D89FCC72191FF7948E4FF7348E47F1912F95F87447EF16E50EC83EED10B079B744881C6D203C046A0699B3C4614682C8D3336028D6A84448106B0D460641909EC84792CD79599B87F3ACB0E9EB10416A7F9026A89A54C22DCE370C48505D99F58C8AD6DE03F5679AA9303936BC5C070DE0E4FDB6CBCAE116E6BEADB19E2733EB685738FAD7E5E668FAD349FD8B77DFFAA9F3C556848B03C82401FF82CE4CF15B8E3B65DDB7DE0F7B94C756EF97F32BAE563FC04046AE3272C9EE2D07B7513E5D5B517D975FEE172F19A17E1B6E3740180F572CE961CA855E7463BEE2D0A0488818B83A39EEC951F85EEC6536EE20062BE7FA86B2A2E5894D56D22C9A4EB320EBD45B95206983CD6C0AC120A0092BE1050D4155ACCAE7497B4400315807975783DF4DA5495FBDE78E18681581F2C8CF9DACBD52AA1246487F779D87503AE00DD88C4D59DBD313584026C742FC32B0B2FC32B9390E84ED4FDF4D0B4F6A98C649F4892688E719F110432CC895FE70C5B0FE21A58E336276277E4E3789CBEDA8FC6E4683DE8953EF938C55EE50BA7AFD5B617CE56739CFC63E5B1B7F8BEE59C9DBC76EAAE8460ACCDBF08B3C88F13DDF6353ADED5544F54E4F623DE75C2A0A0B48CC5CD03491ABF24D667F83DBFE06F8D0B3F8E49A0D7CB2B5BD0BD7FF28757D25C68BD9A0DC3640454D2F4BB1AC4A6313631A4D9087F2FA3DD160C558308B092E58F742828F81D020A4A176106E30FFBAD1AABA22FD8ACC0019648608CBE727D3A5B270A3D0F3EA0331BBC77D24A5E69E51EDFA54C78C9C26DDA0D0D42A04B6FBFD519BFF5834D5B7040E1D973888A857B397D27D623E100D3A4DCCE9275F8D5D59BAB6358558436DBAAABD25F8F55C0C409503DB20A5EC52A32F6B5AEA6EA262F35F4B0AA32A4DFE5409602FDA84CCAAB95E4569BBFEA19D78B6D4DCD6FEEF1D7D092196C42248A59934AD3E88BE5210F33373D71F2FE8AA12AFDF85A8E1C7B1E8FDAD41973F6669FC9CFD35BEFF36CB1BCE379C9A0EC0D4045EFE172F1DB6239BDF1AE671F3B3636736D39B18E19C4221804C9128AE0C77A1B678765637BF9B098CED9B03F5CC366CDA6583DDDAA3A52779515FBA55C14EC074CC98ED6463E0B438DCE73C55E58316108C918AFD4EA79762365B930DE906CED58C34DC730DF733417E070605254092217ED11124125D1870AEFD46A4D35579FD075A3B7CFC6B8CE1A066B01D5C5E0ABBF8D1227E10DEDF22747AE72B7E6DB9276FFCFD4E1117C2B4CCABEAB5083F5557EEE3F79712B5272DFC8B30DD62C7ADA0C80967756B0090C16615318CC58CDAEB357EF5FFCC54EEE74695A689DAECD234F915EE5F670D9DB06ABD3CEE6BB2C0DBE84C5A874746C7454328AB63B3F10631F1B9E23AD323F8F9E4312D0368D727EE4928058D7BEB43CEE70BDE3513F3983FF35F469D16ECBC0C0B8DDCC78DD8CAB8C892633FE371251394893C728DBDA76F5083D4A67633F2FEA677E3BABEEB6E147E9F0DEE3D37439FFDE2C3460AE08E234A844D25E371EB833B06698FDAE5E919B9631BD64F8048A2F2DA65527B430CC7541BBF8FDEF74954745E85D3262305C16B920852C8C433FB7DCD547E0D5EBF0A4D4D21B102EB86EDC587E2F99146F93199E871A609A5FE254966AA1752A4CD546EBCFB523B0B53B6F8D65E933ED7C8F0A6FF595AD0806C3AFEC6588B1FD4A50D669D6C1A1B56EF734E351D79206A1A96A67BC9A909D442752FFB515CD5E939DDAA3067871E9F58A1CA6E31BC7EE92600C6D939318D9FC3E0636FF14C635A72FA1F62360CC989D533C478159D67272421E1B349DC86E24A17673CDF8B0B203D3A5D98C6EBD3C8D9FC32645182EF5C3B89A4F0F15ED9CF3D0A0CE8AFA04D530D809C4D66B1891AF2AAB2AD8A9BAFE98CF24A82720F241C4447D8E5B9D078749C79F0A35C489CE8682CB89FD4E88368AB1CE09C2E18442548F01E29E7DF03961FE7D3A60B09DB93AF0FC833A6848B9F7D7A32E8470AB3D577B5C5FD1DE09A386999B99B1DB3E8D10B2D960F3ECD6F54F946DB7F29C6D25D3A2B237059AB1589CCB284689AF8D766C36D2A0D94073D9711421ADDD56F0D1466CF32D69A28A287333F5DD4275F621F40EE2D54FB4815AEF062CF70EF4F2609C6DC35B76923FD82E6D356FDE852996EA8341CF77C81F451555FC07F2C6D5A949F6EF4DAC8EFC1E19922D7339F37CB809CD1CBD03B2701B6EED2D13466FA384DA39C607B761CEB849FBEA0B9B01B27EEA224C3D228DED31DFA58A5118DA15324F7A762F9DDA7DC83769567C09F5F7286EE54642502DAB9C7CBAE4598AF47DB6671C9C69CF78D64160639F796CDC4732B27F5A0B63E96C896F44642CC2B0D87879F4BF87F7F34862ADD64888A7F3E20C133BC222ADDFE07F5C7EEC3D718DA85093E47F07493EF5DA80362F680FB36127ACDFE5E4FAD2BB992E3FDF5D59C4136E419F414461B6D3026FCBB848BAB6E4A628A4633CC63074C4957ADDF381072E418C8A62304963F0B08AAB0402825EB2C8CDDDD5D418C5B2AA34F64669BFE1A7EE07F0FDFFC0FA74D5A656931E266447D5AEC17E3D4CCB451513B19B8B1EA3AC3DADECE0FCAF71D8D2D630207AEB38D56431E625EE3724F034CF1598AE1F6DCB2D49376D414709193ACAEF1797548B44C51DB8C46EA5892B998B01D2A75A0BEA86765914F0C09F71F82C376BEE70F50ACBCBC2272F4AD68CCBCB9133CD386E78476ED3A2DFD98DF15F3CC4E8BC34DD90E93414ED63E89BE5043CF3AB33CE3BD6680EF44E81745A774BFB394B216C00A750F87B58B74F60D636DAB387CA58C9DAEB7B0A5B5AD2CFF606F8DB3DD2189BB7B3B4AEE254326621A162CE3CE8B0EBF0D1673BDFEB3E2BA53842EBD8E2C1F02972C5F67759856917F6E28955B086CBF9E2A377F9B058D6E1884C3C1282199B67D6373B791E3DD9FA0CC9183A6B3B200755DD4A51D952B5486E5059858EEB15ADAE96B6DAB7931875E34B18EEBC97A8D87855E37479EF5BE18FD42B4C75F661B64FD5315F845DECD5B585A02F50258925A96B92F32533F8BB9BE91CECF5A1D0831957D3736D45C9C0AAAFEDF65108D80418524E5F13B704F601E60831830C6B61A8AA8D20E4623D1A7C706816437B1784B15C500773D1CF72DF6C16FD997DA837BA034FF790227BEF50CE3887D797AC59AD8E630ECC69A96AF0A4A106233E3697884DD3799185A1EE66CD4DDCD3BAAD725566ABFE46554453BB342F0C8102DEBB516BEA49F4B5961C77E30AB83F4ED6CBB71B3F879BEA7A6A8496B6E92AD20628BC70136881B7F5E87F1D654C3CBD50DC6B5FA1630CF573B3C78EE8C8953D9E3889EEE594BC1AD8DC8F6E66E4BBF16600E34DB573D26C6B38239DC48B587988D3D821EFE607E0FBC14F404B0F75A8CB8C59C6FCFE62CCB3BBDBE6F0D3D56D743CC1E1D0E4B8024433BB63091287164712280ECDF9EB7516E679DF6DB0CBA2AD9FBD7AB19F3C95AD348C188B521E0669B2B6028D72CF0FAA19F376FEAB85B732F73AD6283806039ABF4A93F895DA644B6CB4B8620568858E653F591ED3C9B6B4F8FF71FA949AD423B46A66387722C6DBA2A0203B51B0457DC9BD32B3488FB12AF32861FBC1ABDDD8B512B08B6D1805DC83EC4BE7A906928E182817E3984A9054A24018F83995FC85E17A7A677797F17BD8E206EDA70CD00DF88F78175DF6E723D358A4EC657AA8C5267D89A36D54F4E67F79C838584B93C13E96E0601DC58402B8F1B37590EEA80CE87EBFF997AFDA77494EE8FB324D0A26688DD256C5CCBCE9D7200CD7CD0BA69E843559FCE9DD3BEF689C9E3C2CEF48241625CF6914709FAE115C4B38733E1283B32C7557219BAA8C1B6BCDF1CE0DD470483505A67530507CB9622BB88DF290745E3DB21E4EBA32CE08F9169A2903ADDD4DF191B23AA9F0A072C9AA0D56B2B2CB4BF706C3DDFA881726B83B22F46818594D8280ADF58DBF83D3FB360D0A75A11174AA68FADEADD7CB1BA04D39FAFB84A6E6D8370A5D8640BD50A0B01377F709B77A91D50DFFBD7B493A2F6E317E00C64B58988EAD588848C15A3EE3FE92B269AED355B886EE16AF5D8DCCF1CC3CA2352D6A2EA1ACA49B65979CA21BD903E35829029C2ACC90BDB3A58CA12FFFC0BCF8F10F3987F3208B76E304E96D071C29F4C2B3ADBADD3F5B9444511E0CAA8A65A38230C41E5382F5DA4F8D9BC6E4E16AB6AC91FE66DA5430D4D83BAB72C59A94EBC836BE8D8460AC7B7EB719549CBC8171E41CF81885F1099CB45721B7055D6EFCE449C734868A3AE23FB2F51FAF750752896ADF83020A5C5927AB28207AB91C55E8AFA693EBE97CF119E92DDC54FFE6F25D0EAC1A38DAEFEB46CCB388B8D08B909BB5F5DAD5050A066BC12E8C70D55EC7EBE4FEFE7A7639A94EEDE97C7E37F7AEEF3E992817041A3D3D9905FD4623E66BB5F156D8F94FA1F916C74D1A8D2C4BF50E116EDAC90B3FF8C25F5AEA06F517ABC6AC88BC8A1871FB714622F223D0D844FEEC6711A7CFFA0A884AEE5DE8B1459E673F2E4D4DE3C39B92D93E522B1C92EE0EB11226CBE5E4F2B3F771763D5D2CE7D3C98DD129590578A23083FBB4F6FD220D76918CC5869FCA86E97FAA7EDB850BB479CAA3899C66062ED2D4E6AD7777AE5526193BD1CB70A2544E0F7629AF46CAE654CF4A65BD311CB38EEC454D83EE2F00F589180C82469A476DDE0803A98DE05DFE549B39A16B1DB99EA7618AADCB1E0AA0FC688904DDEF9909341324E67EC2E8B10097E8C9DB47360143AD1B36F6F0919E34047EBA2D22DD925A6D304B0BAEF7707B30B1CC11A6DB4EF513D86C93A8F036755E2E7BBBAD8C642C89679BAE4B26F3EFFBD0DF8252E3EBA8CE60904C4B310A9123AECF73EAC6198F511C53AF8F5737F460342D04564F111AF0F07773D004013A0B576514AFBB3183CD7D664242E1C7B15587EB5E32E6EAEDB1D026DEF383A2F42DBC3DCDE2A0AB27303E9374E9F4F82D3D48F9661EF9349B83EF58F2F6E86EAEEB25CDE3B4611275A66A2FA265225DA74159A5D9F4FC64ED455BD6159DFFB6CDE56775B16ACCEB21019CE4CAB38EF2DE27B39D02CDE8D79FFBCC74E13E339D17B313DDC1914A1814D207A2F0A378F824AF87E62CB8C9000988B88BBED7F1D11FCA87F9C5CF323F295EBD20F6A3AD3E47B3A3775D8E982FA52D27D7F4E7713862867D95BE306660786A4B6E07CDDB3F4D6FA7F3C9B547548F14602752937AA94767E5D2D2437BB1D38472DDC5841BA18A6FC183ECDE7A7A81DC8C3D647F9E7965AFB0F4D31AB98DD38B5A4FBE6C5F02D588124632CF7E2CF4090159A65B12D0B79775F5FC9FF21F8C7DFD4339A0B7E95E1DE8BE72B4D8EE1EE377BF7B3D2FA27AAAE3FBD9AB2E464750E7BED829D636F18D2D4D2307302E927AD54FF263CF2E8ACAC5CF7B6492383B715D09B99D262A37BE415BD865E9CA5F45313B50593B41D1F888F44DD7D269661B2569C68E889D1F65BCCDE70AE1204D95491E6C426EC25C0FDC12CF3751C67EA17FE548599A5D2AF01EC3891D35811830F58FFE219C391049BF3E746C5F38D7A1D7DF55793A8E939532D1D4D8E71A9231797BD8F736B08CFBC6C5DA9AFB6EBEDC915F1333A0D9F18E77C9FB5E316B2A8E79B88B5BEE5714C08E048707FC18257E12447E6CDFE95FF71A771F86DCECC78B41786583FFBD3BFCD55A0DC84FAA6B7F2B1568F365C263F3B0FE7CB4DBF44CFEA8EDB390F687736DA98DB4419955982A0F3357ACBC660EAB72CD13C4C5D16348EB1CD15E6D7832A5074ED50AB4ADCB084680EC911801BEA22C0320019FD8138241056D266F553DCD6BBBBCD74BBBDC918B05D674B227568367055FB8BED137498BCDFD15EE6EABD0C0E6E53E563E55D6CA9A75F5CB59D9C631D6E2DBA972BCC7FD4D65E92AE7061BE5D50B952F5B74A1CF05FA5E60CCC3A2DCF5EB45C6C4CF6DE8E72DB50F1B8F881D144C12F3E26A5392E6AE4AA26701C7F30639D34EF7269FC12D165C49DC324A0BF41BCDCC28A9C10B892C0FF374A1A9F96FF95E81AFC389DE2B609B36D8E5518F13DEFFF8E701DF26701A99FEC2CE4394B054D71CFD92E9B9F6A9B0BB646A038F75C9E4E8D122EC1F60716E5493E02807A1D12B0B2900BA5433C8C768C0FD05ACAEBA2D76164D4215614EE1145E9F7BBDF69D02CD583B502B2A5B6C4526C339D882B859E84B6EAD5C2968723BC29CCE53AC1F9B87D18CEF29D69FD4F2BEBACAB744ABB39BFBEB2991568F30A3BF35DFEEE2B03FAD2AD08CC91AFF4318E2EC76713FAD0D7CDE2FB3E9AFD32B0C99C950A313DAD1409B7BCF51F812AE6D494D85682C62D39B9A4F13FB673F11430B7FB3DBE5747E3F9F2EEBE0014CA0BBC1EA590AD0138882AD33CD4202449F8867A77A99D59C8BF77F1924CDD47ED69C286BFAB7C1EE48FDEEC3623AFF651F2463B6401DE622CCD8C4AD302A53A91C639B1E90DC0D97316622B53392EDDD3EDADE82965EB0352227D43EB8D97571F9797AC328F692A6D103606313BBDAAC4DA577A4817C40926F7AE0CC095B75FF3E0201AABD33FED9AF330734BF0DC6F51BBA9EDD4C3E4D695BA10239DD36E84BFC23DFBC0F183F645516053BBB0EE4D2EFF5982BD9CA8DEF364F3A627257B0B93644EF92A3A5C2BB9C2CA79F10EF7A6488D319390246AB4FF6D10F9488C6DA35C7660D2460BCCDB313E40FADF36BBE13E81187E6F34D9A152631D174C5E8D267E7FAC13B78E24CE64601AA5BFB441172225BFB0BEDC19843D23FB4ABBB581E284573DDB403964BB69BF37C71AD248494280E590772B0F4859B8C96D06D97A54FCD225A3D3CBA0E1FED3C746D62B41C20B567BB13196213C5EB745748F1680CABCDF844B46B92272327E491F7D7DFB653A2A1A6A339022DFC6CC93E5E4F595AEEBC7E938FB99B0FBF72A352B8EEB8471B2EE9DFA191126EFE8D48DDAA77D8BCCC4EFCD0CAED2EF0777E10358F1FECDECE368F708B7E88D228CE7D4ED0AA07B4747CC1E6C91132F50B610CDCE80F82CF3F10CF59C46FC029B0E94BBC8EF25DECBF76A280A016A47EEE513DCECDD2175BD0A0C8AB34EF9CD1E8C6EB62B842B379B91AA3D5915F5DE7E24A9ACFDACDEB3AF34B26F47BFB5B0F2F7FDDEE9866A1B368B8CA07947BC71894B631586DC42D3F8ED3176F5DEED8B05BFB149BA6B4F093B59FAD3DA596828847E7275FAA4CD596118A75A601827B39E837EB646993F0C5ABB2D05AF8CC93C108FEFDCAB8A35D85591D9417A8E789AA791366D45C5B0ABF8B00E91573171C28C59870CA98BB2D91D4D2A680166A9D5B1578CB4E543CFBCB1A172C9D6A5EA01F493CD04051693544CEDC11A0E84CB997F0D64367B5D4AEB986925099BF6C17194685DF4609B5738C0B6E43CEC33B1736C833B94EF54E0E4ADB48202ABE409305C027C9B4540795E1D994F7C36D6E44F1FC1AE3D813436A134E4ADB630FED34DBAE7BBA7BA4BED747237B2C1EDAC53DCF722365D676D3192D5C6DF736DA13B9EF609DB5BCD8B3A5F69B3A4AC0A25C799FEB48EA08B29781C6A6FF7D0F7868834D64EB2A0E22196B272CC22CF2E37E8F6E31F6E4C5CD0389EE2F89F5197EDB803DD7CB2B5BD0CBDA5CF7E195740EEFA1AE2C04B74B7B2D7EDA2728E6A58338ED1832995A463B09B2FCD1429605E21DA0246F39741D22C91342D842B3CC9B55ECED6961522744E17E3079C1286B6BE29C3AD8D1236694726E479D4ADD2F3B99AB046194F466C83BFCEF19C70C578703661C7365D0FE9E724C30776B80489CEE367C399E5E18EED6AE7FB2B7AE0A7F2210283F4A6188CAFC844456DD6E0B9FD28FD6318AA85D0DF5183717015007E4F4E228F9E2855FA3BCA0B370B7D9EA7307D2AF9DA5F1B08863B7DBA188BE366554DE3685643650735D9A1C638000510BD6C041F2D93A0A1BCF36C073B8F61EB38E93034674CEBE086F8C3116DAFDC5170F925D50E0D29DB7C9728F7D6232004DDB62A06BFE66ABE5C6816C31F393A711BC808A2A56B74DD2AEC4CEFABF0F2D5E354C5A743E8F7E128476D0FB6659AFAD1BA5C2EEA38752334CEDC10E2D9360633FE7A984FC35BF31B7591DEE7DA173677095AD7D6FF6A0AF639C06FE3806D3320B367E1E7AF5EEA789A02DD8758B29D3806DD6EF08EC32FFD13ADC65ADBEA046C160B661B1498777D42D038363B5237FE0EF8E75CEBB9A854F23445C0CB32CCD04B77DF37DE7631CC2614C0CD4B8AB92E1F84110EEA857B3571F161E42297043CF6BDF8B92202EDB590AF06E5D3C7721F90AF931CAAAE3E9C9B3173BFA41B3DF512A292098141E4F4CBCDE45965620FE803FE2D1D65F8338B4B45C1565B64ABDADDC7B8CE52C29B234F6F25730A0B301989D11FCE2DEABE78EE86DC685192E8B44095D5C4F52AFEAB91F14DE230F03EFD55B4B101BF0A28D882EDF2F4875B9290978E6E199318AF28D154E5B81B9F6E3B50BAB7CF0015EDBB868E45EAD089321D7FB38C6E4A12A678D2AB3CB88AC255525AAFE7D3AEC83162634FF04DC6951295F42D607C6065EB92AEB45F9E7B46C8462ECB921E0B812541C4B343FFFEAA233977B3ED713CDC7328C3F9419F94865E4CA501D74379DE4CEDF0962F31F70B43C38F800A88F9AF190B847EC3BD544F3E5A5320A0DD0BB3DE681C6FEC808D45B310A1D16F940BDAFA591301B0B37952A0E196306DACF07F4436EBE431BC311F8A1854149F1D0C89014B309FDB8D830AC3CE01F5DC89A2CFEF4EE9DD74AA5FEB0BCA3F91DB1214D7EF974F5C1EB9C807D87D5A0154F687798D9A17DF7305FB8472C1EC0EE305FEE29C9156626D7D5E21C6F6241B4127780AD6CC5DDE66F1EBC6EC055CB2E90B1B46FB0A2ED2EB5D4ECEB7B79B6CD0DCE0FEFDDD8AFFF95AEF2A830C6FE71D45AE5F4357C33BBC0EB95BC7A777C198970DCA0FA6008F9C8919E1802D419652F875D20B4D160602F8B760A6C44FDD63B766487144E164ED3AF5B3AAA0D78B34E482DEEA6416729C85D25947691C8FEDF39F9FCF754EF8A9DF33DD5BB72477DCFAC0E827DCFACFE3DB3BABAA9EF99D595F5BF6756C7C37ECFACFE3DB3FAF7CCEADF33ABAB3A47B4C00D925B9C9B2DAA2DE7357C0363EA10614E974F88F88283FA5825FCEA33C9838B79485BC7BE57B57640B560F4486F42D6A7877A93709CB0DE0A837D6E1827D937E4B47526FBB4DE97D9955657B39DDC7FF2E25624DCBE91451BAC59F4B419002DEFAC60261A4C9914063356B3EBECD5FB571AF12C702E97A685D6E9DA845FB9C4C0767DE2B4BB2DB44EBBFB98B1FF791CBBCBDE36589D7636678A63C01F0D8D49F6C74647A5FA68BB636A3FC990E2AF323F6F6596C185BA4EA3BC6859315040BBAE3AF1EF15D3364893C728DB5A1B230FD0A3743664B2B7E9E584D04E1D4483F84C9C4710E5A7FCAF61E35C875A76E3C30E37F3503763C8A1F1FE4727416EABF759D595C1CE8A44DAF0A31189375E1003C4EB2E47D10BD635631EE1F9491930E69AE8DE41B969E7A5B5BF30A64339BFAEBEFE7FEF5D1E78349E31C4EA2C8C433FB7E4A547E0953E3AA09B03B75174F65B65841C57BF976961BCA0E96577F0AEC2C2E7264FBAF9610F7A422BC4BAEA00DEAE6063C0A8B51A9A87C7D1031151B78AF1CCBE058CA2FC2789223030DC54DECBECD199C73ED60FA229C58DF1435AA1312C2E0827D3AE5593389312598CD34E4D4A03B56517126A2F9D0C2EC36EB877ADC728372FB347BFE367898A24FCAF3AF1CCA6EDA48B1BE0D7EA3ED71A3E0B79D208EEC76ED7761F78C45168E5B7883ED396F3C9E5CFDEE4F290E11C974F17861AFB24F3894751947B6B88351959BDEFCABA7DEC413FE7358D911C1D22CE06B476CD2181F40952A63E98103939EA368B579B67C4DD29F292F085044E9D23EBCB38A3CAF9275771F374371428D0B377C8FB1E7E42312F4462761953A5EDE8D34771AB8FAB43DCF75FEFE6B7DEF5EC66B6F43ECF9693CBCF33DC71A7861FFBE06B924F7157C726CB8DB78978B8C9C832F82A126D5F9D849C3DD5C1C15B0F8D0BD0607407EA315E5D1E78799CEEB09AC51FCD17B11903778B73DFCFCA16DA0EB5E2A8AF3DF1F6DFBE3FDFDD4C968B07EBEDBB873F9BEDFB858DA1C84BD7DBB78BF6FBF6ADF698D7BD01ECBB256A9CF5C670BC7DBFB319C7780FF35A45A5E8E4937235BB7D31F7678DD7B3E987CFD3F9DC9A371E109C0D738CA370B509B3CC357714F07E678FDFD9CE09A49BABE9E47A3A5F7C9EDDD7FB6F81DBB812D8D8DB751DB2C1673CB3D77E3BD9ED4E059ABE3711D8CDE85B64095D59C0043630F6F6BA51CC0C7F1CDE3C3DFD0769531CAB9F5B6601F7C1F3DD5CC6E5DB2A71A1D6D8F26D6D9AB3A5FC1EFB9BB8696EEEAEA6D7A47DD386187BEBB4DFC452378D32DDD340DBE53BE19F07E14FF23C0DA26A39F7282FE78B8FDE643E9D78FC974087D364FDA64E0EDAADD6E40EADC7CBF3931E6BB071D7091DA380F5E0EF3FFC5FD2A894688F99B8BB68458CEFFEF0870B0929DB18217FFB15F9F1659AE46CAB317154DE455112443B3FD6B62F4081BB4F9755E6EDB119B1E42ADCF1584F49A19DD6DEED1F9B11D882698E7E7ADB221004DD543962F9AF5C4F384D3D25E5D459D011EBAC468DA41E991EED49471E187AED5AF7AC7D09489E034C2FB41D18818284184A9545C59B25CF0C3BCFCC5A7BFDED3DFED4F445C202519F1400AA4B2D17E25CFE74975C857158846F26D53D2D5B033F0FFC35E024C17AE9A6DB10656B676B1892B79A6B0C29EAE359E17783D5AC123A388362618DB157F67E43CBC9CFD35BEFF36CB1BC9BFFD678113101F4E354B94310B0D0BE80C046DA1C981E435BE2F00CFCBA720B19640B10261343579B3AC5B307260CC5D33D61C230BDAAD7EE64C4DE8A5C5A8FEBFAEE9392BAA1CA10391FEBC934AC963040E400E5B5FA390CD9E94689E45FA637F1786AD3CD8AABCE8C227F2CBDBB0F8BE9FC9749358AF974F170BD5C78E2F7D9CDE4939ABB92B0C0F207888042A6B43E00F40B0F792821C262C23064958539EB2F9CB09E2845584CA78B1E8E4FF4F2A00EE487A435250204A9F7A17175BB08F2566CB16108DC384318CA49573CD74FB590EE09DC3897CE7A3812813792CFEC76713FAD0F291B42A72052113C84834AF8A47E9CC506B099390C9999DFD3D1B681CDCC3AEAE7489B6176737F3DBD01460812A68E0A499854DB014242DD0EB48E28F603665F3ADC105693778A1D6135B9A88E6E7771C8C57E399AFBE936473392FBC97C72335D4EE7F571084E835915B041A8DC2A102EF25EB1E99062CB68E664C08DD363463164B9F37964201E3D971BC4FB6F9F1EF3EDA6BBA7DF3A4DC925932E97935B8398454375AAED027545B551A01938C916D1CCDF796D0ECDEC7E5BDB42757CDA1E28747C2711BDBE95D3C47E3ACF4A187373989C8F20A6A44F1D312A2702DE00545A57A22710F480A46C1A3D86009E4227B7AEE6B9EADB99D1B9F77C3AB99ADD7EF2D8EFF96F480EDD817144842AEC000DAA3A3F063705873E2A051A268AA8A19EFEEE938D49EDF5D2AD36C07D678516E673835F71B68774C2CBCDF6147C43D79ACD002A3708F352F36A440A12C7E5C4EB43E811407CD3C30C0FE8E001CFCB09C9B03D19986E1C27E974CE4AF7F7D7B3CBDA747EFDE0DDDC2C276AE724B92EE88CD454233A89420D00A475E8E7405E43EA516296D4DFEDFA53946622FAF661049A3AF4F8B82FD467A35C15A228C582EB4809400C312915DB74444BEAE1619671BB2D7C17FC493D170E7A31023DDD4C7E9E628849A8075112AF42644A22D61390916260A8D56B52F8F5A020C51C603A503FDED676632C12329D6FED4A58E23152CEC9CE31683423538CC5D1756A42615D3E448BB8FC3CBBBE620AEAF5FE1C9E2D96BA734C03A638D3F6102389EC862E2A9E2DF0EAEC9F5A55BF06853A776725620A313464CCA04D3A3A119386E9D4E5268AD79775CF4E26EDD70F61977777D7962F78B008208A6F60892730BAD133797A439D24D431DA0447EE41CED49944F7EC5C289A6FD4EA0FFD659D168A46BB03716B7D0F35CCBA35FA51A81B9EBB9391343C5198EE2C5977CE818CBB21ABA6FF540B1D3A200B063C341DCB7D04C8581EFDE054AC9CBB9310B17296B0BD39A947B77220ADD06B97130B92EEC25359344AB6D036682455618023532D3C3D6740C0F034E20D07DF0445CF9637BD289AC18F4BD1BC410A45F3019E8EA25BD3735E14DD9AC66F8EA25B6E1F57D3E564C624A6ADFF149A543F15989A7E25082BED4FD9AE928C455FABA19C3A71F382A10F74EA2A2A159B260FD3B926B157AD239E4C54E646C53AEDFAA25C354669ED1513505F75CF74AC4A098DA46A837257E02E5092A13798D5767A3F6E580157FD199DF6B43E1B725532C50D6708167B06D0E9E2352FC2ED80CE1BEA09C210C41E3467A08EE993EAC3514FD499B043D5918BA305D56941255CC3898E6B1473B0C302C520046A989BD3D2AC610E319D7BB83C31218B0206139DA275A81ADA8592A4897820E286515004026A27EC895DDE6B0E5481C5ECCA643C87817AA801363A40D524E45D8D5A40771217664ACE4C03684F9D8DFC9F9FD8567E08A3D5F983C7D432D0AD124E4DBA13F2EB2B5353CAEDDE19C890FAAA711A3034A1CF5049A551E37439E8D229CC2B1D224273B8CE3420B86A2F76DA9D733D718E6546812680C843DD334F68A21C75EA74A4895717B0084622D833541AA833742614DD4B753853E23E0CA4B945A18A97AD3B007BB956A726201A565234DA91CAA9442BF76CEC2B19CC32F5EED3C89EA678CF252DD4D9F9999E97E7126AEE30A4339083692FF7A553BB96B60622466947508A180C9C48C85A5BA3AA0DF0C5AC36BEBC7B3A548CFB7444A89824371D1A970C5B3FF93FEAB0461A984108516A047E1BD2EDFCE0A4A81AFAE96851354FDF223156693F5A9483201301444F8A604E16243D8A0D69C9717842548C9BB0EA6ED2B59867C8559746E78B871091D5F43E7CA88907C7B920D0A1B824D8164C9DE088C6E099BAF93829EBD44DDEB7C841855768E8F778101C8D60CDD7D9DAB6CEE9659D6E324E47ADBA69C3F4EADEE77372461A10FE0D870EE8DCD4F9B37AC08199B8D35174AF571CE7C679AD5E7220E107111DBE81971CC4E939174AB67FCEF1CD10B5EE3107127E5CA23E9FC71CC4E93943A226BEE8380BA206067339B9BEF46EA6CBCF7757E4F7A47844EA4B31150EABA71F840E9DFC41297DF2505755D5C3A13DB1792F699678811F07DE362C36A9839D613BCF03F67DAC9840F8DD01572705991A444057F4EB845B413F5318A2711883A817F19E3A1AD1CDDDD5F4DA1CB7AA5D0B24485E8114B9AA8371FCD055D08050EB95AE43078E06E0F0FBB73F862CB037546BE9A55D093CC38957091D7CA3130B341AD4C1E4E492001A7BEFD6478D3C2CF9E5A996590D32404C6BD94FCDECD937789461D5B8310B3E50C461D53CB9EAD208A4F8B098CEBDCBF9E2A377F9B058D6EF43ABBF9594A884800811AA4CF1D153370619F679B70773CA337605A5B366F9637F0A342E41EFAE8C407957A11F8759BE8976D528EE6EA67375FC03A832446F4DBD912CF460C720DADC170EC42675F3832186061EBEC14193A66E3E5C74645CC27CC8C36C1204619EDFF83B1475762168246A30C8A85B01E84DE8F9E054078FFB54A407CFCF37427F877DE38187A78A3AB450101DAA38928E04F58D40646875FE5B11236A025007639917E936CCFA9FD3A8E972D2A551C912C71415F529A4686088AA164EC50E0D233E15ED59F3C273A03A70E798E30EE9C146D3544E1D8C08D7A9D13568DCEA7C435A74D37724735401908C3906F6A86CE354FCD134E8135A72EC99E4995060E7C9FEE719E3FDF3DF5A5BEA7AF651ED638C8005534D01602369DD981E9F282D1A613231E4B589F22A443C9C67119FD30A3F61985ED56B77264148F82500488BCA2B1314B8292409F9D107B259806E313B6D900025A6B9C1D0CA3E2888A31B1FD21CBAEADEA9F837FA7608056DCBC34D7903516D9FEE06893437A766C97D6E946AA6FCB9EEDDE9725A42C37AB85CFCB6584E6F2CE4900EE8B72086743B7C8AE09EF8793C35B98373F50D0820E2436D6D305AA8329CF35CFBFE7D201A067B075D60A5DB5D9A0C2B3BEB660AA98B2591932CE9EA39C1F4E338576743A0D4585348F8F325E3B38D51459CD95392BD83E854B503B2B67B63199197930FD7D3CA17959E790F8B406958AE6029CA22BAC53349BB479D210CF194B98B8B10EA4C627AC6CD8527E3EDC280EE6E8D063E2504955E0761DDEADE9D480C314ED7C988579E9B6F895A1BDF0A14A76D553F373A6D770D2052B58B8F7B0A0566E924E4094C09A61F772F49989D9E341B53F8E4E18A893E9582AAB6201B21071104144DE9AE96BBC3199C18F5937112BAD44F5AEF2E9D8A4CB1E7BDF91AEF947CF43CAEEC8CD37562C2FD56CF7B9CD55705706EB47A7ABBAE69A64E42A6D626DCB3A1528A97AD016E9063FF0C7D6D91D3701A82ECE96B7B46C73D341475EE2513208D380DB7BEC6C6CE9A402FCE8E422F2824BA4DD7D16314AEBDB3A0D5ABE9E47A3A5F7C66DBAC454E5AC2014194F4D9D4263BE4C20DA9687378C9C29E98B52319998CB5CBF7ADF1589CC3AE12E2ECC4D4F3F0F535CED76938AFB59BEFA929B63A2E78F7D5EF6D0E35C01736C0D3681DF36C909178A5BB970B5207C6A3176922314D5F66A15F84EB0FAF27556B8E5DC7BCCF92EB6229C7F42E0BC07CB23759EA516296D5CD7B7DCD84F4EEC4182E7D55AFAFC3E730E6CB8725303D18E8CAD78518CB8B4FDFCF53512E6EFA30F4236052240FC57BF2A1E6CBA263A7639BFB006593E57272F9B9F62B17BE7D9C5D4F17CBF974A28E4F4AC202B25A190195F392BAA0898D2E8F7A20F66C3367289EB98F79E817851F6C1CBD3EB09A5ED7BD1D27526F3B81C121CC56EB9B2E48AF0154119F57842206EA35356A4C5C315C545EE47C10E8C4598A15E4ACB9EA9A73D29D3298E295C1140C22CC0EDA3D6B230BFC2C8BFCA79017865FD9CAD7AFD9FD24498B0ACFDFD8B9751967D589C81D154BD9839B235F8485E218FDE14D5D4327C04824DB45290A121242B182015F2DAC4B58EACF08586FC2389702C1BE0C83A5DEBF3096BACC342F2D0D539E9356A1A9377A4F48B987FAFA86D624CF6709BF5403D1FF967F1FD0E1AE3B9C011DFC5446A662B09A01B7E09A2063156EF2B1E8A0656ABD88C78DF8FAEE937A9C55A17169C18EB0CF18506F76737F3DAD26A7FDDC0D42A7A88A68A3A115631B7055441B771FD8DEFBA5CE13339F2E1EAE796E3CB009B026B1857D3A5223FE7D3D1A7644C7713D86164CDB751D00A6BD06889DD1939BE9723A570D465197D6CA259B89E5E456B9D47055431BCD24B053E56A76FBC963BF416EA4AC6968E118F856C2782C31318FFBFBEBD965450AE061DF141B51D551C92514F567032C10395C4204D4314FCF51F28566E8588838A2C06C5AE0E10AD644B6D04E51AC44DEAE849AD73A93B76242EB42D2FA88096C0C4B2556B76DABCA2B826FABAA8E6A0B7817A56806A8496DA15A3888CF286B229840BA2EE3D05B942B052B68959BC4D28E439B8CADED0166E27F9568C9F590E3C39888DB2D65F6A7A8489C5AC49C22714EF4F826745CB5A469C078A884666B87D4BD1AE676A882C7A9D06CA41A668C70CE4C08335C93CE283AA96030ACA203603AE078D47EE894DCA73F3075978D0982C66B8B925F11AC374AD54C87CF31343170E61CC3161A90B41FBEC868DAAF4548BB06A618A00E5A75EBBE1650EB5D4245CCFAB49D78E0A569D7C04B66DE743EBF9BAB343CB81E017BB5B36F3FCE4CD85BF590E20C6062574A35405D5A2B2A8B0C54CB482DF5EB60B5FD40AA81A7BF4B956A06D4A1596334FD55D644E849EA1E774A29FABB4969476253106DBB108167FACB54ADF91D0AD1788C8394ABE171B7AC423ADC78E3510BE8A884EA71B7AA9174EC85F7CB6CFAEB143A97551551F899BA7F3F67B2F85E39BFB9D12CA6B236D16A53A586361B6DEA6A08DC8BCBCFD31B067369241EB026A9059DD946AA85B670B02362FA09663D502592EC681419A9B2284E0EC54AB9BA7DD32DA62872DE3EC89549A16BEA99A4D755ECED33584FEA2BD8C7280EF3220BFD2D24D36AAB23DABA0D5F8EE67005FE6E151C4EF30584AA2202FFB20AE5D1A8A30AEC72350BDCFB2B176413C7DA14E959C74C54156D8D339F675CBC9A510C344710DB367FBE63CC6AF14069F30862DBE6F56CFAE13393B3298D3630A8565BAEE715BCDA5804D444B5C0F6840173AB060AE33EA39D1E69B79280B775FD0D5CD8D6F99ADEB42A89D7B64046A7AEDF50A7E2D143E3389CCEEDB074AFAFC47370BA10F0C8DE79DDF161C75EFBDFB05FB972F0AD2A865E373595C3870E3D2DA2E1C62FAA2C868B6B79766808D44326E18166D67014F5680C9A7DD2FD3E7D59C02087E225BEBC181830F5AC20A0A189C7DCF293DB51CC797BF8BD27593405D4361D7956C17AEAE141D5A1796B7B2668660B44074C8FC609C1862D8037EF9EE2C61C620B1404BA9D4AC003B305940F418F4681B5C03916F45E16B947C7D11957440D8B9E17250AC43A901640DD1062EE554E2376B30F79BC50578184433F491454AA55C138F1F46B78F455023D63D46385978986443F5D245CAA85C27874F56C59B152283F2FCBA5823C8B3C937B9362C56C7019A6CF02A572FD304E546E7AA0584782C798F3D5049DBBC8EB0861B19E3F00D9686B07B5AD5A358C5F9C634669B1F92C5059B22E8BADE794759EE1C6530F125E2D657DFD9428C702CFBB5EB3D122244CA4F3BD20F8879AE8BD5B1D4B531D28EBF953E103A60FEBFFDA4791AEFBAC53A1AB1A186D975774A236578860727261AA69BD57A8FCF5748397D33B28FADC49EDD067F09D2C0C102257C614C187A5F68B062C5440358DA548AE0D5AA03AFED53ACB13800F981C955F377D560E8DB4D74D9E14A0967A0C7265684A14433061D2518A8BCDC2FDD40D93215651F75FA8094D03E417AFC531CA0468F647A7DCD06DCD8EC08D7BAC2D70B8ADBBFC3CBBBE3AFAEBEF3D37C0EDA083D012B40650B14D14EE0D14C40A6335E68D027D3E9B0705F4CB1A34AC7A2AB028A0D956BF85B06BE204173342DFC49722C6291700D093D0857337B9025E0D256B1EC4F49A46E0C5917616E5FAA8C14A606EE650460B4CA1F95195C319141F0211265300B598802E8621A65868C138DB867751C34C7CF52ACA6EE23968BF696118069E78DE0265E2A14762B6132F67919A6DFDA75073DC29214C93A00254CFAEF1E51AA515E50C9B5FAFD9292A8DBB63CBB519D656A0AA7A45038050E92DCA777428A4434BF0DD76553A3F500B3B1495EE6F3B352A1380F008D1F1C428378469AE50190635C33565187430A3A69C8074BE6031DDF07B4E55DF2EA089A7A250CF0F1113B418B8F7A9BD5A1D757D947438BBD2280A8AFAF44384830D7D50556D409666DC5363DB393DF88F018F7A55D3AA06318D5A09A99E5CF8E53209B79252B56F981D10697704082AED001048A8331C049DD208B43B59FAC91C6E1A51A71F1A963C7CD419E8629E4F7C122A3BD1D278F0FCB60545E7882DED6960DEDBD6D354930D461DE967C145D9BCF40038332BCAE66561BE3D9DCDABD50BC9575D3B87626DD44045177727B3272576866E55F52FC27ACD9B1C71433B715275D420452837532761852F5DF401457A4DDE212EE7B1E3DAB9136BA3062900E967CEFC0C4683593B7BCE890E8E9C62A23D100A4B2C10B0334A0491C3538A0A1AD36B7E852B32CCB52008821A3C04E9665A41CCA3DE0CB6B707E652455B1FB72B31972AF4A93CD9A58AB20FE64B152CA8C504982F55FA4EF1C92F55303D535CAA6041FB4D8BE252C5E1C49FF252A583BE15AD8B72394BC061D276F0A8D45A960A0742D922343F125FAABC75506BA1A869700442CD2BCEA7E8747354BF7BD7B856752A6886D1AE074EC43E449D6E2A3A3806F5AF3A48C6AA6177CA35A4DFAA06EEAA3AB09E6EF3B4310C3AE4D6659F64BDD2B9DF4AB5D58351033971CB950D6966839983890353DAAA823EA82BAB47A88481660D134711897DB800094D5045AF15C2519E2DB09E7A285075688E3A111F355303E28366A51983CBA911D34B68E74797F64B352845CEAF7E33A548D0D526517DDA0C8B7823FBF987B38543D147B400EA616AE1C0C8242ACA20A0856610132CB5CF3C1A294F5515334823D551676D7C8A03174AEBE0638020F267ADBB8F9B23603CE79FA62533DD29EB62040433E591658E13D01E18E9457C7A043C124280A9478C801E2E8C8DD0CE182FAFBA77DD5C08878762F28D504262DD1854084C9E12E68B00643BEAA838FA14448E081BA38CE0008944875151DC90F789F416B02F82FF2272AEBB50C4E17780879BE56E3323B86E8AF7BA2AAF56B09E7A705075D7A1DB54DEAD4DC89281E688E0E28305C58F9AE0E0D36772CFC2BDA749D3477FF0868635489C08144AF116CC3068D7C4091EBC097DD3C71F5457460F5E1F6BD06E42478E2BD86ABD6394D0CE57BB266A602D003733D546084C93C6BED26F8E54C940B4D3A500420D14867533890ADC5A3D409B03C5D1D422762C5AC152C2B89EC2D154A856EB46A95259173538A304499FAFD1A5C576DB482BA609043750A425D3620A4F6BCC34F4047CBB6384B11E38F83AC7CD9C824F70869CD456ECF6F60814D309D7368C1604524EA13A371516B36A06E144D6FD88D168E35457C6D188D1CA69417727B8D4E1C4CBB12AC3C757859AFB81431D55C878FDEDC2117A68DA38B664B87101AA21BA6FB869414FC3D846EE0AD975F81CC63C1903627E0C101A6B911610344875210CE1B1F4E847D94A7B9FA05622394FF8D64E5E07D01E0981869A2878407A9511E8C997D4A0C6B1D89CE3CFCA3F53CCDA24F8912B5C334D50EAF930032B1C324DE9A5A8AD18FDE209F3FBD3DB1ACB659A147E9484D9B1ECA7B78B60136EFDFD879FDEB22A41B82B4A3FBE49D7619C1F0AD846DB45C953DE40EEBFBC59ECFC8013D2FF58FCF0E6EB364EF2BFFFB0298ADDDFDEBECD2BD4F91FB65190A579FA58FC2148B76FFD75FAF6FDBB777F7D7B71F1765BE3781B74D8CF4F426F8F2D1569E63F8542296B9AF5F46394E5C5955FF82B3F676B73B9DE4AD51E927598057E96450C09FF1E7E2DBA94F0D371B20F4D82BC16E2951C8E971D00F9EFBDBFCAE45A64BD227C339B1FD90079CAAC6AACA19AA3CA18188E45E0C77E769FA5BB302B5E157D9FADD9ECA471B94DD4E522E5AAB1F37FBBF8EA2F32869FDE0A4314E7F0AD348902798B8B835A3AE321A75F383D3862DD4C085413DB8113D74C2AC42F58C90536BF2CD22EC6D6673CAEC6362776B05B82C7189479916EC11E0A45049C59FE08E16B3EE37185879476D11A402997E2310BDBD0B04BE1593DD116533867EA37160484D84E30D8184B3F0C69867E11AEBD35FB57EC62BB848EB1ACD44208635D82C7B84DD7D16304765228B2C029775328C2E3CCA322F412E9386A7D26E2E2F930B90026613B1458E17BAF44F89E8EB15C95D90A42B82F20E2DBA57911A46B68069B22F2A825B2697F27620BD2322978425409DFB1048F71974569C6184B175BF3158F6995F949B0013843A780B08B73EF5FE9AA1A17C06DC442BB39043003C578DC9B345E7B59B84BB3C26318A2D8DBF991708AA9EA105B8992E7340A42C6765E73A0816E31617698BA5205DBCAFDED8EFDEF4B24EE7EA8021E7FC18D1BF2ACB73E53452F58ECA2895C97F5B9F0E1950B952242A9108FF76319C793F53A63624B1767A7E0AC84983A41A88D24034222C51905AC5EA661EBA2146C9A32FC6A71A02EAEFA0B819B3200855C2C149D4674F783227A164EA2C3B7F3A24245C00604154290582A8461B52BA3606862199143CA325CEBF3D9AC94F6A6CE6053508262EC091AE031747E0E241EEB876F342CF23A375F296C27CF5FD622BFA9BFE1B14449C19B8EC3EDAE8BAA5340B0136CAB84EE1DE3C016C8F1AE1DD9264DC29A9BCB42B95448C59B94DB95A87B754BF0181FFDAFAA7E0A45349C501FDBDF290AE72A8A25EDB5FE4610102B3DED42100A0F1FA978444DD0420984F43FB2EA076B7D560A1FA0EB51D53C50C3B351EE52A6CD4469028923DD223CCED84F9E4AFF093AF38422C291C7384B98F94599854C2512350EB99462B0CA98D815408A9E5084C7F912464F9B02E868A78030A361F2546C007C9D029A180B606B7DC6E37AE608A045E91450CC0D4CE381975928229E5B0CBA10D964A78030E6287C1130ED3FD17084320E1217A009EBCA3384DF097A71FA1425C221D22EA0ECFF0314600C950ABF9B81D1381D9A81B35DE1ED3246FE5D7CADCF785CD3673F9E74F1EC3FD1707C90717CA0E2B894715C5271FC53C6F14F0A8EC5CDA28BA1FA8087672B901661C0C84F647FC7CF144161BBF3134950D87F246CEA6ACB6EAB30FBA2622396517A17A759E5FF006AC8522941C80A93B5C7A46041CE3A7E2562023495F67722B68D9FAD8374271AE8BB458463E0C57FE537055901B01DA9908897774A81B52922E02C0A3FD808C8F6DF48771249C194A55D14E6E22669979CF6DEB2CC62C89E70FC4AA09A541866F5817224AF52261FA7E07D865448389AD8D478C18649F5A1579913D24CE00D700D8AE8C6D86FB4DE8B0C9586238A7040055BFCF53E2922D1E4A2AE45148B0E53B09F124036926A108D3C1C94292DD9EB4E3E408072C20DC8A2763995E8A75340D8713E5BAE4ACCF282DCF303606D1555E806ABB4D880A27F534456BDC1F3CAEE4E705DBD0785CE986E09C5E4B1DDFAAC27D0B1D52DA2E37CCAD27207E3DC1791A4136EBE95A493FA23A56FF98E9D4622C1B73ED36EA91988E7AFB7A2422414E171CEF2E9C1E969BA16D55AA99064B0F3E22808935CB6DA3505347CEBF0995F0B8B429E504430DD647EF0C52BD3AD60B3693E531CCBBC4DE8C7852040B43E135CC9167F7AF7CEBB5F2CE6DEE4617927389289855678A737F7B76AC4FB520AC72CA465397CA36181CFEA6E096955CAB6D3B0B43842291EF3FDC10699B03FBD7F94A928878215CEE6F68B1AD5C0707749C186B9CFA4E153F236818A68FE0FE1EFDC98E789485A9F09468DD05FB3010B268DC34782F936CD128F7D60ECB390C8592A248C950991C0E54FEB3381ABA6692CCDDAF123E164622744C65F04089D6A7FC763839C63D43E3127DA95E68C2DFA7D688047EC3C2306C36E017DAA9B827370D4AE4C4C198C572C2363CD1310614E92C9B8E5C28B12A6CCC5B128388A650449745B7AFC48AE6105715428239DB03AC4403141E6F3BF7A59B82AA35894F8DA05149D2BDF7951110AF25EEB331517D7D4188F84F01D8B88382571B4F97ACAEB03F7571C435C1E0C71C9B1DFC25E228978DD121AC6CA7FBACC6584C702223EC6657F9765F04E097DCCEB300F4402EA165176F317C894DEFA4C5AE710B260B6BF53A4B38A95B0751405B4E63B1D5B90E68557FD14C91BAE61DB42F8C88E70EF9189C66516EA1A122A5AB6E73F32C686684EA867D9DA2E4B57FE2A8A997CC270054C5AD1340955B66C771B2569C63DDDFD28E3789FA39CE9729AB6550096ED97C9C1577D8D6A5E51DFB275562128635F32D32A2B91DC7A24671E921413C9CF5B68FAC9B3CF94FD55CC1F4A88CE824211F574F4F8060BFC5CB41A8A85540BD53B8FAB769091EA5042C578F14E8DB32923637DAFC1FA9E8E95098F71B1D6C996623161C5365FEE4403F4E11B094B93B47AC9072A69F98A2AA436E6E12EF60351FA687D27620344EAF67712B68F51E22741E4C7CAE10335482DFCEA67999F88CFBC3A05BDF9DC058AD1919C441538DEA35A22B9916635199878B7A212DD25137E23221692D678C27DC3587F3EC21C14AA40B97DE4CF573CA589022AA7C9CA69C211D45E9985C7D4BE125015C04A541EBB2AD74F61E1C555A46599CD768A0963D896427FF907CA1C484B96D2D6A8F6D1F1CA202F57B0602F16136486D79C69F7DEF5F24A6D0081AB9C8D65D01816D760A03F901F14791B6390D7C30F63803F362A3D6A6C1710AEBFAA23580ECC70F83A943159DF1FD9C0DDFE4EC256FAF1B5C417DADFF1D89651213EB7D87F3A9B2D81CC396188EB834082D81F3834AAC9DE447975CF25BDB66E7DA7B95EA789EA6D9F5C4AB925E207976C5A6B7FFF96CE1C573E1ECEEF3E2A5F1DC5A33FA9F0D4371FC3DDD41C61F91D82026D5D648393E98E2A9C551175BD807DD1FA4EF4C6D318B2A1725BEC0A1A535622CB5C1C4CE26B62D9D91C29C650E6FAC3E4E82C65296519E08791B28E8D8A683A05DFA5AC1A6A1166911FDFF0675973C8A7032AFF2EC399371CDDE748995810B3D1D4B0E39F72794532E2DD53F395E0D5CF840D11CFE11BC5E7370FB2685748170E9D020ABE2C7A66C7C86326DE6C774B08B6826DE183CBD029A0DC4C665F42487EEB1410F085BEE29D68B7048F31DD799B2CE7CE5D3C285217A75846C2BA8EF8E591B8309D0212BE4C7E3BD07C25EC09C59321BBD742F043219B37427B5F96AA1BA007CDBE84B4FB2BCFE5E035884395D2A6AC44D8856C3DFD84E180BB0F149367854D283827D577BB9E4A28A54282F6531B5E2555A2FD9D8CEDD01F1065534894CFF79EA12AE1BF5B8CC7CDFD5484DBD7FD273C8EBD851420A16E09E5EED45D8CA8380D7CF9E06ABE12EE0CCA2CD8F879E8D5EC55B830100BEDF072FA5023AE4B2D30CB54231459E0948D2D4211451ED865520F8F1F4978B661B149450ED17C26484E81ECFC7CF8764A1FB9FFDC300095440D3AC9754B28B7A44FB283D7134D360EB32CCD003FF9E6331ED7631C824267FB3B8182779567B01FF0E0FF0221778BF038AF3E2C3C583BE996503C9BBD2809E252F666EA96902445460790CCD42E20AC4A1559841186F2D93A5C8344874ADCF658D9EF2805EFE5DB05B45E865F771168D8940A09B7D865B64AB96D110AA42A94512CDB4991A5B197BF42A420971230FB319333FDCCABE751402C1652E6970B895C8AE35101E43E43E51449CFAB06ED0785F7C8DD25BC9A0580829BB1729F76F3BDD252197B21891E09E2B20FA8395000F5EA87527B34D5A57A89287CADA5422A5E7EC629F1B60A09FB2BF7EA031D8C93DD2E229C32B55720A4E6764A1CAC25869CADB460198F5AF332D575D02A629CED9A2E3815A2C94E5502EFF513EE860871DD4E09C58AC37AB6E68106CA74EB45F9E7B41475464515FB36AE40D383BA967D4B3FFF8A18CFB1927D3B97FBE354DF5053CBBEA58F65187F28454F65752D9A2D8CE1F1C017BF52210D2FF776D6E2962A5858DD940DC0352C5AD00E435DABDF586423B7BA16BEA52F2F95ED5D391AA89C8C5D3B5FAA3A048D8751B9B76264AE6E4451C5A60DED6034D5A8127B98A99B816BF46B41A62F752DB295D9D3721565257A3B662EA0AF496FD1B48374F5E8AD2168DD5095DE26821EB535F12DD6916618240FD70A48375039C139A18A0FD3B8C8A842D3883528CE158137F9E5D3D5070F9037A4421BBCB0CC0495DB606722D0DDC35C0CB12917DBE0862516A8DC06FBE59EF254D89B7292645F4BE91CCD42BC75934B2D31C337708A2AB6BDBF7990DD05E11A3D476168A65B0DDF56FD1ED48BA3E48B177E95AE9D80623BDCD1B64A0D255B0C9595CEC61569EFC27D7DF7C9D6891C0045F822E9805553BE77E2567A779F8F0BEFBE43DC7508EC695D40C727877D6D1710CCE659BA8AC36D9EC6CF4050E37611B58FF28D69FB3B1EDBCBFE916310FB9120610A45D44B13E8BE84E63695948FDEDE5F5EC02696510CE3D196895D79E8F95B310678B788308769F625CDD8F925DE63750ABE5FF4A2715A5CF49E2CA496856F2903B28A9D45F0277D02EF7E9F2C6E7ED9715A5FC57651B53E937031961782375262D9391C2F4CAA484A31C2E8F1238595398C4DC380A410A5FB6F8491D54F50256FB5F6F7EF0C0B8DD3A1674AFDBE3AF9C29305B55EB2C81B19AC846F675506DCF9F8255A8B4165BB25048CDC5D2B5CB32E159B28F89248993DC10A847DBEF2566951A45B157EB002093F0FF6A2C12E1653AC3545C10D74BAE951D521D0A36986C00A24FC6CF7651AEC62B11D3DCAD64EB9B4175D020DA82A1134EE52C0597DA0DC223DD5CF03ABDC56E2DD51B78CA082F0381C39B4CFBB25648C50378522324E0561C9A51465248B76E0F8BB25648CE032758BC83815E3974B097723DCDD4FE1F82F969168DD7BACB2DC0B04BFFF4A5216B3C2DB54F9E12495B15542E0E33C9B0C80AFFD9D22B3F243F6A91465AEF677A2345D943B6F239BA0C5B2735272BCD9CDFDF5B432BBCF6E17F7D3CAAA64A3F8A010E1B421242A8D08BC0F9B056923622149B43E80CAA2A65448130CDDA8745BFE7E14BE2B128AF038D3E730638A83073C02118A2817EDECB71726CF519626722805A09866B3F1E4ACE6ADCF14952CD84489A8541C3E122C7BBD93AC730793487EA1D2FA4C7120F7C5FBF3EA0B81114BB18B4362C862E9BA8278316193D9FA844CB609C3D493C9621021992C0ED5D84C96B3BD26E819CC16C5720A83ACDED1CA2CA75330E656CAA0108D99457C46473169863AE41A2BA09E72D4D568ABE2454F09A3F9B5BC3A4D897B7675421673F761319DFF32A92E05E7D3C5C3F57261C5611078900C068549BD2FF2322EA05719DD122BCA76CAB1D2157F665D3D1485BA0B14E3717BC1260CBE88547CFC78B60438BB997CA2C7C14161B1203E051EBD6208F1269B3CEFEE09B94551DE6E936A08EE507CAE74D29B4339604D049E34E44E6F012BB1DA1249CC637268FBDBAE427358C0276B3F331B470F1E8547D7C3DE715AAE35D461B9F333BF364570EBA4600C16CAAC7A0B3044B9F4BC88B359F2FBC97C72335D4EE7768C1185094B92385CE3AE7303293B868965E7BAC697ECC8594E6E2DA5730C22FA0A6B50690C52DCA514146CC4B233610F00D1744B482F859886FEEA553E60D2F3A076D1D9906173C6CCA793ABD9ED278FFDB6887C8CC48320423426B34DE1F04C2654E4B1D6D73C2BEB88741BD52EF9B7B1585C3F783737CB0999FA1470086A53422A6D85CEA3059E6B1E33C525B2D5FD71E55AFCA4F205944B099877D063FFE62BC51F639CD879CA3828963150BE7BE3B9F3C60B724FB9C1C5B2B3E19A93FBFBEBD96565B6A03B27B7806D9E9BE8A087DFB2BC776B090D31C1C16E07BC27397C24910E3CB04EC1D910CDCDE467BA9903024250090C36CA89E8C47B9A43C834D27C256808AB5C92E50EDFBE737C344EC71C1F26B86E0901A32FDEB7FAA4BB56299120318BE0319F91E097D3FE8EC7F6C01FEA064C428B7C3114B35084C7B97C1573BDD65FF018E6E2E3B539EDC9DAE7D775E69771246CE9D6673CAE0FE95A88A15D7F391B56BF9C4F2E7FAE1C3B26F3A537FDA7F4AEC8C8F78D1810870002875213D90704AB5345875F211D425587E42B31403E1B97A75991A63164596B7FA778E02B72FF5966FDEBAE00CFCE5A2586F4EAF8B9C62553009CCD2EBA7E3810AF8D7942018AB3502881C725E523A402A1052E10134969DFB2635A0EA1DBFA4C162F32009F5084C72905FBA606F8CED22771C20FDFF058AEC34731BC7AF585648257BDB8148AE8386174246ADA44F13ADDC9A4D9FA4EA083322EA29D98ECA6F94A70398BBE866B7F9B96A20B5EA7C0C620ECF2416D908AE258FD85E09E99A5E54E526C9AAF24E35818707D433E9684220B9C721005A188CCBF145642B9948839794DD81F00D24301814396DB5DE0EFFC2012735E774B2822CD57AF4E342DBACBB60B084E29519CFB9C7A797062EE7B22E83F5039097BB07952A3EE16D22E7DBCA8080545A4F5998A0BECA15044C429BD7B6CBE7E3737A0713A3437ACD297787F170CDC12CBA536E2B797A52F2A49BB2EB3C21A14DC20C24851BA835756B26E272F57C6668E75C85CBB7A9A0472EC7D0981BB02AB9893D76E73B03B1CFCDBBDFC75BB2BD2AD283C6AEA914C5E87E18256AF6E21419E4BF3EAD5112C258A85040B7D1CA72FDEBADCB181CB919AC442C2DA153E8FCFBBF674EA92B212C1D7D73A40F409D3C373230DFBA7F6C3B8066F78CC79E27178104A301A936A0DFA6535BDAF7492CB9A0244545221C154CBF513055AB1ECECA8637977776DE92E6B4641A0091D9261C841B5623624B04CD3584474F846C04248CEAA9C13EE127CE517C29BD4D667C20CD5629C9C27B75340ECDB5292085A9FCF667BD4766E4E9496667608146D5F8781750665853DD9CA38EDC95A6BEB3311976C856B7D3EB3E53EF0A25FEFE6B7DEF5EC66B6F42E277DEF59F4C8C8572E267404BB7E1C6D231E60DA7C1103563FF59D4CDD45E56D8A544A10E42326993FC6B5BFE77D1A89763FA89C843D8FD9970B09E9E133B1A74598F12C6E32BE7611BD7FEFE1FEBDB7ED9F8CAF5D4450E80DAB039593B043ABB3B5599DAD7A75B6B6ABB38557676BB33A5BF5EA6C6D57C75FFFABCC0B8F47E61254BC760141BDE3A31294B9FAD3F91F1EB3E58DBBC30340D6E7F000D1910F8FA880021D22AAFFFB1E1EFB548D6CDF6CBC24144C7852211EEF0B0FD257435EBCE3C9058350E47C8A2A566DBC37B7F1BE6F1B7F34B7F1C7BE6DFCC9DCC69FFAB6F1A3B98D1FFBB6F167731B7FEEDBC6FF34B7F13FFBB6F117731B7FE9DBC65FCD6DFCB56F1B17EF309BB0772B98ADDE7BAF5F2036FB857EB79FF4E86DBD76BC9A2E27335B9DDD88077DE02230E96EFC0E2FCDC2C28F20D55E558776AF38C41BF0FAE42C9348AD54B60A89B60447360E30869E45F4BC4AB0D9EF09C9AD562A24783A3CFB90DDA4F599A080F1A8941E5BC8BCCC1EA558547229C9A7E95FB5D7051015532AA4F879149E16375881B2FAFC6693DFD700B8A5425ABFB5B8C10A243918C8A961934D43204DCEDAB5B45B57B0E2019B2867FC117AB5ABAC44706ABF5C5451D445C37BFBFBF99E54D55D073D5000128FCD49A5C2A434E75F0976FC2BCAEA7D7A10E1EB2F5667D89027651563652DDDA8B4BF53B18101FD8422C2B5CA718C57D510A56B31A0FC6CF6057FBA9DAECB38F416E5CAEAC9B8121AB1070CF0AA19DFC3E4E50A2039A910BF928B2A398B9890A8F98AC7B4EF04E4782C14117A77F320748C7F205C278AF09734789E4FCFAF8247F26C2752573A6504AFEA3A453988552C235F9D7E109C355B9F4F770DBB00327D2DC899BE6A08B953EDEFA45590A69E247D0D964E28C8F247C8F4D87C3ECD33A2F30D137170AB9469A35B42C7286EA7F67792FE978B91F80EDFF0588098E9E458E9FB2C409CCD3001852907A9E439ACA862B133BC3D37F38BC20F36B2FCA1AD4892CA38B3AC430F424905C10AD439E362C03429B7B3641D7E85664CA87036F20E534E7E5B2CA737DEF5EC23DDE5AA566CAEF9D309BAB0A30356CA96BD5CAC60FD4CA79DA9304D2AF955C4D47C25688D7998491AE3FE1BB53F32876B7F27612BFDF85A7A2CD3FE3E8C1BD9A90296092A49EE2DA2B54496E67865283488AD81458455C172930E96133752245A03EB2F67B3A0A231A1B75DC38141E3F4090F86934AC3AFFE364AC4370BCD573B2B8ACBB07752964A627A4A6EEE868DE0541BB80B49AD3657E6FE93174BAF70C5321BAC999CF94A2AB4ED2D288529AA58F7DDD048B70EBE9575F6EAFD8BFB70E5C0C44B85567881A9974BF1981F7924D32A7485DC61B1CC062BD05DA990B04B77595A256954120A5CC3A205359928AA50ACAA3B3F90CCA9F53782EBDA2AF37339E8F9F12B455F8DF2A214DF63375F09B76C6C03497795C78FC4D757FE2A0E7F0D7DE1D0108AF038CB40E6CF876F542C7260AEF6778AB5E6FC5FB90669F218655BB89742990D56A0A742191E6BECE745ED09BA037A2B97DA61967B2C9792EFCF812B966E09A1AF6900646F68BE12CE9D9AD18926FED667CACE61AC29598BDB66FF91E60924FBFD90E6A767C6B7FF4E57795484DE255B1AE16C108A2856BE38F47370930945163857AF0A8C2B9225B2255EC3D7FB60053CFEDF4B26E7029A47FB3BCDC321F09384A71491441BA9D00A2F20DCC8A5542BCDE7DABF00361EB50ACF4C999EF451A46160B412AD02578A172AE5D9B7539C8752C8F7DDC942BE9BF8937099AB2BAA5098C41E12E413DD323BACF2E545B78CE4C4C504BFAD97A7F1B398894C2C3BA9C8E45CAC3BB7502367C06ABCE5E4E7693F8603A320B21D1512C3A62EFC2FA18605B58BC90CC31963EB7446C17A9A424BBC22D7910A2DF10211B6E562326E399E57A7E0DBD4FD4E1EDE9207D9B0C843644280D8CA66146A15B67ACE55DD41AB02DBC055486EB4033C274B7CF1C57CFD85B619CE3EDF5E6B6997BFDDD3AFAF0DF034E2823118D67DA8507F35AC22A8EAA1C80AA71223C908EB24C015F7192C2AB77B49523C7CB61496603F26A9FCB4E2DD30713BDDC529E5811B45C3D2E11B49257010ABD675CCD46D94C863DB7FC363790AD9C9012789178AC83E5C40CCB1760161EB1F43B7A978155481D05F21149A324792A69E1523F3F24D9A155FC25735EB6D6A9CD391C7132A1E0E9DC5C307EBA30F83077704E2306976C17151611776B8C6A985AC220C8B8D9747FF5B0C28D4FA4E10D90447CB84E455F92240BF90A0D98916892E09876FDFAE09C3400D20199CD14E0742655C4EAE2FBD9BE9F2F3DD958B401E1A746813091EA1DE7163F80C0F96EDCBAA140AE06CC8E8E6EE6A7A4DCFE05681D964E582E134FBDBE1AB810A4ACACC75F848C403E4E66A3E13C8AB7A1D0CC569ED9610A4C6950A63B784A0EC7F8D43499C3D7EFC362D5EDFFA29D5F8AA319D29DA965B8809758AAD70478916F7A198A095E6F78B4B4119AD3F51DF1271094AC91A5A85245D46C570842202CE9E89D9EA56775914F067F871F8ACE187502DA2F7AF97853C33C1BACCE1ECD5CA4AF8766E785F6FA560E8ADCF84D711FBB7F3979251BE5B7236C72D577DE8A7ADA5EA45D3B35CBEA983AC8B74B32287908FD9E6EBF793078DD36DF24AB5A9C78A5A56710AA9F5ADCF445CECF313D441A990E009173EFA655C78D23B814EC1D9F09987C574EE5DCE171FBDCB87C5D29BFEE361764F663B182408368443A39AF8DA9E9EE7D11374AF2D97121C12614BBE95013F606761BA05F109451416E3EE29F7704F7B6A6143BEFA697FC763FB12863BEF252A365ED5A72E4AA9F0DF8FB9BAB9663A559206B6BDEF6EA673BA807380B4C9C8A0041D75AF3240E93A75FF8D8605B028B53E137131013D0C4505A45D40C557AECA6C05E1DB1710F1ED98742EBFCA108AC8639685BCD67722B6805FFD65E22550A7843AE64D9A8003AEBF13B16DD35524DEC6760A88F81EFDAF00B2EA2B11138F1D1703B8F6DF09571F92AE484D98D5D9D655AA30CDB6DF97132F0C1C264FFCAEAC3854562AEA4DB32DC49C8F05043560E541ACBEF5D98A43BF57B2685A347B925796B65F8C79C4DC96A43C41C40ABDF043E3976AD8B6A03AB3C40A96F83567985CC57A96E0334D28B7C4AE3EE3A41A04457C0FEAAFD759980BB7C75221C5E127DAFAD92B53E393A7528A632B9752AEB98334592B104B851493B7E707D50C7A3BFF1588A40894D31C703402AD544AD0ECFC559AC402591C3FDAC9510A995B28EE47C7AA36E06A04CAAB17C72BC24C7CF6271411E6387D4A0189BFF5997036458C554601E4EF271491A8EB25F7CA4C7127D22923F086328F12B6EFBDDAE94CE00D622161A705FCBEFD0BE03DDA2D2161E4521C93CC934A5C08035FBC695054B19E0D4FF239032BE0F1D7CF27190904B27FA35886C7CAFE7C640A861815B7F5198F6BB1495FAA942B6298C7D6770A1F678C5AD2639AAF444C801ED3FE4EC4B6F1B37590EEC4ACE8DD22C22AEC198F9CA6B05B82C7789926059319018CDD128A231C638ADEF46B10866BD1175B2CC3639D2CFEF4EE9D77B0FE789387E55D17355881B0F393E7340A42206D73B784C6EB65364FC17015FA7198E59B6827BE0EEE961056FB10E1158A3327151268BD5CDD67E13612D36AB5BF13DCB3CB389E407264A7E06CECA0CD62D02DA10DAC852D54073C1E4DDD4AE2CC2D5192B97B916285ED3F9DCD1A775F80DAB8581B31606EF8CD3874B602FE1612BECA954B695688B47E5F99453BE593F54E39D93DB716B7550F8E5AA5674331D5BDE70DCF243E79B89A2DBDCF337632FD46261B1C1A04ED601169AF1427E51ACC9D23159EC355A56CABA49A285D5E193F46612C70DCFD2782EA107285E372E327A2BDA25B42D8BC8F4C248310760ACE665355BE0557D3C9F574BEF86CEBE2A086C77A37E830A866BA5FAC629794B83E1EF490E9402C3C9BB59FDCDF5FCF2E27D5D9379DCFEFE6DEF5DD273205A0B020E8008947A96E08D440BC96E8CDD976FE5328DBA19AAF04FE9D65A918E8B5FE44501F98A2F985FB198BEA43EBFB59D261F5E0FBF6E3AC1F1D2AB110E950834735F3CF7E16F1E88AB215AA5B825FCB673F2E4174C7CF144EA590290DC2E4A91C62F6AF9F26CBE5E4F2B3F771763D5D2CE7D3093DCF321A13C663068FCB2084EF732EA89F4D762B10DEB094223FACBF90D504C76F3A870BCBE03263A430F9FADE02B54E238584D5A58C7C92B5BF93E640BE69B388A5D9641501AE69A4421BBC2A943463E53001E876691EC9CCB6F97AAE9CD6CA2083C041E7AE56615F46D8B9100E99C0D5B5CE66E5A7FFF01E6E0FE68BB98D3D450B8F32A41830682C1DFAACA360059243154F9DB7C7023A134BE554ECC073DAFDD7539FD503E6583B5EF76EFD846948476BA3A2FFBABA84F96EE001A73BB1D00A6FF8BBFCBE0528C6E3CEC25519C56BE9F170FB3BE994E3A9B8E0C41FAD120A8DF01129132A02C5042AF1FC2A1F124414DDA2F1A59AC067221AD4B1D6F77F4367D06FC1B1B6D96E9C7568F76353C176B74B792C81621BBE58E7C4F0A00073520582F69F06651554DCF393B557252016EE83E11A6724AB1CAF5CAA2B3B7AC04B2306DAC58F0A87F14CF594916615552CCEED7D50EB701FD4DA8B9918A46D505D9F7C79E93A826E9DCD3B07511ECBE8582546D62920E37316DB96FBDA79801B5EFB3B019B9F657E52BC7A41EC475B4998008A4FC9C1FFFD837F2B5D49D217C665441DB2F97A367CF8D3F4763A9F5C7B7D7547241E044F466332E8924A1DF2BCB4A7C12CB3B9F8B2ABF94CBB4D3B48FCA2C3A25846B8D3D2281AF65A068F98BAD7A64449AE5540B3247A91E494DDFA4CC5C5B3224979A2852222CE3285BA577DFD37E5FC433C3177789A1CEC84B2B36CB7848611CCBED72920E2639CF0775029694ACEC476B09FB5EA5A139ED07D1185537C01E365359F4934E4302E9F5B2BD1018ACBAC5EF553DC3A700DDB162A472BEF9189F0520A456D45CBF62A3F2C4473423DCBD67659BAF25751CCE414862B2844CF0E6365CB76B7519266ECFCDAF951C6F13E47B9740D8502B06CBF4CF260137253F61AD5BCA2BE65EBAC4250C6BE14B95E598974A3275DE691A41829B577AE48ED6DF430E19C4CE1625217514F5EC5032DA990702B5F853A7C574571152EE63B25548C17EFD4389B3232D6F71AACEFE958D91116176BDD09271613566CF3E54E0A0FB1FF46C2D2A4AA5F6650F6594515521BF370174BBE68EDEF446C80B8DEFE4EC2F6314AFC2488FC58397CA006A9855FF7F615097153D09BCF5DA018DD858396DEA35A22851BC86A3230F16E4525BA3706A83A4B85A435E6D9259F597F3EC21C14AA40F12DCDEA0B058589022AB7B97508CAAC4254B916AA6E1E844A541EBB2AD73CDD401C3D8261BF3BC5843188B73C01ED5667B8C73CA972D552CBF51ACA5749365E53ADD67B7F883280D34C00C56764D1B4BF53D2C0A22C9716F7483545E64A5ACD6DEF59125FF2D16B179CD57A714FB1BBDBE9EDD26AC594D0C835D3C0ABE6F89067A566A4EA3C2CEDF2D3D827784FE0FE91F9DF2AE7364ADD05A4A2CA78DCDFBD5FCC5EAECFC3A21454B46E094546FADDDB867E0E182D5A0594313369C78FBD384C9E8A8D38EA6E19E9DE320151760A08924F16896AC3FE13497A2A24D3D8F12341730F36E1965169A0DDC3EA5A345E7CF6C9216B1E68F554470D8AE6BDDF1FE59C74E1A7BFB083CF4E528241910BAF02565A609E6B6726F902B65D709AF71AAE3D65AA2141EF3F5ADF4FE029D95BABE05E49D91ABC6F138ACE708BF414524D4848DBC646646D0E31E5565254A1099BC389C54CE0922430F2B6B26021A727BDA39F621FD25322A1919E068DD183464D7A8A2A36BE925A474C2256C9E798E863FC9F4BB2B39BFBEB695F925522A191AC068D52A93AA685562E81A2CA2954F3FF40329BDD2EEEA7B5B1CDFB6536FD754A4FF489438324350C22B31D38F79EA3F025846E3594954E6F6F76294BEF87264B889D823323C5E5747E3F9F2EEB50134C36BBB1D6A990B8D04489C466D01D6059D1EA44759A6AC89966B3553C26EC968CB7D34E48CD771F16D3F92FFBA829B385DDF96D4282A45F339A531AABE51B16D5D58A92F06A7F1C95DFADA5DBADD2EBD6EA31CC3761BE5C5C7E9EDE303AB9ECA9A523F020491785E9F406EA06870EFFF904877193D7E3E021F24FD871E49F36B87E8371FD76B63B657633F9440F0D82C041DE210A2CE3D2ACDB3034ABB228D8B972A00231E987543ABED0C363D3034E02ADCF6743B747FDDDBB9C2CA79F6CDEA7995120A81683C46C5008D821FC04473951562290C701505E5AA1C802A79C825828B2C0996FD2ACD074B6557E360479FDE01D1C472673BAA4A1074710A20981E15C1EE6C121F49A68FF998C0BC44433DCF27C3F522EAAD667F233B10CC02714E1716E32E148A83E50DC29D22771C20FDFF058AEC34761AAEB2F548756D80DB75B44C709A3A3B9F346F13ADDC9A4D9FA4EA083322EA29D9862B2F94A397BBF866B7F2B27A1E91410CC0DC7734377A6D0F7B5E8A1547F2158B8B3B4DC49CF0C9BAF040BF5576E3209D780BBB150648153BED9168ACE41F3719D5B332FB7BBC0DFF94124BE67E89650DC160FEFAC85D9EC14101C0EA338F739F52A5E4E43E524ECC1E6498DBA5B4833FDFD673D1B3FEB2052DF48C09055FA12AFA37C17FBAF40B018B994FA58A37ADA9DA52FD04B8DA6CC0A6B50E455A260390589B292753B79B9323673AC43E6DA0E1FEDE7C02AE6E4B5DBBCAE33BF8CA3C0DBDF19FCFFEDBD5B73E338D220FA572AEA69CF898DA94B77CFCE37D17D2254B2AAACAF24DB23C9DD334F088A822D76F1A2E6C52EEFC6FEF70380A4081217E2464A76F9A5DB25808904904824F20AB2A7E89027DDA28BB27E1AAB9081639653F6EAEA369E3E58CB0BC3E411EC8A039A389BFEA9DBA8B177B917EFBC740764CF2561270D77382FC631881CE0ED166D3A966818F83DC675E38EE12320B50C3BC693E6675D37751618FDFBF0AEF967A186304BF5AC00435B216196EA792899B9FC56A09DA89B8C600A218E7F53E0540B3979B2303A81FA674301871FFEC7B49F56241BE601ECEEC18F5F40DDC095FAB7B1953EAE950F5110B373AB7ED372868B20E6AFAC71A3D3A471B4CA22C19CCB9B6E30119044BC8AD7C15CF0104531CBFA99A92A88929D8981E1F738A7EBCFDCCB54F6B1DA8567E555EA924D1DBF14861FF17BE86A64BB05AE9B5F4DFD0D009FC30A3B995C086ECC6DA723F165196BBF2EB6E0B2AC7E6042EBFD50D4885E058E684FAA6F71CE807DC0F336E67650DFF3354C032FEC5E45CDAF1A9096B71D20F807F5EFA7DDEFA77ADFA3E184B986BA6D1AD69ECD85106AB74D63AE7569ECCE8C9B9FB5615D308261AB41039EE401DF6D53873A932684655BB5F065C59FA9BE6FC74C94A96466985826CDEE78E24EF3B38E287CAEC91705D29654B83AD1BDB0DC86A022E049599008FBED64393A2691F6F5A0034CE196D003277C0FB8AA7B375865BED7BA7AAF75F55C38E2BDD6D57B1675F5305BBB828FC7EBDD88CDCA0028B256390821E90F96C43EE34ADD9981D48D45932E9CFA370D9920CA3DEE245B0DA7917DC83A737379B75BD42196E9754118C4DF00FC1E74FD5838CDEAB04DB39988E1A5C103DC81BBB4EB7DD06ED19125D36FDC20DA568306BCD2C48373A0775D585A2D1A5E2607B04F33807E42F74BE789D46DD382BAC3114B8C1B47AB410B5EEAC5F7900156FDAAA5C24C798174F4EF3A1736CF4AD0FCAAE30F4A12D01334BA2EA1748B063507580DEB4301584EB336B668A25C5CC9EF6698322099460DCE58E60F657224D0BF6B43ABF1E1826C1AD5E1865E86EB61793B6C50678989D3AC61C94EF26EDDB5EA276DAD0C8784DA2D1A334E7C8F65DACDAF1AC25991FA7B2F83A064551D19ADDB680677C75C5A6CAB016476A73B4D0630593FD14E93CE5D7848190C8F3F6AC18960BE4FBAA7BAF95943FEF25907F7FAB757AF4065980EBD025378CF5602B9D79387619A2629BBB1D4CF1AA6E31072C52DFA770D7A3B9012529EEFC343E75C759AD4615E7C5A03FE8BA4DDA271C23C10C47E58B0652FDA2D5A3212AEF8C9B5EB360D3A06FD94DC61F740247DF17B68D1A110B63954F47790707D02E9063D2CE1F743C0D5F1308D5A2FDC8700E7AB7FF24328B4C98B3A6928E88A749B8088BB24DD361D35559CA74908B2277ECAB76EAB06642FC415465350EE570770B751671FB1B887E5B1806B29E7B5EBC86C804CDAF3737087F3F78392D57045B0DECE36E36615B11023374F3657FCC4250E4A6B20F8C80A0FE1FBACAFAFAE2FB9C0FEC434EAFBA8EFC470A9462D77A3522DC47534A29B346EB32A6935E7C1DA6A71B0972AE46CF49E65E188DF507D7D1D8CAA304FBAA70B4EA53064ABEB297DD23388304317C113564A8120BB4C8AEE4B52D0C57C8C0BAE1241DCCB7CA4AF7F28CCE7D8C97C9C69759DCA076A7A998FF4B980E1A7A25B3A4BDC4B4FAB85E0D4DA1656B5D56AD4838B93F14B61331D0CF467C201F83D0C46904E43DCCB6E2EAC1A59DC4B7DA46F8F44BB2D9C0DAF5D1BBA74BD447D345E5688CAC11691B9781041179331A4939174D395D8612A1E86DFC36E0496BEC4BDB4F5C540CA55849DF4C7E9E702F29EFA23F69D20593FFDD11468BDA7ABFE980AF428EDA93EE21E7A61BE475FE234A21CE986D7AE0E7DB2FEF9FDFB26333698DC6EAEDBF0F93D747C5B7D30F9FDCBC527C09137984613B87C9989D76E021D8940D7B7ABB508F8B1D904365F62E1B59B409F56942782DEB46B49F6A5948EC1ACBBF633B6D51032DF9626E8628AFDF21630E9A7F93D2C67D1334CBB9B990745101D12AE9253D84987E7657912210E167B4C068F76933ACC3F936D16E4BC346EED164D8F5A8E33AD965ED7077277236E072DF8526F345EFBB9B9917D995DCD569305BA11C0EDD55C3F7C490D8CBA4B592F20894B13DFD5DCA286A97BAFDA26034D8785B41AF4BC215D257921892B783E61AD064D27B3415CFDAAF5CF62EEB6647ACE60583F55859B748396BB6DDA8E33DC10976E9BEE6E9F7B1A1E77E671F726FC218CE34318F1DD2782817F011951729AF5B125FE987C74AB261D4E79AEE139757D72D623A2F95D1F1A29424EFEEC1226BF87E908F00EDDBBE0CE0B424E72114947C3F1BC3BC4921486EBF4331CED90265B6F1B8448A840B07C24624886E475361C370AE22445F7F7C10B520CB714D325638B3E301CBF8871A8320E5ADD290D2FE86F383AEAE017A1C7E4FC1076D210B193AEB35FA267BE0898CCAB819EABD1B19C27E6649DC758BB49F75E03F880E16723EF6AA31A750DC0EF014E3AC4B3FED62DBA103FBC17C36CDAB4A17E9440FDA80F155D61552964D10DD76DD6D8B1FDB7EBA003B0FE4D0BCAFCF820DCE089B27A467E17AD3156F0107A8CE732F5BB2634CE7385FE5D0BDAE720F6623FF042E1F4393DB446F8C34B532FEEE6126D3558F3B90F4A8CEE8383913E2A8DF4516F2442067DBC5BD0498B770F926E0F6DE50457DA40F87CE673505E070DBC493A11205428F0DAF564E5B2444A6D5220159E59A999DB4997C76E8B1DAEE3C7262BE6346BCC8189B4D0530E47657E8DC2C71936B86279B7F9ACD466843181864D1B29CDFA8028AACCFAC1C81EFE4304D20EA7F681DF3D2437779F47CDAF7A4A8F6A7AECA39D69D452FB30BA1E3D7B837D1C4F79B233EF1E844C56FD6E9B09D434B8DF0BC1568DA6D872D58F822EC6B8F70CD2EEA3A1484C9FC09F4980CB94B20BCF341AC1E52C3DDBAA739EF0D51EC7D8A0C460CC341AC1E560CCB66AF8A8A4E87F00436011EEB69940E5A0CB346A7003F4B4F671F8AF90B4F93D0C461013B6A08B06AF8C0E9EDF5994FA377528DE36F532B662DAF1571DE121C8724699D4FCAA23E8715E20078347C7338834F393F82E48233E969D3613A81C4C3B6D1AFC0309BB9C40B1E3AF1A5487936F6315CD1FB0EBB2DA695287E9263AB1FC82AD6345FFAE0E8D040F13EBCF41145ADC6A3583CCEE31DBAAB7CB809BBBA6DDA281ABB378E35DC932BB1A7EEA679D9D464CAEEB277FFC511DCE2343C28F9A946B5B9DFDBF2B5F0E9C08AE73CB749A74941121F4322E5BEA3419C0DC3E09206EB59440D483A0A2CACEECB91DD4E1FF552439CFD645FF7ED60F607001732F089DBC8305B00C9FC342682A2F43F2A9FC71DCEA6344514EDFDEE52B46A0B7621A754E14C725D6C0FB955443403FF868FFBC6E9A17A6D1182E361F4861971D34D6D561CABAEA76E38937FAD5FBB09B2D40849215E91DA3F2675B3564E334F9B3AC3CB667FD7C9946BDB7A11436B7830EA5E2EA3ED88D9F039B69D4C35B0A9BDB414B2DCCB95864B7C989F8FF6635997E0593E9667E7D6551E45C0D8C02D75705247C2288D8B067C682830CEC92B8AB52AC7F3C0735EA309E8DA50311CFA9E8255F8C1591087231B0ADA6BB0462F828DBA9B27D3C45B5D0AE646A517295C354A4D4F7CC14FAD567ECCBB7D5F0B25445CF252991AD1592CDA2A59B3C4BDDBBE8A497755D0DEB8FEBD51558CC97F30DB89C6F26D3CBB9E1B5AD0E50F902D7012967F2B5C76953790DEC039C69389064C5E8F9E4D4976B89267E6EF072E7B0ADBADA7D908549B78C58BB45C7869946E829C381D86ED1C691E819D9145D6CAB36AE02C86CEBF91FECAFD7CBC9667DEBEE600B00DA1C6C2148ED83FD2D89BC3C2B740E76FB93977BB0C929033CE35DBB45176279287810EB9657E6A385AB05F3E95B57922B8553D691D7AEBFC622E8BCF6F3679C8BF9ECD3E56CB572C73945106D58A718A636EF0C03B8DDC39457D442F59B97CB3D5F39D333168B2E6693C56CB5BE9CDF94A7666D78A67BE1289F640548425334F4429866FBE0509D4196D0055D34B41CBCCAD59E7ED9EA2D0FCE561F8ECF83E31BC0192686FBCCF423273D6BB37FD99D31E1F7CA674B02617CDD7A1691D2BB8C5AA8F9F9F5549EDBF919867B9CF4542EAF2F660BBB832903A17C36E540249BE9305CFBF518BD1E23F1319A6459E207C44190394B8D1B51E945948175B083A024EDF9D5FA66565A9D2F669BC97CF1E16DE71C697FDE3D437C009CF3BCEB2CB9E6C860E3A5F7905707CED8454A3894AAEF14DEB7E3B4DCCF789D14E8EDA23A6306FABCE348C9EDA035A56912EF4840E49B79765584E16F6FEFBC30834E57F5D7775C6AA7FAD4A7056183A0C430ED76391EC7EA97E3BFB3FA074CC4DE3D5C625E9D35DFAD492975B29E197A98425C4E78073FE37A10175EEE6DBD0C965DDEBEB9C109097630FDEDEDFA29CB61F437DCE16FEBBFC26918107370DD61E9C5C11DCCF24DF20DC6BFBDFDF8FEFD3FDEBE99848197E1BC78E1DDDB37DFA330CEFE59A635C321273999FA6F6FF7797EF8E7BB77657DF7EC6F51E0A74996DCE57F430CE99DB74BDE7D7CFFE1A7771F3EBC83BBE85DF7F30AAC1294F7FF5543C9B25DCB0D91BA862B2A9BF83ECCB2057C8021FEB54D9CBF7E850CCDD4B4B482777C101C32FCF55D17D0AF1D62E7C1C07FE0839F574CEA0B44B4818DCB375E9EC314ADE87C07C97CDEBEC1D48BFDEA8F14FC4E3A1CFE6F3D40FCE0E13246E9FF88BCEFFF0F0D294FBBC1AF34DF97AEEA2DBAAECA29214ACD4C16B505C164451900032E27558FB61C651BDC9381BA54FCCF79BC83DF7F7BFB7FC887FF7C33FF37387EFB3FDF5C63B5ED3FDFBC7FF37FB531B8386A233A5355C080FE5684044B0B2C0EC74486862BD1FADE0A91A63AA73E12F5B73608B08F596D3CBA206CD0E930177D0A610068D0AA32CF98AED69F4D3885B0166B3F8F10128A6B06213D1ABAB05A3E4B2528FC771E609EAE7B52686FA51256751DBC7DB3F4BE2F607C9FEF7F7BFBCB7B5DC89DD7901D9A9D67904B3CA93CA9EDEBB003D70C30AE7B8F647C19E89FAC407F1C0676B12DD2AD14F40743D08724CB4B9D9C78173F9AAE08456A826D3402EC2705AE11EF18F4210D929430939A1DE4BA2070389BBF6F31950E4751620219A81306CBD993EE82D922B64FC21D4ED786132E2380E88175F0829DC57A118041FC90E05A6D3BEF29AB616591178626B3AD12BA81CC8B0EE87FDF82DC023DCA6559EF7E3E7E6823259462604738D0BC9BA6E57DF2E9094BDFF39D81DCD3816033A1CFA8F764B74B91E832E45B07CB2D60B29A4DCC851734672B09A6F97E5831060F2467DCEFB56196899D0482F23393FBB17FFA031470005BD9186CFE733333A631613884228DF179936B0223A3D0D298C955ABAEA558CF566033F9B4305A56EAD1AFBBA2427DC1108A89E6C6EC5F4C65A07D7BF4C1881364D9A3145913A8C4632646571BCE16AA7A30394FFA084734ABE3A62401EE931896DCBB4F24FEC50C765C445BF98B495FD6BEF3BE0F8433863C04C651B20D42D72F0EF2FCFA203F5A86503FBA86DA7ACE295CDC4A0436CC438E7EC3B97967755E6F8E1E6F55264DDB274EE8C5F7058E8DA7E1E441FC64227DE788C7E19BA3482109AC94B22B7DED2ECE89E94B1F754A583E429213CB398221F9D03D5CC2EB9C437DC016C601B6E9809F3B4A04A04DF365CAA114E60D7F36B949718D356B001A42B6BD98CEB9A9B00915840992DA6CC0904C4E048A536DEEAB66D8059EE901E7C4201CCE58A3337BF0C289E5F79F2CBF9F5A7EFF6F8BEFD7CBB5C5D78734C94946129B3346BC9D62E9F56F20BA9787B6CC99DC3CB03817B79A84122629716868CB01C65A4918EF0012A62D969E8068BD794C81A0C5DEF9C9C146CDED3D7A4F65C976273C8380C3A8390196E390651B02253C063DA60E01CC2484E4D2CEA832B1220DFB8452251A4832BB1B729B208936E918130C91890A9C577F8F646E0888B621496DCC09418CD863B0AB6E70F2CEB044B00DB124F9922AEDA894081AF58CAB15B0857904875E05E9D341CCA655804DD78038ECD8EB803DB4136531173F039EDFDA15A33D2ED54749BE178ABD1AAF50DBF762E568D8E2CCA627B388220F61E412D67D9A1407EBDBB04A4023B73E1B6841B203AED56B254D9004A248DCF4769150F45741669ECD6A079FD94E68345442294AB03FBC0FE3CCB5F11B43DEC1076C2C6D641C0D131A474351267DC2250E5D8AEAF02F5096F0B6D891B246F7CD7ABDAACA73DB70210AD86C79737584163B7886FBB89892864E5F1566F74274B635052E90ED7B691A78CDAD63B04337B5CE0D1B1FC0BF8A84F5F6706AD7BD5EDE8079FC808E28163F4A6FF32AB5A9914BAB89172B6B43776D22AA2AEA1819EB8FDF5AF9AE1E539A56F208F40392D2E226457F65C475FCC33FD0C47D0F83FCA84B364C86D36186A152899603D8EBF248A6537D6FCDEA331B43362276F4AF0B07EF23634710B9FF878D315D5AED5AED284BCA50F59FE9D6C7831F6EA923B2B664D60A1CD323CBF6D7561C83AA39EDF2AEEA569EB6A3FC6E655F9B95E7140AB601D7AA7B2ED63529DAD78F55CFCD65D84E216D3BF5575346DB0ECE702A70978AFA0135E04E35F5ED12DA5265AC8189373A1C8BEC586AD03028C49FFFA2646CFCCF02068409A3F5484DF9555D8FDBE91E35A5B98D950A7488B73110BA10B7DDB9E397DE367E36480B6C9750A324864F56703B95B45D813D70AA650F23BE2A15CA1E61684191EC1146F6A97AAB16FB7748643C48CD85BE79441882E814C936D75A76CB621B436AD7C22EC1DC85896708A829806D0FEAA303509C3AD756927655E5DA7CE3F815AD6DE01D0B59DB0169499D664038C5AA6DC03525AADDDC313E5D8BDAD54DE0D365A7AD800A4A4CDBB1BC7659694BD267EB489BBB1070CA461B8B38C202D1C3DC4E9C6AD1E6A8E32CED766FFF661F5C4F94537ADA06D58C24B0008BCD85213F565711D704B1C0BBF36254C2C769994570355F5B297926E4EE3242A1FED46AFCF13497A2B9F7E95F5541155EB810B30F25289B206F3CE887B0B654B5843693AFB32B70395F6FAE57FF313951FB2023E69AC0E064D1DF0E7BC2D81A357ABAD4EEF756C406B1898BD1F1E82B399A2BC64CF1425FF4669911DA9E03AEB44B127DBDEE4A13171061F497995689A78E1FCC4CA007AE2C44E5002F408AA65A00220B6F4DE2C48D4AA8153572CA6AA96FDD093FA43C15CBC79CB0EAA3E7CACB927A8ED332BAF4A9AF5FA59ED34B3D6B98065EB8C4B12AABB67B8109FB782632D4EC5FB7F39B25538851D9A42D4DC0AC64D796DE22AE0F6C46F6B8B137B80A6F4697BD73A0C4F2131C724A99EDC8668D16E1015D1F776912D9DD1C51947B86A67DEA532B061079292EF5EEC2D31B7A4C149C21A8E400F669863D8870CA180B1D0C02B40BB089A3D929739452DA85DB51AE23671116AE822B2A9F078298A5580453E2C7EA3FF92114BCBB340F1EDA4A2F46201D21584E15AD9C1D1C1A2D6B60959A33B3561E96706ADCEC8011B1B9F219744265D82321931F25FD4763A57D744019C2AC36BA8F97C4F7DCDF3F870243C92028D9A4C581A221614A7101CA05791C81D11A0A233BC90E1E520A21A3F00F2460E5FBA4274B8A2ED8C2EFCBE460E0A6FE1A8CEC104F225B775C9C4C98400AEF75645B25D4D2344969FA31F5FBB90B21EC53B32951F38138727A7E5927CBD87678F1690D54DE18FA6763E78120F6C382F66D3189AF25E4E02464B84C6880A8C3619CAD5B68E8EF20D939992C460C7E3F041C95A0096679916E13ACC8B3B72FC7799A84207BCAAC41792192FEBC1494CB66E5D787A5372C6BE13065074FB3380164A2B850DE1D36EF83F2B87684257369AE0B3EABA47EA2136D8BC54ED0EFC26F4DC3CD08CEDE41A54F01DF695425B4A4FDB94D88495DEE72E722EBAC9F9509D31D80DA956E5C0ED65AB88FD6EF3216B2BBE78610F60058D7079F026D7CD97831F6047392B280D4D0C5E1CC45128120BB4C8A5494C4C004DE05F30CB606F9F50FD7484EAB0BC421C8CF050C3F15A995C4830E10020B14420671EE395387243C0C76E71C61A8A3BE66CCB14E383707DACF6F8F44213BC204AA91465AAE3B743EC0161D9071071B6976A5440AD3538DE580F06AAFCF91B8503DDC982CA21E73BC33568F382AF5D7838E499465860A340ACE5F68FBBE2B134C1C0DBE0E5256ACD10A4C7EFF72F109B44409D7ABD00CD31583861B094947D7B7ABF5F00375259CE1469A56843BD44848562F45743CE4DAD6FED382E6C60AD44670794B7B883944D21E6C19C106C220FE06E0F74018CDA098FAB4011644A4308ABE064BD7277771FDC5C4A1A4F25135F325697D3CAC1BC988C5DA747C83B1C7488F51D218B40B0FAB439AA0CE5196840F5699DF4A9CAC6D6B8F5510971F7A81281581BA4EDD56C38CC8A5B803953F729F6D595F231B444850CA20F022CB454BD26F09A654B981433F8DFBABF1CF1C4F8D3C36468E7EF7D03471CD3DE484D0B966C7E85A2B8D6E8E3DF0025CA08BF892DBEB88CFEDCA4052415C34E9FF0CD89E9334120886EBC47455F49EBD07D22B4372886719901A7FC3852BA88003DB5B735BF8D8FDF331D835991C5DC79AE29AE700EE10E2F93EF0BFC5547138E719E1B6609BE488118C3214CE1A31FC407E91E7589936CE0A46E3AD201A0A1DEB74F8816822EFCB84AA2F7871C8DBFD207111595C1319BC2F43BAC8F8432DF301A735C8DABCC4C493B004D3C6D51C0E435D26EB97A7C1C17E661518EB9955705CCCEC0EFB7FE54F07171E018846C11D557BD9A58BFC9E54301A8C97E3A209838E80802106715FA8653853838884F6BC38807DDB0CED30EA10BD76C07C79B398117DF7FC6A7D3323EA29932750704C8D63F81262000CF9206AC672A2B8E1BEE2145E2CF57776113E3822AF6B693171644D1ED0FA8621E875DEFFF8CBDFB581EF02F43780F1439026311D526E822956B200BA72AE0990C8F3F7410C6D40D8A2809D39023A80C004C85DE889B23529E62A6814034641107671E466A1FB5A3C0EA71DBFBEFAC1781CE62D4D7625DB740655F05FAB8A4411C134F0DB57E8DF8F57E82FA313722ACDA6E62ADD4587F9296A5C9C5E378DDE4D46500AF78F1090D58584F71104F731A267ABC2205A8C458B215C7F5ACF56BF4F88296E355BDF2E366B137E90C2AC08F3CC9019B4BF1E47DA31221287A4916C71D42819893371056418007649CFF7D0FFA643A4C654365F4EBE1895442F1F1686D74DD42D833B087D090959613FE96F5D511638EC939CB6BE6D83D84B9F5CA685E86CAF11F7E09C05DD0D961F27D7FB4C8D26BB203F7CFC87D5EE8538A0DF565ED1AD476BFD667ED127FC8C6E9083977AE58B176BB57431697F6D67206C26350EBFA168ED66B29A2C679BD9CA88F174975097E8245BE09AF09AA1FA7C77FEFEB3D313DEACF514B1F7CDE4CA4C42440F7CECF4662C2376BF1F65A9CFE360D9EF384F0995A127E213200E3A03BC2D9A8B61359B5CCCAFBE00F4B759D2CDE669563BDB43AAD8A5FE3D2183F68C34ADD48B55BB8817FDAD15850EF3305DDC82E57233312196569E295DDA1025A9724D0AC611B2BDB1B18A353DB9155954C63F7E6985006385538E107E729192963873DEB3EE5A068640EFD08E0A6E9C5354F2EC561FDB043ABB4F3DA598BB404DABF0EA18E5104F3F03220EE5C623FFE666319F4E4C6D02CD59D0F6C7179E22E7A9B10F071D274255987D02DAC75FF46D00B8C078675DDC6DF572F2D5E8854EDD5CDA972BF7D21BE26A75BEC318687FC484BE0CBECDDCD75A7EE5B88E39AE03DF65DFB38ACBB22BD674AC986193C0E1D65195EDCD536AF3F9CA2AFAE6F269977A4518F816303E253BF5524ECAEC78B39A4CBF12E3FC64B501B37F1B855ED4396FCA6A90F0BB692086084EDB27C135E33E9BF2BFC33DCE941217254968663F6ABEB419DF4D41A83609911AE9B81A1828D34B5A24879282549FB78E26A23A95663ACF364DEBEB3C856762B0E3A7EECCAD03D7B1E49445E866A6B3429A04149562430AFAB293EABBB05BA6AA4D93FB661F4C4B0D2FE09D48E850428294B6D37D6A8AE148CDA4FA72D93E0877C981826B1C4B5B847970086D8492BBE03BDC795152083D39159D9C9D4510FA899594759F26C5817A99C46E360D7EC7FA6F24A7D3970BD775AEF13E371F848EF9763D48C5D48CD598DDEFED3C7730B0F829F622291733084728A283EF1D3C3F68AA97F28E99A254F51D942547736B584910661E3E2E3869287696085D80F4F7F7EEE061630F087268F35C29612860A40C8C8AD53285F3AA5F7089E736790C2B4B6CCB106BBA3B8D900CD2E4D121343FC79A10048332887397C0728CACD83A1FA27E33E0600EB918A29F2D2393D9CF9544C55A2751BB0681EC293AA00B441A76F2411F532230970B612BD2F10B329B58CFC2307904BBE280E64F1D54B3C42A3819E80EF09F4C6662142FEBAB3B157CADED41FF29DD2416C69617BB927783BC276F88DC3F2D7763AEEDA0D0F9DC46A331C56F056344DA5F6B086ADA74B0B9BE5E98BB4E9E210998AFB9C1727354CD4912EA8F5D7E6537B061253ECE06619FD60B2FF7A8BB40D9A392B321A5BCE5A40422416D435DD543941C2CD5E2F86018E9C3D1569AAAC09B4F559D9B0440F49E65EA7069A595D1FBDCD036F1C7F5EA0A2CE6CBF9064C270ECC1444911B065180D3A5BAB15870418EA13A3DB5E5A25C060B0B42E77B2B64F6019268EFC2D2E3F126091AE5584FC2819FB445E8006421FAE5C38003906738AEF833E42064161FC798C5608344A3ED7A34F4AE4763EC7A34F4AE4763ECBAB7FB13711780D3030D35045925F78F30E1E536DF2C9D5E6E411EB9BEDC1A90AF97DBC8975B55780C9DA93D88E1E35044FF88738695A37C788F8B6DF97038864A0DF671CCC17E1A73B09FC71CEC973107FBFB9883FDAF3107FBC79883FDD798837D783FEA68A3F2900FAE9988E69D4EC52D5ECC3693B9910A818ED982B91798EA13447006BCB8CF2850B9BC7A8B38E0FB36285FDE470876D870753B8A0E76D6FE750A656044C9F754F381C5F5B9A35C759D8F835365B59450AC024AFB818AB3FB0144705991DE51D98BCC5CA8FE2CDD405A29038DA2A172E00E5A0AB11115DB945CE0E50E5AB7960057A3F8B3BED1B1438DF85230A1487543326111FB009DE54E48AF9905F076BA2609A8E74C9916057ED17C3C80632A73C911CB915164FEFCC2C0747431B43FF897DB660CEB04A2D2EB3776E0DB56661FD93933D594F03A39D8EC6C49C735B8204BA06F1A63210CE370BD4C764508C1BAD89A5073F575566C0D653506C0B074BEEED480E7B25E032B51358DB633B1010B5C2F6FED78E8D41600AEBFE591BC7CB858831DACAADAB013589539F5D393C5EA2A9A649596A9555BC8649D090017A8A055B65BDA114BA0A8392A66770EA40926B2C8100C93BEC1B05A7BD77DD9181DE21EE982706A5856670A1DA9ACC9CB26308EEB9725A0534173817E34701F2CCB9B60AE84641324CF2794ABAFE5D1A92BABA31BCAF3F7B41C6106B8E2996566BACC96D99433C79FCFE22222C757DDD742599A2805F0058E3718DDA76A3081C1FC45D2F71E511A7F424440A3F1EB4FADC6BFCD606AF61E231F3A98BB13072A04AAF0C28538CE72505F33F53C5E1DA13F036BF40E333A4D5D4846C78B07C4EE199359D204590F9B2DE4ABAB3F0005A5B18A43A31EF81154152F3EDFFCB915F083DFBD28887562574E92D08E2AC36722F720C9C9AD3EBAB7F88749C048A9A6CCBC7B105201BA3DCA508B51528D523F9693E908856E22A43A3319648C5DFA04FEC4BE6AD9A09B420D33E8AEDCE1FCA3246FC790B36946197432D9214D4849BBC128EC38C27004164407CF97C6BD2A79D96D532FA352791B87BC27419617A9351C34A76F9429D3785A38080C77FF037AD6019085DF97CD417FF74A989A29DE5E4E2CAD9FC477411AB9C2F308CD3DA6A197E5A5B7EBC109AE343CF7D8561674AE85A7AB57D25F8AC4EFAF4EA00F7657724A794177931386585BEC3813DE23C54E38495494565198DD58E5EBFF4EB65990431CCE16F56A0EB5A797C2107A99A3537904B67D724C31D42341E4646064CEFCAB40D2B97DAA5B1C2284DE61F1A0A21235CCA0B252A99DBA2CBD1F2C1474470883290326C68A00CF4609E08DA4003823DFBB6ACA88C0D0E9C331F20AB782012FAAA0F772107D364EC36E3037657448D6477D239025E183B0DAD589E52D8752E179E6413162166033F93AB36119B9F70D5A320E1AC480EC43C4A65452CABB651BE584E5C74E1F9E0E8BD087DEF7503361705E2DC13439C5A224864FA73CDBAE3890412E4C9CB3C4B40A10090823F6692A178DEE79148019F04C9E4D1C5CEC3109058C04E8C1CAC25164B2F9CF8D51321336BF9E2181302E2E43D2061E4C27D1A52E6C8D97999ABDC536771512A672E217AF4E453D5285437724273CD665524E0799467112C5D8E6C17BE84B2DABA4F97792EF340A62BBB9DC43C4FFBB95B84D5287953E58FCFA239A5772C6A4F6B47191EAE43463ABFB9866876D50CCF6499A7F833D5A1F7702445D831EDF0EEBDB4FC637445DD21D2F8BB9AB371F4A97065EAC28914398EF4116FC6FC70693F8E8C2E83AC8E77130C8E8F209E4D6FE979B85543B47BBDB841BD3C9620A96B3CDE5F585A3941B6CAD015DCEA05BC040F7E4C9C1ABC8F83622FAF2FA6266140F4DBB9EEB2EA9A0EAA0F3025078989EDCE52625A030585AB5E00A704EE24BDB49460D05B3FBAD3350DEF71052E2992114557587562DC11F375B74E30B859841101591857049C10A624B584176B39EDA3C6B0867C072882B295CC06B34E108AB76A94FEA90063E0ED00EE1430721D3D911CF5090429CAC7E87C4C54E9CB329D82546F78ACA906D659DAD439FA794C2D44E625317300C5F1416CAA671B44CFDEA2593DB07011BA0B2E139EAB99F2FDF470CCD853E611B265B2730422FBDB7C66607EFBC2244EFEEC6EB5B459DA1CC076ED7B31598AED69FC1F476BD01B37FDDCE6F4CF842A996CCB2E0DED478C842684FD735A3102A5215B40BC76FED4AD29081CCB1687D6F8789287257058BFA5B9BD0E1338B642EE510DA9A6028DA7F83F0001E837C5FA26727283D0B2EDC6FA850A911C90019C0C70A33BCEBE56C65647A6B1F5D6DBB9BECE43B57A4A2C1FA0A161AC82E38952DAD81514986A40E1949EC10CA1D7E4DAABB10D0C5B648B71A0A0A65C80724C7BB2F9358AD87C73E3A5CE0EC630355FA34C872EC9378109CA3641B84D255FEA01F658001DF79DF87C01727200BA5E89A255AE83B1E46D81EF912A964E5C086A65274EFB580FB699F4E84F89334D2296CABF47CD90295EBC79025E22BE2A3EB3B42D7E347801DE2502156690D7891B58770BE10ED3106BB34EB1106BC3C9B851AE812AD0718E632ADA17BBB5D0AB3CC86340F691079E91308BDF8BEA0129F1A3E6F32E827F1CE15B420039E4F96101CBC274B7F15EC642293B2351F84DE3689C3271B7C2861CB5AE5CEA139FB0AD464C5017A6C4436198BC2E43EE92DE76490036A17203617F8B90BB31DA28DC70C14A98BF460DB220B62742A41E9202567C20631D13EB67B7F6BF9209A14C9F589191DC9E331B9E8A1EF6536A7AB336B40F946398857437BEDD37E733C9BC82FE64E2CE89F77E8FDC02667D503B3DE278FA4C4881547CE2062A0D4BBC3C4350F8368BD314C81A06DDBF9C9C186CFDD547C64F3C416BDB3BC07A7499C23E96C08D084EB81D9771FC25DE3A8EB98EE26EB9FDFBF07B5DA094C6E37D7761418C40F49E043C07B0B1A1D3FCCBC8FBC3F2237BA1E800B889626CDF6C1413FE314FDAD9536FB9871949F034DF35C145BB4FB51D0D46C32F10546BD276DE96D882C64CD0A9AE834DB7BA7ABD214EEBC6B75E61547E76844ECD78F317DA72A2BA7C9774394B86DC7F1191AE8EB202F733B3D0B814BF73A2167D8769E068701522DD0214EB4BDC648EA54DE2962265DE27AD493DB8BF9065CCE114FFF8FC97611B3D0A4D805A6315E0C80618D097D863A4D704E5CDE4E6FC9BD0B60E8DAE7640BB19C3EDDA3B7B55CD56D6062F1EE1019B800ADE76770319B2C66ABF5A5998BC119D6EE3E3DE5ED8ED7AE26AF56DEB9C9CDCD623E9D904B69B65A5DAFC0E2FA8B51724A83FD0B06CF13EC42337F4092B282CA433F234A9A263D9A7E8364DAE80DF50DFBB54AD1FD472F6423022251AF579FE7460484F00C3036A5B6419794DA5F3B65D50F5E58F4C2EDDAE3148FB7AAE0E46AB7EA9893C96633995E82CFF3C56CBD59CD2646755EEBD08D32B9BA5D90721BC8B04CE1BE68188FACAA8E45209B7D50A283D206DC1A6F4618D5BBC37F35A807EC31706CDCB81CC54A43A25F7793D66F983C764DF1825ED5BB894594298D6059B54992F749F3E24DB280E68DEEFC623B6CD0324503E77458724127AF731E4C0EFD380DAA9BFD0BDC5ED54FE695E99B99AD5F67F06EEE2B823740CC1DAE35558DECE0F55C026CAE2A5E548B6DACB55B3F5EFDBBA53459A1BB03C9D8472D8F93581E0AA613F79C061CFC4BD75F9F0597C26D11843B2ABAD0749E55451A27932C67E6AC36988F3371159E0B3B6CE76A75E566E62119C2F6503C1B2FB0E7E153D79C33CC1FEC4F5AFBE05A17656B985699231D58D515DC257E41D2C1022FDE01629353F7CE30D16713EB8351D2B2A6A49655F651019891D4DA550A5058A5000521920F5C5CD592B9989A5448551E2796304FAD3C890628EB1480D8E905B4BC5E1C59FA1FBD34F5E2FC09F8A11744A0A7A2A889458AC3F95CF91ABA4C1430FCADE468D617C9635CE264015699157E995DCD56930570F74EB17A9F9C974D4F4321247F4BE8BC4A32A9EAD3A08E0D5AB55A7CA57C7D0C29DFA5388C13D75572BFF5930E2B59404079249A38A79540706907AAE0A6C53BE4008A24B285F3CC724A9F795449AD03A27DC89C851311F9BC552988E3B1ABCC0B0056C503879A79D7AFD96A2989D1C6F5A3E79B8B67A87DB617776A891A12161501F9D3CAC3B90D8EF84E803B242153159C8C04D1165CE237E11EEC214DB6DE3608D1E58D80FB7963F4759DBFAF356C14C4498A2E9C8317A418870732C028431771E6EF21D65EEE461E1927902B428F4AC76BB47F8744C6D2940407AA20AA2188A3491B731E8BB353DE7B2EE202CA7C59EF49AEBE1ACC5D98788680D0A5E30CD44707A0D08511E63B7717C6FEDBB595D33E02D0D4E9DDA4ED4A7366F056F01052BE21A6405A42AC1990CF41ECC57EE0856E26F647F5F07775C7348CE483BB9BA001FAD11228D945D72C8F185BDDBC12F7DF7015A50784D5677BB683C4AE527DCBBC99AD14B87E9112B8C4BF67A8DBA9644FDB6287D32C87E242E74AA8DBEAC2157DBF5540254A764E0B7F015321DD55AE3DA181B7F0BB59B29DA6ECC2C9C12DD4F4E5166756C101194B1C0355F7A1DD11B88ABFBFFFECCA33A14EBA7E7D35BBDAD8645B2F99875DAE751AC680ABECE25D8951B655F525DB0CEB98F826173B4668A83C736632AF04C60CE6C5C106A714099F11F432EAE56912088C583212A940488E8FC50A936CDCD65070E257BB8774A5BC72AB6EC18FD30851A32F3B8BFA37EB2085844AB675DE3ED53F7DD42677259FEA9FB4AF684587EA8FBFFCDDE16D3DFB1DDD286636F587D2F66F6642A23F1ED684A4E0696B55D34F57B1FBA0E2D5A5AA78EE75D96DCB20BA52685C4410B141252954F1A6F0B1E5DCC84E6C40D7764253C360AD685D006658AA170B6B86E42FAEA4AD4EF6FCA93BDFF4A3CB909DAB901D83E38319CB55C8C186677672EA33A297F9F2663133A597A6C09C15BD08C00CCF247E10D630BF5ADFCC4ACD04F87D3EFB636654A9A851F764E021808FD0B43A9110D0B01BAEACAE1A55B2AA16606891607EB599AD6E56B34D19EF894483A5A9EC5B495EE6028190499FABF4AB226B7EF8F80F53B86E0462B5E82D5B3ABAFEB49EAD7EAF8286E76BA35B43A054D2A5A47EDD946B7AA2959ECE68A0B4F1D2DE4846245A8271424983AA44D6D3CBD912D1CFD4EE7922D604E99291924EC9352535833A72C6ECB30C0DB2F1625BE4BF6DD0A881FC67201ED690E07C39F962143FDADD3F73A21BDE60E3384A785BE439E2B8F52635EE36F0FB10C161069EFE3889646FBCB533C7F4E3030A4C279BD917439FF4E609E4A36DBF378F9F15021A90C48E23F55A050D14CE47E0BDE52B8DAEDF1A3A2925DD8BFF87BFBB6244ED6AD21631EC81E9334C12103058CD68A96EDFA024896EE95F45E50FA984DEB8019AC796A6C07DEAF47D6A9307FA9026F7CD3E98BA7D2FE09DBD5F907D587B0D477E81E8FB4005E12E39E4F2007E252A28C23C388422914AED32FB0E775E44A75D3671D539DE0A2E3C75AC2CDDF769521C404F8963FD4D83DFF1EB17EE5AAE5A3D261CF34134EC44A6A933F912BD7AC69EE3F77615E8542BC5689BF28BE8E07B07CF0F1AD74FE3A0AA26402BB786950461E6E1E3A21460A50AD2DFDFBB83D71743A61CF575AE2164679EE9E099E48DD8268FE12EC80EA1F7D48AD836DD9DD22396447CA5C9A343687E9E91A25698654997C0728CACD83A1F62C838BDACB56D066BBC7FDAA55E11063EA8B4C3207B8A0EE802C97A50D55E85AC4914E7267598BD7088C8327904BBE280E64F1D54931A0CB917EFBC7407F84F26C344425EFC8D540F7292E74FFCD8B770FCE37B60E997C4838F8014E4B0766BB40462E2AA69F8A0B7CD4C47497F86EF7ABEFC38D0CB1E0FA6F30CD385ADC1AED49EF8B69C153DA373F214B0602BFD25794F2897B87C313A780663093FB6636C3D7A8FF11EE35110DBCDE51EE611C45CCCB2165B5524CA45D2BE4600E8B344995CB86CE0937D9A5EA2F0EDCD0DEDEE7270E468656B1518C5D3A61E4DD1AB5B5FA428157FB695C2DA5638D065536E505531C83833292CCB48B775B10597650655136AABA0E068B97D60EAD4C705322CDDAD611A78614FEA30FD1D5C2F6FEDE86C6A0B0061E02CB87DB1B97006EB58D1CB82D757302E1CC82C5387CFB399D3E45B53050F328334A83357A1BC7E9ADDB910F4BA618BC6822C74917BD6486A5066B7CB6D082A8A9B9489BAB1E3012EFAEC454661AA055B8945F644B4ABDE30442905592908538BF18F5B9C410FE4B9D75470A5137D2DA9A008428B8F5DC1C7E38567153824F046E17E941DC53585CEF8A253EC1A45B9A7830775F929F426533D66CF53F8A04CA205D0ABFA1B80DF036C38D665D68EABFB651D39D991DF4CBD454E81B63653F5C96424E0A847997572279A857D3044C155E3B8AC466590921511CA03DC81BB34896C25C3F45B27E0CA50075729F071D2C9DC12547200FB3403E82774E3D9BC6110A01D8E40A04CE0E628A57DE51F0D9C2D7292FFD245A189D88D7AB9CAEF4910B3A32CBCF05EEC4347E02AC4D03CDDA1650DAC4A78655D52A18253E366072CF4329C96DFDB612BA60B9AC02674A961DAA4AC62A5EE70401961E27B0368320B0C2583A06446361222056947DD2836A09C54E1AC8159171FD8C1434A2164722A2112A3F27DE2D863B4F0FBDC7C0DBC505F7DA11CE299C27BD7C9884815587ADF4D6D677721EC8D4557A2C20349A1EFF93E3CD898052F3EAD81CA13419FA6771E08623F2CE8ACC266FE38B8808F0BBBE55D90925BEC1EB89391DC42437F07C9CEC9643162F0FB2170A4E1C1E1B7014E66FAE487D089122B2FD26D02A2C4DAF7CB4FE23C4D42903D7152226A82F2425C752805E54658B91F61F90B4B4B41ECE4291427804CD4F373708753B582920174C41D7379AC0B3EABF69A984BDB82AD13F4BBF05BD3703382B37747E95BEA225163EDA5BA73E2E290815247610F6A576548B45F2BE13E58BF8C58C8EE047E21EC01B0AE0F2E05DAF8FAE138969AE6C287084DC4FB9EB0660304D96552344F14938BBB03EF8279885A83FCFA876B24A7D505E010E4E702869F8AD44A0642070881AD1FE047A2E1A44EC62186A6A993F1303853EA08431D3526638E75C2B939D0167E7B240ACC1126508D34D272DDA1F301B6E8808C3BD848B32B254A989E6A2C07845767E01F890BD5C38DC922EA31C73B63F588A3527F3DE89844B9875E98EFD12838F999ADF43C59FFFCFE3DA02AE5DE6EAE2DBDEDD00A4C7EFF72F109B44409D7ABD00CD31583861B094947D7B7ABF5F00375259CE1469A56843BD44848562F45743CE4DAD602D382E6C60ED34670790BA894940E91B4074BDBBC83E8903852909521F18873F5F9037DD4B71EFD996CB320EFCF2664009A38393A8679F081DBA2B18763E4A8B60B93AEFF51A7C0AFE3C2BE7CC71F69061DBE6F115D0A56A13F15AAAF8890C0B5C8AA32B113E74BBBC40C675239D761E9D341CA33FF384595CF3A01C56B0DE373AF61FC5A23D8C0FEF45A23F8B546B0F5D0AF35825F6B042B007AAD11DC0BE0B546B022B8D71AC1AF358295C5B81FB546F038556EB1B6861C6AD0702FBB6A329AA157BA5166F0BB8784252C9F2AAA6B2AACCA0790AE12C6B80A878D7E410DDC711D541F37BA65479C149F1057DE52D35CF78410983C35CB539E79F720A4D21EF7F0128B51D2E07E3FC23078321D55989B076F6726838CB14B9FC09F49806B670DB929D43083EE0AFC8EAFFA38C6E69101A7430D33E874EE52F43F80471B7236CD28834E26438F5C1F072F0E76608E230C775E82E8E0F9C72532D5FB78DBD4CBA81231C679D19320CB29358C299C43FB71F1B2D30EFB497C17A49133DD6C0DCD3DA61009DD74600C7B0B6B131ECEE58ABBFF011B474CD3EDEE8FD6D29F7209932E51C24F9EAA9D5F9844591233C9C14DD97B0ADE303B0F06CAFCA1127F6990F26357B25ED7D161858F78652C8D33D407FA4851BFA1DE515CAF54E5EBFFAEFC21703E2BE772760A43E8658EF8DB11D8B627C3A3FE55DABC782A4AEFAE8451AA98BF8A24D7B413593DDAC105CCBD20B47CBBEF0810F5D7B8C9B3BF7C4FE8B9761C3D1815FA92DCD2E8371F6DA577CF6C94CA3758456DA52C68ADA3B9CEC0A1FA8159752BED838247A94811A7049FD9C371C629F77DA0B15C641AAB2E6497B2D81E3BC50244615991DE51E606B3A4CC7F960575F6B4A7ADC93CBF1353AC236829C4E528B0ABBC0BBCDC4113DC377A6E83CAB7C66635997E0593695D31DABC5AABA7C9F1830CEC92D840FDEAB9E17DC7F1CD1DCD44DA5B73DF147B40A5CF8C050077E9EC04B78B894EA2C4277FB20F3F6F2F3488E1A30530BB95766453EA7F89FD6C9283514DDFAF01EABCFDED5ED3A7F856C46C9DF887F6B771F72A2AEFB7BA60CB1FD72B5CD27E39DF80CBF96632BD9C9BDC744DC529EC4DD854AD01FB0067160D0CB3F52A82A55668B012AE8E1E1658B895E6E650AD348063E8B330696AC4F4C8E13FE9DB1453046ED831AA7910BD1C9DBD67A0B9381EC7FEC47DBD5E4E36EB5BA727EE5B12797956B83E716DB03FDC8923C700B4CD49AEA9B41CA3A4D5814FDC2BE73829E710EF0BC998D1AAD235D4EEB81EC99E1B2EE6B34F97B3D5CA293B0C03B8DDC33475CD0F3B707F3886F8CA48CE8191681EBA8BD964315BAD2FE737E5915B9B1CB51D4498A5D93E385447C1EC6409C0B4D5EDAECF92675D4C736B0DC1B787E04A33769A77F84F6E35B5B37F5910739F6FEDF8450A22525350E3E1FF52A9FC3C89D3D969D4A4F2E5F5C56C6141E87428A52E89AB14A6FA81D8EF0F4A98932C4BFC80F82255034C57EBCF60B29A4D00FEAB4395B378F766958455B77AF4350CEFFE56FEB02CEB4E063E1AEBB7B7EFFFF6B70FCC84DA30C8500CA0EAD736B4FF9701854E02C4913181174E933843A2305A08F6D804B11F1CBC90C6BCD3897BBA64B574DE1DA1765B2EE001E7F089736692D6631E41778E7ADF32FCFA8EDA6685DDC7F5BEC9EE67D2ED2FEB82335B57FEAA4D08BDC4E470FB3915CD65FB41D9E32C0941694CE97023D040277B0D79D58379FC80A0E38AAFA5DB55E57225A6906E0E1C7A7B99B6F64E7FE82ED3AFD7F1050C610EDF4C888D0D2DA697F9DE8E6355470808A94C3A8F16F9C97B0E4297D29C41024A912709D2204DF51D966332E765121A83662BCF8ECDE4EBEC0A5CCED79BEBD57F1A3F0F24627D9E092995F76D8B1CF81DC6A1D93A08744159CF4B1A6DB70C4293DC89AB90C3BE2CD80CB8554035E8B235479581CBB53E191952A91BCBA55B5C7F11D2DDB1736B5FA95FBB1426BE40A9D138844B7E1E84401A641599445FCCAB3A6D8816D862EC51EED60DB8FEB49EAD7E9F10F457B3F5ED62B306DDDFE7CBC91731C71240E9DCB1823EEA54C5474A3648D563A00B923F2195DD4F618650E2977FD7A23A857D3244617CE263A98EBBA4628290129C15A55910F430D4A64666C916D791214B3E00ADE910BC122623915C2386CDAFD637B3926F9B901E0F104322FC4ECF9D14B9B3522184FE2095710852018F91C871BEBC59CC961C72EC5FE30E99F0203174C2EFA4478FCE08DF214572E7750A8A343F1AD12184A4FAFA19116743923793D56439DBCC56E53DCD25DB7E31910B9025527E2F3D2A9560A8722806171EF99354A1948387D333E09C8B5837674DB1AA5B698CCDE989B5699922E16933B9EAB9DAC724531E6E9291A84E3F0069F66EDCD913A5E87A3765A0635DF267CF3ECFE5C2B7649FE773D9ABAD6A9B4CBAB4E082CA8CC8D91D6529EDDA3D7460E7B022631906A3F3B6D56C7231BFFA02D0DF5D95BC3B7A110D478314F679FED4A2B4DA0204A8B7C5E96D1168D5C4765A87560805727BFE760755123C1383434305AC0DCD860ABA737162ED9CD56BC6583B3B2D2F8DA8DAD35319FEF8C5E94CEE37378BF9B4D4042E6EC172B99908C98BEADB3650D2BF6BB90CD523D2D08EBF0D630CA77055D921EF70B0270CEEC21A0C38023D54A836E50BC5778EC6E6C96840936939A2039D2D89A2DC73C21FB45853CFA823D0C272F275A64208B85F6BF3CA1FB438C169A88020AAB4194DC99CD108A08C09938E3C1611F4DD0C4A14705E17C1C85BAFC56F4EBCE508D73A06747A395F5CA097D3A29210E6EB6EBAA5D61E569F75B7F1F8F3681EA21877F49FF2D9B7604516619FA12E9B7A0954F6BFB70AA49E4F286F9E2A684CF741B89B96B89C4C3E2D436C36D7D70B430FE606408B00E89FF5BCDCCFDAFF989A96D215D324F43BA9E331C1E35C680C9F17F20FB959419BB006667714CA3C4E4737BF2CD293ED9760F00D1AFC1CC8AD9D7061F66FF1E56AC6C6062138166916A356EBCB21B79EFD928C7D52FF3D21C551293EA61387C427BB40A5188829A9DBF1A512956C4B446830C943CE96CAE69BE589A90C63A04465A4E30F4065CC963C072AA37C062E669BC91C5DFE91770FFB9E01CC671C52E0F4D17A2030508858B2968F54F71990DED879A9ECBA72667D5D4A6427AF824E532DA07C5E9C4C88C3FA9CB2BCE1BAD8028162CF5CBFA96037398ECE28CDA8969766626B4FCFD5F0A3D38BD48A6BB8B90349FBEBA72C871163CAA57F1ECC40A3B7D355F7A6D8A8059D51D35319BAEC7E26CC4889DDDBD39BEE35687EE1BE088AB2B9846FA72726B0EEB59B8175B083224AFB700652181FE3B6D39BA0CB8F208309E6AEA43B136C3A5047F384CF84F5FCA24FA5EB843C47A14DEE19F8C1C993F9F4C47ADE3AFB46EB1F3815470F154E58A7EE7683AE2EA435B6086CDD3C200F9CA83B6BCBABF4E8DEBDE2C5371BFE145C4CBC84123626E55FA684A44C99035DA0A307AD6853EF7984A8084848FD793030359DD30BE14C68CCFA1A3E2772ABE42E91CE7B404F8D73A5AF9328FECD684A8AC1C89E68EA9E19E7E688766ACF8CD3BB9F69BA679CDAE98C223B6942473B9A9385601967DD7CF624639241B37FF8718986FA13FF479C34C129D530A3F241D68D2F8C6EE46BFE4C0887E46C16AD217FAB99F4CD4C9B09052992A373AAD1C8E95C6E9D9BACCE66647BEA14CF6D8E536751C2FF5CDF7EE2ACE4808C873B780732BFCFCB6343FD1B618CC6B844D5091A701CFDA1E067FF1AC5611FC571E3E1899E9144ADEEF37C2EEFB8F370783E1DF999793D9F1B3733F27C767A4F9EB3E7F3B9509781FBF3B3213499F3F338847606CECF674868AA1ED06741689C594C278B2958CE3697D717DA114522407D64D2EA6AA0963FF56DDA332525E5385B80D6F7421F4430DF2727BB760DB11A2B93803A7DAA679578C142DFC8590ACC48EED4F90AAA028C7D392A70AF364195BF9C75960A82A2D22608AB48EAEA2FD4F35448871CE32EACD4A5D27D675451065AD191775D5963E44CFBA9BCE7A7D6793699F0E4CE1AC3E446B4F28579FED13746FE3167128073BB9EAD48394C30BD5D6FCA88ADE18BA3F2466DC1E47778092553B933B31E7E044AB9805E08D36C1F1C08E6D7CBD94A1C57DA746E6D2BFDF338BE2615A66D823DFE380841519354D9D7A63B5F0DADAE0EAFA7E562D47109EA3683E9C4F761962DBD8343AAEA6343ED615B0CA8D3F4A22845B6DCE74B2F357D837E166ACA019ECD9DA573D4FD22CB9308A6A7BCBBFA5018957CD4988D16E19C39A33915BDE8F39973A014AE4C3C762E83736237277C5B19B39C33795F350F7345B6E3988A4ECC784E4939FACCE74C68865BEF9DAA75F05CEBBD9FB602C2A9EBBDEB97413871BDF7767828D629F72FA130BC96D136B3ADDA15E1ED887C80E85D759FC62A86D68DA2DA98B255B03815BF53D6633B2106CD98B95328B84FCDBF8CB4DC250BBB2C31385D35171E81DD4ED7FF596F66CBE77B9F9E2A07D5A92951330BD589AFD14EE4963CC9994588DB501AF4243A24314F68EBB40C54134F3FEC0D49F171E0A0445E7B7E2A231FBF381B62D3CD6A707EF4777EE1EAA7A449ABA875E20227C5632CE5DA66F2693133AC5CD10060D561D5CFEA2F89F32E5B41CD4965838BCC85D2D6BE6C05D6BC9C8C0376E8EBFAAA57656240502FF0A63D0DAD695FB1E7425B8D3DD429A71A84B0B4CDE6CF99A4346DEAD78F314C4F4F4E8D7677727B81E436F2AA12EBD69CDE8182B1B9E6874E979743362A1B6082C0A9C8E859DC78A735089C86CEB4AD00E772E3A9E9CBCE85B44EA51B3B0951692AC4CE86A274FCB89C5E79E7E45C71128A3176AB38A3CB8E3707718E756DFA7946FE39CF8B84A26417DC057007CE82962E6693C56CB5BE9CDF00D1329EE1F5D6419D45866E7B6134474DEDB9712C3517B0B321B2133B8F9D86C4F4DDC64E4D61840963BC47BBFC9462C09E33152807854D53E8E570F7E9E9A442F5910254FCDA5DC4EF9DDA9F7DE4983D033FF61347EB95E82EE0030CF1E6A81247E7B3B6A74BB7ED87B884BAB356D9FCCE37825A2B43925F0783D331A62A67C664B3994C2F4B2FD2CE6F9FE78BD97AB39A4DC459A03850B8090F5BED466915599C24E3D0BD8661739C7929319F2ACD8D97E79EBF77E465AAB86D0E501A272F199D8FB4CE9841FD264B49D6FD5496D2D520AD068D8518F27089C818F43536D859EA0DE156588CEF9CB066E89BFC097D93A32F607A7403DBC1CF419AE5175EEE6DBD8C75F7C35FAD61CE67D66FDF941D6457EFDADFC3C8FBEDED6E8B26BAF1B69C9B2AE310597BDCEEFDC90CDBEDC01BB5DBA767CC52D864462A7FE6C12F5B14A08209624602D0559B087ED5AC3248799CF983946DC241CAE6BE3DA19E64EC7E508DDCBDA0DAFB26237767622728EFCF9DB4FC931E04196F430625A6070F09A653DFBAB45D6DD87568B78BE64DB91DF58DC87720675900B71B970F707BF660D131B832C377DA79E3768CCFBD2336218DEC684D9B7424D5C55D5C7F112F2969942C2469EFA5563E850AA9B21F757C01CE97378B1959523ABC84378EA0AB6070416F058C1AE2EEC588DF558411BFB70246D79F10D7FBBD4CC5BE9AAD6F17B88A0717216E4F113EDCCE9AE854D58B7A91A9FAA9A05275D543446141D456426D0978C4255D0BD9073A14ACB13AD44748C49C2C679BD94AB44C82BE42CCF8DDF5909AA2C5DE4CAE84B4CCEFAA8012D5BB07A3668591747431BFFA02D0DFDCBB49D893878FB0730F3AC7DC82CCF0C716DE70C7C6BE9BE2E666319F4E04FCACD5CABD2BE80E3D4395195B9931CA9F79C0CB961EA89CDCABCC109C3EBCF138DDFA37E7F82CE5EDCFB151B045C77605B1955BDA822BB0727B8A44366E674574E85A75424CE84E3224E87E4A7B5E1681146C76D928DEE5B25D8BB6BA99F77BC8ACDBBD9FE2BA5F986247D2B5AB6347BA6B6147BE50C28E139C24408CD3538C13A7B32E3A84D278D78CB0A7123A756705AE9EEC8A108275B115F076AA5DC4E1A92E3D03D21E80CC687423F781DDF281ECBD4005D5EAD9FB53D0917B7D0AFA6A6EBBC27EAB6DB4E2C813F9A893DE1127FAA3D555DBA563D69DFA46AEFB295F84754141C9755877915F8A752FF591054A2AA647CFB84A0A2B610533DEF0FC9E0234F89DF5EF82564D0695DBA0F581E27DD0FAA64FFE2B13ACB30260F93B57022C9BFA26CF5F78F12AABAB24194746BE7292E9265453323DFB44AD63E63D56C03A3671C5AA636BCF08743C143306DDC81B858E07D3E351823D63FBF4732895DD1485F28875709D8E72D55FBBAF0A65D19E8A7CA2A27B08E989EEA4FED403B3D5EA7A25D20FF2FBF53CFFE8AE1A8810BE7BF579DE8708D5AF0F11AAABE23B8663D8163E67387D65AF1A4E773DA44496175E2F0544140F4B994641AC96677AF08F47A793FA199D8AF4779C3E3D27B3EEA6677891CC5DD853C110A3BC16580A10AF42AB55A4FD529F39A586EE536A2B68B21507141C7ABA513C94D2F1C65D67BFCFC4DAC4BA51344EDDAE3C4EEF3AB2DDE4636BAE6AF591CCC6C4EFD68385BAE589FAE8A8F194634175EBC182EAA9A5555E83DFE7B33F663C3158D4B15FA3DCF455C265335BDDAC669B49A58C5E2E256429EC2DC64AF081A6E18694F4EDB7DB94DD54CC36654F052CD6D3CBD9127D33ED3D41DC9E225CB89DB5D091D96F985EFD68A8E9371B5B011269665FF8D710AF93DCF0D0F4D37ADCF6BE69559EB2BA0F6AB5C7B4F2435AF54D2FE359ED66C1A0EA3CAAA5BF0355AEC03E5560D3AF5725D874ED7B976F435055849E946E8A774108B33C855EC47BAE4BBB735FF1D22F14B0BB828F47470C0146ED2E222CDABDD446EEF7C811759460A1EB9F833FDB9044568D22548009DB4D8407DBD3008BCAB3491199636F559C8E1FE82817647788A863AF9A41FD0611DA4D2EE7F80D36D731CE1C3FD132D01CBF32C5F4EB35BAAFD6B73A981E3FD1C2F4F89529A68BF9ECD3E56CC55390297CA3856BF39912B254882DF95E6C6CE2F41423C6E9AC840E62353D68503DC4C3539D9486ADCA71CA476E77120FDEEED7199F7256E6B8C896D5DDDE509DBA8EB29CFA6FED6009CA87170DC0F7D165BE68F9E71E3FE3BBDEBE6B4F41757A657809FA2B13CE8FEAD2832E2D7835E8F2E427FDC5319860577FD2E35DCB4E5F0F807882023180CCB5E73667426E7A3D90CB15D47224D65F5A6E7AE8AE172FBBA02A9F89A72F73FB25B35671E36D2F28CF75B95CC0768BF58275958AA5B29B5D216E3FF104186D0D415EA872E12D27A5C8A71791A78C3739825CB75020F0D1E41D411D00B22328757BAD8EA2920FAB146EEBCDCF85CA7FC65B2F2DBB2447F47B5755FCADF2C4A52BA9B784165B63B88C3C476ADDE5D482215F0C99C3F87135549CBFCF6C99B9FEC7E2B9F0D7590F887C3964B102C7F550F1FB1F6E0B4D979AE7500DFA9CC0052B6E02AB67E165AEE4CDCAAB78852B6DAA802D6B38C43BDF06AE7BB9F606F0A09C70E925CEF83CD062C77AC70CC680E80D409D8AD99C13C58B27C15F67617FE994BBF3325A22A3C5B7A6CC4E04471FF5B5BBBB5B949E4815024335ECC4E63584F0E43EBD3B3D867901292C9AD5E4CAB7A36C72BC04A48E26C70D4F2DBF6FB7D82B03DA0E5465EC10E7F1CFE926799DB2C145E5F3541C35D4FABE13FB44BE150536E94FB982D43837708998D3CB09C236346230591C4BD533D36E1731BA742417C19417A9758A094A28B7D5EE726A8313696D89985ECE1717C720ADCAB7824BB0B22FA413E958FCEBB9086CF88C5E5312A276D468AAC49BE92F5313D4A5AF2156FE563C7936208DCC571C6A76A62AE1CE5274C3F27AD7AEF3C1900BC68F3F6C919924A2D06A693871A2D29561FB0FB530C260580A882CBED5E1B27483193556A8F3E9388BC58FEEE4AC5B4F94E6304B48222ECD96107F3AFA125221A8F225E485929A2E2113150AE691770F254C5FF845DF948571ADD46C7B8354E570DB01AA7CB88268533359B8F11CA3E432BE40CCEB3ACC0B881B287B94B1C4F1AFB64B207AF6717A3947BE05830DDC2500E89F1D4F5D48BD7DABA158A5D1F102393C90064BC78F4B162DC507DE22EA82189F37C923BA4B3D935A7CB63BD6BE9E5F48245241FF1F71E96A870A4E50B768F5C49FF42DE084D5CACAE2D88510DA31EC0C1C4154BA03EA6A63AB405EAD0FD4E94B4A58CACBA4BCD0EE9646E95E50FE76BC053BD50521E247B484ADCEC5A8AF8695E94FB55CB4F64A490321FF60686DD7981A086AA68CC3A1745D7A2A773B5B140B1749BBE560938648D783E93ED48288B2A2746008329D582D499DDAFB88A67445BABD95A6C4780AF7E450B15B586B0AE1E755E92314EE5703D28B2CA94C0D4A29438CD5727514F42AB606EE272FD3D840D3B98A2A58DA7FA8251A5F152C9C66BF2A58F5D37116EB74AA60957510A882553F1D7D094FA20A6E81A79254E9D86E3460682D0B273197686124E9B54E7CD889395D6931053D5D9AE04F30FD32104DE26ED0EA20992C9D14AD9C2D2FE7D9881E07B52C289A59AB5DB2275DC14545241C705A8DBF16AB3C90797731BD87B17358A93B0C9683978C4E182229EE2C11D1B4A3256509F70804A5047AFA4BD1E4B00375D23CAEC990DB4F3C1D36AF1E9904FDB34CC2EDE4FD2B975094D3CF6AD2DD5236D299CB8BB2399B3EBF464F4905F2CA3B0631B4D5AAF20BB3F3226AA51F38DAD3B3381ACD4C7B6944D47590E518913AB8BC4F6A20EFF96298FBE35414D25C94FD2422EC3BD0928C4825DCA0E86E65208E3BB5C267E209BA8FA51ECFDFBC6DCDC322251FD93E13A5F04B553B2323A6B2ADFDF1D7765BE08ADE54045BB50FC7A4B9B1255FEE0A7432DC2BAE5BFBAB31176D0CAFA06EE60C914B14B7DF2056A2B6F8305ADE87EE04350CE1AA9F0EBF5CA735EB36251AF5FDF395BFED918E5AE5251B99885B3892B1369C877F7E6729E4895AC49D075BA8D18E2435B7560A7AE92AD03D875A02ED67AFDDE44519E8A5EB20F868A82591A7DE6F0BF4F244FA8E964AE1C028CBE0964B339ABC4DCDAD57D611F61D6A19C69066E84929EA79FA3E196A394EF596EF992FD779B9F79B17B948540E461A5DC1F2F07B0FBA306C75910684A464881DCDF42A80C49D075B8C31F5C898D63054611646D23898F0355006C623E63DFA5F4E37A7D6A131B57904D8023EC010A72A55987DCF1712D540FBC3B656A0DB7626CB539BD2A99232A0F31B5DEF86432B5A00E40F3341A99CE373ACA7F68D0C1E5B0F88075552DAC7C801A89BB6BEE38528F0FDE9FB4A6A761725DEAF4DF07D99F425F024A03496EBD77725946912A3A7740CD363DBAFEFCA6CC1D50FE89FE8E5EDDDC365B28361467EFDF5DDAA405F47B0FCD705CC82FB06C4AF08665C86DF3440EB3EF3F82EB94993034CC90C688CEA2E7573ED1882DEFA3B2FF726691EDC797E8E9AF1C90BE2FBB76F7EF7C2020BFDD116EEE6F175911F8A1C4D1946DBB095A5FFD777F2F17F7DC7E0FCEBF501FF2B733105846680A600AFE34F4510EE8E787FF6C2ACC3844420A668F5BF40F47BB99739FA3FBC7F3A42BA4A624540D5F25DC0038C77E835B481D12144C0B2EB78ED3D4013DC103B5CC07BCF7F42BF3F043B7C5D8B80F46F447BD97FBD08BCFBD48BB20A46F33DFA27A2E15DF4FDFFFBFF016D34F5B93C5E0900 , N'6.1.3-40302')

