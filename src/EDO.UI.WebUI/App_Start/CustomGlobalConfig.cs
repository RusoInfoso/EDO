using EDO.UI.WebUI.Filters;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Validation.Providers;

namespace EDO.UI.WebUI
{
    public static class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}