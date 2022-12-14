<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/views/root/Site1.Master" AutoEventWireup="true" CodeBehind="dashboard1.aspx.cs" Inherits="DxBlue.cons.views.home.dashboard1" %>

<%@ Import Namespace="DxBlue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <style>
        .dx-datagrid-headers .dx-header-row {
            background-color: lightseagreen;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <input type="hidden" id="hIsExport" class="hIsExport" value="0" runat="server" />
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-7">
                    <h1 id="dashboardTitle" class="blink-text text-navy">Consistent Infosystems Pvt. Ltd.</h1>
                </div>
                <div class="col-sm-5 d-none d-sm-block">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="<%= CGlobal.GoToHome() %>">Home</a></li>
                        <li class="breadcrumb-item active">Dashboard</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="row p-2">
            <div class="col-md-9">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-info card-outline p-1">
                            <div class="cord-body">
                                <div class="form-group row">
                                    <div class="col-md-3">
                                        <label class="col-form-label">Period</label>
                                        <div id="reportrange" class="pull-right">
                                            <%--<i class="fa fa-calendar fa-xs" aria-hidden="true"></i>--%>
                                            <span>This Month </span><i class="fa fa-angle-down text-danger fa-1x"></i>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="col-form-label">Area</label>
                                        <select id="ddlArea" class="form-control form-control-sm select2 ddlArea" runat="server" onchange="return areaChange();">
                                        </select>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="col-form-label">Target</label>
                                        <select id="ddlTarget" class="form-control form-control-sm select2 ddlTarget" runat="server" onchange="return targetChange();">
                                        </select>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="col-form-label">View</label>
                                        <select id="ddlView" class="form-control form-control-sm select2 ddlView" runat="server" onchange="return viewChange();">
                                            <option value="0">All</option>
                                            <option value="1">T Only</option>
                                            <option value="2">NT Only</option>
                                        </select>
                                    </div>
                                    <%--<div class="col-md-2">
                                        <label class="col-form-label">Type</label>
                                        <select id="ddlTargetType" class="form-control form-control-sm select2 ddlTargetType" runat="server">
                                            <option value="0">All</option>
                                        </select>
                                    </div>--%>
                                    <div class="col-md-2">
                                        <label class="col-form-label">User</label>
                                        <select id="ddlTargetUser" class="form-control form-control-sm select2 ddlTargetUser" runat="server" onchange="return targetUserChange();">
                                            <option value="0">All</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-12">
                                        <table class="table table-sm table-bordered table-hover" id="tblTotalTarget" style="width: 100%">
                                            <thead>
                                                <%--<tr style="color: black; background-color: lightseagreen">--%>
                                                <tr class="dashboardHeaderRow">
                                                    <th style="width: 10%; vertical-align: middle" colspan="1" rowspan="2" class="text-center text-white">Stock</th>
                                                    <th style="width: 30%;" colspan="2" class="text-center text-white">Total Target</th>
                                                    <th style="width: 30%;" colspan="2" class="text-center text-white">Total Achievement</th>
                                                    <th style="width: 30%;" colspan="2" class="text-center text-white">Percentage</th>
                                                </tr>
                                                <tr style="color: black; background-color: azure" class="text-center font-weight-bold">
                                                    <td>Qty</td>
                                                    <td>Amount</td>
                                                    <td>Qty</td>
                                                    <td>Amount</td>
                                                    <td>Qty</td>
                                                    <td>Amount</td>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td class="text-center">0</td>
                                                    <td class="text-center">0</td>
                                                    <td class="text-center">0</td>
                                                    <td class="text-center">0</td>
                                                    <td class="text-center">0</td>
                                                    <td class="text-center">0</td>
                                                    <td class="text-center">0</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card card-primary card-outline">
                            <div class="card-header">
                                <span class="font-weight-bold">Groupwise Sale
                                    <a onclick="return fillGroupWiseVsTargetNew();" href="javascript:void(0)">Click to load</a>
                                </span>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-default btn-sm" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div id="dgGroupVsTarget"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card card-danger card-outline">
                            <div class="card-header">
                                <span class="font-weight-bold">Product Detail Tgt Vs Achievement <a onclick="return fillProductVsTargetNew();" href="javascript:void(0)">Click to load</a></span>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-default btn-sm" data-card-widget="collapse" title="Collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div id="dgProductVsTarget"></div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card card-warning card-outline pt-1 pb-1">
                            <div class="cord-body">
                                <div class="col-md-12">
                                    <input type="text" class="form-control form-control-sm" placeholder="Search Serial No." onchange="searchSerialNo(this);" />
                                </div>
                                <div class="col-md-12">
                                    <div id="dgSerialHistory"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-primary">
                            <div class="card-header">
                                <h3 class="card-title">Areawise sales</h3>

                                <div class="card-tools">
                                    <a class="btn btn-rool btn-sm d-none text-center" id="btnTotalSale" onclick="return viewAreawiseSaleForm('0');" title="View All"><i class="fa fa-eye text-white" aria-hidden="true"></i></a>
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div id="chart_areawise_sale" class="align-middle text-center"></div>
                                <div class="text-center">
                                    Total:&nbsp;<span class="font-weight-bold" id="totalAreaWiseSales">0</span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="card card-info">
                            <div class="card-header">
                                <h3 class="card-title">Statewise Sales</h3>
                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>

                            </div>
                            <div class="card-body">
                                <div id="chart_statewise_sale" class="align-middle text-center"></div>
                                <div class="text-center">
                                    Total:&nbsp;<span class="font-weight-bold" id="totalStateWiseSales">0</span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="card card-danger">
                            <div class="card-header">
                                <h3 class="card-title">Groupwise Sales</h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div id="chart_groupwise_sale" class="align-middle text-center"></div>
                                <div class="text-center">
                                    Total:&nbsp;<span class="font-weight-bold" id="totalGroupWiseSales">0</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <div class="modal fade" id="areaSaleModel" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content modal-dialog-scrollable" role="document">
                <div class="modal-header bg-primary py-2">
                    <h6 class="modal-title text-white">Area Wise Sales</h6>
                    <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body"></div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="stateWiseSaleModel" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content modal-dialog-scrollable" role="document">
                <div class="modal-header bg-info py-2">
                    <h6 class="modal-title text-white">State Wise Sales</h6>
                    <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body"></div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="groupWiseSaleModel" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content modal-dialog-scrollable" role="document">
                <div class="modal-header bg-danger py-2">
                    <h6 class="modal-title text-white">Group Wise Sales</h6>
                    <button type="button" class="close text-light" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body"></div>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });</script>
    <%--<script src="scripts/dashboard1.js" async></script>--%>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/dashboard1") %>
    </asp:PlaceHolder>
</asp:Content>
