using DxBlue.Models.common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DxBlue.BL.common
{
    public interface ICommonRepository
    {
        IEnumerable<PaymentModeModel> ListPaymentMode(int userId);
        IEnumerable<StateModel> ListState(int userId);
        IEnumerable<DepositAtLocationModel> ListDepositLocationSync(int userId);
        Task<IEnumerable<DepositAtLocationModel>> ListDepositLocation(int userId);
        Task<IEnumerable<BillingTypeModel>> ListBillingType(int enquiryForId, int userId);
        IEnumerable<BillingTypeModel> ListBillingTypeSync(int enquiryForId, int userId);
        Task<IEnumerable<EnquiryFlowModel>> ListEnquiryFlow(int userId);
        IEnumerable<EnquiryFlowModel> ListEnquiryFlowSync(int userId);
        Task<IEnumerable<PartnerTypeModel>> ListPartnerType(int enquiryForId, int userId);
        IEnumerable<PartnerTypeModel> ListPartnerTypeSync(int enquiryForId, int userId);
        Task<IEnumerable<EnquiryTypeModel>> ListEnquiryType(int userId);
        IEnumerable<EnquiryTypeModel> ListEnquiryTypeSync(int userId);
        Task<IEnumerable<EnquiryStatusModel>> ListEnquiryStatus(int enquiryStageId, int enquiryTypeId, int userId);
        IEnumerable<EnquiryStatusModel> ListEnquiryStatusSync(int enquiryStageId, int enquiryTypeId, int userId);

        Task<IEnumerable<EnquiryStageModel>> ListEnquiryStage(int userId);
        IEnumerable<EnquiryStageModel> ListEnquiryStageSync(int userId);

        Task<IEnumerable<LogisticMaterialStatusModel>> ListLogisticMaterialStatus(int userId);
        IEnumerable<LogisticMaterialStatusModel> ListLogisticMaterialStatusSync(int userId);

        Task<IEnumerable<DsrAccountStatusModel>> ListDsrAccountStatus(int userId);
        IEnumerable<DsrAccountStatusModel> ListDsrAccountStatusSync(int userId);
        IEnumerable<AdvPdcCdcModel> ListAdvPdcCdcSync(int userId);
        IEnumerable<TatModeModel> ListTatMode(int userId);
    }
}
