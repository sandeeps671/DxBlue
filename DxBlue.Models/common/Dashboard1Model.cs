using System;

namespace DxBlue.Models.common
{
    public class TgtVsAchievementSummaryModel
    {
        public int TargetQty { get; set; }
        public decimal TargetAmt { get; set; }
        public int AvailableQty { get; set; }
        public int AchieveQty { get; set; }
        public decimal AchieveAmt { get; set; }
        public decimal PercentQty { get; set; }
        public decimal PercentAmt { get; set; }
    }
    public class GroupwiseSalesVsTargetModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int AvailableQty { get; set; }
        public int TargetQty { get; set; }
        public decimal TargetAmt { get; set; }
        public int AchieveQty { get; set; }
        public decimal AchieveAmt { get; set; }
        public decimal PercentQty { get; set; }
        public decimal PercentAmt { get; set; }
    }
    public class ProductwiseSalesVsTargetModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int AvailableQty { get; set; }
        public int TargetQty { get; set; }
        public decimal TargetAmt { get; set; }
        public int AchieveQty { get; set; }
        public decimal AchieveAmt { get; set; }
        public decimal PercentQty { get; set; }
        public decimal PercentAmt { get; set; }
    }

    public class AreawiseSalesChartModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public decimal AchieveAmt { get; set; }
    }
    public class AreawiseSalesDetailModel
    {
        public int DsrId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PartyName { get; set; }
        public string OrderByName { get; set; }
        public decimal AchieveAmt { get; set; }
    }
    public class StatewiseSalesChartModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public decimal AchieveAmt { get; set; }
    }
    public class StatewiseSalesDetailModel
    {
        public int DsrId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string PartyName { get; set; }
        public string OrderByName { get; set; }
        public string StateName { get; set; }
        public decimal AchieveAmt { get; set; }
    }
    public class GroupwiseSalesChartModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public decimal AchieveAmt { get; set; }
    }
    public class ProductwiseSalesDetailModel
    {
        public string AreaName { get; set; }
        public string GroupName { get; set; }
        public string ProductName { get; set; }
        public int AchieveQty { get; set; }
        public decimal AchieveAmt { get; set; }
    }
    public class AreawiseSalesInGroupModel
    {
        public string AreaName { get; set; }
        public string GroupName { get; set; }
        public int AchieveQty { get; set; }
        public decimal AchieveAmt { get; set; }
    }
    public class SerialNoHistoryModel
    {
        public string TranType { get; set; }
        public string PartyName { get; set; }
        public string OrderId { get; set; }
        public string ProductName { get; set; }
        public string SerialNo { get; set; }
        public string BranchName { get; set; }
        public string ServiceBranch { get; set; }
        public DateTime Date { get; set; }
    }
}
