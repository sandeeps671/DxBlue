using Dapper;
using DxBlue.Models.common;
using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DxBlue.BL.common
{
    public class CommonRepository : ICommonRepository
    {
        public IEnumerable<PaymentModeModel> ListPaymentMode(int userId)
        {
            List<PaymentModeModel> list = null;
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_PAYMENTMODE" },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "sPM_CommonMgmt", ref ht, "ListPaymentMode");
                if (dt != null)
                {
                    list = new List<PaymentModeModel>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new PaymentModeModel();
                        m.PaymentModeId = ClsUtility.GetInteger(dr["PaymentModeId"].ToString());
                        m.PaymentMode = dr["PaymentMode"].ToString();
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListPaymentMode");
            }
            return list;
        }
        public IEnumerable<StateModel> ListState(int userId)
        {
            List<StateModel> list = null;
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "LIST_STATE" },
                    { "@UserId", userId }
                };
                var dt = DBHandler.GetDataTable(ClsUtility.connSales, "sPM_CommonMgmt", ref ht, "ListState");
                if (dt != null)
                {
                    list = new List<StateModel>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        var m = new StateModel();
                        m.StateId = ClsUtility.GetInteger(dr["StateId"].ToString());
                        m.StateName = dr["StateName"].ToString();
                        list.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListState");
            }
            return list;

        }
        public IEnumerable<DepositAtLocationModel> ListDepositLocationSync(int userId)
        {
            List<DepositAtLocationModel> list = new List<DepositAtLocationModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DEPOSIT_LOCATION");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<DepositAtLocationModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;

                }

            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDepositLocationSync");
            }
            return list;
        }
        public async Task<IEnumerable<DepositAtLocationModel>> ListDepositLocation(int userId)
        {
            List<DepositAtLocationModel> list = new List<DepositAtLocationModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DEPOSIT_LOCATION");
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<DepositAtLocationModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;

                }

            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListDepositLocation");
            }
            return list;
        }
        public async Task<IEnumerable<BillingTypeModel>> ListBillingType(int enquiryForId, int userId)
        {
            List<BillingTypeModel> list = new List<BillingTypeModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_BILLING_TYPE");
                    dp.Add("@EnquiryForId", enquiryForId);
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<BillingTypeModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListBillingType");
            }
            return list;
        }
        public IEnumerable<BillingTypeModel> ListBillingTypeSync(int enquiryForId, int userId)
        {
            List<BillingTypeModel> list = new List<BillingTypeModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_BILLING_TYPE");
                    dp.Add("@EnquiryForId", enquiryForId);
                    dp.Add("@UserId", userId);
                    var res = conn.Query<BillingTypeModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListBillingTypeSync");
            }
            return list;
        }
        public async Task<IEnumerable<EnquiryFlowModel>> ListEnquiryFlow(int userId)
        {
            List<EnquiryFlowModel> list = new List<EnquiryFlowModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_FLOW");
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<EnquiryFlowModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListEnquiryFlow");
            }
            return list;
        }
        public IEnumerable<EnquiryFlowModel> ListEnquiryFlowSync(int userId)
        {
            List<EnquiryFlowModel> list = new List<EnquiryFlowModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_FLOW");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<EnquiryFlowModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListEnquiryFlowSync");
            }
            return list;
        }
        public async Task<IEnumerable<PartnerTypeModel>> ListPartnerType(int enquiryForId, int userId)
        {
            List<PartnerTypeModel> list = new List<PartnerTypeModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_PARTNER_TYPE");
                    dp.Add("@EnquiryForId", enquiryForId);
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<PartnerTypeModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListPartnerType");
            }
            return list;
        }
        public IEnumerable<PartnerTypeModel> ListPartnerTypeSync(int enquiryForId, int userId)
        {
            List<PartnerTypeModel> list = new List<PartnerTypeModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_PARTNER_TYPE");
                    dp.Add("@EnquiryForId", enquiryForId);
                    dp.Add("@UserId", userId);
                    var res = conn.Query<PartnerTypeModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListPartnerTypeSync");
            }
            return list;
        }
        public async Task<IEnumerable<EnquiryTypeModel>> ListEnquiryType(int userId)
        {
            List<EnquiryTypeModel> list = new List<EnquiryTypeModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_TYPE");
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<EnquiryTypeModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListEnquiryType");
            }
            return list;
        }
        public IEnumerable<EnquiryTypeModel> ListEnquiryTypeSync(int userId)
        {
            List<EnquiryTypeModel> list = new List<EnquiryTypeModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_TYPE");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<EnquiryTypeModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListEnquiryTypeSync");
            }
            return list;
        }
        public IEnumerable<EnquiryStatusModel> ListEnquiryStatusSync(int enquiryStageId, int enquiryTypeId, int userId)
        {
            List<EnquiryStatusModel> list = new List<EnquiryStatusModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_STATUS");
                    dp.Add("@EnquiryStageId", enquiryStageId);
                    dp.Add("@EnquiryTypeId", enquiryTypeId);
                    dp.Add("@UserId", userId);
                    var res = conn.Query<EnquiryStatusModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListEnquiryStatusSync");
            }
            return list;
        }
        public async Task<IEnumerable<EnquiryStatusModel>> ListEnquiryStatus(int enquiryStageId, int enquiryTypeId, int userId)
        {
            List<EnquiryStatusModel> list = new List<EnquiryStatusModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_STATUS");
                    dp.Add("@EnquiryStageId", enquiryStageId);
                    dp.Add("@EnquiryTypeId", enquiryTypeId);
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<EnquiryStatusModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: ListEnquiryStatus");
            }
            return list;
        }

        public IEnumerable<EnquiryStageModel> ListEnquiryStageSync(int userId)
        {
            List<EnquiryStageModel> list = new List<EnquiryStageModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_STAGE");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<EnquiryStageModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListEnquiryStatusActionSync");
            }
            return list;
        }
        public async Task<IEnumerable<EnquiryStageModel>> ListEnquiryStage(int userId)
        {
            List<EnquiryStageModel> list = new List<EnquiryStageModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ENQUIRY_STAGE");
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<EnquiryStageModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListEnquiryActionSyncStatus");
            }
            return list;
        }

        public async Task<IEnumerable<LogisticMaterialStatusModel>> ListLogisticMaterialStatus(int userId)
        {
            List<LogisticMaterialStatusModel> list = new List<LogisticMaterialStatusModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_LOGISTIC_MATERIAL_STATUS");
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<LogisticMaterialStatusModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListLogisticMaterialStatus");
            }
            return list;
        }
        public IEnumerable<LogisticMaterialStatusModel> ListLogisticMaterialStatusSync(int userId)
        {
            List<LogisticMaterialStatusModel> list = new List<LogisticMaterialStatusModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_LOGISTIC_MATERIAL_STATUS");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<LogisticMaterialStatusModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListLogisticMaterialStatusSync");
            }
            return list;
        }

        public async Task<IEnumerable<DsrAccountStatusModel>> ListDsrAccountStatus(int userId)
        {
            List<DsrAccountStatusModel> list = new List<DsrAccountStatusModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_STATUS");
                    dp.Add("@UserId", userId);
                    var res = await conn.QueryAsync<DsrAccountStatusModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListDsrAccountStatus");
            }
            return list;
        }
        public IEnumerable<DsrAccountStatusModel> ListDsrAccountStatusSync(int userId)
        {
            List<DsrAccountStatusModel> list = new List<DsrAccountStatusModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_DSR_ACCOUNT_STATUS");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<DsrAccountStatusModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListDsrAccountStatusSync");
            }
            return list;
        }
        public IEnumerable<AdvPdcCdcModel> ListAdvPdcCdcSync(int userId)
        {
            List<AdvPdcCdcModel> list = new List<AdvPdcCdcModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_ADV_PDC_CDC");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<AdvPdcCdcModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListAdvPdcCdcSync");
            }
            return list;
        }
        public IEnumerable<TatModeModel> ListTatMode(int userId)
        {
            List<TatModeModel> list = new List<TatModeModel>();
            try
            {
                using (var conn = new SqlConnection(ClsUtility.connSales1))
                {
                    conn.Open();
                    var dp = new DynamicParameters();
                    dp.Add("@ModeSql", "LIST_TAT_MODE");
                    dp.Add("@UserId", userId);
                    var res = conn.Query<TatModeModel>("sPM_CommonMgmt", dp, commandType: CommandType.StoredProcedure);
                    return res;
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "ListTatMode");
            }
            return list;
        }
    }
}
