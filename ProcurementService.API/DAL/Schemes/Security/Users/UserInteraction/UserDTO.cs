namespace ProcurementService.API.DAL.Schemes.Security.Users.UserInteraction
{
    public class UserDTO : UserRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
