using DeliveryOrders.Core.Domain.Model.ShipmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Infrastructure.Adapters.Postgres.EntityConfiguration
{
    internal class CargoEntityTypeConfiguration : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("cargo");

            builder.HasKey(t => t.Id);

            builder
                .Property(t => t.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder
                .Property(t => t.PackageType)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("package_type")
                .IsRequired();

            builder
                .Property(t => t.CargoType)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("cargo_type")
                .IsRequired();

            builder
                .Property(t => t.Comment)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("comment");

            builder
                .OwnsOne(c => c.Dimensions, d =>
                {
                    d.Property(p => p.Height).HasColumnName("height").IsRequired();
                    d.Property(p => p.Width).HasColumnName("width").IsRequired();
                    d.Property(p => p.Length).HasColumnName("length").IsRequired();
                    d.Property(p => p.Weight).HasColumnName("weight").IsRequired();
                });

            builder
                .Property("ShipmentId")                
                .UsePropertyAccessMode (PropertyAccessMode.Field)
                .HasColumnName("shipment_id")
                .HasColumnType("uuid")
                .IsRequired();

        }
    }
}
