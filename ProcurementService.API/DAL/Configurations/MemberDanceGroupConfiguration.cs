using ProcurementService.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProcurementService.API.DAL.Configurations
{
    public class MemberDanceGroupConfiguration : IEntityTypeConfiguration<MemberDanceGroup>
    {
        public void Configure(EntityTypeBuilder<MemberDanceGroup> builder)
        {
            builder.ToTable("MembersDanceGroup");

            builder.HasKey(x => x.Id).HasName("MembersDanceGroupPrimaryKey");

            builder
                .HasOne(mdg => mdg.DanceGroup)
                .WithMany(dg => dg.MemberDanceGroups)
                .HasForeignKey(mdg => mdg.DanceGroupId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(mdg => mdg.ServerFile)
                .WithMany(sf => sf.MembersDanceGroup)
                .HasForeignKey(mdg => mdg.GuidPhotoFile)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MiddleName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.City).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Category).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Score).HasDefaultValue(0).IsRequired();


            builder.Ignore(x => x.FIO);
        }
    }
}
