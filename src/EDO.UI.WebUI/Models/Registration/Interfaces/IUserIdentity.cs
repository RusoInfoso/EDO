using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDO.UI.WebUI.Models.Registration
{
    public interface IUserIdentity
    {
        string UserName { get; set; }
        string Password { get; set; }
        string Password2 { get; set; }
        string PassPhrase { get; set; }
    }
}
