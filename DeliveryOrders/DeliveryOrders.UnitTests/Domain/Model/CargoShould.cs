using DeliveryOrders.Core.Domain.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.UnitTests.Domain.Model
{
    public class CargoShould
    {
        [Fact]
        public void BeEqualToCargoWithSameId()
        {
            var dimensions = Dimensions.Create(1, 1, 1, 1).Value;

            var first = Cargo.Create(1, dimensions, "Коробка", "Хрупкий", "");
            var second = Cargo.Create(1, dimensions, "Пакет", "Ядовитый", "");

            var result = first.Value.Equals(second.Value);

            result.Should().BeTrue();
        }

        [Fact]
        public void BeNotEqualToCargoWithAnotherId()
        {
            var dimensions = Dimensions.Create(1, 1, 1, 1).Value;

            var first = Cargo.Create(1, dimensions, "Пакет", "Ядовитый", "");
            var second = Cargo.Create(2, dimensions, "Пакет", "Ядовитый", "");

            var result = first.Value.Equals(second.Value);

            result.Should().BeFalse();
        }
    }
}
