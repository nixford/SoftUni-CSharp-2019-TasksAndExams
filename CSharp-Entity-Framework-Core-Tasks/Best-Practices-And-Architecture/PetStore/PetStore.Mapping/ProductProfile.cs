using AutoMapper;
using PetStore.Models;
using PetStore.Models.Enumerations;
using PetStore.ServiceModels.Products.InputModels;
using PetStore.ServiceModels.Products.OutputModels;
using PetStore.ViewModels.Product.InputViewModels;
using PetStore.ViewModels.Product.OutputViewModels;
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
                .ForMember(x => x.ProductType, 
                y => y.MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));

            this.CreateMap<Product, ProductDetailServiceModel>()
                .ForMember(x => x.ProductType,
                y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByProductTypeServiceModel>();

            this.CreateMap<Product, ListAllProductsServiceModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ProductType, y => y.MapFrom
                (x => x.ProductType.ToString()));

            this.CreateMap<Product, ListAllProductsByNameServiceModel>()
                .ForMember(x => x.ProductId, 
                y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ProductType, 
                y => y.MapFrom(x => x.ProductType.ToString()));

            this.CreateMap<EditProductInputServiceModel, Product>()
                .ForMember(x => x.ProductType, y => y
                .MapFrom(x => Enum.Parse(typeof(ProductType), x.ProductType)));

            this.CreateMap<ListAllProductsServiceModel,
                ListAllProductsViewModel>();

            this.CreateMap<CreateProductInputModel, AddProductInputServiceModel>();

            this.CreateMap<ProductDetailServiceModel, ProductDetailsViewModel>()
                .ForMember(x => x.Price,
                y => y.MapFrom(x => x.Price.ToString("f2")));

            this.CreateMap<ListAllProductsByNameServiceModel,
                ListAllProductsViewModel>();
        }
    }
}
