using DxBlue.BL.cpanel;
using DxBlue.BL.Menus;
using DxBlue.Common.Utility;
using DxBlue;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DxBlue.cons.views.cpanel.child
{
    public partial class roleForm : ConsPagePermission
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.LoadUsers(e, "M99.2"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            hRoleId.Value = ClsUtility.GetQStrInt("qRoleId").ToString();
            hAction.Value = ClsUtility.GetQStrInt("qAction").ToString();
            hSourceId.Value = ClsUtility.GetQStrInt("qSourceId").ToString();
            FillMenus();
            if (hRoleId.Value != "0")
            {
                GetRoleDetail(ClsUtility.GetInteger(hRoleId.Value));
            }
        }
        private void GetRoleDetail(int roleId)
        {
            IRoleRepository obj = new RoleRepository();
            var m = obj.GetRoleDetail(roleId, CGlobal.UserId());
            if (m.RoleId == 0) return;

            txtRoleCode.Value = m.RoleCode;
            txtRoleName.Value = m.RoleName;

            if (ddlHomePage.Items.FindByValue(m.HomePageId.ToString()) != null) ddlHomePage.Value = m.HomePageId.ToString();
            else ddlHomePage.Items.Add(new ListItem { Text = m.HomePage, Value = m.HomePageId.ToString() });
            ddlHomePage.Value = m.HomePageId.ToString();
        }

        private void FillMenus()
        {
            CMenuRepository obj = new CMenuRepository();
            var list = obj.ListAllMenus(ClsUtility.GetInteger(hSourceId.Value), CGlobal.UserId());
            ClsUtility.FillDropDown(ddlHomePage, list, "MenuName", "MenuId");
        }
    }
}