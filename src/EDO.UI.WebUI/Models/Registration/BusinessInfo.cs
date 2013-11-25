using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI.Models.Registration
{
    public class BusinessInfo : IBusinessRegStep
    {
        public string Bik { get; set; }
        public string PersonalAccount { get; set; }
        public string SettlementAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }

        // Юр адрес
        public string Okato { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Punkt { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Office { get; set; }

        // Почтовый адрес
        public bool IsAddressesEqual { get; set; }
        public string RealAddress { get; set; }
    }
}