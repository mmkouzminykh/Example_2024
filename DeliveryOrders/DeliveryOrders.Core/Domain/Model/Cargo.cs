using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Core.Domain.Model
{
    public sealed class Cargo: Entity<long>
    {
        public static Result<Cargo> Create(long id, Dimensions dimensions, string packageType, string cargoType, string? comment)
        {
            if (id <= 0)
                return Result.Failure<Cargo>("Недопустимое значение Id");
            if (dimensions == null)
                return Result.Failure<Cargo>("Не переданы измерения груза");
            if (string.IsNullOrWhiteSpace(packageType))
                return Result.Failure<Cargo>("Не указан тип упаковки");
            if (string.IsNullOrWhiteSpace(cargoType))
                return Result.Failure<Cargo>("Не указан тип груза");

            return new Cargo(id, dimensions, packageType, cargoType, comment);
        }

        private Cargo() { }

        private Cargo(long id, Dimensions dimensions, string packageType, string cargoType, string? comment): base (id)
        {
            Dimensions = dimensions;
            PackageType = packageType;
            CargoType = cargoType;
            Comment = comment;
        }

        public Dimensions Dimensions { get; private set; }

        public string PackageType { get; private set; }

        public string CargoType { get; private set; }

        public string? Comment { get; set; }

    }
}
