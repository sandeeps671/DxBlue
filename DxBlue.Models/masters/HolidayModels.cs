using System;
using System.Collections.Generic;

namespace DxBlue.Models.masters
{
    public class HolidayModel:BaseModel
    {
        public int HolidayId { get; set; }
        public string HolidayName { get; set; }
        public int SessionYr { get; set; }
        public DateTime HolidayDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string HolidayType { get; set; }
        public string Areas { get; set; }
        public List<int> AreaIds { get; set; }

    }
}
