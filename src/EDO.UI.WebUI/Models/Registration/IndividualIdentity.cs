using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Models.Registration
{
    public class IndividualIdentity : IIndividualRegStep
    {
        // Идентификационные данные
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string PassPhrase { get; set; }
    }
}