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
        [HttpGet]
        public RolesModel Get()
        {
            var roles = new RolesModel();
            var items = MembershipUtils.GetRolesList();

            foreach (var item in items)
            {
                roles.Items.Add(new RoleModel { Name = item });
            }

            return roles;
        }

        [HttpPost]
        public HttpResponseMessage Post(RoleModel role)
        {
            var newRole = role.Name;

            try
            {
                if (MembershipUtils.IsRoleExists(newRole)) throw new Exception("Роль существует");
                MembershipUtils.CreateRole(newRole);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(RoleModel role)
        {
            try
            {
                MembershipUtils.DeleteRole(role.Name);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { Message = ex.Message });
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
