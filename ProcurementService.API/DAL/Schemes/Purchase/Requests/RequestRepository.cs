using ProcurementService.API.DAL.Core.Interfaces;
using ProcurementService.API.DAL.Core;
using ProcurementService.API.DAL.Schemes.Security.UsersRoles;

namespace ProcurementService.API.DAL.Schemes.Purchase.Requests
{
    public class RequestRepository : BaseRepository<Request>, IBaseRepository<Request>
    {
        public RequestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
