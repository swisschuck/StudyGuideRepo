using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class DerivedCatClass : AbstractAnimalBaseClass
    {
        #region fields
        #endregion fields


        #region properties

        public bool CanFly
        {
            get
            {
                return false;
            }
        }

        #endregion properties


        #region constructors

        public DerivedCatClass(string name)
        {
            base.Name = name;
            base.FoodToEat = new List<string>();
        }

        #endregion constructors


        #region public methods

        public override string Sound()
        {
            return "Meow";
        }

        public override void AddFood(string foodToAdd)
        {
            base.FoodToEat.Add(foodToAdd);
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
