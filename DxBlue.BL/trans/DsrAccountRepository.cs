using Dapper;
using DxConsistent.Models;
using DxConsistent.Models.trans;
using DxSoftware.Common.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DxConsistent.BL.trans
{
    public class DsrAccountRepository : IDsrAccountRepository
    {
        public async Task<IEnumerable<DsrAccountModel>> ListDsrForAccountStatus(DateTime fromDate, DateTime toDate, int areaId, string userType, int userId)
        {
            IEnumerable<DsrAccountModel> list = new List<DsrAccountModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_FOR_ACCOUNTS_STATUS");
                    dp.Add("@FromDate", fromDate);
                    dp.Add("@ToDate", toDate);
                    dp.Add("@AreaId", areaId);
                    dp.Add("@UserType", userType);
                    dp.Add("@UserId", userId);
                    list = await conn.QueryAsync<DsrAccountModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDsrForAccountStatus");
            }
            return list;
        }
        public async Task<DsrAccountModel> GetDsrAccountStatus(int dsrId, int userId)
        {
            DsrAccountModel m = new DsrAccountModel();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "GET_DSR_ACCOUNT_STATUS");
                    dp.Add("@DsrId", dsrId);
                    dp.Add("@DsrId", dsrId);
                    dp.Add("@UserId", userId);
                    m = await conn.QuerySingleOrDefaultAsync<DsrAccountModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: GetDsrAccountStatus");
            }
            return m;
        }
        public DsrAccountModel GetDsrAccountStatusSync(int dsrId, int userId)
        {
            DsrAccountModel m = new DsrAccountModel();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "GET_DSR_ACCOUNT_STATUS");
                    dp.Add("@DsrId", dsrId);
                    dp.Add("@UserId", userId);
                    m = conn.QuerySingleOrDefault<DsrAccountModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: GetDsrAccountStatusSync");
            }
            return m;
        }
        public async Task<ResultModel> UpdateDsrAccountStatus(DsrAccountModel model, int userId)
        {
            ResultModel result = new ResultModel { IsValid = false, Msg = "Error while updating a/c status", Result = "0" };
            try
            {
                DataTable DtOtherConcern = new DataTable("ctbl_Ids");
                DtOtherConcern.Columns.Add("RecordId", typeof(int));
                foreach (var concern in model.ListOtherConcern)
                {
                    DataRow row = DtOtherConcern.NewRow();
                    row["RecordId"] = concern.ConcernId;
                    DtOtherConcern.Rows.Add(row);
                }
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "UPDATE_DSR_ACCOUNT_STATUS");
                    dp.Add("@RecordId", model.RecordId);
                    dp.Add("@DsrId", model.DsrId);
                    dp.Add("@AccountStatusId", model.AccountStatusId);
                    dp.Add("@AssignToId", model.AssignToId);
                    dp.Add("@TpOtherConcern", DtOtherConcern.AsTableValuedParameter("dbo.ctbl_Ids"));
                    dp.Add("@RV", model.RV, DbType.Binary);
                    dp.Add("@UserId", userId);
                    result = await conn.QuerySingleOrDefaultAsync<ResultModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "UpdateDsrAccountStatus");
            }
            return result;
        }
        public async Task<IEnumerable<DsrAccountAssignToModel>> ListDsrAccountAssignTo(int userId)
        {
            IEnumerable<DsrAccountAssignToModel> list = new List<DsrAccountAssignToModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_ASSIGN_TO");
                    dp.Add("@UserId", userId);
                    list = await conn.QueryAsync<DsrAccountAssignToModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDsrAccountAssignTo");
            }
            return list;
        }
        public IEnumerable<DsrAccountAssignToModel> ListDsrAccountAssignToSync(int userId)
        {
            IEnumerable<DsrAccountAssignToModel> list = new List<DsrAccountAssignToModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_ASSIGN_TO");
                    dp.Add("@UserId", userId);
                    list = conn.Query<DsrAccountAssignToModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDsrAccountAssignToSync");
            }
            return list;
        }
        public async Task<IEnumerable<DsrAccountConcernMasterModel>> ListDsrAccountConcernMaster(int userId)
        {
            IEnumerable<DsrAccountConcernMasterModel> list = new List<DsrAccountConcernMasterModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_CONCERN_MASTER");
                    dp.Add("@UserId", userId);
                    list = await conn.QueryAsync<DsrAccountConcernMasterModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDsrAccountConcernMaster");
            }
            return list;
        }
        public IEnumerable<DsrAccountConcernMasterModel> ListDsrAccountConcernMasterSync(int userId)
        {
            IEnumerable<DsrAccountConcernMasterModel> list = new List<DsrAccountConcernMasterModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_CONCERN_MASTER");
                    dp.Add("@UserId", userId);
                    list = conn.Query<DsrAccountConcernMasterModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDsrAccountStatusMasterSync");
            }
            return list;
        }

        public async Task<IEnumerable<DsrAccountConcernModel>> ListDsrAccountConcern(int dsrAccountStatusId, int userId)
        {
            IEnumerable<DsrAccountConcernModel> list = new List<DsrAccountConcernModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_CONCERN");
                    dp.Add("@DsrAccountStatusId", dsrAccountStatusId);
                    dp.Add("@UserId", userId);
                    list = await conn.QueryAsync<DsrAccountConcernModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDsrAccountConcern");
            }
            return list;
        }
        public IEnumerable<DsrAccountConcernModel> ListDsrAccountConcernSync(int dsrAccountStatusId, int userId)
        {
            IEnumerable<DsrAccountConcernModel> list = new List<DsrAccountConcernModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_CONCERN");
                    dp.Add("@DsrAccountStatusId", dsrAccountStatusId);
                    dp.Add("@UserId", userId);
                    list = conn.Query<DsrAccountConcernModel>("sP_AccountStatusMgmt", dp, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDsrAccountConcernSync");
            }
            return list;
        }
    }
}
