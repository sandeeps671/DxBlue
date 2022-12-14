namespace DxBlue.Models.masters
{
    public class PhysicalConditionModel
    {
        public int PhysicalConditionId { get; set; }
        public string PhysicalCondition { get; set; }
        public bool Disable { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string ActionType { get; set; }
    }
}
