using AutoMapper;
using EventsApi.Dtos;
using EventsApi.Models;

namespace EventsApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EventDetail, EventDetailDto>();
        }
    }
}
