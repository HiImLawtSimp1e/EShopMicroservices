namespace EShop.Service.OrderingApplication.Orders.Queries.GetOrderByName
{
    public class GetOrderByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
    {
        public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
        {
            // Usecase business logic here
            var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

            var orders = await dbContext.Orders
                           .Include(o => o.OrderItems)
                           .AsNoTracking()
                           .Where(o => o.OrderName.Value.Contains(query.Name))
                           .OrderBy(o => o.OrderName.Value)
                           .ToListAsync(cancellationToken);

            var ordersDto = orders.ToOrderDtoList();

            return new GetOrderByNameResult(ordersDto);
        }
    }
}
