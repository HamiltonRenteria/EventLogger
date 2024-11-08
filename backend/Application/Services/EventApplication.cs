using Application.Commons.Bases;
using Application.DTOs.Event;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Request;
using Infrastructure.Commons.Bases.Response;
using Infrastructure.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Utilities.Static;

namespace Application.Services
{
    public class EventApplication : IEventApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public EventApplication(IConfiguration configuration, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<Evento>>> GetEvents()
        {
            BaseResponse<IEnumerable<Evento>> response = new();

            try
            {
                IEnumerable<Evento>? eventLogs = await _unitOfWork.Event.GetAllAsync();

                if (eventLogs is not null)
                {
                    response.IsSuccess = true;
                    response.Data = eventLogs;
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse<BaseEntityResponse<EventResponseDto>>> GetEventsByFilters(BaseFiltersRequest requestDto)
        {
            BaseResponse<BaseEntityResponse<EventResponseDto>> response = new();
            BaseEntityResponse<Evento>? events = await _unitOfWork.Event.GetEventsByFilters(requestDto);

            if (events is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<EventResponseDto>>(events);
                response.Message = ReplyMessage.MESSAGE_QUERY;

                return response;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterEventLog(EventLogRequestDto requestDto)
        {
            BaseResponse<bool> response = new();

            try
            {
                Evento evento = _mapper.Map<Evento>(requestDto);

                response.Data = await _unitOfWork.Event.RegisterAsync(evento);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_REGISTER;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }
}
