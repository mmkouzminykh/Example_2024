using DeliveryOrders.Core.Domain.Model.PickupPointAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Core.Ports
{
    public interface IPickPointRepository
    {
        public Task AddAsync(PickupPoint pickupPoint, CancellationToken cancellationToken);

        public Task UpdateAsync(PickupPoint pickupPoint, CancellationToken cancellationToken);

        public Task<PickupPoint> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<IEnumerable<PickupPoint>> GetAllAsync(CancellationToken cancellationToken);

        public Task<IEnumerable<PickupPoint>> GetByRegionAsync(string region, CancellationToken cancellationToken);
    }
}
