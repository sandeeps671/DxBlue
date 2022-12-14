using DxBlue.Common.Utility;

namespace DxBlue.Models.masters
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal MinSellingPrice { get; set; }
        public decimal MaxSellingPrice { get; set; }

        public decimal MinDiscount { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool HasSerial { get; set; }
        public string SerialStatus { get; set; }
        public string SerialNo { get; set; }
        
        public string SerialQty { get; set; }
        public int Qty { get; set; }
        public int BinId { get; set; }
        public string ProductBin { get; set; }

       
        public int WarrantyPeriod { get; set; }

    }
    public class SerialModel
    {
        public string SaleDt { get; set; } = ClsUtility.GetCurrentDateDmy();
        public bool HasSerial { get; set; } = true;
        public string SerialNo { get; set; } = "";
        public string SerialNoQty { get; set; } = "";
        public string WarrantyValid { get; set; } = ClsUtility.GetCurrentDateDmy();
        public int SaleRecordId { get; set; } = 0;
        public int SourceId { get; set; } = 0;
        public string SourceType { get; set; } = "";
        public int ProductId { get; set; } = 0;
        public string ProductName { get; set; } = "";
        public bool IsInWarranty { get; set; } = false;
        public string WarrantyStatus { get; set; } = "NOT OUR PRODUCT";
        public int WarrantyStatusId { get; set; } = 2;
        public bool IsOurProduct { get; set; } = false;

        public string BranchName { get; set; } = "";

        public int BranchId { get; set; } = 0;
        public int StockInId { get; set; } = 0;
        public string ProductBin { get; set; }
        public int BinId { get; set; } = 0;
        public int Qty { get; set; } = 0;
    }

    public class SaleProductModel:BaseModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal MinSellingPrice { get; set; }
        public decimal MaxSellingPrice { get; set; }
        public decimal MinDiscount { get; set; }
        
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public bool HasSerial { get; set; }
        public string SerialStatus { get; set; }
        public int Warranty { get; set; }
        public bool Disabled { get; set; }
        public decimal TranLimit { get; set; }
        public decimal GST { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }

        public int AreaId { get; set; }
        public string AreaName { get; set; }
    }
}
