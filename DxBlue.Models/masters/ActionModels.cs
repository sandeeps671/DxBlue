using System;

namespace DxBlue.Models.masters
{
    public class ActionModel
    {
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.Parse("01/01/1900");
        public DateTime CurrentDate { get; set; } = DateTime.Parse("01/01/1900");
        public static string OpenigStockMode = "OPENING_STOCK";
        public static string DuePaymentMode = "SYNC_DUE_PAYMENT";

        public static string DsrBillMode = "SYNC_DSR_BILL";
    }

}
