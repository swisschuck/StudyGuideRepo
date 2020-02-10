using MvcStudyGuide_NinjectDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStudyGuide_NinjectDI.Models
{
    public class Samurai
    {
        public IWeapon Weapon;

        public Samurai(IWeapon weapon)
        {
            this.Weapon = weapon;
        }

        public string Strike()
        {
            string message = Weapon.Strike();
            return message;
        }
    }
}
