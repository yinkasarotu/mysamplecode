using GraduationTracker.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GraduationTracker
{
    public static class UnityConfig
    {
        // public static Type IUserRepository { get; private set; }
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IRepository, Repository>();

            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
