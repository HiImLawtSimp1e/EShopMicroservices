namespace EShop.ShoppingWeb.Services
{
    public interface ICatalogService
    {
        [Get("/catalog-service/categories")]
        Task<GetCategoriesResponse> GetCategories();

        [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetProductsResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);

        [Get("/catalog-service/products/{id}")]
        Task<GetProductByIdResponse> GetProduct(Guid id);

        [Get("/catalog-service/products/category/{category}?pageNumber={pageNumber}&pageSize={pageSize}")]
        Task<GetProductByCategoryResponse> GetProductsByCategory(string category, int? pageNumber = 1, int? pageSize = 10);
    }
}
