using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DxBlue.BL.Menus
{
    public class CMenuRepository
    {
        public IEnumerable<cMenuModel> ListUserMenu(int userId)
        {
            List<cMenuModel> list = new List<cMenuModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "ListUserMenu" },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "PM_Menu", ref ht, "cons ListUserMenu");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new cMenuModel
                        {
                            MenuId = ClsUtility.GetInteger(dr["MenuId"].ToString()),
                            MenuName = dr["MenuName"].ToString()
                        };
                        m.MenuName = dr["MenuName"].ToString();
                        m.MenuPath = dr["MenuPath"].ToString();
                        m.Icon = dr["Icon"].ToString();
                        m.ParentId = ClsUtility.GetInteger(dr["ParentId"].ToString());
                        m.MainOrder = ClsUtility.GetInteger(dr["MainOrder"].ToString());
                        m.HasChild = ClsUtility.ToBoolean(dr["HasChild"].ToString());
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex:cons ListUserMenu");
            }
            return list;
        }

        public DataTable ListUserMenu1(int loginType, int userId, int sourceId)
        {
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "ListUserMenu" },
                    { "@LoginType", loginType },
                    { "@SourceId", sourceId},
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "PM_Menu", ref ht, "con ListUserMenu1");
                return dt;
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: con ListUserMenu1");
            }
            return null;
        }
        public IEnumerable<cMenuModel> ListAllMenus(int sourceId, int userId)
        {
            List<cMenuModel> list = new List<cMenuModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_ALL_MENUS" },
                    { "@SourceId", sourceId },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "PM_Menu", ref ht, "con ListAllMenus");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new cMenuModel
                        {
                            MenuId = ClsUtility.GetInteger(dr["MenuId"].ToString()),
                            MenuName = dr["MenuName"].ToString(),
                            SerialNo = ClsUtility.GetInteger(dr["SerialNo"].ToString()),
                            MainOrder = ClsUtility.GetInteger(dr["MainOrder"].ToString())
                        };
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: con ListAllMenus");
            }
            return list;
        }
        public IEnumerable<cMenuModel> ListAllMenus2(int sourceId, int loginType, int userId)
        {
            List<cMenuModel> list = new List<cMenuModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_ALL_MENUS2" },
                    { "@SourceId", sourceId },
                    { "@LoginType", loginType },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "PM_Menu", ref ht, "con ListAllMenus2");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new cMenuModel
                        {
                            MenuId = ClsUtility.GetInteger(dr["MenuId"].ToString()),
                            MenuName = dr["MenuName"].ToString(),
                            SerialNo = ClsUtility.GetInteger(dr["SerialNo"].ToString()),
                            MainOrder = ClsUtility.GetInteger(dr["MainOrder"].ToString()),
                            SourceId = ClsUtility.GetInteger(dr["SourceId"].ToString())
                        };
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: con ListAllMenus2");
            }
            return list;
        }
    }
}
