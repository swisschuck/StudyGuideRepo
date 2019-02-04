using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.Helpers
{
    // a helper class to help with Unity (Nuget package library) Containers
    public static class ContainerHelpers
    {
        // if you get the following error, try updating your System.Runtime.CompilerServices.Unsafe nuget package:

        // FileLoadException: Could not load file or assembly 'System.Runtime.CompilerServices.Unsafe, Version=4.0.4.1, Culture=neutral, 
        // PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies.The located assembly's manifest definition does not match the assembly 
        //reference. (Exception from HRESULT: 0x80131040)
        #region fields

        private static IUnityContainer _container;

        #endregion fields


        #region properties

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
        }
        #endregion properties


        #region constructors

        static ContainerHelpers()
        {
            _container = new UnityContainer();
            _container.RegisterType<ICustomerService, CustomerServiceJSON>(new ContainerControlledLifetimeManager());
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
