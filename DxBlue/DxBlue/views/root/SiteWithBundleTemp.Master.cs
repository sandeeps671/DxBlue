using DxBlue.BL.accounts;
using DxBlue.BL.Menus;
using DxBlue;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web.UI;

namespace DxBlue.cons.views.root
{
    public partial class SiteWithBundleTemp : System.Web.UI.MasterPage
    {
        public string DisplayName = "User";
        public string profilePic = "/user_images/anonymous.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (CGlobal.UserId() == 0) CGlobal.GoToLogin();
            if (Page.IsPostBack) return;
            if (Request.IsAuthenticated)
            {
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

        readonly StringBuilder strMenu = new StringBuilder();
        public string RenderMenus()
        {
            CMenuRepository objMenu = new CMenuRepository();
            var dt = objMenu.ListUserMenu1(CGlobal.LoginType(), CGlobal.UserId(),CGlobal.IsCustomer());

            if (dt != null)
            {
                strMenu.Clear();
                strMenu.Append("<ul id=\"sideMenu\" class=\"nav nav-pills nav-sidebar flex-column nav-child-indent nav-compact text-sm\" data-widget=\"treeview\" role=\"menu\" data-accordion=\"false\">");
                DataRow[] dr0 = dt.Select("ParentId = 0", "SerialNo ASC");
                DataRow[] dr1 = null;
                //DataRow[] dr2 = null;
                for (int i = 0; i < dr0.Length; i++)
                {
                    if (dr0[i]["hasChild"].ToString() == "0")
                    {
                        strMenu.Append("<li class=\"nav-item\">");
                        strMenu.Append("<a href=\"" + dr0[i]["MenuPath"].ToString() + "\" class=\"nav-link\">");
                        strMenu.Append(dr0[i]["Icon"].ToString());
                        strMenu.Append(dr0[i]["MenuName"].ToString());
                        strMenu.Append("</a>");
                        strMenu.Append("</li>");
                    }
                    else
                    {
                        strMenu.Append("<li class=\"nav-item has-treeview\">");
                        strMenu.Append("<a href=\"#\" class=\"nav-link\">");
                        strMenu.Append(dr0[i]["Icon"].ToString());
                        strMenu.Append("<p>");
                        strMenu.Append(dr0[i]["MenuName"].ToString());
                        strMenu.Append("<i class=\"right fas fa-angle-left\"></i>");
                        strMenu.Append("</p>");
                        strMenu.Append("</a>");
                        #region Sub Menues Level 1
                        dr1 = dt.Select("ParentId = " + dr0[i]["MenuId"], "SerialNo ASC");
                        if (dr1.Length != 0)
                        {
                            strMenu.Append("<ul class=\"nav nav-treeview\" >");
                            for (int j = 0; j < dr1.Length; j++)
                            {
                                strMenu.Append("<li class=\"nav-item\">");
                                strMenu.Append("<a href=\"" + dr1[j]["MenuPath"].ToString() + "\"");
                                strMenu.Append(" class=\"nav-link\">");
                                //strMenu.Append("<i class=\"far fa-circle nav-icon\"></i>");
                                strMenu.Append(dr1[j]["Icon"].ToString());
                                strMenu.Append("<p>" + dr1[j]["MenuName"].ToString() + "</p>");
                                strMenu.Append("</a>");
                                strMenu.Append("</li>");
                            }
                            strMenu.Append("</ul>");
                        }
                        #endregion
                        strMenu.Append("</li>");
                    }

                }
                strMenu.Append("</ul>");
            }
            return strMenu.ToString();
        }
    }
}