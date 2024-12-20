using CSharpFunctionalExtensions;
using Domain.BaseClasses.GeneralErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.Core.Domain.SharedKernel
{
    public class Address : ValueObject
    {
        private Address() { }

        private Address(string region, string city, string street, string house)
        {
            Region = region;
            City = city;
            Street = street;
            House = house;
        }
        
        public string Region { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string House { get; private set; }

        public static Result<Address, Error> Create(string region, string city, string street, string house)
        {
            if (string.IsNullOrWhiteSpace(region)) return GeneralErrors.ValueIsRequired(nameof(region));
            if (string.IsNullOrWhiteSpace(city)) return GeneralErrors.ValueIsRequired(nameof(city));
            if (string.IsNullOrWhiteSpace(street)) return GeneralErrors.ValueIsRequired(nameof(street));
            if (string.IsNullOrWhiteSpace(house)) return GeneralErrors.ValueIsRequired(nameof(house));

            return new Address(region, city, street, house);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Region;
            yield return City;
            yield return Street;
            yield return House;
        }
    }
}
