using AutoMapper;
using BartTest.Dto;
using BartTest.Entities;

namespace BartTest.Mappers
{
    public class AddNewIncidentMapper : Profile
    {
        public AddNewIncidentMapper()
        {
            CreateMap<AddNewIncidentDto, Contact>()
                .ForMember(c => c.FirstName, a => a.MapFrom(b => b.ContactFirstName))
                .ForMember(c => c.LastName, a => a.MapFrom(b => b.ContactLastName))
                .ForMember(c => c.Email, a => a.MapFrom(b => b.ContactEmail));

            CreateMap<AddNewIncidentDto, Account>()
                .ForMember(c => c.Name, a => a.MapFrom(b => b.AccountName));

            CreateMap<AddNewIncidentDto, Incident>()
                .ForMember(c => c.Description, a => a.MapFrom(b => b.IncidentDescription));
        }
    }
}
