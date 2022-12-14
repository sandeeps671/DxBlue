var IsAdd = false, IsEdit = false, IsDelete = false, IsRestore = false, IsExport = false;
$(document).ready(function () {
    IsAdd = GetBoolValue($(".hIsAdd")); IsEdit = GetBoolValue($(".hIsEdit")); IsDelete = GetBoolValue($(".hIsDelete"));
    IsRestore = GetBoolValue($(".hIsRestore")); IsExport = GetBoolValue($(".hIsExport"));
    if (!IsAdd) HideCtrl($("#btnAdd"));
    let dataGrid;
    mainGrid = $("#mainGrid").dxDataGrid({
        onInitialized: function (e) { dataGrid = e.component; },
        dataSource: {
            store: {
                type: "odata",
                url: baseApiUrl + "/api/cArea/ListAreas",
                beforeSend: function (request) { }
            }
        },
        onToolbarPreparing: function (e) {
            let dataGrid = e.component;
            e.toolbarOptions.items.unshift(
                {
                    location: "before",
                    template: function () {
                        if (IsAdd) return "<button id='btnAdd' class='btn btn-success btn-xs' onclick=\"return loadAreaForm(0,1)\">Add New</button>";
                        return "";
                    }
                },
                { location: "after", widget: "dxButton", options: { icon: "refresh", onClick: function () { dataGrid.refresh(); } } }
            );
        },
        columns: [
            {
                dataField: "Action", caption: 'Action', fixed: false, fixedPosition: "left", allowFixing: false,
                alignment: "center", minWidth: 80, width: "5%", allowExporting: false, allowHeaderFiltering: false
            },
            { dataField: "SNo", caption: 'SNo', dataType: "number", alignment: "center", minWidth: 60, width: "5%", allowExporting: false, allowHeaderFiltering: false },
            { dataField: "AreaName", caption: "Area", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "15%" },
            { dataField: "EmailId", caption: "Email Id", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 130, width: "20%" },
            { dataField: "SrEmailId", caption: "Sr Email Id", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 130, width: "20%" },
            { dataField: "GstNo", caption: "GST No", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 90, width: "15%" },
            { dataField: "GodownStatus", caption: "Godown", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 90, width: "10%" },
            {
                dataField: "IsActive", caption: "Status", dataType: "boolean", alignment: "center", allowHeaderFiltering: true, minWidth: 100, width: "10%",
                trueText: 'Active', falseText: "Disabled"//, showEditorAlways: false
                //cellTemplate: function (cElement, cInfo) {
                //    let data = cInfo.row.data;
                //    let ctrl = "";
                //    if (data.IsActive) ctrl = "<span class='badge badge-success'>Active</span>";
                //    else ctrl = "<span class='badge badge-danger'>Disabled</span>";
                //    cElement.html(ctrl);
                //}
            }
        ],
        onCellPrepared: function (e) {
            switch (e.rowType) {
                case "data":
                    let data = e.data;
                    switch (e.column.dataField) {
                        case "Action":
                            let ctrl = ""
                            if (data.IsActive && IsDelete) {
                                ctrl += "<a title='Delete' onclick=\"return deleteArea(" + data + ")\" href='javascript:void(0)'><i class='fas fa-trash-alt fa-lg p-1 text-danger'></i></a>";
                            }

                            if (data.IsActive && IsEdit) {
                                ctrl += "<a title=\"Edit\" onclick=\"return loadAreaForm(" + data + ",1)\" href='javascript:void(0)'> <i class='fas fa-edit fa-lg p-1 text-info'></i></a>";
                            }
                            else if (!data.IsActive && IsRestore) {
                                ctrl += "<a title='Restore' onclick=\"return restoreArea(" + data + ")\" href='javascript:void(0)'><i class='fa fa-undo fa-lg p-1 text-warning'></i></a>";
                                ctrl += "<a title=\"View\" onclick=\"return loadAreaForm(" + data + ",0)\" href='javascript:void(0)'> <i class='fa fa-eye fa-lg p-1 text-navy'></i></a>";
                            }
                            else {
                                ctrl += "<a title=\"View\" onclick=\"return loadAreaForm(" + data + ",0)\" class='btn btn-xs text-navy'> <i class='fa fa-eye'></i></a>";
                            }
                            e.cellElement.html(ctrl);
                            break;
                        case "SNo":
                            e.cellElement.text(dataGrid.pageIndex() * dataGrid.pageSize() + e.rowIndex + 1);
                            break;
                    }
                    break;
            }
        },
        onContentReady: function (e) { },  //if (!collapsed) {//    collapsed = true;//    e.component.expandRow(["EnviroCare"]);//}
        export: { enabled: IsExport }, onExporting: function (e) { exportDxGrid(e, "AreaList", "Sheet1"); },

    });
});
function loadAreaForm(data, action) {
    let areaId = 0;
    let pageUrl = "child/areaForm?qAreaId=" + areaId + "&qAction=" + action;
    $('#areaModal').modal({ show: true, backdrop: 'static', keyboard: true, focus: true });
    $("#areaModal .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
    $('#areaModal .modal-body').load(pageUrl, function (res) { });
    return false;
}

function deleteArea(data) {
    let areaId = 0;
    $.confirm({
        escapeKey: true, backgroundDismiss: true, theme: 'material', type: 'red',
        title: 'Delete', content: 'Are you sure to delete this area?',
        buttons: {
            confirm: {
                text: 'DELETE', btnClass: 'btn-red', keys: ['enter', 'y'],
                action: function () {
                    let model = {};
                    model.AreaId = areaId;
                    $.ajax({
                        type: "POST",
                        url: baseApiUrl + "/api/cArea/DeleteArea",
                        data: JSON.stringify(model),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (res) {
                            if (res.IsValid) {
                                toastr.success(res.Msg);
                                $("#mainGrid").dxDataGrid("instance").refresh();
                                pushUserLocationAction("AREA MASTER", "DELETE", areaId);
                            }
                            else { toastr.error(res.Msg); }
                        },
                        error: function (err) { toastr.error(err.responseText); },
                        complete: function (res) { }
                    });
                }
            },
            cancel: { text: 'Cancel', btnClass: 'btn-default', }
        }
    });
    return false;
}
function restoreArea(data) {
    let areaId = 0;
    $.confirm({
        escapeKey: true, backgroundDismiss: true, theme: 'material', type: 'green',
        title: 'Restore', content: 'Are you sure to restore this area?',
        buttons: {
            confirm: {
                text: 'RESTORE', btnClass: 'btn-green', keys: ['enter', 'y'],
                action: function () {
                    let model = {};
                    model.AreaId = areaId;
                    $.ajax({
                        type: "POST",
                        url: baseApiUrl + "/api/cArea/RestoreArea",
                        data: JSON.stringify(model),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (res) {
                            if (res.IsValid) {
                                toastr.success(res.Msg);
                                $("#mainGrid").dxDataGrid("instance").refresh();
                                pushUserLocationAction("AREA MASTER", "RESTORE", areaId);
                            }
                            else { toastr.error(res.Msg); }
                        },
                        error: function (err) { toastr.error(err.responseText); },
                        complete: function (res) { }
                    });
                }
            },
            cancel: { text: 'Cancel', btnClass: 'btn-default', }
        }
    });
    return false;
}