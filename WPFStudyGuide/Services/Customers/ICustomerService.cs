using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes;
using WPFStudyGuide.Classes.Other;

namespace WPFStudyGuide.Services.Customers
{
    interface ICustomerService
    {
        Task<List<SimpleCustomer>> GetCustomersAsync();
        Task<List<SimpleCustomer>> GetSimpleCustomersAsync();
        Task<SimpleCustomer> GetCustomerAsync(Guid id);
        Task<SimpleCustomer> AddCustomerAsync(SimpleCustomer customer);
        Task<SimpleCustomer> UpdateCustomerAsync(SimpleCustomer customer);
        Task<bool> DeleteCustomerAsync(Guid customerId);
    }
}
