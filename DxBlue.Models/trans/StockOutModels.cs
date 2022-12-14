using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxBlue.Models.trans
{
    public class StockOutModel : BaseModel
    {
        public int StockOutId { get; set; }
        public DateTime StockOutDate { get; set; }
        public string StockOutNo { get; set; }
        public int FromBranchId { get; set; }
        public string FromBranchName { get; set; }
        public int ToBranchId { get; set; }
        public string ToBranchName { get; set; }
        public string Remarks { get; set; }
        public string StockOutMode { get; set; }
        public bool Disabled { get; set; }
        public IEnumerable<StockOutItemModel> Items { get; set; }
        public int TotalQty { get; set; }
        public bool HasCourierOut { get; set; }
        public bool HasStockIn { get; set; }
        public bool HasTransitLoss { get; set; }
    }
    public class StockOutItemModel
    {
        public int StockOutId { get; set; }
        public int StockOutItemId { get; set; }
        public bool HasSerial { get; set; }
        public int ProductGroupId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SerialNo { get; set; }
        public int Qty { get; set; }
        public int BinId { get; set; }
        public string ProductBin { get; set; }
        public bool Disabled { get; set; }
    }
}
