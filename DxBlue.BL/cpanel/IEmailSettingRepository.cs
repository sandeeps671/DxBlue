using DxBlue.Models.cpanel;
using System.Threading.Tasks;

namespace DxBlue.BL.cpanel
{
    public interface IEmailSettingRepository
    {
        EmailSettingModel GetEmailSetting(int userId);
        void SendEmail(EmailParamModel param);
        Task SendEmailAsync(EmailParamModel param);
    }
}
