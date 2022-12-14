using DxBlue.BL.masters;
using DxBlue.Common.Utility;
using System;

namespace DxBlue.cons.views.home
{
    public partial class dashboard1 : ConsPagePermission
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.LoadUsers(e, "M1"); if (!IsView) CGlobal.GoToUnAuthorizePage(); if (Page.IsPostBack) return;
            hIsExport.Value = IsExport.ToString();
            FillUserAreas();
            FillTargetsInArea();
        }
        private void FillUserAreas()
        {
            IAreaRepository areaRepository = new AreaRepository();
            var areas = areaRepository.ListActiveAreasSync(CGlobal.UserId());
            ClsUtility.FillDropDown(ddlArea, areas, "AreaName", "AreaId");
            switch (ClsUtility.ToUpper(CGlobal.GetUserType()))
            {
                case "ADMIN":
                case "BI":
                case "GM":
                    ClsUtility.AppendDropdownTextValue(ddlArea, "All", "0", 0);
                    break;
            }
            
        }
        private void FillTargetsInArea()
        {
            //ITargetRepository targetRepository = new TargetRepository();
            //DateTime fromDate = ClsUtility.GetCurrentMonthStartDtMdy();
            //DateTime toDate = ClsUtility.GetCurrentMonthEndtDtMdy();
            //var targets = targetRepository.ListTargetsInArea(fromDate, toDate, ClsUtility.GetInteger(ddlArea.Value), CGlobal.UserId());
            //ClsUtility.FillDropDown(ddlTarget, targets, "TargetTitle", "TargetId");
            //ClsUtility.AppendDropdownTextValue(ddlTarget, "All", "0", 0);
        }
    }
}