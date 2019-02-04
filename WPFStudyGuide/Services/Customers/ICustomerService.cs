using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStudyGuide.Classes;
using WPFStudyGuide.Classes.Other;

namespace WPFStudyGuide.Services.Customers
{
    public interface ICustomerService
    {
        Task<List<SimpleCustomer>> GetCustomersAsync(bool getMockedData = false);
        Task<SimpleCustomer> GetCustomerAsync(Guid id);
        Task<bool> AddCustomerAsync(SimpleCustomer customerToAdd);
        Task<bool> UpdateCustomerAsync(SimpleCustomer customerToUpdate);
        Task<bool> DeleteCustomerAsync(SimpleCustomer customerToDelete);
    }
}
