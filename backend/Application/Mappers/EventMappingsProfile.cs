using Application.DTOs.Event;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Commons.Bases.Response;

namespace Application.Mappers
{
    public class EventMappingsProfile : Profile
    {
        public EventMappingsProfile()
        {
            _ = CreateMap<EventLogRequestDto, Evento>();
            _ = CreateMap<BaseEntityResponse<Evento>, BaseEntityResponse<EventResponseDto>>()
                      .ReverseMap();
        }
    }
}
