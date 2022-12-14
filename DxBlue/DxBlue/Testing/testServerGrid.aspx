<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testServerGrid.aspx.cs" Inherits="DxBlue.Testing.testServerGrid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.5.1.min.js"></script>

    <!-- DevExtreme theme -->
    <link rel="stylesheet" href="https://cdn3.devexpress.com/jslib/21.1.3/css/dx.softblue.compact.css">
    <%--<link rel="stylesheet" href="https://cdn3.devexpress.com/jslib/21.1.3/css/dx.softblue.css">--%>
    <!-- DevExtreme library -->
    <script type="text/javascript" src="https://cdn3.devexpress.com/jslib/21.1.3/js/dx.all.js"></script>
    <!-- <script type="text/javascript" src="https://cdn3.devexpress.com/jslib/21.1.3/js/dx.web.js"></script> -->
    <!-- <script type="text/javascript" src="https://cdn3.devexpress.com/jslib/21.1.3/js/dx.viz.js"></script> -->
    <script src="../Scripts/Shared/jHandler.js"></script>
    <style>
        .dx-datagrid .dx-data-row > td.bullet {
            padding-top: 0;
            padding-bottom: 0;
        }

        .dx-datagrid-headers {
            background-color: dodgerblue;
            font-weight: bold;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="demo-container" style="padding: 15px">
                <div id="gridContainer"></div>
            </div>
            <script>
                $(document).ready(function () {
                    let gridContainer;
                    gridContainer = $("#gridContainer").dxDataGrid({
                        //onInitialized: function (e) { dataGrid = e.component; },
                        dataSource: {
                            store: {
                                type: "odata",
                                url: "/api/cParty/ListSalesParty",
                                beforeSend: function (request) { }
                            }
                        },
                        columns: [
                            
                            { dataField: "ContactName", caption: "Contact Name", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 120, width: "20%" },
                            { dataField: "CompanyName", caption: "Company", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 120, width: "20%" },
                            { dataField: "CreditDays", caption: "Credit Days", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 80, width: "5%" },
                            { dataField: "AreaName", caption: "Area", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "10%" },
                            { dataField: "MobileNo", caption: "Mobile", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "10%" },
                            { dataField: "Address", caption: "Address", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 60, width: "15%", visible: false },
                            { dataField: "Pincode", caption: "Pincode", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 60, width: "10%", visible: false },
                            { dataField: "StateName", caption: "State", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "10%", visible: false },
                            { dataField: "GST", caption: "GST", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "10%", visible: false },
                            { dataField: "PAN_No", caption: "PAN_No", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "10%", visible: true }
                        ],
                        onContentReady: function (e) { }
                    });
                });
            </script>

        </div>
    </form>
</body>
</html>
