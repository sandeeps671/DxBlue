using DxBlue.BL.mis;
using System.Web.Http;

namespace DxBlue.services.mis
{
    public class cMisController : ApiController
    {
        readonly IReportRepository _reportRepository;
        int userId = 0;
        string userType = "";
        public cMisController()
        {
            if (_reportRepository == null) _reportRepository = new ReportRepository();
            userId = CGlobal.UserId();
            userType = CGlobal.GetUserType();
        }

    }
}