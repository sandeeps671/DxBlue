using DxBlue.BL.accounts;
using DxBlue.BL.cpanel;
using DxBlue.BL.masters;
using DxBlue.Models.accounts;
using DxBlue.Common.Utility;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DxBlue.cons.views.cpanel.child
{
    public partial class UserForm : ConsPagePermission
    {
        readonly IcUserRepository objUser = new CUserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.LoadUsers(e, "M99.1"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            hUserId.Value = ClsUtility.GetQStrInt("qUserId").ToString();
            hAction.Value = ClsUtility.GetQStrInt("qAction").ToString();
            hSourceId.Value = ClsUtility.GetQStrInt("qSourceId").ToString();
            FillUserTypes();
            FillManagers();
            FillAreas();
            FillRoles();
            if (hUserId.Value != "0")
            {
                GerUserDetail(ClsUtility.GetInteger(hUserId.Value));
            }

        }

        private void FillRoles()
        {
            IRoleRepository objRole = new RoleRepository();
            var lstRole = objRole.ListActiveRole(ClsUtility.GetInteger(hSourceId.Value), CGlobal.UserId());
            ClsUtility.FillDropDown(ddlRole, lstRole, "RoleName", "RoleId");
            ddlRole.Items.Insert(0, new ListItem { Text = "Select", Value = "0" });
        }

        private void GerUserDetail(int userId)
        {
            var m = objUser.GetUserDetail2(userId);
            if (m.UserId != 0)
            {
                txtUserName.Value = m.UserName;
                txtPassword.Value = m.Password;
                txtFirstname.Value = m.FirstName;
                txtLastName.Value = m.LastName;
                txtMobileNo.Value = m.ContactNo;
                if (ddlUserType.Items.FindByValue(m.UserType) != null) ddlUserType.Value = m.UserType;
                foreach (string platForm in m.Platform.Split(','))
                {
                    if (!string.IsNullOrEmpty(platForm) && ddlPlatform.Items.FindByValue(platForm) != null) ddlPlatform.Items.FindByValue(platForm).Selected = true;
                }

                if (m.UserManagers != null)
                {
                    foreach (UserManagerModel r in m.UserManagers)
                    {
                        if (ddlManager.Items.FindByValue(r.ManagerId.ToString()) != null)
                            ddlManager.Items.FindByValue(r.ManagerId.ToString()).Selected = true;
                        else
                        {
                            ddlManager.Items.Add(new ListItem { Text = r.ManagerName, Value = r.ManagerId.ToString(), Selected = true });
                        }
                    }
                }
                if (m.UserAreas != null)
                {
                    foreach (UserAreaModel r in m.UserAreas)
                    {
                        if (ddlArea.Items.FindByValue(r.AreaId.ToString()) != null)
                            ddlArea.Items.FindByValue(r.AreaId.ToString()).Selected = true;
                        else
                        {
                            ddlArea.Items.Add(new ListItem { Text = r.AreaName, Value = r.AreaId.ToString(), Selected = true });
                        }
                    }
                }
                if (m.UserRoles != null)
                {
                    foreach (UserRoleModel r in m.UserRoles)
                    {
                        if (ddlRole.Items.FindByValue(r.RoleId.ToString()) != null)
                            ddlRole.Items.FindByValue(r.RoleId.ToString()).Selected = true;
                        else
                        {
                            ddlRole.Items.Add(new ListItem { Text = r.RoleName, Value = r.RoleId.ToString(), Selected = true });
                        }
                    }
                }
                chkDsrAccountStatus.Checked = m.IsDsrAccountStatus;
            }
        }

        private void FillAreas()
        {
            IAreaRepository objArea = new AreaRepository();
            var dt = objArea.ListActiveAreasSync(CGlobal.UserId());
            ClsUtility.FillDropDown(ddlArea, dt, "AreaName", "AreaId");
        }

        private void FillManagers()
        {
            var list = objUser.ListManagers(ClsUtility.GetInteger(hSourceId.Value), CGlobal.UserId());
            ClsUtility.FillDropDown(ddlManager, list, "ManagerName", "ManagerId");
        }

        private void FillUserTypes()
        {
            var uTypes = objUser.ListUserTypes(ClsUtility.GetInteger(hSourceId.Value), CGlobal.UserId());
            ClsUtility.FillDropDown(ddlUserType, uTypes, "UserTypeName", "UserTypeCode");
            ddlUserType.Items.Insert(0, new ListItem { Text = "Select", Value = "0" });
        }
    }
}