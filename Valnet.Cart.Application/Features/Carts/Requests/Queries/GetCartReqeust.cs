using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Dtos.CartDtos;

namespace Valnet.Cart.Application.Features.Carts.Requests.Queries
{
    public class GetCartReqeust:IRequest<CartDto>
    {
        public string UserId { get; set; } 
    }
}
