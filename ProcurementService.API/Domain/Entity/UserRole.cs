namespace ProcurementService.API.Domain.Entity
{
    public class UserRole
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<User> Users { get; set; } = new();
    }
}
