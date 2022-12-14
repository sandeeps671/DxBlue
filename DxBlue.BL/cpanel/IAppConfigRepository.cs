using DxBlue.Models;
using DxBlue.Models.cpanel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DxBlue.BL.cpanel
{
    public interface IAppConfigRepository
    {
        IEnumerable<App_Config_Model> GetAllSetting(int userId);
        ResultModel SubmitConfigSetting(App_Config_Model_Root model, int userId);
        string GetConfigValue(string paramCode, int userId);
        Task<string> GetConfigValueAsync(string paramCode, int userId);
    }
}
