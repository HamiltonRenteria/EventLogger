using Application.Commons.Bases;
using Application.DTOs.Event;
using Application.Interfaces;
using Infrastructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EventLogsController : ControllerBase
    {
        private readonly IEventApplication _eventApplication;

        public EventLogsController(IEventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListEvents([FromBody] BaseFiltersRequest filtersRequest)
        {
            BaseResponse<Infrastructure.Commons.Bases.Response.BaseEntityResponse<EventResponseDto>> response = await _eventApplication.GetEventsByFilters(filtersRequest);
            return Ok(response);
        }

        [HttpPost("RegisterEvent")]
        public async Task<IActionResult> RegisterEvent([FromBody] EventLogRequestDto requestDto)
        {
            BaseResponse<bool> response = await _eventApplication.RegisterEventLog(requestDto);
            return Ok(response);
        }

        [HttpGet("GetEvents")]
        public async Task<IActionResult> GetEvents()
        {
            BaseResponse<IEnumerable<Domain.Entities.Evento>> response = await _eventApplication.GetEvents();
            return Ok(response);
        }
    }
}
