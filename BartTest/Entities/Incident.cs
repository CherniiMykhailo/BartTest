using System.Collections.Generic;

namespace BartTest.Entities
{
    public class Incident
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>(); // 1:M
    }
}
