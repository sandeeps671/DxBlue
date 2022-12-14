using DxBlue.BL.cpanel;
using DxBlue.BL.Menus;
using DxBlue.Common.Utility;
using DxBlue;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DxBlue.cons.views.cpanel
{
    public partial class RolePermission : ConsPagePermission
    {
        readonly IRoleRepository objRole = new RoleRepository();
        readonly CMenuRepository objMenu = new CMenuRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.LoadUsers(e, "M99.2"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            FillSources();
            FillRoles();
            FillMenus();
        }
        private void FillSources()
        {
            ClsUtility.AppendDropdownTextValue(ddlSource, "Consistent", "0", 0);
            ClsUtility.AppendDropdownTextValue(ddlSource, "Customer (Party)", "1", 1);
            ddlSource.SelectedIndex = 0;
        }
        public void FillRoles()
        {
            var roles = objRole.ListActiveRole(ClsUtility.GetInteger(ddlSource.SelectedValue), CGlobal.UserId());
            ClsUtility.FillDropDown(ddlRole, roles, "RoleName", "RoleId");
        }
        private void FillMenus()
        {
            var menus = objMenu.ListAllMenus2(ClsUtility.GetInteger(ddlSource.SelectedValue), CGlobal.LoginType(), CGlobal.UserId());
            dlMenu.DataSource = menus;
            dlMenu.DataKeyField = "MenuId";
            dlMenu.DataBind();
        }
        protected void DlMenu_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    //var menuId = ClsUtility.GetInteger(((DataRowView)e.Item.DataItem)["MenuId"].ToString());
                    var menuId = ClsUtility.GetInteger(((HtmlInputHidden)e.Item.FindControl("hMenuId")).Value);
                    DataList dlPermission = (DataList)e.Item.FindControl("dlPermission");
                    var roleId = ClsUtility.GetInteger(ddlRole.SelectedValue);
                    IRoleRepository obj = new RoleRepository();
                    var dt = obj.ListMenuPermissionInRole(menuId, roleId, CGlobal.UserId());
                    if (dt != null)
                    {
                        dlPermission.DataSource = dt;
                        dlPermission.DataBind();
                    }
                    break;
            }
        }
        protected void DdlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMenus();
        }
        protected void DdlSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillRoles();
            FillMenus();

            ScriptManager.RegisterClientScriptBlock(UpdatePanel2, this.GetType(), "script", "$('.select2').select2();", true);

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (DataListItem dliMenu in dlMenu.Items)
            {
                DataList dlParam = (DataList)dliMenu.FindControl("dlPermission");
                if (dlParam != null)
                {
                    foreach (DataListItem dliParam in dlParam.Items)
                    {
                        var menuId = ClsUtility.GetInteger(((HtmlInputHidden)dliParam.FindControl("hMenuId")).Value);
                        var paramId = ClsUtility.GetInteger(((HtmlInputHidden)dliParam.FindControl("hParamId")).Value);
                        var isActive = ((CheckBox)dliParam.FindControl("chkParam")).Checked ? true : false;
                        var roleId = ClsUtility.GetInteger(ddlRole.SelectedValue);
                        #region Submit Role Permission
                        var res = objRole.SubmitRolePermission(roleId, menuId, paramId, isActive, CGlobal.UserId());
                        #endregion
                    }
                }
            }
            ScriptManager.RegisterClientScriptBlock(UpdatePanel2, this.GetType(), "script", "$('.select2').select2();toastr.success('Record successfully submitted');", true);
        }
    }
}