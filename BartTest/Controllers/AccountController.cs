using BartTest.Dto;
using BartTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BartTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAccount([FromBody] AddNewAccountDto addNewAccountDto)
        {
            var addedAccount = await accountService.AddNewAccountAsync(addNewAccountDto);

            return addedAccount == null ? NotFound() : Ok(addedAccount);
        }
    }
}
