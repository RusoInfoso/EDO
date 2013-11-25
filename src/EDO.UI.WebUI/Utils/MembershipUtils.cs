using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace EDO.UI.WebUI.Utils
{
    public static class MembershipUtils
    {
        public static int GetUserIdByName(string name)
        {
            return WebSecurity.GetUserId(name);
        }

        public static int CreateUser(bool isAdmin = false)
        {
            return 0;
        }
    }
}