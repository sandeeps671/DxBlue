using System;

namespace DxBlue.cons.views.masters
{
    public partial class areaMaster : ConsPagePermission
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.LoadUsers(e, "M6.1"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            //hIsAdd.Value = IsAdd.ToString();
            //hIsEdit.Value = IsEdit.ToString();
            //hIsDelete.Value = IsDelete.ToString();
            //hIsRestore.Value = IsRestore.ToString();
            //hIsExport.Value = IsExport.ToString();
            hIsAdd.Value = 1.ToString();
            hIsEdit.Value = 1.ToString();
            hIsDelete.Value = 1.ToString();
            hIsRestore.Value = 1.ToString();
            hIsExport.Value = 1.ToString();
        }
    }
}