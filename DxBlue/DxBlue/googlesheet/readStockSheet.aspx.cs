using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Data;

namespace DxBlue.googlesheet
{
    public partial class readStockSheet : System.Web.UI.Page
    {
        DataTable dtStock = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            //var gsh = new GoogleSheetsHelper("consistent-320005-66acf297f757.json", "1c8fDHwbhSLAiPiXuuAo2AqPlcGew9HhABeb2tvfRJC4");
            ////var gsp = new GoogleSheetParameters() { RangeColumnStart = 1, RangeRowStart = 1, RangeColumnEnd = 3, RangeRowEnd = 100, FirstRowIsHeaders = true, SheetName = "Stock Report" };
            //var gsp = new GoogleSheetParameters() { SheetName = "Stock Report", IsFullSheetAsRange = true };
            //var rowValues = gsh.GetDataFromSheet(gsp);
            ////foreach (var rowValue in rowValues)
            ////{
            ////    var name = rowValue.Column1;
            ////    var color = rowValue.Column2;
            ////    var color = rowValue.Column3;
            ////}
            ///
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            string ApplicationName = "consistent";

            //var myFileName = HttpContext.Current.Server.MapPath("~/prerequisites/googlesheet/keys/" + "consistent-320005-66acf297f757.json");
            var myFileName = HttpContext.Current.Server.MapPath("~/consistent-320005-66acf297f757.json");
            var credential = GoogleCredential.FromStream(new FileStream(myFileName, FileMode.Open)).CreateScoped(Scopes);
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.  
            //String spreadsheetId = "1c8fDHwbhSLAiPiXuuAo2AqPlcGew9HhABeb2tvfRJC4";
            String spreadsheetId = "1QmoPDHapmZ5_DNP-fg4eOMHqNesVUxAJUinW1hC5oQM"; 
            String range = "Item Stock";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                                    service.Spreadsheets.Values.Get(spreadsheetId, range);
            // Prints the names and majors of students in a sample spreadsheet:  
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;
            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    var dd = row;
                   // Response.Write(row[0] + " , " + row[1] + " , " + row[2] + " , " + row[3] + " , " + row[4]);
                    // Writing Data on Console...
                    //Response.Write("{0} | {1} | {2} | {3} | {4} ", row[0], row[1], row[2], row[3], row[4]);
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        
       
    }
}