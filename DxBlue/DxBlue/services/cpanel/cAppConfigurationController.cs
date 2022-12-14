using DxBlue.BL.cpanel;
using DxBlue.Models;
using DxBlue.Models.cpanel;
using DxBlue;
using System.Web.Http;

namespace DxBlue.cons.services.cpanel
{
    public class cAppConfigurationController : ApiController
    {
        IAppConfigRepository _appConfigRepository;
        public cAppConfigurationController()
        {
            if (_appConfigRepository == null) _appConfigRepository = new AppConfigRepository();
        }

        [HttpPost]
        public ResultModel SubmitConfigSetting(App_Config_Model_Root model)
        {
            return _appConfigRepository.SubmitConfigSetting(model, CGlobal.UserId());
        }
    }
}