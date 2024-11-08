namespace Application.DTOs.Event
{
    public class EventsRequestDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? TypeEvent { get; set; }
    }
}


