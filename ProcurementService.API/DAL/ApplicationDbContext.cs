using ProcurementService.API.DAL.Configurations;
using ProcurementService.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ProcurementService.API.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TypeBallroomDanceConfiguration());
            modelBuilder.ApplyConfiguration(new RussiaTrainerBallroomDanceConfiguration());
            modelBuilder.ApplyConfiguration(new DanceGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ServerFileConfiguration());
            modelBuilder.ApplyConfiguration(new MemberDanceGroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
