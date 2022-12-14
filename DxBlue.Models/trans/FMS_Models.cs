using System;
using System.Collections.Generic;

namespace DxBlue.Models.trans
{
    public class FmsStatusModel : BaseModel
    {
        public int FmsStatusId { get; set; }
        public string FmsStatusCode { get; set; }
        public string FmsStatusName { get; set; }
        public int SerialNo { get; set; }
    }
    public class FmsModel : DSR_Model
    {
        public int IsFmsUpdate { get; set; } = 0;
        public bool IsValidUser { get; set; }
        public int FmsId { get; set; }
        public int PendingStepId { get; set; }
        public string PendingStepName { get; set; }
        public new int DsrId { get; set; }
        public bool IsAddEdit { get; set; }
        #region Sales Approval
        public DateTime SaleApprovalPlanDate { get; set; }
        public DateTime? SaleApprovalActualDate { get; set; }
        public int? SaleApprovalStatusId { get; set; }
        public string SaleApprovalStatusName { get; set; }
        public int? SaleApprovalStatusByUserId { get; set; }
        public string SaleApprovalStatusByUserName { get; set; }
        #endregion

        #region Material Ready
        public DateTime? MaterialReadyPlanDate { get; set; }
        public DateTime? MaterialReadyActualDate { get; set; }
        public int? MaterialReadyInDays { get; set; }
        public int? MaterialReadyByUserId { get; set; }
        public string MaterialReadyByUserName { get; set; }
        #endregion

        #region Material Confirmation 
        public DateTime? MaterialConfirmPlanDate { get; set; }
        public DateTime? MaterialConfirmActualDate { get; set; }
        public int? MaterialConfirmStatusId { get; set; }
        public string MaterialConfirmStatusName { get; set; }
        public int? MaterialConfirmByUserId { get; set; }
        public string MaterialConfirmByUserName { get; set; }
        #endregion

        #region Account Approval
        public DateTime? AccountApprovalPlanDate { get; set; }
        public DateTime? AccountApprovalActualDate { get; set; }
        public int? AccountApprovalStatusId { get; set; }
        public string AccountApprovalStatusName { get; set; }
        public int? AccountApprovalAssignToId { get; set; }
        public string AccountApprovalAssignToName { get; set; }
        //public int? AccountApprovalConcernId { get; set; }
        public string AccountApprovalConcernName { get; set; }
        public List<int> ListAccountApprovalConcernIds { get; set; }
        public IEnumerable<FmsAccountApprovalConcernModel> ListAccountApprovalConcern;
        public int? AccountApprovalByUserId { get; set; }
        public string AccountApprovalByUserName { get; set; }
        #endregion

        #region Re-Sales Approval
        public DateTime? ReSaleApprovalPlanDate { get; set; }
        public DateTime? ReSaleApprovalActualDate { get; set; }
        public int? ReSaleApprovalStatusId { get; set; }
        public string ReSaleApprovalStatusName { get; set; }
        public int? ReSaleApprovalConcernId { get; set; }
        public string ReSaleApprovalRemark { get; set; }
        public int? ReSaleApprovalByUserId { get; set; }
        public string ReSaleApprovalByUserName { get; set; }
        #endregion

        #region Re Account Approval
        public DateTime? ReAccountApprovalPlanDate { get; set; }
        public DateTime? ReAccountApprovalActualDate { get; set; }
        public int? ReAccountApprovalStatusId { get; set; }
        public string ReAccountApprovalStatusName { get; set; }
        public string ReAccountApprovalRemark { get; set; }
        public int? ReAccountApprovalByUserId { get; set; } // ReAccountApprovalClearedById
        public string ReAccountApprovalByUserName { get; set; }
        public int? ReAccountApprovalAssignToId { get; set; }
        public string ReAccountApprovalAssignToName { get; set; }
        #endregion

        #region Serial No
        public DateTime? SerialNoUpdatePlanDate { get; set; }
        public DateTime? SerialNoUpdateActualDate { get; set; }
        public int? SerialNoUpdateStatusId { get; set; }
        public string SerialNoUpdateStatusName { get; set; }
        public int? SerialNoUpdateByUserId { get; set; }
        public string SerialNoUpdateByUserName { get; set; }

        public int TotalProducts { get; set; }
        public int TotalProductUploaded { get; set; }
        public int TotalNonSerialProduct { get; set; }
        public bool IsSynced { get; set; }
        #endregion


        #region Transport 
        public DateTime? TransportPlanDate { get; set; }
        public DateTime? TransportActualDate { get; set; }
        public int? TransportTransporterId { get; set; }
        public string TransporterName { get; set; }
        public string TransportDocketNo { get; set; }
        public int? TransportByUserId { get; set; }
        public string TransportByUserName { get; set; }
        #endregion

        #region Billing
        public DateTime? BillingPlanDate { get; set; }
        public DateTime? BillingActualDate { get; set; }
        public int? BillingStatusId { get; set; }
        public string BillingStatusName { get; set; }
        public string BillingInvoiceNo { get; set; }
        public int? BillingByUserId { get; set; }
        public string BillingByUserName { get; set; }

        public int? DuePaymentId { get; set; }
        #endregion

        #region Physical Dispatch
        public DateTime? PhysicalDispatchPlanDate { get; set; }
        public DateTime? PhysicalDispatchActualDate { get; set; }
        public int? PhysicalDispatchStatusId { get; set; }
        public string PhysicalDispatchStatusName { get; set; }
        public int? EstimatedTransitTime { get; set; } // in days
        public string PhysicalDispatchByUserId { get; set; }
        public string PhysicalDispatchByUserName { get; set; }

        public string Weight { get; set; }
        public decimal? Distance { get; set; }
        #endregion

        #region Delivery Confirmation
        public DateTime? DeliveryConfirmationEstimatedPlanDate { get; set; }
        public DateTime? DeliveryConfirmationActualDate { get; set; }
        public int? DeliveryConfirmationStatusId { get; set; }
        public string DeliveryConfirmationStatusName { get; set; }
        public string DeliveryConfirmationLastKnownTrackingStatus { get; set; }
        public int? DeliveryConfirmationByUserId { get; set; }
        public string DeliveryConfirmationByUserName { get; set; }
        #endregion

        #region Invoicing
        public DateTime InvoiceReceivePlanDate { get; set; }
        public DateTime? InvoiceReceiveActualDate { get; set; }
        public int? InvoiceReceiveStatusId { get; set; }
        public string InvoiceReceiveStatusName { get; set; }
        public int? InvoiceReceiveByUserId { get; set; }
        public string InvoiceReceiveByUserName { get; set; }
        public string InvoiceLink { get; set; }
        public string EwayBillLink { get; set; }
        public string EInvoiceLink { get; set; }
        #endregion

        #region Party Outstanding related Data
        public decimal OverdueAmt { get; set; }
        public decimal OutstandingAmt { get; set; }
        public decimal CreditLimit { get; set; }
        public string PartyPaymentMode { get; set; }
        public string ChequesUnderClearance { get; set; }
        #endregion
    }
    public class DsrAccountAssignToModel
    {
        public int AssignToId { get; set; }
        public string AssignToName { get; set; }
    }
    public class FmsAccountApprovalConcernModel
    {
        public int? AccountApprovalConcernId { get; set; }
        public string AccountApprovalConcernName { get; set; }
    }
    public class DsrAccountConcernModel
    {
        public int ConcernId { get; set; }
        public string ConcernCode { get; set; }
        public string ConcernName { get; set; }
        public int SerialNo { get; set; }
    }
    public class FmsLastKnownTrackingStatusModel : BaseModel
    {
        public int FmsId { get; set; }
        public string LastKnownTrackingStatus { get; set; }
    }
}
