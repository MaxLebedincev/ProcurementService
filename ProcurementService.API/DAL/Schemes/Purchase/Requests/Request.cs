using ProcurementService.API.DAL.Schemes.Purchase.Files;
using ProcurementService.API.DAL.Schemes.Purchase.Products;

namespace ProcurementService.API.DAL.Schemes.Purchase.Requests
{
    public class Request
    {
        public int Id { get; set; }

        public List<Product>? Products { get; set; } = new();

        public Guid UUIDFile { get; set; }
        public ServerFile file { get; set; }


        public string Name { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int IdCreate { get; set; }
        public int IdUpdate { get; set; }
        public bool IsConfirmed { get; set; }
        public int IdConfirmed { get; set; }
    }
}
