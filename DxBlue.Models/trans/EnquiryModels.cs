using System;
using System.Collections.Generic;

namespace DxBlue.Models.trans
{
    public class Enquiry_RootModel
    {
        public EnquiryModel EnquiryModel { get; set; }
        public List<Enquiry_ActivityModel> ActivityList { get; set; }
        public List<EnquiryProductModel> ProductList { get; set; }
    }
    public class EnquiryModel : BaseModel
    {
        public int EnquiryId { get; set; }
        public string EnquiryNo { get; set; }
        public DateTime EnquiryDate { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public int LeadSourceId { get; set; }
        public string LeadSourceName { get; set; }
        public int LeadAssignToId { get; set; }
        public string LeadAssignToName { get; set; }
        public int BillingTypeId { get; set; }
        public string BillingTypeName { get; set; }
        public int EnquiryFlowId { get; set; }
        public string EnquiryFlowName { get; set; }
        public int PartnerTypeId { get; set; }
        public string PartnerTypeName { get; set; }
        public int CustomerId { get; set; }
        public int PartyId { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public int EnquiryTypeId { get; set; }
        public string EnquiryTypeName { get; set; }
        public string Remarks { get; set; }

        public int EnquiryStatusId { get; set; }
        public string EnquiryStatusName { get; set; }
        public int EnquiryStageId { get; set; }
        public string EnquiryStageName { get; set; }
        public List<EnquiryProductModel> EnquiryProducts { get; set; } = null;
        public List<Enquiry_ActivityModel> EnquiryActivities { get; set; } = null;

        public int EnquiryForId { get; set; }
        public string ContactName { get; set; }
        public decimal? TotalAmt { get; set; }
        public DateTime? FollowUpOn { get; set; }

    }
    public class EnquiryProductModel : BaseModel
    {
        public int EnquiryId { get; set; }
        public int ProductId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        //public decimal Disc { get; set; }
        public decimal GST { get; set; }
        public decimal TradeDisc { get; set; }
        public decimal CashDisc { get; set; }
        public decimal FreightAmt { get; set; }
        public decimal Amount { get; set; }
        public decimal GST_Amt { get; set; }

        public decimal MinSellingPrice { get; set; }
        public decimal MaxSellingPrice { get; set; }
        public decimal TranLimit { get; set; }
        public int AvailableQty { get; set; }

    }
    public class Enquiry_ActivityModel : BaseModel
    {
        public int EnquiryId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public decimal Amount { get; set; }
    }
    public class EnquiryFollowUpModel : BaseModel
    {
        public int FollowupId { get; set; }
        public int EnquiryId { get; set; }
        public DateTime FollowUpDate { get; set; } = DateTime.Now;
        public string Remarks { get; set; }
        public int EnquiryStageId { get; set; }
        public string EnquiryStageName { get; set; }
        public int EnquiryStatusId { get; set; }
        public string EnquiryStatusName { get; set; }
        public string OtherStatus { get; set; }
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public int PartyId { get; set; }
        public string PartyName { get; set; }
        public DateTime NextDate { get; set; } = DateTime.Parse("01/01/1900");
        public string CaseStudy { get; set; }

    }
}
