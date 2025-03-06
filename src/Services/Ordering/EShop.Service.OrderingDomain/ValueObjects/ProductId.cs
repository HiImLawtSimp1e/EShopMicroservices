namespace EShop.Service.OrderingDomain.ValueObjects
{
    public record ProductId
    {
        public Guid Value { get; }
        private ProductId() { }
        private ProductId(Guid value) => Value = value;
        public static ProductId Of(Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException("ProductId cannot be empty.");
            }

            return new ProductId(value);
        }
    }
}
