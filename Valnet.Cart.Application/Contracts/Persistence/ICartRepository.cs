using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valnet.Cart.Application.Contracts.Persistence
{
    public interface ICartRepository : IGenericRepository<Model.Cart>
    {
        Task<Model.Cart> GetFirstCart(string userId); 
    }
}
