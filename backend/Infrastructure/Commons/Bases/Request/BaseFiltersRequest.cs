namespace Infrastructure.Commons.Bases.Request
{
    public class BaseFiltersRequest : BasePaginationRequest
    {
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
        public string? TypeEvent { get; set; } = null;
    }
}
