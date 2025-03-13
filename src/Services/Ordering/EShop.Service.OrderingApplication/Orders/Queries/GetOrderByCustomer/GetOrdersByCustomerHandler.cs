namespace EShop.Service.OrderingApplication.Orders.Queries.GetOrderByCustomer
{
    public class GetOrdersByCustomerHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {
            // Usecase business logic here
            var orders = await dbContext.Orders
                            .Include(o => o.OrderItems)
                            .AsNoTracking()
                            .Where(o => o.CustomerId == query.CustomerId)
                            .OrderBy(o => o.OrderName.Value)
                            .ToListAsync(cancellationToken);

            var ordersDto = orders.ToOrderDtoList();

            return new GetOrdersByCustomerResult(ordersDto);
        }
    }
}
