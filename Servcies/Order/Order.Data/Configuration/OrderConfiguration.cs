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
                   .OnDelete(DeleteBehavior.Restrict);

            ///Delete Behavior Explaination:
            ///

            //Restrict:
            // it prevent deleting User it any order exists
            //for examples

            // if User has 5 orders, DB will not allow deleteting that user until all 5 orders are deleted first.

            //this protects important data (order history stay safe)



            //Cascade:
            // if user is deleted, all related orders will be automatically deleted as well.

            // its child table data has no meaning without parent table data, so it will be deleted together with the parent data.








        }
    }
}
