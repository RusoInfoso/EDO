using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EDO.Model.Common.Entities
{
    [Table("Business")]
    public class Business : Entity
    {
        public string Title { get; set; }

        public string ShortTitle { get; set; }
        public bool IsAccreditated { get; set; }
        public bool IsInvoiceStatement { get; set; }

        public virtual List<Office> Offices { get; set; }

        public Business()
        {
            Offices = new List<Office>();
        }
    }
}
