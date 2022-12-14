using System;

namespace DxBlue.Models.trans
{
    public class FmsBaseForGoogleSheet
    {
        public int RecordId { get; set; }
        public int DsrId { get; set; }
        public int FmsId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public string OrderId { get; set; }
    }
    public class DsrFmsDataModel : FmsBaseForGoogleSheet
    {
        public string BranchName { get; set; }        
        public string PartyName { get; set; }
        public string BriefDescription { get; set; }
        public string DispatchFrom { get; set; }
        public string CreditDays { get; set; }
        public decimal OrderAmt { get; set; }
        public string ContactNo { get; set; }
        public string Priority { get; set; }
        public string OrderByName { get; set; }
        public string Remarks { get; set; }
    }
    public class FmsSalesApprovalModel : FmsBaseForGoogleSheet
    {
        public string SaleApprovalStatusName { get; set; }
        public string SaleApprovalStatusByUserName { get; set; }
    }
    public class FmsMaterialReadyDaysModel : FmsBaseForGoogleSheet
    {
        public int EstimatedMaterialReadyTime { get; set; }
    }
    public class FmsMaterialConfirmationModel : FmsBaseForGoogleSheet
    {
        public string MaterialStatus { get; set; }
    }
    public class FmsAccountApprovalModel : FmsBaseForGoogleSheet
    {
        public string AssignedToName { get; set; }
        public string AccountApprovalStatus { get; set; }
        public string ConcernedIssue { get; set; }
    }
    public class FmsReSalesApprovalModel : FmsBaseForGoogleSheet
    {
        public string ReSalesApprovalStatus { get; set; }
        public string ReSaleApprovalRemark { get; set; }
    }
    public class FmsReAccountsApprovalModel : FmsBaseForGoogleSheet
    {
        public string ReAccountsApprovalStatus { get; set; }
        public string ReAccountApprovalRemark { get; set; }
    }
    public class FmsTransportStatusModel : FmsBaseForGoogleSheet
    {
        public string TransporterName { get; set; }
        public string TransportDocketNo { get; set; }
    }
    public class FmsSerialNoStatusModel : FmsBaseForGoogleSheet
    {
        public string SerialNoUploadingStatus { get; set; }
    }
    public class FmsBillingStatusModel : FmsBaseForGoogleSheet
    {
        public string BillingStatus { get; set; }
        public string BillingInvoiceNo { get; set; }
        public string InvoiceAmt { get; set; }
        public string InvoiceLink { get; set; }
        public string EWayBillLink { get; set; }
        public string EInvoiceLink { get; set; }
        public string BranchName { get; set; }
        public string PartyName { get; set; }
        public int CreditDays { get; set; }
        public string MobileNo { get; set; }
    }
    public class FmsPhysicalDispatchModel : FmsBaseForGoogleSheet
    {
        public string DispatchStatus { get; set; }
        public int EstimatedTransitTime { get; set; }
        public decimal Weight { get; set; }
        public decimal Distance { get; set; }
    }
    public class FmsDeliveryConfirmationModel : FmsBaseForGoogleSheet
    {
        public string DeliveryStatusName { get; set; }
    }
    public class FmsDeliveryTrackingModel : FmsBaseForGoogleSheet
    {
        public string LastKnownTrackingStatus { get; set; }
        public string EstimatedTrackingTime { get; set; }
    }
    public class FmsInvoicingModel : FmsBaseForGoogleSheet
    {
        public string InvoiceReceiveStatusName { get; set; }
        public string ReceivingCopy { get; set; }
        public string DocketCopy { get; set; }
        public string InvoiceEnteredByName { get; set; }
    }
}
