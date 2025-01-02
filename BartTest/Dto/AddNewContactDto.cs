using Microsoft.Identity.Client;

namespace BartTest.Dto
{
    public class AddNewContactDto
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
    }
}
