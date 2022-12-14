using System;

namespace DxBlue.Models.mis
{
    public class SalesReportModel
    {
        public string Purpose { get; set; }
        //public int DsrId { get; set; }
        public string AreaName { get; set; }
        public string OrderId { get; set; }
        //public int DispatchFromId { get; set; }
        public string DispatchFrom { get; set; }
        //public string PartyId { get; set; }
        public string PartyName { get; set; }
        //public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public decimal NetAmt { get; set; }
        //public string OrderById { get; set; }
        public DateTime OrderDate { get; set; }

        public int AreaId { get; set; }
        public int DispatchFromId { get; set; }
        public string OrderByName { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public int ProductId { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderAmt { get; set; }
        public string View { get; set; }
    }
    public class TotalSalesSummaryModel
    {
        public string OrderByName { get; set; }
        #region SALES
        public int Sale_ConsumerQty { get; set; }
        public decimal Sale_ConsumerAmt { get; set; }

        public int Sale_ItQty { get; set; }
        public string Sale_ItAmt { get; set; }

        public int Sale_SoftwareQty { get; set; }
        public decimal Sale_SoftwareAmt { get; set; }

        public int Sale_ConsumableQty { get; set; }
        public decimal Sale_ConsumableAmt { get; set; }

        public int Sale_SurveillanceQty { get; set; }
        public decimal Sale_SurveillanceAmt { get; set; }

        public int Sale_FlashQty { get; set; }
        public decimal Sale_FlashAmt { get; set; }

        public int Sale_TotalQty { get; set; }
        public decimal Sale_TotalAmt { get; set; }
        #endregion

        #region SS
        public int SS_ConsumerQty { get; set; }
        public decimal SS_ConsumerAmt { get; set; }

        public int SS_ItQty { get; set; }
        public string SS_ItAmt { get; set; }

        public int SS_SoftwareQty { get; set; }
        public decimal SS_SoftwareAmt { get; set; }

        public int SS_ConsumableQty { get; set; }
        public decimal SS_ConsumableAmt { get; set; }

        public int SS_SurveillanceQty { get; set; }
        public decimal SS_SurveillanceAmt { get; set; }

        public int SS_FlashQty { get; set; }
        public decimal SS_FlashAmt { get; set; }

        public int SS_TotalQty { get; set; }
        public decimal SS_TotalAmt { get; set; }
        #endregion
    }
}
