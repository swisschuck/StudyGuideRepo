using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes.Other;

namespace WPFStudyGuide.Services.Customers
{
    class CustomerServiceEF : ICustomerService
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public Task<bool> AddCustomerAsync(SimpleCustomer customerToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCustomerAsync(SimpleCustomer customerToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleCustomer> GetCustomerAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SimpleCustomer>> GetCustomersAsync(bool getMockedData = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomerAsync(SimpleCustomer customerToUpdate)
        {
            throw new NotImplementedException();
        }


        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
