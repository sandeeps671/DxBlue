using DxBlue.BL.accounts;
using System;
using System.IO;
using System.Web.UI;

namespace DxBlue.views.root
{
    public partial class MiscMaster : System.Web.UI.MasterPage
    {
        public string DisplayName = "User";
        public string profilePic = "/user_images/anonymous.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Request.IsAuthenticated)
            {
                hUserIdRoot.Value = CGlobal.UserId().ToString();
                hUserTypeRoot.Value = CGlobal.GetUserType();
                getUserDetail();
            }
        }
        private void getUserDetail()
        {
            CUserRepository obj = new CUserRepository();
            var user = obj.GetUserDetail(CGlobal.UserId());

            if (user.UserId != 0)
            {
                DisplayName = user.DisplayName;

                if (user.ProfilePic != "") profilePic = "/assets/images/user_images/" + CGlobal.UserId() + "." + profilePic.ToString();
                if (!File.Exists(Server.MapPath("~" + profilePic))) profilePic = "/assets/images/user_images/anonymous.png";
            }
        }
    }
}