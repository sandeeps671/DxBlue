using DxConsistent.BL.trans;
using DxConsistent.Models.trans;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DxConsistent.services.trans
{
    public class cAccountsController : ApiController
    {
        IDsrAccountRepository _dsrAccountRepository;
        public cAccountsController()
        {
            if (_dsrAccountRepository == null) _dsrAccountRepository = new DsrAccountRepository();
        }
        #region DsrAccount Services

        [HttpGet]
        public async Task<HttpResponseMessage> ListDsrForLogisticMaterialStatus(DateTime fromDate, DateTime toDate, int areaId)
        {
            string userType = CGlobal.GetUserType();
            var response = await _dsrAccountRepository.ListDsrForAccountStatus(fromDate, toDate, areaId, userType, CGlobal.UserId());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateDsrAccountStatus(DsrAccountModel model)
        {
            var response = await _dsrAccountRepository.UpdateDsrAccountStatus(model, CGlobal.UserId());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        #endregion
    }
}