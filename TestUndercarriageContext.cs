using DAL.TestDbset;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace DAL.UndercarriageTest
{
    public class TestUndercarriageContext : IUndercarriageContext
    {
        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            SaveChangesCount++;
            return 1;
        }
        public void MarkAsModified<T>(T entity) where T : class { }
        public TestUndercarriageContext()
        {
            TEMP_UPLOAD_IMAGE = new TestDbSet<TEMP_UPLOAD_IMAGE>();
            COMPART_MEASUREMENT_POINT = new TestDbSet<COMPART_MEASUREMENT_POINT>();
            MEASUREMENT_POINT_RECORD = new TestDbSet<MEASUREMENT_POINT_RECORD>();
            MEASUREMENT_POSSIBLE_TOOLS = new TestDbSet<MEASUREMENT_POSSIBLE_TOOLS>();
            MEASUREPOINT_RECORD_IMAGES = new TestDbSet<MEASUREPOINT_RECORD_IMAGES>();
            CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL = new TestDbSet<CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL>();
            COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS = new TestDbSet<COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS>();
            CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE = new TestDbSet<CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE>();
            COMPARTTYPE_ADDITIONAL_TYPE = new TestDbSet<COMPARTTYPE_ADDITIONAL_TYPE>();
            INSPECTION_COMPARTTYPE_RECORD = new TestDbSet<INSPECTION_COMPARTTYPE_RECORD>();
            INSPECTION_COMPARTTYPE_IMAGES = new TestDbSet<INSPECTION_COMPARTTYPE_IMAGES>();
            INSPECTION_COMPARTTYPE_RECORD_IMAGES = new TestDbSet<INSPECTION_COMPARTTYPE_RECORD_IMAGES>();

            CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE = new TestDbSet<CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE>();
            COMPARTTYPE_ADDITIONAL_TYPE = new TestDbSet<COMPARTTYPE_ADDITIONAL_TYPE>();
            INSPECTION_COMPARTTYPE_RECORD = new TestDbSet<INSPECTION_COMPARTTYPE_RECORD>();
            INSPECTION_COMPARTTYPE_IMAGES = new TestDbSet<INSPECTION_COMPARTTYPE_IMAGES>();
            INSPECTION_COMPARTTYPE_RECORD_IMAGES = new TestDbSet<INSPECTION_COMPARTTYPE_RECORD_IMAGES>();
            CUSTOMER_MODEL_MANDATORY_IMAGE = new TestDbSet<CUSTOMER_MODEL_MANDATORY_IMAGE>();
            INSPECTION_MANDATORY_IMAGES = new TestDbSet<INSPECTION_MANDATORY_IMAGES>();
            MININGSHOVEL_REPORT = new TestDbSet<MININGSHOVEL_REPORT>();
            MININGSHOVEL_REPORT_INTRODUCTION = new TestDbSet<MININGSHOVEL_REPORT_INTRODUCTION>();
            MININGSHOVEL_REPORT_RECOMMENDATIONS = new TestDbSet<MININGSHOVEL_REPORT_RECOMMENDATIONS>();
            MININGSHOVEL_REPORT_SUMMARY = new TestDbSet<MININGSHOVEL_REPORT_SUMMARY>();
            MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES = new TestDbSet<MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES>();
            MININGSHOVEL_REPORT_IMAGE_CATEGORIES = new TestDbSet<MININGSHOVEL_REPORT_IMAGE_CATEGORIES>();
            MININGSHOVEL_REPORT_IMAGE_RESIZED = new TestDbSet<MININGSHOVEL_REPORT_IMAGE_RESIZED>();
            MININGSHOVEL_REPORT_OVERALL_COMMENTS = new TestDbSet<MININGSHOVEL_REPORT_OVERALL_COMMENTS>();
            REPORT_HIDDEN_ADDITIONAL_RECORD = new TestDbSet<REPORT_HIDDEN_ADDITIONAL_RECORD>();
            REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE = new TestDbSet<REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE>();
            REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE = new TestDbSet<REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE>();
            REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES = new TestDbSet<REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES>();
            REPORT_HIDDEN_MEASUREMENT_POINT_RECORD = new TestDbSet<REPORT_HIDDEN_MEASUREMENT_POINT_RECORD>();
            REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES = new TestDbSet<REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES>();

            LU_EQUIPMENT_RANKING = new TestDbSet<LU_EQUIPMENT_RANKING>();
            WSREComponentRecordRecommendation = new TestDbSet<WSREComponentRecordRecommendation>();
            WSRE = new TestDbSet<WSRE>();
            WSREComponentImage = new TestDbSet<WSREComponentImage>();
            WSREComponentRecommendation = new TestDbSet<WSREComponentRecommendation>();
            WSREComponentRecord = new TestDbSet<WSREComponentRecord>();
            WSREContact = new TestDbSet<WSREContact>();
            WSRECrackTest = new TestDbSet<WSRECrackTest>();
            WSRECrackTestImage = new TestDbSet<WSRECrackTestImage>();
            WSREDipTest = new TestDbSet<WSREDipTest>();
            WSREDipTestCondition = new TestDbSet<WSREDipTestCondition>();
            WSREDipTestImage = new TestDbSet<WSREDipTestImage>();
            WSREInitialImage = new TestDbSet<WSREInitialImage>();
            WSREInitialImageType = new TestDbSet<WSREInitialImageType>();
            WSREStatusType = new TestDbSet<WSREStatusType>();
            AccessLevelTypes = new TestDbSet<AccessLevelType>();
            ACTION_LOG = new TestDbSet<ACTION_LOG>();
            ACTION_TAKEN_HISTORY = new TestDbSet<ACTION_TAKEN_HISTORY>();
            APPLICATIONs = new TestDbSet<APPLICATION>();
            APPLICATION_LU_CONFIG = new TestDbSet<APPLICATION_LU_CONFIG>();
            COMP_Inventory_Inspec_Details = new TestDbSet<COMP_Inventory_Inspec_Details>();
            COMPART_ATTACH_FILESTREAM = new TestDbSet<COMPART_ATTACH_FILESTREAM>();
            COMPART_ATTACH_TYPE = new TestDbSet<COMPART_ATTACH_TYPE>();
            COMPART_PARENT_RELATION = new TestDbSet<COMPART_PARENT_RELATION>();
            COMPART_TOOL_IMAGE = new TestDbSet<COMPART_TOOL_IMAGE>();
            COMPONENT_LIFE = new TestDbSet<ComponentLife>();
            CRSF = new TestDbSet<CRSF>();
            CRSF_AREA = new TestDbSet<CRSF_AREA>();
            CRSF_TYPE = new TestDbSet<CRSF_TYPE>();
            CUSTOMERs = new TestDbSet<CUSTOMER>();
            Dealerships = new TestDbSet<Dealership>();
            EQ_UNIT_HISTORY = new TestDbSet<EQ_UNIT_HISTORY>();
            EQUIPMENTs = new TestDbSet<EQUIPMENT>();
            EQUIPMENT_ACTIONS = new TestDbSet<EQUIPMENT_ACTIONS>();
            EQUIPMENT_AUDIT_HISTOY = new TestDbSet<EQUIPMENT_AUDIT_HISTOY>();
            EQUIPMENT_LIVES = new TestDbSet<EQUIPMENT_LIFE>();
            GENERAL_EQ_UNIT = new TestDbSet<GENERAL_EQ_UNIT>();
            GENERAL_EQ_UNIT_HISTORY = new TestDbSet<GENERAL_EQ_UNIT_HISTORY>();
            GETs = new TestDbSet<GET>();
            GET_ACTIONS = new TestDbSet<GET_ACTIONS>();
            GET_COMPONENT = new TestDbSet<GET_COMPONENT>();
            GET_COMPONENT_INSPECTION = new TestDbSet<GET_COMPONENT_INSPECTION>();
            GET_CONFIG = new TestDbSet<GET_CONFIG>();
            GET_EVENTS = new TestDbSet<GET_EVENTS>();
            GET_EVENTS_COMPONENT = new TestDbSet<GET_EVENTS_COMPONENT>();
            GET_EVENTS_EQUIPMENT = new TestDbSet<GET_EVENTS_EQUIPMENT>();
            GET_EVENTS_IMPLEMENT = new TestDbSet<GET_EVENTS_IMPLEMENT>();
            GET_IMPLEMENT_INSPECTION = new TestDbSet<GET_IMPLEMENT_INSPECTION>();
            GET_IMPLEMENT_INSPECTION_IMAGE = new TestDbSet<GET_IMPLEMENT_INSPECTION_IMAGE>();
            GET_INSPECTION_CONSTANTS = new TestDbSet<GET_INSPECTION_CONSTANTS>();
            GET_INSPECTION_PARAMETERS = new TestDbSet<GET_INSPECTION_PARAMETERS>();
            GET_INSPECTIONS_VIEWED = new TestDbSet<GET_INSPECTIONS_VIEWED>();
            GET_INTERPRETATION_COMMENTS = new TestDbSet<GET_INTERPRETATION_COMMENTS>();
            GET_OBSERVATION_IMAGE = new TestDbSet<GET_OBSERVATION_IMAGE>();
            GET_OBSERVATION_LIST = new TestDbSet<GET_OBSERVATION_LIST>();
            GET_OBSERVATION_RESULTS = new TestDbSet<GET_OBSERVATION_RESULTS>();
            GET_OBSERVATIONS = new TestDbSet<GET_OBSERVATIONS>();
            GET_SCHEMATIC_COMPONENT = new TestDbSet<GET_SCHEMATIC_COMPONENT>();
            GET_SCHEMATIC_IMAGE = new TestDbSet<GET_SCHEMATIC_IMAGE>();
            IMPLEMENT_CATEGORY = new TestDbSet<IMPLEMENT_CATEGORY>();
            IMPLEMENT_READING_ENTRY = new TestDbSet<IMPLEMENT_READING_ENTRY>();
            InspectionDetails_Side = new TestDbSet<InspectionDetails_Side>();
            LU_COMPART = new TestDbSet<LU_COMPART>();
            LU_COMPART_PARTS = new TestDbSet<LU_COMPART_PARTS>();
            LU_COMPART_TYPE = new TestDbSet<LU_COMPART_TYPE>();
            LU_GET_COMPART = new TestDbSet<LU_GET_COMPART>();
            LU_GET_COMPART_SUB_TYPE = new TestDbSet<LU_GET_COMPART_SUB_TYPE>();
            LU_GET_COMPART_TYPE = new TestDbSet<LU_GET_COMPART_TYPE>();
            LU_IMPLEMENT = new TestDbSet<LU_IMPLEMENT>();
            LU_MMTA = new TestDbSet<LU_MMTA>();
            LU_Module_Sub = new TestDbSet<LU_Module_Sub>();
            LU_Module_Sub_History = new TestDbSet<LU_Module_Sub_History>();
            MAKE = new TestDbSet<MAKE>();
            MODELs = new TestDbSet<MODEL>();
            TRACK_ACTION = new TestDbSet<TRACK_ACTION>();
            TRACK_ACTION_TAKEN = new TestDbSet<TRACK_ACTION_TAKEN>();
            TRACK_ACTION_TYPE = new TestDbSet<TRACK_ACTION_TYPE>();
            TRACK_COMPART_EXT = new TestDbSet<TRACK_COMPART_EXT>();
            TRACK_COMPART_WORN_CALC_METHOD = new TestDbSet<TRACK_COMPART_WORN_CALC_METHOD>();
            TRACK_COMPART_WORN_LIMIT_CAT = new TestDbSet<TRACK_COMPART_WORN_LIMIT_CAT>();
            TRACK_COMPART_WORN_LIMIT_HITACHI = new TestDbSet<TRACK_COMPART_WORN_LIMIT_HITACHI>();
            TRACK_COMPART_WORN_LIMIT_ITM = new TestDbSet<TRACK_COMPART_WORN_LIMIT_ITM>();
            TRACK_COMPART_WORN_LIMIT_KOMATSU = new TestDbSet<TRACK_COMPART_WORN_LIMIT_KOMATSU>();
            TRACK_COMPART_WORN_LIMIT_LIEBHERR = new TestDbSet<TRACK_COMPART_WORN_LIMIT_LIEBHERR>();
            TRACK_DEALERSHIP_LIMITS = new TestDbSet<TRACK_DEALERSHIP_LIMITS>();
            TRACK_INSPECTION = new TestDbSet<TRACK_INSPECTION>();
            TRACK_INSPECTION_DETAIL = new TestDbSet<TRACK_INSPECTION_DETAIL>();
            TRACK_TOOL = new TestDbSet<TRACK_TOOL>();
            TYPEs = new TestDbSet<TYPE>();
            UCSYSTEM_LIFE = new TestDbSet<SystemLife>();
            USER_CRSF_CUST_EQUIP = new TestDbSet<USER_CRSF_CUST_EQUIP>();
            USER_DEALERSHIP = new TestDbSet<USER_DEALERSHIP>();
            USER_TABLE = new TestDbSet<USER_TABLE>();
            UserAccessMaps = new TestDbSet<UserAccessMaps>();
            APPLICATION_ERROR_LOG = new TestDbSet<APPLICATION_ERROR_LOG>();
            Mbl_CompartAttach_filestream = new TestDbSet<Mbl_CompartAttach_filestream>();
            Mbl_NewEquipment = new TestDbSet<Mbl_NewEquipment>();
            Mbl_NewGENERAL_EQ_UNIT = new TestDbSet<Mbl_NewGENERAL_EQ_UNIT>();
            Mbl_Track_Inspection = new TestDbSet<Mbl_Track_Inspection>();
            Mbl_Track_Inspection_Detail = new TestDbSet<Mbl_Track_Inspection_Detail>();
            TRACK_ACTION_COMPONENT = new TestDbSet<TRACK_ACTION_COMPONENT>();
            TRACK_EQ_LIMITS = new TestDbSet<TRACK_EQ_LIMITS>();
            TRACK_INSPECTION_IMAGES = new TestDbSet<TRACK_INSPECTION_IMAGES>();
            TRACK_MODEL_LIMITS = new TestDbSet<TRACK_MODEL_LIMITS>();
            FLUID_REPORT_LOGO = new TestDbSet<FLUID_REPORT_LOGO>();
            FLUID_REPORT_LU_REPORTS = new TestDbSet<FLUID_REPORT_LU_REPORTS>();
            FLUID_REPORT_LU_SETTINGS = new TestDbSet<FLUID_REPORT_LU_SETTINGS>();
            DealershipReports = new TestDbSet<DealershipReports>();
            CustomerReports = new TestDbSet<CustomerReports>();
            TRACK_QUOTE = new TestDbSet<TRACK_QUOTE>();
            DealershipBranding = new TestDbSet<DealershipBranding>();
            ApplicationStyle = new TestDbSet<ApplicationStyle>();
            ClientRedirectUris = new TestDbSet<ClientRedirectUri>();
            LANGUAGE = new TestDbSet<LANGUAGE>();
            TRACK_COMPART_MODEL_MAPPING = new TestDbSet<TRACK_COMPART_MODEL_MAPPING>();
            SHOE_SIZE = new TestDbSet<SHOE_SIZE>();
            SystemModelTemplate = new TestDbSet<SystemModelTemplate>();
            SystemFamilyTemplate = new TestDbSet<SystemFamilyTemplate>();
            TrackInspectionImagesMain = new TestDbSet<TrackInspectionImagesMain>();
            TrackInspectionMeasurePoints = new TestDbSet<TrackInspectionMeasurePoints>();
            MeasurePointTypes = new TestDbSet<MeasurePointTypes>();
            MeasurePointTools = new TestDbSet<MeasurePointTools>();
            TrackInspectionRecords = new TestDbSet<TrackInspectionRecords>();
            TrackInspectionImagesRecords = new TestDbSet<TrackInspectionImagesRecords>();
            TrackInspectionComments = new TestDbSet<TrackInspectionComments>();
            TrackInspectionCommentImages = new TestDbSet<TrackInspectionCommentImages>();
            TrackInspectionCommentTypes = new TestDbSet<TrackInspectionCommentTypes>();
            ModelCommentMap = new TestDbSet<ModelCommentMap>();
            LuLinksCondition = new TestDbSet<LuLinksCondition>();
            TRACK_QUOTE_DETAIL = new TestDbSet<TRACK_QUOTE_DETAIL>();
            TRACK_QUOTE_STATUS = new TestDbSet<TRACK_QUOTE_STATUS>();
            TRACK_QUOTE_STATUS_HISTORY = new TestDbSet<TRACK_QUOTE_STATUS_HISTORY>();
            SearchFavorite = new TestDbSet<SearchFavorite>();
            SearchFavoriteItems = new TestDbSet<SearchFavoriteItems>();
            DASHBOARD_SEARCH = new TestDbSet<DASHBOARD_SEARCH>();
            SEARCH_ITEM = new TestDbSet<SEARCH_ITEM>();
        }
        public DbSet<TEMP_UPLOAD_IMAGE> TEMP_UPLOAD_IMAGE { get; set; }
        public DbSet<COMPART_MEASUREMENT_POINT> COMPART_MEASUREMENT_POINT { get; set; }
        public DbSet<MEASUREMENT_POINT_RECORD> MEASUREMENT_POINT_RECORD { get; set; }
        public DbSet<MEASUREMENT_POSSIBLE_TOOLS> MEASUREMENT_POSSIBLE_TOOLS { get; set; }
        public DbSet<MEASUREPOINT_RECORD_IMAGES> MEASUREPOINT_RECORD_IMAGES { get; set; }
        public DbSet<CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL> CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL { get; set; }
        public DbSet<COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS> COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS { get; set; }
        public DbSet<CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE> CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE { get; set; }
        public DbSet<COMPARTTYPE_ADDITIONAL_TYPE> COMPARTTYPE_ADDITIONAL_TYPE { get; set; }
        public DbSet<INSPECTION_COMPARTTYPE_RECORD> INSPECTION_COMPARTTYPE_RECORD { get; set; }
        public DbSet<INSPECTION_COMPARTTYPE_IMAGES> INSPECTION_COMPARTTYPE_IMAGES { get; set; }
        public DbSet<INSPECTION_COMPARTTYPE_RECORD_IMAGES> INSPECTION_COMPARTTYPE_RECORD_IMAGES { get; set; }
        public DbSet<CUSTOMER_MODEL_MANDATORY_IMAGE> CUSTOMER_MODEL_MANDATORY_IMAGE { get; set; }
        public DbSet<INSPECTION_MANDATORY_IMAGES> INSPECTION_MANDATORY_IMAGES { get; set; }
        public DbSet<MININGSHOVEL_REPORT> MININGSHOVEL_REPORT { get; set; }
        public DbSet<MININGSHOVEL_REPORT_INTRODUCTION> MININGSHOVEL_REPORT_INTRODUCTION { get; set; }
        public DbSet<MININGSHOVEL_REPORT_RECOMMENDATIONS> MININGSHOVEL_REPORT_RECOMMENDATIONS { get; set; }
        public DbSet<MININGSHOVEL_REPORT_SUMMARY> MININGSHOVEL_REPORT_SUMMARY { get; set; }
        public DbSet<MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES> MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES { get; set; }
        public DbSet<MININGSHOVEL_REPORT_IMAGE_CATEGORIES> MININGSHOVEL_REPORT_IMAGE_CATEGORIES { get; set; }
        public DbSet<MININGSHOVEL_REPORT_IMAGE_RESIZED> MININGSHOVEL_REPORT_IMAGE_RESIZED { get; set; }
        public DbSet<MININGSHOVEL_REPORT_OVERALL_COMMENTS> MININGSHOVEL_REPORT_OVERALL_COMMENTS { get; set; }
        public DbSet<REPORT_HIDDEN_ADDITIONAL_RECORD> REPORT_HIDDEN_ADDITIONAL_RECORD { get; set; }
        public DbSet<REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE> REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE { get; set; }
        public DbSet<REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE> REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE { get; set; }
        public DbSet<REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES> REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES { get; set; }
        public DbSet<REPORT_HIDDEN_MEASUREMENT_POINT_RECORD> REPORT_HIDDEN_MEASUREMENT_POINT_RECORD { get; set; }
        public DbSet<REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES> REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES { get; set; }
        public DbSet<LU_EQUIPMENT_RANKING> LU_EQUIPMENT_RANKING { get; set; }
        public DbSet<WSREComponentRecordRecommendation> WSREComponentRecordRecommendation { get; set; }
        public DbSet<WSRE> WSRE { get; set; }
        public DbSet<WSREComponentImage> WSREComponentImage { get; set; }
        public DbSet<WSREComponentRecommendation> WSREComponentRecommendation { get; set; }
        public DbSet<WSREComponentRecord> WSREComponentRecord { get; set; }
        public DbSet<WSREContact> WSREContact { get; set; }
        public DbSet<WSRECrackTest> WSRECrackTest { get; set; }
        public DbSet<WSRECrackTestImage> WSRECrackTestImage { get; set; }
        public DbSet<WSREDipTest> WSREDipTest { get; set; }
        public DbSet<WSREDipTestCondition> WSREDipTestCondition { get; set; }
        public DbSet<WSREDipTestImage> WSREDipTestImage { get; set; }
        public DbSet<WSREInitialImage> WSREInitialImage { get; set; }
        public DbSet<WSREInitialImageType> WSREInitialImageType { get; set; }
        public DbSet<WSREStatusType> WSREStatusType { get; set; }
        public DbSet<AccessLevelType> AccessLevelTypes { get; set; }
        public DbSet<ACTION_LOG> ACTION_LOG { get; set; }
        public DbSet<ACTION_TAKEN_HISTORY> ACTION_TAKEN_HISTORY { get; set; }
        public DbSet<APPLICATION> APPLICATIONs { get; set; }
        public DbSet<APPLICATION_LU_CONFIG> APPLICATION_LU_CONFIG { get; set; }
        public DbSet<COMP_Inventory_Inspec_Details> COMP_Inventory_Inspec_Details { get; set; }
        public DbSet<COMPART_ATTACH_FILESTREAM> COMPART_ATTACH_FILESTREAM { get; set; }
        public DbSet<COMPART_ATTACH_TYPE> COMPART_ATTACH_TYPE { get; set; }
        public DbSet<COMPART_PARENT_RELATION> COMPART_PARENT_RELATION { get; set; }
        public DbSet<COMPART_TOOL_IMAGE> COMPART_TOOL_IMAGE { get; set; }
        public DbSet<ComponentLife> COMPONENT_LIFE { get; set; }
        public DbSet<CRSF> CRSF { get; set; }
        public DbSet<CRSF_AREA> CRSF_AREA { get; set; }
        public DbSet<CRSF_TYPE> CRSF_TYPE { get; set; }
        public DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<EQ_UNIT_HISTORY> EQ_UNIT_HISTORY { get; set; }
        public DbSet<EQUIPMENT> EQUIPMENTs { get; set; }
        public DbSet<EQUIPMENT_ACTIONS> EQUIPMENT_ACTIONS { get; set; }
        public DbSet<EQUIPMENT_AUDIT_HISTOY> EQUIPMENT_AUDIT_HISTOY { get; set; }
        public DbSet<EQUIPMENT_LIFE> EQUIPMENT_LIVES { get; set; }
        public DbSet<GENERAL_EQ_UNIT> GENERAL_EQ_UNIT { get; set; }
        public DbSet<GENERAL_EQ_UNIT_HISTORY> GENERAL_EQ_UNIT_HISTORY { get; set; }
        public DbSet<GET> GETs { get; set; }
        public DbSet<GET_ACTIONS> GET_ACTIONS { get; set; }
        public DbSet<GET_COMPONENT> GET_COMPONENT { get; set; }
        public DbSet<GET_COMPONENT_INSPECTION> GET_COMPONENT_INSPECTION { get; set; }
        public DbSet<GET_CONFIG> GET_CONFIG { get; set; }
        public DbSet<GET_EVENTS> GET_EVENTS { get; set; }
        public DbSet<GET_EVENTS_COMPONENT> GET_EVENTS_COMPONENT { get; set; }
        public DbSet<GET_EVENTS_EQUIPMENT> GET_EVENTS_EQUIPMENT { get; set; }
        public DbSet<GET_EVENTS_IMPLEMENT> GET_EVENTS_IMPLEMENT { get; set; }
        public DbSet<GET_IMPLEMENT_INSPECTION> GET_IMPLEMENT_INSPECTION { get; set; }
        public DbSet<GET_IMPLEMENT_INSPECTION_IMAGE> GET_IMPLEMENT_INSPECTION_IMAGE { get; set; }
        public DbSet<GET_INSPECTION_CONSTANTS> GET_INSPECTION_CONSTANTS { get; set; }
        public DbSet<GET_INSPECTION_PARAMETERS> GET_INSPECTION_PARAMETERS { get; set; }
        public DbSet<GET_INSPECTIONS_VIEWED> GET_INSPECTIONS_VIEWED { get; set; }
        public DbSet<GET_INTERPRETATION_COMMENTS> GET_INTERPRETATION_COMMENTS { get; set; }
        public DbSet<GET_OBSERVATION_IMAGE> GET_OBSERVATION_IMAGE { get; set; }
        public DbSet<GET_OBSERVATION_LIST> GET_OBSERVATION_LIST { get; set; }
        public DbSet<GET_OBSERVATION_RESULTS> GET_OBSERVATION_RESULTS { get; set; }
        public DbSet<GET_OBSERVATIONS> GET_OBSERVATIONS { get; set; }
        public DbSet<GET_SCHEMATIC_COMPONENT> GET_SCHEMATIC_COMPONENT { get; set; }
        public DbSet<GET_SCHEMATIC_IMAGE> GET_SCHEMATIC_IMAGE { get; set; }
        public DbSet<IMPLEMENT_CATEGORY> IMPLEMENT_CATEGORY { get; set; }
        public DbSet<IMPLEMENT_READING_ENTRY> IMPLEMENT_READING_ENTRY { get; set; }
        public DbSet<InspectionDetails_Side> InspectionDetails_Side { get; set; }
        public DbSet<LU_COMPART> LU_COMPART { get; set; }
        public DbSet<LU_COMPART_PARTS> LU_COMPART_PARTS { get; set; }
        public DbSet<LU_COMPART_TYPE> LU_COMPART_TYPE { get; set; }
        public DbSet<LU_GET_COMPART> LU_GET_COMPART { get; set; }
        public DbSet<LU_GET_COMPART_SUB_TYPE> LU_GET_COMPART_SUB_TYPE { get; set; }
        public DbSet<LU_GET_COMPART_TYPE> LU_GET_COMPART_TYPE { get; set; }
        public DbSet<LU_IMPLEMENT> LU_IMPLEMENT { get; set; }
        public DbSet<LU_MMTA> LU_MMTA { get; set; }
        public DbSet<LU_Module_Sub> LU_Module_Sub { get; set; }
        public DbSet<LU_Module_Sub_History> LU_Module_Sub_History { get; set; }
        public DbSet<MAKE> MAKE { get; set; }
        public DbSet<MODEL> MODELs { get; set; }
        public DbSet<TRACK_ACTION> TRACK_ACTION { get; set; }
        public DbSet<TRACK_ACTION_TAKEN> TRACK_ACTION_TAKEN { get; set; }
        public DbSet<TRACK_ACTION_TYPE> TRACK_ACTION_TYPE { get; set; }
        public DbSet<TRACK_COMPART_EXT> TRACK_COMPART_EXT { get; set; }
        public DbSet<TRACK_COMPART_WORN_CALC_METHOD> TRACK_COMPART_WORN_CALC_METHOD { get; set; }
        public DbSet<TRACK_COMPART_WORN_LIMIT_CAT> TRACK_COMPART_WORN_LIMIT_CAT { get; set; }
        public DbSet<TRACK_COMPART_WORN_LIMIT_HITACHI> TRACK_COMPART_WORN_LIMIT_HITACHI { get; set; }
        public DbSet<TRACK_COMPART_WORN_LIMIT_ITM> TRACK_COMPART_WORN_LIMIT_ITM { get; set; }
        public DbSet<TRACK_COMPART_WORN_LIMIT_KOMATSU> TRACK_COMPART_WORN_LIMIT_KOMATSU { get; set; }
        public DbSet<TRACK_COMPART_WORN_LIMIT_LIEBHERR> TRACK_COMPART_WORN_LIMIT_LIEBHERR { get; set; }
        public DbSet<TRACK_DEALERSHIP_LIMITS> TRACK_DEALERSHIP_LIMITS { get; set; }
        public DbSet<TRACK_INSPECTION> TRACK_INSPECTION { get; set; }
        public DbSet<TRACK_INSPECTION_DETAIL> TRACK_INSPECTION_DETAIL { get; set; }
        public DbSet<TRACK_TOOL> TRACK_TOOL { get; set; }
        public DbSet<TYPE> TYPEs { get; set; }
        public DbSet<SystemLife> UCSYSTEM_LIFE { get; set; }
        public DbSet<USER_CRSF_CUST_EQUIP> USER_CRSF_CUST_EQUIP { get; set; }
        public DbSet<USER_DEALERSHIP> USER_DEALERSHIP { get; set; }
        public DbSet<USER_TABLE> USER_TABLE { get; set; }
        public DbSet<UserAccessMaps> UserAccessMaps { get; set; }
        public DbSet<APPLICATION_ERROR_LOG> APPLICATION_ERROR_LOG { get; set; }
        public DbSet<Mbl_CompartAttach_filestream> Mbl_CompartAttach_filestream { get; set; }
        public DbSet<Mbl_NewEquipment> Mbl_NewEquipment { get; set; }
        public DbSet<Mbl_NewGENERAL_EQ_UNIT> Mbl_NewGENERAL_EQ_UNIT { get; set; }
        public DbSet<Mbl_Track_Inspection> Mbl_Track_Inspection { get; set; }
        public DbSet<Mbl_Track_Inspection_Detail> Mbl_Track_Inspection_Detail { get; set; }
        public DbSet<TRACK_ACTION_COMPONENT> TRACK_ACTION_COMPONENT { get; set; }
        public DbSet<TRACK_EQ_LIMITS> TRACK_EQ_LIMITS { get; set; }
        public DbSet<TRACK_INSPECTION_IMAGES> TRACK_INSPECTION_IMAGES { get; set; }
        public DbSet<TRACK_MODEL_LIMITS> TRACK_MODEL_LIMITS { get; set; }
        public DbSet<FLUID_REPORT_LOGO> FLUID_REPORT_LOGO { get; set; }
        public DbSet<FLUID_REPORT_LU_REPORTS> FLUID_REPORT_LU_REPORTS { get; set; }
        public DbSet<FLUID_REPORT_LU_SETTINGS> FLUID_REPORT_LU_SETTINGS { get; set; }
        public DbSet<DealershipReports> DealershipReports { get; set; }
        public DbSet<CustomerReports> CustomerReports { get; set; }
        public DbSet<TRACK_QUOTE> TRACK_QUOTE { get; set; }
        public DbSet<DealershipBranding> DealershipBranding { get; set; }
        public DbSet<ApplicationStyle> ApplicationStyle { get; set; }
        public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
        public DbSet<LANGUAGE> LANGUAGE { get; set; }
        public DbSet<TRACK_COMPART_MODEL_MAPPING> TRACK_COMPART_MODEL_MAPPING { get; set; }
        public DbSet<SHOE_SIZE> SHOE_SIZE { get; set; }
        public DbSet<SystemModelTemplate> SystemModelTemplate { get; set; }
        public DbSet<SystemFamilyTemplate> SystemFamilyTemplate { get; set; }
        public DbSet<TrackInspectionImagesMain> TrackInspectionImagesMain { get; set; }
        public DbSet<TrackInspectionMeasurePoints> TrackInspectionMeasurePoints { get; set; }
        public DbSet<MeasurePointTypes> MeasurePointTypes { get; set; }
        public DbSet<MeasurePointTools> MeasurePointTools { get; set; }
        public DbSet<TrackInspectionRecords> TrackInspectionRecords { get; set; }
        public DbSet<TrackInspectionImagesRecords> TrackInspectionImagesRecords { get; set; }
        public DbSet<TrackInspectionComments> TrackInspectionComments { get; set; }
        public DbSet<TrackInspectionCommentImages> TrackInspectionCommentImages { get; set; }
        public DbSet<TrackInspectionCommentTypes> TrackInspectionCommentTypes { get; set; }
        public DbSet<ModelCommentMap> ModelCommentMap { get; set; }
        public DbSet<LuLinksCondition> LuLinksCondition { get; set; }
        public DbSet<TRACK_QUOTE_DETAIL> TRACK_QUOTE_DETAIL { get; set; }
        public DbSet<TRACK_QUOTE_STATUS> TRACK_QUOTE_STATUS { get; set; }
        public DbSet<TRACK_QUOTE_STATUS_HISTORY> TRACK_QUOTE_STATUS_HISTORY { get; set; }
        public DbSet<SearchFavorite> SearchFavorite { get; set; }
        public DbSet<SearchFavoriteItems> SearchFavoriteItems { get; set; }
        public DbSet<LU_QuoteReport> LU_QuoteReports { get; set; }
        public DbSet<DealershipQuoteReports> DealershipQuoteReports { get; set; }
        public DbSet<DASHBOARD_SEARCH> DASHBOARD_SEARCH { get; set; }
        public DbSet<SEARCH_ITEM> SEARCH_ITEM { get; set; }
    }
}