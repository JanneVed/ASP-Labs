using Lab_4_MVC_Razor.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4_MVC_Razor.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDBContext _appDbContext;

        public CustomerRepository(AppDBContext appDBContext)
        {
            _appDbContext = appDBContext;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            _appDbContext.Add(newCustomer);
            _appDbContext.SaveChanges();
            return newCustomer;
        }

        public void DeleteCustomer(Customer customer)
        {
            _appDbContext.Customers.Remove(customer);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _appDbContext.Customers;
        }

        public Customer GetCustomer(int customerId)
        {
            return _appDbContext.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
