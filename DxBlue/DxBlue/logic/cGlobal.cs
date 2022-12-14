using DxBlue.Common.Utility;
using DxBlue.Models;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace DxBlue
{
    public class CGlobal
    {
        public static int UserId()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) return 0;
                string cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie);
                return ClsUtility.GetInteger(ticket.UserData.Split('!')[0].ToString());
            }
            catch { return 0; }
        }

        public static int BranchId()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) return 0;
                string cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie);
                return ClsUtility.GetInteger(ticket.UserData.Split('!')[4].ToString());
            }
            catch { return 0; }
        }

        public static int CustomerId()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) return 0;
                string cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie);
                return ClsUtility.GetInteger(ticket.UserData.Split('!')[8].ToString());
            }
            catch { return 0; }
        }
        public static void GoToUnAuthorizePage() // to be fine tuned
        {
            if (UserId() == 0) HttpContext.Current.Response.Redirect("~/views/account/login");
            else HttpContext.Current.Response.Redirect("/views/home/homePage");
        }
        public static string GoToHome()
        {
            if (IsCustomer() == 1) return "~/vCustomer/home/home";
            return "/views/home/homePage";
        }
        public static void GoToHome2()
        {
            if (IsCustomer() == 1)
                HttpContext.Current.Response.Redirect("~/vCustomer/home/home");
            else
                HttpContext.Current.Response.Redirect("~/views/home/homePage");
        }
        public static void GoToCustomerHome2()
        {
            HttpContext.Current.Response.Redirect("~/vCustomer/home/home");
        }
        public static void GoToLogin()
        {
            switch (ClsUtility.ToUpper(GetPlatform()))
            {
                case "APP":
                case "ANDROID":
                case "MOBILE":
                    HttpContext.Current.Response.Redirect("~/views/account/login");
                    break;
                default:
                    HttpContext.Current.Response.Redirect("~/aandroid/login");
                    break;
            }
        }
        public static void GoToNotFound()
        { }
        public static int SessionYrId { get; set; } = 0;
        public static string Session_Log(string user_id, string status)
        {
            if (user_id is null)
            {
                return "";
            }

            return "";
        }

        internal static async Task SendOrderMail(int dsrId, int mode = 0)
        {
            throw new NotImplementedException();
        }
        internal static void SendSalesReturnMail(int salesReturnId)
        {
        }
        internal static void SendDeleteOrderMailSync(int dsrId)
        {
        }
        public static string GetSiteName()
        {
            return "Gobluefeather";
        }
        public static string GetSiteAddress()
        {
            return "http://customer.consistent.in/";
        }
        public static string GetUserSource()
        {
            return "DEALER";
        }
        public static string GetUserType()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) return "";
                string cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie);
                return ClsUtility.GetString(ticket.UserData.Split('!')[5].ToString());
            }
            catch { return ""; }
        }
        public static string GetPlatform()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) return "";
                string cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie);
                return ClsUtility.ToUpper(ticket.UserData.Split('!')[6].ToString());
            }
            catch { return "WEB"; }
        }
        public static int IsCustomer()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) return 0;
                string cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie);
                return ClsUtility.GetInteger(ticket.UserData.Split('!')[7].ToString());
            }
            catch { return 0; }
        }
        public static int SourceId()
        {
            try
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] == null) return 0;
                string cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie);
                return ClsUtility.GetInteger(ticket.UserData.Split('!')[9].ToString());
            }
            catch { return 0; }
        }
        public static int LoginType()
        {
            if (IsCustomer() == 0) return 0;
            else return 1;
        }
        public static string GoogleSheetCredentials()
        {
            //return HttpContext.Current.Server.MapPath("~/consistent-320005-66acf297f757.json");
            return HttpContext.Current.Server.MapPath("~/credentials/consistent-320005-66acf297f757.json");
        }
        public static ResultModel AnauthorizedResponse()
        {
            return new ResultModel { IsValid = false, Msg = "Loin expired, Kindly login again", IsExpired = true };
        }
    }
}