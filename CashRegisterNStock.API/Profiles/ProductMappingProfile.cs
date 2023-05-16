using AutoMapper;
using CashRegisterNStock.API.DTOs.Product;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Entities;
using CashRegisterNStock.BLL.Services;

namespace CashRegisterNStock.API.Profiles
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductAddDTO, ProductModel>();
            CreateMap<ProductUpdateDTO, ProductModel>();

            CreateMap<ProductModel, ProductIndexDTO>();
            CreateMap<ProductIndexDTO, ProductModel>();

            CreateMap<ProductModel, Product>();
                //.ForMember(p => p.ImageUrl, opt => opt.MapFrom(src => ProductService.ConvertAndStoreImage(src)));
            CreateMap<Product, ProductModel>();

            CreateMap<Product, Product>();
        }
    }
}
