<%@ Page Title="" Language="C#" MasterPageFile="~/views/root/Site1.Master" AutoEventWireup="true" CodeBehind="dxBuilder.aspx.cs" Inherits="DxConsistent.views.mis.dxBuilder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .textAlignLeft {
            text-align: left;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="<%= Page.ResolveClientUrl("~/Content/RunQueryBuilder.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <dx:ShowQueryBuilderButtonControl ID="showQueryBuilderButton" runat="server" />
    <dx:ASPxGridView ID="grid" runat="server" Styles-Cell-CssClass="textAlignLeft" ClientInstanceName="grid"
        Width="100%" OnDataBound="grid_DataBound" DataSourceID="NorthwindDataSource">
        <SettingsBehavior AllowEllipsisInText="true" AllowSort="false" />
        <SettingsResizing ColumnResizeMode="Control" />
    </dx:ASPxGridView>
    <asp:SqlDataSource ID="NorthwindDataSource" runat="server" OnInit="NorthwindDataSource_Init" />
</asp:Content>
