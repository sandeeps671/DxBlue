using System;

namespace DxBlue.Models.trans
{
    public class DuePaymentModel : BaseModel
    {
        public int DuePaymentId { get; set; }
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public int CreditDays { get; set; }
        public int OverdueDays { get; set; }

        public int AssignTo { get; set; }
        public string AssignToName { get; set; }
        public int AssignBy { get; set; }
        public string AssignByName { get; set; }
        public string Remarks { get; set; }
        public bool IsApprove { get; set; }
        public string ApprovalStatus { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public DateTime DueDate { get; set; }

        public decimal TotalAmt { get; set; }
        public decimal Amount { get; set; }
        public decimal OrderAmt { get; set; }
        public decimal PendingAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal OtherAmt { get; set; }

        public decimal NetAmt { get; set; }
        public decimal ReceivedAmt { get; set; }
        public string OrderByName { get; set; }
        public string Comment { get; set; }
        public int HasCollected { get; set; }

        public string InvoiceLink { get; set; }
        public string EwayBillLink { get; set; }
        public string EInvoiceLink { get; set; }

        public static string GoogleFileName = "1HBDsqC_pteeDvVq_x2uiKUfHSWu29kE-RKsqubh201w";
        public static string GoogleSheetName = "Billing";
        public static string GoogleSheetRange = "Billing!A:R";

        public decimal UnApprovedReceivableAmt { get; set; }
        public decimal ActualPendingAmt { get; set; }
    }

    public class ReceivePaymentModel : BaseModel
    {
        public int PaymentReceiveId { get; set; }
        public int DuePaymentId { get; set; }
        public DateTime CollectionDate { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public decimal ReceiveAmt { get; set; }
        public DateTime HoDate { get; set; }
        public DateTime ChequeDepositDate { get; set; }
        public string Remarks { get; set; }

        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }

        public int AdvanceId { get; set; }
        public string AdvSource { get; set; }

        public string EnteredByName { get; set; }
        public bool IsActive { get; set; }
        public bool IsApproved { get; set; }

        public string HoRemarks { get; set; }
        public int DepositLocationId { get; set; }
        public string DepositLocationName { get; set; }
        public string DeletedByUserName { get; set; }
        public DateTime DeletedDate { get; set; }
    }
    public class AmountAdjustmentModel
    {
        public int DsrId { get; set; }
        public int DuePaymentId { get; set; }
        public string PartyName { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime AdjustmentDate { get; set; }
        public decimal AdjustmentAmt { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovalStatus { get; set; }
    }
    public class DuePaymentCommentModel
    {
        public int DuePaymentId { get; set; }
        public string Comment { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class DuePaymentCashChqStatusModel
    {
        public int DuePaymentId { get; set; }
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public int PaymentReceiveId { get; set; }
        public DateTime CollectionDate { get; set; }
        public string PartyName { get; set; }
        public string PaymentMode { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? HoDate { get; set; }
        public DateTime? ChequeDepositDate { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }
        public decimal CollectionAmt { get; set; }
    }
}
