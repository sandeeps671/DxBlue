var IsAdd = false, IsEdit = false, IsDelete = false, IsRestore = false, IsExport = false;
$(document).ready(function () {
    $(".select2").select2();
    IsAdd = GetBoolValue($(".hIsAdd")); IsEdit = GetBoolValue($(".hIsEdit")); IsDelete = GetBoolValue($(".hIsDelete"));
    IsRestore = GetBoolValue($(".hIsRestore")); IsExport = GetBoolValue($(".hIsExport"));
    if (!IsAdd) HideCtrl($("#btnAdd"));
    $(".ddlSource").on("change", function () {
        if (GetCtrlIntVal($(".ddlSource")) != 0) { HideCtrl($("#btnAdd")); } else { if (IsAdd) ShowCtrl($("#btnAdd")); else HideCtrl($("#btnAdd")); }
        mainGrid.dxDataGrid("instance").refresh();
    });
    let dataGrid;
    mainGrid = $("#mainGrid").dxDataGrid({
        onInitialized: function (e) { dataGrid = e.component; },
        dataSource: {
            store: {
                type: "odata",
                url: baseApiUrl + "/api/cUser/ListAllUser",
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
                        if (IsAdd) return "<button id='btnAdd' class='btn btn-success btn-xs' onclick=\"return loadUserForm(0,1)\">Add New</button>";
                        return "";
                    }
                },
                { location: "after", widget: "dxButton", options: { icon: "refresh", onClick: function () { dataGrid.refresh(); } } }
            );
        },
        columns: [
            {
                caption: 'Action', fixed: false, fixedPosition: "left", allowFixing: true,
                cellTemplate: function (cElement, cInfo) {
                    let data = cInfo.row.data;
                    let ctrl = "";
                    if (!data.Disable && IsDelete) {
                        ctrl += "<a title='Delete' onclick=\"return deleteUser(" + data.UserId + ")\" href='javscript:void(0)'><i class='fas fa-trash-alt fa-lg p-1 text-danger'></i></a>";
                    }
                    if (!data.Disable && IsEdit) {
                        ctrl += "<a title=\"Edit\" onclick=\"return loadUserForm(" + data.UserId + ",1)\" href='javscript:void(0)'> <i class='fas fa-edit fa-lg p-1 text-info'></i></a>";
                    }
                    else if (data.Disable && IsRestore) {
                        ctrl += "<a title='Restore' onclick=\"return restoreUser(" + data.UserId + ")\" href='javscript:void(0)'><i class='fa fa-undo fa-lg p-1 text-danger'></i></a>";
                        ctrl += "<a title=\"View\" onclick=\"return loadUserForm(" + data.UserId + ",0)\" href='javscript:void(0)'> <i class='fa fa-eye fa-lg p-1 text-navy'></i></a>";
                    }
                    else {
                        ctrl += "<a title=\"View\" onclick=\"return loadUserForm(" + data.UserId + ",0)\" href='javscript:void(0)'> <i class='fa fa-eye fa-lg p-1 text-navy'></i></a>";
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
            { dataField: "UserName", caption: "User Name", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "15%" },
            { dataField: "FullName", caption: "Full Name", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 130, width: "20%" },
            { dataField: "UserType", caption: "UserType", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 100, width: "15%" },
            { dataField: "ContactNo", caption: "Contact No", dataType: "string", alignment: "left", allowHeaderFiltering: true, minWidth: 100, width: "15%" },
            {
                caption: "Manager", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 110, width: "20%",
                cellTemplate: function (cElement, cInfo) {
                    let data = cInfo.row.data;
                    let ctrl = "";
                    if (data.UserManagers != null) { $.each(data.UserManagers, function (i, row) { ctrl += "<span class='badge badge-info p-1 mr-2'>" + row.ManagerName + "</span>"; }); }
                    cElement.html(ctrl);
                }
            },
            {
                caption: "Area", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 110, width: "20%",
                cellTemplate: function (cElement, cInfo) {
                    let data = cInfo.row.data;
                    let ctrl = "";
                    if (data.UserAreas != null) { $.each(data.UserAreas, function (i, row) { ctrl += "<span class='badge badge-info p-1 mr-2'>" + row.AreaName + "</span>"; }); }
                    cElement.html(ctrl);
                }
            },
            {
                dataField: "Status", caption: "Status", dataType: "string", alignment: "center", allowHeaderFiltering: true, minWidth: 80, width: "10%",
                cellTemplate: function (cElement, cInfo) {
                    let data = cInfo.row.data;
                    let ctrl = "";
                    if (!data.Disable) ctrl = "<span class='badge badge-success'>Active</span>";
                    else ctrl = "<span class='badge badge-danger'>Disabled</span>";
                    cElement.html(ctrl);
                }
            }
        ],
        onContentReady: function (e) { //if (!collapsed) {//    collapsed = true;//    e.component.expandRow(["EnviroCare"]);//}
        }
    });
});
function loadUserForm(userId, action) {
    let sourceId = GetCtrlIntVal($(".ddlSource"));
    let pageUrl = "child/userForm?ts=" + moment().unix() + "&qUserId=" + userId + "&qAction=" + action + "&qSourceId=" + sourceId;
    $('#userModal').modal({ show: true, backdrop: 'static', keyboard: true, focus: true });
    $("#userModal .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
    $('#userModal .modal-body').load(pageUrl, function (res) { });
    return false;
}

function deleteUser(userId) {
    $.confirm({
        escapeKey: true, backgroundDismiss: true, theme: 'material', type: 'red',
        title: 'Delete', content: 'Are you sure to delete this record?',
        buttons: {
            confirm: {
                text: 'DELETE', btnClass: 'btn-red', keys: ['enter', 'y'],
                action: function () {
                    let model = {};
                    model.UserId = userId;
                    $.ajax({
                        type: "POST",
                        url: baseApiUrl + "/api/cUser/DeleteUser",
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
function restoreUser(userId) {
    $.confirm({
        escapeKey: true, backgroundDismiss: true, theme: 'material', type: 'green',
        title: 'Restore', content: 'Are you sure to restore this record?',
        buttons: {
            confirm: {
                text: 'RESTORE', btnClass: 'btn-green', keys: ['enter', 'y'],
                action: function () {
                    let model = {};
                    model.UserId = userId;
                    $.ajax({
                        type: "POST",
                        url: baseApiUrl + "/api/cUser/RestoreUser",
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