using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes.Other;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Constants;
using WPFStudyGuide.ViewModels.Other;

namespace WPFStudyGuide.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region fields

        private BaseViewModel _currentViewModel;
        private CommandsExampleViewModel _commandsExampleViewModel = new CommandsExampleViewModel();
        private AttachedPropertiesExampleViewModel _attachedPropertiesExampleViewModel = new AttachedPropertiesExampleViewModel();
        private PropertyChangeNotificationsExampleViewModel _propertyChangeNotificationsExampleViewModel = new PropertyChangeNotificationsExampleViewModel();
        private ViewFirstExampleViewModel _viewFirstExampleViewModel = new ViewFirstExampleViewModel();
        private ViewModelFirstExampleViewModel _viewModelFirstExampleViewModel = new ViewModelFirstExampleViewModel();
        private ViewModelLocaterExampleViewModel _viewModelLocaterExampleViewModel = new ViewModelLocaterExampleViewModel();
        private ParentAndChildViewsExampleViewModel _parentAndChildViewsExampleViewModel = new ParentAndChildViewsExampleViewModel();
        private PlaceOrderViewModel _placeOrderViewModel = new PlaceOrderViewModel();
        private AddEditCustomerViewModel _addEditCustomerViewModel = new AddEditCustomerViewModel();

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
            _parentAndChildViewsExampleViewModel.PlaceOrderRequested += NavigateToOrder;
            _parentAndChildViewsExampleViewModel.AddCustomerRequested += NavigateToAddCustomer;
            _parentAndChildViewsExampleViewModel.EditCustomerRequested += NavigateToEditCustomer;
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

        #endregion private methods
    }
}
