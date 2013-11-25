using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Models.Registration
{
    public class BusinessContacts : IBusinessRegStep
    {
        // Руководитель
        public string Position { get; set; }        
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        
        // Идентификационные данные
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string PassPhrase { get; set; }
    }
}