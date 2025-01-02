using BartTest.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BartTest.EntityConfiguration
{
    class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents");

            builder.HasKey(i => i.Name); //primary key
            builder.Property(i => i.Name).HasDefaultValue("NEWID()"); // autogenerate by DB
        }
    }
}
