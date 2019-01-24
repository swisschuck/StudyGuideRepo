using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFStudyGuide.Classes;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.ViewModels.Other
{
    public class PropertyChangeNotificationsExampleViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region fields

        private ICustomerService _customerService = new CustomerService();
        private SimpleCustomer _selectedCustomer;
        private ObservableCollection<SimpleCustomer> _customers;

        #endregion fields


        #region properties

        // delegate { } - assigning an empty anonymous delegate in as a subscriber which means that property will always be in the list
        // and you never have to worry about that property being null.
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        // we set the setter to private as this should only be set once during construction.
        public MyFirstRelayCommand DeleteCommand { get; private set; }

        public MyFirstRelayCommand ChangeCustomerCommand { get; private set; }

        public string ErrorMessage { get; set; }

        public ObservableCollection<SimpleCustomer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                if (_customers != value)
                {
                    _customers = value;
                    //PropertyChanged(this, new PropertyChangedEventArgs("Customers"));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Customers))); // new to C# 6.0, a way to get the property name so we dont have magic strings
                }
            }
        }

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
                // having this here is not really needed cause the view is handling this but if a viewmodel implements the INotifyPropertyChanged its good 
                // practice to have all public properties follow the pattern
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedCustomer"));
            }
        }


        #endregion properties


        #region constructors

        public PropertyChangeNotificationsExampleViewModel()
        {
            DeleteCommand = new MyFirstRelayCommand(OnDeleteClicked, IsDeleteEnabled);
            ChangeCustomerCommand = new MyFirstRelayCommand(OnCustomerChangedClicked);
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

            ViewHeaderTitle = "Property Change Notifications Example";

            Customers = new ObservableCollection<SimpleCustomer>(await _customerService.GetSimpleCustomersAsync());
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


        public void OnCustomerChangedClicked()
        {
            SimpleCustomer SC = SelectedCustomer;
            SC.FirstName = "Changed in background";
        }

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
