using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProcurementService.API.DAL.Schemes.Purchase.Filters;

namespace ProcurementService.API.DAL.Schemes.Purchase.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products", "purchase");

            builder.HasKey(x => x.Id).HasName("id").HasName("ProductsPrimaryKey");

            builder
                .HasOne(p => p.Request)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.RequestId);

            builder
                .HasOne(f => f.Filter)
                .WithMany(r => r.Products)
                .HasForeignKey(p => p.FilterId);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(1000);
            builder.Property(x => x.CreateAt).HasColumnName("create_at").ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.UpdateAt).HasColumnName("update_at").ValueGeneratedOnUpdate().IsRequired();
            builder.Property(x => x.Count).HasColumnName("count").IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").IsRequired();
        }
    }
}
