using MvcStudyGuide_NinjectDI.Interfaces;
using MvcStudyGuide_NinjectDI.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStudyGuide_NinjectDI.Modules
{
    // This class is inherited from NinjectModule (namespace Ninject.Modules) and tells Ninject how to resolve the dependency for the IWeapon interface.
    public class WarriorModule : NinjectModule
    {
        //public override void Load()
        //{
        //    //provide me an object of the Sword class whenever there is a dependency of IWeapon interface.
        //    this.Bind<IWeapon>().To<Sword>();
        //}

        // https://hackernoon.com/ddd-5a1x3zl2
        // this module can now be called via one  of Ninjects scopes:
        //====================================================================================
        // Transient - A new instance of the type will be created each
        //             time one is requested.This is the default scope if none is specified.
        //             Specified as .InTransientScope().
        //
        // Singleton - Only a single instance of the type will be created, and the same 
        //             instance will be returned for each subsequent request.Specified as .InSingletonScope().
        //
        // Thread - One instance of the type will be created per thread. Specified as .InThreadScope().
        //
        // Request - One instance of the type will be created for each Web Request.Specified as .InRequestScope().
        //
        // Example calling: this.Bind<IWeapon>().To<Sword>().InTransientScope();


        string Name;
        public WarriorModule(string name)
        {
            Name = name;
        }

        public override void Load()
        {
            if (Name == "Sword")
            {
                this.Bind<IWeapon>().To<Sword>();
            }
            else if (Name == "Arrow")
            {
                this.Bind<IWeapon>().To<Arrow>();
            }
            else if (Name == "Gun")
            {
                this.Bind<IWeapon>().To<Gun>();
            }
        }


    }
}
