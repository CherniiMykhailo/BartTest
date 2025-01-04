using AutoMapper;
using BartTest.Entities;
using BartTest.Repository.Infrastructure;
using BartTest.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using ContactEntity = BartTest.Entities.Contact;

namespace BartTest.Repository.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IRepository<ContactEntity> contactRepository;
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public ContactService(
             IRepository<ContactEntity> contactRepository,
            IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.mapper = mapper;
        }

        public async Task<ContactEntity> AddNewContactAsync(Contact newContact)
        {
            var contact = await contactRepository.Query().Where(c => c.Email == newContact.Email)
                 .FirstOrDefaultAsync();

            if (contact != null)
            {
                return null;
            }

            var addedContact = await contactRepository.AddAsync(newContact);

            await contactRepository.SaveChangesAsync();

            return addedContact;
        }

        public async Task<ContactEntity> CheckIfExistByEmailAsync(string email) => await contactRepository.Query().Where(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<ContactEntity> UpdateContactAsync(ContactEntity updatedContact)
        {
            var contact = await contactRepository.Query().Where(c => c.Email == updatedContact.Email)
                .FirstOrDefaultAsync();

            if (contact == null)
            {
                return null;
            }

            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;

            await contactRepository.SaveChangesAsync();

            return contact;
        }
    }
}
