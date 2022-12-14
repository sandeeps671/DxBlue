<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DxBlue.consistent.views.account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, maximum-scale=1.0, minimum-scale=1.0">
    <%--<script type="text/javascript" src="/Scripts/jquery-3.6.0.min.js"></script>--%>

    <!-- DevExtreme theme -->
    <%--<link href="/Content/softblue/dx.softblue.compact.css" rel="stylesheet" />--%>
    <!-- Bootstrap -->
    <%--<link href="/Content/bootstrap.min.css" rel="stylesheet" />--%>
    <!-- DevExtreme library -->
    <%--<script type="text/javascript" src="/Scripts/dx/dx.all.js"></script>--%>
    <!-- <script type="text/javascript" src="https://cdn3.devexpress.com/jslib/21.1.3/js/dx.web.js"></script> -->
    <!-- <script type="text/javascript" src="https://cdn3.devexpress.com/jslib/21.1.3/js/dx.viz.js"></script> -->

    <%--<link href="/Content/myStyle.css" rel="stylesheet" />--%>
    <%--<link href="/Content/toastr.min.css" rel="stylesheet" />--%>

    <%--<link href="/plugins/ladda-spinner/ladda-themeless.min.css" rel="stylesheet" />--%>

    <%--<script src="/Scripts/Shared/jHandler.js"></script>--%>
    <%--<script src="/Scripts/toastr.min.js"></script>--%>

    <%--<script src="/plugins/ladda-spinner/spin.min.js"></script>--%>
    <%--<script src="/plugins/ladda-spinner/ladda.min.js"></script>--%>
    <%--<link href="../../Content/login.css" rel="stylesheet" />--%>
    <asp:PlaceHolder runat="server">
        <%: Styles.Render("~/bundle/loginCss") %>
        <%: Scripts.Render("~/bundle/loginJs") %>
    </asp:PlaceHolder>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid px-1 px-md-5 px-lg-1 px-xl-5 py-5 mx-auto">
            <div class="card card0 border-0">
                <div class="row d-flex">
                    <div class="col-lg-6">
                        <div class="card1 pb-5">
                            <div class="row">
                                <img src="/assets/images/logo-min.jpg" class="logo" />
                            </div>
                            <div class="row px-3 justify-content-center mt-4 mb-5 border-line">
                                <img src="/assets/images/banner.jpg" class="image" />
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="card2 card border-0 px-4 py-5">
                            <span class="mt-5 mb-5"></span>
                            <div class="row px-3">
                                <label class="mb-1">
                                    <h6 class="mb-0 text-sm">Username</h6>
                                </label>
                                <input type="text" id="txtUserName" class="form form-control mb-4" placeholder="username" required="required" autocomplete="off" />
                            </div>
                            <div class="row px-3 mb-2">
                                <label class="mb-1">
                                    <h6 class="mb-0 text-sm">Password</h6>
                                </label>
                                <input type="password" id="txtPassword" class="form form-control" placeholder="Enter password" required="required" />
                            </div>
                           <%-- <div class="row px-3 mb-4">
                                    <div class="custom-control custom-checkbox custom-control-inline">
                                    <input id="chkRememberMe" type="checkbox" name="chkRememberMe" class="custom-control-input" />
                                    <label for="chkRememberMe" class="custom-control-label text-sm">Remember me</label>
                                </div>
                            </div>--%>
                            <div class="row mb-3 px-3">
                                <button type="submit" id="btnLogin" class="btn btn-primary text-center ladda-button" data-style="zoom-in">Login</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="bg-blue py-4">
                    <div class="row px-3">
                        <small class="ml-4 ml-sm-5 mb-2">Copyright &copy; 2021. All rights reserved.</small>
                        <div class="social-contact ml-4 ml-sm-auto"><span class="fa fa-facebook mr-4 text-sm"></span><span class="fa fa-google-plus mr-4 text-sm"></span><span class="fa fa-linkedin mr-4 text-sm"></span><span class="fa fa-twitter mr-4 mr-sm-5 text-sm"></span></div>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
<script src="/Scripts/Shared/jHandler.js"></script>
<script src="/Scripts/Shared/userLocation.js"></script>
<script>
    $(document).ready(function () {
        //pushUserLocationAction("Test Location","Test Action","Test Remark")
        $("#txtUserName").focus();
        $("#btnLogin").click(function (e) {
            e.preventDefault();
            let model = {};
            model.UserName = $("#txtUserName").val();
            model.Password = $("#txtPassword").val();
            model.ReturnUrl = ReturnUrl;
            model.platform = 'Web';
            model.keep_logged = false; // GetCheckBoxState($("#chkRememberMe"));

            if (model.UserName == "") { toastr.error("Please enter username"); $("#txtUserName").focus(); return false; }
            if (model.Password == "") { toastr.error("Please enter password"); $("#txtPassword").focus(); return false; }
            let l = Ladda.create(document.querySelector('#btnLogin')); l.start();
            // ajax code to be displayd

            var ReturnUrl = "";
            //if ("ReturnUrl" in urlParams) ReturnUrl = urlParams["ReturnUrl"];

            $.ajax({
                type: "POST",
                url: "/api/cLogin/ValidateLogin",
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    if (res.IsValid) {
                        window.location.replace("/views/home/dashboard1");
                    }
                    else { l.stop(); toastr.error("Invalid username of password"); }
                },
                error: function (err) { l.stop(); debugger; toastr.error(err.responseText); },
                complete: function () { }
            })
        });
    });
</script>
</html>
