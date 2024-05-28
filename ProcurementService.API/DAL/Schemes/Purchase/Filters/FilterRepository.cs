using ProcurementService.API.DAL.Core.Interfaces;
using ProcurementService.API.DAL.Core;
using ProcurementService.API.DAL.Schemes.Security.UsersRoles;

namespace ProcurementService.API.DAL.Schemes.Purchase.Filters
{
    public class FilterRepository : BaseRepository<Filter>, IBaseRepository<Filter>
    {
        public FilterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
