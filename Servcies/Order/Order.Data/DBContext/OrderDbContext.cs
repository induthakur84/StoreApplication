using Microsoft.EntityFrameworkCore;
using Order.DTO.Models;
using System.Reflection;

namespace Order.Data.DBContext
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<Product> Products { get; set; }





    }
}
