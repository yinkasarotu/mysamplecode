using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GraduationTracker
{
    public static class UnityCommon
    {
        static IUnityContainer _container;

        public static IUnityContainer GetContainer(bool forceRefresh = false)
        {
            if (_container == null || forceRefresh)
            {
                _container = new UnityContainer();
                //_container.LoadConfiguration(Common.RequiredAppConfiguration("UnityContainer"));


            }

            return _container;
        }
    }
}
