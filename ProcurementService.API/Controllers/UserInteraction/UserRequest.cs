using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.Controllers.UserInteraction
{
    public class UserRequest
    {
        public int? IdUserRole { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
