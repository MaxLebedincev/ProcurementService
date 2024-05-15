using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.DAL.Repositories
{
    public class ServerFileRepository : BaseRepository<ServerFile>, IBaseRepository<ServerFile>
    {
        public ServerFileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
