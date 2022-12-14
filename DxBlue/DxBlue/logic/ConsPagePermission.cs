using DxBlue.BL.cpanel;
using DxBlue.Common.Utility;
using System;
using System.Data;
using System.Web;

namespace DxBlue
{
    public class ConsPagePermission : System.Web.UI.Page
    {
        IRoleRepository roleRepository;
        public ConsPagePermission()
        {
            if (roleRepository == null) roleRepository = new RoleRepository();
        }
        public bool IsView { get; set; }
        public bool IsAdd { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsRestore { get; set; }
        public bool IsDateChange { get; set; }
        public bool IsApprove { get; set; }
        public bool IsPayDsr { get; set; }
        public bool IsEditAfterApproval { get; set; }
        public bool IsDeleteAfterApproval { get; set; }
        public bool IsReceiveDelete { get; set; }
        public bool IsDeleteReceiveingAfterApproval { get; set; }
        public bool IsReceiveApprove { get; set; }
        public bool IsSellingPrice { get; set; }
        public bool IsEmailAlert { get; set; }
        public bool IsExport { get; set; }
        public bool IsBill { get; set; }
        public bool IsReceive { get; set; }
        public bool IsHoReceive { get; set; }
        public bool IsUndoApprove { get; set; }
        public bool IsSendMail { get; set; }
        public virtual void LoadUsers(EventArgs e, string uniqueCode = "", int roleId = 0)
        {
            //AssignUserInfo();
            HttpContext.Current.Response.Expires = -1;
            #region Code to fetch user menu level permission
            //var PageName = HttpContext.Current.Request.Url.AbsolutePath.Trim(); //string PageName = HttpContext.Current.Request.Path.Replace(Request.ApplicationPath.ToString(), "");

            var dt = roleRepository.ListUserMenuPermission(uniqueCode, CGlobal.UserId(), CGlobal.GetUserType(), roleId);
            if (dt != null && dt.Rows.Count > 0)
            {
                IsView = GetParamValue("View", dt); IsAdd = GetParamValue("Add", dt); IsEdit = GetParamValue("Edit", dt); IsDelete = GetParamValue("Delete", dt);
                IsRestore = GetParamValue("Restore", dt); IsApprove = GetParamValue("Approve", dt); IsUndoApprove = GetParamValue("Undo Approve", dt); 
                IsReceiveApprove = GetParamValue("Approve Payment", dt); IsPayDsr = GetParamValue("Pay DSR", dt); IsDateChange = GetParamValue("Date Change", dt);
                IsEditAfterApproval = GetParamValue("Edit After Approval", dt); IsDeleteAfterApproval = GetParamValue("Delete After Approval", dt);
                IsReceiveDelete = GetParamValue("Delete Receiving", dt); IsDeleteReceiveingAfterApproval = GetParamValue("Delete Receiving After Approval", dt);
                IsSellingPrice = GetParamValue("EDIT SellingPrice", dt);
                IsEmailAlert = GetParamValue("Email Alert", dt); IsExport = GetParamValue("Export", dt);
                IsBill = GetParamValue("Bill", dt); IsReceive = GetParamValue("Receive", dt); IsHoReceive = GetParamValue("Ho Status", dt);
                IsSendMail = GetParamValue("Send Mail", dt);

            }
            #endregion
        }
        public bool GetParamValue(string paramName, DataTable dt)
        {

            DataRow[] dr = dt.Select("ParamName='" + paramName + "'");

            if (dr.Length > 0) return ClsUtility.ToBoolean(dr[0]["ParamVal"].ToString());
            return false;
        }
    }
}