using DxBlue.Models;
using DxBlue.Models.cpanel;
using System.Collections.Generic;
using System.Data;

namespace DxBlue.BL.cpanel
{
    public interface IRoleRepository
    {
        IEnumerable<RoleModel> ListAllRole(int isCustomer,int userId);
        IEnumerable<RoleModel> ListActiveRole(int sourceId,int userId);
        RoleModel GetRoleDetail(int roleId, int userId);
        ResultModel DeleteRole(int roleId, int userId);
        ResultModel RestoreRole(int areaId, int userId);
        ResultModel SubmitRole(RoleModel model, int userId);
        IEnumerable<MenuParamModel> ListMenuPermissionInRole(int menuId, int roleId, int userId);
        bool SubmitRolePermission(int roleId, int menuId, int paramId, bool isActive, int userId);
        DataTable ListUserMenuPermission(string uniqueCode, int userId, string userType, int roleId = 0);
    }
}
