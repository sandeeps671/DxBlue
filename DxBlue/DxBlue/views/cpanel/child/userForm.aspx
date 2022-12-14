<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userForm.aspx.cs" Inherits="DxBlue.cons.views.cpanel.child.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formUser" runat="server">
        <div class="form-horizontal">
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">User Name<span class="text-danger">*</span></label>
                <div class="col-sm-4">
                    <input type="hidden" id="hUserId" name="hUserId" class="hUserId" value="0" runat="server" />
                    <input type="hidden" id="hAction" name="hAction" class="hAction" value="0" runat="server" />
                    <input type="hidden" id="hSourceId" name="hAction" class="hSourceId" value="0" runat="server" />
                    <input id="txtUserName" type="text" class="form-control form-control-sm txtUserName" value="" autocomplete="off" maxlength="15" runat="server" />
                </div>
                <label class="col-sm-2 col-form-label">Password<span class="text-danger">*</span></label>
                <div class="col-sm-4">
                    <input id="txtPassword" type="password" class="form-control form-control-sm txtPassword" value="" autocomplete="off" maxlength="50" runat="server" aria-autocomplete="none" />
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">First Name<span class="text-danger">*</span></label>
                <div class="col-sm-4">
                    <input id="txtFirstname" type="text" class="form-control form-control-sm txtFirstname" value="" autocomplete="off" maxlength="50" runat="server" />
                </div>
                <label class="col-sm-2 col-form-label">Last Name</label>
                <div class="col-sm-4">
                    <input id="txtLastName" type="text" class="form-control form-control-sm txtLastName" value="" autocomplete="off" maxlength="50" runat="server" />
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-1 col-form-label">Mobile<span class="text-danger">*</span></label>
                <div class="col-sm-2">
                    <input id="txtMobileNo" type="text" class="form-control form-control-sm txtMobileNo" value="" autocomplete="off" maxlength="10" runat="server" />
                </div>
                <label class="col-sm-2 col-form-label">User Type<span class="text-danger">*</span></label>
                <div class="col-sm-3">
                    <select id="ddlUserType" class="form-control form-control-sm select3 ddlUserType" runat="server"></select>
                </div>
                <label class="col-sm-1 col-form-label">Platform<span class="text-danger">*</span></label>
                <div class="col-sm-3">
                    <select id="ddlPlatform" class="form-control form-control-sm select3 ddlPlatform" runat="server" multiple="true">
                        <option value="Web">Web</option>
                        <option value="App">App</option>
                    </select>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Manager<span class="text-danger">*</span></label>
                <div class="col-sm-10">
                    <select id="ddlManager" class="form-control form-control-sm select3 ddlManager" runat="server" multiple="true"></select>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Area<span class="text-danger">*</span></label>
                <div class="col-sm-10">
                    <select id="ddlArea" class="form-control form-control-sm select3 ddlArea" runat="server" multiple="true"></select>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-2 col-form-label">Role<span class="text-danger">*</span></label>
                <div class="col-sm-10">
                    <select id="ddlRole" class="form-control form-control-sm select3 ddlRole" runat="server"></select>
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-2"></div>
                <div class="col-sm-10">
                    <div class="custom-control custom-checkbox custom-control-inline">
                        <input id="chkDsrAccountStatus" type="checkbox" name="chkDsrAccountStatus" class="custom-control-input" runat="server" />
                        <label for="chkDsrAccountStatus" class="custom-control-label text-sm">Use for DSR account status</label>
                    </div>
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

            SetMaskMobileNo($(".txtMobileNo"));
            if (GetCtrlIntVal($("#hAction")) == 0) {
                $("#userModal input, #userModal textarea, #userModal select").prop("disabled", true);
                HideCtrl($("#btnSubmitChild"));
            }
            $("select.select3").select2();
        });
        $("#btnSubmitChild").click(function (e) {
            e.preventDefault();
            let l = Ladda.create(document.querySelector('#btnSubmitChild')); l.start();
            let submit = true;
            let model = {};
            model.UserId = GetCtrlIntVal($("#hUserId"));
            model.UserName = GetCtrlVal($("#txtUserName"));
            model.Password = GetCtrlVal($("#txtPassword"));
            model.FirstName = GetCtrlVal($("#txtFirstname"));
            model.LastName = GetCtrlVal($("#txtLastName"));
            model.ContactNo = GetCtrlVal($("#txtMobileNo"));
            model.UserType = GetCtrlVal($("#ddlUserType"));
            model.Platform = GetCtrlVal($("#ddlPlatform"));

            model.Managers = GetCtrlVal($("#ddlManager")).split(',');
            model.Areas = GetCtrlVal($("#ddlArea")).split(',');

            model.Roles = GetCtrlVal($("#ddlRole")).split(',');
            model.IsDsrAccountStatus = GetCheckBoxState($("#chkDsrAccountStatus"));

            if (model.UserName == "") { toastr.error("Please enter username"); l.stop(); FocusCtrl($("#txtUserName")); submit = false; return false; }
            else if (model.Password == "" && model.UserId == 0) { toastr.error("Please enter password"); l.stop(); FocusCtrl($("#txtPassword")); submit = false; return false; }
            else if (model.FirstName == "") { toastr.error("Please enter first name"); l.stop(); FocusCtrl($("#FirstName")); submit = false; return false; }
            else if (model.ContactNo == "") { toastr.error("Please enter mobile number"); l.stop(); FocusCtrl($("#txtMobileNo")); submit = false; return false; }
            else if (model.ContactNo.length == 0) { toastr.error("Please enter 10 digit mobile number"); l.stop(); FocusCtrl($("#txtMobileNo")); submit = false; return false; }

            else if (model.UserType == 0) { toastr.error("Please select user type"); l.stop(); FocusSelect2($("#ddlUserType")); submit = false; return false; }
            else if ($("#ddlPlatform").val().length == 0) { toastr.error("Please select platform"); l.stop(); FocusSelect2($("#ddlPlatform")); submit = false; return false; }
            else if (($("#ddlManager").val().length == 0 || model.Managers[0] == '') && model.UserType != "ADMIN") { toastr.error("Please select manager"); l.stop(); FocusSelect2($("#ddlManager")); submit = false; return false; }
            else if ($("#ddlArea").val().length == 0) { toastr.error("Please select atleast one area"); l.stop(); FocusSelect2($("#ddlArea")); submit = false; return false; }
            else if (GetCtrlVal($("#ddlRole")) == '0') { toastr.error("Please select role"); l.stop(); FocusSelect2($("#ddlRole")); submit = false; return false; }
            
            if (!submit) return false;

            $.ajax({
                type: "POST",
                url: baseApiUrl + "/api/cUser/SubmitUser",
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    if (res.IsValid) {
                        toastr.success(res.Msg);
                        $("#userModal").modal("hide");
                        $("#mainGrid").dxDataGrid("instance").refresh();
                    }
                    else { toastr.error(res.Msg); }
                },
                error: function (err) { toastr.error(err.responseText); },
                complete: function (res) { l.stop(); }
            });
            return false;
        });
    </script>
</body>
</html>
