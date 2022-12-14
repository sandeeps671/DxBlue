$.fn.select2.defaults.set("theme", "classic");
$.fn.select2.defaults.set("width", "100%");
var IsExport = false;
toastr.options = {
    "closeButton": true, "debug": false, "newestOnTop": true, "progressBar": false,
    "positionClass": "toast-bottom-right", "preventDuplicates": true, "onclick": null, "showDuration": "300",
    "hideDuration": "400", "timeOut": "1500", "extendedTimeOut": "1000", "showEasing": "swing",
    "hideEasing": "linear", "showMethod": "fadeIn", "hideMethod": "fadeOut"
}
$.fn.datepicker.defaults.format = "dd/mm/yyyy";
$.fn.daterangepicker.defaultOptions = {
    clearBtn: true, todayBtn: true, autoclose: true, todayHighlight: true, calendarWeeks: true, showDropdowns: true,
    format: 'dd/mm/yyyy',
    startDate: GetMonthStartDt(),
    endDate: GetCurrentDt(),
    minYear: 2014, maxYear: parseInt(moment().format('YYYY'), 10),
    locale: { format: 'DD/MM/YYYY' }
};

DevExpress.ui.dxDataGrid.defaultOptions({
    //device: { deviceType: "desktop" },
    //scrolling: {
    //    mode: 'virtual',
    //    rowRenderingMode: 'virtual',
    //},
    //remoteOperations: {
    //    filtering: true,
    //    paging: true,
    //    sorting: true,
    //    groupPaging: true,
    //    grouping: true,
    //    summary: true
    //},
    scrolling: {
        mode: 'virtual',
        rowRenderingMode: 'virtual',
        columnRenderingMode: 'virtual'
    },
    options: {
        //focusedRowEnabled: true,
        //focusedRowIndex: 0,
        //focusedColumnIndex: 0,

        selection: {
            mode: "none",// or "multiple" | "none"
            selectAllMode: "page", // or "allPages"
            allowSelectAll: true,
            showCheckBoxesMode: "always"    // or "onClick" | "onLongTap" | "always"
        },
        loadPanel: { enabled: true, },
        repaintChangesOnly: true,
        height: "auto",
        paging: { enabled: true, pageSize: 25 },
        pager: {
            showPageSizeSelector: true, allowedPageSizes: [10, 25, 50, 100], showNavigationButtons: true,
            showInfo: true, infoText: "Total: {2} items" //infoText: "Page #{0}. Total: {1} ({2} items)"
        },
        remoteOperations: false, allowColumnResizing: true,
        searchPanel: { visible: true, highlightCaseSensitive: true },
        groupPanel: { visible: false }, grouping: { autoExpandAll: true, contextMenuEnabled: true },
        allowColumnReordering: true, rowAlternationEnabled: true,
        showBorders: true, columnChooser: { enabled: true, mode: "select" },
        headerFilter: { visible: true, allowSearch: true },
        filterRow: { visible: false }, filterPanel: { visible: false }, filterSyncEnabled: false, wordWrapEnabled: true,
        columnFixing: { enabled: true }, export: { enabled: false },
        scrolling: {
            useNative: false, scrollByContent: true, scrollByThumb: true, showScrollbar: "onHover" // or "onScroll" | "always" | "never"
        },
        sorting: {
            mode: "multiple" // or "single" | "none"
        }
    }
});
$(document).ready(function () {
    $(".combobox").select2({ "theme": "default" });
    //$('#sideMenu a[href="' + $(location).attr("pathname") + '"]').addClass('nav-link active').css("background-color", "lightseagreen").css("color", "white");
    $('#sideMenu a[href="' + $(location).attr("pathname") + '"]').addClass('nav-link active').css("background-color", "#17a2b8").css("color", "white");
    $('#sideMenu a[href="' + $(location).attr("pathname") + '"]').parent().parent().parent().addClass('menu-open');
});

DevExpress.ui.dxPivotGrid.defaultOptions({
    //device: { deviceType: "desktop" },
    options: {
        dataFieldArea: "column", // row
        disabled: false,
        fieldChooser: {
            enabled: true, allowSearch: true, applyChangesMode: "onDemand", // "instantly",
            height: 400, width: 400
        },
        fieldPanel: {
            allowFieldDragging: true, showColumnFields: true, showDataFields: true,
            showFilterFields: true, showRowFields: true, texts: {}, visible: false
        },
        headerFilter: { allowSearch: true, height: 325, searchTimeout: 500, showRelevantValues: false, texts: {}, width: 252 },
        hideEmptySummaryCells: true,
        loadPanel: {
            enabled: true, height: 70, indicatorSrc: "", shading: false, shadingColor: "",
            showIndicator: true, showPane: true, text: "Loading...", width: 200
        },
        onCellClick: null,
        onCellPrepared: null,
        onContentReady: null,
        onContextMenuPreparing: null,
        onDisposing: null,
        onExporting: null,
        onInitialized: null,
        onOptionChanged: null,
        rowHeaderLayout: "standard", // "tree"
        rtlEnabled: false,
        scrolling: {
            mode: "standard", // "virtual"
            useNative: "auto"
        },
        allowSortingBySummary: false,
        allowSorting: false,
        allowFiltering: true,
        showBorders: true,
        showColumnGrandTotals: false,
        showRowGrandTotals: true,
        showRowTotals: false,
        showColumnTotals: true,
        //width: '100%',
        allowExpandAll: true,

        showTotalsPrior: "none",
        stateStoring: {
            customLoad: null,
            customSave: null,
            enabled: false,
            savingTimeout: 2000,
            storageKey: null,
            type: "localStorage"
        },
        tabIndex: 0,
        texts: {
            collapseAll: "Collapse All",
            dataNotAvailable: "N/A",
            expandAll: "Expand All",
            exportToExcel: "Export to Excel file",
            grandTotal: "Grand Total",
            noData: "No data found",
            removeAllSorting: "Remove All Sorting",
            showFieldChooser: "Show Field Chooser",
            sortColumnBySummary: "Sort {0} by This Column",
            sortRowBySummary: "Sort {0} by This Row",
            total: "{0} Total"
        },
        visible: true,
        width: undefined,
        wordWrapEnabled: true,
        export: { enabled: false },
        rowHeaderLayout: "tree", // "standard"
        showTotalsPrior: "both", // "columns","rows","none", "both"
    }
});