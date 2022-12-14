using DxConsistent.Models;
using DxConsistent.Models.trans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DxConsistent.BL.trans
{
    public interface IDsrAccountRepository
    {
        Task<IEnumerable<DsrAccountModel>> ListDsrForAccountStatus(DateTime fromDate, DateTime toDate, int areaId, string userType, int userId);
        Task<DsrAccountModel> GetDsrAccountStatus(int dsrId, int userId);
        DsrAccountModel GetDsrAccountStatusSync(int dsrId, int userId);
        Task<ResultModel> UpdateDsrAccountStatus(DsrAccountModel model, int userId);

        Task<IEnumerable<DsrAccountAssignToModel>> ListDsrAccountAssignTo(int userId);
        IEnumerable<DsrAccountAssignToModel> ListDsrAccountAssignToSync(int userId);

        Task<IEnumerable<DsrAccountConcernMasterModel>> ListDsrAccountConcernMaster(int userId);
        IEnumerable<DsrAccountConcernMasterModel> ListDsrAccountConcernMasterSync(int userId);
        IEnumerable<DsrAccountConcernModel> ListDsrAccountConcernSync(int dsrAccountStatusId, int userId);
        Task<IEnumerable<DsrAccountConcernModel>> ListDsrAccountConcern(int dsrAccountStatusId, int userId);
    }
}
