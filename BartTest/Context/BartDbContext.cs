using BartTest.Entities;
using BartTest.EntityConfiguration;
using BartTest.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BartTest.Context
{
    public class BartDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public BartDbContext(DbContextOptions<BartDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //to setup tables in DB, how they should be displayed
        {
            modelBuilder.ApplyConfiguration(new IncidentConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());

            modelBuilder.Seed(); //add data to DB
        }
    }
}
