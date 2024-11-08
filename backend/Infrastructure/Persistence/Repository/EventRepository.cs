using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class EventRepository : GenericRepository<Evento>, IEventRepository
    {
        public EventRepository(EventLoggerContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<BaseEntityResponse<Evento>> GetEventsByFilters(BaseFiltersRequest filtersRequest)
        {
            BaseEntityResponse<Evento> response = new();
            IQueryable<Evento> events = GetEntityQuery();

            if (filtersRequest.StartDate is not null && filtersRequest.EndDate is not null)
            {
                events = events.Where(x => x.DateEvent >= filtersRequest.StartDate && x.DateEvent <= filtersRequest.EndDate);
            }

            if (filtersRequest.TypeEvent is not null)
            {
                events = events.Where(x => x.TypeEvent == filtersRequest.TypeEvent);
            }


            response.TotalRecords = await events.CountAsync();
            response.Items = await Ordering(filtersRequest, events, false).ToListAsync();

            return response;
        }
    }
}
