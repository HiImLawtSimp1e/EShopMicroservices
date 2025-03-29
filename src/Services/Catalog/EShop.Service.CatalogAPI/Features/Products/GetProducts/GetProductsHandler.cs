namespace EShop.Service.CatalogAPI.Features.Products.GetProducts
{
    public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

    public record GetProductsResult(PaginatedResult<Product> Products);

    internal class GetProductsQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            //Business logic here
            var totalCount = await session.Query<Product>().CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalCount / query.PageSize ?? 10);

            var products = await session.Query<Product>().ToPagedListAsync(query.PageNumber ?? 1, query.PageSize ?? 10, cancellationToken);

            var result = new PaginatedResult<Product>(query.PageNumber, query.PageSize, totalPages, products);

            return new GetProductsResult(result);
        }
    }
}
