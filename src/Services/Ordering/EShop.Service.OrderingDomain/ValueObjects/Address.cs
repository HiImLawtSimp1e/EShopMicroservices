using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EShop.Service.OrderingDomain.ValueObjects
{
    [Owned]
    public record Address
    {
        public string FirstName { get; init; } = default!;
        public string LastName { get; init; } = default!;
        public string? EmailAddress { get; init; } = default!;
        public string AddressLine { get; init; } = default!;
        public string Country { get; init; } = default!;
        public string State { get; init; } = default!;
        public string ZipCode { get; init; } = default!;

        [JsonConstructor]
        public Address(string firstName, string lastName, string? emailAddress, string addressLine, string country, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            AddressLine = addressLine;
            Country = country;
            State = state;
            ZipCode = zipCode;
        }

        public static Address Of(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            ArgumentException.ThrowIfNullOrWhiteSpace(addressLine);

            return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
        }
    }
}
