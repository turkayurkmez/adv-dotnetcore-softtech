﻿using AutoMapper;
using eshop.DataTransferObjects.Request;
using eshop.DataTransferObjects.Response;
using eshop.Entities;

namespace eshop.Application.MapProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductCardResponse>();
            CreateMap<Category, CategoryMenuResponse>();
            CreateMap<CreateNewProductRequest, Product>();
            CreateMap<UpdateExistingProductRequest, Product>();
        }
    }
}
