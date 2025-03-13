namespace EShop.Service.OrderingApplication.Orders.Queries.GetOrderByCustomer
{
    public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerResult>;

    public record GetOrdersByCustomerResult(IEnumerable<OrderDto> Orders);
}
