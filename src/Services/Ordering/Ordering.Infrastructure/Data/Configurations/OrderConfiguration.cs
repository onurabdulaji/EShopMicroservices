using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Id)
                .HasConversion
                (
                    orderId => orderId.Value,
                    dbId => OrderId.Of(dbId)
                );

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(q => q.CustomerId)
                .IsRequired();

            builder.HasMany(q => q.OrderItems)
                .WithOne()
                .HasForeignKey(oi => oi.OrderId);

            builder.ComplexProperty
                (
                    q => q.OrderName, nameBuilder =>
                    {
                        nameBuilder.Property(q => q.Value)
                        .HasColumnName(nameof(Order.OrderName))
                        .HasMaxLength(100)
                        .IsRequired();
                    }
                );

            builder.ComplexProperty
                (
                    q => q.ShippingAddress, addressBuilder =>
                    {
                        addressBuilder.Property(q => q.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

                        addressBuilder.Property(q => q.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                        addressBuilder.Property(q => q.EmailAdress)
                        .HasMaxLength(50);

                        addressBuilder.Property(q => q.AdressLine)
                        .HasMaxLength(180)
                        .IsRequired();

                        addressBuilder.Property(q => q.Country)
                        .HasMaxLength(50);

                        addressBuilder.Property(q => q.State)
                        .HasMaxLength(50);

                        addressBuilder.Property(q => q.ZipCode)
                        .HasMaxLength(5);
                    }
                );

            builder.ComplexProperty
                (
                    q => q.BillingAddress, addressBuilder =>
                    {
                        addressBuilder.Property(q => q.FirstName)
                        .HasMaxLength(50)
                        .IsRequired();

                        addressBuilder.Property(q => q.LastName)
                        .HasMaxLength(50)
                        .IsRequired();

                        addressBuilder.Property(q => q.EmailAdress)
                        .HasMaxLength(50);

                        addressBuilder.Property(q => q.AdressLine)
                        .HasMaxLength(180)
                        .IsRequired();

                        addressBuilder.Property(q => q.Country)
                        .HasMaxLength(50);

                        addressBuilder.Property(q => q.State)
                        .HasMaxLength(50);

                        addressBuilder.Property(q => q.ZipCode)
                        .HasMaxLength(5)
                        .IsRequired();  
                    }
                );

            builder.ComplexProperty
                (
                    q => q.Payment, paymnetBuilder =>
                    {
                        paymnetBuilder.Property(q => q.CardName)
                        .HasMaxLength(50);

                        paymnetBuilder.Property(q => q.CardNumber)
                        .HasMaxLength(24)
                        .IsRequired();

                        paymnetBuilder.Property(q => q.Expiration)
                        .HasMaxLength(10);

                        paymnetBuilder.Property(q => q.CVV)
                        .HasMaxLength(3);

                        paymnetBuilder.Property(q => q.PaymentMethod);
                    }
                );

            builder.Property(q => q.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion
                (
                    q => q.ToString(),
                    dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus), dbStatus)
                );

            builder.Property(q => q.TotalPrice);
        }
    }
}
