using System.Web.Mvc;

namespace EDO.UI.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}
