namespace ProcurementService.API.Domain.Entity
{
    public class RussiaTrainerBallroomDance
    {
        public int Id { get; set; }

        public int? TypeBallroomDanceId { get; set; }
        public TypeBallroomDance? TypeBallroomDance { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string FIO { get { return $"{LastName} {FirstName} {MiddleName}"; } }
        
        public List<DanceGroup>? DanceGroups { get; set; } = new();
    }
}
