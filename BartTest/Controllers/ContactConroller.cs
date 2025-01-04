using BartTest.Dto;
using BartTest.Entities;
using BartTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BartTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewContact([FromBody] Contact contact)
        {

            var addedContact = await contactService.AddNewContactAsync(contact);

            return addedContact == null ? StatusCode(409, $"Contact already exists.") : Ok(addedContact);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] Contact contact)
        {
            var updatedContact = await contactService.UpdateContactAsync(contact);

            return updatedContact == null ? StatusCode(409, $"Contact already exists.") : Ok(updatedContact);
        }

    }
}
