<%@ Page Title="Configuration" Language="C#" MasterPageFile="~/views/root/Site1.Master" AutoEventWireup="true" CodeBehind="configSetting.aspx.cs" Inherits="DxBlue.cons.views.cpanel.configSetting" %>

<%@ Import Namespace="DxBlue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH" runat="server">
    <input type="hidden" id="hIsEdit" class="hIsEdit" value="0" runat="server" />
    <section class="content-header">
        <div class="container-fluid">
            <div class="row mb-2">
                <div class="col-sm-6">
                    <h1>App Configuration</h1>
                </div>
                <div class="col-sm-6">
                    <ol class="breadcrumb float-sm-right">
                        <li class="breadcrumb-item"><a href="<%= CGlobal.GoToHome() %>">Home</a></li>
                        <li class="breadcrumb-item active">App Configuration</li>
                    </ol>
                </div>
            </div>
        </div>
    </section>
    <section class="content">
        <div class="card card-info m-2">
            <div class="card-header">
                <div class="form-group row bg-info">
                    <div class="col-md-1 font-weight-bold">SNo</div>
                    <div class="col-sm-4 font-weight-bold">Parameter </div>
                    <div class="col-sm-2 font-weight-bold">Value</div>
                </div>
            </div>
            <div class="card-body">

                <div class="form-group row">
                    <div class="col-sm-1">1</div>
                    <div class="col-sm-4">Deduct PI from stock</div>
                    <div class="col-md-2">
                        <input type="hidden" class="hDeductPIfromStock" value="LESS_PI_FROM_STOCK" />
                        <asp:CheckBox runat="server" ID="chkDeductPIfromStock" CssClass="chkDeductPIfromStock" ClientIDMode="Static"></asp:CheckBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1">2</div>
                    <div class="col-sm-4">No order punch if party has overdue</div>
                    <div class="col-md-2">
                        <input type="hidden" class="hNoOrderIfOverdue" value="NO_ORDER_IF_OVERDUES" />
                        <asp:CheckBox runat="server" ID="chkNoOrderIfOverdue" CssClass="chkNoOrderIfOverdue" ClientIDMode="Static"></asp:CheckBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1">3</div>
                    <div class="col-sm-4">No proforma if party has overdue</div>
                    <div class="col-md-2">
                        <input type="hidden" class="hNoProformaIfOverdue" value="NO_PROFORMA_IF_OVERDUES" />
                        <asp:CheckBox runat="server" ID="chkNoProformaIfOverdue" CssClass="chkNoProformaIfOverdue" ClientIDMode="Static"></asp:CheckBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1">4</div>
                    <div class="col-sm-4">Ceiling Limit</div>
                    <div class="col-md-2">
                        <input type="hidden" class="hCeilingLimit" value="CEILING_LIMIT" />
                        <asp:TextBox ID="txtCeilingLimit" CssClass="form-control form-control-sm currency" ClientIDMode="Static" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1">5</div>
                    <div class="col-sm-4">Proforma invoice validity</div>
                    <div class="col-md-2">
                        <input type="hidden" class="hPI_Validity" value="PI_VALIDITY" />
                        <asp:TextBox ID="txtPI_Validiaty" CssClass="form-control form-control-sm numberOnly" ClientIDMode="Static" runat="server"></asp:TextBox>
                    </div>
                    <div clas="col-sm-2">(In Hours)</div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-1">6</div>
                    <div class="col-sm-4">Exclude GST from sales</div>
                    <div class="col-md-2">
                        <input type="hidden" class="hExcludeGstFromSales" value="EXCLUDE_GST_FROM_SALES" />
                        <asp:CheckBox runat="server" ID="chkExcludeGstFromSales" CssClass="chkExcludeGstFromSales" ClientIDMode="Static"></asp:CheckBox>
                    </div>
                </div>
            </div>
            <div class="card-footer">
                <button type="submit" class="btn bg-gradient-primary ladda-button" data-style="zoom-in" id="btnSubmit">Save Changes</button>
                <button type="reset" class="btn btn-default" id="btnCancel">Cancel</button>
            </div>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            SetMaskCurrency($(".currency"));
            SetMaskInt($(".numberOnly"));
            // $(".select2").select2();

            if (!GetBoolValue($("#CPH_hIsEdit"))) {
                $("input, textarea").prop("disabled", true);
                $("#btnSubmit").hide();
            }
        });
        $("#btnCancel").click(function (e) { location.reload(); });
        $("#btnSubmit").click(function (e) {
            e.preventDefault();
            let l = Ladda.create(document.querySelector('#btnSubmit')); l.start();
            let model = {};
            let items = new Array();
            let row = {}; row.ParamCode = GetCtrlVal($(".hDeductPIfromStock")); row.ParamValue = GetCheckBoxState($("#chkDeductPIfromStock")) ? "YES" : "NO"; items.push(row);
            row = {}; row.ParamCode = GetCtrlVal($(".hNoProformaIfOverdue")); row.ParamValue = GetCheckBoxState($("#chkNoProformaIfOverdue")) ? "YES" : "NO"; items.push(row);
            row = {}; row.ParamCode = GetCtrlVal($(".hNoOrderIfOverdue")); row.ParamValue = GetCheckBoxState($("#chkNoOrderIfOverdue")) ? "YES" : "NO"; items.push(row);
            row = {}; row.ParamCode = GetCtrlVal($(".hCeilingLimit")); row.ParamValue = GetCtrlFloatVal($("#txtCeilingLimit")); items.push(row);
            row = {}; row.ParamCode = GetCtrlVal($(".hPI_Validity")); row.ParamValue = GetCtrlIntVal($("#txtPI_Validiaty")); items.push(row);
            row = {}; row.ParamCode = GetCtrlVal($(".hExcludeGstFromSales")); row.ParamValue = GetCheckBoxState($("#chkExcludeGstFromSales")) ? "YES" : "NO"; items.push(row);

            model.Items = items;
            $.ajax({
                type: "POST",
                url: baseApiUrl + "/api/cAppConfiguration/SubmitConfigSetting",
                data: JSON.stringify(model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    if (res.IsValid) { toastr.success(res.Msg); }
                    else { toastr.error(res.Msg) }
                },
                error: function (err) { toastr.error(err.responseText); },
                complete: function () { l.stop(); },
            });
        });
    </script>
</asp:Content>
