using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.EF;
using WebApiCore.Models;
using WebApiCore.Security;
using WebApiCore.Services.Interfaces;

namespace WebApiCore.Services.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly MyDbContext _context;

        public CustomerService(MyDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Login(CustomerModel customer)
        {
            try
            {
                var pssWd = Securitis.md5(customer.Password);
                return _context.Customers.SingleOrDefault(s => s.UserName == customer.UserName && s.Password == pssWd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
