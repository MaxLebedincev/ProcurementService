using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IBaseRepository<User>
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
