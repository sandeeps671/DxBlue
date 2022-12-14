using System;
using System.Collections.Generic;

namespace DxBlue.Models.trans
{
    public class TargetModel : BaseModel
    {
        public int TargetId { get; set; }
        public string TargetTitle { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string TargetType { get; set; }
        public List<TargetProductModel> TargetProducts { get; set; }
        public List<TargetUserModel> TargetUsers { get; set; }
        public List<TargetBranchModel> TargetBranches { get; set; }

        public string TransactionId { get; set; }
        public decimal TotalTargetAmt { get; set; }
        public int TargetAreaId { get; set; }
        public string TargetAreaName { get; set; }

    }
    public class TargetProductModel
    {
        public int RecordId { get; set; }
        public int TargetId { get; set; }
        public string TransactionId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public decimal Amount { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmt { get; set; }
    }
    public class TargetUserModel
    {
        public int RecordId { get; set; }
        public int TargetId { get; set; }
        public int TargerUserId { get; set; }
        public string TargetUserName { get; set; }
    }
    public class TargetAreaModel
    {
        public int RecordId { get; set; }
        public int TargetId { get; set; }
        public int TargetAreaId { get; set; }
        public string TargetAreaName { get; set; }
    }
    public class TargetBranchModel
    {
        public int RecordId { get; set; }
        public int TargetBranchId { get; set; }
        public string TargetBranchName { get; set; }
    }
}
