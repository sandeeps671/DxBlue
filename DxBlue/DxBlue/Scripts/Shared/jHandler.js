function IsCtrlEmpty(ctrl) { if (ctrl !== null) { if ($.trim(ctrl.val()) == "") return true; else return false; } return true; }
function GetCtrlUpperVal(ctrl) { if (ctrl !== null) return $.trim(ctrl.val()).toUpperCase(); return ""; }
function GetCtrlVal(ctrl) { if (ctrl !== null) return $.trim(ctrl.val()); return ""; }
function GetCtrlIntVal(ctrl) { if (ctrl !== null) if (!isNaN(ctrl.val())) { if (parseInt(ctrl.val(), 10)) return parseInt(ctrl.val(), 10); else return 0; } else return 0; else return 0; }
function GetCtrlFloatVal(ctrl) { if (ctrl !== null) if (!isNaN(parseFloat(ctrl.val()))) { if (parseFloat(ctrl.val())) return parseFloat(ctrl.val()); else return 0.0; } else return 0.0; else return 0.0; }
//function GetCtrlFloatVal(ctrl) { if (ctrl !== null) if (!isNaN(parseFloat(ctrl.val()))) { if (parseFloat(ctrl.val())) return numeral(ctrl.val()).value(); else return 0.0; } else return 0.0; else return 0.0; }
function FocusCtrl(ctrl) { if (ctrl !== null) ctrl.focus(); }
function FocusSelect2(ddl) { if (ddl !== null) ddl.select2('open'); }
function ToIntVal(value) { return isNaN(parseInt(value)) ? 0 : parseInt(value); }
function ToFloatVal(value) { return isNaN(parseFloat(value)) ? 0.0 : parseFloat(value); }
//function ToFloatVal(value) { return isNaN(parseFloat(value)) ? 0.0 : numeral(value).value(); }
function IsDateEmpty(dt) { if (dt == null) return true; else if (dt === "01/01/1900" || dt === "") return true; else if (moment(dt, 'DD/MM/YYYY').isValid()) return false; else return true; }
function IsDateValid(dt) { if (dt == null) return false; else if (dt.val() === "01/01/1900") return false; else if (moment(dt.val(), 'DD/MM/YYYY').isValid()) return true; else false; }
function GetCtrlDate(dt) { if (dt == null) return ""; else if (moment(dt.val(), 'DD/MM/YYYY').isValid()) return moment(dt.val(), 'DD/MM/YYYY').format('MM/DD/YYYY'); else return moment("01/01/1900", 'DD/MM/YYYY').format('MM/DD/YYYY'); }
function GetCtrlDateFromLabel(dt) { if (dt == null) return ""; else if (moment(dt.html(), 'DD/MM/YYYY').isValid()) return moment(dt.html(), 'DD/MM/YYYY').format('MM/DD/YYYY'); else return moment("01/01/1900", 'DD/MM/YYYY').format('MM/DD/YYYY'); }
function GetMdyDate(dt) {
    let minDate = moment.utc("0001-01-01"); // minimum value asfunction FocusSelect2(ddl) { if (ddl !== null) ddl.select2('open'); } per UTC
    if (dt == null) return "";
    else if (moment(dt, 'DD/MM/YYYY').isValid()) {
        if (moment.utc(dt, 'DD/MM/YYYY').isAfter(minDate))
            return moment(dt, 'DD/MM/YYYY').format('MM/DD/YYYY');
        else "";
    }
    else return "";
}
function GetDmyDate(dt) {
    let minDate = moment.utc("0001-01-01"); // minimum value as per UTC
    if (dt == null) return "";
    else if (moment(dt, 'MM/DD/YYYY').isValid()) {
        if (moment.utc(dt, 'MM/DD/YYYY').isAfter(minDate))
            return moment(dt, 'MM/DD/YYYY').format('DD/MM/YYYY');
        else "";
    }
    else return "";
}
function GetDmyDateByUtc(dt) {
    let minDate = moment.utc("0001-01-01"); // minimum value as per UTC
    if (dt == null) return "";
    else if (moment(dt).isValid()) {
        if (moment(dt).format('DD/MM/YYYY') == "01/01/1900")
            return "";
        else if (moment.utc(dt).isAfter(minDate))
            return moment(dt).format('DD/MM/YYYY');
        else "";
    }
    else return "";
}
function GetValidDmyDate(dt) {
    let minDate = moment.utc("1900-01-01"); // minimum value as per UTC
    if (dt == null) return "";
    else if (moment(dt).isValid()) {
        if (moment.utc(dt).isAfter(minDate))
            return moment(dt).format('DD/MM/YYYY');
        else "";
    }
    else return "";
}
function DisableCtrl(ctrl) { if (ctrl != null) ctrl.attr("disabled", true); }
function EnableCtrl(ctrl) { if (ctrl != null) ctrl.attr("disabled", false); }
function OnlyNumber(e) { e.value = e.value.replace(/[^0-9]/g, ''); e.value = e.value.replace(/(\..*)\./g, '$1'); }
function TwoDecimalPlaces(e) {
    let val = e.value;
    let re = /^([0-9]+[\.]?[0-9]?[0-9]?|[0-9]+)$/g;
    let re1 = /^([0-9]+[\.]?[0-9]?[0-9]?|[0-9]+)/g;
    if (re.test(val)) { } else { val = re1.exec(val); if (val) { e.value = val[0]; } else { e.value = ""; } }
}

function GetCheckBoxState(ctrl) { if (ctrl != null) return ctrl.is(":checked"); else false; }
function HideCtrl(ctrl) { if (ctrl != null) ctrl.hide(); }
function ShowCtrl(ctrl) { if (ctrl != null) ctrl.show(); }
function GetBoolValue(ctrl) {
    if (ctrl != null) { if (ctrl.val() == "1" || ctrl.val() == "TRUE" || ctrl.val() == "true" || ctrl.val() == "True") return true; else return false; }
}
function MatchTxt(searchIn, textMatch) {
    txtcount = 0;
    $('#' + searchIn).filter(function () { if (this.value != "") { if (textMatch == this.value) { txtcount += 1 } } });
    return txtcount;
}

function GetStringToArray(strVal, splitter) {
    let values = strVal.split(splitter);
    let arr = new Array();
    $.each(values, function (index, recordId) { arr.push(recordId); });
    return arr;
}

function GetMonthStartDt() { return moment().startOf('month'); }
function GetMonthEndDt() { return moment().endOf('month'); }
function GetCurrentDt() { return moment(); }
function GetFinYearStartDt() {
    if (moment().month() < 3) {
        return moment().month('april').startOf('month').subtract(1, 'year');
    }
    else return moment().month('april').startOf('month');
}
function GetFinYearEndDt() {
    if (moment().month() < 3) {
        return moment().month('march').endOf('month');
    }
    else return moment().month('march').endOf('month').add(1, 'year');
}
function GetYearStartDt() {
    return moment().month('jan').startOf('month');
}
function GetYearEndDt() {
    return moment().month('dec').startOf('month');
}
function SetMaskIntMinMax(ctrl, min, max) { if (ctrl != null) return ctrl.inputmask("integer", { min: min, max: max }); }
function SetMaskInt(ctrl) { if (ctrl != null) return ctrl.inputmask("integer", { min: 0 }); }
function SetDecimal(ctrl) { if (ctrl != null) return ctrl.inputmask("decimal"); }
function SetDecimalTwoDigit(ctrl) { if (ctrl != null) return ctrl.inputmask("decimal", { digits: 2 }); }
function SetMaskCurrency(ctrl) { if (ctrl != null) return ctrl.inputmask("currency", { groupSeparator: "", min: 0, greedy: false }); }
function SetMaskCurrency2(ctrl) { if (ctrl != null) return ctrl.inputmask("currency", { groupSeparator: "" }); }
function SetMaskDate(ctrl) { if (ctrl != null) return ctrl.inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' }); }
function SetDatePicker(ctrl) { if (ctrl != null) return ctrl.datepicker({ format: 'dd/mm/yyyy', autoclose: true }); }
function SetDatePickerMaxToday(ctrl) { if (ctrl != null) return ctrl.datepicker({ format: 'dd/mm/yyyy', todayHighlight: 'TRUE' }); }
//function SetDatePickerWithDate(ctrl) { if (ctrl != null) return ctrl.datepicker({  format: 'dd/mm/yyyy' }); }
function SetMaskGstNo(ctrl) { if (ctrl != null) return ctrl.inputmask({ regex: "^[0-9]{2}[A-Za-z]{5}[0-9]{4}[A-Za-z]{1}[1-9A-Za-z]{1}[Zz][0-9A-Za-z]{1}$", autoUnmask: true }); }
function SetMaskPanNo(ctrl) { if (ctrl != null) return ctrl.inputmask({ regex: "[A-Za-z]{5}[0-9]{4}[A-Z]{1}", autoUnmask: true }); }
function SetMaskMobileNo(ctrl) { if (ctrl != null) return ctrl.inputmask("9999999999", { autoUnmask: true }); }
function SingleDatePicker(ctrl) {
    if (ctrl != null) {
        return ctrl.daterangepicker({
            singleDatePicker: true,
            format: 'dd/mm/yyyy',
            startDate: GetCurrentDt,
            minYear: 2014, maxYear: parseInt(moment().format('YYYY'), 10)
        });
    }
}
function SingleDatePickerWithDate(ctrl, defaultDate) {
    if (ctrl != null) {
        return ctrl.daterangepicker({
            singleDatePicker: true,
            format: 'dd/mm/yyyy',
            startDate: defaultDate,
            minYear: 2014, maxYear: parseInt(moment().format('YYYY'), 10),
        });
    }
}
function IsDateBefore(endDate, startDate) {
    return moment(endDate).isBefore(startDate);
}
function exportDxGrid(e, fileName, sheetName) {
    let workbook = new ExcelJS.Workbook();
    let worksheet = (sheetName == null || sheetName == "") ? workbook.addWorksheet('Sheet1') : workbook.addWorksheet(sheetName);
    let myFileName = (fileName == null || fileName == "") ? "Consistent.xlsx" : fileName + ".xlsx"
    DevExpress.excelExporter.exportDataGrid({
        component: e.component,
        worksheet: worksheet,
        autoFilterEnabled: true
    }).then(function () {
        workbook.xlsx.writeBuffer().then(function (buffer) {
            saveAs(new Blob([buffer], { type: 'application/octet-stream' }), myFileName);
        });
    });
    e.cancel = true;
}


var baseApiUrl = "";
function viewOrderDetail(orderId) {
    //window.open("/views/mis/orderInfo?qAdsgahsdgaSDFSADGAxxsiydsafda=" + orderId, "_blank");
    var pageUrl = "/views/mis/orderInfo?qAdsgahsdgaSDFSADGAxxsiydsafda=" + encodeURI(orderId);
    $('#orderInfoModal').modal({ show: true, backdrop: 'static', keyboard: true, focus: true });
    $("#orderInfoModal .modal-body").html('<center><i class="fas fa-spinner fa-spin fa-2x"></i></center>');
    $('#orderInfoModal .modal-body').load(pageUrl, function (res) { });
    return false;
}

function openLink(url) {
    window.open(url);
    return false;
}

function IsMobileDevice() {
    if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|ipad|iris|kindle|Android|Silk|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent)
        || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(navigator.userAgent.substr(0, 4))) {
        return true;
    }
    else return false;
}
function generateRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}
function redirectWithPOST(url, target, params) {
    var form = document.createElement("form");
    form.setAttribute("method", "post");
    form.setAttribute("action", url);
    form.setAttribute("target", target); // _self,_blank

    for (var i in params) {
        if (params.hasOwnProperty(i)) {
            var input = document.createElement('input');
            input.type = 'hidden';
            input.name = i;
            input.value = params[i];
            form.appendChild(input);
        }
    }

    document.body.appendChild(form);
    form.submit();
    document.body.removeChild(form);
}
function ShowSysEditToast() { toastr.error("You cannot edit a system created item!"); }
function ShowSysDeleteToast() { toastr.error("You cannot delete a system created item!"); }
function ShowSysRestoreToast() { toastr.error("You cannot restore a system created item!"); }
function jDateTimePicker(ctrl) {
    if (ctrl != null)
        return ctrl.datetimepicker({
            datepicker: true,
            timepicker: true,
            mask: true,
            format: 'd/m/Y h:m A',
            minDate: moment().format("DD/MM/YYYY"),
        });
}
function GetMdyDateTT(dt) {
    if (dt.length == 0) return "01/01/1900";
    else dt = dt.val();
    let minDate = moment.utc("0001-01-01"); // minimum value as per UTC
    if (dt == null) return "";
    else if (moment(dt, 'DD/MM/YYYY hh:mm:ss a').isValid()) {
        if (moment.utc(dt, 'DD/MM/YYYY hh:mm:ss a').isAfter(minDate))
            return moment(dt, 'DD/MM/YYYY hh:mm:ss a').format('MM/DD/YYYY hh:mm:ss a');
        else "";
    }
    else return "";
}
function SetSelect2Val(ddl, val) { if (ddl !== null) ddl.val(val).select2(); }