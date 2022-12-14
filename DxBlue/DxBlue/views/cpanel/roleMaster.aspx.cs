using DxBlue;
using DxBlue.Common.Utility;
using System;
using System.Web.UI;

namespace DxBlue.cons.views.cpanel
{
    public partial class roleMaster : ConsPagePermission
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.LoadUsers(e, "M99.2"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            FillSources();
            hIsAdd.Value = IsAdd.ToString();
            hIsEdit.Value = IsEdit.ToString();
            hIsDelete.Value = IsDelete.ToString();
            hIsRestore.Value = IsRestore.ToString();
        }

        private void FillSources()
        {
            ClsUtility.AppendDropDownWithTextAndValue(ddlSource, "Consistent", "0");
            ClsUtility.AppendDropDownWithTextAndValue(ddlSource, "Customer (Party)", "1");
            ddlSource.SelectedIndex = 0;
        }
    }
}