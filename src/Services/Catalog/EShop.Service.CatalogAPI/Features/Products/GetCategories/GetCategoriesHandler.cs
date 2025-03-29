namespace EShop.Service.CatalogAPI.Features.Products.GetCategories
{
    public record GetCategoriesQuery() : IQuery<GetCategoriesResult>;
    public record GetCategoriesResult(IEnumerable<string> Categories);
    public class GetCategoriesQueryHandler(IDocumentSession session) : IQueryHandler<GetCategoriesQuery, GetCategoriesResult>
    {
        public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            //Business logic here
            var categories = await session.Query<Product>()
                                        .SelectMany(p => p.Category)
                                        .Distinct()
                                        .ToListAsync();

            return new GetCategoriesResult(categories);
        }
    }
}
