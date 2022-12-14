using DxBlue.Models.common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DxBlue.BL.common
{
    public interface IDashboard1Repository
    {
        Task<TgtVsAchievementSummaryModel> GetTargetVsAchivementSummary(
            DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType);

        Task<IEnumerable<GroupwiseSalesVsTargetModel>> ListGroupwiseSalesVsTgtSummary(
            DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType);
        Task<IEnumerable<ProductwiseSalesVsTargetModel>> ListProductwiseSalesVsTgtSummary(
            DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType);


        Task<IEnumerable<AreawiseSalesChartModel>> ListAreawiseSalesSummary(
           DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType);

        Task<IEnumerable<StatewiseSalesChartModel>> ListStateWiseSalesSummary(
         DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType);

        Task<IEnumerable<GroupwiseSalesChartModel>> ListGroupWiseSalesSummary(
       DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId, int userId, string userType);

        Task<IEnumerable<AreawiseSalesDetailModel>> ListAreawiseSalesDetail(DateTime fromDate, DateTime toDate, int areaId, int userId, string userType);
        Task<IEnumerable<StatewiseSalesDetailModel>> ListStatewiseSalesDetail(DateTime fromDate, DateTime toDate, int stateId, int userId, string userType);
        Task<IEnumerable<ProductwiseSalesDetailModel>> ListProductwiseSalesDetail(DateTime fromDate, DateTime toDate, int groupId, int userId, string userType);
        Task<IEnumerable<AreawiseSalesInGroupModel>> ListAreawiseSalesInGroup(DateTime fromDate, DateTime toDate, int groupId, int userId, string userType);
        Task<IEnumerable<SerialNoHistoryModel>> ListSerialNoHistory(string serialNo);
    }
}
