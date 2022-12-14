using System.Web.Optimization;

namespace DxBlue
{
    public class BundleConfig
    {
        // For more information on Bundling, visit https://go.microsoft.com/fwlink/?LinkID=303951
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region LOGIN BUNDLES
            bundles.Add(new StyleBundle("~/bundle/customerLoginCss").Include(
                "~/Content/adminlte/css/adminlte.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/login.css",
                "~/Content/toastr.min.css",
                "~/Content/toastr.min.css",
                "~/plugins/ladda-spinner/ladda-themeless.min.css",
                "~/plugins/fontawesome-free/css/all.min.css"
                ));
            bundles.Add(new StyleBundle("~/bundle/loginCss").Include(
               "~/Content/bootstrap.min.css",
               "~/Content/login.css",
               "~/Content/toastr.min.css",
               "~/Content/toastr.min.css",
               "~/plugins/ladda-spinner/ladda-themeless.min.css"
               ));

            bundles.Add(new ScriptBundle("~/bundle/loginJs").Include(
               "~/Scripts/jquery-3.6.0.min.js",
               "~/Scripts/toastr.min.js",
               "~/plugins/ladda-spinner/spin.min.js",
               "~/plugins/ladda-spinner/ladda.min.js"
               // "~/Scripts/Shared/jHandler.js"
               ));
            #endregion

            #region CSS
            bundles.Add(new StyleBundle("~/bundles/renderVCss").Include(
                "~/plugins/fontawesome-free/css/all.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/softblue/dx.softblue.compact.css",
                "~/Content/adminlte/css/adminlte.min.css",
                "~/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                "~/Content/myCustomerStyle.css",
                "~/Content/toastr.min.css",
                "~/Content/ladda-themeless.min.css",
                "~/Content/css/select2.min.css",
                "~/plugins/bootstra-multiselect/bootstrap-multiselect.min.css",
                "~/plugins/bootstrap-datepicker/css/datepicker3.css",
                "~/plugins/bootstrap-daterangepicker/daterangepicker.css",
                "~/plugins/data-table/jquery.dataTables.min.css",
                "~/plugins/jquery-confirm/jquery-confirm.css",
                "~/plugins/typeahead-0.11.1/typeaheadjs.css",
                "~/Content/jquery.datetimepicker.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/renderCss").Include(
                "~/plugins/fontawesome-free/css/all.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/softblue/dx.softblue.compact.css",
                "~/Content/adminlte/css/adminlte.min.css",
                "~/plugins/overlayScrollbars/css/OverlayScrollbars.min.css",
                "~/Content/myStyle.css",
                "~/Content/toastr.min.css",
                "~/Content/ladda-themeless.min.css",
                "~/Content/css/select2.min.css",
                "~/plugins/bootstra-multiselect/bootstrap-multiselect.min.css",
                "~/plugins/bootstrap-datepicker/css/datepicker3.css",
                "~/plugins/bootstrap-daterangepicker/daterangepicker.css",
                "~/plugins/data-table/jquery.dataTables.min.css",
                "~/plugins/jquery-confirm/jquery-confirm.css",
                "~/plugins/typeahead-0.11.1/typeaheadjs.css",
                "~/Content/jquery.datetimepicker.css"
                ));
            #endregion


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                    "~/Scripts/jquery-3.6.0.min.js",
                    "~/Scripts/dx/libs/babel-polyfill/polyfill.min.js",
                    "~/Scripts/bootstrap/js/bootstrap.bundle.min.js"
                //,"~/Scripts/jquery-3.6.0.intellisense.js"

                ));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                    "~/plugins/overlayScrollbars/js/OverlayScrollbars.min.js",
                    "~/plugins/numeraljs/numeral.min.js",
                    "~/Scripts/moment.min.js",
                    "~/Scripts/inputmask/jquery.inputmask.min.js",
                    "~/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js",
                    "~/plugins/bootstrap-daterangepicker/daterangepicker.min.js",
                    "~/Scripts/select2.min.js",
                    "~/plugins/bootstra-multiselect/bootstrap-multiselect.min.js",
                    "~/Scripts/toastr.min.js",
                    "~/Scripts/spin.min.js",
                    "~/Scripts/ladda.min.js",
                    "~/Content/adminlte/js/adminlte.min.js",
                    "~/plugins/jquery-confirm/jquery-confirm.js",
                    "~/plugins/typeahead-0.11.1/typeahead.bundle.min.js",
                    "~/plugins/typeahead-0.11.1/handlebars.min.js",
                    "~/Scripts/jquery.datetimepicker.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/devexjs").Include(
                    "~/Scripts/dx/libs/exceljs/exceljs.min.js",
                    "~/Scripts/dx/libs/FileSaver/FileSaver.min.js",
                    "~/Scripts/dx/libs/jspdf/jspdf.umd.min.js",
                    "~/Scripts/dx/libs/jspdf/jspdf.plugin.autotable.min.js",
                    "~/Scripts/dx/libs/jszip/jszip.min.js",
                   // "~/Scripts/dx/dx.all.js"
                    "~/Scripts/dx/dx.web.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/globalScripts").Include(
                   "~/Scripts/Shared/jHandler.js",
                   "~/Scripts/Shared/globalSettings.js"
               ));
            //bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            //"~/Scripts/inputmask/jquery.inputmask.js"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard1").Include("~/views/home/scripts/dashboard1.js"));
            bundles.Add(new ScriptBundle("~/bundles/groupwiseSaleDashboardForm").Include("~/views/home/child/scripts/groupwiseSaleDashboardForm.js"));
            bundles.Add(new ScriptBundle("~/bundles/areawiseSaleDashboardForm").Include("~/views/home/child/scripts/areawiseSaleDashboardForm.js"));
            bundles.Add(new ScriptBundle("~/bundles/statewiseSaleDashboardForm").Include("~/views/home/child/scripts/statewiseSaleDashboardForm.js"));
            //Cons Trans
            
            //Cons Masters
            bundles.Add(new ScriptBundle("~/bundles/masters/areaMaster").Include("~/views/masters/scripts/areaMaster.js"));

            //Cons CPanels
            bundles.Add(new ScriptBundle("~/bundles/cpanel/roleMaster").Include("~/views/cpanel/scripts/roleMaster.js"));
            bundles.Add(new ScriptBundle("~/bundles/cpanel/rolePermission").Include("~/views/cpanel/scripts/rolePermission.js"));
            bundles.Add(new ScriptBundle("~/bundles/cpanel/userMaster").Include("~/views/cpanel/scripts/userMaster.js"));

            BundleTable.EnableOptimizations = true;

        }
    }
}