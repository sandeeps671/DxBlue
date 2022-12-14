$(document).ready(function () {
    var isAdd = GetBoolValue($(".hAdd"));
    var isEdit = GetBoolValue($(".hEdit"));
    var isDelete = GetBoolValue($(".hDelete"));
    $(".select2").select2();
    $('.datepicker').daterangepicker({}, function (start, end, label) { mainGrid.dxDataGrid("instance").refresh(); });
    $("#ddlView").on("change", function () { mainGrid.dxDataGrid("instance").refresh(); });
    let dataGrid;
    mainGrid = $("#mainGrid").dxDataGrid({
        onInitialized: function (e) { dataGrid = e.component; },
        dataSource: {
            store: {
                type: "odata",
                url: baseApiUrl + "/api/cLogistic/ListLogistic",
                beforeSend: function (request) {
                    request.params.fromDate = GetMdyDate($("#txtPeriod").data('daterangepicker').startDate._d);
                    request.params.toDate = GetMdyDate($("#txtPeriod").data('daterangepicker').endDate._d);
                }
            }
        },
        onToolbarPreparing: function (e) {
            let dataGrid = e.component;
            e.toolbarOptions.items.unshift(
                { location: "after", widget: "dxButton", options: { icon: "refresh", onClick: function () { dataGrid.refresh(); } } });
        },
        columns: [
            {
                caption: 'Action', fixed: false, fixedPosition: "left", allowFixing: true,
                cellTemplate: function (cElement, cInfo) {
                    let data = cInfo.row.data;
                    let ctrl = "";
                    if (data.IsAdjusted || (!isEdit)) {
                        ctrl = "<a title=\"View\" onclick=\"return loadLogisticForm(" + data.DsrId + ",0);\" href='javascript:void(0)'> <i class='fa fa-eye fa-lg p-1 text-navy'></i></a>";
                    }
                    else {
                        ctrl = "<a title=\"View/Edit\" onclick=\"return loadLogisticForm(" + data.DsrId + ",1);\" href='javascript:void(0)'> <i class='fas fa-edit fa-lg p-1 text-warning'></i></a>";
                    }
                    cElement.html(ctrl);
                },
                alignment: "center", minWidth: 80, width: "auto", allowExporting: false
            },
            {
                caption: 'SNo',
                cellTemplate: function (container, options) { container.text(dataGrid.pageIndex() * dataGrid.pageSize() + options.rowIndex + 1); },
                dataType: "number", alignment: "center", minWidth: 60, width: "5%", allowExporting: false
            },
            { dataField: "AreaName", caption: "Area", dataType: "string", alignment: "left", minWidth: 80 },
            { dataField: "OrderDate", caption: "Order Date", dataType: "date", format: 'dd/MM/yyyy', alignment: "center", minWidth: 80 },
            { dataField: "OrderId", caption: "Order Id", dataType: "string", alignment: "center", minWidth: 100 },
            { dataField: "PartyName", caption: "PartyName", dataType: "string", alignment: "left", minWidth: 130 },
            { dataField: "OrderAmt", caption: "Amount", dataType: "number", alignment: "right", minWidth: 80 },
            { dataField: "LogisticStatus", caption: "Status", dataType: "number", alignment: "center", minWidth: 80, filterValues: ['Pending'] }
        ],
        onContentReady: function (e) { },
        onExporting: function (e) { exportDxGrid(e, "AdvancePayments", "Sheet1"); }
    });
});
function loadLogisticForm(dsrId, action) {
    let pageUrl = "child/logisticForm?qDsrId=" + dsrId + "&qAction=" + action;
    $('#logisticModal').modal({ show: true, backdrop: 'static', keyboard: true, focus: true });
    $("#logisticModal .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
    $('#logisticModal .modal-body').load(pageUrl, function (res) { });
    return false;
}
