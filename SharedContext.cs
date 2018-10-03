namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SharedContext : DbContext
    {
        public SharedContext()
            : base("TTDALConnection")
        {
        }
        public virtual DbSet<CURRENCY> Currencies { get; set; }
        public virtual DbSet<DEALER_GROUP> DEALER_GROUP { get; set; }
        public virtual DbSet<SUPPORT_TEAM> SUPPORT_TEAM { get; set; }
        public virtual DbSet<DEALER_CUSTOMER_RELATION> DEALER_CUSTOMER_RELATION { get; set; }
        public virtual DbSet<DEALER_JOBSITE_RELATION> DEALER_JOBSITE_RELATION { get; set; }
        public virtual DbSet<DEALERGROUP_DEALER_RELATION> DEALERGROUP_DEALER_RELATION { get; set; }
        public virtual DbSet<DEALERGROUP_CUSTOMER_RELATION> DEALERGROUP_CUSTOMER_RELATION { get; set; }
        public virtual DbSet<USER_SUPPORTTEAM_RELATION> USER_SUPPORTTEAM_RELATION { get; set; }
        public virtual DbSet<USER_DEALERGROUP_RELATION> USER_DEALERGROUP_RELATION { get; set; }
        public virtual DbSet<USER_DEALER_RELATION> USER_DEALER_RELATION { get; set; }
        public virtual DbSet<USER_CUSTOMER_RELATION> USER_CUSTOMER_RELATION { get; set; }
        public virtual DbSet<USER_JOBSITE_RELATION> USER_JOBSITE_RELATION { get; set; }
        public virtual DbSet<USER_EQUIPMENT_RELATION> USER_EQUIPMENT_RELATION { get; set; }
        public virtual DbSet<UserInvitationAccessToCustomers> UserInvitationAccessToCustomers { get; set; }
        public virtual DbSet<UserInvitationJobRoles> UserInvitationJobRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AccessLevelType> AccessLevelTypes { get; set; }
        public virtual DbSet<ACTION_LOG> ACTION_LOG { get; set; }
        public virtual DbSet<ACTION_TAKEN_HISTORY> ACTION_TAKEN_HISTORY { get; set; }
        public virtual DbSet<APPLICATION> APPLICATIONs { get; set; }
        public virtual DbSet<APPLICATION_LU_CONFIG> APPLICATION_LU_CONFIG { get; set; }
        public virtual DbSet<COMP_Inventory_Inspec_Details> COMP_Inventory_Inspec_Details { get; set; }
        public virtual DbSet<COMPART_ATTACH_FILESTREAM> COMPART_ATTACH_FILESTREAM { get; set; }
        public virtual DbSet<COMPART_ATTACH_TYPE> COMPART_ATTACH_TYPE { get; set; }
        public virtual DbSet<COMPART_PARENT_RELATION> COMPART_PARENT_RELATION { get; set; }
        public virtual DbSet<COMPART_TOOL_IMAGE> COMPART_TOOL_IMAGE { get; set; }
        public virtual DbSet<ComponentLife> COMPONENT_LIFE { get; set; }
        public virtual DbSet<CRSF> CRSF { get; set; }
        public virtual DbSet<CRSF_AREA> CRSF_AREA { get; set; }
        public virtual DbSet<CRSF_TYPE> CRSF_TYPE { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMER { get; set; }
        public virtual DbSet<Dealership> Dealerships { get; set; }
        public virtual DbSet<EQ_UNIT_HISTORY> EQ_UNIT_HISTORY { get; set; }
        public virtual DbSet<EQUIPMENT> EQUIPMENT { get; set; }
        public virtual DbSet<EQUIPMENT_ACTIONS> EQUIPMENT_ACTIONS { get; set; }
        public virtual DbSet<EQUIPMENT_AUDIT_HISTOY> EQUIPMENT_AUDIT_HISTOY { get; set; }
        public virtual DbSet<EQUIPMENT_LIFE> EQUIPMENT_LIFE { get; set; }
        public virtual DbSet<GENERAL_EQ_UNIT> GENERAL_EQ_UNIT { get; set; }
        public virtual DbSet<GENERAL_EQ_UNIT_HISTORY> GENERAL_EQ_UNIT_HISTORY { get; set; }
        public virtual DbSet<GET> GET { get; set; }
        public virtual DbSet<GET_ACTIONS> GET_ACTIONS { get; set; }
        public virtual DbSet<GET_COMPONENT> GET_COMPONENT { get; set; }
        public virtual DbSet<GET_COMPONENT_INSPECTION> GET_COMPONENT_INSPECTION { get; set; }
        public virtual DbSet<GET_CONFIG> GET_CONFIG { get; set; }
        public virtual DbSet<GET_EVENTS> GET_EVENTS { get; set; }
        public virtual DbSet<GET_EVENTS_COMPONENT> GET_EVENTS_COMPONENT { get; set; }
        public virtual DbSet<GET_EVENTS_EQUIPMENT> GET_EVENTS_EQUIPMENT { get; set; }
        public virtual DbSet<GET_EVENTS_IMPLEMENT> GET_EVENTS_IMPLEMENT { get; set; }
        public virtual DbSet<GET_IMPLEMENT_INSPECTION> GET_IMPLEMENT_INSPECTION { get; set; }
        public virtual DbSet<GET_IMPLEMENT_INSPECTION_IMAGE> GET_IMPLEMENT_INSPECTION_IMAGE { get; set; }
        public virtual DbSet<GET_INSPECTION_CONSTANTS> GET_INSPECTION_CONSTANTS { get; set; }
        public virtual DbSet<GET_INSPECTION_PARAMETERS> GET_INSPECTION_PARAMETERS { get; set; }
        public virtual DbSet<GET_INSPECTIONS_VIEWED> GET_INSPECTIONS_VIEWED { get; set; }
        public virtual DbSet<GET_INTERPRETATION_COMMENTS> GET_INTERPRETATION_COMMENTS { get; set; }
        public virtual DbSet<GET_OBSERVATION_IMAGE> GET_OBSERVATION_IMAGE { get; set; }
        public virtual DbSet<GET_OBSERVATION_LIST> GET_OBSERVATION_LIST { get; set; }
        public virtual DbSet<GET_OBSERVATION_RESULTS> GET_OBSERVATION_RESULTS { get; set; }
        public virtual DbSet<GET_OBSERVATIONS> GET_OBSERVATIONS { get; set; }
        public virtual DbSet<GET_SCHEMATIC_COMPONENT> GET_SCHEMATIC_COMPONENT { get; set; }
        public virtual DbSet<GET_SCHEMATIC_IMAGE> GET_SCHEMATIC_IMAGE { get; set; }
        public virtual DbSet<IMPLEMENT_CATEGORY> IMPLEMENT_CATEGORY { get; set; }
        public virtual DbSet<IMPLEMENT_READING_ENTRY> IMPLEMENT_READING_ENTRY { get; set; }
        public virtual DbSet<InspectionDetails_Side> InspectionDetails_Side { get; set; }
        public virtual DbSet<LU_COMPART> LU_COMPART { get; set; }
        public virtual DbSet<LU_COMPART_PARTS> LU_COMPART_PARTS { get; set; }
        public virtual DbSet<LU_COMPART_TYPE> LU_COMPART_TYPE { get; set; }
        public virtual DbSet<LU_GET_COMPART> LU_GET_COMPART { get; set; }
        public virtual DbSet<LU_GET_COMPART_SUB_TYPE> LU_GET_COMPART_SUB_TYPE { get; set; }
        public virtual DbSet<LU_GET_COMPART_TYPE> LU_GET_COMPART_TYPE { get; set; }
        public virtual DbSet<LU_IMPLEMENT> LU_IMPLEMENT { get; set; }
        public virtual DbSet<LU_MMTA> LU_MMTA { get; set; }
        public virtual DbSet<LU_Module_Sub> LU_Module_Sub { get; set; }
        public virtual DbSet<LU_Module_Sub_History> LU_Module_Sub_History { get; set; }
        public virtual DbSet<MAKE> MAKE { get; set; }
        public virtual DbSet<MODEL> MODEL { get; set; }
        public virtual DbSet<TRACK_ACTION> TRACK_ACTION { get; set; }
        public virtual DbSet<TRACK_ACTION_TAKEN> TRACK_ACTION_TAKEN { get; set; }
        public virtual DbSet<TRACK_ACTION_TYPE> TRACK_ACTION_TYPE { get; set; }
        public virtual DbSet<TRACK_COMPART_EXT> TRACK_COMPART_EXT { get; set; }
        public virtual DbSet<TRACK_COMPART_WORN_CALC_METHOD> TRACK_COMPART_WORN_CALC_METHOD { get; set; }
        public virtual DbSet<TRACK_COMPART_WORN_LIMIT_CAT> TRACK_COMPART_WORN_LIMIT_CAT { get; set; }
        public virtual DbSet<TRACK_COMPART_WORN_LIMIT_HITACHI> TRACK_COMPART_WORN_LIMIT_HITACHI { get; set; }
        public virtual DbSet<TRACK_COMPART_WORN_LIMIT_ITM> TRACK_COMPART_WORN_LIMIT_ITM { get; set; }
        public virtual DbSet<TRACK_COMPART_WORN_LIMIT_KOMATSU> TRACK_COMPART_WORN_LIMIT_KOMATSU { get; set; }
        public virtual DbSet<TRACK_COMPART_WORN_LIMIT_LIEBHERR> TRACK_COMPART_WORN_LIMIT_LIEBHERR { get; set; }
        public virtual DbSet<TRACK_DEALERSHIP_LIMITS> TRACK_DEALERSHIP_LIMITS { get; set; }
        public virtual DbSet<TRACK_INSPECTION> TRACK_INSPECTION { get; set; }
        public virtual DbSet<TRACK_INSPECTION_DETAIL> TRACK_INSPECTION_DETAIL { get; set; }
        public virtual DbSet<TRACK_TOOL> TRACK_TOOL { get; set; }
        public virtual DbSet<TYPE> TYPE { get; set; }
        public virtual DbSet<SystemLife> UCSYSTEM_LIFE { get; set; }
        public virtual DbSet<USER_CRSF_CUST_EQUIP> USER_CRSF_CUST_EQUIP { get; set; }
        public virtual DbSet<USER_DEALERSHIP> USER_DEALERSHIP { get; set; }
        public virtual DbSet<USER_MODULE_ACCESS> USER_MODULE_ACCESS { get; set; }
        public virtual DbSet<USER_TABLE> USER_TABLE { get; set; }
        public virtual DbSet<UserAccessMaps> UserAccessMaps { get; set; }
        public virtual DbSet<APPLICATION_ERROR_LOG> APPLICATION_ERROR_LOG { get; set; }
        public virtual DbSet<Mbl_CompartAttach_filestream> Mbl_CompartAttach_filestream { get; set; }
        public virtual DbSet<Mbl_NewEquipment> Mbl_NewEquipment { get; set; }
        public virtual DbSet<Mbl_NewGENERAL_EQ_UNIT> Mbl_NewGENERAL_EQ_UNIT { get; set; }
        public virtual DbSet<Mbl_Track_Inspection> Mbl_Track_Inspection { get; set; }
        public virtual DbSet<Mbl_Track_Inspection_Detail> Mbl_Track_Inspection_Detail { get; set; }
        public virtual DbSet<TRACK_ACTION_COMPONENT> TRACK_ACTION_COMPONENT { get; set; }
        public virtual DbSet<TRACK_EQ_LIMITS> TRACK_EQ_LIMITS { get; set; }
        public virtual DbSet<TRACK_INSPECTION_IMAGES> TRACK_INSPECTION_IMAGES { get; set; }
        public virtual DbSet<TRACK_MODEL_LIMITS> TRACK_MODEL_LIMITS { get; set; }
        public virtual DbSet<USER_GROUP> USER_GROUP { get; set; }
        public virtual DbSet<USER_GROUP_ASSIGN> USER_GROUP_ASSIGN { get; set; }
        public virtual DbSet<UserInvitations> UserInvitations { get; set; }
        public virtual DbSet<LU_MODULE_GROUP> LU_MODULE_GROUP { get; set; }
        public virtual DbSet<MENU_L1> MENU_L1 { get; set; }
        public virtual DbSet<MENU_L2> MENU_L2 { get; set; }
        public virtual DbSet<MENU_L3> MENU_L3 { get; set; }
        public virtual DbSet<USER_GROUP_OBJECT> USER_GROUP_OBJECT { get; set; }
        public virtual DbSet<VERSION> VERSIONs { get; set; }
        #region Identity Entities
        public virtual DbSet<ClientClaim> ClientClaims { get; set; }
        public virtual DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public virtual DbSet<ClientCustomGrantType> ClientCustomGrantTypes { get; set; }
        public virtual DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }
        public virtual DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        public virtual DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientScope> ClientScopes { get; set; }
        public virtual DbSet<ClientSecret> ClientSecrets { get; set; }
        public virtual DbSet<Consent> Consents { get; set; }
        public virtual DbSet<ScopeClaim> ScopeClaims { get; set; }
        public virtual DbSet<Scope> Scopes { get; set; }
        public virtual DbSet<ScopeSecret> ScopeSecrets { get; set; }
        public virtual DbSet<LANGUAGE> LANGUAGE { get; set; }
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CURRENCY>()
                .Property(e => e.currency_code)
                .IsUnicode(false);

            modelBuilder.Entity<CURRENCY>()
                .Property(e => e.currency_name)
                .IsUnicode(false);

            modelBuilder.Entity<VERSION>()
                .Property(e => e.VersionNo)
                .IsUnicode(false);

            modelBuilder.Entity<VERSION>()
                .Property(e => e.UpdatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<VERSION>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<VERSION>()
                .Property(e => e.dbVersion)
                .IsUnicode(false);

            modelBuilder.Entity<VERSION>()
                .Property(e => e.MailService)
                .IsUnicode(false);

            modelBuilder.Entity<VERSION>()
                .Property(e => e.PrintTool)
                .IsUnicode(false);

            modelBuilder.Entity<VERSION>()
                .Property(e => e.IFTLab)
                .IsUnicode(false);

            modelBuilder.Entity<USER_GROUP>()
                .Property(e => e.groupname)
                .IsUnicode(false);

            modelBuilder.Entity<USER_GROUP>()
                .Property(e => e.comment)
                .IsUnicode(false);
            modelBuilder.Entity<AccessLevelType>()
                .HasMany(e => e.UserAccessMaps)
                .WithRequired(e => e.AccessLevelType)
                .HasForeignKey(e => e.AccessLevelTypeId);

            modelBuilder.Entity<ACTION_LOG>()
                .Property(e => e.action_desc)
                .IsUnicode(false);

            modelBuilder.Entity<ACTION_LOG>()
                .Property(e => e.actioncost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ACTION_LOG>()
                .Property(e => e.manuf_comments)
                .IsUnicode(false);

            modelBuilder.Entity<ACTION_LOG>()
                .Property(e => e.reimburse_amt)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ACTION_LOG>()
                .Property(e => e.workorderno)
                .IsUnicode(false);

            modelBuilder.Entity<ACTION_LOG>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<ACTION_LOG>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<ACTION_TAKEN_HISTORY>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<ACTION_TAKEN_HISTORY>()
                .HasMany(e => e.COMPONENT_LIFE)
                .WithRequired(e => e.ACTION_TAKEN_HISTORY)
                .HasForeignKey(e => e.ActionId);

            modelBuilder.Entity<ACTION_TAKEN_HISTORY>()
                .HasMany(e => e.EQUIPMENT_LIFE)
                .WithRequired(e => e.Action)
                .HasForeignKey(e => e.ActionId);

            modelBuilder.Entity<ACTION_TAKEN_HISTORY>()
                .HasMany(e => e.TRACK_INSPECTION)
                .WithOptional(e => e.ActionTakenHistory)
                .HasForeignKey(e => e.ActionHistoryId);

            modelBuilder.Entity<ACTION_TAKEN_HISTORY>()
                .HasMany(e => e.UCSYSTEM_LIFE)
                .WithRequired(e => e.ACTION_TAKEN_HISTORY)
                .HasForeignKey(e => e.ActionId);

            modelBuilder.Entity<APPLICATION>()
                .Property(e => e.appid)
                .IsUnicode(false);

            modelBuilder.Entity<APPLICATION>()
                .Property(e => e.appdesc)
                .IsUnicode(false);

            modelBuilder.Entity<APPLICATION_LU_CONFIG>()
                .Property(e => e.variable_key)
                .IsUnicode(false);

            modelBuilder.Entity<APPLICATION_LU_CONFIG>()
                .Property(e => e.value_key)
                .IsUnicode(false);

            modelBuilder.Entity<APPLICATION_LU_CONFIG>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<COMP_Inventory_Inspec_Details>()
                .Property(e => e.eval_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COMPART_ATTACH_FILESTREAM>()
                .Property(e => e.attachment_name)
                .IsUnicode(false);

            modelBuilder.Entity<COMPART_ATTACH_TYPE>()
                .Property(e => e.compart_attach_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<CRSF>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<CRSF>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<CRSF>()
                .Property(e => e.site_postcode)
                .IsUnicode(false);

            modelBuilder.Entity<CRSF_AREA>()
                .Property(e => e.area)
                .IsUnicode(false);

            modelBuilder.Entity<CRSF_TYPE>()
                .Property(e => e.type_name)
                .IsUnicode(false);

            modelBuilder.Entity<CRSF_TYPE>()
                .HasMany(e => e.CRSFs)
                .WithOptional(e => e.CRSF_TYPE)
                .HasForeignKey(e => e.type_auto);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.custid)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.cust_postcode)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.cust_mobile)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.cust_email)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.companyname)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.cust_formid)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.db_custid)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.cust_billing_postcode)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.logo_name)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.quote_discount)
                .HasPrecision(5, 2);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.terms_Exceeded)
                .HasPrecision(5, 2);

            modelBuilder.Entity<EQ_UNIT_HISTORY>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<EQ_UNIT_HISTORY>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<EQ_UNIT_HISTORY>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.unitno)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.op_range)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.purchase_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.depmethod)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.uccode)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.regno)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .HasMany(e => e.USER_CRSF_CUST_EQUIP)
                .WithRequired(e => e.CUSTOMER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_TABLE>()
                .HasMany(e => e.USER_CRSF_CUST_EQUIP)
                .WithRequired(e => e.USER_TABLE)
                .HasForeignKey(e => e.user_auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.DBS_serialno)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.smu_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.smu_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.distance_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.distance_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.kw_hrs_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.kw_hrs_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.fuel_burn_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.fuel_burn_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.calender_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.current_smu_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.current_distance_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.current_kw_hrs_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.current_fuel_burn_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.current_calender_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.Sec_AVGDB_Hours)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.Sec_AVGDB_Distance)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.Sec_AVGDB_KWHOURS)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.Sec_AVGDB_FuelBurn)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .Property(e => e.Sec_AVGDB_Calender)
                .HasPrecision(20, 2);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.ACTION_LOG)
                .WithRequired(e => e.EQUIPMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.Life)
                .WithRequired(e => e.Equipment)
                .HasForeignKey(e => e.EquipmentId);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.GETs)
                .WithRequired(e => e.EQUIPMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPMENT>()
                .HasMany(e => e.TRACK_INSPECTION)
                .WithRequired(e => e.EQUIPMENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EQUIPMENT_ACTIONS>()
                .Property(e => e.action_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<EQUIPMENT_AUDIT_HISTOY>()
                .Property(e => e.field)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT_AUDIT_HISTOY>()
                .Property(e => e.beforeChange)
                .IsUnicode(false);

            modelBuilder.Entity<EQUIPMENT_AUDIT_HISTOY>()
                .Property(e => e.afterChange)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.compartsn)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.compart_note)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.compart_descr)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_before_failure)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_after_failure)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_calculated)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_calculated1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_calculated2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .Property(e => e.replace_cost_calculated)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .HasMany(e => e.COMP_Inventory_Inspec_Details)
                .WithRequired(e => e.GENERAL_EQ_UNIT)
                .HasForeignKey(e => e.equnit_Id);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .HasMany(e => e.Life)
                .WithRequired(e => e.GENERAL_EQ_UNIT)
                .HasForeignKey(e => e.ComponentId);

            modelBuilder.Entity<GENERAL_EQ_UNIT>()
                .HasMany(e => e.TRACK_INSPECTION_DETAIL)
                .WithRequired(e => e.GENERAL_EQ_UNIT)
                .HasForeignKey(e => e.track_unit_auto);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.compartsn)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.compart_note)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.compart_descr)
                .IsUnicode(false);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.rebuild_cost_before_failure)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.rebuild_cost_after_failure)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.rebuild_cost_calculated)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.rebuild_cost_calculated1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.rebuild_cost_calculated2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GENERAL_EQ_UNIT_HISTORY>()
                .Property(e => e.replace_cost_calculated)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GET>()
                .Property(e => e.impserial)
                .IsUnicode(false);

            modelBuilder.Entity<GET>()
                .Property(e => e.makeid)
                .IsUnicode(false);

            modelBuilder.Entity<GET>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<GET>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<GET>()
                .Property(e => e.bucket_width_uom)
                .IsUnicode(false);

            modelBuilder.Entity<GET>()
                .Property(e => e.base_edge_thickness_uom)
                .IsUnicode(false);

            modelBuilder.Entity<GET>()
                .Property(e => e.num_feet)
                .IsUnicode(false);

            modelBuilder.Entity<GET>()
                .HasMany(e => e.GET_IMPLEMENT_INSPECTION)
                .WithRequired(e => e.GET)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET>()
                .HasMany(e => e.IMPLEMENT_READING_ENTRY)
                .WithRequired(e => e.GET)
                .HasForeignKey(e => e.implement_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_COMPONENT>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GET_COMPONENT>()
                .Property(e => e.part_no)
                .IsUnicode(false);

            modelBuilder.Entity<GET_COMPONENT_INSPECTION>()
                .Property(e => e.measurement)
                .HasPrecision(16, 5);

            modelBuilder.Entity<GET_COMPONENT_INSPECTION>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<GET_COMPONENT_INSPECTION>()
                .HasMany(e => e.GET_OBSERVATION_RESULTS)
                .WithRequired(e => e.GET_COMPONENT_INSPECTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_CONFIG>()
                .Property(e => e.variable_key)
                .IsUnicode(false);

            modelBuilder.Entity<GET_CONFIG>()
                .Property(e => e.value_key)
                .IsUnicode(false);

            modelBuilder.Entity<GET_CONFIG>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<GET_IMPLEMENT_INSPECTION>()
                .Property(e => e.overall_notes)
                .IsUnicode(false);

            modelBuilder.Entity<GET_IMPLEMENT_INSPECTION>()
                .HasMany(e => e.GET_COMPONENT_INSPECTION)
                .WithRequired(e => e.GET_IMPLEMENT_INSPECTION)
                .HasForeignKey(e => e.implement_inspection_auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_IMPLEMENT_INSPECTION>()
                .HasMany(e => e.GET_IMPLEMENT_INSPECTION_IMAGE)
                .WithRequired(e => e.GET_IMPLEMENT_INSPECTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_INSPECTION_CONSTANTS>()
                .Property(e => e.inspect_desc)
                .IsUnicode(false);

            modelBuilder.Entity<GET_INSPECTION_PARAMETERS>()
                .Property(e => e.parameter_desc)
                .IsUnicode(false);

            modelBuilder.Entity<GET_INSPECTION_PARAMETERS>()
                .HasMany(e => e.GET_IMPLEMENT_INSPECTION_IMAGE)
                .WithRequired(e => e.GET_INSPECTION_PARAMETERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_INSPECTION_PARAMETERS>()
                .HasMany(e => e.GET_INSPECTION_CONSTANTS)
                .WithRequired(e => e.GET_INSPECTION_PARAMETERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_OBSERVATION_LIST>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<GET_OBSERVATION_RESULTS>()
                .HasMany(e => e.GET_OBSERVATION_IMAGE)
                .WithRequired(e => e.GET_OBSERVATION_RESULTS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_OBSERVATIONS>()
                .Property(e => e.observation)
                .IsUnicode(false);

            modelBuilder.Entity<GET_OBSERVATIONS>()
                .HasMany(e => e.GET_OBSERVATION_RESULTS)
                .WithRequired(e => e.GET_OBSERVATIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GET_SCHEMATIC_IMAGE>()
                .Property(e => e.button_positions)
                .IsUnicode(false);

            modelBuilder.Entity<GET_SCHEMATIC_IMAGE>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<GET_SCHEMATIC_IMAGE>()
                .Property(e => e.file_name)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.compartid)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.compart)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.modifier_code)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.parentid)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.expected_life)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.expected_cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.companyname)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.track_comp_cts_maintype)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.track_comp_cts_subtype)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.compart_note)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .Property(e => e.hydraulic_inspect_symptoms)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.CHILD_RELATION_LIST)
                .WithRequired(e => e.ParentCompartment)
                .HasForeignKey(e => e.ChildCompartId);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.PARENT_RELATION_LIST)
                .WithOptional(e => e.ChildCompartment)
                .HasForeignKey(e => e.ParentCompartId);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.COMPART_TOOL_IMAGE)
                .WithRequired(e => e.LU_COMPART)
                .HasForeignKey(e => e.CompartId);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.GENERAL_EQ_UNIT)
                .WithRequired(e => e.LU_COMPART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.LU_COMPART_PARTS)
                .WithRequired(e => e.LU_COMPART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.LU_GET_COMPART_SUB_TYPE)
                .WithRequired(e => e.LU_COMPART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.TRACK_COMPART_WORN_LIMIT_CAT)
                .WithRequired(e => e.LU_COMPART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_COMPART>()
                .HasMany(e => e.TRACK_COMPART_WORN_LIMIT_ITM)
                .WithRequired(e => e.LU_COMPART)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_COMPART_PARTS>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART_TYPE>()
                .Property(e => e.comparttypeid)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART_TYPE>()
                .Property(e => e.comparttype)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART_TYPE>()
                .Property(e => e.comparttype_shortkey)
                .IsUnicode(false);

            modelBuilder.Entity<LU_COMPART_TYPE>()
                .HasMany(e => e.LU_COMPART)
                .WithRequired(e => e.LU_COMPART_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.compartid)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.compart)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.modifier_code)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.parentid)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.expected_life)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.expected_cost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.companyname)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.track_comp_cts_maintype)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.track_comp_cts_subtype)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.compart_note)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.hydraulic_inspect_symptoms)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_SUB_TYPE>()
                .Property(e => e.teeth_size)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_SUB_TYPE>()
                .Property(e => e.series)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_SUB_TYPE>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_SUB_TYPE>()
                .Property(e => e.compart)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_TYPE>()
                .Property(e => e.comparttypeid)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_TYPE>()
                .Property(e => e.comparttype)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_TYPE>()
                .Property(e => e.comparttype_shortkey)
                .IsUnicode(false);

            modelBuilder.Entity<LU_GET_COMPART_TYPE>()
                .HasMany(e => e.LU_GET_COMPART)
                .WithRequired(e => e.LU_GET_COMPART_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_IMPLEMENT>()
                .Property(e => e.implementdescription)
                .IsUnicode(false);

            modelBuilder.Entity<LU_IMPLEMENT>()
                .Property(e => e.schematic_auto_multiple)
                .IsUnicode(false);

            modelBuilder.Entity<LU_MMTA>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_MMTA>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_MMTA>()
                .HasMany(e => e.EQUIPMENTs)
                .WithRequired(e => e.LU_MMTA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LU_Module_Sub>()
                .HasMany(e => e.TRACK_INSPECTION_DETAIL)
                .WithOptional(e => e.LU_Module_Sub)
                .HasForeignKey(e => e.UCSystemId);

            modelBuilder.Entity<LU_Module_Sub>()
                .HasMany(e => e.Life)
                .WithRequired(e => e.LU_Module_Sub)
                .HasForeignKey(e => e.SystemId);

            modelBuilder.Entity<MAKE>()
                .Property(e => e.makeid)
                .IsUnicode(false);

            modelBuilder.Entity<MAKE>()
                .Property(e => e.makedesc)
                .IsUnicode(false);

            modelBuilder.Entity<MAKE>()
                .Property(e => e.dbs_id)
                .IsUnicode(false);

            modelBuilder.Entity<MAKE>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<MAKE>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<MAKE>()
                .HasMany(e => e.EQUIPMENTs)
                .WithOptional(e => e.MAKE)
                .HasForeignKey(e => e.track_make_auto);

            modelBuilder.Entity<MAKE>()
                .HasMany(e => e.LU_MMTA)
                .WithRequired(e => e.MAKE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MAKE>()
                .HasMany(e => e.TRACK_COMPART_EXT)
                .WithOptional(e => e.MAKE)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MODEL>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<MODEL>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<MODEL>()
                .HasMany(e => e.LU_MMTA)
                .WithRequired(e => e.MODEL)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRACK_ACTION>()
                .Property(e => e.action_recommandation)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION>()
                .Property(e => e.recommanded_by)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION>()
                .HasMany(e => e.TRACK_ACTION_TAKEN)
                .WithRequired(e => e.TRACK_ACTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRACK_ACTION_TAKEN>()
                .Property(e => e.action_taken_by)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_TAKEN>()
                .Property(e => e.action_taken_desc)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_TAKEN>()
                .Property(e => e.action_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TRACK_ACTION_TAKEN>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_TYPE>()
                .Property(e => e.action_description)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_TYPE>()
                .Property(e => e.compartment_type)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_TYPE>()
                .HasMany(e => e.ACTION_TAKEN_HISTORY)
                .WithRequired(e => e.TRACK_ACTION_TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRACK_COMPART_WORN_CALC_METHOD>()
                .Property(e => e.track_compart_worn_calc_method_name)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.hi_inflectionPoint)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.hi_slope1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.hi_intercept1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.hi_slope2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.hi_intercept2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.mi_inflectionPoint)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.mi_slope1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.mi_intercept1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.mi_slope2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.mi_intercept2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_CAT>()
                .Property(e => e.adjust_base)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_HITACHI>()
                .Property(e => e.impact_slope)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_HITACHI>()
                .Property(e => e.normal_slope)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_HITACHI>()
                .Property(e => e.impact_intercept)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_HITACHI>()
                .Property(e => e.normal_intercept)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.start_depth_new)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_10_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_20_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_30_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_40_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_50_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_60_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_70_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_80_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_90_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_100_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_110_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_ITM>()
                .Property(e => e.wear_depth_120_percent)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.slope_impact)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.slope_normal)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.impact_slope)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.normal_slope)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.impact_intercept)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.normal_intercept)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.impact_secondorder)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_KOMATSU>()
                .Property(e => e.normal_secondorder)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_LIEBHERR>()
                .Property(e => e.impact_slope)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_LIEBHERR>()
                .Property(e => e.normal_slope)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_LIEBHERR>()
                .Property(e => e.impact_intercept)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_COMPART_WORN_LIMIT_LIEBHERR>()
                .Property(e => e.normal_intercept)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_DEALERSHIP_LIMITS>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.examiner)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.evalcode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.track_sag_left)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.track_sag_right)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.track_sag_left_status)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.track_sag_right_status)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.dry_joints_left)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.dry_joints_right)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.frame_ext_left)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.frame_ext_right)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.sprocket_left_status)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.sprocket_right_status)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.uccode)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.uccodedesc)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.confirmed_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.last_interp_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.docket_no)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.ucbrand)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.released_by)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.ext_cannon_left)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .Property(e => e.ext_cannon_right)
                .HasPrecision(18, 3);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .HasMany(e => e.TRACK_ACTION)
                .WithRequired(e => e.TRACK_INSPECTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRACK_INSPECTION>()
                .HasMany(e => e.TRACK_INSPECTION_DETAIL)
                .WithRequired(e => e.TRACK_INSPECTION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRACK_INSPECTION_DETAIL>()
                .Property(e => e.eval_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION_DETAIL>()
                .HasOptional(e => e.SIDE)
                .WithRequired(e => e.INSPECTION_DETAIL);

            modelBuilder.Entity<TRACK_INSPECTION_DETAIL>()
                .HasMany(e => e.Images)
                .WithOptional(e => e.TRACK_INSPECTION_DETAIL)
                .HasForeignKey(e => e.InspectionDetailId);

            modelBuilder.Entity<TRACK_TOOL>()
                .Property(e => e.tool_name)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_TOOL>()
                .HasMany(e => e.COMP_Inventory_Inspec_Details)
                .WithOptional(e => e.TRACK_TOOL)
                .HasForeignKey(e => e.tool_Id);

            modelBuilder.Entity<TRACK_TOOL>()
                .HasMany(e => e.COMPART_TOOL_IMAGE)
                .WithRequired(e => e.Tool)
                .HasForeignKey(e => e.ToolId);

            modelBuilder.Entity<TRACK_TOOL>()
                .HasMany(e => e.TRACK_COMPART_EXT)
                .WithOptional(e => e.TRACK_TOOL)
                .HasForeignKey(e => e.tools_auto)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TRACK_TOOL>()
                .HasMany(e => e.TRACK_COMPART_WORN_LIMIT_CAT)
                .WithRequired(e => e.TRACK_TOOL)
                .HasForeignKey(e => e.track_tools_auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRACK_TOOL>()
                .HasMany(e => e.TRACK_COMPART_WORN_LIMIT_ITM)
                .WithRequired(e => e.TRACK_TOOL)
                .HasForeignKey(e => e.track_tools_auto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TYPE>()
                .Property(e => e.typeid)
                .IsUnicode(false);

            modelBuilder.Entity<TYPE>()
                .Property(e => e.typedesc)
                .IsUnicode(false);

            modelBuilder.Entity<TYPE>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<TYPE>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<TYPE>()
                .HasMany(e => e.LU_MMTA)
                .WithRequired(e => e.TYPE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_CRSF_CUST_EQUIP>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.userid)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.passwd)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.phone_area_code)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.fax_area_code)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.fax_number)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.mobile)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.street1)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.street2)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.suburb)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.postcode)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.state)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.temperature_unit)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.weight_unit)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.length_unit)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.area_unit)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.volume_unit)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.pressure_unit)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.company)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.track_uom)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.AS400_PSSR_EMPNO)
                .IsFixedLength();

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.cat_id)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .Property(e => e.cat_password)
                .IsUnicode(false);

            modelBuilder.Entity<USER_TABLE>()
                .HasMany(e => e.COMP_Inventory_Inspec_Details)
                .WithRequired(e => e.USER_TABLE)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_TABLE>()
                .HasMany(e => e.COMPONENT_LIFE)
                .WithRequired(e => e.USER_TABLE)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<USER_TABLE>()
                .HasMany(e => e.EQUIPMENT_AUDIT_HISTOY)
                .WithRequired(e => e.USER_TABLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_TABLE>()
                .HasMany(e => e.EQUIPMENT_LIFE)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<USER_TABLE>()
                .HasMany(e => e.UCSYSTEM_LIFE)
                .WithRequired(e => e.USER_TABLE)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<APPLICATION_ERROR_LOG>()
                .Property(e => e.pagename)
                .IsUnicode(false);

            modelBuilder.Entity<APPLICATION_ERROR_LOG>()
                .Property(e => e.error)
                .IsUnicode(false);

            modelBuilder.Entity<APPLICATION_ERROR_LOG>()
                .Property(e => e.stacktrace)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_CompartAttach_filestream>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_CompartAttach_filestream>()
                .Property(e => e.attachment_name)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.serialno)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.unitno)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.op_range)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.purchase_cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.depmethod)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.uccode)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.regno)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.DBS_serialno)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.smu_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.smu_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.distance_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.distance_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.kw_hrs_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.kw_hrs_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.fuel_burn_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.fuel_burn_ltd_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.calender_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.current_smu_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.current_distance_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.current_kw_hrs_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.current_fuel_burn_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.current_calender_sec_reading)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.Sec_AVGDB_Hours)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.Sec_AVGDB_Distance)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.Sec_AVGDB_KWHOURS)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.Sec_AVGDB_FuelBurn)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.Sec_AVGDB_Calender)
                .HasPrecision(20, 2);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.jobsite_name)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewEquipment>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.compartsn)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.compart_note)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.compart_descr)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_before_failure)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_after_failure)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_calculated)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_calculated1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.rebuild_cost_calculated2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mbl_NewGENERAL_EQ_UNIT>()
                .Property(e => e.replace_cost_calculated)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.examiner)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.track_sag_left)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.track_sag_right)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.track_sag_left_status)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.track_sag_right_status)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.dry_joints_left)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.dry_joints_right)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.ext_cannon_left)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.ext_cannon_right)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.frame_ext_left)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.frame_ext_right)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.sprocket_left_status)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.sprocket_right_status)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.confirmed_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.evalcode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.uccode)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.uccodedesc)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.last_interp_user)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.eval_comment)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.docket_no)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.ucbrand)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.Jobsite_Comms)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.released_by)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection>()
                .Property(e => e.inspection_comments)
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection_Detail>()
                .Property(e => e.eval_code)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mbl_Track_Inspection_Detail>()
                .Property(e => e.comments)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_COMPONENT>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_COMPONENT>()
                .Property(e => e.action_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_COMPONENT>()
                .Property(e => e.created_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_COMPONENT>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_ACTION_COMPONENT>()
                .Property(e => e.cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TRACK_EQ_LIMITS>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<TRACK_INSPECTION_IMAGES>()
                .Property(e => e.inspection_detail_auto)
                .IsFixedLength();

            modelBuilder.Entity<TRACK_MODEL_LIMITS>()
                .Property(e => e.modified_user)
                .IsUnicode(false);

            modelBuilder.Entity<LU_MODULE_GROUP>()
                .Property(e => e.moduledesc)
                .IsUnicode(false);

            modelBuilder.Entity<LU_MODULE_GROUP>()
                .Property(e => e.comp_tbl_name)
                .IsUnicode(false);

            modelBuilder.Entity<LU_MODULE_GROUP>()
                .Property(e => e.login_targetpath)
                .IsUnicode(false);

            modelBuilder.Entity<LU_MODULE_GROUP>()
                .Property(e => e.homepage_name)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L1>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L1>()
                .Property(e => e.targetpath)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L1>()
                .Property(e => e.tooltip)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L2>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L2>()
                .Property(e => e.targetpath)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L2>()
                .Property(e => e.tooltip)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L3>()
                .Property(e => e.label)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L3>()
                .Property(e => e.targetpath)
                .IsUnicode(false);

            modelBuilder.Entity<MENU_L3>()
                .Property(e => e.tooltip)
                .IsUnicode(false);

            modelBuilder.Entity<USER_GROUP>()
                .Property(e => e.groupname)
                .IsUnicode(false);

            modelBuilder.Entity<USER_GROUP>()
                .Property(e => e.comment)
                .IsUnicode(false);
        }
    }
}