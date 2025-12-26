namespace bed_grooming_app.application.DTOs
{
    public class ServiceDTO
    {
        public long ServiceId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public string? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? LastModifiedUserId { get; set; }
        public DateTime? LastModifiedDateTime { get; set; }
        public bool State { get; set; } = true;
    }
}
