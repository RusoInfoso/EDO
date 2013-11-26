using EDO.UI.WebUI.Models;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.Web;
using Microsoft.Web.Mvc;
using EDO.UI.WebUI.Models.Registration;
using EDO.Model.Common.Abstract;
using System;
using EDO.UI.WebUI.Utils;
using EDO.Model.Common.Entities;

// http://stackoverflow.com/questions/6402628/multi-step-registration-process-issues-in-asp-net-mvc-splitted-viewmodels-sing/6403485#6403485


namespace EDO.UI.WebUI.Controllers
{
    public class RegistrationController : Controller
    {
        private IApplicationUnit _uow;

        public RegistrationController(IApplicationUnit appUnit)
        {
            _uow = appUnit;
        }

        public ActionResult Index()
        {
            var wizard = new RegistrationViewModel();

            return View(wizard);
        }

        [HttpPost]
        public ActionResult Index([Deserialize]RegistrationViewModel wizard, IRegistrationStepVM step)
        {
            wizard.Steps[wizard.CurrentStepIndex] = step;

            if(ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(Request["next"]))
                {
                    wizard.GetNextStep();
                }
                else if (!string.IsNullOrEmpty(Request["prev"]))
                {
                    wizard.GetPreviousStep();
                }
                else
                {
                    try
                    {
                        IUserIdentity identity = wizard.GetUserIdentity();
                        int userId = MembershipUtils.CreateUser(identity.UserName, identity.Password);

                        UserProfile user = _uow.UserProfiles.GetById(userId);

                        if(user == null)
                        {
                            throw new Exception("Ошибка регистрации");
                        }


                    }
                    catch(Exception ex)
                    {
                        ModelState.AddModelError("saveError", ex);
                        return View(wizard);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            else if(!string.IsNullOrEmpty(Request["prev"]))
            {
                // Even if validation failed we allow the user to
                // navigate to previous steps
                wizard.GetPreviousStep();
            }

            return View(wizard);
        }
	}
}