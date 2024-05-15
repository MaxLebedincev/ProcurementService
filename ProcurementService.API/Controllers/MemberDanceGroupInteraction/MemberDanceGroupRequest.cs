namespace ProcurementService.API.Controllers.MemberDanceGroupInteraction
{
    public class MemberDanceGroupRequest
    {
        public int? DanceGroupId { get; set; }
        public Guid? GuidPhotoFile { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? City { get; set; }
        public string? Category { get; set; }
        public int? Score { get; set; }
    }
}
