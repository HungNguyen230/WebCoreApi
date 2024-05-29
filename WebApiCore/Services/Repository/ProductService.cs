using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.EF;
using WebApiCore.Models;

namespace WebApiCore.Services.Repository
{
    public class ProductService : IProductService
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductModel>> Get()
        {
            try
            {
                var data = await _context.Products.ToListAsync();
                return _mapper.Map<List<ProductModel>>(data);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProductModel> GetById(int id) 
        {
            try
            {
                var product = await _context.Products.SingleOrDefaultAsync(s => s.Id == id);
                return _mapper.Map<ProductModel>(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Product> Add(ProductModel product)
        {
            try
            {
                var data = _mapper.Map<Product>(product);
                _context.Products.Add(data);
                await _context.SaveChangesAsync();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProductModel> Update(ProductModel product)
        {
            try
            {
                var data = await _context.Products.FindAsync(product.Id);
                data.Name = product.Name;
                data.Describe = product.Describe;
                data.Type = product.Type;
                data.Price = product.Price;
                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var data = await _context.Products.FindAsync(id);
                _context.Entry(data).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
