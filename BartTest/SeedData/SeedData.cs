using BartTest.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BartTest.SeedData
{
    internal static class SeedData
    {
        internal static void Seed(this ModelBuilder builder)
        {
            SeedContacts(builder.Entity<Contact>());
        }

        internal static void SeedContacts(EntityTypeBuilder<Contact> builder) =>
            builder.HasData(
                new Contact()
                {
                    Id = 1,
                    FirstName = "Mykhailo",
                    LastName = "Chernii",
                    Email = "mykhailo@gmail.com"
                },
                new Contact()
                {
                    Id = 2,
                    FirstName = "Mykhailo2",
                    LastName = "Chernii2",
                    Email = "mykhailo2@gmail.com"
                },
                new Contact()
                {
                    Id = 3,
                    FirstName = "Mykhailo3",
                    LastName = "Chernii3",
                    Email = "mykhailo3@gmail.com"
                }
                );

    }
}
