namespace ProcurementService.API.Controllers.ServerFileInteraction
{
    public class ServerFileDTO : ServerFileRequest
    {
        public int Offset { get; set; } = 0;
        public int Number { get; set; } = 10;
    }
}
