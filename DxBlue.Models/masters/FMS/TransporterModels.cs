using System.Collections.Generic;

namespace DxBlue.Models.masters.FMS
{
    public class TransporterModel: BaseModel
    {
        public int TransporterId { get; set; }
        public string TransporterName { get; set; }
        public string GST_No { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string TrackingUrl { get; set; }
        public List<int> TransporterAreas { get; set; }
        public List<TransporterAreaModel> TransporterAreaList { get; set; }
        public string TransporterArea { get; set; }
        
    }
    public class TransporterAreaModel : BaseModel
    {
        public int TransporterAreaId { get; set; }
        public int TransporterId { get; set; }
        public int AreaId { get; set; }
        public string AreaName { get; set; }
    }
}
