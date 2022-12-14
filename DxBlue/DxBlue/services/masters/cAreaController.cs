using DxBlue.BL.masters;
using DxBlue.Models.masters;
using System.Collections.Generic;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DxBlue.cons.services.masters
{
    public class cAreaController : ApiController
    {
        string userType;
        int userId = 0;
        IAreaRepository _areaRepository;
        public cAreaController()
        {
            userType = CGlobal.GetUserType();
            userId = CGlobal.UserId();
            if (_areaRepository == null) _areaRepository = new AreaRepository();
        }
        [HttpGet]
        public AreaModel GetAreaDetail(int areaId)
        {
            return _areaRepository.GetAreaDetail(areaId, userId);
        }
        [HttpGet]
        public IEnumerable<AreaModel> ListUserAreas()
        {
            return _areaRepository.ListUserAreas(CGlobal.UserId());
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListAreas()
        {
            var response = await _areaRepository.ListAreas(userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListActiveAreas()
        {
            var response = await _areaRepository.ListActiveAreas(userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> SubmitArea(AreaModel model)
        {
            var response = await _areaRepository.SubmitArea(model, userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> DeleteArea(AreaModel model)
        {
            var response = await _areaRepository.DeleteArea(model, userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> RestoreArea(AreaModel model)
        {
            var response = await _areaRepository.RestoreArea(model, userId);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}