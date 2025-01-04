using AutoMapper;
using BartTest.Context;
using BartTest.Dto;
using BartTest.Entities;
using BartTest.Repository.Infrastructure;
using BartTest.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using IncidentEntity = BartTest.Entities.Incident;

namespace BartTest.Repository.Implementation
{
    public class IncidentService : IIncidentService
    {
        private readonly IRepository<IncidentEntity> incidentRepository;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public IncidentService(
            IRepository<IncidentEntity> incidentRepository, //use for add, update, delete, get incidents from db
             IAccountService accountService, //use for work with Account(check for null, link with new Contact)
             IMapper mapper) // use for mapping(DTO to DB)
        {
            this.incidentRepository = incidentRepository;
            this.accountService = accountService;
            this.mapper = mapper;
        }
        public async Task<IncidentEntity> AddNewIncidentAsync(AddNewIncidentDto addNewIncidentDto)
        {
            var newIncident = mapper.Map<AddNewIncidentDto, Incident>(addNewIncidentDto);
            var newAccount = mapper.Map<AddNewIncidentDto, Account>(addNewIncidentDto);
            var newContact = mapper.Map<AddNewIncidentDto, Contact>(addNewIncidentDto);

            var account = await accountService.CheckIfExistByNameAsync(newAccount.Name);
            if (account == null)
            {
                return null;
            }

            await accountService.LinkNewContactAsync(account.Name, newContact); //add new Contact to Account

            newIncident.Accounts = new List<Account> { account }; //link relation between newIncident and Account
            
            var addedIncident = await incidentRepository.AddAsync(newIncident); //add newIncident to DB

            await incidentRepository.SaveChangesAsync();

            return addedIncident;
        }
    }
}
