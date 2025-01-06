using BartTest.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BartTest.EntityConfiguration
{
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(contact => contact.Id);
            builder.Property(contact => contact.Id).ValueGeneratedOnAdd();

            builder.Property(contact => contact.FirstName).HasMaxLength(100);

            builder.Property(contact => contact.LastName).HasMaxLength(100);

            builder.Property(contact => contact.Email).HasMaxLength(100);
            builder.HasIndex(contact => contact.Email).IsUnique();


            builder.HasOne<Account>(c => c.Account)
                .WithMany(c => c.Contacts) // 1:M
                .HasForeignKey(c => c.AccountId) // foreign key for communicate with Account
                .OnDelete(DeleteBehavior.SetNull); //set null in Contact table if we delete Account
        }
    }
}
