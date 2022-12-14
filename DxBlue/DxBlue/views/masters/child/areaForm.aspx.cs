using DxBlue.BL.masters;
using DxBlue.Common.Utility;
using System;
//using System.Web.UI;

namespace DxBlue.cons.views.masters.child
{
    public partial class areaForm : ConsPagePermission
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // base.LoadUsers(e, "M6.1"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            hAreaId.Value = ClsUtility.GetQStrInt("qAreaId").ToString();
            hAction.Value = ClsUtility.GetQStrInt("qAction").ToString();

            if (hAreaId.Value != "0") { GetAreaDetail(ClsUtility.GetInteger(hAreaId.Value)); }
        }
        private void GetAreaDetail(int areaId)
        {
            IAreaRepository obj = new AreaRepository();
            var m = obj.GetAreaDetail(areaId, CGlobal.UserId());
            if (m.AreaId == 0) return;

            txtAreaName.Value = m.AreaName;
            ddlHasGodown.Value = m.HasGodown ? "1" : "0";
            txtEmailId.Value = m.EmailId;
            txtSrEmailId.Value = m.SrEmailId;
            txtGstNo.Value = m.GstNo;
            txtAddress.Value = m.Address;
            hRV.Value = Convert.ToBase64String(m.RV);
        }
    }
}