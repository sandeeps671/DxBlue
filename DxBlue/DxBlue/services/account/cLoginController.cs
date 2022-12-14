using DxBlue.BL.accounts;
using DxBlue.Models;
using DxBlue.Models.accounts;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace DxBlue.consistent.services.account
{
    public class CLoginController : ApiController
    {
        readonly IcUserRepository icUserRepository;
        public CLoginController()
        {
            if (icUserRepository == null) icUserRepository = new CUserRepository();
        }
        [HttpPost]
        public async Task<HttpResponseMessage> ValidateLogin(UserModel model)
        {
            CUserRepository obj = new CUserRepository();
            var m = await obj.ValidateLogin(model.UserName, model.Password, model.Platform);
            m.ReturnUrl = model.ReturnUrl;
            m.IsValid = m.UserId > 0;

            if (!m.IsValid) { return Request.CreateResponse(HttpStatusCode.OK, m); }
            //var homePage = (ClsUtility.GetString(drLogin["HomePage"].ToString()) == "" ? "/pages/MyDashboard" : ClsUtility.GetString(drLogin["HomePage"].ToString()));
            FormsAuthentication.SetAuthCookie(m.UserName, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1, m.UserName, DateTime.Now, DateTime.Now.AddHours(10), model.Keep_logged,
            m.UserId.ToString() + "!" +
            CGlobal.Session_Log(m.UserId.ToString(), "Online") + "!" +
            m.DisplayName + "!" +
            m.UserSource + "!" +
            m.DefaultBranchId + "!" +
            m.UserType + "!" +
            m.Platform + "!" +
            m.IsCustomer + "!" +
            m.CustomerId + "!" +
            m.SourceId,
            FormsAuthentication.FormsCookiePath
            );

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                Expires = ticket.Expiration
            };
            HttpContext.Current.Response.Cookies.Add(cookie1);

            return Request.CreateResponse(HttpStatusCode.OK, m);
        }
        [HttpPost]
        public async Task<HttpResponseMessage> ValidateCustomerLogin(UserModel model)
        {
            CUserRepository obj = new CUserRepository();
            var m = await obj.ValidateCustomerLogin(model.UserName, model.Password, model.Platform);
            m.ReturnUrl = model.ReturnUrl;
            m.IsValid = m.UserId > 0;

            if (!m.IsValid) { return Request.CreateResponse(HttpStatusCode.OK, m); }
            //var homePage = (ClsUtility.GetString(drLogin["HomePage"].ToString()) == "" ? "/pages/MyDashboard" : ClsUtility.GetString(drLogin["HomePage"].ToString()));
            FormsAuthentication.SetAuthCookie(m.UserName, false);
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
            1, m.UserName, DateTime.Now, DateTime.Now.AddHours(10), model.Keep_logged,
            m.UserId.ToString() + "!" +
            CGlobal.Session_Log(m.UserId.ToString(), "Online") + "!" +
            m.DisplayName + "!" +
            m.UserSource + "!" +
            m.DefaultBranchId + "!" +
            m.UserType + "!" +
            m.Platform + "!" +
            m.IsCustomer + "!" +
            m.CustomerId + "!" +
            m.SourceId,
            FormsAuthentication.FormsCookiePath
            );

            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                Expires = ticket.Expiration
            };
            HttpContext.Current.Response.Cookies.Add(cookie1);

            return Request.CreateResponse(HttpStatusCode.OK, m);
        }
        [HttpPost]
        public ResultModel ChangePassword(ChangePasswordModel model)
        {
            ResultModel msg = new ResultModel
            {
                IsValid = false
            };
            model.LoginId = CGlobal.UserId();
            msg.Result = "Sorry! There is some error while changing passowrd, please try later";

            if (model.LoginId == 0)
            {
                msg.Result = "Please login again to change your password";
                return msg;
            }
            else if (model.CurrentPassword.Trim().Length == 0)
            {
                msg.Result = "Please enter your current password";
                return msg;
            }
            else if (model.CurrentPassword == model.NewPassword)
            {
                msg.Result = "New password cannot be same as your current password";
                return msg;
            }
            else if (model.NewPassword.Trim().Length == 0)
            {
                msg.Result = "Please enter new password";
                return msg;
            }
            else if (model.ConfirmPassword.Trim().Length == 0)
            {
                msg.Result = "Please enter confirm password";
                return msg;
            }
            else if (model.NewPassword.Trim() != model.ConfirmPassword.Trim())
            {
                msg.Result = "New password and confirm password not matched";
                return msg;
            }
            IcUserRepository obj = new CUserRepository();
            msg = obj.ChangePassword(model);
            return msg;
        }
    }
}