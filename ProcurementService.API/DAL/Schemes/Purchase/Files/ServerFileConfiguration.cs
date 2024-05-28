using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProcurementService.API.DAL.Schemes.Purchase.Files
{
    public class ServerFileConfiguration : IEntityTypeConfiguration<ServerFile>
    {
        public void Configure(EntityTypeBuilder<ServerFile> builder)
        {
            builder.ToTable("files", "purchase");

            builder.HasKey(x => x.UUID).HasName("uuid").HasName("FilePrimaryKey");

            builder.Property(x => x.UUID).HasDefaultValueSql("NEWID()");
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(250).IsRequired();
            builder.Property(x => x.CreateAt).HasColumnName("create_at").ValueGeneratedOnAdd();
            builder.Property(x => x.UpdateAt).HasColumnName("update_at").ValueGeneratedOnUpdate();
            builder.Property(x => x.IdCreate).HasColumnName("id_create").IsRequired();
            builder.Property(x => x.IdUpdate).HasColumnName("id_update").IsRequired();
            builder.Property(x => x.Size).HasColumnName("size").IsRequired();
        }
    }
}
