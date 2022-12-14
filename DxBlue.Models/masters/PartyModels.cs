namespace DxBlue.Models.masters
{
    public class PartyModel : BaseModel
    {
        public int PartyId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string MobileNo { get; set; }
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CreditDays { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public new bool IsActive { get; set; }
        public string GST_No { get; set; }
        public string PAN_No { get; set; }
        public decimal CreditLimit { get; set; }
        public string Pincode { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string ClientCode { get; set; }
        public bool IsTcsApplicable { get; set; }
        public int AdvPdcCdcId { get; set; }
        public string AdvPdcCdcName { get; set; }
    }
}
