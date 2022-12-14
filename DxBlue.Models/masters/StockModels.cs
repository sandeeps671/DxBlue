using System;
using System.Collections.Generic;

namespace DxBlue.Models.masters
{
    public class OpeingStockUploadHistoryModal
    {
        public int RecordId { get; set; }
        public DateTime OpeningDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public int MainQty { get; set; }
        public int TransitQty { get; set; }
        public int TotalQty { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadByName { get; set; }
        public int UploadById { get; set; }
    }
    public class OpeningStockModel
    {
        public int RecordId { get; set; }
        public DateTime OpeningDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }

        public int MainQty { get; set; }
        public int TransitQty { get; set; }
        public int TotalQty { get; set; }

        public int MinSellingPrice { get; set; }
        public int MaxSellingPrice { get; set; }

        public int ApprovedQty { get; set; }
        public int BilledQty { get; set; }
        public int PendingQty { get; set; }
        public string ApprovedQtyLink { get; set; }
        public string PendingQtyLink { get; set; }
        public int RemainingQty { get; set; }
        public int ReceiveQty { get; set; }
        public static string GoogleFileName = "1QmoPDHapmZ5_DNP-fg4eOMHqNesVUxAJUinW1hC5oQM";
        public static string GoogleSheetName = "Item Stock";
    }

    public class AvailableQtyModel
    {
        public int ProductId { get; set; }
        public string Date { get; set; }
        public int AreaId { get; set; }
        public int MainQty { get; set; }
        public int TransitQty { get; set; }
        public int TotalQty { get; set; }
        public int RemainingQty { get; set; }
    }
    public class TransitDataModel
    {
        public int RecordId { get; set; }
        public int ProductId { get; set; }
        public int AreaId { get; set; }
        public int ReceiveQty { get; set; }
    }
    public class ReceiveTransitQtyModel
    {
        public List<TransitDataModel> TransitData { get; set; }
    }
    public class TransitQtyModel
    {
        public int RecordId { get; set; }
        public DateTime OpeningDate { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Date { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int MainQty { get; set; }
        public int TransitQty { get; set; }
        public int ReceiveQty { get; set; }
        public int TotalQty { get; set; }
    }
}
