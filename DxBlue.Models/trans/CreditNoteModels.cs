using System;

namespace DxBlue.Models.trans
{
    public class CreditNoteModel : BaseModel
    {
        public int CreditNoteId { get; set; }
        public int SalesReturnId { get; set; }
        public string CreditNoteNo { get; set; }
        public DateTime CreditNoteDate { get; set; }
        public decimal CreditNoteAmt { get; set; }
        public string AreaName { get; set; }
        public string CompanyName { get; set; }
        public string MobileNo { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }

        public bool IsAdjusted { get; set; }
        public string AdjustmentStatus { get; set; }
        public decimal AdjustedAmt { get; set; }
        public decimal PendingAmt { get; set; }
    }
}
