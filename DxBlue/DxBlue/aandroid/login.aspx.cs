using System;
using System.Web.UI;

namespace DxBlue.aandroid
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated) {
                CGlobal.GoToHome2();
            }
            if (Page.IsPostBack) return;
        }
    }
}