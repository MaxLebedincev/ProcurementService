using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProcurementService.API.DAL.Schemes.Security.Roles;

namespace ProcurementService.API.DAL.Schemes.Purchase.Requests
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("requests", "purchase");

            builder.HasKey(x => x.Id).HasName("id").HasName("RequestsPrimaryKey");

            builder
                .HasOne(x => x.file)
                .WithOne()
                .HasForeignKey<Request>(f => f.UUIDFile);

            builder.Property(x => x.UUIDFile).HasColumnName("uuid_file");
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.CreateAt).HasColumnName("create_at").ValueGeneratedOnAdd();
            builder.Property(x => x.UpdateAt).HasColumnName("update_at").ValueGeneratedOnUpdate();
            builder.Property(x => x.IdCreate).HasColumnName("id_create");
            builder.Property(x => x.IdUpdate).HasColumnName("id_update");
            builder.Property(x => x.IsConfirmed).HasColumnName("is_confirmed").IsRequired();
            builder.Property(x => x.IdConfirmed).HasColumnName("id_confirmed").IsRequired();
        }
    }
}
