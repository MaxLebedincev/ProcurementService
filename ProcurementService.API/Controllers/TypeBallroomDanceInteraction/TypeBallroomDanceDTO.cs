using ProcurementService.API.Domain.Entity;

namespace ProcurementService.API.Controllers.TypeBallroomDanceInteraction
{
    public class TypeBallroomDanceDTO : TypeBallroomDanceRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
