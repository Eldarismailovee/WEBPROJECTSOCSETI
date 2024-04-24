using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
     "~/Scripts/jquery.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
    "~/Scripts/bootstrap.bundle.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery-easing").Include(
    "~/Scripts/jquery.easing.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom-app").Include(
    "~/Scripts/app.js"));
            bundles.Add(new ScriptBundle("~/bundles/counter-init").Include("~/Scripts/counter.init.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrapmin/css").Include(
        "~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/bundles/pe-icons/css").Include(
    "~/Content/pe-icon-7-stroke.css"));
            bundles.Add(new StyleBundle("~/bundles/custom/css").Include(
    "~/Content/style.css"));

            bundles.Add(new StyleBundle("~/bundles/material-icons/css").Include(
    "~/Content/materialdesignicons.min.css"));



        }
    }
}