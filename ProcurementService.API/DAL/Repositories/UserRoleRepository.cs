using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.DAL.Repositories
{
    public class UserRoleRepository : BaseRepository<UserRole>, IBaseRepository<UserRole>
    {
        public UserRoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
