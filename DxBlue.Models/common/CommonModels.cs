using System;

namespace DxBlue.Models.common
{
    public class StaticModel
    {
        public static string TicketStatusGoogleSheetId = "1XSeI822qR0hknBxpbckRWi4UtnJ5ILqzO-Mbx2aLnX8";
        public static string TicketStatusGoogleSheetRange = "TicketStatus!A:V";

        public static string DsrFmsGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string DsrFmsGoogleSheetRange = "SO!A:L";

        public static string FmsSalesApprovalGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsSalesApprovalGoogleSheetRange = "App Sales!A:D";

        public static string FmsMaterialReadyDaysGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsMaterialReadyDaysGoogleSheetRange = "Mat Con Day!A:C";

        public static string FmsMaterialConfirmationGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsMaterialConfirmationGoogleSheetRange = "Mat Con Status!A:C";

        public static string FmsAccountsApprovalGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsAccountsApprovalGoogleSheetRange = "App Acc!A:E";

        public static string FmsReSalesApprovalGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsReSalesApprovalGoogleSheetRange = "Re-App Sales!A:D";

        public static string FmsReAccountsApprovalGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsReAccountsApprovalGoogleSheetRange = "Re-App Acc!A:D";

        public static string FmsSerialNoGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsSerialNoGoogleSheetRange = "SRN!A:C";

        public static string FmsBillingGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsBillingGoogleSheetRange = "Billing!A:L";

        public static string FmsPhysicalDispatchGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsPhysicalDispatchGoogleSheetRange = "Dispatch!A:F";

        public static string FmsTransportStatusGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsTransportStatusGoogleSheetRange = "Transport!A:D";

        public static string FmsTrackingStatusGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsTrackingStatusGoogleSheetRange = "Tracking!A:D";

        public static string FmsDeliveryConfirmationGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsDeliveryConfirmationGoogleSheetRange = "Delivery!A:C";

        public static string FmsInvoiceReceivingGoogleSheetId = "13MUq3wMTBeXbeHbiH_Yd4vxzkVaOCpPg15aQrjs3rpo";
        public static string FmsInvoiceReceivingGoogleSheetRange = "Inv Receiving!A:F";
    }
    public class SearchModel
    {
        public SearchModel()
        {
            Origin = string.Empty;
        }
        public int branchId { get; set; }
        public string SearchText { get; set; }
        public string SearchFor { get; set; }
        public int Tag { get; set; }

        public string Origin { get; set; }

        public int productId { get; set; }
        public int groupId { get; set; }
        public int categoryId { get; set; }
        public int serialWise { get; set; }
        public int binId { get; set; }

    }

    public class PaymentModeModel
    {
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
    }
    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
    public class LastSyncDetailModel
    {
        public DateTime LastSyncDate { get; set; } = DateTime.Parse("01/01/1900");
        public string LastSyncDateText { get; set; } = "";
    }
    public class DepositAtLocationModel
    {
        public int DepositLocationId { get; set; }
        public string DepositLocationName { get; set; }
    }
    public class BillingTypeModel
    {
        public int BillingTypeId { get; set; }
        public string BillingTypeName { get; set; }
    }
    public class EnquiryFlowModel
    {
        public int EnquiryFlowId { get; set; }
        public string EnquiryFlowName { get; set; }
    }
    public class PartnerTypeModel
    {
        public int PartnerTypeId { get; set; }
        public string PartnerTypeName { get; set; }
    }
    public class EnquiryTypeModel
    {
        public int EnquiryTypeId { get; set; }
        public string EnquiryTypeName { get; set; }
    }
    public class EnquiryStatusModel : EnquiryStageModel
    {
        public string CaseStudy { get; set; }
        public int EnquiryStatusId { get; set; }
        public string EnquiryStatusName { get; set; }
    }
    public class EnquiryStageModel // i.e. Enquiry Stage
    {
        public int EnquiryStageId { get; set; }
        public string EnquiryStageName { get; set; }
        public int SerialNo { get; set; }
    }
    public class LogisticMaterialStatusModel
    {
        public int MaterialStatusId { get; set; }
        public string MaterialStatusName { get; set; }
        public int SerialNo { get; set; }
    }

    public class DsrAccountStatusModel
    {
        public int DsrAccountStatusId { get; set; }
        public string DsrAccountStatusName { get; set; }
        public int SerialNo { get; set; }
    }
    public class AdvPdcCdcModel
    {
        public int AdvPdcCdcId { get; set; }
        public string AdvPdcCdcName { get; set; }
    }
    public class TatModeModel
    {
        public int TatModeId { get; set; }
        public string TatModeName { get; set; }
    }
}
