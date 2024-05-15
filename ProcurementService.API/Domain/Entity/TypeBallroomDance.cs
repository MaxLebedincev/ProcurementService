namespace ProcurementService.API.Domain.Entity
{
    public class TypeBallroomDance
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<RussiaTrainerBallroomDance> Trainers { get; set; } = new();
    }
}
