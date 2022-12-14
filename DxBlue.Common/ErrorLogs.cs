using System;
using System.IO;
using System.Web;
using System.Xml;

namespace DxBlue.Common.Utility
{
    public static class LogError
    {
        public static string MonthName(int month)
        {
            string monthName = string.Empty;
            switch (month)
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

        public static void WriteErrorToFile(Exception ex, string source)
        {
            string logFile = DateTime.Today.Year + "_" + MonthName(DateTime.Today.Month) + "_" + DateTime.Today.Day + ".xml";
            if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/errors/")))
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/errors/"));
            string logFilePath = HttpContext.Current.Server.MapPath("~/errors/") + logFile;

            if (!File.Exists(logFilePath))
            {
                using (XmlWriter writer = XmlWriter.Create(logFilePath))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Logs");
                    writer.WriteStartElement("Error");
                    writer.WriteElementString("DateTime", DateTime.Now.ToString());
                    //writer.WriteElementString("Application", System.Windows.Forms.Application.ProductName);
                    writer.WriteElementString("Message", " # " + ex.Message);
                    writer.WriteElementString("Source", source); //ex.StackTrace
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            else  // If XML File already exists
            {
                //XElement xml = XElement.Load(logFilePath);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(logFilePath);
                XmlElement subRoot = xmlDoc.CreateElement("Error");

                XmlElement xeDateTime = xmlDoc.CreateElement("DateTime");
                XmlText xDateTimeText = xmlDoc.CreateTextNode(DateTime.Now.ToString());
                xeDateTime.AppendChild(xDateTimeText);
                subRoot.AppendChild(xeDateTime);

                //XmlElement xeApplication = xmlDoc.CreateElement("Application");
                //XmlText xApplicationText = xmlDoc.CreateTextNode(System.Windows.Forms.Application.ProductName);
                //xeApplication.AppendChild(xApplicationText);
                //subRoot.AppendChild(xeApplication);

                XmlElement xeMessage = xmlDoc.CreateElement("Message");
                XmlText xMessageText = xmlDoc.CreateTextNode(ex.Message);
                xeMessage.AppendChild(xMessageText);
                subRoot.AppendChild(xeMessage);

                XmlElement xeSource = xmlDoc.CreateElement("Source");
                XmlText xSourceText = xmlDoc.CreateTextNode(source);
                xeSource.AppendChild(xSourceText);
                subRoot.AppendChild(xeSource);

                if (xmlDoc.DocumentElement != null) xmlDoc.DocumentElement.AppendChild(subRoot);

                //xml.Add(
                //    new XElement("DateTime", DateTime.Now.ToString()),
                //    new XElement("Application", System.Windows.Forms.Application.ProductName),
                //    new XElement("Error", ex.Message),
                //    new XElement("Source", ex.StackTrace));
                xmlDoc.Save(logFilePath);
            }

        }
    }
}
