using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class DerivedBirdClass : AbstractAnimalBaseClass
    {
        #region fields
        private List<string> _foodForBirdToEat;
        #endregion fields


        #region properties

        public bool CanFly
        {
            get
            {
                return true;
            }
        }

        public string FirstThingFed
        {
            get
            {
                if (_foodForBirdToEat != null && _foodForBirdToEat.Count > 0)
                {
                    return _foodForBirdToEat.FirstOrDefault();
                }
                else
                {
                    return "bird has not been fed yet";
                }
            }
        }

        #endregion properties


        #region constructors

        public DerivedBirdClass(string name)
        {
            base.Name = name;
            _foodForBirdToEat = new List<string>();
        }
        #endregion constructors


        #region public methods

        public override string Sound()
        {
            return "Chirp";
        }

        // here (for example purposes) we want to store the food for the bird in its own private field
        public override void AddFood(string foodToAdd)
        {
            _foodForBirdToEat.Add(foodToAdd);
        }

        #endregion public methods


        #region private methods
        #endregion private methods

    }
}
