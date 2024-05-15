namespace ProcurementService.API.Controllers.UserRoleInteraction
{
    public class UserRoleDTO : UserRoleRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
