using System.Web.Mvc;
using SimpleMembershipModule;

namespace EDO.UI.WebUI.Controllers
{
    [RoledAuthorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}