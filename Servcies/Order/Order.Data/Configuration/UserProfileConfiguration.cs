using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.DTO.Models;

namespace Order.Data.Configuration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            // one to one relationship between User and UserProfile,
            // where each User has one UserProfile and each UserProfile is associated with one User.
            builder.HasOne(p => p.User)
                   .WithOne(u => u.UserProfile)
                   .HasForeignKey<UserProfile>(up => up.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


//CaseCade.DeleteBehavior

//userprofile
 
//id  name   Userid
//i     ram       1