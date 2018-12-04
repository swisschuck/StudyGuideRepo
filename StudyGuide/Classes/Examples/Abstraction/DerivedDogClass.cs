using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class DerivedDogClass : AbstractAnimalBaseClass
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

        public DerivedDogClass(string name)
        {
            base.Name = name;
            base.FoodToEat = new List<string>();
        }

        #endregion constructors


        #region public methods

        public override string Sound()
        {
            return "Bark";
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
