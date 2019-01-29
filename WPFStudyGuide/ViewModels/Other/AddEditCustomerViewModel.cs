using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes.Other;
using WPFStudyGuide.Commands.Other;

namespace WPFStudyGuide.ViewModels.Other
{
    public class AddEditCustomerViewModel : BaseViewModel
    {
        #region fields

        private bool _editMode;
        private SimpleEditableCustomer _customer = null;
        private SimpleCustomer _editingCustomer = null;

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


        public SimpleEditableCustomer Customer
        {
            get
            {
                return _customer;
            }

            set
            {
                SetProperty(ref _customer, value);
            }
        }

        public MyFirstRelayCommand CancelCommand { get; private set; }
        public MyFirstRelayCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        #endregion properties


        #region constructors

        public AddEditCustomerViewModel()
        {
            ViewHeaderTitle = "Add/Edit Customer";
            CancelCommand = new MyFirstRelayCommand(OnCancel);
            SaveCommand = new MyFirstRelayCommand(OnSave, CanSave);
        }

        #endregion constructors


        #region public methods

        public void SetCustomer(SimpleCustomer incomingCustomer)
        {
            _editingCustomer = incomingCustomer;

            if (Customer != null)
            {
                // is there is an existing customer we want to unsubsribe so we dont leak memory
                Customer.ErrorsChanged -= RaiseCanExecuteChanged;
            }

            Customer = new SimpleEditableCustomer();
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
            CopyCustomer(incomingCustomer, Customer);
        }

        #endregion public methods


        #region private methods

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        private void CopyCustomer(SimpleCustomer source, SimpleEditableCustomer target)
        {
            target.Id = source.Id;
            
            if (EditMode)
            {
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Email = source.Email;
                target.Phone = source.Phone;
            }
        }

        private void UpdateCustomer(SimpleEditableCustomer source, SimpleCustomer target)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Phone = source.Phone;
            target.Email = source.Email;
        }

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            UpdateCustomer(Customer, _editingCustomer);

            if (EditMode)
            {
                // call update customer
            }
            else
            {
                // call add customer
            }

            Done();
        }


        private bool CanSave()
        {
            // check the Customer object for errors and send that back to the button for disabling/enabling
            return !Customer.HasErrors;
        }

        #endregion private methods
    }
}
