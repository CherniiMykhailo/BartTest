namespace BartTest.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int IncedentId {  get; set; }
        public Incident? Incident { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }
}
