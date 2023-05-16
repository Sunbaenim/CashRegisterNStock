using AutoMapper;
using CashRegisterNStock.API.DTOs.Category;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.API.Profiles
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CategoryAddDTO, CategoryModel>();

            CreateMap<CategoryIndexDTO, CategoryModel>();
            CreateMap<CategoryModel, CategoryIndexDTO>();

            CreateMap<CategoryModel, CategoryWithProductsIndexDTO>()
                .ForMember(c => c.Products, opt => opt.MapFrom(cc => cc.Products));
            CreateMap<CategoryWithProductsIndexDTO, CategoryModel>();

            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();

            CreateMap<Category, Category>();
        }
    }
}
