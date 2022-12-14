namespace DxBlue.Models.masters.FMS
{
    public class FmsStageTatModel : BaseModel
    {
        public int FmsStageId { get; set; }
        public string FmsStageName { get; set; }
        public int TatModeId { get; set; }
        public string TatModeName { get; set; }
        public float TatValue { get; set; }
        public string TrackingUrl { get; set; }
        public int SerialNo { get; set; }
    }
}
