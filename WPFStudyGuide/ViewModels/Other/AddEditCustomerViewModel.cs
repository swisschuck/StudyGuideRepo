using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes.Other;

namespace WPFStudyGuide.ViewModels.Other
{
    public class AddEditCustomerViewModel : BaseViewModel
    {
        #region fields

        private bool _editMode;
        private SimpleCustomer _customerToEdit;

        #endregion fields


        #region properties

        public bool EditMode
        {
            get
            {
                return _editMode;
            }

            set
            {
                SetProperty(ref _editMode, value);
            }
        }

        #endregion properties


        #region constructors

        public AddEditCustomerViewModel()
        {

        }

        #endregion constructors


        #region public methods

        public void SetCustomer(SimpleCustomer customer)
        {
            _customerToEdit = customer;
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
