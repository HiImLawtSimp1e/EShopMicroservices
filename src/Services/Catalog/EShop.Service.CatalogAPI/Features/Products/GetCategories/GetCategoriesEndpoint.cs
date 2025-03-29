namespace EShop.Service.CatalogAPI.Features.Products.GetCategories
{
    public record GetCategoriesRequest();
    public record GetCategoriesResponse(IEnumerable<string> Categories);
    public class GetCategoriesEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            // Config Minimal API Endpoint here - Carter library
            app.MapGet("/categories", async (ISender sender) =>
            {
                var result = await sender.Send(new GetCategoriesQuery());

                var response = result.Adapt<GetCategoriesResponse>();

                return Results.Ok(response);

            }).WithName("GetCategories")
              .Produces<GetCategoriesResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Get Categories")
              .WithDescription("Get Categories");
        }
    }
}
