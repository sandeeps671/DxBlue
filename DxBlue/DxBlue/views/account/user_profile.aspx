<%@ Page Title="User Profile" Language="C#" MasterPageFile="~/views/root/Site1.Master" AutoEventWireup="true" CodeBehind="user_profile.aspx.cs" Inherits="DxBlue.views.account.user_profile" %>

<%@ Import Namespace="DxBlue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <input type="hidden" id="hIsAdd" runat="server" value="0" />
    <input type="hidden" id="hIsEdit" runat="server" value="0" />
    <input type="hidden" id="hIsDelete" runat="server" value="0" />
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h5>My Profile</h5>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="<%=CGlobal.GoToHome() %>">Home</a></li>
                        <li class="breadcrumb-item active">My Profile</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-5">
                    <!-- Profile Image -->
                    <div class="card card-primary card-outline">
                        <div class="card-body box-profile">
                            <%--<form class="" id="form-profile">
                                <div class="text-center">
                                    <label class="control-label">
                                        Avatar *(.jpg Height:85px;Width:190px)</label>
                                    <div class="col-sm-12">
                                        <div class="fileupload fileupload-new" data-provides="fileupload">
                                            <img id="img_profile" style="width: 120px; height: 120px"
                                                src="<%= profilePic + "?ts="+DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() %>" />
                                            <div class="fileupload-preview fileupload-exists thumbnail" style="width: 50px; height: 50px;">
                                            </div>
                                            <span class="btn btn-file"><span class="fileupload-new">Change Image </span><span
                                                class="fileupload-exists"></span>
                                                <input type="file" id="txtPicture" />
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </form>
                            <br />
                            <br />--%>
                        <div class="form-horizontal">
                            <div class="form-group row">
                                <label for="txtCurrentPassword" class="col-sm-4 col-form-label">Display Name</label>
                                <div class="col-sm-8">
                                    <input type="text" class="form-control form-control-sm" id="txtDisplayName" placeholder="" autocomplete="off" runat="server" disabled="disabled">
                                </div>
                            </div>
                            <div class="form-group row">
                                <label for="txtContactNo" class="col-sm-4 col-form-label">Contact No</label>
                                <div class="col-sm-8">
                                    <input type="text" class="form-control form-control-sm" id="txtContactNo" placeholder="" autocomplete="off" runat="server" disabled="disabled">
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="offset-sm-4 col-sm-10">
                                    <%--<button type="button" class="btn btn-primary" id="btnUpdateProfile" onclick="return _saveProfile();">
                                        Save</button>--%>
                                    <div id="btnProgress" class="span4" style="height: 0; width: 140px; display: none; margin-left: 0;">
                                        <div style="font-size: 14px;">
                                            Please wait, Saving...
                                        </div>
                                        <div class="progress progress-striped active progress-medium">
                                            <div style="width: 100%" class="bar">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-7">
                <div class="card  card-danger card-outline">
                    <div class="card-header p-2">
                        <h5 class="text-bold text-center">Change Password</h5>
                        <div class="text-center">
                            If someone has figured out your password, they might be accessing your account without your knowledge. Regularly resetting your password helps limit this type of unauthorized access.
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="tab-pane" id="settings">
                            <div class="form-horizontal">
                                <div class="form-group row">
                                    <label for="txtCurrentPassword" class="col-sm-4 col-form-label">Current Password</label>
                                    <div class="col-sm-8">
                                        <input type="password" class="form-control form-control-sm txtCurrentPassword" id="txtCurrentPassword" placeholder="Current Password" autocomplete="off" aria-autocomplete="none">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="txtNewPassword" class="col-sm-4 col-form-label">New Password</label>
                                    <div class="col-sm-8">
                                        <input type="password" class="form-control form-control-sm txtNewPassword" id="txtNewPassword" placeholder="New Password" autocomplete="off">
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="txtConfirmPassword" class="col-sm-4 col-form-label">Confirm Password</label>
                                    <div class="col-sm-8">
                                        <input type="password" class="form-control form-control-sm txtConfirmPassword" id="txtConfirmPassword" placeholder="Confirm Password" autocomplete="off">
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group row">
                                    <div class="offset-sm-4 col-sm-10">
                                        <button type="button" class="btn btn-danger ladda-button" onclick="return changePassword(this);" data-style="zoom-in">Submit</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        function changePassword(e) {
            var currentPassword = $.trim($(".txtCurrentPassword").val());
            var newPassword = $.trim($(".txtNewPassword").val());
            var confirmPassword = $.trim($(".txtConfirmPassword").val());

            if (currentPassword == "") { toastr.error("Please enter your current password"); $(".txtCurrentPassword").focus(); return false; }
            else if (newPassword == "") { toastr.error("Please enter new password"); $(".txtNewPassword").focus(); return false; }
            else if (confirmPassword == "") { toastr.error("Please enter confirm password"); $(".txtConfirmPassword").focus(); return false; }
            else if (newPassword == currentPassword) { toastr.error("New password cannot be same as your current password"); $(".txtConfirmPassword").focus(); return false; }
            else if (newPassword != confirmPassword) { toastr.error("Confirm password doesnt match with your new password"); $(".txtConfirmPassword").focus(); return false; }
            var l = Ladda.create(e); l.start();

            var model = {};
            model.CurrentPassword = currentPassword;
            model.NewPassword = newPassword;
            model.ConfirmPassword = confirmPassword;
            $.ajax({
                type: "POST",
                url: '/api/cLogin/ChangePassword',
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    if (res.IsValid) {
                        toastr.success(res.Msg);
                    }
                    else {
                        toastr.error(res.Msg)
                    }
                },
                error: function (err) {
                    l.stop();
                    toastr.error("There is some error while contacting server, please try later");
                },
                complete: function () { l.stop(); }
            });
            return false;
        }

    
        <%--$('#form-profile').submit(function (event) {
            event.preventDefault();
        });
        function _saveProfile() {

            let model = {};
            model.DisplayName = $.trim($('#<%=txtDisplayName.ClientID %>').val());
        model.ContactNo = $.trim($('#<%=txtContactNo.ClientID %>').val());
        var fd = new FormData();
        var file = document.getElementById('txtPicture');

        model.profilePic = file.files.length == 0 ? $('#img_profile').attr('src').substring($('#img_profile').attr('src').lastIndexOf('/')) : file.files[0].name;
        debugger;
        var param_detail = JSON.stringify(model);
        for (var i = 0; i < file.files.length; i++) {
            fd.append('_file', file.files[i]);
        }

        $('#btnUpdateProfile').hide();
        $('#btnProgress').show();
        $.ajax({
            type: "POST",
            url: '<%= ResolveClientUrl("~/settings/my_profile.aspx/UpdateUserProfile") %>',
                data: '{model:' + param_detail + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var data = data.d;
                    if (data.IsValid) {
                        if (file.files.length == null || file.files.length == 0) window.location = 'my_profile';
                        $.ajax({
                            url: 'sAjaxSource/UploadProfileImg.aspx',
                            type: 'post',
                            data: fd,
                            contentType: false,
                            processData: false,
                            success: function (response) {
                                if (response != 0) {
                                    window.location = 'my_profile';
                                }
                            },
                        });
                    }
                    else {
                        $('#btnUpdateProfile').show();
                        $('#btnProgress').hide();
                        bootbox.alert(data.Result, function () { });
                        $('#<%=txtDisplayName.ClientID %>').focus();
                        return false;
                    }
                },
                error: function (err) {
                    debugger;
                    console.log(err.responseText);
                    $('#btnUpdateProfile').show();
                    $('#btnUpdateProfile').hide();
                    bootbox.alert("Please check your form entries and try again", function () { });
                }
            });
        }--%>
    </script>
</asp:Content>
