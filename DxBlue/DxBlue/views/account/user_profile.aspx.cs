using DxBlue.BL.accounts;
using System;
using System.Web.UI;

namespace DxBlue.views.account
{
    public partial class user_profile : System.Web.UI.Page
    {
        public string profilePic = "/assets/user_images/anonymous.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (CGlobal.UserId() == 0) CGlobal.GoToLogin();
            getUserDetail();
        }
        private void getUserDetail()
        {
            IcUserRepository obj = new CUserRepository();
            var m = obj.GetUserDetail(CGlobal.UserId());
            txtDisplayName.Value = m.DisplayName;
            txtContactNo.Value = m.ContactNo;

            //if (dr["profilePic"].ToString() != "") profilePic = "/user_images/" + CustomIdentity.LoginId() + "." + dr["profilePic"].ToString();
            //if (!File.Exists(Server.MapPath("~" + profilePic))) profilePic = "/user_images/anonymous.png";
        }
    }
}