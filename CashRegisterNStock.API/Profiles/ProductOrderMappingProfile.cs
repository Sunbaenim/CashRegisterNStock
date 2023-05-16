using AutoMapper;
using CashRegisterNStock.API.DTOs.ProductOrder;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.API.Profiles
{
    public class ProductOrderMappingProfile : Profile
    {
        public ProductOrderMappingProfile()
        {
            CreateMap<ProductOrderAddDTO, ProductOrderModel>();
            CreateMap<ProductOrderModel, ProductOrderIndexDTO>();

            CreateMap<ProductOrderModel, ProductOrder>();
            CreateMap<ProductOrder, ProductOrderModel>();
        }
    }
}
