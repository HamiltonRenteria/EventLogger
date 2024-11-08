using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IEventRepository : IGenericRepository<Evento>
    {
        Task<BaseEntityResponse<Evento>> GetEventsByFilters(BaseFiltersRequest requestDto);
    }
}
