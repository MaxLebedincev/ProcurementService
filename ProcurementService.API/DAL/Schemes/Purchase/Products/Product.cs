using ProcurementService.API.DAL.Schemes.Purchase.Filters;
using ProcurementService.API.DAL.Schemes.Purchase.Requests;

namespace ProcurementService.API.DAL.Schemes.Purchase.Products
{
    public class Product
    {
        public int Id { get; set; }
        public int FilterId { get; set; }
        public Filter Filter { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
