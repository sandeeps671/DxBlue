using System;
using System.Collections.Generic;

namespace DxBlue.Models.trans
{
    public class Dsr_RootModel
    {
        public DSR_Model DsrModel { get; set; }
        public List<DSR_ActivityModel> ActivityList { get; set; }
        public List<DSR_ProductModel> ProductList { get; set; }
    }
    public class DSR_Model : BaseModel
    {
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public DateTime Date { get; set; } = DateTime.Parse("01/01/1900");
        public int PartyId { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string Purpose { get; set; }
        public int FollowUpId { get; set; }
        public string FollowUp { get; set; }
        public string Remarks { get; set; }
        public bool IsApproved { get; set; } = false;
        public int ApproveById { get; set; }
        public string ApproveByName { get; set; }
        public string Approve_Type { get; set; }
        public int OrderById { get; set; }
        public string OrderByName { get; set; }
        public string Others { get; set; }
        public string Days { get; set; }
        public string Reference { get; set; }
        public string Transporter { get; set; }
        public string CompanyName { get; set; }
        public int CustomerId { get; set; }
        public int DispatchFromId { get; set; }
        public string DispatchFrom { get; set; }
        public int ConvertById { get; set; }
        public DateTime ConvertDate { get; set; }

        public string SsoContactName { get; set; }
        public string SsoCompanyName { get; set; }
        public string SsoAddress { get; set; }
        public string SsoContactNo { get; set; }

        public decimal Amount { get; set; }
        public decimal PendingAmt { get; set; }

        public bool Disabled { get; set; } = false;
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string ApprovalStatus { get; set; }
        public bool IsBilled { get; set; }
        public string EmailId { get; set; }
        public int SourceId { get; set; }
        public decimal TcsAmount { get; set; }
        public bool IsTcsApplicable { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? CreditDays { get; set; }
        public string ADV_PDC_CDC { get; set; } // Payment Term
        public string PaymentTerm{ get; set; }
        public string OrderDesc { get; set; }
    }
    public class DSR_ProductModel
    {
        public int DsrId { get; set; }
        public int ProductId { get; set; }
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

    public class DSR_ActivityModel
    {
        public int DsrId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public decimal Amount { get; set; }
    }

    public class OrderStockModel
    {
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public string AreaName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string PartyName { get; set; }
        public string ContactName { get; set; }

        public string Purpose { get; set; }
        public string OrderByName { get; set; }
        public int Qty { get; set; }
        public decimal OrderAmt { get; set; }
    }

    public class ApprovedDsrModel : BaseModel
    {
        public int DsrId { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PartyName { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string ApprovedByName { get; set; }
        public string OrderPunchByName { get; set; }
        public string AreaName { get; set; }
        public decimal OrderAmt { get; set; }
        public decimal PendingAmt { get; set; }
        public int TotalProducts { get; set; }
        public int TotalProductUploaded { get; set; }
        public int TotalNonSerialProduct { get; set; }
        public bool IsApproved { get; set; }
        public bool IsSynced { get; set; }
    }


    public class SaleProductSerialModel
    {
        public int RecordId { get; set; }
        public int SNo { get; set; }
        public string Branch { get; set; }
        public string OrderId { get; set; }
        public string Party { get; set; }
        public string ProductName { get; set; }
        public string ServiceBranch { get; set; }
        public string SerialQty { get; set; }

        public int DsrId { get; set; }
        public string PartyName { get; set; }
        public string AreaName { get; set; }
        public bool HasSerial { get; set; }
        public string SerialNo { get; set; }
        public int Qty { get; set; }
        public int MaxQty { get; set; }
        public bool IsApproved { get; set; }
    }
    public class OrderListItemWiseModel
    {
        public string SsoParty { get; set; }
        public string SsoCustomerName { get; set; }
        public string SsoContactNo { get; set; }

        public string SsoAddress { get; set; }
        public int DsrId { get; set; }

        public string OrderPunchByName { get; set; }

        public DateTime OrderDate { get; set; }
        public string OrderId { get; set; }
        public string PartyName { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string Purpose { get; set; }
        public decimal PendingAmt { get; set; }
        public bool IsApproved { get; set; }
        public string ApproveStatus { get; set; }
        public string ApprovedByName { get; set; }

        public int Qty { get; set; }
        public int ProductId { get; set; }
        public string ProductGroup { get; set; }
        public string ProductName { get; set; }
        public decimal Rate { get; set; }
        public decimal OrderAmt { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal GstAmt { get; set; }
        public decimal TradeDisc { get; set; }
        public decimal CashDisc { get; set; }
        public decimal FreightAmt { get; set; }
        public decimal NetAmt { get; set; }
        public decimal Amount { get; set; }


        public string ADV_PDC_CDC { get; set; }
        public int CreditDays { get; set; }
        public string DispatchFrom { get; set; }
        public string Transporter { get; set; }
        public string Remarks { get; set; }

        public string Address { get; set; }
        public DateTime EntryDt { get; set; }

    }
    public class PartyOverDueAmtModel
    {
        public int PartyId { get; set; }
        public decimal TotalBillAmt { get; set; }
        public decimal ReceivedAmt { get; set; }
        public decimal PendingAmt { get; set; }
        public int OverDueDays { get; set; }
    }
    public class DsrBillModel
    {
        public int BillId { get; set; }
        public int DsrId { get; set; }
        public string BillNo { get; set; }
        public DateTime BillDate { get; set; }

        public string Transporter { get; set; }
        public string DocketNo { get; set; }
        public bool IsActive { get; set; }

        public string PartyName { get; set; }
        public string ContactNo { get; set; }
        public string PartyAddress { get; set; }
        public string OrderId { get; set; }
        public DateTime DsrDate { get; set; }
        public string Purpose { get; set; }
        public int OrderById { get; set; }
        public string OrderByName { get; set; }
        public int ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public static string GoogleFileName = "1HBDsqC_pteeDvVq_x2uiKUfHSWu29kE-RKsqubh201w";
        public static string GoogleSheetRange = "Transport!A:F";

    }
}
