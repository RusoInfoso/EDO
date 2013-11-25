
namespace EDO.UI.WebUI.Models.Registration
{
    public class PrivateInfo : IPrivateRegStep
    {
        public string Bik { get; set; }
        public string PersonalAccount { get; set; }
        public string SettlementAccount { get; set; }
        public string CorrespondentAccount { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }

        // Адрес
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Punkt { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Appartment { get; set; }
    }
}