using System;

namespace DxBlue.Models.mis
{
    public class FMSReportModel
    {
        public DateTime PlannedDate { get; set; }
        public string BranchName { get; set; }
        public string DispatchFrom { get; set; }
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public string PartyName { get; set; }
        public int CreditDays { get; set; }
        public string PaymentTerm { get; set; }
        public string OrderByName { get; set; }
        public string BriefDescription { get; set; }
        public string Step { get; set; }
        public int StepSerialNo { get; set; }
        public string OrderAmt { get; set; }
        public string PendingOrderText { get; set; }
        public int PendingStepId { get; set; }
    }
}
