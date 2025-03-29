namespace EShop.Service.CatalogAPI.Features.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category, int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductByCategoryResult>;
    
    public record GetProductByCategoryResult(PaginatedResult<Product> Products);

    internal class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            //Queries here
            var totalCount = await session.Query<Product>()
                                        .Where(p => p.Category.Contains(query.Category))
                                        .CountAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalCount / query.PageSize ?? 10);

            var products = await session.Query<Product>()
                                      .Where(p => p.Category.Contains(query.Category))
                                      .ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

            var result = new PaginatedResult<Product>(query.PageNumber, query.PageSize, totalPages, products);

            return new GetProductByCategoryResult(result);
        }
    }
}
