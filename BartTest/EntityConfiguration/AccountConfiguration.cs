using BartTest.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BartTest.EntityConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(account => account.Id);
            builder.Property(account => account.Id).ValueGeneratedOnAdd();

            builder.Property(account => account.Name).HasMaxLength(100);
            builder.HasIndex(account => account.Name).IsUnique(); // unique string field

            builder.HasOne<Incident>(c => c.Incident)
                .WithMany(c => c.Accounts)
                .HasForeignKey(c => c.IncedentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
