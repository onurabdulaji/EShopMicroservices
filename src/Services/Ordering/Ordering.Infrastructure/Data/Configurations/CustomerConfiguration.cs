using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id).HasConversion
                (
                    customerId => customerId.Value,
                    dbId => CustomerId.Of(dbId)
                );

            builder.Property(q=>q.Name).HasMaxLength(100).IsRequired();

            builder.Property(q=>q.Email).HasMaxLength(100);

            builder.HasIndex(q=>q.Email).IsUnique();
        }
    }
}
