using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4_MVC_Razor.Models
{
    public interface ICustomerRepository
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer GetCustomer(int customerId);

        public Customer AddCustomer(Customer newCustomer);
        public Customer UpdateCustomer(Customer customer);
        public void DeleteCustomer(Customer customer);
    }
}
