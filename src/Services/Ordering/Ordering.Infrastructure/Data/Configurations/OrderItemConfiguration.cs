using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .HasConversion
                (
                    orderItemId => orderItemId.Value,
                    dbId => OrderItemId.Of(dbId)
                );

            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(q => q.ProductId);

            builder.Property(q => q.Quantity).IsRequired();

            builder.Property(q => q.Price).IsRequired();
        }
    }
}
