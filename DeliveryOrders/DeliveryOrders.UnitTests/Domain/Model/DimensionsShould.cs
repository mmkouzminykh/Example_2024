using DeliveryOrders.Core.Domain.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.UnitTests.Domain.Model
{
    public class DimensionsShould
    {
        [Theory]
        [InlineData(1, 1, 1, 1)]
        [InlineData(2, 2, 2, 100)]
        [InlineData(1.5, 1.5, 1.5, 50)]
        public void CreateCorrectObject(decimal length, decimal width, decimal height, decimal weight)
        {
            var dimensions = Dimensions.Create(length, width, height, weight);

            dimensions.IsSuccess.Should().BeTrue();
            dimensions.Value.Length.Should().Be(length);
            dimensions.Value.Width.Should().Be(width);
            dimensions.Value.Height.Should().Be(height);
            dimensions.Value.Weight.Should().Be(weight);            
        }

        [Theory]
        [InlineData(0, 1, 1, 1)]
        [InlineData(1, 3, 1, 1)]
        [InlineData(1, 1, 0, 1)]
        [InlineData(1, 1, 1, 300)]
        public void ReturnFailureForWrongParameters(decimal length, decimal width, decimal height, decimal weight)
        {
            var dimensions = Dimensions.Create(length, width, height, weight);

            dimensions.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void CalculateCorrectVolume()
        {
            var dimensions = Dimensions.Create(1, 2, 2, 5);

            dimensions.Value.Volume.Should().Be(4);
        }

        [Fact]
        public void BeEqualToSimilarDimensions()
        {
            var first = Dimensions.Create(1, 1, 1, 1);
            var second = Dimensions.Create(1, 1, 1, 1);

            var result = first.Value == second.Value;

            result.Should().BeTrue();
        }

        [Fact]
        public void BeNotEqualToAnotherDimensions()
        {
            var first = Dimensions.Create(1, 1, 1, 1);
            var second = Dimensions.Create(1, 1, 2, 1);

            var result = first.Value == second.Value;

            result.Should().BeFalse();
        }
    }
}
