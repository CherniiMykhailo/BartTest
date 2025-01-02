using BartTest.Dto;
using BartTest.Entities;

namespace BartTest.Repository.Interfaces
{
    public interface IAccountService
    {
        Task<ReturnNewAccountDto> AddNewAccountAsync(AddNewAccountDto addNewAccountDto);

        Task<Account> UpdateAccountAsync(Account newAccount);

        Task<Account> CheckIfExistByNameAsync(string name);

        Task<Account> LinkNewContactAsync(string name, Contact newContact);
    }
}
