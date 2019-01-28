using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFStudyGuide.Classes.Other;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.ViewModels.Other
{
    public class AttachedPropertiesExampleViewModel : BaseViewModel
    {
        #region fields

        private ICustomerService _customerService = new CustomerServiceJSON();
        private SimpleCustomer _selectedCustomer;

        #endregion fields


        #region properties


        public string ErrorMessage { get; set; }
        public ObservableCollection<SimpleCustomer> Customers { get; set; }

        // we set the setter to private as this should only be set once during construction.
        public MyFirstRelayCommand DeleteCommand { get; private set; }

        public SimpleCustomer SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }
            set
            {
                _selectedCustomer = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }


        #endregion properties


        #region constructors

        public AttachedPropertiesExampleViewModel()
        {
            ViewHeaderTitle = "Attached Properties Example";
  
            DeleteCommand = new MyFirstRelayCommand(OnDeleteClicked, IsDeleteEnabled);
            // so with the MyMvvmBehaviors that we defined in the View, we dont have to call the load method here it will be called using Attached Properties
            // in class the demo he ran through this using Visual Studio Blend to get it working fully.
            //LoadCustomers();
        }

        #endregion constructors


        #region public methods

        public async void LoadCustomers()
        {
            // if we are in design mode just return and do nothing so we dont cause problems
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }

            Customers = new ObservableCollection<SimpleCustomer>(await _customerService.GetCustomersAsync(true));
        }

        public void OnDeleteClicked()
        {
            ErrorMessage = string.Empty;

            if (SelectedCustomer == null)
            {
                ErrorMessage = "Please select a row before deleting.";
                return;
            }

            Customers.Remove(SelectedCustomer);
        }

        public bool IsDeleteEnabled()
        {
            return SelectedCustomer != null;
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
