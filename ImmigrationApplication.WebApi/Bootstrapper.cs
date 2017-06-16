using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using ImmigrationApplication.DataAccess;
using ImmigrationApplication.WebApi.Controllers;
using ImmigrationApplication.WebApi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace ImmigrationApplication.WebApi
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
            container.RegisterType<DbContext, ApplicationDbContext>(
           new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(
                new InjectionConstructor());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new InjectionConstructor(typeof(ApplicationDbContext)));
        container.RegisterType<IUnitOfWork, UnitOfWork>();
    }
  }
}