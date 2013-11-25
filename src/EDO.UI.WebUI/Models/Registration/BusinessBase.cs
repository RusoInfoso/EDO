using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Models.Registration
{
    [Serializable]
    public class BusinessBase : IBusinessRegStep
    {
        /**
         * Основные данные компании
         */
        //[Required]
        public string FullName { get; set; }
        //[Required]
        public string ShortName { get; set; }
                
        //[Required]
        public string Inn { get; set; }
        //[Required]
        public string Ogrn { get; set; }
        //[Required]
        public string Kpp { get; set; }
        //[Required]
        public string MainEmail { get; set; }
        //[Required]
        public string MainPhone { get; set; }
        //[Required]
        public string MainFax { get; set; }

        public string AdditionalEmails { get; set; }

        /**
         * Заявления
         */
        // Заявление на аккредитацию
        //[Required]
        public bool IsAccreditationStatement { get; set; }
        // Заявление на открытие счета
        //[Required]
        public bool IsInvoiceStatement { get; set; }
        
    }
}