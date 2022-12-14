using System;

namespace DxBlue.Models
{
    public class BaseModel
    {
        public bool IsFmsPending { get; set; } = true;
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedByName { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedByName { get; set; }
        public int DeletedBy { get; set; }
        public string DeletedByName { get; set; }
        public DateTime DeletedDate { get; set; }
        public byte[] RV { get; set; } = null;
    }
    public class ResultModel
    {
        public bool IsValid { get; set; } = false;
        public string Msg { get; set; } = "There is some error while performing action";
        public string Result { get; set; }
        public string IntResult { get; set; }
        public object CustomData { get; set; }
        public bool IsExpired { get; set; } = false;
        public byte[] RV { get; set; } = null;

    }
}
