using CSharpFunctionalExtensions;
using DeliveryOrders.Core.Domain.BaseClasses;
using Domain.BaseClasses.GeneralErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Core.Domain.Model.ShipmentAggregate
{
    public class Shipment: Aggregate
    {       

        private Shipment()
        { }

        private Shipment(Guid departurePointId, Guid destinationPointId, DateTime shipmentDate)
        {
            DeparturePointId = departurePointId;
            DestinationPointId = destinationPointId;
            ShipmentDate = shipmentDate;

        }   

        public Guid DeparturePointId { get; private set; }

        public Guid DestinationPointId { get; private set; }

        public DateTime ShipmentDate { get; private set; }

        public Decimal TotalWeight {
            get => cargos.Sum(c => c.Dimensions.Weight); 
        }

        public List<Cargo> cargos { get; private set; } = new();

        public Result<Shipment, Error> Create(Guid departurePointId, Guid destinationPointId, DateTime shipmentDate)
        {
            if (departurePointId == Guid.Empty) return GeneralErrors.ValueIsRequired(nameof(departurePointId));
            if (destinationPointId == Guid.Empty) return GeneralErrors.ValueIsRequired(nameof(destinationPointId));
            if (shipmentDate == DateTime.MinValue) return GeneralErrors.ValueIsRequired(nameof(shipmentDate));

            return new Shipment(departurePointId, destinationPointId, shipmentDate);
        }

        public UnitResult<Error> AddCargo(Cargo cargo)
        {
            if (cargo == null) return GeneralErrors.ValueIsRequired(nameof(cargo));
            if (cargos.Contains(cargo)) return Errors.CargoAlreadyAdded();

            cargos.Add(cargo);
            return UnitResult.Success<Error>();
        }

        public static class Errors
        {
            public static Error CargoAlreadyAdded()
            {
                return new Error("cargo.already.added", "Груз уже добавлен в отправление");
            }
        }

    }
}
