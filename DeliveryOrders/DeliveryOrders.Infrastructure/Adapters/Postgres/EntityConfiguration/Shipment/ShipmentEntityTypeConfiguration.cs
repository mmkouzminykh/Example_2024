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
    internal class ShipmentEntityTypeConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("shipments");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedNever()
                .HasColumnName("Id");

            builder
                .Property(x => x.DeparturePointId)
                .HasColumnName("departure_point_id")
                .IsRequired();

            builder
                .Property(x => x.DestinationPointId)
                .HasColumnName("destination_point_id")
                .IsRequired();

            builder
                .Property(x => x.ShipmentDate)
                .HasColumnName("shipment_date")
                .IsRequired();            
        }
    }
}
