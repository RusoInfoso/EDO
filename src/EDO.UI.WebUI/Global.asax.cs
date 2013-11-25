using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using EDO.UI.WebUI.Models;
using EDO.UI.WebUI.Models.Binders;
using EDO.UI.WebUI.Models.Registration;
using System.Web.Optimization;

namespace EDO.UI.WebUI
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Код, выполняемый при запуске приложения
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);     
       
            Bootstrapper.Initialise();

            ModelBinders.Binders.Add(typeof(IRegistrationStepVM), new RegStepViewModelBinder());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CustomGlobalConfig.Customize(GlobalConfiguration.Configuration);
        }
    }
}