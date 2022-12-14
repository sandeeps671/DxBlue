using System;
using System.Collections.Generic;

namespace DxBlue.Models.trans
{
    public class SalesReturn_RootModel
    {
        public SalesReturnModel SalesReturnModel { get; set; }
        public List<SalesReturn_ActivityModel> ActivityList { get; set; }
        public List<SalesReturn_ProductModel> ProductList { get; set; }
    }

    public class SalesReturnModel : BaseModel
    {
        public int SalesReturnId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderId { get; set; }
        public DateTime SalesReturnDate { get; set; }
        public int PartyId { get; set; }
        public string Address { get; set; }
        public string PartyName { get; set; }
        public string ContactName { get; set; }
        public string ContactNo { get; set; }
        public string Purpose { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovalStatus { get; set; }
        public int ApprovedById { get; set; }

        public int EnteredById { get; set; }
        public string EnteredByName { get; set; }
        public DateTime EntryDate { get; set; }
        public string Remarks { get; set; }

        public decimal Amount { get; set; }
        public string ApprovedByName { get; set; }
        public string Transporter { get; set; }
        public decimal CreditNoteAmt { get; set; }
        public string AreaName { get; set; }
        public int TotalProducts { get; set; }
        public int TotalProductUploaded { get; set; }
        public int TotalNonSerialProduct { get; set; }
        public string EmailId { get; set; }
        public decimal SalesReturnAmt { get; set; }

        public decimal TcsAmount { get; set; }
        public bool IsTcsApplicable { get; set; }
    }
    public class SalesReturn_ProductModel
    {
        public int SalesReturnId { get; set; }
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
        public byte[] RV { get; set; } = null;
    }

    public class SalesReturn_ActivityModel
    {
        public int SalesReturnId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public decimal Amount { get; set; }
        public byte[] RV { get; set; } = null;
    }

    

    public class SaleReturnProductSerialModel
    {
        public int RecordId { get; set; }
        public int SNo { get; set; }
        public string Branch { get; set; }
        public string OrderId { get; set; }
        public string Party { get; set; }
        public string ProductName { get; set; }
        public string ServiceBranch { get; set; }
        public string SerialQty { get; set; }

        public int SalesReturnId { get; set; }
        public string PartyName { get; set; }
        public string AreaName { get; set; }
        public bool HasSerial { get; set; }
        public string SerialNo { get; set; }
        public int Qty { get; set; }
        public int MaxQty { get; set; }
        public bool IsApproved { get; set; }
        public byte[] RV { get; set; } = null;
    }
}