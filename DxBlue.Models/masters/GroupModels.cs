namespace DxBlue.Models.masters
{
    public class GroupModel : BaseModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
