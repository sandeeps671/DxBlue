namespace DxBlue.Models.masters
{
    public class ReportedProblemModel
    {
        public int ReportedProblemId { get; set; }
        public string ReportedProblem { get; set; }
        public bool Disable { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
