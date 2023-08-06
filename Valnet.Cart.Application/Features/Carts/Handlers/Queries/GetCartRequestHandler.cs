using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Contracts.Infrastructure;
using Valnet.Cart.Application.Contracts.Persistence;
using Valnet.Cart.Application.Dtos.CartDtos;
using Valnet.Cart.Application.Features.Carts.Requests.Queries;

namespace Valnet.Cart.Application.Features.Carts.Handlers.Queries
{
    internal class GetCartRequestHandler : IRequestHandler<GetCartReqeust, CartDto>
    {
        private readonly ICartRepository _repository;
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public GetCartRequestHandler(ICartRepository repository , IProductService service, IMapper mapper)
        {
            this._repository = repository;
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<CartDto> Handle(GetCartReqeust request, CancellationToken cancellationToken)
        {
            try
            {
                //var cart = _context.Carts.First(c => c.UserId == int.Parse(userId));  
                var cart = await _repository.GetFirstCart(request.UserId);
                var cartDto = _mapper.Map<CartDto>(cart);

                foreach (var product in cart.Products)
                {
                    var price = _service.GetProductPriceAsync(product.ProductId.ToString()).Result;
                    cartDto.Total += (float)price * product.Quantity;
                }
                return cartDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
