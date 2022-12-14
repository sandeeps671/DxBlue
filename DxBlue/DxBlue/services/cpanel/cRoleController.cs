using DxBlue.BL.cpanel;
using DxBlue.Models;
using DxBlue.Models.cpanel;
using DxBlue;
using System.Collections.Generic;
using System.Web.Http;

namespace DxBlue.cons.services.cpanel
{
    public class CRoleController : ApiController
    {
        readonly IRoleRepository _roleRepository;
        public CRoleController()
        {
            if (_roleRepository == null) _roleRepository = new RoleRepository();
        }
        public RoleModel GetRoleDetail(int roleId)
        {
            return _roleRepository.GetRoleDetail(roleId, CGlobal.UserId());
        }
        [HttpGet]
        public IEnumerable<RoleModel> ListAllRole(int sourceId)
        {
            return _roleRepository.ListAllRole(sourceId, CGlobal.UserId());
        }

        [HttpPost]
        public ResultModel SubmitRole(RoleModel model)
        {
            return _roleRepository.SubmitRole(model, CGlobal.UserId());
        }
        [HttpPost]
        public ResultModel DeleteRole(RoleModel model)
        {
            return _roleRepository.DeleteRole(model.RoleId, CGlobal.UserId());
        }
        [HttpPost]
        public ResultModel RestoreRole(RoleModel model)
        {
            return _roleRepository.RestoreRole(model.RoleId, CGlobal.UserId());
        }
    }
}