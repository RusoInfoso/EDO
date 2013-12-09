using EDO.Model.Common.Abstract;
using EDO.UI.WebUI.Models.JSON.Admin;
using EDO.UI.WebUI.Utils;
using SimpleMembershipModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EDO.UI.WebUI.Controllers.Api
{
    [ApiRoledAuthorize(Roles = "Administrator")]
    public class RolesController : ApiController
    {
        private IApplicationUnit _uow;

        public RolesController(IApplicationUnit appUnit)
        {
            _uow = appUnit;
        }

        public RolesModel Get()
        {
            var roles = new RolesModel();
            var items = MembershipUtils.GetRolesList();

            foreach(var item in items)
	        {
                roles.Items.Add(new RoleModel { Name = item });
	        }

            return roles;
        }
    }
}
