using ProcurementService.API.DAL.Core.Interfaces;
using ProcurementService.API.DAL.Core;
using ProcurementService.API.DAL.Schemes.Security.UsersRoles;

namespace ProcurementService.API.DAL.Schemes.Purchase.Products
{
    public class ProductRepository : BaseRepository<Product>, IBaseRepository<Product>
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
