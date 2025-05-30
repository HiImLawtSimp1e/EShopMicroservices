﻿namespace EShop.Service.OrderingDomain.ValueObjects
{
    public record OrderItemId
    {
        public Guid Value { get; }
        private OrderItemId() { }
        private OrderItemId(Guid value) => Value = value;
        public static OrderItemId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("OrderItemId cannot be empty.");
            }

            return new OrderItemId(value);
        }
    }
}
