﻿using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<AddProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y.MapFrom
                (x => Enum.Parse(typeof(ProductType), x.productType)));

            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();

            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductType, y => y.MapFrom
                (x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.ProductType, 
                y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y
                .MapFrom(x => Enum.Parse(typeof(ProductType), x.productType)));
        }
    }
}
