
using System;

namespace WPFStudyGuide.ViewModels.Other
{
    public class PlaceOrderViewModel : BaseViewModel
    {
        #region fields

        private Guid _customerId;

        #endregion fields


        #region properties

        public Guid CustomerId
        {
            get { return _customerId; }
            set { SetProperty(ref _customerId, value); }
        }

        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
