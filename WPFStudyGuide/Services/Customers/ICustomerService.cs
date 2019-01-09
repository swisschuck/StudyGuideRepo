using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes;

namespace WPFStudyGuide.Services.Customers
{
    interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<List<SimpleCustomer>> GetSimpleCustomersAsync();
        Task<Customer> GetCustomerAsync(Guid id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(Guid customerId);
    }
}
