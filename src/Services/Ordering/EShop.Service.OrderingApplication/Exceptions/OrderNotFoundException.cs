using BuidingBlocks.Exceptions;

namespace EShop.Service.OrderingApplication.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(Guid id) : base("Order", id)
        {
        }
    }
}
