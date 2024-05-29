using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.EF;
using WebApiCore.Models;

namespace WebApiCore.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> Login(CustomerModel customer);
    }
}
