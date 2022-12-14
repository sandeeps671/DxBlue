using Dapper;
using DxBlue.Models;
using DxBlue.Models.masters;
using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DxBlue.BL.masters
{
    public class AreaRepository : IAreaRepository
    {
        public async Task<IEnumerable<AreaModel>> ListAreas(int userId)
        {
            IEnumerable<AreaModel> list = new List<AreaModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_AREAS");
                    dp.Add("@UserId", userId);
                    list = await conn.QueryAsync<AreaModel>("sPM_AreaMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAreas");
            }
            return list;
        }
        public async Task<IEnumerable<AreaModel>> ListActiveAreas(int userId)
        {
            List<AreaModel> list = new List<AreaModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ACTIVE_AREAS");
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<AreaModel>("sPM_AreaMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAreas");
            }
            return list;
        }
        public IEnumerable<AreaModel> ListActiveAreasSync(int userId)
        {
            List<AreaModel> list = new List<AreaModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ACTIVE_AREAS");
                    dp.Add("@UserId", userId);
                    var res =  conn.Query<AreaModel>("sPM_AreaMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListActiveAreasSync");
            }
            return list;
        }
        public IEnumerable<AreaModel> ListUserAreas(int userId)
        {
            List<AreaModel> list = new List<AreaModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_USER_AREAS");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<AreaModel>("sPM_AreaMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListAreas");
            }
            return list;
        }

        public AreaModel GetAreaDetail(int areaId, int userId)
        {
            AreaModel result = new AreaModel();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "GET_AREA_DETAIL");
                    dp.Add("@AreaId", areaId);
                    dp.Add("@UserId", userId);
                    result = conn.QuerySingleOrDefault<AreaModel>("sPM_AreaMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Submit Area");
            }
            return result;
        }

        public async Task<ResultModel> SubmitArea(AreaModel model, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! while submitting area detail", Result = "" };
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", model.AreaId == 0 ? "INSERT_AREA" : "UPDATE_AREA");
                    dp.Add("@AreaId", model.AreaId);
                    dp.Add("@AreaName", model.AreaName);
                    dp.Add("@EmailId", model.EmailId);
                    dp.Add("@HasGodown", model.HasGodown);
                    dp.Add("@SrEmailId", model.SrEmailId);
                    dp.Add("@GstNo", model.GstNo);
                    dp.Add("@Address", model.Address);
                    dp.Add("@RV", model.RV, DbType.Binary);
                    dp.Add("@UserId", userId);
                    //dp.Add("@ResultId", direction: ParameterDirection.Output);
                    result = await conn.QuerySingleOrDefaultAsync<ResultModel>("sPM_Area_IU", dp, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Submit Area");
            }
            return result;
        }

        public async Task<ResultModel> DeleteArea(AreaModel model, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! While deleting area", Result = "" };
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "DELETE_AREA");
                    dp.Add("@AreaId", model.AreaId);
                    dp.Add("@RV", model.RV, DbType.Binary);
                    dp.Add("@UserId", userId);
                    result = await conn.QuerySingleOrDefaultAsync<ResultModel>("sPM_AreaMgmt", dp, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: DeleteArea");
            }
            return result;
        }
        public async Task<ResultModel> RestoreArea(AreaModel model, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error! While deleting area", Result = "" };
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "RESTORE_AREA");
                    dp.Add("@AreaId", model.AreaId);
                    dp.Add("@RV", model.RV, DbType.Binary);
                    dp.Add("@UserId", userId);
                    result = await conn.QuerySingleOrDefaultAsync<ResultModel>("sPM_AreaMgmt", dp, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: RestoreArea");
            }
            return result;
        }
        public int GetAreaIdByName(string areaName)
        {
            int areaId = 0;
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "GET_AREA_ID_BY_NAME" },
                    { "@AreaName", areaName}
                };
                areaId = DBHandler.GetInteger(ClsUtility.connSales, "sPM_AreaMgmt", ref ht, "GetAreaIdByName");
                return areaId;
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: GetAreaIdByName");
            }
            return areaId;
        }

    }
}
