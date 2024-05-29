using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.EF
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }
     
        public double TotalPrice { get; set; }

        //relationship
        //public ICollection<OrderDetail> OrderDetails { get; set; }
        //public Order()
        //{
        //    OrderDetails = new List<OrderDetail>();
        //}
    }
}
