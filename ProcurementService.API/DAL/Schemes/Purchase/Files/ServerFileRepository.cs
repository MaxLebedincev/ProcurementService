using ProcurementService.API.DAL.Core.Interfaces;
using ProcurementService.API.DAL.Core;
using ProcurementService.API.DAL.Schemes.Security.UsersRoles;

namespace ProcurementService.API.DAL.Schemes.Purchase.Files
{
    public class ServerFileRepository : BaseRepository<UserRole>, IBaseRepository<UserRole>
    {
        public ServerFileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
