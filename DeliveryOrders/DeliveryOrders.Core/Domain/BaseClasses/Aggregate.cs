using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Core.Domain.BaseClasses
{
    public class Aggregate: Entity<Guid>
    {
        protected Aggregate(Guid id) : base(id) { }

        protected Aggregate() { }
    }
}
