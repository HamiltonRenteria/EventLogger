namespace Application.DTOs.Event
{
    public class EventLogRequestDto
    {
        public string Description { get; set; } = null!;

        public DateTime? DateEvent { get; set; }

        public string? TypeEvent { get; set; }

        public int? UserId { get; set; }
    }
}
