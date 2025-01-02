using BartTest.Entities;

namespace BartTest.Repository.Interfaces
{
    public interface IContactService
    {
        Task<Contact> AddNewContactAsync(Contact newContact);

        Task<Contact> UpdateContactAsync(Contact contact);

        Task<Contact> CheckIfExistByEmailAsync(string email);
    }
}
