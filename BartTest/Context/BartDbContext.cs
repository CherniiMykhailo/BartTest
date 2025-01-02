using BartTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace BartTest.Context
{
    public class BartDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
