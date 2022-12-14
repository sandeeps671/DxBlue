using DxBlue.BL.common;
using DxBlue;
using System;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace DxBlue.cons.services.home
{
    public class cDashboard1Controller : ApiController
    {
        IDashboard1Repository _dashboard1Repository;
        public cDashboard1Controller()
        {
            if (_dashboard1Repository == null) _dashboard1Repository = new Dashboard1Repository();
        }
        [HttpGet]
        public async Task<HttpResponseMessage> GetTargetVsAchivementSummary(DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId)
        {
            var response= await _dashboard1Repository.GetTargetVsAchivementSummary(fromDate, toDate, areaId, targetId, view, targetType, targetUserId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListGroupwiseSalesVsTgtSummary(DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId)
        {
            var response = await _dashboard1Repository.ListGroupwiseSalesVsTgtSummary(fromDate, toDate, areaId, targetId, view, targetType, targetUserId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListProductwiseSalesVsTgtSummary(DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId)
        {
            var response = await _dashboard1Repository.ListProductwiseSalesVsTgtSummary(fromDate, toDate, areaId, targetId, view, targetType, targetUserId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> ListAreawiseSalesSummary(DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId)
        {
            var response = await _dashboard1Repository.ListAreawiseSalesSummary(fromDate, toDate, areaId, targetId, view, targetType, targetUserId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> ListStateWiseSalesSummary(DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId)
        {
            var response = await _dashboard1Repository.ListStateWiseSalesSummary(fromDate, toDate, areaId, targetId, view, targetType, targetUserId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> ListGroupWiseSalesSummary(DateTime fromDate, DateTime toDate, int areaId, int targetId, int view, string targetType, int targetUserId)
        {
            var response = await _dashboard1Repository.ListGroupWiseSalesSummary(fromDate, toDate, areaId, targetId, view, targetType, targetUserId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        public async Task<HttpResponseMessage> ListAreawiseSalesDetail(DateTime fromDate, DateTime toDate, int areaId)
        {
            var response = await _dashboard1Repository.ListAreawiseSalesDetail(fromDate, toDate, areaId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListStatewiseSalesDetail(DateTime fromDate, DateTime toDate, int stateId)
        {
            var response = await _dashboard1Repository.ListStatewiseSalesDetail(fromDate, toDate, stateId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListProductwiseSalesDetail(DateTime fromDate, DateTime toDate, int groupId)
        {
            var response = await _dashboard1Repository.ListProductwiseSalesDetail(fromDate, toDate, groupId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListAreawiseSalesInGroup(DateTime fromDate, DateTime toDate, int groupId)
        {
            var response = await _dashboard1Repository.ListAreawiseSalesInGroup(fromDate, toDate, groupId, CGlobal.UserId(), CGlobal.GetUserType());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListSerialNoHistory(string serialNo = "")
        {
            var response = await _dashboard1Repository.ListSerialNoHistory(serialNo);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}