using DeliveryOrders.Core.Domain.Model.PickupPointAggregate;
using DeliveryOrders.Core.Domain.Model.ShipmentAggregate;
using DeliveryOrders.Infrastructure.Adapters.Postgres.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Infrastructure.Adapters.Postgres
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<PickupPoint> PickupPoints { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PickupPointEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CargoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentEntityTypeConfiguration());
            
        }
    }
}
