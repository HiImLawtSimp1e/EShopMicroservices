namespace EShop.Service.OrderingApplication.Orders.Queries.GetOrders
{
    public class GetOrdersHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersQuery, GetOrdersResult>
    {
        public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
        {
            // Usecase business logic here
            var pageNumber = query.PaginationRequest.PageNumber;
            var pageSize = query.PaginationRequest.PageSize;

            var totalCount = await dbContext.Orders.CountAsync(cancellationToken);

            var orders = await dbContext.Orders
                           .Include(o => o.OrderItems)
                           .OrderBy(o => o.OrderName.Value)
                           .Skip(pageSize * (pageNumber - 1))
                           .Take(pageSize)
                           .ToListAsync(cancellationToken);

            var ordersDto = orders.ToOrderDtoList();

            var paginatedResult = new PaginatedResult<OrderDto>(pageNumber, pageSize, totalCount, ordersDto);

            return new GetOrdersResult(paginatedResult);
               
        }
    }
}
