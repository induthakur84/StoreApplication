using Microsoft.EntityFrameworkCore;
using Payment.DTO.Models;

namespace Order.Data.DBContext
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }
        public DbSet<PaymentModel> Payments { get; set; }
    }
}
