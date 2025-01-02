using AutoMapper;
using BartTest.Dto;
using BartTest.Entities;

namespace BartTest.Mappers
{
    public class ReturnNewAccountMapper : Profile
    {
        public ReturnNewAccountMapper() 
        {
            CreateMap<Account, ReturnNewAccountDto>()
                .ForMember(c => c.Id, a => a.MapFrom(b => b.Id))
                .ForMember(c => c.Name, a => a.MapFrom(b => b.Name));
        }
    }
}
