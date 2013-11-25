using SimpleMembershipModule;
using System.Web.Http;
using System.Web.Hosting;
using EDO.UI.WebUI.Models;

namespace EDO.UI.WebUI.Controllers.Api
{

    [ApiRoledAuthorize]
    public class SiteMenuController : ApiController
    {
        public Menu Get()
        {
            var principal = ControllerContext.RequestContext.Principal;
            var path = HostingEnvironment.MapPath("~/App_Data/SiteMenu.xml");
            var parser = new MenuParser(principal);
            var menu = parser.LoadFromXMLFile(path);

            return menu;
        }
    }
}
