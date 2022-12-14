using DxBlue.BL.accounts;
using DxBlue.Models;
using DxBlue.Models.accounts;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace DxBlue.cons.services.cpanel
{
    public class cUserController : ApiController
    {
        IcUserRepository _userRepository;
        public cUserController()
        {
            if (_userRepository == null) _userRepository = new CUserRepository();
        }
        [HttpGet]
        public IEnumerable<UserModel> ListAllUser(int sourceId)
        {
            var userType = CGlobal.GetUserType();
            return _userRepository.ListAllUser(sourceId, userType, CGlobal.UserId());
        }
        [HttpPost]
        public ResultModel DeleteUser(UserModel model)
        {
            return _userRepository.DeleteUser(model.UserId, CGlobal.UserId());
        }
        [HttpPost]
        public ResultModel RestoreUser(UserModel model)
        {
            return _userRepository.RestoreUser(model.UserId, CGlobal.UserId());
        }
        [HttpPost]
        public ResultModel SubmitUser(UserModel model)
        {
            ResultModel result = new ResultModel();
            model.SourceId = 0; // to be fine tuned
            if (!_userRepository.IsUserExists(model.UserId, model.UserName))
                return _userRepository.SubmitUser(model, CGlobal.UserId());
            else
            {
                result.IsValid = false;
                result.Msg = "Sorry! This username is already exist";
            }

            return result;


        }
        [HttpGet]
        public async Task<HttpResponseMessage> ListUserInArea(int areaId)
        {
            var response = await _userRepository.ListActiveUserInArea(0, areaId, CGlobal.GetUserType(), CGlobal.UserId());
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
