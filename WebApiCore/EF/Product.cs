using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.EF;

namespace WebApiCore.Models
{
    public enum ProductType
    {
        MOBILE = 0,
        COMPUTER = 1
    }
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Describe { get; set; }

        [Required]
        public ProductType Type { get; set; }
        [Required]
        public double Price { get; set; }

        //relationship
        //public ICollection<OrderDetail> OrderDetails { get; set; }
        //public Product()
        //{
        //    OrderDetails = new List<OrderDetail>();
        //}
    }
}
