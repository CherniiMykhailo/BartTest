using AutoMapper;
using BartTest.Dto;
using BartTest.Entities;

namespace BartTest.Mappers
{
    public class AddNewContactMapper : Profile
    {
        public AddNewContactMapper()
        {
            CreateMap<AddNewContactDto, Contact>()
                .ForMember(c => c.FirstName, a => a.MapFrom(b => b.FirstName))
                .ForMember(c => c.LastName, a => a.MapFrom(b => b.LastName))
                .ForMember(c => c.Email, a => a.MapFrom(b => b.Email));
        }
    }
}
