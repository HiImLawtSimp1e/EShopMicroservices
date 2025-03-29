namespace EShop.Service.CatalogAPI.Features.Products.GetProductByCategory
{
    public record GetProductByCategoryRequest(string Category, int? PageNumber = 1, int? PageSize = 10);

    public record GetProductByCategoryResponse(PaginatedResult<Product> Products);

    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Config Minimal API Endpoint here - Carter library
            app.MapGet("/products/category/{category}", async ([AsParameters] GetProductByCategoryRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductByCategoryQuery>();

                var result = await sender.Send(query);

                var response = result.Adapt<GetProductByCategoryResponse>();

                return Results.Ok(response);

            }).WithName("GetProductByCategory")
           .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("Get Product By Category")
           .WithDescription("Get Product By Category");
        }
    }
}
