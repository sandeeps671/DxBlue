namespace DxBlue.Models.masters
{
    public class LeadSourceModel : BaseModel
    {
        public int LeadSourceId { get; set; }
        public string LeadSourceName { get; set; }
        public bool IsLeadGenerateBy { get; set; }
        public bool IsLeadAssignTo { get; set; }
    }
}
