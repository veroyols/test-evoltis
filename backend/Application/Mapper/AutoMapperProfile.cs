using Application.DTO;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
            CreateMap<ContactBody, Contact>();
        }
    }
}
