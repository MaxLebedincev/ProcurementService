namespace ProcurementService.API.Domain.Entity
{
    public class ServerFile
    {
        public Guid Guid { get; set; }
        public string? Name { get; set; }
        public long Size { get; set; }

        public List<MemberDanceGroup>? MembersDanceGroup { get; set; }
    }
}
