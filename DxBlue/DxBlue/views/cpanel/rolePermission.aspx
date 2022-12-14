<%@ Page Title="Role Permission" Language="C#" MasterPageFile="~/views/root/Site1.Master" AutoEventWireup="true" CodeBehind="rolePermission.aspx.cs" Inherits="DxBlue.cons.views.cpanel.RolePermission" %>

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
                    <h5>Role Permission</h5>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="<%= CGlobal.GoToHome() %>">Home</a></li>
                        <li class="breadcrumb-item active">Role Permission</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="container-fluid">
            <div class="card card-outline card-primary">
                <div class="card-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlRole" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlSource" EventName="SelectedIndexChanged" />
                        </Triggers>
                        <ContentTemplate>
                            <div class="form">
                                <div class="form-group row">
                                    <div class="col-sm-1 text-right">Role</div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="true" CssClass="form form-control select2 ddlRole" OnSelectedIndexChanged="DdlRole_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-1 text-right">For</div>
                                    <div class="col-sm-4">
                                        <asp:DropDownList ID="ddlSource" runat="server" AutoPostBack="true" CssClass="form form-control select2 ddlSource" OnSelectedIndexChanged="DdlSource_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-sm-2">
                                        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-primary btn-block btn-sm" Text="Submit" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlRole" EventName="SelectedIndexChanged" />
                                    <asp:AsyncPostBackTrigger ControlID="ddlSource" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:DataList ID="dlMenu" runat="server" OnItemDataBound="DlMenu_ItemDataBound" Width="100%">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="col-sm-12" style="background-color: lightcyan">
                                                    <%# Container.ItemIndex+1 %> &nbsp;  <span style="font-weight: bold; font-size: medium" class="badge badge-info"><%# Eval("MenuName") %></span>
                                                    <input type="hidden" id="hMenuId" value='<%# Eval("MenuId") %>' runat="server" />
                                                </div>
                                                <div class="col-sm-12">
                                                    <asp:DataList ID="dlPermission" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal" RepeatColumns="4" Width="100%">
                                                        <ItemTemplate>
                                                            <table style="width: 100%;">
                                                                <tr>
                                                                    <td style="width: 100%; text-align: left; height: 20px; padding-bottom: 20px">
                                                                        <input type="hidden" id="hParamId" value='<%# Eval("ParamId") %>' runat="server" />
                                                                        <input type="hidden" id="hMenuId" value='<%# Eval("MenuId") %>' runat="server" />
                                                                        <%# Eval("ParamName") %> &nbsp;
                                                                                    <asp:CheckBox ID="chkParam" runat="server"
                                                                                        Checked='<%# Eval("IsActive") %>' />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            $(".select2").select2();
        });
    </script>
    <%--<asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/cpanel/roleMaster") %>
    </asp:PlaceHolder>--%>
</asp:Content>


