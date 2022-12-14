using System;

namespace DxBlue.Models.trans
{
    public class UserLocationModel
    {
        public int RecordId { get; set; }
        public DateTime LogDate { get; set; }
        public int UserId { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Address { get; set; }
        public string SourceName { get; set; }
        public int SourceId { get; set; }
        public string OS { get; set; } = "";
        public string Browser { get; set; } = "";
        public string Module { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string ActionName { get; set; } = "";
    }
}
