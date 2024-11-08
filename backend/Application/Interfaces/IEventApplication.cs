using Application.Commons.Bases;
using Application.DTOs.Event;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;

namespace Application.Interfaces
{
    public interface IEventApplication
    {
        Task<BaseResponse<bool>> RegisterEventLog(EventLogRequestDto requestDto);
        Task<BaseResponse<IEnumerable<Evento>>> GetEvents();
        Task<BaseResponse<BaseEntityResponse<EventResponseDto>>> GetEventsByFilters(BaseFiltersRequest requestDto);

    }
}
