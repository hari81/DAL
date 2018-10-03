using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUndercarriageContext
    {
        int SaveChanges();
        void MarkAsModified<T>(T entity) where T : class;
        DbSet<TEMP_UPLOAD_IMAGE> TEMP_UPLOAD_IMAGE { get; set; }
        DbSet<COMPART_MEASUREMENT_POINT> COMPART_MEASUREMENT_POINT { get; set; }
        DbSet<MEASUREMENT_POINT_RECORD> MEASUREMENT_POINT_RECORD { get; set; }
        DbSet<MEASUREMENT_POSSIBLE_TOOLS> MEASUREMENT_POSSIBLE_TOOLS { get; set; }
        DbSet<MEASUREPOINT_RECORD_IMAGES> MEASUREPOINT_RECORD_IMAGES { get; set; }
        DbSet<CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL> CUSTOMER_MODEL_COMPARTTYPE_ADDITIONAL { get; set; }
        DbSet<COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS> COMPARTTYPE_ADDITIONAL_POSSIBLE_TOOLS { get; set; }
        DbSet<CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE> CUSTOMER_MODEL_COMPARTTYPE_MANDATORY_IMAGE { get; set; }
        DbSet<COMPARTTYPE_ADDITIONAL_TYPE> COMPARTTYPE_ADDITIONAL_TYPE { get; set; }
        DbSet<INSPECTION_COMPARTTYPE_RECORD> INSPECTION_COMPARTTYPE_RECORD { get; set; }
        DbSet<INSPECTION_COMPARTTYPE_IMAGES> INSPECTION_COMPARTTYPE_IMAGES { get; set; }
        DbSet<INSPECTION_COMPARTTYPE_RECORD_IMAGES> INSPECTION_COMPARTTYPE_RECORD_IMAGES { get; set; }
        DbSet<CUSTOMER_MODEL_MANDATORY_IMAGE> CUSTOMER_MODEL_MANDATORY_IMAGE { get; set; }
        DbSet<INSPECTION_MANDATORY_IMAGES> INSPECTION_MANDATORY_IMAGES { get; set; }
        DbSet<MININGSHOVEL_REPORT> MININGSHOVEL_REPORT { get; set; }
        DbSet<MININGSHOVEL_REPORT_INTRODUCTION> MININGSHOVEL_REPORT_INTRODUCTION { get; set; }
        DbSet<MININGSHOVEL_REPORT_RECOMMENDATIONS> MININGSHOVEL_REPORT_RECOMMENDATIONS { get; set; }
        DbSet<MININGSHOVEL_REPORT_SUMMARY> MININGSHOVEL_REPORT_SUMMARY { get; set; }
        DbSet<MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES> MININGSHOVEL_REPORT_RECOMMENDATION_IMAGES { get; set; }
        DbSet<MININGSHOVEL_REPORT_IMAGE_CATEGORIES> MININGSHOVEL_REPORT_IMAGE_CATEGORIES { get; set; }
        DbSet<MININGSHOVEL_REPORT_IMAGE_RESIZED> MININGSHOVEL_REPORT_IMAGE_RESIZED { get; set; }
        DbSet<MININGSHOVEL_REPORT_OVERALL_COMMENTS> MININGSHOVEL_REPORT_OVERALL_COMMENTS { get; set; }
        DbSet<REPORT_HIDDEN_ADDITIONAL_RECORD> REPORT_HIDDEN_ADDITIONAL_RECORD { get; set; }
        DbSet<REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE> REPORT_HIDDEN_ADDITIONAL_RECORD_IMAGE { get; set; }
        DbSet<REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE> REPORT_HIDDEN_COMPARTTYPE_MANDATORY_IMAGE { get; set; }
        DbSet<REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES> REPORT_HIDDEN_INSPECTION_MANDATORY_IMAGES { get; set; }
        DbSet<REPORT_HIDDEN_MEASUREMENT_POINT_RECORD> REPORT_HIDDEN_MEASUREMENT_POINT_RECORD { get; set; }
        DbSet<REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES> REPORT_HIDDEN_MEASUREPOINT_RECORD_IMAGES { get; set; }
        DbSet<WSREComponentRecordRecommendation> WSREComponentRecordRecommendation { get; }
        DbSet<WSRE> WSRE { get; }
        DbSet<WSREComponentImage> WSREComponentImage { get; }
        DbSet<WSREComponentRecommendation> WSREComponentRecommendation { get; }
        DbSet<WSREComponentRecord> WSREComponentRecord { get; }
        DbSet<WSREContact> WSREContact { get; }
        DbSet<WSRECrackTest> WSRECrackTest { get; }
        DbSet<WSRECrackTestImage> WSRECrackTestImage { get; }
        DbSet<WSREDipTest> WSREDipTest { get; }
        DbSet<WSREDipTestCondition> WSREDipTestCondition { get; }
        DbSet<WSREDipTestImage> WSREDipTestImage { get; }
        DbSet<WSREInitialImage> WSREInitialImage { get; }
        DbSet<WSREInitialImageType> WSREInitialImageType { get; }
        DbSet<WSREStatusType> WSREStatusType { get; }
        DbSet<AccessLevelType> AccessLevelTypes { get; }
        DbSet<ACTION_LOG> ACTION_LOG { get; }
        DbSet<ACTION_TAKEN_HISTORY> ACTION_TAKEN_HISTORY { get; }
        DbSet<APPLICATION> APPLICATIONs { get; }
        DbSet<APPLICATION_LU_CONFIG> APPLICATION_LU_CONFIG { get; }
        DbSet<COMP_Inventory_Inspec_Details> COMP_Inventory_Inspec_Details { get; }
        DbSet<COMPART_ATTACH_FILESTREAM> COMPART_ATTACH_FILESTREAM { get; }
        DbSet<COMPART_ATTACH_TYPE> COMPART_ATTACH_TYPE { get; }
        DbSet<COMPART_PARENT_RELATION> COMPART_PARENT_RELATION { get; }
        DbSet<COMPART_TOOL_IMAGE> COMPART_TOOL_IMAGE { get; }
        DbSet<ComponentLife> COMPONENT_LIFE { get; }
        DbSet<CRSF> CRSF { get; }
        DbSet<CRSF_AREA> CRSF_AREA { get; }
        DbSet<CRSF_TYPE> CRSF_TYPE { get; }
        DbSet<CUSTOMER> CUSTOMERs { get; }
        DbSet<Dealership> Dealerships { get; }
        DbSet<EQ_UNIT_HISTORY> EQ_UNIT_HISTORY { get; }
        DbSet<EQUIPMENT> EQUIPMENTs { get; }
        DbSet<EQUIPMENT_ACTIONS> EQUIPMENT_ACTIONS { get; }
        DbSet<EQUIPMENT_AUDIT_HISTOY> EQUIPMENT_AUDIT_HISTOY { get; }
        DbSet<EQUIPMENT_LIFE> EQUIPMENT_LIVES { get; }
        DbSet<GENERAL_EQ_UNIT> GENERAL_EQ_UNIT { get; }
        DbSet<GENERAL_EQ_UNIT_HISTORY> GENERAL_EQ_UNIT_HISTORY { get; }
        DbSet<GET> GETs { get; }
        DbSet<GET_ACTIONS> GET_ACTIONS { get; }
        DbSet<GET_COMPONENT> GET_COMPONENT { get; }
        DbSet<GET_COMPONENT_INSPECTION> GET_COMPONENT_INSPECTION { get; }
        DbSet<GET_CONFIG> GET_CONFIG { get; }
        DbSet<GET_EVENTS> GET_EVENTS { get; }
        DbSet<GET_EVENTS_COMPONENT> GET_EVENTS_COMPONENT { get; }
        DbSet<GET_EVENTS_EQUIPMENT> GET_EVENTS_EQUIPMENT { get; }
        DbSet<GET_EVENTS_IMPLEMENT> GET_EVENTS_IMPLEMENT { get; }
        DbSet<GET_IMPLEMENT_INSPECTION> GET_IMPLEMENT_INSPECTION { get; }
        DbSet<GET_IMPLEMENT_INSPECTION_IMAGE> GET_IMPLEMENT_INSPECTION_IMAGE { get; }
        DbSet<GET_INSPECTION_CONSTANTS> GET_INSPECTION_CONSTANTS { get; }
        DbSet<GET_INSPECTION_PARAMETERS> GET_INSPECTION_PARAMETERS { get; }
        DbSet<GET_INSPECTIONS_VIEWED> GET_INSPECTIONS_VIEWED { get; }
        DbSet<GET_INTERPRETATION_COMMENTS> GET_INTERPRETATION_COMMENTS { get; }
        DbSet<GET_OBSERVATION_IMAGE> GET_OBSERVATION_IMAGE { get; }
        DbSet<GET_OBSERVATION_LIST> GET_OBSERVATION_LIST { get; }
        DbSet<GET_OBSERVATION_RESULTS> GET_OBSERVATION_RESULTS { get; }
        DbSet<GET_OBSERVATIONS> GET_OBSERVATIONS { get; }
        DbSet<GET_SCHEMATIC_COMPONENT> GET_SCHEMATIC_COMPONENT { get; }
        DbSet<GET_SCHEMATIC_IMAGE> GET_SCHEMATIC_IMAGE { get; }
        DbSet<IMPLEMENT_CATEGORY> IMPLEMENT_CATEGORY { get; }
        DbSet<IMPLEMENT_READING_ENTRY> IMPLEMENT_READING_ENTRY { get; }
        DbSet<InspectionDetails_Side> InspectionDetails_Side { get; }
        DbSet<LU_COMPART> LU_COMPART { get; }
        DbSet<LU_COMPART_PARTS> LU_COMPART_PARTS { get; }
        DbSet<LU_COMPART_TYPE> LU_COMPART_TYPE { get; }
        DbSet<LU_GET_COMPART> LU_GET_COMPART { get; }
        DbSet<LU_GET_COMPART_SUB_TYPE> LU_GET_COMPART_SUB_TYPE { get; }
        DbSet<LU_GET_COMPART_TYPE> LU_GET_COMPART_TYPE { get; }
        DbSet<LU_IMPLEMENT> LU_IMPLEMENT { get; }
        DbSet<LU_MMTA> LU_MMTA { get; }
        DbSet<LU_Module_Sub> LU_Module_Sub { get; }
        DbSet<LU_Module_Sub_History> LU_Module_Sub_History { get; }
        DbSet<MAKE> MAKE { get; }
        DbSet<MODEL> MODELs { get; }
        DbSet<TRACK_ACTION> TRACK_ACTION { get; }
        DbSet<TRACK_ACTION_TAKEN> TRACK_ACTION_TAKEN { get; }
        DbSet<TRACK_ACTION_TYPE> TRACK_ACTION_TYPE { get; }
        DbSet<TRACK_COMPART_EXT> TRACK_COMPART_EXT { get; }
        DbSet<TRACK_COMPART_WORN_CALC_METHOD> TRACK_COMPART_WORN_CALC_METHOD { get; }
        DbSet<TRACK_COMPART_WORN_LIMIT_CAT> TRACK_COMPART_WORN_LIMIT_CAT { get; }
        DbSet<TRACK_COMPART_WORN_LIMIT_HITACHI> TRACK_COMPART_WORN_LIMIT_HITACHI { get; }
        DbSet<TRACK_COMPART_WORN_LIMIT_ITM> TRACK_COMPART_WORN_LIMIT_ITM { get; }
        DbSet<TRACK_COMPART_WORN_LIMIT_KOMATSU> TRACK_COMPART_WORN_LIMIT_KOMATSU { get; }
        DbSet<TRACK_COMPART_WORN_LIMIT_LIEBHERR> TRACK_COMPART_WORN_LIMIT_LIEBHERR { get; }
        DbSet<TRACK_DEALERSHIP_LIMITS> TRACK_DEALERSHIP_LIMITS { get; }
        DbSet<TRACK_INSPECTION> TRACK_INSPECTION { get; }
        DbSet<TRACK_INSPECTION_DETAIL> TRACK_INSPECTION_DETAIL { get; }
        DbSet<TRACK_TOOL> TRACK_TOOL { get; }
        DbSet<TYPE> TYPEs { get; }
        DbSet<SystemLife> UCSYSTEM_LIFE { get; }
        DbSet<USER_CRSF_CUST_EQUIP> USER_CRSF_CUST_EQUIP { get; }
        DbSet<USER_DEALERSHIP> USER_DEALERSHIP { get; }
        DbSet<USER_TABLE> USER_TABLE { get; }
        DbSet<UserAccessMaps> UserAccessMaps { get; }
        DbSet<APPLICATION_ERROR_LOG> APPLICATION_ERROR_LOG { get; }
        DbSet<Mbl_CompartAttach_filestream> Mbl_CompartAttach_filestream { get; }
        DbSet<Mbl_NewEquipment> Mbl_NewEquipment { get; }
        DbSet<Mbl_NewGENERAL_EQ_UNIT> Mbl_NewGENERAL_EQ_UNIT { get; }
        DbSet<Mbl_Track_Inspection> Mbl_Track_Inspection { get; }
        DbSet<Mbl_Track_Inspection_Detail> Mbl_Track_Inspection_Detail { get; }
        DbSet<TRACK_ACTION_COMPONENT> TRACK_ACTION_COMPONENT { get; }
        DbSet<TRACK_EQ_LIMITS> TRACK_EQ_LIMITS { get; }
        DbSet<TRACK_INSPECTION_IMAGES> TRACK_INSPECTION_IMAGES { get; }
        DbSet<TRACK_MODEL_LIMITS> TRACK_MODEL_LIMITS { get; }
        DbSet<FLUID_REPORT_LOGO> FLUID_REPORT_LOGO { get; }
        DbSet<FLUID_REPORT_LU_REPORTS> FLUID_REPORT_LU_REPORTS { get; }
        DbSet<FLUID_REPORT_LU_SETTINGS> FLUID_REPORT_LU_SETTINGS { get; }
        DbSet<DealershipReports> DealershipReports { get; }
        DbSet<CustomerReports> CustomerReports { get; }
        DbSet<TRACK_QUOTE> TRACK_QUOTE { get; }
        DbSet<DealershipBranding> DealershipBranding { get; }
        DbSet<ApplicationStyle> ApplicationStyle { get; }
        DbSet<ClientRedirectUri> ClientRedirectUris { get; }
        DbSet<LANGUAGE> LANGUAGE { get; }
        DbSet<TRACK_COMPART_MODEL_MAPPING> TRACK_COMPART_MODEL_MAPPING { get; }
        DbSet<SHOE_SIZE> SHOE_SIZE { get; }
        DbSet<SystemModelTemplate> SystemModelTemplate { get; }
        DbSet<SystemFamilyTemplate> SystemFamilyTemplate { get; }
        DbSet<TrackInspectionImagesMain> TrackInspectionImagesMain { get; }
        DbSet<TrackInspectionMeasurePoints> TrackInspectionMeasurePoints { get; }
        DbSet<MeasurePointTypes> MeasurePointTypes { get; }
        DbSet<MeasurePointTools> MeasurePointTools { get; }
        DbSet<TrackInspectionRecords> TrackInspectionRecords { get; }
        DbSet<TrackInspectionImagesRecords> TrackInspectionImagesRecords { get; }
        DbSet<TrackInspectionComments> TrackInspectionComments { get; }
        DbSet<TrackInspectionCommentImages> TrackInspectionCommentImages { get; }
        DbSet<TrackInspectionCommentTypes> TrackInspectionCommentTypes { get; }
        DbSet<ModelCommentMap> ModelCommentMap { get; }
        DbSet<LuLinksCondition> LuLinksCondition { get; }
        DbSet<TRACK_QUOTE_DETAIL> TRACK_QUOTE_DETAIL { get; }
        DbSet<TRACK_QUOTE_STATUS> TRACK_QUOTE_STATUS { get; }
        DbSet<TRACK_QUOTE_STATUS_HISTORY> TRACK_QUOTE_STATUS_HISTORY { get; }
        DbSet<SearchFavorite> SearchFavorite { get; }
        DbSet<SearchFavoriteItems> SearchFavoriteItems { get; }
        DbSet<LU_QuoteReport> LU_QuoteReports { get; }
        DbSet<DealershipQuoteReports> DealershipQuoteReports { get; }
        DbSet<DASHBOARD_SEARCH> DASHBOARD_SEARCH { get; }
        DbSet<SEARCH_ITEM> SEARCH_ITEM { get; }
    }
}
//    
//  
//  