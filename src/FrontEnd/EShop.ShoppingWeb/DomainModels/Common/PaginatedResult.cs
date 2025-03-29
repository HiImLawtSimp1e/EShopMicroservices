namespace EShop.ShoppingWeb.DomainModels.Common
{
    public class PaginatedResult<TEntity>(int pageNumber, int pageSize, int totalPage, IEnumerable<TEntity> data) where TEntity : class
    {
        public int PageNumber { get; } = pageNumber;
        public int PageSize { get; } = pageSize;
        public int TotalPage { get; } = totalPage;
        public IEnumerable<TEntity> Data { get; } = data;
    }
}
