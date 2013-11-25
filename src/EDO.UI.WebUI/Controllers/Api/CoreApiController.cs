using EDO.Model.Common.Abstract;
using EDO.Model.Common.Abstract.Repositories;
using EDO.UI.WebUI.Models;
using EDO.UI.WebUI.Models.JSON.Core;
using EDO.UI.WebUI.Utils;
using SimpleMembershipModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace EDO.UI.WebUI.Controllers.Api
{
    [ApiRoledAuthorize]
    public class CoreApiController : ApiController
    {
        private IApplicationUnit _uow;

        public CoreApiController(IApplicationUnit appUnit)
        {
            _uow = appUnit;
        }

        public object Get()
        {
            var principal = ControllerContext.RequestContext.Principal;
            var userId = MembershipUtils.GetUserIdByName(principal.Identity.Name);

            var userProfile = _uow.UserProfiles.GetById(userId);
            if (userProfile == null)
            {
                return new HttpResponseException(Request.CreateResponse(HttpStatusCode.Unauthorized));
            }            

            return new
            {
                Data = new
                {
                    User = new UserInfo(userProfile)
                },
                Success = true
            };
        }
    }
}
