using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStudyGuide.Classes
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public Guid Id { get; set; }
        public Guid? StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public List<Order> Orders { get; set; }
    }
}
