using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Contracts.Infrastructure;
using Valnet.Cart.Application.Contracts.Persistence;
using Valnet.Cart.Application.Features.Carts.Requests.Commands;
using Valnet.Cart.Model;

namespace Valnet.Cart.Application.Features.Carts.Handlers.Commands
{
    public class RemoveItemFromCartCommandHandler : IRequestHandler<RemoveItemFromCartCommand, Model.Cart>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductInCartRepository _productInCartRepository;
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public RemoveItemFromCartCommandHandler(ICartRepository  cartRepository,
            IProductInCartRepository productInCartRepository,
            IProductService service, 
            IMapper mapper)
        {
            _cartRepository = cartRepository;
            _productInCartRepository = productInCartRepository;
            _service = service;
            _mapper = mapper;
        }
        public async Task<Model.Cart> Handle(RemoveItemFromCartCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.GetFirstCart(request.UserId);
            if (cart == null)
                return cart;

            await _productInCartRepository.RemoveProductInCart(request.ProductId, cart.Id.ToString());

            return await _cartRepository.GetFirstCart(request.UserId);
        }
    }
}
