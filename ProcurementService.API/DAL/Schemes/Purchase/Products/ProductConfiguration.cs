using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProcurementService.API.DAL.Schemes.Purchase.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products", "purchase");

            builder.HasKey(x => x.Id).HasName("ProductsPrimaryKey");

            builder
                .HasOne(p => p.Request)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.RequestId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.RequestId).HasColumnName("request_id").HasDefaultValue(null).IsRequired(false);
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired(true);
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(1000).IsRequired(false);
            builder.Property(x => x.CreateAt).HasColumnName("create_at").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.UpdateAt).HasColumnName("update_at").ValueGeneratedOnUpdate().IsRequired(true);
            builder.Property(x => x.Count).HasColumnName("count").IsRequired(true);
            builder.Property(x => x.Price).HasColumnName("price").IsRequired(true);
        }
    }
}
