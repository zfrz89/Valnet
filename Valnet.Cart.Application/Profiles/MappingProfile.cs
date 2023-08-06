using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Valnet.Cart.Application.Dtos.CartDtos;
using Valnet.Cart.Application.Dtos.ProductInCartDtos;
using Valnet.Cart.Model;

namespace Valnet.Cart.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CartDto, Model.Cart>().ReverseMap();
            CreateMap<ProductInCartItemDto, ProductInCart>().ReverseMap();
        }
    }
}
