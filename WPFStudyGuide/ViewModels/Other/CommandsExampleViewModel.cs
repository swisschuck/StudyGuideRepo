using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFStudyGuide.Classes;
using WPFStudyGuide.Commands.Other;
using WPFStudyGuide.Helpers;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.ViewModels.Other
{
    public class CommandsExampleViewModel : BaseViewModel
    {
        #region fields

        private ICustomerService _customerService = new CustomerService();
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

        public CommandsExampleViewModel()
        {
            // if we are in design mode just return and do nothing so we dont cause problems
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }

            ViewHeaderTitle = "Commands Example";
            // the .Result property on the task forces it to be syncronous
            Customers = new ObservableCollection<SimpleCustomer>(_customerService.GetSimpleCustomersAsync().Result);
            DeleteCommand = new MyFirstRelayCommand(OnDeleteClicked, IsDeleteEnabled);
        }

        #endregion constructors


        #region public methods

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
