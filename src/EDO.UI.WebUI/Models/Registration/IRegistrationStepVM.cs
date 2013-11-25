using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDO.UI.WebUI.Models.Registration
{
    public interface IRegistrationStepVM
    {
    }

    public interface IIndividualRegStep : IRegistrationStepVM { }

    public interface IBusinessRegStep : IRegistrationStepVM { }

    public interface IPrivateRegStep : IRegistrationStepVM { }
}
