using System.Web;
using System.Web.Optimization;

namespace PYS_Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Content/jquery/jquery.min.js",
                "~/Content/jquery-ui/jquery-ui.min.js",
                "~/Content/bootstrap/js/bootstrap.min.js",
                "~/Scripts/app/common.js" ,
                "~/Scripts/app/UtilScritp.js",
                //"~/Content/raphael/raphael.min.js",
                "~/Content/plugins/pace/pace.min.js",
                //"~/Content/morris.js/morris.min.js",
                //"~/Content/jquery-sparkline/js/jquery.sparkline.min.js",
                //"~/Content/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                //"~/Content/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                //"~/Content/jquery-knob/js/jquery.knob.min.js",
                "~/Content/moment/min/moment.min.js",
                "~/Content/bootstrap-daterangepicker/daterangepicker.js",
                "~/Content/bootstrap-datepicker/js/bootstrap-datepicker.min.js",
                "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                "~/Content/jquery-slimscroll/jquery.slimscroll.min.js",
                "~/Content/fastclick/lib/fastclick.js",
                "~/Content/AdminLTE/js/adminlte.min.js",               
                "~/Content/AdminLTE/js/pages/dashboard.js",
                "~/Content/AdminLTE/js/demo.js",
                "~/Content/alertifyjs/alertify.min.js",
                "~/Content/Cleave/cleave.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jsTables").Include(
                        "~/Content/datatables.net/js/jquery.dataTables.min.js",
                        "~/Content/datatables.net-bs/js/dataTables.bootstrap.min.js"                        
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/bootstrap/css/bootstrap.min.css",
                    "~/Content/font-awesome/css/font-awesome.min.css",
                    "~/Content/Ionicons/css/ionicons.min.css",
                    "~/Content/AdminLTE/css/AdminLTE.min.css",                
                    "~/Content/AdminLTE/css/skins/_all-skins.min.css",
                    "~/Content/PACE/themes/orange/pace-theme-custom-flash.css",
                    //"~/Content/morris.js/morris.css",
                    //"~/Content/jvectormap/jquery-jvectormap.css",
                    "~/Content/bootstrap-datepicker/css/bootstrap-datepicker.min.css",
                    "~/Content/bootstrap-daterangepicker/daterangepicker.css",
                    "~/Content/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css",
                    "~/Content/datatables.net-bs/css/dataTables.bootstrap.min.css",
                    "~/Content/cssEstilosGenerales/general.css",
                    "~/Content/alertifyjs/css/alertify.core.css",
                    //"~/Content/alertifyjs/css/alertify.min.css",
                    "~/Content/alertifyjs/css/alertify.bootstrap.css"
               
                    ));
            bundles.Add(new ScriptBundle("~/bundles/jsValidacion").Include(
                 "~/Scripts/jquery.form.min.js",
                 "~/Scripts/jquery.validate.min.js",
                 "~/Scripts/jquery.validate.unobtrusive.min.js",
                 "~/Scripts/myScripts/cleave.validarCampos.js"
                ));
        }
    }
}