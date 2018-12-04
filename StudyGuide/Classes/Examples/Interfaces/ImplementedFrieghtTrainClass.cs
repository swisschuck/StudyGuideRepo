using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    public class ImplementedFrieghtTrainClass : IVehicle
    {

        #region fields

        private string _vehicleType;
        private List<string> _goodsInTrain;

        #endregion fields


        #region properties

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

        public List<string> ItemsInVehicle
        {
            get
            {
                return _goodsInTrain;
            }
        }

        #endregion properties


        #region constructors

        public ImplementedFrieghtTrainClass(string type)
        {
            _vehicleType = type;
            _goodsInTrain = new List<string>();
        }
        #endregion constructors


        #region public methods

        public bool IsUsedToTransportGoods()
        {
            return true;
        }
        public void AddItemToVehicle(string itemToStore)
        {
            if (_goodsInTrain != null)
            {
                _goodsInTrain.Add(itemToStore);
            }
        }

        public string GetFirstItemInVehicle()
        {
            if (_goodsInTrain != null && _goodsInTrain.Count > 0)
            {
                return _goodsInTrain.FirstOrDefault();
            }
            else
            {
                return "There is nothing in the train.";
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
