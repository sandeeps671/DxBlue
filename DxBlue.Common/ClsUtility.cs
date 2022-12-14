using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DxBlue.Common.Utility
{
    public static class ClsUtility
    {
        public static string connSchool = "connSchool";
        public static string connRma = "connRma";
        public static string connSales = "connSales";
        public static readonly string connSales1 = ConfigurationManager.ConnectionStrings["connSales"].ConnectionString;
        public static readonly string connRma1 = ConfigurationManager.ConnectionStrings["connRma"].ConnectionString;

        private static string _strReportName = string.Empty;
        private static string _strReportServer = string.Empty;
        public static bool ShowParam = false;
        public static string ReportName = string.Empty;
        public static string ReportUrl = string.Empty;
        public static string ReportType = string.Empty;

        public static string StrReportName
        {
            get { return _strReportName.Trim(); }
            set { _strReportName = value; }
        }

        public static void FillDropDown(HtmlSelect ddl, DataTable dt, string TextField, string ValueField)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField.Trim().ToLower();
            ddl.DataBind();
        }
        public static void FillDropDown(HtmlSelect ddl, IEnumerable<object> dt, string TextField, string ValueField)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField.Trim().ToLower();
            ddl.DataBind();
        }
        public static void FillDropDown(DropDownList ddl, IEnumerable<object> dt, string TextField, string ValueField)
        {
            ddl.DataSource = dt;
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField.Trim().ToLower();
            ddl.DataBind();
        }

        public static string StrReportServer
        {
            get { return _strReportServer.Trim(); }
            set { _strReportServer = value; }
        }

        //public static string appMode = ConfigurationManager.AppSettings["appMode"] == null ? "" : ConfigurationManager.AppSettings["appMode"].ToString();
        public static string CceConnStr = "connstr";
        public static string ConnStr = "connstr";
        public static string connDashboard = "connDashboard";

        public static void RemoveCache()
        {
            HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.AppendHeader("Pragma", "no-cache");
        }

        public static string EncodeStr(string qStr, string source = "")
        {
            var utf8Encode = new UTF8Encoding();
            try
            {
                return Convert.ToBase64String(utf8Encode.GetBytes(qStr));
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
                return null;
            }
        }

        public static DateTime GetDate(object val, string source)
        {
            var dateTime = new DateTime();
            try
            {
                dateTime = Convert.ToDateTime(val);
            }
            catch
            {
                dateTime = Convert.ToDateTime("01/01/1900");
                //LogError.WriteErrorToFile(ex,source);
            }
            return dateTime;
        }
        public static DateTime GetDate(object val)
        {
            var dateTime = new DateTime();
            try
            {
                dateTime = Convert.ToDateTime(val);
            }
            catch
            {
                dateTime = Convert.ToDateTime("01/01/1900");
                //LogError.WriteErrorToFile(ex,source);
            }
            return dateTime;
        }

        public static string DecodeStr(string qStr, string source = "")
        {
            var utf8Encode = new UTF8Encoding();
            try
            {
                return utf8Encode.GetString(Convert.FromBase64String(qStr));
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
                return null;
            }
        }

        public static int GetInteger(object val, string source)
        {
            int result;
            try
            {
                result = Convert.ToInt32(val.ToString().Trim());
            }
            catch (Exception ex)
            {
                result = 0;
                LogError.WriteErrorToFile(ex, source);
            }
            return result;
        }
        public static int GetInteger(object val)
        {
            int result = 0;
            if (val == null) return 0;
            if (val != null) int.TryParse(val.ToString(), out result); // Added for fast work 
            return result;
        }
        public static byte[] ToByteArray(object val)
        {
            try
            {
                if (val == null) return null;
                return (byte[])val;
            }
            catch
            {
                return null;
            }
        }
        public static int GetInteger(String val)
        {
            int result = 0;
            if (val != "" && val != null) int.TryParse(val, out result); // Added for fast work 
            return result;
        }

        public static Int16 GetInteger16(String val)
        {
            Int16 result = 0;
            if (val != "") Int16.TryParse(val, out result); // Added for fast work 
            return result;
        }

        public static int GetInteger(Boolean val)
        {
            int result = val ? 1 : 0;
            return result;
        }


        //public static bool ToBoolean(object val)
        //{
        //    try
        //    {
        //        Boolean b = false;
        //        return bool.TryParse(val, out b);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public static Int16 GetInteger16(object val, string source)
        {
            Int16 result;
            try
            {
                result = Convert.ToInt16(val.ToString().Trim());
            }
            catch (Exception ex)
            {
                result = 0;
                LogError.WriteErrorToFile(ex, source);
            }
            return result;
        }

        public static Int16 GetInteger16(bool val)
        {
            Int16 result;
            result = Convert.ToInt16(val ? 1 : 0);
            return result;
        }

        public static double GetDouble(object val, string source)
        {
            double result;
            try
            {
                result = Convert.ToDouble(val.ToString().Trim());
            }
            catch (Exception ex)
            {
                result = 0;
                LogError.WriteErrorToFile(ex, source);
            }
            return result;
        }

        public static double GetDouble(string val)
        {
            double result = 0;
            if (val != "") double.TryParse(val, out result); // Added for fast work 
            return result;
        }

        public static decimal GetDecimal(object val, string source)
        {
            decimal result;
            try
            {
                result = Convert.ToDecimal(val.ToString().Trim());
            }
            catch (Exception ex)
            {
                result = 0;
                LogError.WriteErrorToFile(ex, source);
            }
            return result;
        }
        public static decimal GetDecimal(object val)
        {
            decimal result;
            try
            {
                result = Convert.ToDecimal(val.ToString().Trim());
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public static decimal GetDecimal(string val)
        {
            decimal result = 0;
            if (val != "") decimal.TryParse(val, out result); // Added for fast work 
            return result;
        }

        public static float GetFloat(object val, string source)
        {
            float result;
            try
            {
                result = float.Parse(val.ToString().Trim());
            }
            catch (Exception ex)
            {
                result = 0;
                LogError.WriteErrorToFile(ex, source);
            }
            return result;
        }

        public static int GetCurrentMonthNumber()
        {
            return DateTime.Today.Month;
        }
        public static int GetCurrentPLMonthNo()
        {
            return DateTime.Today.Month;
        }

        public static string GetCurrentMonthName()
        {
            string strMnthName = string.Empty;
            switch (DateTime.Today.Month)
            {
                case 1:
                    strMnthName = "January";
                    break;
                case 2:
                    strMnthName = "February";
                    break;
                case 3:
                    strMnthName = "March";
                    break;
                case 4:
                    strMnthName = "April";
                    break;
                case 5:
                    strMnthName = "May";
                    break;
                case 6:
                    strMnthName = "June";
                    break;
                case 7:
                    strMnthName = "July";
                    break;
                case 8:
                    strMnthName = "August";
                    break;
                case 9:
                    strMnthName = "September";
                    break;
                case 10:
                    strMnthName = "October";
                    break;
                case 11:
                    strMnthName = "November";
                    break;
                case 12:
                    strMnthName = "December";
                    break;
            }
            return strMnthName;
        }

        public static string GetDateDdMmYyyy(object date)
        {
            string result;
            try
            {
                string dt = Convert.ToDateTime(date).ToShortDateString();
                result = (dt == "01/01/1900" || dt == "1/1/1900")
                             ? string.Empty
                             : DateTime.Parse(dt).ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {
                result = string.Empty;
            }
            return result;
        }

        public static string GetValidDt(object date)
        {
            if (date.ToString() == "01/01/1900" || date.ToString() == "01/01/1900 12:00:00 AM" ||
                date.ToString() == "1/1/1900 12:00:00 AM" || date.ToString().Trim() == "1/1/0001 12:00:00 AM" ||
                date.ToString().Trim() == "1/1/0001")
                return "";
            return date.ToString();
        }
        public static bool ToBoolean(object data)
        {
            try
            {
                switch (data.ToString())
                {
                    case "1":
                    case "TRUE":
                    case "true":
                    case "True":
                        return true;
                    default: return false;
                }
            }
            catch { return false; }
        }
        public static DateTime ConvertToDt(object date)
        {
            try
            {
                if (date == null) return DateTime.Parse("01/01/1900");
                return Convert.ToDateTime(date);
            }
            catch
            {
                return Convert.ToDateTime("01/01/1900");
            }
        }
        public static DateTime GetDateMmDdYyyy(object date)
        {
            try
            {
                if (date == null) return DateTime.Parse("01/01/1900");

                var dateTimeFormatterProvider = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
                dateTimeFormatterProvider.ShortDatePattern = "dd/MM/yyyy";
                DateTime dateTime = DateTime.Parse(date.ToString(), dateTimeFormatterProvider);
                string formatted = dateTime.ToString("MM/dd/yyyy");

                return DateTime.Parse(formatted);
            }
            catch
            {
                return DateTime.Parse("01/01/1900");
            }
        }


        public static string GetAge(string strDob)
        {
            try
            {
                DateTime dtt = DateTime.Parse(strDob);
                DateTime td = DateTime.Now;
                int leapYear = 0;
                for (int i = dtt.Year; i < td.Year; i++)
                {
                    if (DateTime.IsLeapYear(i))
                        ++leapYear;
                }
                TimeSpan timespan = td.Subtract(dtt);
                int intDate = timespan.Days - leapYear;
                int intResult;
                int intYear = Math.DivRem(intDate, 365, out intResult);

                return intYear.ToString();
            }
            catch
            {
                return "";
            }
        }


        public static String[] GetTwoYearRange()
        {
            var s = new string[21];
            for (int i = 0; i <= 20; i++)
            {
                int ttl = 2001 + i;
                s[i] = Convert.ToString(2000 + i + "-" + ttl);
            }
            return s;
        }

        public static ArrayList GetYearRange()
        {
            int year = DateTime.Today.Year;
            year = year + 10;
            var s = new string[21];
            var al = new ArrayList();
            for (int i = 0; i <= 20; i++)
                //s[i] = Convert.ToString(year - i);
                al.Add(Convert.ToString(year - i));
            return al;
        }

        public static String[] GetMonthsListArray()
        {
            var mnth = new string[12];
            mnth[0] = "January";
            mnth[1] = "February";
            mnth[2] = "March";
            mnth[3] = "April";
            mnth[4] = "May";
            mnth[5] = "June";
            mnth[6] = "July";
            mnth[7] = "August";
            mnth[8] = "September";
            mnth[9] = "October";
            mnth[10] = "November";
            mnth[11] = "December";
            return mnth;
        }


        public static ArrayList GetMonthsListArrayList()
        {
            var al = new ArrayList
                         {
                             "January",
                             "February",
                             "March",
                             "April",
                             "May",
                             "June",
                             "July",
                             "August",
                             "September",
                             "October",
                             "November",
                             "December"
                         };
            return al;
        }

        public static void FillYears(DropDownList ddl)
        {
            int intCurrentyear = DateTime.Now.Year + 1;
            for (int i = 0; i <= 20; i++)
                ddl.Items.Add((intCurrentyear - i).ToString());
        }

        public static void FillMonths(CheckBoxList ddl)
        {
            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;

            ListItem li = new ListItem { Text = "April", Value = "1" };
            li.Attributes.Add("data-monthNo", "1");
            ddl.Items.Add(li);

            li = new ListItem { Text = "May", Value = "2" };
            li.Attributes.Add("data-monthNo", "1");
            ddl.Items.Add(li);

            li = new ListItem { Text = "June", Value = "3" };
            li.Attributes.Add("data-monthNo", "3");
            ddl.Items.Add(li);

            li = new ListItem { Text = "July", Value = "4" };
            li.Attributes.Add("data-monthNo", "3");
            ddl.Items.Add(li);

            li = new ListItem { Text = "August", Value = "5" };
            li.Attributes.Add("data-monthNo", "5");
            ddl.Items.Add(li);

            li = new ListItem { Text = "September", Value = "6" };
            li.Attributes.Add("data-monthNo", "6");
            ddl.Items.Add(li);

            li = new ListItem { Text = "October", Value = "7" };
            li.Attributes.Add("data-monthNo", "7");
            ddl.Items.Add(li);

            li = new ListItem { Text = "November", Value = "8" };
            li.Attributes.Add("data-monthNo", "8");
            ddl.Items.Add(li);

            li = new ListItem { Text = "December", Value = "9" };
            li.Attributes.Add("data-monthNo", "9");
            ddl.Items.Add(li);

            li = new ListItem { Text = "January", Value = "10" };
            li.Attributes.Add("data-monthNo", "10");
            ddl.Items.Add(li);

            li = new ListItem { Text = "February", Value = "11" };
            li.Attributes.Add("data-monthNo", "11");
            ddl.Items.Add(li);

            li = new ListItem { Text = "March", Value = "12" };
            li.Attributes.Add("data-monthNo", "12");
            ddl.Items.Add(li);

        }
        public static void FillMonths(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;

            ListItem li = new ListItem { Text = "April", Value = "1" };
            li.Attributes.Add("data-monthNo", "1");
            ddl.Items.Add(li);

            li = new ListItem { Text = "May", Value = "2" };
            li.Attributes.Add("data-monthNo", "1");
            ddl.Items.Add(li);

            li = new ListItem { Text = "June", Value = "3" };
            li.Attributes.Add("data-monthNo", "3");
            ddl.Items.Add(li);

            li = new ListItem { Text = "July", Value = "4" };
            li.Attributes.Add("data-monthNo", "3");
            ddl.Items.Add(li);

            li = new ListItem { Text = "August", Value = "5" };
            li.Attributes.Add("data-monthNo", "5");
            ddl.Items.Add(li);

            li = new ListItem { Text = "September", Value = "6" };
            li.Attributes.Add("data-monthNo", "6");
            ddl.Items.Add(li);

            li = new ListItem { Text = "October", Value = "7" };
            li.Attributes.Add("data-monthNo", "7");
            ddl.Items.Add(li);

            li = new ListItem { Text = "November", Value = "8" };
            li.Attributes.Add("data-monthNo", "8");
            ddl.Items.Add(li);

            li = new ListItem { Text = "December", Value = "9" };
            li.Attributes.Add("data-monthNo", "9");
            ddl.Items.Add(li);

            li = new ListItem { Text = "January", Value = "10" };
            li.Attributes.Add("data-monthNo", "10");
            ddl.Items.Add(li);

            li = new ListItem { Text = "February", Value = "11" };
            li.Attributes.Add("data-monthNo", "11");
            ddl.Items.Add(li);

            li = new ListItem { Text = "March", Value = "12" };
            li.Attributes.Add("data-monthNo", "12");
            ddl.Items.Add(li);

        }

        public static void FillDropdownWithFinancialMonths(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Select", "10"));
            ddl.Items.Insert(1, new ListItem("January", "11"));
            ddl.Items.Insert(2, new ListItem("February", "12"));
            ddl.Items.Insert(3, new ListItem("March", "3"));
            ddl.Items.Insert(4, new ListItem("April", "1"));
            ddl.Items.Insert(5, new ListItem("May", "2"));
            ddl.Items.Insert(6, new ListItem("June", "3"));
            ddl.Items.Insert(7, new ListItem("July", "4"));
            ddl.Items.Insert(8, new ListItem("August", "5"));
            ddl.Items.Insert(9, new ListItem("September", "6"));
            ddl.Items.Insert(10, new ListItem("October", "7"));
            ddl.Items.Insert(11, new ListItem("November", "8"));
            ddl.Items.Insert(12, new ListItem("December", "9"));
        }

        public static string GetBlankDate(object str)
        {
            try
            {
                return DateTime.Parse(str.ToString()).ToShortDateString().Trim() == "1/1/1900" ? "" : str.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static Double GetColumnTotal(DataList dl, String column, String ctrlType)
        {
            double total = 0;
            if (dl.Items.Count <= 0 || dl.EditItemIndex > -1)
                total = 0;
            else
            {
                switch (ctrlType)
                {
                    case "TextBox":
                        foreach (DataListItem dli in dl.Items)
                            total += Convert.ToDouble(((TextBox)dli.FindControl(column)).Text);
                        break;
                    case "HtmlTextBox":
                        foreach (DataListItem dli in dl.Items)
                            total +=
                                Convert.ToDouble(
                                    ((HtmlInputText)dli.FindControl(column)).Value);
                        break;
                    case "Label":
                        foreach (DataListItem dli in dl.Items)
                        {
                            var lbl = (Label)dli.FindControl(column);
                            if (lbl.Text.Trim() != "")
                                total += Convert.ToDouble(((Label)dli.FindControl(column)).Text);
                        }
                        break;
                }
            }
            return total;
        }

        public static Double GetColumnTotal(DataGrid dl, String column, String ctrlType)
        {
            double total = 0;
            if (dl.Items.Count <= 0 || dl.EditItemIndex > -1)
                total = 0;
            else
            {
                switch (ctrlType)
                {
                    case "TextBox":
                        foreach (DataGridItem dli in dl.Items)
                            total += Convert.ToDouble(((TextBox)dli.FindControl(column)).Text);
                        break;
                    case "HtmlTextBox":
                        foreach (DataGridItem dli in dl.Items)
                            total += Convert.ToDouble(((HtmlInputText)dli.FindControl(column)).Value);
                        break;
                    case "Label":
                        foreach (DataGridItem dli in dl.Items)
                        {
                            var lbl = (Label)dli.FindControl(column);
                            if (lbl.Text.Trim() != "" && lbl.Text != null)
                                total += Convert.ToDouble(((Label)dli.FindControl(column)).Text);
                        }
                        break;
                }
            }
            return total;
        }

        public static String GetCurrentSession()
        {
            int year = DateTime.Now.Year;
            string session = DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3
                                 ? (year - 1) + "-" + year
                                 : (year) + "-" + (year + 1);
            return session;
        }

        public static int GetCurrentSessionYear(DateTime dt)
        {
            int session;
            int year = dt.Year;
            if (dt.Month >= 1 && dt.Month <= 3)
                session = (year - 1);
            else
                session = year;
            return session;
        }

        public static int GetCurrentSessionYear()
        {
            int session;
            int year = DateTime.Now.Year;
            if (DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3)
                session = (year - 1);
            else
                session = year;
            return session;
        }

        public static int GetCurrentYear()
        {
            return DateTime.Today.Year;
        }

        public static int GetYearFromDt(object Dt)
        {
            DateTime Dat = Convert.ToDateTime(Dt);
            return Dat.Year;
        }

        public static int GetMonthFromDt(object Dt)
        {
            DateTime Dat = Convert.ToDateTime(Dt);
            return Dat.Month;
        }

        public static int GetDayFromDt(object Dt)
        {
            DateTime Dat = Convert.ToDateTime(Dt);
            return Dat.Day;
        }

        //public static string DateMonthYearFormat(object date)
        //{
        //    try
        //    {
        //        if (Convert.ToDateTime(date).ToShortDateString() != "01/01/1900")
        //        {
        //            DateTimeFormatInfo dateTimeFormatterProvider = DateTimeFormatInfo.CurrentInfo.Clone() as DateTimeFormatInfo;
        //            dateTimeFormatterProvider.ShortDatePattern = "MM/dd/yyyy";
        //            DateTime dateTime = DateTime.Parse(date.ToString(), dateTimeFormatterProvider);
        //            string formatted = dateTime.ToString("dd/MM/yyyy");

        //            return formatted;
        //        }
        //        return "01/01/1900";
        //    }
        //    catch
        //    {
        //        return "01/01/1900";
        //    }
        //}


        public static DropDownList AppendDropDown(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            var li = new ListItem { Text = "", Value = "0" };
            ddl.Items.Add(li);
            return ddl;
        }

        public static DropDownList AppendDropDownWithText(DropDownList ddl, string txt)
        {
            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            var li = new ListItem { Text = txt, Value = "0" };
            ddl.Items.Add(li);
            return ddl;
        }
        public static DropDownList AppendDropdownTextValue(DropDownList ddl, string txt, string val, int position)
        {
            var li = new ListItem { Text = txt, Value = val };
            ddl.Items.Insert(position, li);
            return ddl;
        }
        public static HtmlSelect AppendDropdownTextValue(HtmlSelect ddl, string txt, string val, int position)
        {
            var li = new ListItem { Text = txt, Value = val };
            ddl.Items.Insert(position, li);
            return ddl;
        }
        public static HtmlSelect AppendDropDownWithTextAndValue(HtmlSelect ddl, string txt, string val)
        {
            var li = new ListItem { Text = txt, Value = val };
            ddl.Items.Add(li);
            return ddl;
        }
        public static string DropDownText(DropDownList ddl)
        {
            return ddl.SelectedItem.ToString().Trim();
        }

        public static int DropDownIndex(DropDownList ddl)
        {
            return ddl.SelectedIndex;
        }

        public static string DropDownValue(DropDownList ddl)
        {
            return ddl.SelectedValue.Trim();
        }

        public static void FillDataGrid(DataGrid dg, DataTable dataTable, string datakeyField)
        {
            dg.DataSource = dataTable;
            switch (ToLower(datakeyField))
            {
                case "":
                    break;
                default:
                    dg.DataKeyField = datakeyField;
                    break;
            }
            dg.DataBind();
        }

        public static void FillRadioButtonList(RadioButtonList radioButtonList, DataTable dt, string TextField,
                                               string ValueField)
        {
            //if (dt == null || dt.Rows.Count < 0) return;
            radioButtonList.DataSource = dt;
            radioButtonList.DataTextField = TextField;
            radioButtonList.DataValueField = ValueField;
            radioButtonList.DataBind();
        }

        public static void FillCheckBoxList(CheckBoxList checkBoxList, DataTable dt, string TextField, string ValueField)
        {
            // if (dt == null || dt.Rows.Count < 0) return;
            checkBoxList.DataSource = dt;
            checkBoxList.DataTextField = TextField;
            checkBoxList.DataValueField = ValueField;
            checkBoxList.DataBind();
        }
        public static void FillCheckBoxList(CheckBoxList checkBoxList, IEnumerable<object> dt, string TextField, string ValueField)
        {
            // if (dt == null || dt.Rows.Count < 0) return;
            checkBoxList.DataSource = dt;
            checkBoxList.DataTextField = TextField;
            checkBoxList.DataValueField = ValueField;
            checkBoxList.DataBind();
        }
        public static void FillDropDown(DropDownList ddl, DataTable dt, string TextField, string ValueField)
        {
            //            if (dt == null || dt.Rows.Count < 0) return;
            ddl.DataSource = dt;
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField.Trim().ToLower();
            ddl.DataBind();
        }

        public static void FillDropDown(DropDownList ddl, SortedList sl)
        {
            ddl.DataSource = sl;
            ddl.DataTextField = "Key";
            ddl.DataValueField = "Value";
            ddl.DataBind();
        }

        public static void FillDropDown(DropDownList ddl, ArrayList al)
        {
            ddl.DataSource = al;
            ddl.DataBind();
        }

        public static void FillDropDown(DropDownList ddl, string[] strA)
        {
            ddl.DataSource = strA;
            ddl.DataBind();
        }

        public static bool IsItemSelected(CheckBoxList chkList)
        {
            bool flag = false;
            foreach (ListItem li in chkList.Items)
            {
                if (!li.Selected) continue;
                flag = true;
            }
            return flag;
        }

        public static bool IsItemSelected(RadioButtonList rdList)
        {
            bool flag = false;
            foreach (ListItem li in rdList.Items)
            {
                if (!li.Selected) continue;
                flag = true;
            }
            return flag;
        }

        public static bool IsItemSelected(ListBox lBox)
        {
            bool flag = false;
            foreach (ListItem li in lBox.Items)
            {
                if (!li.Selected) continue;
                flag = true;
            }
            return flag;
        }

        public static DateTime GetCurrentSessionDtMdy()
        {
            int year = DateTime.Now.Year;
            string session = DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3
                                 ? "04/01/" + (year - 1)
                                 : "04/01/" + (year);
            return Convert.ToDateTime(session);
        }

        public static string GetCurrentSessionDtDmy()
        {
            int year = DateTime.Now.Year;
            string session = DateTime.Now.Month >= 1 && DateTime.Now.Month <= 3
                                 ? "04/01/" + (year - 1)
                                 : "04/01/" + (year);
            return Convert.ToDateTime(session).ToString("dd/MM/yyyy");
        }

        public static DateTime GetSessionStartDt(DateTime dt)
        {
            int year = dt.Year;
            return dt.Month >= 1 && dt.Month <= 3
                       ? DateTime.Parse("04/01/" + (year - 1)).Date
                       : DateTime.Parse("04/01/" + (year)).Date;
        }

        public static string GetSessionStartDtDmy(DateTime dt)
        {
            int year = dt.Year;
            return dt.Month >= 1 && dt.Month <= 3
                       ? GetDateDdMmYyyy(DateTime.Parse("04/01/" + (year - 1)))
                       : GetDateDdMmYyyy(DateTime.Parse("04/01/" + (year)));
        }

        public static int GetSessionStartMonthNumber()
        {
            return 4;
        }

        public static DateTime GetCurrentSessionEndDt()
        {
            DateTime dt = DateTime.Today;
            int year = dt.Year;
            return dt.Month >= 1 && dt.Month <= 3
                       ? DateTime.Parse("03/31/" + (year))
                       : DateTime.Parse("03/31/" + (year + 1));
        }

        public static DateTime GetCurrentDateMdy()
        {
            return DateTime.Today;
            // return SqlHandler.GetStringFROMString("Select GETDATE()");
        }

        public static string GetCurrentDateDmy()
        {
            return DateTime.Today.ToString("dd/MM/yyyy");
        }

        public static SortedList GetMonthsList()
        {
            var sl = new SortedList
                         {
                             {"January", "1"},
                             {"February", "2"},
                             {"March", "3"},
                             {"April", "4"},
                             {"May", "5"},
                             {"June", "6"},
                             {"July", "7"},
                             {"August", "8"},
                             {"September", "9"},
                             {"October", "10"},
                             {"November", "11"},
                             {"December", "12"}
                         };
            return sl;
        }

        public static SortedList GetInterestModes()
        {
            var sl = new SortedList
                         {
                             {"Monthly", "Monthly"},
                             {"Quarterly", "Quarterly"},
                             {"Half Yearly", "Half Yearly"},
                             {"Yearly", "Yearly"}
                         };
            return sl;
        }

        public static SortedList GetInvestmentModes()
        {
            var sl = new SortedList
                         {
                             {"Cash", "Cash"},
                             {"Cheque", "Cheque"}
                         };
            return sl;
        }

        public static SortedList GetMaritalStatus()
        {
            var sl = new SortedList
                         {
                             {"Single", "Single"},
                             {"Married", "Married"},
                             {"Unmarried", "Unmarried"},
                             {"Divorsee", "Divorsee"}
                         };
            return sl;
        }

        public static string GetQtrNo(int monthNo)
        {
            string res = "1";
            switch (monthNo)
            {
                case 1:
                case 2:
                case 3:
                    res = "1";
                    break;
                case 4:
                case 5:
                case 6:
                    res = "2";
                    break;
                case 7:
                case 8:
                case 9:
                    res = "3";
                    break;
                case 10:
                case 11:
                case 12:
                    res = "4";
                    break;
            }
            return res;
        }

        public static string GetCurrentQuarterName()
        {
            string res = "1";
            switch (Convert.ToDateTime(GetCurrentDateMdy()).Month)
            {
                case 1:
                case 2:
                case 3:
                    res = "(04) Jan - Mar";
                    break;
                case 4:
                case 5:
                case 6:
                    res = "(02) Jul - Sep";
                    break;
                case 7:
                case 8:
                case 9:
                    res = "02-Second Quarter";
                    break;
                case 10:
                case 11:
                case 12:
                    res = "(03) Oct - Dec";
                    break;
            }
            return res;
        }

        public static SortedList GetQuarterList()
        {
            var sl = new SortedList
                         {
                             {"(01) Apr - Jun", "1"},
                             {"(02) Jul - Sep", "2"},
                             {"(03) Oct - Dec", "3"},
                             {"(04) Jan - Mar", "4"}
                         };
            return sl;
        }

        public static SortedList GetDatesListDmy(DateTime fromDt, DateTime ToDt)
        {
            var sl = new SortedList();
            while (fromDt <= ToDt)
            {
                sl.Add(fromDt.ToString("dd/MM/yyyy"), fromDt.ToString("dd/MM/yyyy"));
                fromDt = fromDt.AddDays(1);
            }
            return sl;
        }


        /// <summary>
        ///  Returns Database name for dynamic sql queries
        /// </summary>
        public static string GetCurrentMonthStartDtDmy()
        {
            string str;
            if (DateTime.Today.Month >= 1 && DateTime.Today.Month <= 9)
                str = "01/0" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            else
                str = "01/" + DateTime.Today.Month + "/" + DateTime.Today.Year;
            return str;
        }

        public static DateTime GetCurrentMonthStartDtMdy()
        {
            return Convert.ToDateTime(DateTime.Today.Month + "/01/" + DateTime.Today.Year);
        }
        public static DateTime GetCurrentMonthEndtDtMdy()
        {
            return Convert.ToDateTime(DateTime.Today.Month + "/01/" + DateTime.Today.Year).AddMonths(1).AddDays(-1);
        }
        public static string GetCurrentMonthEndDtDmy()
        {
            var dt = Convert.ToDateTime(DateTime.Today.Month + "/01/" + DateTime.Today.Year).AddMonths(1).AddDays(-1);
            string str;
            if (dt.Month >= 1 && dt.Month <= 9)
                str = "01/0" + dt.Month + "/" + dt.Year;
            else
                str = "01/" + dt.Month + "/" + dt.Year;
            return str;
        }
        public static DateTime GetMonthStartDtMdy(int month, int year)
        {
            return Convert.ToDateTime(month + "/01/" + year);
        }

        public static string GetBlankDt()
        {
            return "01/01/1900";
        }

        public static string GetUserName()
        {
            var id = (FormsIdentity)HttpContext.Current.User.Identity;
            FormsAuthenticationTicket ticket = id.Ticket;
            string userdata = ticket.UserData;
            string[] data = userdata.Split('#');

            return data[2];
        }

        public static int GetUserId()
        {
            int userId;
            try
            {
                var id = (FormsIdentity)HttpContext.Current.User.Identity;
                FormsAuthenticationTicket ticket = id.Ticket;
                string userdata = ticket.UserData;
                string[] data = userdata.Split('#');

                userId = int.Parse(data[1]);
            }
            catch
            {
                userId = 0;
            }
            return userId;
        }

        public static void FillExportType(DropDownList dropDownList)
        {
            var sl = new SortedList
                         {
                             {"Microsoft Excel", "EXCEL"},
                             {"Microsoft Word", "WORD"},
                             {"Portable File Document(PDF)", "PDF"}
                         };
            dropDownList.DataSource = sl;
            dropDownList.DataTextField = "Key";
            dropDownList.DataValueField = "Value";
            dropDownList.DataBind();
            dropDownList.SelectedValue = "PDF";
        }

        public static ArrayList GetReportType()
        {
            var list = new ArrayList { "PDF", "EXCEL", "WORD" };
            return list;
        }

        public static SortedList GetExportType()
        {
            var sl = new SortedList
                         {
                             {"Microsoft Excel", "EXCEL"},
                             {"Microsoft Word", "WORD"},
                             {"Portable File Document(PDF)", "PDF"}
                         };
            return sl;
        }

        public static string GetSchoolMonthName(int monthId)
        {
            string monthName = string.Empty;
            switch (monthId)
            {
                case 1:
                    monthName = "April";
                    break;
                case 2:
                    monthName = "May";
                    break;
                case 3:
                    monthName = "June";
                    break;
                case 4:
                    monthName = "July";
                    break;
                case 5:
                    monthName = "August";
                    break;
                case 6:
                    monthName = "September";
                    break;
                case 7:
                    monthName = "October";
                    break;
                case 8:
                    monthName = "November";
                    break;
                case 9:
                    monthName = "December";
                    break;
                case 10:
                    monthName = "January";
                    break;
                case 11:
                    monthName = "February";
                    break;
                case 12:
                    monthName = "March";
                    break;
            }
            return monthName;
        }
        public static string GetSchoolMonthNameReceipt(int monthId)
        {
            string monthName = string.Empty;
            switch (monthId)
            {
                case 1:
                    monthName = "Apr";
                    break;
                case 2:
                    monthName = "May";
                    break;
                case 3:
                    monthName = "Jun";
                    break;
                case 4:
                    monthName = "Jul";
                    break;
                case 5:
                    monthName = "Aug";
                    break;
                case 6:
                    monthName = "Sep";
                    break;
                case 7:
                    monthName = "Oct";
                    break;
                case 8:
                    monthName = "Nov";
                    break;
                case 9:
                    monthName = "Dec";
                    break;
                case 10:
                    monthName = "Jan";
                    break;
                case 11:
                    monthName = "Feb";
                    break;
                case 12:
                    monthName = "Mar";
                    break;
            }
            return monthName;
        }

        public static string GetMonthName(int monthId)
        {
            string monthName = string.Empty;
            switch (monthId)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
            }
            return monthName;
        }

        public static string GetValidDate(object dt)
        {
            string val;
            try
            {
                val = dt.ToString();
            }
            catch (Exception)
            {
                val = "";
            }
            return val;
        }

        //public static byte[] GetByte(object val)
        //{
        //    byte[] result = null;
        //    try
        //    {
        //        result = Convert.ToByte(val);
        //    }
        //    catch (Exception ex)
        //    {

        //        LogError.WriteErrorToFile(ex,source);
        //    }
        //    return result;
        //}

        public static string ToLower(object str)
        {
            return str.ToString().Trim().ToLower();
        }

        public static string ToUpper(object str)
        {
            return str.ToString().Trim().ToUpper();
        }

        public static string ToProperCase(object str, string source)
        {
            try
            {
                string val = str.ToString().Trim().ToLower();
                return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(val);
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
                return null;
            }
        }

        public static void SetDropDownValue(DropDownList ddl, string value = "0", string text = "")
        {
            var li = new ListItem { Text = text, Value = value };
            if (!ddl.Items.Contains(li))
                ddl.Items.Add(li);

            ddl.SelectedValue = li.Value;
        }
        public static void SetDropDownValue(DropDownList ddl, ListItem li)
        {
            if (li == null) return;

            if (!ddl.Items.Contains(li))
                ddl.Items.Add(li);

            ddl.SelectedValue = li.Value;
        }

        public static void SetRadioButtionListValue(RadioButtonList rbl, string value = "0", string text = "")
        {
            var li = new ListItem { Text = text, Value = value };
            if (!rbl.Items.Contains(li))
                rbl.Items.Add(li);

            rbl.SelectedValue = li.Value;
        }

        public static void SetCheckBoxListValue(CheckBoxList chk, string value = "0", string text = "")
        {
            var li = new ListItem { Text = text, Value = value };
            if (!chk.Items.Contains(li))
                chk.Items.Add(li);

            chk.SelectedValue = li.Value;
        }

        public static string GetString(object val, string source)
        {
            string result;
            try
            {
                if (val == null) return "";
                result = val.ToString().Trim();
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
                result = string.Empty;
            }
            return result;
        }
        public static string GetString(object val)
        {
            string result;
            try
            {
                if (val == null) return "";
                result = val.ToString().Trim();
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "");
                result = string.Empty;
            }
            return result;
        }


        public static string UniqueName(string reportName, string exportType)
        {
            string strUniqueName;
            try
            {
                strUniqueName = DateTime.Today.Month + DateTime.Today.Day + "-" +
                                DateTime.Now.Millisecond;
                //strUniqueName = strUniqueName + reportName.Substring(0, reportName.IndexOf(".rpt")) + ".pdf";
                strUniqueName = strUniqueName + reportName + "." + exportType;
            }
            catch (Exception)
            {
                strUniqueName = (DateTime.Today.Month + DateTime.Today.Day).ToString();
            }
            return strUniqueName;
        }

        public static string ReturnExtension(string fileExtension)
        {
            #region Code to download any file from aspx page

            //byte[] fileData = DownloadReport();
            //Response.ClearContent();
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + "ABC.pdf");
            //var bw = new BinaryWriter(Response.OutputStream);
            //bw.Write(fileData);
            //bw.Close();
            //Response.ContentType = ClsUtility.ReturnExtension(".pdf");
            //Response.End();

            #endregion

            switch (ToLower(fileExtension))
            {
                case "htm":
                case "html":
                case "log":
                    return "text/HTML";
                case "txt":
                    return "text/plain";
                case "doc":
                    return "application/ms-word";
                case "tiff":
                case "tif":
                    return "image/tiff";
                case "asf":
                    return "video/x-ms-asf";
                case "avi":
                    return "video/avi";
                case "zip":
                    return "application/zip";
                case "xls":
                case "csv":
                    return "application/vnd.ms-excel";
                case "gif":
                    return "image/gif";
                case "jpg":
                case "jpeg":
                    return "image/jpeg";
                case "bmp":
                    return "image/bmp";
                case "wav":
                    return "audio/wav";
                case "mp3":
                    return "audio/mpeg3";
                case "mpg":
                case "mpeg":
                    return "video/mpeg";
                case "rtf":
                    return "application/rtf";
                case "asp":
                    return "text/asp";
                case "pdf":
                    return "application/pdf";
                case "fdf":
                    return "application/vnd.fdf";
                case "ppt":
                    return "application/mspowerpoint";
                case "dwg":
                    return "image/vnd.dwg";
                case "msg":
                    return "application/msoutlook";
                case "xml":
                case "sdxl":
                    return "application/xml";
                case "xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public static void DeleteFile(string filePath, string source)
        {
            try
            {
                if (File.Exists(filePath)) File.Delete(filePath);
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }


        public static SortedList GetSessionList()
        {
            var sl = new SortedList();

            int yr = DateTime.Today.Year - 5;
            for (int i = 0; i <= 20; i++)
            {
                sl.Add(yr + "-" + (yr + 1), yr);
                yr++;
            }
            return sl;
        }

        public static int GetRandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public static bool ValidImage(string str)
        {
            switch (str.ToLower())
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                //case ".bmp":
                //    return true;
                default:
                    return false;
            }
        }

        public static bool ValidDoc(string str)
        {
            switch (str.ToLower())
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".pdf":
                    return true;
                case ".doc":
                    return true;
                default:
                    return false;
            }
        }

        public static void BindNumber(DropDownList ddl, int IntNo)
        {
            ddl.Items.Clear();
            ddl.ClearSelection();
            for (int i = 0; i <= IntNo; i++)
            {
                ddl.Items.Add(i.ToString());
            }
        }

        public static void BindNumber(CheckBoxList chk, int IntNo)
        {
            chk.Items.Clear();
            chk.ClearSelection();
            for (int i = 0; i <= IntNo; i++)
            {
                chk.Items.Add(i.ToString());
            }
        }


        public static void ExportDataToExcel(DataTable dt, string ReportName)
        {
            var dg = new DataGrid();
            dg.HeaderStyle.Font.Bold = true;
            dg.DataSource = dt;
            dg.DataBind();

            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AppendHeader("content-disposition",
                                                      "attachment; filename='" + ReportName + "'.xls");
            HttpContext.Current.Response.Charset = "";
            var sw = new StringWriter();
            var hw = new HtmlTextWriter(sw);
            hw.RenderBeginTag(HtmlTextWriterTag.Html);
            dg.RenderControl(hw);
            hw.RenderEndTag();
            HttpContext.Current.Response.Write(sw);
            HttpContext.Current.Response.End();
        }

        public static string ChangeNumericToWords(double numb)
        {
            String num = numb.ToString();
            return "Rupees " + ChangeToWords(num, false) + " Only ";
        }

        public static string ChangeCurrencyToWords(String numb)
        {
            return ChangeToWords(numb, true);
        }

        public static string ChangeNumericToWords(String numb)
        {
            return ChangeToWords(numb, false);
        }

        public static string ChangeCurrencyToWords(double numb)
        {
            return ChangeToWords(numb.ToString(), true);
        }

        public static string ChangeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("Only") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("and") : ("point"); // just to separate whole numbers from points/cents
                        endStr = (isCurrency) ? ("Cents " + endStr) : ("");
                        pointStr = TranslateCents(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", TranslateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch
            {
                ;
            }
            return val;
        }

        public static string TranslateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool isDone = false; //test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))
                if (dblAmt > 0)
                {
                    //test for zero or digit zero in a nuemric
                    bool beginsZero = number.StartsWith("0"); //tests for 0XX

                    int numDigits = number.Length;
                    int pos = 0; //store digit grouping
                    String place = "";
                    switch (numDigits)
                    {
                        case 1: //ones' range
                            word = Ones(number);
                            isDone = true;
                            break;
                        case 2: //tens' range
                            word = Tens(number);
                            isDone = true;
                            break;
                        case 3: //hundreds' range
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4: //thousands' range
                        case 5:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 6:
                            pos = (numDigits % 6) + 1;
                            place = " Lakh ";
                            break;
                        case 7: //millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10: //Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        //if transalation is not done, continue...(Recursion comes in now!!)
                        word = TranslateWholeNumber(number.Substring(0, pos)) + place +
                               TranslateWholeNumber(number.Substring(pos));
                        //check for trailing zeros
                        if (beginsZero) word = " and " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                ;
            }
            return word.Trim();
        }

        public static string Tens(string digit)
        {
            int digt = Convert.ToInt32(digit);
            string name = null;
            switch (digt)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (digt > 0)
                        name = Tens(digit.Substring(0, 1) + "0") + " " + Ones(digit.Substring(1));
                    break;
            }
            return name;
        }

        public static string Ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        public static string TranslateCents(string cents)
        {
            string cts = "", digit = "";
            for (int i = 0; i < cents.Length; i++)
            {
                digit = cents[i].ToString();
                string engOne = "";
                if (digit.Equals("0"))
                    engOne = "Zero";
                else
                {
                    engOne = Ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }

        public static string SelectedItemsWithComma(CheckBoxList list)
        {
            string strB = "";
            foreach (ListItem li in list.Items)
            {
                if (li.Selected)
                {
                    strB += li.Text;
                    strB += ",";
                }
            }
            if (!string.IsNullOrWhiteSpace(strB))
                strB = strB.Substring(0, strB.Length - 1);
            return strB;
        }

        public static string SelectedValuesWithComma(CheckBoxList list)
        {
            string strB = "";
            foreach (ListItem li in list.Items)
            {
                if (li.Selected)
                {
                    strB += li.Value;
                    strB += ",";
                }
            }
            if (!string.IsNullOrWhiteSpace(strB))
                strB = strB.Substring(0, strB.Length - 1);
            return strB;
        }

        public static string SelectedItemsWithComma(RadioButtonList list)
        {
            string strB = "";
            foreach (ListItem li in list.Items)
            {
                if (li.Selected)
                {
                    strB += li.Text;
                    strB += ",";
                }
            }
            if (!string.IsNullOrWhiteSpace(strB))
                strB = strB.Substring(0, strB.Length - 1);
            return strB;
        }

        public static string SelectedValuesWithComma(RadioButtonList list)
        {
            string strB = "";
            foreach (ListItem li in list.Items)
            {
                if (li.Selected)
                {
                    strB += li.Value;
                    strB += ",";
                }
            }
            if (!string.IsNullOrWhiteSpace(strB))
                strB = strB.Substring(0, strB.Length - 1);
            return strB;
        }

        public static string SelectedItemsWithComma(ListBox list)
        {
            string strB = "";
            foreach (ListItem li in list.Items)
            {
                if (li.Selected)
                {
                    strB += li.Text;
                    strB += ",";
                }
            }
            if (!string.IsNullOrWhiteSpace(strB))
                strB = strB.Substring(0, strB.Length - 1);
            return strB;
        }

        public static string SelectedValuesWithComma(ListBox list)
        {
            string strB = "";
            foreach (ListItem li in list.Items)
            {
                if (li.Selected)
                {
                    strB += li.Value;
                    strB += ",";
                }
            }
            if (!string.IsNullOrWhiteSpace(strB))
                strB = strB.Substring(0, strB.Length - 1);
            return strB;
        }

        public static void SetAllItemChecked(CheckBoxList checkBoxList)
        {
            foreach (ListItem item in checkBoxList.Items)
            {
                item.Selected = true;
            }
        }

        public static void SetFirstItemSelected(RadioButtonList radioButtonList)
        {
            if (radioButtonList.Items.Count > 0)
            {
                radioButtonList.Items[0].Selected = true;
            }
        }

        public static decimal GetRound(decimal amount)
        {
            return Math.Round(amount, 0, MidpointRounding.AwayFromZero);
        }


        public static readonly string ReportServiceUrl = "";// new AppSettingsReader().GetValue("ReportServiceUrl", typeof(string)).ToString();
        public static readonly string ReportServerUrl = ""; // new AppSettingsReader().GetValue("ReportServerUrl", typeof(string)).ToString();
        public static readonly string StrRptFolder = ""; // new AppSettingsReader().GetValue("RptFolder", typeof(string)).ToString();

        public static readonly string ServerDomainName = ""; // new AppSettingsReader().GetValue("serverDomainName", typeof(string)).ToString();

        public static readonly string ServerUsername = ""; // new AppSettingsReader().GetValue("ServerUsername", typeof(string)).ToString();
        public static readonly string ServerPassword = ""; // new AppSettingsReader().GetValue("ServerPassword", typeof(string)).ToString();

        public static int GetQStrInt(string qStrVal)
        {
            try
            {
                if (HttpContext.Current.Request.QueryString[qStrVal] == null) return 0;
                return GetInteger(HttpContext.Current.Request.QueryString[qStrVal].ToString());
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "QSTR" + qStrVal);
                return 0;
            }
        }
        public static string GetQStrString(string qStrVal)
        {
            try
            {
                if (HttpContext.Current.Request.QueryString[qStrVal] == null) return "";
                return GetString(HttpContext.Current.Request.QueryString[qStrVal].ToString()).Trim();
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "QSTR" + qStrVal);
                return "";
            }
        }
        public static string GetQStrStringRV(string qStrVal)
        {
            try
            {
                if (HttpContext.Current.Request.QueryString[qStrVal] == null) return "";
                return GetString(HttpContext.Current.Request.QueryString[qStrVal].ToString()).Trim().Replace(" ", "+");
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "QSTR" + qStrVal);
                return "";
            }
        }

        public static int GetPostStrInt(string qStrVal)
        {
            try
            {
                if (HttpContext.Current.Request[qStrVal] == null) return 0;
                return GetInteger(HttpContext.Current.Request[qStrVal].ToString());
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, "GetPostStrInt" + qStrVal);
                return 0;
            }
        }
        public static int? GetNullIfZero(int val)
        {
            if (val == 0) return null;
            else return val;
        }
        public static string GetNullIfBlank(string val)
        {
            if (val == null) return null;
            else if (val == "") return null;
            else return val;
        }
        public static int CommandTimeout120 = 120;
        public static int CommandTimeout60 = 120;
    }
}