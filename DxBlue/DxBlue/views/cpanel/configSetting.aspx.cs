using DxBlue.BL.cpanel;
using DxBlue.Common.Utility;
using DxBlue;
using System;

namespace DxBlue.cons.views.cpanel
{
    public partial class configSetting : ConsPagePermission
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.LoadUsers(e, "M99.4"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            hIsEdit.Value = IsEdit.ToString();
            BindAllSettings();
        }

        private void BindAllSettings()
        {
            IAppConfigRepository obj = new AppConfigRepository();
            var lst = obj.GetAllSetting(CGlobal.UserId());
            foreach (var m in lst)
            {
                switch (ClsUtility.ToUpper(m.ParamCode))
                {
                    case "LESS_PI_FROM_STOCK":
                        chkDeductPIfromStock.Checked = ClsUtility.ToUpper(m.ParamValue) == "YES";
                        break;
                    case "NO_ORDER_IF_OVERDUES":
                        chkNoOrderIfOverdue.Checked = ClsUtility.ToUpper(m.ParamValue) == "YES";
                        break;
                    case "NO_PROFORMA_IF_OVERDUES":
                        chkNoProformaIfOverdue.Checked = ClsUtility.ToUpper(m.ParamValue) == "YES";
                        break;
                    case "CEILING_LIMIT":
                        txtCeilingLimit.Text = ClsUtility.GetDecimal(m.ParamValue).ToString();
                        break;
                    case "PI_VALIDITY":
                        txtPI_Validiaty.Text = ClsUtility.GetInteger(m.ParamValue).ToString();
                        break;
                    case "EXCLUDE_GST_FROM_SALES":
                        chkExcludeGstFromSales.Checked = ClsUtility.ToUpper(m.ParamValue) == "YES";
                        break;
                }
            }
        }
    }
}