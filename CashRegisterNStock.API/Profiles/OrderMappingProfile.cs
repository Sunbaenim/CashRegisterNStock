using AutoMapper;
using CashRegisterNStock.API.DTOs.Order;
using CashRegisterNStock.BLL.Models;
using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.API.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderAddDTO, OrderModel>()
                .ForMember(dest => dest.ProductOrders, opt => opt.MapFrom(src => src.ProductOrders));
            CreateMap<OrderModel, OrderIndexDTO>()
                .ForMember(dest => dest.ProductOrders, opt => opt.MapFrom(src => src.ProductOrders));

            CreateMap<OrderModel, Order>()
                .ForMember(dest => dest.ProductOrders, opt => opt.MapFrom(src => src.ProductOrders));
            CreateMap<Order, OrderModel>()
                .ForMember(dest => dest.ProductOrders, opt => opt.MapFrom(src => src.ProductOrders));
        }
    }
}
