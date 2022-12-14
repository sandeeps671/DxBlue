// using DxBlue.BL.masters;
//using DxBlue;
using System;
using System.Web.Security;

namespace DxBlue.consistent.views.account
{
    public partial class Login : System.Web.UI.Page
    {
       // readonly IOpeningStockRepository openingStockRepository = new OpeningStockRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (User.Identity.IsAuthenticated) { CGlobal.GoToHome2(); }
            // openingStockRepository.SyncOpeningStock(CGlobal.GoogleSheetCredentials(), CGlobal.UserId());
            FormsAuthentication.SignOut();
            if (Page.IsPostBack) return;
        }
    }
    //private void SyncOpeningStock()
    //{
    //    IActionRepository objAction = new ActionRepository();
    //    var m = objAction.GetLastActionLog(ActionModel.OpenigStockMode, CGlobal.UserId());
    //    var diffInMinutes = (m.CurrentDate - m.ActionDate).TotalMinutes;
    //    if (diffInMinutes > 60)
    //    {
    //        IOpeningStockRepository obj = new OpeningStockRepository();
    //        var res = obj.SyncLiveStockFromGoogleSheet(CGlobal.GoogleSheetCredentials(), OpeningStockModel.GoogleFileName, OpeningStockModel.GoogleSheetName);
    //        if (res.IsValid)
    //        {
    //            objAction.SubmitActionLog(ActionModel.OpenigStockMode, CGlobal.UserId());
    //        }
    //    }
    //}
}