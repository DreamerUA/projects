using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Tutor.Core;
using System.Web.Optimization;
using Tutor.Web.App_Start;
using Tutor.Web.Models;

namespace Tutor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer(new DataDbInitializer());
            //Database.SetInitializer(new SkillDbInitializer());
            
        }
    }
}
