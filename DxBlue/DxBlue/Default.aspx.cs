using System;

namespace DxBlue
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("/school/views/account/Login");
            Response.Redirect("/views/account/Login");
        }
    }
}