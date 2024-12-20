using DeliveryOrders.Core.Domain.Model.PickupPointAggregate;
using DeliveryOrders.Core.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Infrastructure.Adapters.Postgres
{
    public class PickupPointRepository : IPickPointRepository
    {
        private ApplicationDbContext _context;

        public PickupPointRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PickupPoint pickupPoint, CancellationToken cancellationToken)
        {
            await _context.AddAsync(pickupPoint, cancellationToken);
        }

        public async Task<IEnumerable<PickupPoint>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.PickupPoints.ToListAsync(cancellationToken);
        }

        public async Task<PickupPoint?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.PickupPoints.FindAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<PickupPoint>> GetByRegionAsync(string region, CancellationToken cancellationToken)
        {
            return await _context.PickupPoints.Where(p => p.Address.Region == region).ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(PickupPoint pickupPoint, CancellationToken cancellationToken)
        {
            _context.Update(pickupPoint);
            return Task.CompletedTask;
        }
    }
}
