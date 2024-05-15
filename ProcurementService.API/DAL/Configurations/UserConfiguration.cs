using ProcurementService.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProcurementService.API.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id).HasName("UsersPrimaryKey");

            builder
                .HasOne(u => u.UserRole)
                .WithMany(ur => ur.Users)
                .HasForeignKey(u => u.IdUserRole)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.Login).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Created).ValueGeneratedOnAdd();
            builder.Property(x => x.Updated).ValueGeneratedOnUpdate();
        }
    }
}
