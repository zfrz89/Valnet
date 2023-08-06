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
    public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, Model.Cart>
    {
        private readonly ICartRepository _repository;
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public AddItemToCartCommandHandler(ICartRepository repository, IProductService service, IMapper mapper)
        {
            this._repository = repository;
            this._service = service;
            this._mapper = mapper;
        }
        public async Task<Model.Cart> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = await _repository.GetFirstCart(request.UserId);
                var cartAlreadyExist = cart.Products.FirstOrDefault(q => q.ProductId == request.ProductInCartItemDto.ProductId);
                var item = request.ProductInCartItemDto;
                var priceResponse = _service.GetProductPriceAsync(item.ProductId.ToString()).Result;
                if (cartAlreadyExist == null)
                {
                    item.Price = (float)priceResponse;
                    item.CartId = cart.Id;
                    var productToAdd = _mapper.Map<ProductInCart>(item);
                    cart.Products.Add(productToAdd);
                }
                else
                {
                    cartAlreadyExist.Quantity = item.Quantity;
                }
                cart.UpdatedDate = DateTime.Today;
                await _repository.Update(cart);
                return await _repository.GetFirstCart(request.UserId); ;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
