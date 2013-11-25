using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDO.Model.Common.Entities
{
    [Table("Office")]
    public class Office : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsMainOffice { get; set; }

        public string Inn { get; set; }
        public string Ogrn { get; set; }
        public string Kpp { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string AdditionalContacts { get; set; }

        public OfficeEssentials OfficeEssentials { get; set; }
        public virtual Address Address { get; set; }

        public virtual Business Business { get; set; }

        public virtual List<UserProfile> Accounts { get; set; }

        public Office()
        {
            OfficeEssentials = new OfficeEssentials();
            Address = new Address();
            Business = new Business();
            Accounts = new List<UserProfile>();
        }
    }
}
