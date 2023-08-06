using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Model;

namespace Valnet.Cart.Application.Contracts.Persistence
{
    public interface IProductInCartRepository:IGenericRepository<ProductInCart>
    {
        Task RemoveProductInCart(string ProductId, string CartId); 
    }
}
