using EDO.Model.Common.Abstract;
using EDO.Model.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EDO.UI.WebUI.Models.JSON.Core
{

    [DataContract(Name = "User", Namespace = "")]
    public class UserInfo
    {
        private UserProfile _profile;

        [DataMember(EmitDefaultValue = false)]
        public int UserId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }


        [DataMember(EmitDefaultValue = false)]
        public BusinessInfo Business { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public OfficeInfo Office { get; set; }



        public UserInfo(UserProfile profile)
        {
            _profile = profile;

            UserId = _profile.Id;
            Name = _profile.UserName;

            Business = new BusinessInfo();
            Office = new OfficeInfo();

            if (_profile.Business != null)
            {                
                Business.Title = _profile.Business.Title;
            }

            if (_profile.Office != null)
            {
                Office.Title = _profile.Office.Title;
            }
        }
    }
}