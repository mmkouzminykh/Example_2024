using CSharpFunctionalExtensions;

namespace DeliveryOrders.Core.Domain.Model
{
    public sealed class Dimensions : ValueObject
    {
        public static Result<Dimensions> Create(decimal length, decimal width, decimal height, decimal weight)
        {
            if (length <= 0 || length > 2)
                return Result.Failure<Dimensions>("Недопустимое значение длины");
            if (width <= 0 || width > 2)
                return Result.Failure<Dimensions>("Недопустимое значение ширины");
            if (height <= 0 || height > 2)
                return Result.Failure<Dimensions>("Недопустимое значение высоты");
            if (weight <= 0 || weight > 100)
                return Result.Failure<Dimensions>("Недопустимый значение веса");

            return new Dimensions(length, width, height, weight);   
        }

        private Dimensions() { }

        private Dimensions(decimal length, decimal width,  decimal height, decimal weight)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;

            Volume = length * width * height;
        }

        public decimal Length { get; private set; }

        public decimal Width { get; private set; }

        public decimal Height { get; private set; }

        public decimal Weight { get; private set; }

        public decimal Volume { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Length;
            yield return Width;
            yield return Height;
            yield return Weight;
        }
    }
}
