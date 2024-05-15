namespace ProcurementService.API.Controllers.UserInteraction
{
    public class UserDTO : UserRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
