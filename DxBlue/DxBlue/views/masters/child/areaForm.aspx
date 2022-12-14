<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="areaForm.aspx.cs" Inherits="DxBlue.cons.views.masters.child.areaForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <div class="form-group row">
            <div class="col-md-6">
                <input type="hidden" id="hRV" name="hRV" class="hRV" value="" runat="server" />
                <input type="hidden" id="hAreaId" name="hAreaId" class="hAreaId" value="0" runat="server" />
                <input type="hidden" id="hAction" name="hAction" class="hAction" value="0" runat="server" />
                <label class="col-form-label">Area Name<span class="text-danger">*</span></label>
                <input id="txtAreaName" type="text" class="form-control form-control-sm txtAreaName" value="" autocomplete="off" maxlength="30" runat="server" />
            </div>
            <div class="col-md-3">
                <label class="col-form-label">GstNo<span class="text-danger">*</span></label>
                <input type="text" runat="server" id="txtGstNo" class="form-control form-control-sm txtGstNo" maxlength="15" autocomplete="off" />
            </div>
            <div class="col-md-3">
                <label class="col-form-label">Godown Facility<span class="text-danger">*</span></label>
                <select id="ddlHasGodown" class="form-control form-control-sm  select3 ddlHasGodown" runat="server">
                    <option value="0">No</option>
                    <option value="1">Yes</option>
                </select>
            </div>
            <div class="col-md-6">
                <label class="col-form-label">Email Id</label>
                <input id="txtEmailId" type="text" class="form-control form-control-sm txtEmailId" value="" autocomplete="off" maxlength="500" runat="server" />
            </div>
            <div class="col-md-6">
                <label class="col-form-label">Sales Return Email Id</label>
                <input id="txtSrEmailId" type="text" class="form-control form-control-sm txtSrEmailId" value="" autocomplete="off" maxlength="500" runat="server" />
            </div>
            <div class="col-md-12">
                <label class="col-form-label">Address</label>
                <textarea id="txtAddress" runat="server" class="form-control form-control-sm txtAddress textArea" rows="2" maxlength="500"></textarea>
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
                $("#areaModal input, #areaModal textarea, #areaModal select").prop("disabled", true);
                $("#btnSubmitChild").hide();
            }
            $("select.select3").select2();
            SetMaskGstNo($(".txtGstNo"));
        });
        $("#btnSubmitChild").click(function (e) {
            e.preventDefault();
            let l = Ladda.create(document.querySelector('#btnSubmitChild')); l.start();
            let submit = true;
            let _model = {};

            _model.AreaId = GetCtrlIntVal($("#hAreaId"));
            _model.AreaName = GetCtrlVal($("#txtAreaName"));
            _model.HasGodown = GetCtrlIntVal($("#ddlHasGodown")) == 1 ? true : false;
            _model.EmailId = GetCtrlVal($("#txtEmailId"));
            _model.SrEmailId = GetCtrlVal($("#txtSrEmailId"));
            _model.GstNo = GetCtrlVal($("#txtGstNo"));
            _model.Address = GetCtrlVal($("#txtAddress"));
            _model.RV = GetCtrlVal($("#hRV"));

            if (_model.AreaName == "") { toastr.error("Please enter area name"); l.stop(); FocusCtrl($("#txtAreaName")); submit = false; return false; }
            if (_model.ContactName == "") { toastr.error("Please enter contact name"); l.stop(); FocusCtrl($("#txtContactName")); submit = false; return false; }

            if (!submit) return false;
            $.ajax({
                type: "POST",
                url: baseApiUrl + "/api/cArea/SubmitArea",
                data: JSON.stringify(_model),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res) {
                    if (res.IsValid) {
                        toastr.success(res.Msg);
                        $("#areaModal").modal("hide");
                        $("#mainGrid").dxDataGrid("instance").refresh();
                        pushUserLocationAction("AREA MASTER", _model.AreaId == 0 ? "ADD" : "EDIT", _model.AreaId == 0 ? "" : _model.AreaId);
                    }
                    else {
                        toastr.error(res.Msg);
                    }
                },
                error: function (err) { toastr.error("Please check your form entries and try again"); },
                complete: function (res) { l.stop(); }
            });
            return false;
        });
    </script>
</body>
</html>
