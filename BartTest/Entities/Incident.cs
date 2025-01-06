using BartTest.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace BartTest.Entities
{
    public class Incident : IEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; } = new List<Account>(); // 1:M
    }
}
