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
            // approach via @encosia at: http://bit.ly/10EEHlQ
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // approach via @John_Papa at: http://jpapa.me/NqC2HH
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new ValidationActionFilter());
        }
    }
}