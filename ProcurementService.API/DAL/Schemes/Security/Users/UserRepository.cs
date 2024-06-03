using ProcurementService.API.DAL.Core;
using ProcurementService.API.DAL.Core.Interfaces;

namespace ProcurementService.API.DAL.Schemes.Security.Users
{
    public class UserRepository : BaseRepository<User>, IBaseRepository<User>
    {
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
        }
    }
}
