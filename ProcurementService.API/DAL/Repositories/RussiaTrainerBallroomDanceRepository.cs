using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.DAL.Repositories
{
    public class RussiaTrainerBallroomDanceRepository : BaseRepository<RussiaTrainerBallroomDance>, IBaseRepository<RussiaTrainerBallroomDance>
    {
        public RussiaTrainerBallroomDanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
