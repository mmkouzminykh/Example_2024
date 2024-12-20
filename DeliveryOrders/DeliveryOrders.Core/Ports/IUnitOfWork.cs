using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Core.Ports
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
