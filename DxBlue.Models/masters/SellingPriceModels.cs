namespace DxBlue.Models.masters
{
    public class SellingPriceModel
    {
        public int SpId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal MinSellingPrice { get; set; }
        public decimal MaxSellingPrice { get; set; }
        public decimal TranLimit { get; set; }
    }
}
