using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Tutor.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.rateyo.js",
                        "~/Scripts/jquery-2.2.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/jquery-ui.css",
                      "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/newcss").Include(
                      "~/Content/newbootstrap.min.css",
                       "~/Content/newbootstrap-theme.css",
                        "~/Content/jquery.rateyo.css",
                       "~/Content/newfont-awesome.min.css",
                      "~/Content/newmain.css"));

            bundles.Add(new ScriptBundle("~/bundles/newjs").Include(
                        "~/Scripts/newgoogle-map.js",
                        "~/Scripts/newheadroom.min.js",
                        "~/Scripts/jQuery.headroom.min.js",
                        "~/Scripts/newtemplate.js"));

        }
    }
}