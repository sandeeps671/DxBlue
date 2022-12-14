namespace DxBlue.Models.masters
{
    public class SaleOpeningStockModel
    {
        public int RecordId { get; set; }
        public string OpeningDate { get; set; }
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
        public int PendingQty { get; set; }
        public string ApprovedQtyLink { get; set; }
        public string PendingQtyLink { get; set; }
        public int RemaingQty { get; set; }
    }
    public class SaleAvailableStockModel
    {
        public int productId { get; set; }
        public string date { get; set; }
        public int areaId { get; set; }
        public int mainQty { get; set; }
        public int transitQty { get; set; }
        public int totalQty { get; set; }
    }
}
