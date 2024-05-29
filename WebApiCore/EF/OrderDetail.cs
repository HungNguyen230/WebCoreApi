using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.EF
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Amount { get; set; }

        //relationship
        //public Order Order { get; set; }
        //public Product Product { get; set; }
    }
}
