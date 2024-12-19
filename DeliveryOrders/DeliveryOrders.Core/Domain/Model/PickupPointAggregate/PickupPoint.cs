using CSharpFunctionalExtensions;
using DeliveryOrders.Core.Domain.BaseClasses;
using DeliveryOrders.Core.Domain.SharedKernel;
using Domain.BaseClasses.GeneralErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Core.Domain.Model.PickupPointAggregate
{
    public class PickupPoint: Aggregate
    {
        private PickupPoint() { }

        private PickupPoint(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; private set; }
        public Address Address { get; private set; }

        public Result<PickupPoint, Error> Create(string name, Address address)
        {
            if (string.IsNullOrWhiteSpace(name)) return GeneralErrors.ValueIsRequired(nameof(name));
            if (address == null) return GeneralErrors.ValueIsRequired(nameof(address));

            return new PickupPoint(name, address);
        }
    }
}
