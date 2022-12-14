using Dapper;
using DxBlue.Models.common;
using DxBlue.Common.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DxBlue.BL.common
{
    public class Dashboard1Repository : IDashboard1Repository
    {
        public async Task<TgtVsAchievementSummaryModel> GetTargetVsAchivementSummary(
            DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType)
        {
            TgtVsAchievementSummaryModel m = new TgtVsAchievementSummaryModel();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "TARGET_ACHIEVEMENT_SUMMARY");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@TargetId", targetId);
                    dp.Add("@View", view);
                    dp.Add("@TargetType", targetType);
                    dp.Add("@TargetUserId", targetUserId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dr = await conn.QuerySingleOrDefaultAsync<dynamic>("sP_Dashboard1", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    m = new TgtVsAchievementSummaryModel();
                    m.AvailableQty = dr.AvailableQty;
                    m.TargetQty = dr.TargetQty;
                    m.TargetAmt = dr.TargetAmt;

                    m.AchieveQty = dr.AchieveQty;
                    m.AchieveAmt = dr.AchieveAmt;

                    m.PercentQty = m.TargetQty == 0 ? 0 : (m.AchieveQty * 100) / m.TargetQty;
                    m.PercentAmt = m.TargetAmt == 0 ? 0 : (m.AchieveAmt * 100) / m.TargetAmt;

                    m.PercentQty = Math.Round(m.PercentQty, 2);
                    m.PercentAmt = Math.Round(m.PercentAmt, 2);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: GetTargetVsAchivementSummary user: " + userId );
            }
            return m;
        }
        public async Task<IEnumerable<GroupwiseSalesVsTargetModel>> ListGroupwiseSalesVsTgtSummary(
            DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType)
        {
            List<GroupwiseSalesVsTargetModel> list = new List<GroupwiseSalesVsTargetModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "GROUPWISE_SALES_VS_TGT_SUMMARY");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@TargetId", targetId);
                    dp.Add("@View", view);
                    dp.Add("@TargetType", targetType);
                    dp.Add("@TargetUserId", targetUserId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    foreach (var dr in dt)
                    {
                        var m = new GroupwiseSalesVsTargetModel();
                        m.CategoryName = dr.CategoryName;
                        m.GroupName = dr.GroupName;

                        m.AvailableQty = dr.AvailableQty;

                        m.TargetQty = dr.TargetQty;
                        m.TargetAmt = dr.TargetAmt;

                        m.AchieveQty = dr.AchieveQty;
                        m.AchieveAmt = dr.AchieveAmt;

                        m.PercentQty = m.TargetQty == 0 ? 0 : (m.AchieveQty * 100) / m.TargetQty;
                        m.PercentAmt = m.TargetAmt == 0 ? 0 : (m.AchieveAmt * 100) / m.TargetAmt;

                        m.PercentQty = Math.Round(m.PercentQty, 2);
                        m.PercentAmt = Math.Round(m.PercentAmt, 2);
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListGroupwiseSalesVsTgtSummary user: " + userId);
            }
            return list;
        }
        public async Task<IEnumerable<ProductwiseSalesVsTargetModel>> ListProductwiseSalesVsTgtSummary(
           DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType)
        {
            List<ProductwiseSalesVsTargetModel> list = new List<ProductwiseSalesVsTargetModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "PRODUCTWISE_SALES_VS_TGT_SUMMARY");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@TargetId", targetId);
                    dp.Add("@View", view);
                    dp.Add("@TargetType", targetType);
                    dp.Add("@TargetUserId", targetUserId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);
                    foreach (var dr in dt)
                    {
                        var m = new ProductwiseSalesVsTargetModel();
                        m.GroupName = dr.GroupName;
                        m.ProductName = dr.ProductName;

                        m.AvailableQty = dr.AvailableQty;

                        m.TargetQty = dr.TargetQty;
                        m.TargetAmt = dr.TargetAmt;

                        m.AchieveQty = dr.AchieveQty;
                        m.AchieveAmt = dr.AchieveAmt;

                        m.PercentQty = m.TargetQty == 0 ? 0 : (m.AchieveQty * 100) / m.TargetQty;
                        m.PercentAmt = m.TargetAmt == 0 ? 0 : (m.AchieveAmt * 100) / m.TargetAmt;

                        m.PercentQty = Math.Round(m.PercentQty, 2);
                        m.PercentAmt = Math.Round(m.PercentAmt, 2);
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListProductwiseSalesVsTgtSummary");
            }
            return list;
        }

        public async Task<IEnumerable<AreawiseSalesChartModel>> ListAreawiseSalesSummary(
           DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType)
        {
            List<AreawiseSalesChartModel> list = new List<AreawiseSalesChartModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "AREAWISE_SALES_SUMMARY");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@TargetId", targetId);
                    dp.Add("@View", view);
                    dp.Add("@TargetType", targetType);
                    dp.Add("@TargetUserId", targetUserId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    foreach (var dr in dt)
                    {
                        var m = new AreawiseSalesChartModel();
                        m.AreaId = dr.AreaId;
                        m.AreaName = dr.AreaName;
                        m.AchieveAmt = dr.AchieveAmt;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAreawiseSalesSummary");
            }
            return list;
        }


        public async Task<IEnumerable<StatewiseSalesChartModel>> ListStateWiseSalesSummary(
          DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType)
        {
            List<StatewiseSalesChartModel> list = new List<StatewiseSalesChartModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "STATEWISE_SALE_SUMMARY");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@TargetId", targetId);
                    dp.Add("@View", view);
                    dp.Add("@TargetType", targetType);
                    dp.Add("@TargetUserId", targetUserId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    foreach (var dr in dt)
                    {
                        var m = new StatewiseSalesChartModel();
                        m.StateName = dr.StateName;
                        m.AchieveAmt = dr.AchieveAmt;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListStateWiseSalesSummary");
            }
            return list;
        }


        public async Task<IEnumerable<GroupwiseSalesChartModel>> ListGroupWiseSalesSummary(
        DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType)
        {
            List<GroupwiseSalesChartModel> list = new List<GroupwiseSalesChartModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "GROUPWISE_SALE_SUMMARY");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@TargetId", targetId);
                    dp.Add("@View", view);
                    dp.Add("@TargetType", targetType);
                    dp.Add("@TargetUserId", targetUserId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    foreach (var dr in dt)
                    {
                        var m = new GroupwiseSalesChartModel();
                        m.GroupName = dr.GroupName;
                        m.AchieveAmt = dr.AchieveAmt;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListGroupWiseSalesSummary");
            }
            return list;
        }

        public async Task<IEnumerable<AreawiseSalesDetailModel>> ListAreawiseSalesDetail(DateTime fromDate, DateTime toDate, int areaId, int userId, string userType)
        {
            List<AreawiseSalesDetailModel> list = new List<AreawiseSalesDetailModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "AREAWISE_SALES_DETAIL");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1Detail", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    foreach (var dr in dt)
                    {
                        var m = new AreawiseSalesDetailModel();
                        //m.AreaId = ClsUtility.GetInteger(dr["AreaId"].ToString());
                        m.AreaName = dr.AreaName;
                        m.DsrId = dr.DsrId;
                        m.OrderId = dr.OrderId + "-" + dr.DsrId;
                        m.OrderDate = dr.OrderDate;
                        m.PartyName = dr.PartyName;
                        m.AchieveAmt = dr.AchieveAmt;
                        m.OrderByName = dr.OrderByName;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAreawiseSalesDetail");
            }
            return list;
        }

        public async Task<IEnumerable<StatewiseSalesDetailModel>> ListStatewiseSalesDetail(DateTime fromDate, DateTime toDate, int stateId, int userId, string userType)
        {
            List<StatewiseSalesDetailModel> list = new List<StatewiseSalesDetailModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "SATEWISE_SALES_DETAIL");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@StateId", stateId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1Detail", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    foreach (var dr in dt)
                    {
                        var m = new StatewiseSalesDetailModel();
                        //m.AreaId = ClsUtility.GetInteger(dr["AreaId"].ToString());
                        m.AreaName = dr.AreaName;
                        m.DsrId = dr.DsrId;
                        m.OrderId = dr.OrderId + "-" + dr.DsrId;
                        m.OrderDate = dr.OrderDate;
                        m.PartyName = dr.PartyName;
                        m.AchieveAmt = dr.AchieveAmt;
                        m.OrderByName = dr.OrderByName;
                        m.StateName = dr.StateName;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListStatewiseSalesDetail");
            }
            return list;
        }

        public async Task<IEnumerable<ProductwiseSalesDetailModel>> ListProductwiseSalesDetail(DateTime fromDate, DateTime toDate, int groupId, int userId, string userType)
        {
            List<ProductwiseSalesDetailModel> list = new List<ProductwiseSalesDetailModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "PRODUCTWISE_SALES_DETAIL");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@GroupId", groupId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1Detail", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);
                    foreach (var dr in dt)
                    {
                        var m = new ProductwiseSalesDetailModel();
                        m.AreaName = dr.AreaName;
                        m.GroupName = dr.GroupName;
                        m.ProductName = dr.ProductName;
                        m.AchieveQty = dr.AchieveQty;
                        m.AchieveAmt = dr.AchieveAmt;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListProductwiseSalesDetail");
            }
            return list;
        }
        public async Task<IEnumerable<AreawiseSalesInGroupModel>> ListAreawiseSalesInGroup(DateTime fromDate, DateTime toDate, int groupId, int userId, string userType)
        {
            List<AreawiseSalesInGroupModel> list = new List<AreawiseSalesInGroupModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "AREAWISE_SALE_IN_GROUP");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@GroupId", groupId);
                    dp.Add("@UserId", userId);
                    dp.Add("@UserType", userType);

                    var dt = await conn.QueryAsync<dynamic>("sP_Dashboard1Detail", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);
                    foreach (var dr in dt)
                    {
                        var m = new AreawiseSalesInGroupModel();
                        m.AreaName = dr.AreaName;
                        m.GroupName = dr.GroupName;
                        m.AchieveQty = dr.AchieveQty;
                        m.AchieveAmt = dr.AchieveAmt;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAreawiseSalesInGroup");
            }
            return list;
        }
        public async Task<IEnumerable<SerialNoHistoryModel>> ListSerialNoHistory(string serialNo)
        {
            List<SerialNoHistoryModel> list = new List<SerialNoHistoryModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "SERIAL_NO_HISTORY");
                    dp.Add("@SerialNo", serialNo);

                    var dt = await conn.QueryAsync<dynamic>("sPSerialHistory", dp, commandType: CommandType.StoredProcedure, commandTimeout: ClsUtility.CommandTimeout120);

                    foreach (var dr in dt)
                    {
                        var m = new SerialNoHistoryModel();
                        m.TranType = dr.TranType;
                        m.PartyName = dr.PartyName;
                        m.OrderId = dr.OrderId;
                        m.BranchName = dr.BranchName;
                        m.ServiceBranch = dr.ServiceBranch;
                        m.Date = dr.Date;
                        m.ProductName = dr.ProductName;
                        m.SerialNo = dr.SerialNo;
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListProductwiseSalesDetail");
            }
            return list;
        }
    }
}
