namespace ProcurementService.API.Domain.Entity
{
    public class MemberDanceGroup
    {
        public int Id { get; set; }

        public int? DanceGroupId { get; set; }
        public DanceGroup? DanceGroup { get; set; }

        public Guid? GuidPhotoFile { get; set; }
        public ServerFile? ServerFile { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string FIO { get { return $"{LastName} {FirstName} {MiddleName}"; } }
        public string? City { get; set; }
        public string? Category { get; set; }
        public int Score { get; set; }
    }
}
