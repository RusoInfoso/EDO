using System.ComponentModel.DataAnnotations.Schema;

namespace EDO.Model.Common.Entities
{
    [Table("UserProfile")]
    public class UserProfile : Entity
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string PassPhrase { get; set; }

        public virtual Business Business { get; set; }
        public virtual Office Office { get; set; }
        public virtual UserPosition Position { get; set; }
        public virtual AccountType AccountType { get; set; }

        public UserProfile()
        {
            Business = new Business();
            Office = new Office();
            Position = new UserPosition();
            AccountType = new AccountType();
        }
    }
}
