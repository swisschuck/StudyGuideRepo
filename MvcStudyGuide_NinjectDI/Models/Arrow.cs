using MvcStudyGuide_NinjectDI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStudyGuide_NinjectDI.Models
{
    public class Arrow : IWeapon
    {
        public string Strike()
        {
            return "Samurai strikes with Arrow";
        }
    }
}
