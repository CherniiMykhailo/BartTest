using BartTest.Entities.Interfaces;
using System.Text.Json.Serialization;

namespace BartTest.Entities
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IncedentId {  get; set; }
        public Incident? Incident { get; set; }
        [JsonIgnore]
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
