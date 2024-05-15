using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.DAL.Repositories
{
    public class DanceGroupRepository : BaseRepository<DanceGroup>, IBaseRepository<DanceGroup>
    {
        public DanceGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
