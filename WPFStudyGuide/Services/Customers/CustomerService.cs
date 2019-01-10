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

        public Task<List<SimpleCustomer>> GetSimpleCustomersAsync()
        {
            Task<List<SimpleCustomer>> taskToReturn = Task.Run(() =>
            {
                return GetSimpleCustomersMocked();
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

        private List<SimpleCustomer> GetSimpleCustomersMocked()
        {
            List<SimpleCustomer> customersToSendBack = new List<SimpleCustomer>();

            for (int index = 0; index < 21; index++)
            {
                SimpleCustomer customer = new SimpleCustomer();
                customer.Id = new Guid();
                customer.FirstName = String.Format("FirstName{0}", index);
                customer.LastName = String.Format("LastName{0}", index);
                customer.Phone = String.Format("555-555-55{0}", index < 10 ? index + index : index);
                customer.State = "Colorado";
                customer.Street = String.Format("{0} fake street", index < 10 ? index + index : index);
                customer.Zip = "80001";
                customer.StoreId = new Guid();
                customersToSendBack.Add(customer);
            }

            return customersToSendBack;
        }
        #endregion private methods
    }
}
