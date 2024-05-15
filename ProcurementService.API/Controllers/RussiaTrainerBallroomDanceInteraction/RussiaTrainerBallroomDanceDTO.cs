namespace ProcurementService.API.Controllers.RussiaTrainerBallroomDanceInteraction
{
    public class RussiaTrainerBallroomDanceDTO : RussiaTrainerBallroomDanceRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
