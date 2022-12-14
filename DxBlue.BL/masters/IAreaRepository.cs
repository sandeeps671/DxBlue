using DxBlue.Models.masters;
using DxBlue.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DxBlue.BL.masters
{
    public interface IAreaRepository
    {
        Task<IEnumerable<AreaModel>> ListAreas(int userId);
        Task<IEnumerable<AreaModel>> ListActiveAreas(int userId);
        IEnumerable<AreaModel> ListActiveAreasSync(int userId);
        IEnumerable<AreaModel> ListUserAreas(int userId);
        AreaModel GetAreaDetail(int areaId, int userId);
        Task<ResultModel> SubmitArea(AreaModel model, int userId);
        Task<ResultModel> DeleteArea(AreaModel model, int userId);
        Task<ResultModel> RestoreArea(AreaModel model, int userId);

        int GetAreaIdByName(string areaName);
    }
}
