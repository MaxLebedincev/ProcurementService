namespace ProcurementService.API.Domain.Entity
{
    public class DanceGroup
    {
        public int Id { get; set; }

        public int? RussiaTrainerBallroomDanceId { get; set; }
        public RussiaTrainerBallroomDance? RussiaTrainerBallroomDance { get; set; }

        public string? Name { get; set; }
        public DateTime Created { get; set; }

        public List<MemberDanceGroup> MemberDanceGroups { get; set; } = new();
    }
}
