namespace EShop.Service.OrderingDomain.Models
{
    public class OrderItem : Entity<Guid>
    {
        protected OrderItem() { }
        internal OrderItem(Guid orderId, Guid productId, int quantity, decimal price)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid OrderId { get; private set; } = default!;
        public Guid ProductId { get; private set; } = default!;
        public int Quantity { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;
    }
}
