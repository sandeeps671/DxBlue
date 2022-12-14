<%@ Page Title="Area Master" Language="C#" MasterPageFile="~/views/root/Site1.Master" AutoEventWireup="true" CodeBehind="areaMaster.aspx.cs" Inherits="DxBlue.cons.views.masters.areaMaster" %>

<%@ Import Namespace="DxBlue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <input type="hidden" id="hIsAdd" class="hIsAdd" value="0" runat="server" />
    <input type="hidden" id="hIsEdit" class="hIsEdit" value="0" runat="server" />
    <input type="hidden" id="hIsDelete" class="hIsDelete" value="0" runat="server" />
    <input type="hidden" id="hIsRestore" class="hIsRestore" value="0" runat="server" />
    <input type="hidden" id="hIsExport" class="hIsExport" value="0" runat="server" />
   
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>Area Master</h1>
                </div>
                <div class="col-sm-6 d-none d-sm-block">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="<%= CGlobal.GoToHome() %>">Home</a></li>
                        <li class="breadcrumb-item active">Area Master</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-md-8"></div>
                    <div class="col-md-4 text-right">
                    </div>
                </div>
                <div class="row">
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div id="mainGrid"></div>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <div class="modal fade" id="areaModal" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content modal-dialog-scrollable" role="document">
                <div class="modal-header bg-info py-2">
                    <h6 class="modal-title text-white">Area Form</h6>
                    <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body"></div>
            </div>
        </div>
    </div>
     <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/masters/areaMaster") %>
    </asp:PlaceHolder>
</asp:Content>
