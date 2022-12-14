using System;
using System.Collections.Generic;

namespace DxConsistent.Models.trans
{
    public class DsrAccountModel : LogisticStatusModel
    {
        public new int RecordId { get; set; }
        public int LogisticStatusId { get; set; }
        public new int DsrId { get; set; }
        public int? AccountStatusId { get; set; }
        public string AccountStatusName { get; set; }
        public DateTime? AccountStatusPlanDate { get; set; }
        public DateTime? AccountStatusActualDate { get; set; }
        public int? AccountStatusActualDateByUserId { get; set; }
        public int? AssignToId { get; set; }
        public string AssignToName { get; set; }
        public List<DsrAccountConcernMasterModel> ListOtherConcern { get; set; }
    }

    public class DsrAccountAssignToModel
    {
        public int AssignToId { get; set; }
        public string AssignToName { get; set; }
    }

    public class DsrAccountConcernModel
    {
        public int DsrAccountStatusId { get; set; }
        public int DsrId { get; set; }
        public int ConcernId { get; set; }
        public string ConcernCode { get; set; }
        public string ConcernName { get; set; }
    }

    public class DsrAccountConcernMasterModel
    {
        public int ConcernId { get; set; }
        public string ConcernCode { get; set; }
        public string ConcernName { get; set; }
    }
}
