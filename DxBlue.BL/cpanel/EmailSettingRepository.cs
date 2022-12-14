using DxBlue.Models.cpanel;
using DxBlue.Common.Utility;
using System;
using System.Collections;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DxBlue.BL.cpanel
{
    public class EmailSettingRepository : IEmailSettingRepository
    {
        public EmailSettingModel GetEmailSetting(int userId)
        {
            EmailSettingModel result = new EmailSettingModel();
            try
            {
                Hashtable ht = new Hashtable
                {
                    { "@ModeSql", "GET_EMAIL_SETTING" },
                    { "@UserId", userId }
                };
                var dr = DBHandler.GetDataRow(ClsUtility.connSales, "sCP_EmailSettingMgmt", ref ht, "GetEmailSetting");
                if (dr != null)
                {
                    result.RecordId = ClsUtility.GetInteger(dr["RecordId"].ToString());
                    result.SmtpEmailId = dr["SmtpEmailId"].ToString();
                    result.SmtpPassword = dr["SmtpPassword"].ToString();
                    result.Host = dr["Host"].ToString();
                    result.Port = ClsUtility.GetInteger(dr["Port"].ToString());
                    result.EnableSsl = ClsUtility.ToBoolean(dr["EnableSsl"].ToString());
                    result.UseDefaultCredentials = ClsUtility.ToBoolean(dr["UseDefaultCredentials"].ToString());
                    result.IsBodyHtml = ClsUtility.ToBoolean(dr["IsBodyHtml"].ToString());
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: GetEmailSetting");
            }
            return result;
        }
        public void SendEmail(EmailParamModel param)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(param.FromEmailId, param.DisplayName);
                if (param.ToEmailIds == null || param.ToEmailIds.Count == 0) return;
                foreach (var toEmailId in param.ToEmailIds) message.To.Add(toEmailId);

                message.Subject = param.Subject;
                message.Body = param.MailBody;

                var setting = GetEmailSetting(0);
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = setting.UseDefaultCredentials;
                message.IsBodyHtml = param.IsBodyHtml || setting.IsBodyHtml;
                smtpClient.Host = setting.Host;
                smtpClient.Port = setting.Port;
                smtpClient.EnableSsl = setting.EnableSsl;
                smtpClient.Credentials = new System.Net.NetworkCredential(setting.SmtpEmailId, setting.SmtpPassword);
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: Send Email");
            }
        }
        public async Task SendEmailAsync(EmailParamModel param)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(param.FromEmailId, param.DisplayName);
                if (param.ToEmailIds == null || param.ToEmailIds.Count == 0) return;
                foreach (var toEmailId in param.ToEmailIds) message.To.Add(toEmailId);

                message.Subject = param.Subject;
                message.Body = param.MailBody;

                var setting = GetEmailSetting(0);
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.UseDefaultCredentials = setting.UseDefaultCredentials;
                message.IsBodyHtml = param.IsBodyHtml || setting.IsBodyHtml;
                smtpClient.Host = setting.Host;
                smtpClient.Port = setting.Port;
                smtpClient.EnableSsl = setting.EnableSsl;
                smtpClient.Credentials = new System.Net.NetworkCredential(setting.SmtpEmailId, setting.SmtpPassword);
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "Ex: Send Email");
            }
        }
    }
}
