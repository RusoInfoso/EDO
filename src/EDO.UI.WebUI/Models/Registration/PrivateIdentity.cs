
namespace EDO.UI.WebUI.Models.Registration
{
    public class PrivateIdentity : IPrivateRegStep
    {
        // Идентификационные данные
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string PassPhrase { get; set; }
    }
}