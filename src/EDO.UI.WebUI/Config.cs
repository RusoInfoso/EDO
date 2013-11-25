using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EDO.UI.WebUI
{
    /**
     * Упрощенный доступ к настройками в Web.Config и дефолтные значения
     */
    public class Config
    {
        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"]
                    != null)
                {
                    return ConfigurationManager
                        .AppSettings["ConnectionStringName"].ToString();
                }

                return "DefaultConnection";
            }
        }
    }
}