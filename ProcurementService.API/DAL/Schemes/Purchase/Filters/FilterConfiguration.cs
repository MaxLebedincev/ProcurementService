using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProcurementService.API.DAL.Schemes.Purchase.Files;

namespace ProcurementService.API.DAL.Schemes.Purchase.Filters
{
    public class FilterConfiguration : IEntityTypeConfiguration<Filter>
    {
        public void Configure(EntityTypeBuilder<Filter> builder)
        {
            builder.ToTable("filters", "purchase");

            builder.HasKey(x => x.Id).HasName("id").HasName("FilterPrimaryKey");

            builder.Property(x => x.Manufacturer).HasColumnName("manufacturer").HasMaxLength(150).IsRequired();
            builder.Property(x => x.VRAM).HasColumnName("vram");
            builder.Property(x => x.RAM).HasColumnName("ram");
            builder.Property(x => x.SizeDisk).HasColumnName("size_disk");
            builder.Property(x => x.TypeDisk).HasColumnName("type_disk").HasMaxLength(100);
            builder.Property(x => x.CountCors).HasColumnName("count_cors");
            builder.Property(x => x.Diagonal).HasColumnName("diagonal");
        }
    }
}
