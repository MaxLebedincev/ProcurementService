namespace ProcurementService.API.DAL.Schemes.Security.Users.UserInteraction
{
    public class UserResponse
    {
        public int Id { get; set; }
        public int? IdUserRole { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
