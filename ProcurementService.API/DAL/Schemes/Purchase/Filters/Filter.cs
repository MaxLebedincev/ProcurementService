using ProcurementService.API.DAL.Schemes.Purchase.Products;

namespace ProcurementService.API.DAL.Schemes.Purchase.Filters
{
    public class Filter
    {
        public int Id { get; set; }

        public List<Product>? Products { get; set; } = new();

        public string Manufacturer { get; set; } = null!;
        public int VRAM { get; set; }
        public int RAM { get; set; }
        public int SizeDisk { get; set; }
        public string TypeDisk { get; set; } = null!;
        public int CountCors { get; set; }
        public int Diagonal { get; set; }
    }
}
