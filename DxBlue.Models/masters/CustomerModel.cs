namespace DxBlue.Models.masters
{
    public class SalesCustomerModel : BaseModel
    {
        public int CustomerId { get; set; } = 0;
        public string CustomerName { get; set; } = "";
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public bool IsApproved { get; set; }
        public bool IsBlocked { get; set; }
        public int CreditDays { get; set; }
        public int AreaId { get; set; }
        public string EmailId { get; set; } = string.Empty;
        public int SourceId { get; set; } = 0; // 0 Direct, 1: DSR, 2: Enquiry
    }
}
