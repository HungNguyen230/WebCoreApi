using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Models
{
    public class ProductModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }

        public ProductType Type { get; set; }
        public double Price { get; set; }
        //public ProductModel(Product product)
        //{
        //    this.Id = product.Id;
        //    this.Name = product.Name;
        //    this.Describe = product.Describe;
        //    this.Type = product.Type;
        //    this.Price = product.Price;
        //}
    }
}
