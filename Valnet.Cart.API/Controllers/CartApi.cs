using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Valnet.Cart.Application.Dtos.ProductInCartDtos;
using Valnet.Cart.Application.Features.Carts.Requests.Commands;
using Valnet.Cart.Application.Features.Carts.Requests.Queries;

namespace Valnet.Cart.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CartApi : ControllerBase
{
    private readonly IMediator _mediator;

    public CartApi(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("{userId}/cart", Name = "GetCart")]
    public async Task<ActionResult<Model.Cart>> Get(string userId)
    {
        try
        {
            var cart = await _mediator.Send(new GetCartReqeust { UserId = userId });
            return Ok(cart);
        }
        catch
        {
            Log.Information("Something went wrong!");
            throw new ApplicationException("Something went wrong, please try again later!");
        }
    }

    

    [HttpPost("{userId}/cart/items", Name = "Add Or Update Product And Its Qty")]
    public async Task<ActionResult<Model.Cart>> AddOrUpdate(string userId, ProductInCartItemDto item)
    {
        try
        {
            var cart = await _mediator.Send(new AddItemToCartCommand { UserId = userId, ProductInCartItemDto = item });
            return Ok(cart);
        }
        catch
        {
            Log.Debug("Something went wrong!");
            throw new ApplicationException("Something went wrong, please try again later!");
        }
    }


    [HttpDelete("{userId}/cart/items", Name = "Remove Item from Cart")]
    public async Task<ActionResult<Model.Cart>> Remove(string userId, string productId)
    {
        try
        {
            var cart = await _mediator.Send(new RemoveItemFromCartCommand { UserId = userId, ProductId= productId});
            return Ok(cart);
        }
        catch
        {
            Log.Debug("Something went wrong!");
            throw new ApplicationException("Something went wrong, please try again later!");
        }
    }


}