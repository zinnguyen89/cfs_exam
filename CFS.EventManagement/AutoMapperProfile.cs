using AutoMapper;
using CFS.EventManagement.BusinessRules;
using CFS.EventManagement.Commands;
using CFS.EventManagement.Dtos;
using CFS.EventManagement.Entities;
using CFS.EventManagement.Services;

namespace CFS.EventManagement
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateEventCommand, CfsEvent>();
            CreateMap<CfsEvent, CreateEventResponse>();
            CreateMap<CreateEventCommand, CreateEventRuleModel>();
            CreateMap<GetEventsByFilterQuery, GetEventByFilterRuleModel>();
        }
    }

}
