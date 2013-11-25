using System.Web.Http;
using System.Web.Mvc;
using EDO.Data.EFModelCommon.Repos;
using EDO.Model.Common.Abstract;
using EDO.Model.Common.Abstract.Repositories;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using System.Data.Entity;
using EDO.Data.EFModelCommon;

namespace EDO.UI.WebUI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();            
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IApplicationUnit, EFApplicationUnit>();
            //container.RegisterType<DbContext, EFDBContext>();
        }
    }
}