using System.Collections.Generic;

namespace BartTest.Entities
{
    public interface IEntity { }
    public class Incident : IEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>(); // 1:M
    }
}
