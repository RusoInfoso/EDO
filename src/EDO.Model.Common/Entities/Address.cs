using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDO.Model.Common.Entities
{
    [Table("Address")]
    public class Address : Entity
    {
        public string Okato { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Punkt { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Office { get; set; }

        public string RawAddress { get; set; }
    }
}
