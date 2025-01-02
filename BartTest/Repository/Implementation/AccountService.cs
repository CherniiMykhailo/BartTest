using AutoMapper;
using BartTest.Dto;
using BartTest.Entities;
using BartTest.Repository.Infrastructure;
using BartTest.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using AccountEntity = BartTest.Entities.Account;

namespace BartTest.Repository.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<AccountEntity> accountRepository;
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public AccountService(
            IRepository<AccountEntity> accountRepository,
            IContactService contactService,
            IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.contactService = contactService;
            this.mapper = mapper;
        }

        public async Task<ReturnNewAccountDto> AddNewAccountAsync(AddNewAccountDto addNewAccountDto)
        {
            var newAccount = mapper.Map<AccountEntity>(addNewAccountDto);
            var newContact = mapper.Map<Contact>(addNewAccountDto);

            var account = await accountRepository.Query().Where(x => x.Name == newAccount.Name).FirstOrDefaultAsync(); //check for avaible newAccount.Name
            if (account != null)
            {
                return null!;
            }

            var contact = await contactService.CheckIfExistByEmailAsync(newContact.Email!); // search contact with this email

            if (contact == null)
            {
                contact = await contactService.AddNewContactAsync(newContact); // create new contact
            }
            else
            {
                contact = await contactService.UpdateContactAsync(newContact); // add to avaible contact
            }

            newAccount.Contacts = new List<Contact> { contact }; // add list of contacts to newAccount

            var addedAccount = await accountRepository.AddAsync(newAccount); // add newAccount to DB
            await accountRepository.SaveChangesAsync();

            var returnNewAccountDto = mapper.Map<ReturnNewAccountDto>(addedAccount);
            return returnNewAccountDto;
        }

        public async Task<AccountEntity> CheckIfExistByNameAsync(string name) => await accountRepository.Query().Where(x => x.Name == name).FirstOrDefaultAsync();

        public async Task<AccountEntity> LinkNewContactAsync(string name, Contact newContact)
        {
            var account = await accountRepository.Query().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (account == null)
            {
                return null!;
            }

            var contact = await contactService.CheckIfExistByEmailAsync(newContact.Email!);

            if (contact == null)
            {
                contact = await contactService.AddNewContactAsync(newContact);
            }
            else
            {
                contact = await contactService.UpdateContactAsync(newContact);
            }

            if (contact.AccountId != null)
            {
                return null!;
            }

            account.Contacts.Add(contact);

            await accountRepository.SaveChangesAsync();

            return account;
        }

        public async Task<AccountEntity> UpdateAccountAsync(Account newAccount)
        {
            var addedAccount = await accountRepository.AddAsync(newAccount);

            await accountRepository.SaveChangesAsync();

            return addedAccount;
        }
    }
}
