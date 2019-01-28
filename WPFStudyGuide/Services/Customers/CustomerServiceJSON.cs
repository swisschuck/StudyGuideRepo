using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes;
using WPFStudyGuide.Classes.Other;

namespace WPFStudyGuide.Services.Customers
{
    public class CustomerServiceJSON : ICustomerService
    {
        #region fields
        #endregion fields


        #region properties
        #endregion properties


        #region constructors
        #endregion constructors


        #region public methods

        public Task<SimpleCustomer> GetCustomerAsync(Guid id)
        {
            Task<SimpleCustomer> taskToReturn = Task.Run(() =>
            {
                return new SimpleCustomer();
            });

            return taskToReturn;
        }

        public Task<List<SimpleCustomer>> GetCustomersAsync(bool getMockedData = false)
        {
            Task<List<SimpleCustomer>> taskToReturn = Task.Run(() =>
            {
                if (getMockedData)
                {
                    return GetSimpleCustomersMocked();
                }
                return new List<SimpleCustomer>();
            });

            return taskToReturn;
        }


        public async Task<SimpleCustomer> AddCustomerAsync(SimpleCustomer customer)
        {
            return new SimpleCustomer();
        }

        public async Task<SimpleCustomer> UpdateCustomerAsync(SimpleCustomer customer)
        {
            return new SimpleCustomer();
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

            for (int index = 0; index < 20; index++)
            {
                SimpleCustomer customer = new SimpleCustomer();
                customer.Id = Guid.NewGuid();
                customer.FirstName = String.Format("FirstName{0}", index);
                customer.LastName = String.Format("LastName{0}", index);
                customer.Email = String.Format("test{0}@fake.com", index);
                customer.Phone = String.Format("555-555-55{0}", index < 10 ? String.Concat(index, index) : index.ToString());
                customer.State = "Colorado";
                customer.Street = String.Format("{0} fake street", index < 10 ? String.Concat(index, index) : index.ToString());
                customer.City = "Denver";
                customer.Zip = "80001";
                customer.StoreId = new Guid();
                customersToSendBack.Add(customer);
            }

            return customersToSendBack;
        }
        #endregion private methods
    }
}
