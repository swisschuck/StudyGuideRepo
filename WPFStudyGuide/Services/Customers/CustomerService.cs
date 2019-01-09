using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes;

namespace WPFStudyGuide.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public Task<List<Customer>> GetCustomersAsync()
        {
            Task<List<Customer>> taskToReturn = Task.Run(() =>
            {
                return new List<Customer>();
            });

            return taskToReturn;
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            Task<Customer> taskToReturn = Task.Run(() =>
            {
                return new Customer();
            });

            return taskToReturn;
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            return new Customer();
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            return new Customer();
        }

        public async Task<bool> DeleteCustomerAsync(Guid customerId)
        {
            return true;
        }
        #endregion public methods


        #region private methods
        #endregion private methods
    }
}
