namespace EShop.Service.OrderingApplication.DTOs
{
    public record OrderItemDto (Guid OrderId, Guid ProductId, int Quantity, decimal Price);
}
