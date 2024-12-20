using DeliveryOrders.Core.Domain.Model.PickupPointAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Infrastructure.Adapters.Postgres.EntityConfiguration
{
    internal class PickupPointEntityTypeConfiguration : IEntityTypeConfiguration<PickupPoint>
    {
        public void Configure(EntityTypeBuilder<PickupPoint> builder)
        {
            builder.ToTable("pickup_points");

            builder.HasKey(p => p.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder
                .Property(x => x.Name)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .IsRequired();

            builder
                .OwnsOne(pp => pp.Address, a =>
                {
                    a.Property(p => p.Region).HasColumnName("region").IsRequired();
                    a.Property(p => p.City).HasColumnName("city").IsRequired();
                    a.Property(p => p.Street).HasColumnName("street").IsRequired();
                    a.Property(p => p.House).HasColumnName("house").IsRequired();
                    a.WithOwner();
                });
        }
    }
}
