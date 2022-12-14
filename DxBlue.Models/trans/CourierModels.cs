using System;

namespace DxBlue.Models.trans
{
    public class CourierOutModel
    {
        public int CourierId { get; set; }
        public int CustomerId { get; set; }
        public string CourierOutNo { get; set; }
        public DateTime CourierOutDate { get; set; }
        public string DocketNo { get; set; }
        public DateTime DocketDate { get; set; }

        public string ChallanNo { get; set; }
        public DateTime ChallanDate { get; set; }
        public string Remarks { get; set; }
        public bool Disabled { get; set; }
        public int TotalItems { get; set; }

    }

    public  class PendingItemModel
    {
        public DateTime TicketDate { get; set; }
        public int TicketId { get; set; }
        public int TicketItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SerialNo { get; set; }
        public int Qty { get; set; }
        public bool Disabled { get; set; }
    }
}
