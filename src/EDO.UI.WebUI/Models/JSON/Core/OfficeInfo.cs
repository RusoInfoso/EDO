using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EDO.UI.WebUI.Models.JSON.Core
{
    [DataContract(Name = "Office", Namespace = "")]
    public class OfficeInfo
    {
        [DataMember(EmitDefaultValue = true)]
        public string Title { get; set; }
    }
}