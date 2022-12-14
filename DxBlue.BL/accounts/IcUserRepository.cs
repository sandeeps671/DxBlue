using DxBlue.Models;
using DxBlue.Models.accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DxBlue.BL.accounts
{
    public interface IcUserRepository
    {
        Task<UserModel> ValidateLogin(string userName, string password, string platForm);
        UserModel GetUserDetail(int userId);
        UserModel GetUserDetail2(int userId);
        IEnumerable<UserModel> ListAllUser(int sourceId, string userType,int userId);
        IEnumerable<UserModel> ListActiveUser(int sourceId, string userType, int userId);
        IEnumerable<UserModel> ListActiveUserInAreaSync(int sourceId, int areaId, string userType, int userId);
        Task<IEnumerable<UserModel>> ListActiveUserInArea(int sourceId, int areaId, string userType, int userId);
        ResultModel DeleteUser(int userId, int loginId);
        ResultModel RestoreUser(int userId, int loginId);

        IEnumerable<UserTypeModel> ListUserTypes(int sourceId, int userId);
        ResultModel SubmitUser(UserModel model, int userId);
        IEnumerable<UserManagerModel> ListManagers(int sourceId,int userId);
        bool IsUserExists(int userId, string userName);
        ResultModel ChangePassword(ChangePasswordModel model);
    }
}
