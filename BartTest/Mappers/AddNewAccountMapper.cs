using AutoMapper;
using BartTest.Dto;
using BartTest.Entities;

namespace BartTest.Mappers
{
    public class AddNewAccountMapper : Profile
    {
        public AddNewAccountMapper()
        {
            CreateMap<AddNewAccountDto, Contact>()
                .ForMember(c => c.FirstName, a => a.MapFrom(b => b.ContactFirstName))
                .ForMember(c => c.LastName, a => a.MapFrom(b => b.ContactLastName))
                .ForMember(c => c.Email, a => a.MapFrom(b => b.ContactEmail));

            CreateMap<AddNewAccountDto, Account>()
                .ForMember(c => c.Name, a => a.MapFrom(b => b.AccountName));
        }
    }
}
