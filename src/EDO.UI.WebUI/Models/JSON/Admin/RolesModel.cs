using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EDO.UI.WebUI.Models.JSON.Admin
{
    [DataContract(Name = "Role", Namespace = "")]
    public class RoleModel
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }

    [DataContract(Name = "Roles", Namespace = "")]
    public class RolesModel
    {
        [DataMember(Name = "Items")]
        public List<RoleModel> Items { get; set; }
        [DataMember(Name = "Total")]
        public int TotalItems
        {
            get
            {
                return Items.Count();
            }
        }

        public RolesModel()
        {
            Items = new List<RoleModel>();
        }
    }
}