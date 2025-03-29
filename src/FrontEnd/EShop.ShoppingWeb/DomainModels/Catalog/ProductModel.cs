namespace EShop.ShoppingWeb.DomainModels.Catalog
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public List<string> Category { get; set; } = new();
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public decimal Price { get; set; }
    }

    //wrapper classes
    public record GetCategoriesResponse(IEnumerable<string> Categories);
    public record GetProductsResponse(PaginatedResult<ProductModel> Products);
    public record GetProductByCategoryResponse(PaginatedResult<ProductModel> Products);
    public record GetProductByIdResponse(ProductModel Product);
}
