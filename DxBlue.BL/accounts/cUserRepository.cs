using Dapper;
using DxBlue.Models;
using DxBlue.Models.accounts;
using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DxBlue.BL.accounts
{
    public class CUserRepository : IcUserRepository
    {
        public async Task<UserModel> ValidateLogin(string userName, string password, string platForm)
        {
            UserModel m = new UserModel();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "Validate_Login");
                    dp.Add("@UserName", userName);
                    dp.Add("@Password", password);
                    dp.Add("@Platform", platForm);
                    var res = await conn.QuerySingleOrDefaultAsync<dynamic>("rPM_UserMgmt", dp, commandType: CommandType.StoredProcedure);
                    if (res == null || res.RecordId == 0 || res.RecordId == null) return m;
                    m.UserId = res.RecordId;
                    m.UserName = String.IsNullOrEmpty(res.userName) ? "" : res.userName.ToString();
                    m.FullName = String.IsNullOrEmpty(res.fullName) ? "" : res.fullName.ToString();
                    m.UserSource = String.IsNullOrEmpty(res.userSource) ? "" : res.userSource.ToString();
                    m.UserType = String.IsNullOrEmpty(res.UserType) ? "" : res.UserType.ToString();
                    m.Disable = res.disable;
                    m.DefaultBranchId = res.defaultBranchId;
                    m.Platform = platForm;
                    m.IsCustomer = 0;
                    m.SourceId = 0;
                    m.CustomerId = ClsUtility.GetInteger(res.CustomerId);
                }
            }
            catch (Exception ex) { LogError.WriteErrorToFile(ex, "cons ValidateLogin"); }
            return m;

            //try
            //{
            //    Hashtable ht = new Hashtable();
            //    ht.Add("@ModeSql", "Validate_Login");
            //    ht.Add("@UserName", userName);
            //    ht.Add("@Password", password);
            //    ht.Add("@Platform", platForm);

            //    //var dr = DBHandler.GetDataRow(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons ValidateLogin");
            //    //if (dr != null)
            //    //{
            //    //    m.UserId = ClsUtility.GetInteger(dr["recordId"].ToString());
            //    //    m.UserName = dr["userName"].ToString();
            //    //    m.FullName = dr["fullName"].ToString();
            //    //    m.UserSource = dr["userSource"].ToString();
            //    //    m.UserType = dr["UserType"].ToString();
            //    //    m.Disable = ClsUtility.ToBoolean(dr["disable"]);
            //    //    m.DefaultBranchId = ClsUtility.GetInteger(dr["defaultBranchId"].ToString());
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    LogError.WriteErrorToFile(ex, "cons ValidateLogin");
            //}
            //return m;
        }
        public async Task<UserModel> ValidateCustomerLogin(string userName, string password, string platForm)
        {
            UserModel m = new UserModel();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "Validate_Customer_Login");
                    dp.Add("@UserName", userName);
                    dp.Add("@Password", password);
                    dp.Add("@Platform", platForm);
                    var res = await conn.QuerySingleOrDefaultAsync<dynamic>("rPM_UserMgmt", dp, commandType: CommandType.StoredProcedure);
                    if (res == null || res.RecordId == 0 || res.RecordId == null) return m;
                    m.UserId = res.RecordId;
                    m.UserName = String.IsNullOrEmpty(res.userName) ? "" : res.userName.ToString();
                    m.FullName = String.IsNullOrEmpty(res.fullName) ? "" : res.fullName.ToString();
                    m.UserSource = String.IsNullOrEmpty(res.userSource) ? "" : res.userSource.ToString();
                    m.UserType = String.IsNullOrEmpty(res.UserType) ? "" : res.UserType.ToString();
                    m.Disable = false;
                    m.DefaultBranchId = ClsUtility.GetInteger(res.defaultBranchId);
                    m.Platform = platForm;
                    m.IsCustomer = 1;
                    m.SourceId = 1;
                    m.CustomerId = ClsUtility.GetInteger(res.CustomerId);
                }
            }
            catch (Exception ex) { LogError.WriteErrorToFile(ex, "cons ValidateLogin"); }
            return m;
        }

        public UserModel GetUserDetail(int userId)
        {
            UserModel m = new UserModel();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "GET_USER_DETAIL" },
                    { "@UserId", userId }
                };
                var dr = DBHandler.GetDataRow(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons GetUserDetail");
                if (dr != null)
                {
                    m.UserId = ClsUtility.GetInteger(dr["UserId"].ToString());
                    m.UserName = dr["UserName"].ToString();
                    m.FirstName = dr["FirstName"].ToString();
                    m.LastName = dr["LastName"].ToString();
                    m.FullName = m.FirstName + " " + m.LastName;
                    m.DisplayName = m.FullName;

                    m.UserSource = dr["UserSource"].ToString();
                    m.ProfilePic = "";

                    m.ContactNo = dr["ContactNo"].ToString();
                    m.UserType = dr["UserType"].ToString();
                    m.DaysLock = ClsUtility.GetInteger(dr["DaysLock"].ToString());
                    m.Platform = dr["Platform"].ToString();
                    m.Disable = ClsUtility.ToBoolean(dr["disable"]);
                    m.IsDsrAccountStatus = ClsUtility.ToBoolean(dr["IsDsrAccountStatus"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "cons GetUserDetail");
            }
            return m;
        }
        public UserModel GetUserDetail2(int userId)
        {
            UserModel m = new UserModel();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "GET_USER_DETAIL" },
                    { "@UserId", userId }
                };
                var dr = DBHandler.GetDataRow(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons GetUserDetail");
                if (dr != null)
                {
                    m.UserId = ClsUtility.GetInteger(dr["UserId"].ToString());
                    m.UserName = dr["UserName"].ToString();
                    m.Password = dr["Password"].ToString();
                    m.FirstName = dr["FirstName"].ToString();
                    m.LastName = dr["LastName"].ToString();
                    m.FullName = m.FirstName + " " + m.LastName;
                    m.DisplayName = m.FullName;

                    m.UserSource = dr["UserSource"].ToString();
                    m.ProfilePic = "";

                    m.ContactNo = dr["ContactNo"].ToString();
                    m.UserType = dr["UserType"].ToString();
                    m.DaysLock = ClsUtility.GetInteger(dr["DaysLock"].ToString());
                    m.Platform = dr["Platform"].ToString();
                    m.Disable = ClsUtility.ToBoolean(dr["disable"]);
                    m.IsDsrAccountStatus = ClsUtility.ToBoolean(dr["IsDsrAccountStatus"].ToString());

                    #region List User Managers
                    ht.Clear();
                    ht.Add("@ModeSql", "LIST_USER_MANAGER");
                    ht.Add("@UserId", m.UserId);
                    var dtManager = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons GetUser Manager");
                    if (dtManager != null && dtManager.Rows.Count > 0)
                    {
                        m.UserManagers = new List<UserManagerModel>();
                        foreach (DataRow drManager in dtManager.Rows)
                        {
                            UserManagerModel um = new UserManagerModel();
                            um.ManagerId = ClsUtility.GetInteger(drManager["ManagerId"].ToString());
                            um.ManagerName = drManager["ManagerName"].ToString();
                            m.UserManagers.Add(um);
                        }
                    }
                    #endregion
                    #region List User Areas
                    ht.Clear();
                    ht.Add("@ModeSql", "LIST_USER_AREAS");
                    ht.Add("@UserId", m.UserId);
                    var dtArea = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons LIST_USER_AREAS");
                    if (dtArea != null && dtArea.Rows.Count > 0)
                    {
                        m.UserAreas = new List<UserAreaModel>();
                        foreach (DataRow drArea in dtArea.Rows)
                        {
                            UserAreaModel ua = new UserAreaModel();
                            ua.AreaId = ClsUtility.GetInteger(drArea["AreaId"].ToString());
                            ua.AreaName = drArea["AreaName"].ToString();
                            m.UserAreas.Add(ua);
                        }
                    }
                    #endregion
                    #region List User Roles
                    ht.Clear();
                    ht.Add("@ModeSql", "LIST_USER_ROLES");
                    ht.Add("@UserId", m.UserId);
                    var dtRoles = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons LIST_USER_ROLES");
                    if (dtRoles != null && dtRoles.Rows.Count > 0)
                    {
                        m.UserRoles = new List<UserRoleModel>();
                        foreach (DataRow drRole in dtRoles.Rows)
                        {
                            UserRoleModel ur = new UserRoleModel();
                            ur.RoleId = ClsUtility.GetInteger(drRole["RoleId"].ToString());
                            ur.RoleName = drRole["RoleName"].ToString();
                            m.UserRoles.Add(ur);
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "cons GetUserDetail");
            }
            return m;
        }
        public IEnumerable<UserModel> ListAllUser(int sourceId, string userType, int userId)
        {
            List<UserModel> list = new List<UserModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_ALL_USER" },
                    { "@UserType", userType },
                    { "@SourceId", sourceId },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons ListAllUser");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new UserModel();
                        m.UserId = ClsUtility.GetInteger(dr["UserId"].ToString());
                        m.UserName = dr["UserName"].ToString();
                        m.FirstName = dr["FirstName"].ToString();
                        m.LastName = dr["LastName"].ToString();
                        m.FullName = m.FirstName + " " + m.LastName;
                        m.ContactNo = dr["ContactNo"].ToString();
                        m.UserType = dr["UserType"].ToString();
                        m.Disable = ClsUtility.ToBoolean(dr["Disable"].ToString());
                        m.Status = m.Disable ? "Disabled" : "Active";
                        m.SourceId = ClsUtility.GetInteger(dr["SourceId"].ToString());
                        #region List User Managers
                        ht.Clear();
                        ht.Add("@ModeSql", "LIST_USER_MANAGER");
                        ht.Add("@UserId", m.UserId);
                        var dtManager = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons GetUser Manager");
                        if (dtManager != null && dtManager.Rows.Count > 0)
                        {
                            m.UserManagers = new List<UserManagerModel>();
                            foreach (DataRow drManager in dtManager.Rows)
                            {
                                UserManagerModel um = new UserManagerModel();
                                um.ManagerId = ClsUtility.GetInteger(drManager["ManagerId"].ToString());
                                um.ManagerName = drManager["ManagerName"].ToString();
                                m.UserManagers.Add(um);
                            }
                        }
                        #endregion
                        #region List User Areas
                        ht.Clear();
                        ht.Add("@ModeSql", "LIST_USER_AREAS");
                        ht.Add("@UserId", m.UserId);
                        var dtArea = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons LIST_USER_AREAS");
                        if (dtArea != null && dtArea.Rows.Count > 0)
                        {
                            m.UserAreas = new List<UserAreaModel>();
                            foreach (DataRow drArea in dtArea.Rows)
                            {
                                UserAreaModel ua = new UserAreaModel();
                                ua.AreaId = ClsUtility.GetInteger(drArea["AreaId"].ToString());
                                ua.AreaName = drArea["AreaName"].ToString();
                                m.UserAreas.Add(ua);
                            }
                        }
                        #endregion
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: cons ListAllUser");
            }
            return list;
        }
        public IEnumerable<UserModel> ListActiveUser(int sourceId, string userType, int userId)
        {
            List<UserModel> list = new List<UserModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_ACTIVE_USER" },
                    { "@SourceId", sourceId },
                    { "@UserType", userType },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons ListActiveUser");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new UserModel();
                        m.UserId = ClsUtility.GetInteger(dr["UserId"].ToString());
                        m.UserName = dr["UserName"].ToString();
                        m.FirstName = dr["FirstName"].ToString();
                        m.LastName = dr["LastName"].ToString();
                        m.FullName = m.FirstName + " " + m.LastName;
                        m.ContactNo = dr["ContactNo"].ToString();
                        m.UserType = dr["UserType"].ToString();
                        m.Disable = ClsUtility.ToBoolean(dr["Disable"].ToString());
                        m.Status = m.Disable ? "Disabled" : "Active";
                        m.SourceId = ClsUtility.GetInteger(dr["SourceId"].ToString());
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: cons ListActiveUser");
            }
            return list;
        }
        public IEnumerable<UserModel> ListActiveUserInAreaSync(int sourceId, int areaId, string userType, int userId)
        {
            IEnumerable<UserModel> list = new List<UserModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ACTIVE_USER_IN_AREA");
                    dp.Add("@AreaId", areaId);
                    dp.Add("@SourceId", sourceId);
                    dp.Add("@UserType", userType);
                    dp.Add("@UserId", userId);

                    list = conn.Query<UserModel>("rPM_UserMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListActiveUserInAreaSync");
            }
            return list;
        }
        public async Task<IEnumerable<UserModel>> ListActiveUserInArea(int sourceId, int areaId, string userType, int userId)
        {
            IEnumerable<UserModel> list = new List<UserModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ACTIVE_USER_IN_AREA");
                    dp.Add("@AreaId", areaId);
                    dp.Add("@SourceId", sourceId);
                    dp.Add("@UserType", userType);
                    dp.Add("@UserId", userId);

                    list = await conn.QueryAsync<UserModel>("rPM_UserMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListActiveUserInArea");
            }
            return list;
        }
        public ResultModel DeleteUser(int userId, int logingId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! While deleting user", Result = "" };
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "DELETE_USER" },
                    { "@UserId", userId },
                    { "@LoginId", logingId}
                };
                var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "@ResultId", "int", "DeleteUser");
                if (res > 0)
                {
                    result.IsValid = true;
                    result.Msg = "Record successfully deleted";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: DeleteUser");
            }
            return result;
        }
        public ResultModel RestoreUser(int userId, int logingId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! While restoring user", Result = "" };
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "RESTORE_USER" },
                    { "@UserId", userId },
                    { "@LoginId", logingId}
                };
                var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "@ResultId", "int", "RestoreUser");
                if (res > 0)
                {
                    result.IsValid = true;
                    result.Msg = "Record successfully restored";
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: RestoreUser");
            }
            return result;
        }

        public IEnumerable<UserTypeModel> ListUserTypes(int sourceId, int userId)
        {
            List<UserTypeModel> list = new List<UserTypeModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_USER_TYPES" },
                    { "@SourceId", sourceId },
                    {"@UserId",userId }

                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "ListUserTypes");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new UserTypeModel();
                        m.UserTypeCode = dr["UserTypeCode"].ToString();
                        m.UserTypeName = dr["UserTypeName"].ToString();
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListUserTypes");
            }
            return list;
        }

        public IEnumerable<UserManagerModel> ListManagers(int sourceId, int userId)
        {
            List<UserManagerModel> list = new List<UserManagerModel>();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_MANAGERS" },
                    { "@SourceId", sourceId },
                    {"@UserId",userId }

                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "ListManagers");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new UserManagerModel();
                        m.ManagerId = ClsUtility.GetInteger(dr["ManagerId"].ToString());
                        m.ManagerName = dr["ManagerName"].ToString();
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListManagers");
            }
            return list;
        }
        public ResultModel SubmitUser(UserModel model, int loginId)
        {
            ResultModel result = new ResultModel
            {
                IsValid = false,
                Msg = "Error while submitting record",
                Result = "0"
            };
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", model.UserId == 0 ? "INSERT_USER" : "UPDATE_USER" },
                    { "@UserId", model.UserId },
                    { "@UserName", model.UserName },
                    { "@Password", model.Password },
                    { "@FirstName", model.FirstName },
                    { "@LastName", model.LastName },
                    { "@ContactNo", model.ContactNo },
                    { "@UserType", model.UserType },
                    { "@Platform", model.Platform },

                    { "@SourceId", model.SourceId },
                    { "@IsDsrAccountStatus", model.IsDsrAccountStatus },
                    { "@LoginId", loginId }
                };

                #region User Managers
                DataTable tbl_userManager = new DataTable("ctbl_Ids");
                tbl_userManager.Columns.Add("RecordId", typeof(int));

                foreach (int um in model.Managers)
                {
                    DataRow row = tbl_userManager.NewRow();
                    row["RecordId"] = um;
                    tbl_userManager.Rows.Add(row);
                }
                #endregion
                #region User Area
                DataTable tbl_userArea = new DataTable("ctbl_Ids");
                tbl_userArea.Columns.Add("RecordId", typeof(int));

                foreach (int ua in model.Areas)
                {
                    DataRow row = tbl_userArea.NewRow();
                    row["RecordId"] = ua;
                    tbl_userArea.Rows.Add(row);
                }
                #endregion
                #region User Role
                DataTable tbl_userRole = new DataTable("ctbl_Ids");
                tbl_userRole.Columns.Add("RecordId", typeof(int));

                foreach (int ur in model.Roles)
                {
                    DataRow row = tbl_userRole.NewRow();
                    row["RecordId"] = ur;
                    tbl_userRole.Rows.Add(row);
                }
                #endregion

                ht.Add("@UserManager", tbl_userManager);
                ht.Add("@UserArea", tbl_userArea);
                ht.Add("@UserRole", tbl_userRole);
                var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "sP_User_IU", ref ht, "@ResultId", "int", "SubmitUser");
                if (res > 0)
                {
                    result.Msg = model.UserId == 0 ? "User detail successfully saved" : "User Detail successfully updated";
                    result.IsValid = true;
                    result.Result = res.ToString();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: SubmitUser");
                result.Msg = "Error! while submitting user detail";
                result.IsValid = false;
                result.Result = "0";
            }
            return result;
        }

        public bool IsUserExists(int userId, string userName)
        {
            var result = false;
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "CHECK_DUPLICATE_USER" },
                    { "@UserId", userId },
                    { "@UserName", userName }
                };
                var dr = DBHandler.GetDataRow(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "IsUserExists");
                if (dr != null)
                {
                    if (ClsUtility.GetInteger(dr["TotalRecord"].ToString()) > 0) result = true;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: IsUserExists");
            }
            return result;
        }

        public ResultModel ChangePassword(ChangePasswordModel model)
        {
            ResultModel m = new ResultModel();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "CHANGE_PASSWORD" },
                    { "@LoginId", model.LoginId },
                    { "@CurrentPassword", model.CurrentPassword },
                    { "@NewPassword", model.NewPassword },
                    { "@ConfirmPassword", model.ConfirmPassword }
                };
                var dr = DBHandler.GetDataRow(ClsUtility.connSales, "rPM_UserMgmt", ref ht, "cons changePasword");
                if (dr != null)
                {
                    m.IsValid = ClsUtility.ToBoolean(dr["IsValid"].ToString());
                    m.Msg = dr["Msg"].ToString();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ex cons changePasword");
            }
            return m;
        }
    }
}
