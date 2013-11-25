using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EDO.UI.WebUI.Models.JSON.Core
{
    [DataContract(Name = "Business", Namespace = "")]
    public class BusinessInfo
    {
        [DataMember(EmitDefaultValue = true)]
        public string Title { get; set; }
    }
}