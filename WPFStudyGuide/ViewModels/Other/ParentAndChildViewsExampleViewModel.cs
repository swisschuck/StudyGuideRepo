using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFStudyGuide.Classes.Other;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.ViewModels.Other
{
    public class ParentAndChildViewsExampleViewModel : BaseViewModel
    {
        #region fields

        private ICustomerService _customerService = new CustomerServiceJSON();
        private ObservableCollection<SimpleCustomer> _customers;

        #endregion fields


        #region properties

        public event Action<Guid> PlaceOrderRequested = delegate { };
        public event Action<SimpleCustomer> AddCustomerRequested = delegate { };
        public event Action<SimpleCustomer> EditCustomerRequested = delegate { };
        public event Action<SimpleCustomer> DeleteCustomerRequested = delegate { };

        public MyFirstRelayCommand<SimpleCustomer> PlaceOrderCommand
        {
            get;
            private set;
        }

        public MyFirstRelayCommand AddCustomerCommand
        {
            get;
            private set;
        }

        public MyFirstRelayCommand<SimpleCustomer> EditCustomerCommand
        {
            get;
            private set;
        }

        public MyFirstRelayCommand<SimpleCustomer> DeleteCustomerCommand
        {
            get;
            private set;
        }

        public ObservableCollection<SimpleCustomer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                SetProperty(ref _customers, value);
            }
        }

        #endregion properties


        #region constructors

        public ParentAndChildViewsExampleViewModel()
        {
            // if we are in design mode just return and do nothing so we dont cause problems
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }

            ViewHeaderTitle = "Parent and Child view example";
            PlaceOrderCommand = new MyFirstRelayCommand<SimpleCustomer>(OnPlaceOrder);
            AddCustomerCommand = new MyFirstRelayCommand(OnAddCustomer);
            EditCustomerCommand = new MyFirstRelayCommand<SimpleCustomer>(OnEditCustomer);
            DeleteCustomerCommand = new MyFirstRelayCommand<SimpleCustomer>(OnDeleteCustomer);
        }

        #endregion constructors


        #region public methods

        public async void LoadCustomers()
        {
            // the view is calling this method via the interactivity:Interaction.Triggers, you will need the System.Windows.Interactivity sdk
            // from nuget (can normally be obtained from loading the solution in Visual Studio Blend).
            Customers = new ObservableCollection<SimpleCustomer>(await _customerService.GetCustomersAsync());
        }

        #endregion public methods


        #region private methods

        private void OnPlaceOrder(SimpleCustomer customer)
        {
            // in order to load up the place order child view we need to communicate with the MainWindow view so we can replace this view with
            // the view we want. There are many ways to do this but we are going to raise an event in the child that the parent can handle.
            PlaceOrderRequested(customer.Id);
        }

        private void OnAddCustomer()
        {
            AddCustomerRequested(new SimpleCustomer { Id = Guid.NewGuid() });
        }


        private void OnEditCustomer(SimpleCustomer customerToEdit)
        {
            EditCustomerRequested(customerToEdit);
        }

        private async void OnDeleteCustomer(SimpleCustomer customerToDelete)
        {
            bool deleteStatus = await _customerService.DeleteCustomerAsync(customerToDelete);
            LoadCustomers();
        }

        #endregion private methods
    }
}
