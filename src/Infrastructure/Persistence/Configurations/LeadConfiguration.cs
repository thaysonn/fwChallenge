using fw.Domain.Leads;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fw.Infrastructure.Persistence.Configurations;

public class LeadConfiguration : IEntityTypeConfiguration<Lead>
{
    public void Configure(EntityTypeBuilder<Lead> builder)
    {
        builder.Property(t => t.Suburb)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Description)
            .IsRequired();

        builder.OwnsOne(e => e.Price, b =>
        {
            b.Property(e => e.Value)
            .HasColumnName("Price")
            .HasColumnType("decimal(5,2)")
            .IsRequired() ; 
        });
    }
}
