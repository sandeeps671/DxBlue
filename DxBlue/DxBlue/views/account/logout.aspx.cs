using DxBlue;
using System;
using System.Web.Security;

namespace DxBlue.cons.views.account
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (CGlobal.GetPlatform())
            {
                case "APP":
                case "ANDROID":
                case "MOBILE":
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/aandroid/Login");
                    break;
                default:
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/views/account/Login");
                    break;
            }
        }
    }
}