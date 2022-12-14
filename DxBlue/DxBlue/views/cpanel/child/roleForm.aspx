<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roleForm.aspx.cs" Inherits="DxBlue.cons.views.cpanel.child.roleForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server" class="">
        <div class="form-horizontal">
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Role Code<span class="text-danger">*</span></label>
                <div class="col-sm-4">
                    <input type="hidden" id="hRoleId" name="hRoleId" class="hRoleId" value="0" runat="server" />
                    <input type="hidden" id="hAction" name="hAction" class="hAction" value="0" runat="server" />
                    <input type="hidden" id="hSourceId" name="hSourceId" class="hAction" value="0" runat="server" />
                    <input id="txtRoleCode" type="text" class="form-control form-control-sm txtRoleCode" value="" autocomplete="off" maxlength="15" runat="server" />
                </div>
                <label class="col-sm-2 col-form-label">Role Name<span class="text-danger">*</span></label>
                <div class="col-sm-4">
                    <input id="txtRoleName" type="text" class="form-control form-control-sm txtRoleName" value="" autocomplete="off" maxlength="50" runat="server" />
                </div>
                <label class="col-sm-2 col-form-label">Home Page<span class="text-danger">*</span></label>
                <div class="col-sm-10">
                    <select id="ddlHomePage" class="form-control form-control-sm select3 ddlHomePage" runat="server"></select>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <button type="submit" class="btn bg-gradient-primary ladda-button" data-style="zoom-in" id="btnSubmitChild">Save Changes</button>
            <button type="reset" class="btn btn-default" id="btnCancel" data-dismiss="modal">Cancel</button>
        </div>
    </form>
    <script>
        $(document).ready(function () {
            if (GetCtrlIntVal($("#hAction")) == 0) {
                $("#roleModal input, #roleModal textarea, #roleModal select").prop("disabled", true);
                HideCtrl($("#btnSubmitChild"));
            }
            $("select.select3").select2();
        });
        $("#btnSubmitChild").click(function (e) {
            e.preventDefault();
            let l = Ladda.create(document.querySelector('#btnSubmitChild')); l.start();
            let submit = true;
            let _model = {};

            _model.RoleId = GetCtrlIntVal($("#hRoleId"));
            _model.RoleCode = GetCtrlVal($("#txtRoleCode"));
            _model.RoleName = GetCtrlVal($("#txtRoleName"));
            _model.HomePageId = GetCtrlIntVal($("#ddlHomePage"));
            _model.SourceId = GetCtrlIntVal($("#hSourceId"));

            if (_model.RoleCode == "") { toastr.error("Please enter code"); l.stop(); FocusCtrl($("#txtRoleCode")); submit = false; return false; }
            if (_model.RoleName == "") { toastr.error("Please enter role name"); l.stop(); FocusCtrl($("#txtRoleName")); submit = false; return false; }
            if (_model.HomePageId == 0) { toastr.error("Please select home page"); l.stop(); FocusSelect2($("#ddlHomePage")); submit = false; return false; }
            if (!submit) return false;
            $.ajax({
                type: "POST",
                url: baseApiUrl + "/api/cRole/SubmitRole",
                data: JSON.stringify(_model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    if (res.IsValid) {
                        toastr.success(res.Msg);
                        $("#roleModal").modal("hide");
                        $("#mainGrid").dxDataGrid("instance").refresh();
                    }
                    else {
                        toastr.error(res.Msg);
                    }
                },
                error: function (err) { toastr.error(err.responseText); },
                complete: function (res) { l.stop(); }
            });
            return false;
        });
    </script>

</body>
</html>
