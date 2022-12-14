using DxBlue.Models;
using DxBlue.Models.cpanel;
using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DxBlue.BL.cpanel
{
    public class RoleRepository : IRoleRepository
    {
        public RoleModel GetRoleDetail(int roleId, int userId)
        {
            var m = new RoleModel();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "GetRoleDetail" },
                    { "@RoleId", roleId },
                    { "@UserId", userId }
                };
                var dr = DBHandler.GetDataRow(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "GetRoleDetail");
                if (dr != null)
                {
                    m.RoleId = ClsUtility.GetInteger(dr["RoleId"].ToString());
                    m.RoleCode = dr["RoleCode"].ToString();
                    m.RoleName = dr["RoleName"].ToString();
                    m.IsActive = ClsUtility.ToBoolean(dr["IsActive"].ToString());
                    m.HomePageId = ClsUtility.GetInteger(dr["HomePageId"].ToString());
                    m.SourceId = ClsUtility.GetInteger(dr["SourceId"].ToString());
                    m.HomePage = dr["HomePage"].ToString();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ex: GetRoleDetail");
            }
            return m;
        }

        public IEnumerable<RoleModel> ListAllRole(int sourceId, int userId)
        {
            List<RoleModel> list = new List<RoleModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_ALL_ROLE" },
                    { "@SourceId", sourceId },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "ListAllRole");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new RoleModel();
                        m.RoleId = ClsUtility.GetInteger(dr["RoleId"].ToString());
                        m.RoleCode = dr["RoleCode"].ToString();
                        m.RoleName = dr["RoleName"].ToString();
                        m.HomePageId = ClsUtility.GetInteger(dr["HomePageId"].ToString());
                        m.HomePage = dr["HomePage"].ToString();
                        m.IsActive = ClsUtility.ToBoolean(dr["IsActive"].ToString());
                        m.SourceId = ClsUtility.GetInteger(dr["SourceId"].ToString());
                        m.Status = m.IsActive ? "Active" : "Disabled";
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAllRole");
            }
            return list;
        }
        public ResultModel DeleteRole(int roleId, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! While deleting role", Result = "" };
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "DELETE_ROLE" },
                    { "@RoleId", roleId},
                    { "@UserId", userId }
                };
                var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "@ResultId", "int", "DeleteRole");
                if (res > 0)
                {
                    result.IsValid = true;
                    result.Msg = "Record successfully deleted";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: DeleteRole");
            }
            return result;
        }
        public ResultModel RestoreRole(int roleId, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! While restoring role", Result = "" };
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "RESTORE_ROLE" },
                    { "@RoleId", roleId},
                    { "@UserId", userId }
                };
                var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "@ResultId", "int", "RestoreRole");
                if (res > 0)
                {
                    result.IsValid = true;
                    result.Msg = "Record successfully restored";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: RestoreRole");
            }
            return result;
        }
        public ResultModel SubmitRole(RoleModel model, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! while submitting role detail", Result = "" };
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", model.RoleId==0 ? "INSERT_ROLE": "UPDATE_ROLE" },
                    { "@RoleId", model.RoleId},
                    { "@RoleCode", model.RoleCode},
                    { "@RoleName", model.RoleName},
                    { "@HomePageId", model.HomePageId},
                    { "@SourceId", model.SourceId},
                    { "@UserId", userId }
                };
                var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "sPM_Role_IU", ref ht, "@ResultId", "int", "SubmitRole");
                if (res > 0)
                {
                    result.IsValid = true;
                    result.Msg = model.RoleId == 0 ? "Record successfully added" : "Record successfully updated";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: SubmitRole");
            }
            return result;
        }
        public IEnumerable<RoleModel> ListActiveRole(int sourceId, int userId)
        {
            List<RoleModel> list = new List<RoleModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_ACTIVE_ROLE" },
                    { "@SourceId", sourceId },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "ListAllRole");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new RoleModel();
                        m.RoleId = ClsUtility.GetInteger(dr["RoleId"].ToString());
                        m.RoleCode = dr["RoleCode"].ToString();
                        m.RoleName = dr["RoleName"].ToString();
                        m.HomePageId = ClsUtility.GetInteger(dr["HomePageId"].ToString());
                        m.HomePage = dr["HomePage"].ToString();
                        m.IsActive = ClsUtility.ToBoolean(dr["IsActive"].ToString());
                        m.Status = m.IsActive ? "Active" : "Disabled";
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAllRole");
            }
            return list;
        }
        public IEnumerable<MenuParamModel> ListMenuPermissionInRole(int menuId, int roleId, int userId)
        {
            List<MenuParamModel> list = new List<MenuParamModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "listMenuPermissionInRole" },
                    { "@MenuId", menuId },
                    { "@RoleId", roleId },
                    { "@UserId", userId }
                };
                //ht.Add("@userType", Global.Department());
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "ListMenuPermissionInRole");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new MenuParamModel();
                        m.MenuId = ClsUtility.GetInteger(dr["MenuId"].ToString());
                        m.ParamId = ClsUtility.GetInteger(dr["ParamId"].ToString());
                        m.ParamName = dr["ParamName"].ToString();
                        m.IsActive = ClsUtility.ToBoolean(dr["IsActive"].ToString());
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: List Menu Permission In role");
            }
            return list;
        }
        public bool SubmitRolePermission(int roleId, int menuId, int paramId, bool isActive, int userId)
        {
            Hashtable ht = new Hashtable
            {
                { "@ModeSql", "SubmitRolePermission" },
                { "@RoleId", roleId },
                { "@MenuId", menuId },
                { "@ParamId", paramId },
                { "@IsActive", isActive },
                { "@UserId", userId }
            };
            var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "@ResultId", "int", "Submit Role Permission");
            return res > 0;
        }

        public DataTable ListUserMenuPermission(string uniqueCode, int userId, string userType, int roleId = 0)
        {
            //List<MenuParamModel> list = new List<MenuParamModel>();
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "ListUserMenuPermission" },
                    { "@UniqueCode", uniqueCode },
                    { "@UserId", userId },
                    { "@UserType", userType },
                    { "@RoleId", roleId }
                };
                dt = DBHandler.GetDataTable(ClsUtility.connSales, "sPM_RoleMgmt", ref ht, "ListUserMenuPermission");
                return dt;
                //if (dt != null)
                //{
                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        var m = new MenuParamModel();
                //        m.ParamName = dr["ParamName"].ToString();
                //        m.ParamVal = ClsUtility.ToBoolean(dr["ParamVal"].ToString());
                //        list.Add(m);
                //    }
                //}
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListUserMenuPermission");
            }
            return dt;
        }
    }
}
