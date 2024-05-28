namespace ProcurementService.API.DAL.Schemes.Purchase.Files
{
    public class ServerFile
    {
        public Guid UUID { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int IdCreate { get; set; }
        public int IdUpdate { get; set; }
        public long Size { get; set; }

    }
}
