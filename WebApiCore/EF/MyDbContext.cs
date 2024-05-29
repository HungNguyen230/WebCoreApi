using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.EF
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        #region DBSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        #endregion

        #region Fluent
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Order>(e => {
        //        e.ToTable("Order");
        //        e.HasKey(o => o.Id);
        //        e.Property(v => v.OrderDate).HasDefaultValue(new DateTime());
        //    });
        //    modelBuilder.Entity<OrderDetail>(e => {
        //        e.ToTable("OrderDetail");
        //        e.HasKey(od => new { od.OrderId, od.ProductId});

        //        e.HasOne(od => od.Order)
        //        .WithMany(od => od.OrderDetails)
        //        .HasForeignKey(od=>od.OrderId)
        //        .HasConstraintName("FK_OrderDetail_Order");

        //        e.HasOne(od => od.Product)
        //        .WithMany(od => od.OrderDetails)
        //        .HasForeignKey(od => od.ProductId)
        //        .HasConstraintName("FK_OrderDetail_Product");
        //    });
        //}
        #endregion
    }
}
