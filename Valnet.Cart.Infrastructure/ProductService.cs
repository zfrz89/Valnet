using Valnet.Cart.Application.Contracts.Infrastructure;

namespace Valnet.Cart.Infrastructure
{
    public class ProductService : IProductService
    {
        public async Task<decimal> GetProductPriceAsync(string productId)
        {
            if (productId == "1")
                return (decimal)10.0;
            if (productId == "2")
                return (decimal)20.0;            
            return (decimal)30.0;
        }
    }
}