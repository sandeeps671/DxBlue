using DxBlue.Common.Utility;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Web;

namespace DxBlue.Common
{
    public static class ReportHandler
    {
        public static void ExportSsrsReportPDF(
            ReportViewer strReportViewer,
            Hashtable hashtable,
            string strReportPath,
            string fileName,
            string strOutputPath,
            string source)
        {
            try
            {
                var reportParameter = new ReportParameter[hashtable.Count];
                var intCtr = 0;
                foreach (DictionaryEntry dict in hashtable)
                {
                    reportParameter[intCtr] = new ReportParameter(dict.Key.ToString(), dict.Value.ToString());
                    intCtr++;
                }

                strReportViewer.ShowParameterPrompts = false;
                //DisableUnwantedExportFormats(strReportViewer, intIsPdfOnly);
                strReportViewer.ProcessingMode = ProcessingMode.Remote;
                strReportViewer.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials();
                strReportViewer.ServerReport.ReportServerUrl = new Uri(StrReadServerUrl);
                strReportViewer.ServerReport.ReportPath = strReportPath;
                strReportViewer.ServerReport.SetParameters(reportParameter);
                strReportViewer.ServerReport.Refresh();

                string mimeType;
                string encoding;
                string extension;
                string[] streams;
                Warning[] warnings;
                var pdfBytes = strReportViewer.ServerReport.Render("PDF", string.Empty, out mimeType, out encoding, out extension, out streams, out warnings);

                // Save output file
                using (var fs = new FileStream(strOutputPath + fileName + ".pdf", FileMode.Create))
                {
                    fs.Write(pdfBytes, 0, pdfBytes.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }

        public static string StrReadServerUrl
        {
            get
            {
                string strSsrsServerUrl = string.Empty;
                if (ConfigurationManager.AppSettings["ssrsServerUrl"] != null)
                    strSsrsServerUrl = ConfigurationManager.AppSettings["ssrsServerUrl"];
                return strSsrsServerUrl;
            }
        }
        public static void DisableUnwantedExportFormats(ReportViewer strReportViewer, int intIsPdfOnly)
        {
            switch (intIsPdfOnly)
            {
                case 0:
                    foreach (var extension in strReportViewer.ServerReport.ListRenderingExtensions())
                    {
                        switch (extension.Name.Trim().ToLower())
                        {
                            case "mhtml":
                            case "image":
                            case "xml":
                            case "xls":
                            case "xlsx":
                            case "doc":
                            case "docx":
                            case "tif":
                            case "csv":
                                ReflectivelySetVisibilityFalse(extension);
                                break;
                        }
                    }
                    break;
            }
        }
        private static void ReflectivelySetVisibilityFalse(RenderingExtension extension)
        {
            FieldInfo info = extension.GetType().GetField("m_serverExtension", BindingFlags.NonPublic | BindingFlags.Instance);
            if (info == null) return;

            var actualExtension = info.GetValue(extension);
            if (actualExtension == null) return;
            PropertyInfo propInfo = actualExtension.GetType().GetProperty("Visible");
            if (propInfo != null && propInfo.CanWrite)
                propInfo.SetValue(actualExtension, false, null);
        }

        public static void ShowReport(ReportViewer strReportViewer, Hashtable hashtable, string strReportPath, string source, int intIsPdfOnly = 0)
        {
            try
            {
                var reportParameter = new ReportParameter[hashtable.Count];
                int intCtr = 0;
                foreach (DictionaryEntry dict in hashtable)
                {
                    reportParameter[intCtr] = new ReportParameter(dict.Key.ToString(), dict.Value.ToString());
                    intCtr++;
                }
                strReportViewer.ShowParameterPrompts = false;
                //DisableUnwantedExportFormats(strReportViewer, intIsPdfOnly);
                strReportViewer.ProcessingMode = ProcessingMode.Remote;
                strReportViewer.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials();
                strReportViewer.ServerReport.ReportServerUrl = new Uri(StrReadServerUrl);
                strReportViewer.ServerReport.ReportPath = strReportPath;
                strReportViewer.ServerReport.SetParameters(reportParameter);

                strReportViewer.AsyncRendering = true;
                strReportViewer.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }

        public static void ShowReport(
            ReportViewer strReportViewer,
            Hashtable hashtable,
            string strReportPath,
            bool showPropmt, string source)
        {
            try
            {
                var reportParameter = new ReportParameter[hashtable.Count];
                int intCtr = 0;
                foreach (DictionaryEntry dict in hashtable)
                {
                    reportParameter[intCtr] = new ReportParameter(dict.Key.ToString(), dict.Value.ToString());
                    intCtr++;
                }
                strReportViewer.ShowParameterPrompts = showPropmt;
                strReportViewer.ProcessingMode = ProcessingMode.Remote;
                strReportViewer.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials();
                strReportViewer.ServerReport.ReportServerUrl = new Uri(StrReadServerUrl);
                strReportViewer.ServerReport.ReportPath = strReportPath;
                strReportViewer.ServerReport.SetParameters(reportParameter);
                strReportViewer.AsyncRendering = true;
                strReportViewer.ServerReport.Refresh();
            }
            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }
        public static void ShowReport(ReportViewer strReportViewer, string strReportPath)
        {
            strReportViewer.ShowParameterPrompts = false;
            strReportViewer.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials();
            strReportViewer.ProcessingMode = ProcessingMode.Remote;
            strReportViewer.ServerReport.ReportServerUrl = new Uri(StrReadServerUrl);
            strReportViewer.ServerReport.ReportPath = strReportPath;
            strReportViewer.ServerReport.Refresh();
        }

        public static void ShowReport(ReportViewer strReportViewer, string strReportPath, bool showPropmt)
        {
            strReportViewer.ShowParameterPrompts = showPropmt;
            strReportViewer.ServerReport.ReportServerCredentials = new ReportServerNetworkCredentials();
            strReportViewer.ProcessingMode = ProcessingMode.Remote;
            strReportViewer.ServerReport.ReportServerUrl = new Uri(StrReadServerUrl);
            strReportViewer.ServerReport.ReportPath = strReportPath;
            strReportViewer.ServerReport.Refresh();
        }

        public static void RenderReport(ReportViewer strReportViewer, string strRenderType)
        {
            byte[] results;
            switch (strRenderType.Trim().ToLower())
            {
                case "pdf":
                    results = strReportViewer.ServerReport.Render("PDF");
                    HttpContext.Current.Response.ContentType = "Application/pdf";
                    HttpContext.Current.Response.AddHeader("content-disposition",
                                                           "attachment; filename=" + DateTime.Today + "_" +
                                                           DateTime.Today.Year + ".pdf");
                    HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                    HttpContext.Current.Response.End();
                    break;
                case "excel":
                    results = strReportViewer.ServerReport.Render("EXCEL");
                    HttpContext.Current.Response.ContentType = "Application/excel";
                    HttpContext.Current.Response.AddHeader("content-disposition",
                                                           "attachment; filename=" + DateTime.Today + "_" +
                                                           DateTime.Today.Year + ".xls");
                    HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                    HttpContext.Current.Response.End();
                    break;
                case "word":
                    results = strReportViewer.ServerReport.Render("WORD");
                    HttpContext.Current.Response.ContentType = "application/vnd.word";
                    HttpContext.Current.Response.AddHeader("content-disposition",
                                                           "attachment; filename=" + DateTime.Today + "_" +
                                                           DateTime.Today.Year + ".doc");
                    HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                    HttpContext.Current.Response.End();
                    break;
            }
        }

        public static void SsrsLocalReoprt(
            ReportViewer reportViewer,
            string strReportPath,
            ref Hashtable hashtable,
            DataTable dataTable,
            string source)
        {
            try
            {
                var reportParameter = new ReportParameter[hashtable.Count];
                var intCtr = 0;
                foreach (DictionaryEntry dict in hashtable)
                {
                    reportParameter[intCtr] = new ReportParameter(dict.Key.ToString(), dict.Value.ToString());
                    intCtr++;
                }
                reportViewer.Visible = true;
                var datasource = new ReportDataSource("DataSet1", dataTable);
                reportViewer.ShowParameterPrompts = true;
                reportViewer.ProcessingMode = ProcessingMode.Local;

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportPath = strReportPath;
                reportViewer.LocalReport.DataSources.Add(datasource);
                reportViewer.LocalReport.SetParameters(reportParameter);
                reportViewer.AsyncRendering = true;

                reportViewer.LocalReport.Refresh();
            }

            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }
        public static void SsrsLocalReoprt(
            ReportViewer reportViewer,
            string strReportPath,
            ref Hashtable hashtable,
            List<DataTable> dataTable,
            string source)
        {
            try
            {
                var reportParameter = new ReportParameter[hashtable.Count];
                var intCtr = 0;
                foreach (DictionaryEntry dict in hashtable)
                {
                    reportParameter[intCtr] = new ReportParameter(dict.Key.ToString(), dict.Value.ToString());
                    intCtr++;
                }
                reportViewer.Visible = true;
                reportViewer.ShowParameterPrompts = true;
                reportViewer.ProcessingMode = ProcessingMode.Local;

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportPath = strReportPath;
                int i = 1;
                foreach (var dt in dataTable)
                {
                    var datasource = new ReportDataSource("DataSet" + i, dt);
                    reportViewer.LocalReport.DataSources.Add(datasource);
                    i++;
                }

                // reportViewer.LocalReport.SetParameters(reportParameter);
                reportViewer.AsyncRendering = true;

                reportViewer.LocalReport.Refresh();
            }

            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }
        public static void SsrsLocalReoprt(
            ReportViewer reportViewer,
            string strReportPath,
            ref Hashtable hashtable,
            DataTable dataTable,
            string strRenderType,
            string source)
        {
            try
            {
                var reportParameter = new ReportParameter[hashtable.Count];
                var intCtr = 0;
                foreach (DictionaryEntry dict in hashtable)
                {
                    reportParameter[intCtr] = new ReportParameter(dict.Key.ToString(), dict.Value.ToString());
                    intCtr++;
                }
                reportViewer.Visible = true;
                var datasource = new ReportDataSource("DataSet1", dataTable);
                reportViewer.ShowParameterPrompts = true;
                reportViewer.ProcessingMode = ProcessingMode.Local;

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportPath = strReportPath;
                reportViewer.LocalReport.DataSources.Add(datasource);
                reportViewer.LocalReport.SetParameters(reportParameter);
                reportViewer.AsyncRendering = true;
                reportViewer.LocalReport.Refresh();
                byte[] results;
                switch (strRenderType.Trim().ToLower())
                {
                    case "pdf":
                        results = reportViewer.ServerReport.Render("PDF");
                        HttpContext.Current.Response.ContentType = "Application/pdf";
                        HttpContext.Current.Response.AddHeader("content-disposition",
                                                               "attachment; filename=" + DateTime.Today + "_" +
                                                               DateTime.Today.Year + ".pdf");
                        HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                        HttpContext.Current.Response.End();
                        break;
                    case "excel":
                        results = reportViewer.ServerReport.Render("EXCEL");
                        HttpContext.Current.Response.ContentType = "Application/excel";
                        HttpContext.Current.Response.AddHeader("content-disposition",
                                                               "attachment; filename=" + DateTime.Today + "_" +
                                                               DateTime.Today.Year + ".xls");
                        HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                        HttpContext.Current.Response.End();
                        break;
                    case "word":
                        results = reportViewer.ServerReport.Render("WORD");
                        HttpContext.Current.Response.ContentType = "application/vnd.word";
                        HttpContext.Current.Response.AddHeader("content-disposition",
                                                               "attachment; filename=" + DateTime.Today + "_" +
                                                               DateTime.Today.Year + ".doc");
                        HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                        HttpContext.Current.Response.End();
                        break;
                }
            }

            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }
        public static void SsrsLocalReoprt(
            ReportViewer reportViewer,
            string strReportPath,
            DataTable dataTable,
            string strRenderType,
            string source)
        {
            try
            {
                reportViewer.Visible = true;
                var datasource = new ReportDataSource("DataSet1", dataTable);
                reportViewer.ShowParameterPrompts = true;
                reportViewer.ProcessingMode = ProcessingMode.Local;

                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.ReportPath = strReportPath;
                reportViewer.LocalReport.DataSources.Add(datasource);
                reportViewer.AsyncRendering = true;
                reportViewer.LocalReport.Refresh();
                byte[] results;
                switch (strRenderType.Trim().ToLower())
                {
                    case "pdf":
                        results = reportViewer.LocalReport.Render("PDF");
                        HttpContext.Current.Response.ContentType = "Application/pdf";
                        HttpContext.Current.Response.AddHeader("content-disposition",
                                                               "attachment; filename=" + DateTime.Today + "_" +
                                                               DateTime.Today.Year + ".pdf");
                        HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                        HttpContext.Current.Response.End();
                        break;
                    case "excel":
                        results = reportViewer.LocalReport.Render("EXCEL");
                        HttpContext.Current.Response.ContentType = "Application/excel";
                        HttpContext.Current.Response.AddHeader("content-disposition",
                                                               "attachment; filename=" + DateTime.Today + "_" +
                                                               DateTime.Today.Year + ".xls");
                        HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                        HttpContext.Current.Response.End();
                        break;
                    case "word":
                        results = reportViewer.LocalReport.Render("WORD");
                        HttpContext.Current.Response.ContentType = "application/vnd.word";
                        HttpContext.Current.Response.AddHeader("content-disposition",
                                                               "attachment; filename=" + DateTime.Today + "_" +
                                                               DateTime.Today.Year + ".doc");
                        HttpContext.Current.Response.OutputStream.Write(results, 0, results.Length);
                        HttpContext.Current.Response.End();
                        break;
                }
            }

            catch (Exception ex)
            {
                LogError.WriteErrorToFile(ex, source);
            }
        }
    }

    [Serializable]
    public sealed class ReportServerNetworkCredentials : IReportServerCredentials
    {
        #region IReportServerCredentials Members

        public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password,
                                        out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;
            return false;
        }

        public WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }


        public ICredentials NetworkCredentials
        {
            get
            {
                string strSsrsUserName = string.Empty;
                string strSsrsDomainName = string.Empty;
                string strSsrsPassword = string.Empty;

                if (ConfigurationManager.AppSettings["ssrsUsername"] != null)
                    strSsrsUserName = ConfigurationManager.AppSettings["ssrsUsername"];

                if (ConfigurationManager.AppSettings["ssrsPassword"] != null)
                    strSsrsPassword = ConfigurationManager.AppSettings["ssrsPassword"];

                if (ConfigurationManager.AppSettings["ssrsDomainName"] != null)
                    strSsrsDomainName = ConfigurationManager.AppSettings["ssrsDomainName"];

                return new NetworkCredential(strSsrsUserName, strSsrsPassword, strSsrsDomainName);
            }
        }

        #endregion
    }
}
