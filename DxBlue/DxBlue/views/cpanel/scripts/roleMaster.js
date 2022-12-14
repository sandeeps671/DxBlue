var IsAdd = false, IsEdit = false, IsDelete = false, IsRestore = false, IsExport = false;
$(document).ready(function () {
    $(".select2").select2();
    $(".ddlSource").on("change", function () { mainGrid.dxDataGrid("instance").refresh(); });
    IsAdd = GetBoolValue($(".hIsAdd")); IsEdit = GetBoolValue($(".hIsEdit")); IsDelete = GetBoolValue($(".hIsDelete"));
    IsRestore = GetBoolValue($(".hIsRestore")); IsExport = GetBoolValue($(".hIsExport"));
    if (!IsAdd) HideCtrl($("#btnAdd"));
    let dataGrid;
    mainGrid = $("#mainGrid").dxDataGrid({
        onInitialized: function (e) { dataGrid = e.component; },
        dataSource: {
            store: {
                type: "odata",
                url: baseApiUrl + "/api/cRole/ListAllRole",
                beforeSend: function (request) {
                    request.params.SourceId = GetCtrlIntVal($(".ddlSource"));
                }
            }
        },
        onToolbarPreparing: function (e) {
            let dataGrid = e.component;
            e.toolbarOptions.items.unshift(
                {
                    location: "before",
                    template: function () {
                        if (IsAdd) return "<button id='btnAdd' class='btn btn-success btn-xs' onclick=\"return loadRoleForm(0,1)\">Add New</button>";
                        return "";
                    }
                },
                { location: "after", widget: "dxButton", options: { icon: "refresh", onClick: function () { dataGrid.refresh(); } } }
            );
        },
        columns: [
            {
                caption: 'Action', fixed: true, fixedPosition: "left", allowFixing: false,
                cellTemplate: function (cElement, cInfo) {
                    let data = cInfo.row.data;
                    let ctrl = "";
                    if (data.IsActive && IsDelete) {
                        ctrl += "<a title='Delete' onclick=\"return deleteRole(" + data.RoleId + ")\" href='javascript:return(0)'><i class='fas fa-trash-alt fa-lg p-1 text-danger'></i></a>";
                    }

                    if (data.IsActive && IsEdit) {
                        ctrl += "<a title=\"Edit\" onclick=\"return loadRoleForm(" + data.RoleId + ",1)\" href='javascript:return(0)'> <i class='fas fa-edit fa-lg p-1 text-info'></i></a>";
                    }
                    else if (!data.IsActive && IsRestore) {
                        ctrl += "<a title='Restore' onclick=\"return restoreRole(" + data.RoleId + ")\" href='javascript:return(0)'><i class='fa fa-undo fa-lg p-1 text-danger'></i></a>";
                        ctrl += "<a title=\"View\" onclick=\"return loadRoleForm(" + data.RoleId + ",0)\" href='javascript:return(0)'> <i class='fa fa-eye fa-lg p-1 text-navy'></i></a>";
                    }
                    else {
                        ctrl += "<a title=\"View\" onclick=\"return loadRoleForm(" + data.RoleId + ",0)\" class='btn btn-xs text-navy'> <i class='fa fa-eye'></i></a>";
                    }
                    cElement.html(ctrl);
                },
                alignment: "center", minWidth: 100, width: "15%"
            },
            {
                caption: 'SNo',
                cellTemplate: function (container, options) { container.text(dataGrid.pageIndex() * dataGrid.pageSize() + options.rowIndex + 1); },
                dataType: "number", alignment: "center", minWidth: 60, width: "10%"
            },
            { dataField: "RoleCode", caption: "RoleCode", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "15%" },
            { dataField: "RoleName", caption: "Role Name", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 130, width: "25%" },
            { dataField: "HomePage", caption: "Home Page", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "20%" },
            {
                dataField: "Status", caption: "Status", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 80, width: "10%",
                cellTemplate: function (cElement, cInfo) {
                    let data = cInfo.row.data;
                    let ctrl = "";
                    if (data.IsActive) ctrl = "<span class='badge badge-success'>Active</span>";
                    else ctrl = "<span class='badge badge-danger'>Disabled</span>";
                    cElement.html(ctrl);
                }
            }
        ],
        onContentReady: function (e) { //if (!collapsed) {//    collapsed = true;//    e.component.expandRow(["EnviroCare"]);//}
        }
    });
});
function loadRoleForm(roleId, action) {
    let sourceId = GetCtrlIntVal($(".ddlSource"));
    let pageUrl = "child/roleForm?qRoleId=" + roleId + "&qAction=" + action + "&qSourceId=" + sourceId;
    $('#roleModal').modal({ show: true, backdrop: 'static', keyboard: true, focus: true });
    $("#roleModal .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
    $('#roleModal .modal-body').load(pageUrl, function (res) { });
    return false;
}

function deleteRole(roleId) {
    $.confirm({
        escapeKey: true, backgroundDismiss: true, theme: 'material', type: 'red',
        title: 'Delete', content: 'Are you sure to delete this record?',
        buttons: {
            confirm: {
                text: 'DELETE', btnClass: 'btn-red', keys: ['enter', 'y'],
                action: function () {
                    let model = {};
                    model.RoleId = roleId;
                    $.ajax({
                        type: "POST",
                        url: baseApiUrl + "/api/cRole/DeleteRole",
                        data: JSON.stringify(model),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (res) {
                            if (res.IsValid) {
                                toastr.success(res.Msg);
                                $("#mainGrid").dxDataGrid("instance").refresh();
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
function restoreRole(roleId) {
    $.confirm({
        escapeKey: true, backgroundDismiss: true, theme: 'material', type: 'green',
        title: 'Restore', content: 'Are you sure to restore this record?',
        buttons: {
            confirm: {
                text: 'RESTORE', btnClass: 'btn-green', keys: ['enter', 'y'],
                action: function () {
                    let model = {};
                    model.RoleId = roleId;
                    $.ajax({
                        type: "POST",
                        url: baseApiUrl + "/api/cRole/restoreRole",
                        data: JSON.stringify(model),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (res) {
                            if (res.IsValid) {
                                toastr.success(res.Msg);
                                $("#mainGrid").dxDataGrid("instance").refresh();
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
