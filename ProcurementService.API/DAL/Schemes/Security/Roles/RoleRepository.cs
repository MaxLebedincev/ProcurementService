using ProcurementService.API.DAL.Core.Interfaces;
using ProcurementService.API.DAL.Core;
using ProcurementService.API.DAL.Schemes.Security.UsersRoles;

namespace ProcurementService.API.DAL.Schemes.Security.Roles
{
    public class RoleRepository : BaseRepository<Role>, IBaseRepository<Role>
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
