using System.Collections.Generic;

namespace DxBlue.Models.cpanel
{
    public class EmailSettingModel
    {
        public int RecordId { get; set; }
        public string DisplayName { get; set; }
        public string SmtpEmailId { get; set; }
        public string SmtpPassword { get; set; }
        public string Host { get; set; } = "smtp.gmail.com";
        public int Port { get; set; } = 587;
        public bool UseDefaultCredentials { get; set; } = true;
        public bool EnableSsl { get; set; } = true;
        public bool IsBodyHtml { get; set; } = true;

    }
    public class EmailParamModel
    {
        public string FromEmailId { get; set; } = "";
        public string DisplayName { get; set; } = "";
        public List<string> ToEmailIds { get; set; } = null;
        public string Subject { get; set; } = "";
        public bool IsBodyHtml { get; set; } = true;
        public string MailBody { get; set; } = "";

        //public string Host { get; set; } = "smtp.gmail.com";
        //public int Port { get; set; } = 587;
        //public string SmtpEmailId { get; set; } = "";
        //public string SmtpPassword { get; set; } = "";
        //public bool UseDefaultCredentials { get; set; } = true;
        //public bool EnableSsl { get; set; } = true;
    }
}
