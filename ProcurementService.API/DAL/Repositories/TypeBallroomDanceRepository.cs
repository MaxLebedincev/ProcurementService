using ProcurementService.API.DAL.Interfaces;
using ProcurementService.API.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ProcurementService.API.DAL.Repositories
{
    public class TypeBallroomDanceRepository : BaseRepository<TypeBallroomDance>, IBaseRepository<TypeBallroomDance>
    {
        public TypeBallroomDanceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
