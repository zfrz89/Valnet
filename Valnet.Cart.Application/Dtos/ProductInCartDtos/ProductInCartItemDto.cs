using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valnet.Cart.Application.Dtos.ProductInCartDtos
{
    public class ProductInCartItemDto
    {
        public long ProductId { get; set; }   
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public float Price { get; set; }
    }
}
