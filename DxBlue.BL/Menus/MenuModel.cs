namespace DxBlue.BL.Menus
{
    public class cMenuModel
    {
        public cMenuModel()
        {
            StrMode = string.Empty;
            ModeSql = string.Empty;
            MenuName = string.Empty;
            MenuPath = string.Empty;

        }
        public string StrMode { get; set; }
        public string ModeSql { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuPath { get; set; }
        public string Icon { get; set; }
        public int ParentId { get; set; }
        public int SerialNo { get; set; }
        public int MainOrder { get; set; }
        public bool HasChild { get; set; }
        public int RoleId { get; set; }
        public int SourceId { get; set; }
    }
}