<%@ Page Title="User Master" Language="C#" MasterPageFile="~/views/root/Site1.Master" AutoEventWireup="true" CodeBehind="userMaster.aspx.cs" Inherits="DxBlue.cons.views.cpanel.userMaster" %>

<%@ Import Namespace="DxBlue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <input type="hidden" id="hIsAdd" class="hIsAdd" value="0" runat="server" />
    <input type="hidden" id="hIsEdit" class="hIsEdit" value="0" runat="server" />
    <input type="hidden" id="hIsDelete" class="hIsDelete" value="0" runat="server" />
    <input type="hidden" id="hIsRestore" class="hIsRestore" value="0" runat="server" />

    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>User Master</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="<%= CGlobal.GoToHome() %>">Home</a></li>
                        <li class="breadcrumb-item active">User Master</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="card">
            <div class="card-body">
               <div class="row">
                    <div class="col-md-1">
                        For:
                    </div>
                    <div class="col-md-2">
                        <select id="ddlSource" class="form-control form-control-sm select2 ddlSource" runat="server"></select>
                    </div>
                    <div class="col-md-9 text-right">
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="mainGrid"></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="modal fade" id="userModal" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content modal-dialog-scrollable" role="document">
                <div class="modal-header bg-info py-2">
                    <h6 class="modal-title text-white">User Form</h6>
                    <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body"></div>
            </div>
        </div>
    </div>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/cpanel/userMaster") %>
    </asp:PlaceHolder>
</asp:Content>
