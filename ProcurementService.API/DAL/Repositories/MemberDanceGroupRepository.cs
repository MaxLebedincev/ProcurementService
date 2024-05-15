using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.DAL.Repositories
{
    public class MemberDanceGroupRepository : BaseRepository<MemberDanceGroup>, IBaseRepository<MemberDanceGroup>
    {
        public MemberDanceGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
