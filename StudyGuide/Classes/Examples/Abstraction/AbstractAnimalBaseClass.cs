using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public abstract class AbstractAnimalBaseClass
    {
        // Abstract classes cannot be instantiated, they are used as a super class. The child or derived classes provide the actual
        // implementations of the members that are declared abstract inside the abstract class but unlike interfaces they CAN have 
        // their own implementations

        #region fields

        protected string _name;

        #endregion fields


        #region properties

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
        public List<String> FoodToEat;
        public string FirstThingFed
        {
            get
            {
                return getFirstThingFedToAnimal();
            }
        }

        // we cannot have abstract properties or fields
        //public abstract bool CanFly;

        #endregion properties


        #region constructors

        #endregion constructors


        #region public methods

        // these abstract methods can be overwritten in the derived classes
        public abstract string Sound();

        public abstract void AddFood(string foodToAdd);

        #endregion public methods


        #region private methods

        private string getFirstThingFedToAnimal()
        {
            if (FoodToEat != null && FoodToEat.Count > 0)
            {
                return FoodToEat.FirstOrDefault();
            }

            return "Animal has not been fed yet";
        }
        #endregion private methods
    }
}
