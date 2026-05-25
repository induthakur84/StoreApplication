using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DTO.Models;

namespace Order.Data.Configuration
{
     public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
     { 
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
