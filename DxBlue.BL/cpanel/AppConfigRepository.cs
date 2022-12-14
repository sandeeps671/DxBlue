using Dapper;
using DxBlue.Models;
using DxBlue.Models.cpanel;
using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DxBlue.BL.cpanel
{
    public class AppConfigRepository : IAppConfigRepository
    {
        public IEnumerable<App_Config_Model> GetAllSetting(int userId)
        {
            List<App_Config_Model> list = new List<App_Config_Model>();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@ModeSql", "GET_ALL_SETTINGS");
                ht.Add("@UserId", userId);
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "sPM_AppConfigMgmt", ref ht, "GetAllSetting");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new App_Config_Model();
                        m.ParamCode = dr["ParamCode"].ToString();
                        m.ParamName = dr["ParamName"].ToString();
                        m.ParamValue = dr["ParamValue"].ToString();
                        m.SerialNo = ClsUtility.GetInteger(dr["SerialNo"].ToString());
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex) { LogError.WriteErrorToFile(ex, "ex: GetAllSetting"); }
            return list;
        }
        public ResultModel SubmitConfigSetting(App_Config_Model_Root model, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! while submitting app configurations", Result = "" };
            if (model.Items.Count == 0) { return result; }
            try
            {
                Hashtable ht = new Hashtable();
                foreach (var row in model.Items)
                {
                    ht.Clear();
                    ht.Add("@modeSql", "UPDATE_SETTING");
                    ht.Add("@ParamCode", row.ParamCode);
                    ht.Add("@ParamValue", row.ParamValue);
                    ht.Add("@UserId", userId);
                    var res = DBHandler.ExecuteWithOutput(ClsUtility.connSales, "sPM_AppConfigMgmt", ref ht, "@ResultId", "int", "SubmitConfigSetting");
                    if (res > 0)
                    {
                        result.IsValid = true;
                        result.Msg = "App configuration successfully updated";
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: DeleteRole");
            }
            return result;
        }
        public string GetConfigValue(string paramCode, int userId)
        {
            string val = "";
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("@ModeSql", "GET_CONFIG_VALUE");
                ht.Add("@ParamCode", paramCode);
                ht.Add("@userId", userId);
                var res = DBHandler.GetString(ClsUtility.connSales, "sPM_AppConfigMgmt", ref ht, "GetConfigValue");
                val = ClsUtility.ToUpper(res);
            }
            catch (Exception ex) { LogError.WriteErrorToFile(ex, "Get Config Value"); }
            return val;
        }

        public async Task<string> GetConfigValueAsync(string paramCode, int userId)
        {
            string val = "";
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "GET_CONFIG_VALUE");
                    dp.Add("@ParamCode", paramCode);
                    dp.Add("@userId", userId);
                    val = await conn.QuerySingleOrDefaultAsync<string>("sPM_AppConfigMgmt", dp, commandType: CommandType.StoredProcedure);
                    val = ClsUtility.ToUpper(val);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "GetConfigValueAsync");
            }
            return val;
        }
    }
}
