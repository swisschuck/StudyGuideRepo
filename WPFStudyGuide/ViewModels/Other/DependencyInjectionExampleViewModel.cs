using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WPFStudyGuide.Classes.Other;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.ViewModels.Other
{
    public class DependencyInjectionExampleViewModel : BaseViewModel
    {
        #region fields

        // so with our previous setup we were newing up an instance of the customer service here and in the child view model.
        // this is wastfull and not needed, really we should one instance of the service that is shared between the two views.

        //private ICustomerService _customerService = new CustomerServiceJSON();
        private ICustomerService _customerService;

        private ObservableCollection<SimpleCustomer> _customers;
        private List<SimpleCustomer> _allCustomers;
        private string _searchInput;

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

        public MyFirstRelayCommand ClearSearchCommand
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

        public string SearchInput
        {
            get
            {
                return _searchInput;
            }
            set
            {
                SetProperty(ref _searchInput, value);
                FilterCustomers(_searchInput);
            }
        }

        #endregion properties


        #region constructors

        // previous

        //public DependencyInjectionExampleViewModel()
        //{
        //    // if we are in design mode just return and do nothing so we dont cause problems
        //    if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
        //    {
        //        return;
        //    }

        //    ViewHeaderTitle = "Dependency Injection Example";
        //    PlaceOrderCommand = new MyFirstRelayCommand<SimpleCustomer>(OnPlaceOrder);
        //    AddCustomerCommand = new MyFirstRelayCommand(OnAddCustomer);
        //    EditCustomerCommand = new MyFirstRelayCommand<SimpleCustomer>(OnEditCustomer);
        //    DeleteCustomerCommand = new MyFirstRelayCommand<SimpleCustomer>(OnDeleteCustomer);
        //}

        // here we will add an instance of the customer service and pass it into our constructor
        // this will allow us to decouple the CustomerServiceJSON to this view model and just use the interface

        public DependencyInjectionExampleViewModel(ICustomerService _incomingCustomerService)
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }
            _customerService = _incomingCustomerService;

            ViewHeaderTitle = "Dependency Injection Example";
            PlaceOrderCommand = new MyFirstRelayCommand<SimpleCustomer>(OnPlaceOrder);
            AddCustomerCommand = new MyFirstRelayCommand(OnAddCustomer);
            EditCustomerCommand = new MyFirstRelayCommand<SimpleCustomer>(OnEditCustomer);
            DeleteCustomerCommand = new MyFirstRelayCommand<SimpleCustomer>(OnDeleteCustomer);
            ClearSearchCommand = new MyFirstRelayCommand(OnClearSearch);
        }

        #endregion constructors


        #region public methods

        public async void LoadCustomers()
        {
            // the view is calling this method via the interactivity:Interaction.Triggers, you will need the System.Windows.Interactivity sdk
            // from nuget (can normally be obtained from loading the solution in Visual Studio Blend).
            _allCustomers = await _customerService.GetCustomersAsync();
            Customers = new ObservableCollection<SimpleCustomer>(_allCustomers);
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

        private void FilterCustomers(string searchInput)
        {
            if (String.IsNullOrWhiteSpace(searchInput))
            {
                Customers = new ObservableCollection<SimpleCustomer>(_allCustomers);
            }
            else
            {
                Customers = new ObservableCollection<SimpleCustomer>
                                (
                                    _allCustomers.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower()))
                                );
            }
        }

        private void OnClearSearch()
        {
            SearchInput = null;
        }

        #endregion private methods
    }
}
