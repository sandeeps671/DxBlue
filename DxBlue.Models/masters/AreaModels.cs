namespace DxBlue.Models.masters
{
    public class AreaModel : BaseModel
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string EmailId { get; set; }
        public bool HasGodown { get; set; }
        public string GodownStatus { get; set; }
        public string SrEmailId { get; set; }
        public string GstNo { get; set; }
        public string Address { get; set; }
    }
}
