using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class ImplementedCarClass : IVehicle
    {
        #region fields

        private string _vehicleType;
        private List<string> _peopleInCar;

        #endregion fields


        #region properties

        public List<string> ItemsInVehicle
        {
            get
            {
                return _peopleInCar;
            }
        }

        public string VehicleType
        {
            get
            {
                return _vehicleType;
            }
            set
            {
                _vehicleType = value;
            }
        }
        #endregion properties


        #region constructors

        public ImplementedCarClass(string type)
        {
            _vehicleType = type;
            _peopleInCar = new List<string>();
        }

        #endregion constructors


        #region public methods

        public bool IsUsedToTransportGoods()
        {
            return false;
        }
        public void AddItemToVehicle(string personToStore)
        {
            if (_peopleInCar != null)
            {
                _peopleInCar.Add(personToStore);
            }
        }

        public string GetFirstItemInVehicle()
        {
            if (_peopleInCar != null && _peopleInCar.Count > 0)
            {
                return _peopleInCar.FirstOrDefault();
            }
            else
            {
                return "There is nobody in the car.";
            }
        }

        public IEnumerator GetEnumerator()
        {
            return ItemsInVehicle.GetEnumerator();
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
