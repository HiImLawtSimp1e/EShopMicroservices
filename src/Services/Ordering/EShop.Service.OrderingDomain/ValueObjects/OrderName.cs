using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace EShop.Service.OrderingDomain.ValueObjects
{
    [Owned]
    public record OrderName
    {
        private const int DefaultLength = 5;
        public string Value { get; init; } = default!;

        [JsonConstructor]
        public OrderName(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLength);

            Value = value;
        }

        public static OrderName Of(string value)
        {
            return new OrderName(value);
        }
    }
}
