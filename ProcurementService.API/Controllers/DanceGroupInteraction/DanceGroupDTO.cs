namespace ProcurementService.API.Controllers.DanceGroupInteraction
{
    public class DanceGroupDTO : DanceGroupRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
        public new string? Created { get; set; } = null;
        public string? Finish { get; set; } = null;
    }
}
