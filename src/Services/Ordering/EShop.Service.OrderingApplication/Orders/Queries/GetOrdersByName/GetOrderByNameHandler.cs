﻿namespace EShop.Service.OrderingApplication.Orders.Queries.GetOrdersByName
{
    public class GetOrderByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrdersByNameQuery, GetOrdersByNameResult>
    {
        public async Task<GetOrdersByNameResult> Handle(GetOrdersByNameQuery query, CancellationToken cancellationToken)
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

            return new GetOrdersByNameResult(ordersDto);
        }
    }
}
