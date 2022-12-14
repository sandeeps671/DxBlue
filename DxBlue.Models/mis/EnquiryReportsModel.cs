using System;

namespace DxBlue.Models.mis
{
    public class EnquiryReportModel
    {
        public string PersonName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        #region CRR
        public int? CRR_Generated { get; set; }
        public int? CRR_Assigned { get; set; }
        public int? CRR_Lead { get; set; }
        public int? CRR_Lost { get; set; }
        #endregion

        #region NBD
        public int? NBD_Generated { get; set; }
        public int? NBD_Assigned { get; set; }
        public int? NBD_Lead { get; set; }
        public int? NBD_Lost { get; set; }
        #endregion

        #region NBD of CRR
        public int? NBD_OF_CRR_Generated { get; set; }
        public int? NBD_OF_CRR_Assigned { get; set; }
        public int? NBD_OF_CRR_Lead { get; set; }
        public int? NBD_OF_CRR_Lost { get; set; }
        #endregion

        #region Total Enquiries
        public int? Total_Generated { get; set; }
        public int? Total_Assigned { get; set; }
        public int? Total_Lead { get; set; }
        public int? Total_Lost { get; set; }
       
        public int? Total_Incoming { get; set; }
        public int? Total_Outgoing { get; set; }
        public int? Total_Account_Opened { get; set; }
        #endregion

        #region AVG
        public decimal? Avg_First_Enquiry_Action_Time { get; set; }
        public decimal? Avg_Enquiry_Closure_Time { get; set; }
        #endregion
        #region MyRegion
        public decimal? NetSales { get; set; }
        public decimal? OverdueAmt { get; set; }
        #endregion
    }
}
