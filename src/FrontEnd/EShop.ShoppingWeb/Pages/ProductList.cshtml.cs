namespace EShop.ShoppingWeb.Pages
{
    public class ProductListModel(ICatalogService catalogService, IBasketService basketService, ILogger<ProductListModel> logger, IMemoryCache memoryCache) : PageModel
    {
        private readonly IMemoryCache _memoryCache = memoryCache;

        public IEnumerable<string> CategoryList { get; set; } = [];
        public IEnumerable<ProductModel> ProductList { get; set; } = [];

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        public int TotalPages { get; set; }

        // Async methods.
        public async Task<IActionResult> OnGetAsync(string categoryName, int pageNumber = 1)
        {
            CategoryList = await GetCategoryListAsync();

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                var response = await catalogService.GetProductsByCategory(categoryName, pageNumber);

                ProductList = response.Products.Data;

                PageNumber = response.Products.PageNumber;
                TotalPages = response.Products.TotalPage;

                SelectedCategory = categoryName;
            }
            else
            {
                var response = await catalogService.GetProducts(pageNumber);

                ProductList = response.Products.Data;

                PageNumber = response.Products.PageNumber;
                TotalPages = response.Products.TotalPage;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("Add to cart button clicked");
            var productResponse = await catalogService.GetProduct(productId);

            var basket = await basketService.LoadUserBasket();

            var shoppingCartItem = new ShoppingCartItemModel
            {
                ProductId = productId,
                ProductName = productResponse.Product.Name,
                Price = productResponse.Product.Price,
                Quantity = 1,
                Color = "Black"
            };

            basket.Items.Add(shoppingCartItem);

            await basketService.StoreBasket(new StoreBasketRequest(basket));

            return RedirectToPage("Cart");
        }

        private async Task<IEnumerable<string>> GetCategoryListAsync()
        {
            if (!_memoryCache.TryGetValue("CachedCategoryList", out IEnumerable<string>? cachedCategories))
            {
                var categoryResponse = await catalogService.GetCategories();
                cachedCategories = categoryResponse.Categories;

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30));

                _memoryCache.Set("CachedCategoryList", cachedCategories, cacheEntryOptions);
            }
            return cachedCategories!;
        }
    }
}
