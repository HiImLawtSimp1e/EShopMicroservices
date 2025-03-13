namespace EShop.Service.OrderingApplication.Orders.Queries.GetOrders
{
    public class GetOrdersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            // Usecase business logic here
            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Orders.LongCountAsync(cancellationToken);

            var orders = await dbContext.Orders
                           .Include(o => o.OrderItems)
                           .OrderBy(o => o.OrderName.Value)
                           .Skip(pageSize * pageIndex)
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            var ordersDto = orders.ToOrderDtoList();

            var paginatedResult = new PaginatedResult<OrderDto>(pageIndex, pageSize, totalCount, ordersDto);

            return new GetOrdersResult(paginatedResult);
               
        }
    }
}
