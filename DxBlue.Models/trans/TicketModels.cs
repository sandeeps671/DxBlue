using System;
using System.Collections.Generic;

namespace DxBlue.Models.trans
{
    public class TicketModel
    {
        public string TicketFor { get; set; }
        public string Mode { get; set; }
        public int TicketId { get; set; }
        public int TicketBranchId { get; set; }
        public string TicketNo { get; set; }
        public DateTime TicketDate { get; set; }
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public List<TicketItemModel> Items { get; set; }
        public int TicketStatus { get; set; }
        public string TicketStatusName { get; set; }
        public bool Disabled { get; set; }

        #region Sub Customer
        public int SubCustomerId { get; set; }
        public string SubCompanyName { get; set; }
        public string SubCustomerName { get; set; }
        public string SubCustomerCity { get; set; }
        public string SubCustomerMobileNo { get; set; }
        public string SubCustomerEmailId { get; set; }
        #endregion

    }
    public class TicketItemModel
    {
        public int ProductGroupId { get; set; }
        public string ProductGroup { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SourceId { get; set; }
        public int SaleRecordId { get; set; }
        public DateTime SaleDt { get; set; }
        public string SerialNo { get; set; } = String.Empty;
        public bool HasSerial { get; set; }
        public bool IsOurProduct { get; set; }
        public DateTime WarrantyValid { get; set; }
        public int WarrantyStatusId { get; set; }
        public string WarrantyStatus { get; set; }
        public int PhysicalConditionId { get; set; }
        public string PhysicalCondition { get; set; }
        public int ReportedProblemId { get; set; }
        public string ReportedProblem { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public int ApprovalStatus { get; set; } = 0;

    }

    public class TicketStatusModel
    {
        public int RecordId { get; set; }
        public string StatusDate { get; set; }
        public int TicketItemId { get; set; }
        public string BranchName { get; set; }
        public string TicketNo { get; set; }
        public string TicketDate { get; set; }
        public string CustomerName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }

        public string ProductName { get; set; }
        public string SerialNo { get; set; }
        public bool HasSerial { get; set; }
        public string WarrantyValid { get; set; }
        public string WarrantyStatus { get; set; }
        public string PhysicalStatus { get; set; }
        public string ReportedProblem { get; set; }
        public string ServiceType { get; set; }
        public string ReplacedProduct { get; set; }
        public string ReplacedSerial { get; set; }
        public string ReplacedBin { get; set; }
        public string ReplacementDate { get; set; }
    }
}
