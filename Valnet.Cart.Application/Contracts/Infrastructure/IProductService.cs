using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valnet.Cart.Application.Contracts.Infrastructure
{
    public interface IProductService 
    {
        Task<decimal> GetProductPriceAsync(string productId);
    }
}
