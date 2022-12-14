using System.Collections.Generic;

namespace DxBlue.Models.cpanel
{
    public class App_Config_Model
    {
        public int RecordId { get; set; }
        public string ParamCode { get; set; }
        public string ParamName { get; set; }
        public string ParamValue { get; set; }
        public int SerialNo { get; set; }
        public bool IsActive { get; set; }
    }
    public class App_Config_Model_Root
    {
        public List<App_Config_Model> Items { get; set; }
    }
}
