using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Models.Registration
{
    [Serializable]
    public class IndividualBase : IIndividualRegStep
    {
        /**
         * Основные данные компании
         */
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }

        public string Inn { get; set; }
        public string MainEmail { get; set; }
        public string MainPhone { get; set; }
        public string MainFax { get; set; }

        public string AdditionalEmails { get; set; }

        /**
         * Заявления
         */
        // Заявление на аккредитацию
        public bool IsAccreditationStatement { get; set; }
        // Заявление на открытие счета
        public bool IsInvoiceStatement { get; set; }
    }
}