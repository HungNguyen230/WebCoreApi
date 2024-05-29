using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> Get();
        Task<ProductModel> GetById(int id);
        Task<Product> Add(ProductModel product);
        Task<ProductModel> Update(ProductModel product);
        Task<bool> Delete(int id);
    }
}
