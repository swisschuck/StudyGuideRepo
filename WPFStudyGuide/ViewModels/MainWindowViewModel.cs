using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes.Other;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Constants;
using WPFStudyGuide.ViewModels.Other;
using Unity;
using WPFStudyGuide.Helpers;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region fields

        private BaseViewModel _currentViewModel;

        #region examples
        private CommandsExampleViewModel _commandsExampleViewModel = new CommandsExampleViewModel();
        private AttachedPropertiesExampleViewModel _attachedPropertiesExampleViewModel = new AttachedPropertiesExampleViewModel();
        private PropertyChangeNotificationsExampleViewModel _propertyChangeNotificationsExampleViewModel = new PropertyChangeNotificationsExampleViewModel();
        private ViewFirstExampleViewModel _viewFirstExampleViewModel = new ViewFirstExampleViewModel();
        private ViewModelFirstExampleViewModel _viewModelFirstExampleViewModel = new ViewModelFirstExampleViewModel();
        private ViewModelLocaterExampleViewModel _viewModelLocaterExampleViewModel = new ViewModelLocaterExampleViewModel();
        private ParentAndChildViewsExampleViewModel _parentAndChildViewsExampleViewModel = new ParentAndChildViewsExampleViewModel();
        private PlaceOrderViewModel _placeOrderViewModel = new PlaceOrderViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel = new AddEditCustomerViewModel();
        private DependencyInjectionExampleViewModel _dependencyInjectionExampleViewModel;
        private AddEditCustomerDIViewModel _addEditCustomerDIViewModel;
        #endregion examples

        #endregion fields


        #region properties

        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                SetProperty(ref _currentViewModel, value);
            }
        }


        public MyFirstRelayCommand<string> NavigationCommand
        {
            get;
            private set;
        }

        #endregion properties


        #region constructors

        public MainWindowViewModel()
        {
            //CurrentViewModel = _initialViewModel;
            NavigationCommand = new MyFirstRelayCommand<string>(OnNavigationClicked);

            _dependencyInjectionExampleViewModel = ContainerHelpers.Container.Resolve<DependencyInjectionExampleViewModel>();
            _addEditCustomerDIViewModel = ContainerHelpers.Container.Resolve<AddEditCustomerDIViewModel>();

            _parentAndChildViewsExampleViewModel.PlaceOrderRequested += NavigateToOrder;
            _parentAndChildViewsExampleViewModel.AddCustomerRequested += NavigateToAddCustomer;
            _parentAndChildViewsExampleViewModel.EditCustomerRequested += NavigateToEditCustomer;

            _dependencyInjectionExampleViewModel.PlaceOrderRequested += NavigateToOrder;
            _dependencyInjectionExampleViewModel.AddCustomerRequested += NavigateToAddCustomerDI;
            _dependencyInjectionExampleViewModel.EditCustomerRequested += NavigateToEditCustomerDI;

            _addEditCustomerViewModel.Done += NavigateToCustomerList;
            _addEditCustomerDIViewModel.Done += NavigateToCustomerListDI;
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods

        private void LoadWindowResources()
        {
            
        }

        private void OnNavigationClicked(string destination)
        {
            CurrentViewModel = null;

            switch (destination)
            {
                #region Examples

                case CommandParameters.LoadCommandsExample:
                    CurrentViewModel = _commandsExampleViewModel;
                    break;

                case CommandParameters.LoadAttachedPropertiesExample:
                    CurrentViewModel = _attachedPropertiesExampleViewModel;
                    break;

                case CommandParameters.LoadPropertyChangedExample:
                    CurrentViewModel = _propertyChangeNotificationsExampleViewModel;
                    break;

                case CommandParameters.LoadViewFirstExample:
                    CurrentViewModel = _viewFirstExampleViewModel;
                    break;

                case CommandParameters.LoadViewModelFirstExample:
                    CurrentViewModel = _viewModelFirstExampleViewModel;
                    break;

                case CommandParameters.LoadModelLocaterExample:
                    CurrentViewModel = _viewModelLocaterExampleViewModel;
                    break;

                case CommandParameters.LoadParentAndChildViewsExample:
                    CurrentViewModel = _parentAndChildViewsExampleViewModel;
                    break;

                case CommandParameters.LoadDependencyInjectionExample:
                    CurrentViewModel = _dependencyInjectionExampleViewModel;
                    break;

                    #endregion Examples
            }
        }


        private void NavigateToOrder(Guid customerId)
        {
            _placeOrderViewModel.CustomerId = customerId;
            CurrentViewModel = _placeOrderViewModel;
        }


        private void NavigateToAddCustomer(SimpleCustomer customerToAdd)
        {
            _addEditCustomerViewModel.EditMode = false;
            _addEditCustomerViewModel.SetCustomer(customerToAdd);
            CurrentViewModel = _addEditCustomerViewModel;
        }

        private void NavigateToEditCustomer(SimpleCustomer customerToEdit)
        {
            _addEditCustomerViewModel.EditMode = true;
            _addEditCustomerViewModel.SetCustomer(customerToEdit);
            CurrentViewModel = _addEditCustomerViewModel;
        }


        private void NavigateToAddCustomerDI(SimpleCustomer customerToAdd)
        {
            _addEditCustomerDIViewModel.EditMode = false;
            _addEditCustomerDIViewModel.SetCustomer(customerToAdd);
            CurrentViewModel = _addEditCustomerDIViewModel;
        }

        private void NavigateToEditCustomerDI(SimpleCustomer customerToEdit)
        {
            _addEditCustomerDIViewModel.EditMode = true;
            _addEditCustomerDIViewModel.SetCustomer(customerToEdit);
            CurrentViewModel = _addEditCustomerDIViewModel;
        }

        private void NavigateToCustomerList()
        {
            CurrentViewModel = _parentAndChildViewsExampleViewModel;
        }

        private void NavigateToCustomerListDI()
        {
            CurrentViewModel = _dependencyInjectionExampleViewModel;
        }


        #endregion private methods
    }
}
