using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Dtos.ProductInCartDtos;

namespace Valnet.Cart.Application.Features.Carts.Requests.Commands
{
    public class RemoveItemFromCartCommand:IRequest<Model.Cart>
    {
        public string UserId { get; set; } 
        public string ProductId { get; set; }
    }
}
