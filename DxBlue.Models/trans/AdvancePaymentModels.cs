using System;

namespace DxBlue.Models.trans
{
    public class AdvancePaymentModel : BaseModel
    {
        public int AdvanceId { get; set; }
        public string AdvSource { get; set; }
        public string AdvNo { get; set; }
        public DateTime AdvDate { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public string Remarks { get; set; }
        public decimal PendingAmt { get; set; }
        public decimal AdvanceAmt { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovalStatus { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string ContactName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }

        public int ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public decimal AdjustedAmt { get; set; }
        public bool IsAdjusted { get; set; }
        public int DsrId { get; set; }
        public string OrderId { get; set; }
    }

    public class AdvancePaymentIUModel
    {
        public int AdvanceId { get; set; }
        public string AdvNo { get; set; }
        public DateTime AdvDate { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public string Remarks { get; set; }
        public decimal AdvanceAmt { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovalStatus { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public string ContactName { get; set; }
        public string MobileNo { get; set; }

        public int ApprovedById { get; set; }
        public string ApprovedByName { get; set; }

    }
}
