namespace ProcurementService.API.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }

        public int? IdUserRole { get; set; }
        public UserRole? UserRole { get; set; }

        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
