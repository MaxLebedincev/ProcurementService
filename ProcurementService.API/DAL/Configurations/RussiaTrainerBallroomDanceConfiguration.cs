using ProcurementService.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProcurementService.API.DAL.Configurations
{
    public class RussiaTrainerBallroomDanceConfiguration : IEntityTypeConfiguration<RussiaTrainerBallroomDance>
    {
        public void Configure(EntityTypeBuilder<RussiaTrainerBallroomDance> builder)
        {
            builder.ToTable("RussiaTrainersBallroomDance");

            builder.HasKey(x => x.Id).HasName("RussiaTrainerBallroomDancesPrimaryKey");
            
            builder.Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MiddleName).HasMaxLength(100).IsRequired();
            
            builder.Ignore(x => x.FIO);

            builder
                .HasOne(rtbc => rtbc.TypeBallroomDance)
                .WithMany(tbd => tbd.Trainers)
                .HasForeignKey(rtbc => rtbc.TypeBallroomDanceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
