using System;
using System.Collections.Generic;

namespace DxBlue.Models.trans
{

    public class LogisticStatusModel : DSR_Model
    {
        public int RecordId { get; set; }
        public new int DsrId { get; set; }

        public int IsMaterialReadyInDays { get; set; }
        public int? MaterialReadyInDays { get; set; }
        public DateTime? MaterialReadyPlanDate { get; set; }
        public DateTime? MaterialReadyActualDate { get; set; }
        public int? MaterialStatusId { get; set; }
        public string MaterialStatusName { get; set; }
        public DateTime? MaterialStatusPlanDate { get; set; }
        public DateTime? MaterialStatusActualDate { get; set; }
        
    }
    public class LogisticModel
    {
        public string AreaName { get; set; }
        public int LogisticId { get; set; }
        public DateTime LogisticDate { get; set; }
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Carrier { get; set; }
        public string DocketNo { get; set; }
        public DateTime DocketDate { get; set; }
        public string ChallanNo { get; set; }
        public DateTime ChallanDate { get; set; }
        public int NoOfBoxes { get; set; }
        public string Remarks { get; set; }
        public List<LogisticItemModel> LogisticItems { get; set; }
        public bool IsACtive { get; set; }
        public string PartyName { get; set; }
        public string OrderByName { get; set; }

        public decimal OrderAmt { get; set; }
        public decimal PendingAmt { get; set; }
        public string LogisticStatus { get; set; }
    }

    public class LogisticItemModel
    {
        public int RecordId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalQty { get; set; }
        public int OutQty { get; set; }
        public int PendingQty { get; set; }
    }
}
