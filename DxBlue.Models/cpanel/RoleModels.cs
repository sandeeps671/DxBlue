namespace DxBlue.Models.cpanel
{
    public class RoleModel : BaseModel
    {
        public int RoleId { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string HomePage { get; set; }
        public int HomePageId { get; set; }
        public int SourceId { get; set; }
    }
    public class RolePermssion
    {
        
    }
    public class MenuParamModel
    {
        public int ParamId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string ParamName { get; set; }
        public bool ParamVal { get; set; }
        public bool IsActive { get; set; }
    }
}
