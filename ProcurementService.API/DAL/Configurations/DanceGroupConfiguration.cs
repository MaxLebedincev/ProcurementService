using ProcurementService.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProcurementService.API.DAL.Configurations
{
    public class DanceGroupConfiguration : IEntityTypeConfiguration<DanceGroup>
    {
        public void Configure(EntityTypeBuilder<DanceGroup> builder)
        {
            builder.ToTable("DanceGroups");

            builder.HasKey(x => x.Id).HasName("DanceGroupPrimaryKey"); ;
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Created).IsRequired().ValueGeneratedOnAdd();

            builder
                .HasOne(dg => dg.RussiaTrainerBallroomDance)
                .WithMany(rtbd => rtbd.DanceGroups)
                .HasForeignKey(dg => dg.RussiaTrainerBallroomDanceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
