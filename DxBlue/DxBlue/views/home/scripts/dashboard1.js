var chart, chartData;
var chartState, chartDataState;
var chartGroup, chartDataGroup;
var IsExport = false;
$(document).ready(function () {
    $('#reportrange span').html(GetMonthStartDt().format('MMM D, YYYY') + ' - ' + GetMonthEndDt().format('MMM D, YYYY') + ' ')
    $(".select2").select2();
    IsExport = GetBoolValue($(".hIsExport"));
    runReportRange();
    fillTargetVsAchivementSummary();
    fillGroupWiseVsTarget();
    fillProductVsTarget();
    google.charts.setOnLoadCallback(drawAreaWiseSalesChart);
    google.charts.setOnLoadCallback(drawStateWiseSalesChart);
    google.charts.setOnLoadCallback(drawGroupWiseSalesChart);
    //setInterval(blink_text, 3000);
});

var runReportRange = function () {
    if ($('#reportrange').length) {
        $('#reportrange').daterangepicker({
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract('days', 1), moment().subtract('days', 1)],
                'Last 7 Days': [moment().subtract('days', 6), moment()],
                'Last 30 Days': [moment().subtract('days', 29), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract('month', 1).startOf('month'), moment().subtract('month', 1).endOf('month')]
            }, format: 'DD/MM/YYYY',
            startDate: moment().startOf('month'),
            endDate: moment().endOf('month')
        }, function (start, end) {
            $('#reportrange span').html(start.format('MMM D, YYYY') + ' - ' + end.format('MMM D, YYYY') + ' ');
            FillTargets();
        });
    }
};
function areaChange() {
    $(".ddlTargetUser").empty().append($("<option></option>").val("0").html("All"));
    FillTargets();
}
function FillTargets() {
    let ddlTarget = $(".ddlTarget");
    let data = {
        fromDate: GetMdyDate($("#reportrange").data('daterangepicker').startDate._d),
        toDate: GetMdyDate($("#reportrange").data('daterangepicker').endDate._d),
        areaId: GetCtrlIntVal($(".ddlArea"))
    };
    ddlTarget.empty();
    ddlTarget.append($("<option></option>").val("0").html("All"));
    $.ajax({
        type: "GET", url: baseApiUrl + "/api/cTarget/ListTargetsInArea", data: data,
        contentType: "application/json; charset=utf-8", dataType: "json",
        success: function (res) {
            $.each(res, function (index, item) { ddlTarget.append($("<option></option>").val(item.TargetId).html(item.TargetTitle)); });
            doLoadData();
        },
        failure: function (err) { toastr.error("Error while contacting server, please try again"); },
        error: function (err) { toastr.error("Error while contacting server, please try again"); }
    });
}
function targetChange() {
    let ddlTargetUser = $(".ddlTargetUser");
    let data = {
        targetId: GetCtrlIntVal($(".ddlTarget"))
    };
    ddlTargetUser.empty();
    ddlTargetUser.append($("<option></option>").val("0").html("All"));
    $.ajax({
        type: "GET", url: baseApiUrl + "/api/cTarget/ListTargetUser", data: data,
        contentType: "application/json; charset=utf-8", dataType: "json",
        success: function (res) {
            $.each(res, function (index, item) { ddlTargetUser.append($("<option></option>").val(item.TargerUserId).html(item.TargetUserName)); });
            doLoadData();
        },
        failure: function (err) { toastr.error("Error while contacting server, please try again"); },
        error: function (err) { toastr.error("Error while contacting server, please try again"); }
    });
}
function paramData() {
    return {
        fromDate: GetMdyDate($("#reportrange").data('daterangepicker').startDate._d),
        toDate: GetMdyDate($("#reportrange").data('daterangepicker').endDate._d),
        areaId: GetCtrlIntVal($(".ddlArea")),
        targetId: GetCtrlIntVal($(".ddlTarget")),
        view: GetCtrlIntVal($(".ddlView")),
        targetType: "0",// GetCtrlVal($(".ddlTargetType")),
        targetUserId: GetCtrlIntVal($(".ddlTargetUser")),
    };
}
function viewChange() { doLoadData(); }
function targetUserChange() { doLoadData(); }

function doLoadData() {
    fillTargetVsAchivementSummary();
    fillGroupWiseVsTarget();
    fillProductVsTarget();

    drawAreaWiseSalesChart();
    drawStateWiseSalesChart();
    drawGroupWiseSalesChart();
}
function fillTargetVsAchivementSummary() {
    $('#tblTotalTarget tbody tr').remove();
    $('#tblTotalTarget tbody tr').append('<tr><td colspan="6"><i class="fad fa-asterisk fa-spin"></i></td></tr>');
    $.ajax({
        type: "GET",
        url: baseApiUrl + "/api/cDashboard1/GetTargetVsAchivementSummary",
        data: paramData(),
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            $('#tblTotalTarget tbody tr').remove();
            $('#tblTotalTarget tbody').append(
                '<tr class="text-default">' +
                '<td class="text-center">' + res.AvailableQty + '</td>' +
                '<td class="text-center">' + res.TargetQty + '</td>' +
                '<td class="text-center">' + res.TargetAmt + '</td>' +
                '<td class="text-center">' + res.AchieveQty + '</td>' +
                '<td class="text-center">' + res.AchieveAmt + '</td>' +
                '<td class="text-center">' + res.PercentQty + '</td>' +
                '<td class="text-center">' + res.PercentAmt + '</td>' +
                '</tr>');
        },
        error: function (err) { console.log(err.responseText); },
        complete: function () { }
    });
}
function fillGroupWiseVsTargetNew() {
}
function fillGroupWiseVsTarget() {
    dgGroupwise = $("#dgGroupVsTarget").dxDataGrid({
        onInitialized: function (e) { dataGrid = e.component; },
        dataSource: {
            store: {
                type: "odata",
                url: baseApiUrl + "/api/cDashboard1/ListGroupwiseSalesVsTgtSummary",
                beforeSend: function (req) {
                    req.params.fromDate = GetMdyDate($("#reportrange").data('daterangepicker').startDate._d);
                    req.params.toDate = GetMdyDate($("#reportrange").data('daterangepicker').endDate._d);
                    req.params.areaId = GetCtrlIntVal($(".ddlArea"));
                    req.params.targetId = GetCtrlIntVal($(".ddlTarget"));
                    req.params.view = GetCtrlIntVal($(".ddlView"));
                    req.params.targetType = "0";// GetCtrlVal($(".ddlTargetType"));
                    req.params.targetUserId = GetCtrlIntVal($(".ddlTargetUser"));
                }
            }
        },
        onToolbarPreparing: function (e) {
            let dataGrid = e.component;
            e.toolbarOptions.items.unshift({ location: "after", widget: "dxButton", options: { icon: "refresh", onClick: function () { dataGrid.refresh(); } } });
        },
        height: "300px", paging: { enabled: false },
        columns: [
            {
                caption: 'SNo',
                cellTemplate: function (container, options) { container.text(dataGrid.pageIndex() * dataGrid.pageSize() + options.rowIndex + 1); },
                dataType: "number", alignment: "center", minWidth: 60, width: "10%", allowExporting: false
            },
            {
                dataField: "CategoryName", caption: "Category Name",
                dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 120, width: "15%",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); },
            },
            {
                dataField: "GroupName", caption: "Group Name",
                dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 120, width: "20%",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); },
            },
            {
                dataField: "AvailableQty", caption: "Stock",
                dataType: "number", alignment: "center", allowHeaderFiltering: true, minWidth: 90, width: "10%",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); },
            },
            {
                caption: "Target", alignment: "center", minWidth: 120, width: "25%",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); },
                columns: [{
                    dataField: "TargetQty", caption: "Qty",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60
                }, {
                    dataField: "TargetAmt", caption: "Amount",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60
                }]
            },
            {
                caption: "Achievement", alignment: "center", minWidth: 120, width: "25%",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '16px').appendTo(header); },
                columns: [{
                    dataField: "AchieveQty", caption: "Qty",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60//, sortIndex: 2, sortOrder: "desc"
                }, {
                    dataField: "AchieveAmt", caption: "Amount",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60, sortIndex: 1, sortOrder: "desc"
                }]
            },
        ],
        onContentReady: function (e) { },
        export: { enabled: IsExport }, onExporting: function (e) { exportDxGrid(e, "TargetVsAchivement_V1", "Sheet1"); },
        summary: {
            totalItems: [
                { column: "AvailableQty", summaryType: "sum", showInColumn: "AvailableQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "TargetQty", summaryType: "sum", showInColumn: "TargetQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "TargetAmt", summaryType: "sum", showInColumn: "TargetAmt", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "AchieveQty", summaryType: "sum", showInColumn: "AchieveQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "AchieveAmt", summaryType: "sum", showInColumn: "AchieveAmt", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "fixedPoint", precision: 2 } }
            ],
            //groupItems: [
            //    { column: "AvailableQty", summaryType: "sum", showInColumn: "AvailableQty", alignment: "right", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", showInGroupFooter: false, alignByColumn: true },
            //    { column: "TargetQty", summaryType: "sum", showInColumn: "TargetQty", alignment: "right", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", showInGroupFooter: false, alignByColumn: true },
            //    { column: "TargetAmt", summaryType: "sum", showInColumn: "TargetAmt", alignment: "right", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", alignByColumn: true },
            //    { column: "AchieveQty", summaryType: "sum", showInColumn: "AchieveQty", alignment: "right", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", showInGroupFooter: false, alignByColumn: true },
            //    { column: "AchieveAmt", summaryType: "sum", showInColumn: "AchieveAmt", alignment: "right", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", alignByColumn: true }
            //]
        },
    });
}
function fillProductVsTarget() {
}
function fillProductVsTargetNew() {
    var dgProductVsTarget = $("#dgProductVsTarget").dxDataGrid({
        onInitialized: function (e) { dataGrid = e.component; },
        dataSource: {
            store: {
                type: "odata",
                url: baseApiUrl + "/api/cDashboard1/ListProductwiseSalesVsTgtSummary",
                beforeSend: function (req) {
                    req.params.fromDate = GetMdyDate($("#reportrange").data('daterangepicker').startDate._d);
                    req.params.toDate = GetMdyDate($("#reportrange").data('daterangepicker').endDate._d);
                    req.params.areaId = GetCtrlIntVal($(".ddlArea"));
                    req.params.targetId = GetCtrlIntVal($(".ddlTarget"));
                    req.params.view = GetCtrlIntVal($(".ddlView"));
                    req.params.targetType = "0";// GetCtrlVal($(".ddlTargetType"));
                    req.params.targetUserId = GetCtrlIntVal($(".ddlTargetUser"));
                }
            }
        },
        onToolbarPreparing: function (e) {
            let dataGrid2 = e.component;
            e.toolbarOptions.items.unshift({ location: "after", widget: "dxButton", options: { icon: "refresh", onClick: function () { dataGrid2.refresh(); } } });
        },
        height: "300px", paging: { enabled: false }, grouping: { autoExpandAll: false, contextMenuEnabled: true },
        columns: [
            {
                caption: 'SNo',
                cellTemplate: function (container, options) { container.text(dataGrid.pageIndex() * dataGrid.pageSize() + options.rowIndex + 1); },
                dataType: "number", alignment: "center", minWidth: 5, width: "10%", allowExporting: false
            },
            {
                dataField: "GroupName", caption: "Group", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 120, width: "20%", sortIndex: 1, sortOrder: "asc", visible: false,
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); }
            },
            {
                dataField: "ProductName", caption: "Product Name", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 120, width: "30%", sortIndex: 1, sortOrder: "asc",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); }
            },
            {
                dataField: "AvailableQty", caption: "Stock",
                dataType: "number", alignment: "center", allowHeaderFiltering: true, minWidth: 90, width: "10%",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); },
            },
            {
                caption: "Target", alignment: "center", minWidth: 120, width: "30",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '14px').appendTo(header); },
                columns: [{
                    dataField: "TargetQty", caption: "Qty",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60, allowGrouping: false
                }, {
                    dataField: "TargetAmt", caption: "Amount",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60, allowGrouping: false
                }]
            },
            {
                caption: "Achievement", alignment: "center", minWidth: 120, width: "25%",
                headerCellTemplate: function (header, info) { $('<div>').html(info.column.caption).css('font-size', '16px').appendTo(header); },
                columns: [{
                    dataField: "AchieveQty", caption: "Qty",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60, allowGrouping: false
                }, {
                    dataField: "AchieveAmt", caption: "Amount",
                    dataType: "number", alignment: "center", allowHeaderFiltering: false, minWidth: 60, allowGrouping: false
                }]
            },
        ],
        onContentReady: function (e) { },
        export: { enabled: IsExport }, onExporting: function (e) { exportDxGrid(e, "TargetVsAchivement_V2", "Sheet1"); },
        summary: {
            totalItems: [
                { column: "AvailableQty", summaryType: "sum", showInColumn: "AvailableQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "TargetQty", summaryType: "sum", showInColumn: "TargetQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "TargetAmt", summaryType: "sum", showInColumn: "TargetAmt", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "AchieveQty", summaryType: "sum", showInColumn: "AchieveQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", format: { type: "decimal", precision: 2 } },
                { column: "AchieveAmt", summaryType: "sum", showInColumn: "AchieveAmt", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", alignByColumn: true, dataType: 'number', format: { type: "decimal", precision: 3 } }
                /*{ column: "AchieveAmt", summaryType: "sum", showInColumn: "AchieveAmt", alignment: "center", displayFormat: "{0}", cssClass: "text-navy font-weight-bold", alignByColumn: true, format: { type: "%",precision: 2}, dataType: 'number' }*/
            ],
            groupItems: [
                { column: "AvailableQty", summaryType: "sum", showInColumn: "AvailableQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", showInGroupFooter: false, alignByColumn: true, format: { type: "decimal", precision: 2 } },
                { column: "TargetQty", summaryType: "sum", showInColumn: "TargetQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", showInGroupFooter: false, alignByColumn: true, format: { type: "decimal", precision: 2 } },
                { column: "TargetAmt", summaryType: "sum", showInColumn: "TargetAmt", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", alignByColumn: true, format: { type: "decimal", precision: 2 } },
                { column: "AchieveQty", summaryType: "sum", showInColumn: "AchieveQty", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", showInGroupFooter: false, alignByColumn: true, format: { type: "decimal", precision: 2 } },
                { column: "AchieveAmt", summaryType: "sum", showInColumn: "AchieveAmt", alignment: "center", displayFormat: "{0}", precision: 2, cssClass: "text-navy font-weight-bold", alignByColumn: true, format: 'fixedPoint', dataType: 'number', format: { type: "decimal", precision: 2 } }
            ]
        },
    });
}
function drawAreaWiseSalesChart() {
    $.ajax({
        type: "GET",
        url: baseApiUrl + "/api/cDashboard1/ListAreawiseSalesSummary",
        data: paramData(),
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            let total = 0;
            let arrValues = [['AreaName', 'AchieveAmt']];
            $.each(res, function (index, item) {
                arrValues.push([item.AreaName, parseFloat(item.AchieveAmt)]);
                total = total + ToFloatVal(item.AchieveAmt);
            });
            $('#totalAreaWiseSales').html(total.toFixed(2));

            chartData = google.visualization.arrayToDataTable(arrValues);
            let options = {
                // title: 'Area Wise Sales',//pieHole: 0.2, sliceVisibilityThreshold: .2
                is3D: true, legend: 'none', pieSliceText: 'label', height: 250, width: '300px',
                chartArea: { left: 0, top: 0, bottom: 0, width: "300", height: "250px" }
            };
            chart = new google.visualization.PieChart(document.getElementById('chart_areawise_sale'));
            google.visualization.events.addListener(chart, 'select', areaWiseChartEvent);
            chart.draw(chartData, options);
            if (res.length > 0) { $("#btnTotalSale").removeClass("d-none"); }
            else { $("#btnTotalSale").removeClass("d-none"); }
        },
        error: function (err) { console.log(err.responseText); },
        complete: function () { }
    });
}
function areaWiseChartEvent(e) {
    let selection = chart.getSelection();
    if (selection.length) {
        let areaName = chartData.getValue(selection[0].row, 0);
        $('#hAreaName').val(areaName);
        viewAreawiseSaleForm(areaName);
    }
}
function viewAreawiseSaleForm(areaname) {
    $('#areaSaleModel').modal({ show: true });
    $("#areaSaleModel .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
    let formUrl = "child/areawiseSaleDashboardForm?";
    formUrl += "qFromDate=" + encodeURI(GetDmyDate($("#reportrange").data('daterangepicker').startDate._d));
    formUrl += "&qToDate=" + encodeURI(GetDmyDate($("#reportrange").data('daterangepicker').endDate._d));
    formUrl += "&qAreaName=" + encodeURI(areaname);
    $('#areaSaleModel .modal-body').load(formUrl, function (result) { });
    return false;
}

function drawStateWiseSalesChart() {
    $.ajax({
        type: "GET",
        url: baseApiUrl + "/api/cDashboard1/ListStateWiseSalesSummary",
        data: paramData(),
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            let total = 0;
            var arrValues = [['StateName', 'AchieveAmt']];
            $.each(res, function (index, item) {
                arrValues.push([item.StateName, parseFloat(item.AchieveAmt)]);
                total = total + ToFloatVal(item.AchieveAmt);
            });
            $('#totalStateWiseSales').html(total.toFixed(2));
            chartDataState = google.visualization.arrayToDataTable(arrValues);

            var options = {
                is3D: true, legend: 'none', pieSliceText: 'label', height: 250, width: '300px',
                chartArea: { left: 0, top: 0, bottom: 0, width: "300", height: "250px" }
            };
            chartState = new google.visualization.PieChart(document.getElementById('chart_statewise_sale'));
            google.visualization.events.addListener(chartState, 'select', stateWiseChartEvent);
            chartState.draw(chartDataState, options);
        },
        error: function (err) { console.log(err.responseText); },
        complete: function () { }
    });
}
function stateWiseChartEvent(e) {
    let selection = chartState.getSelection();
    if (selection.length) {
        let stateName = chartDataState.getValue(selection[0].row, 0);
        $('#stateWiseSaleModel').modal({ show: true });
        $("#stateWiseSaleModel .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
        let formUrl = "child/statewiseSaleDashboardForm?";
        formUrl += "qFromDate=" + encodeURI(GetDmyDate($("#reportrange").data('daterangepicker').startDate._d));
        formUrl += "&qToDate=" + encodeURI(GetDmyDate($("#reportrange").data('daterangepicker').endDate._d));
        formUrl += "&qStateName=" + encodeURI(stateName);
        $('#stateWiseSaleModel .modal-body').load(formUrl, function (result) { });
    }
}

function drawGroupWiseSalesChart() {
    $.ajax({
        type: "GET",
        url: baseApiUrl + "/api/cDashboard1/ListGroupWiseSalesSummary",
        data: paramData(),
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            let total = 0;
            var arrValues = [['GroupName', 'AchieveAmt']];
            $.each(res, function (index, item) {
                arrValues.push([item.GroupName, parseFloat(item.AchieveAmt)]);
                total = total + ToFloatVal(item.AchieveAmt);
            });
            $('#totalGroupWiseSales').html(total.toFixed(2));
            chartDataGroup = google.visualization.arrayToDataTable(arrValues);

            var options = {
                is3D: true, legend: 'none', pieSliceText: 'label', height: 250, width: '300px',
                chartArea: { left: 0, top: 0, bottom: 0, width: "300", height: "250px" }
            };
            chartGroup = new google.visualization.PieChart(document.getElementById('chart_groupwise_sale'));
            google.visualization.events.addListener(chartGroup, 'select', groupSalesChartEvent);
            chartGroup.draw(chartDataGroup, options);
        },
        error: function (err) { console.log(err.responseText); },
        complete: function () { }
    });
}
function groupSalesChartEvent(e) {
    let selection = chartGroup.getSelection();
    if (selection.length) {
        let groupName = chartDataGroup.getValue(selection[0].row, 0);
        $('#groupWiseSaleModel').modal({ show: true });
        $("#groupWiseSaleModel .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
        let formUrl = "child/groupwiseSaleDashboardForm?";
        formUrl += "qFromDate=" + encodeURI(GetDmyDate($("#reportrange").data('daterangepicker').startDate._d));
        formUrl += "&qToDate=" + encodeURI(GetDmyDate($("#reportrange").data('daterangepicker').endDate._d));
        formUrl += "&qGroupName=" + encodeURI(groupName);
        $('#groupWiseSaleModel .modal-body').load(formUrl, function (result) { });
    }
}

function searchSerialNo(e) {
    var dgSerialHistory = $("#dgSerialHistory").dxDataGrid({
        onInitialized: function (e) { dataGrid55 = e.component; },
        dataSource: {
            store: {
                type: "odata",
                url: baseApiUrl + "/api/cDashboard1/ListSerialNoHistory",
                beforeSend: function (req) {
                    req.params.serialNo = $.trim($(e).val());
                }
            }
        },
        onToolbarPreparing: function (e) {
            let dataGrid = e.component;
            e.toolbarOptions.items.unshift({ location: "after", widget: "dxButton", options: { icon: "refresh", onClick: function () { dataGrid.refresh(); } } });
        },
        height: "300px", paging: { enabled: false }, grouping: { autoExpandAll: false, contextMenuEnabled: true },
        columns: [
            {
                caption: 'SNo',
                cellTemplate: function (container, options) { container.text(dataGrid2.pageIndex() * dataGrid55.pageSize() + options.rowIndex + 1); },
                dataType: "number", alignment: "center", minWidth: 60, width: "5%", allowExporting: false, allowExporting: false
            },
            { dataField: "TranType", caption: "Type", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 80, width: "10%" },
            { dataField: "ProductName", caption: "Product", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 120, width: "25%" },
            { dataField: "PartyName", caption: "Party", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "20%" },
            { dataField: "OrderId", caption: "Order Id", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 90, width: "15%" },
            { dataField: "Date", caption: "Date", dataType: "date", dataFormat: 'dd/MM/yyyy', alignment: "center", allowHeaderFiltering: true, minWidth: 80, width: "10%" },
            { dataField: "BranchName", caption: "Branch", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 110, width: "10%" },
            /*{ dataField: "ServiceBranch", caption: "ServiceBranch", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 80, width: "10%", sortIndex: 1, sortOrder: "asc",visible:"false" },*/
        ],
        onContentReady: function (e) { },
        columnFixing: { enabled: true }, export: { enabled: false }, export: { enabled: IsExport }, onExporting: function (e) { exportDxGrid(e, "SerialNoHistory", "Sheet1"); }
    });
}
function blink_text() {
    //$('.blink-text').fadeOut(2000);
    //$('.blink-text').fadeIn(2000);
    //$('#dashboardTitle').toggleClass('text-danger', 500);
}