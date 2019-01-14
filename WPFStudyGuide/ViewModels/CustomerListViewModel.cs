using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes;
using WPFStudyGuide.Services.Customers;

namespace WPFStudyGuide.ViewModels
{
    public class CustomerListViewModel
    {
        #region fields

        private ICustomerService _customerService = new CustomerService();

        #endregion fields


        #region properties

        public ObservableCollection<SimpleCustomer> Customers { get; set; }

        #endregion properties


        #region constructors
        public CustomerListViewModel()
        {
            // if we are in design mode just return and do nothing so we dont cause problems
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                return;
            }

            // the .Result property on the task forces it to be syncronous
            Customers = new ObservableCollection<SimpleCustomer>(_customerService.GetSimpleCustomersAsync().Result);
        }

        #endregion constructors


        #region public methods
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
