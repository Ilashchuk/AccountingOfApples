using AccountingOfApples.ViewModels;
using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace AccountingOfApples;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<Client, ClientDTO>().ReverseMap();
        CreateMap<ClientDTO, ClientViewModel>().ReverseMap();

        CreateMap<Owner, OwnerDTO>().ReverseMap();
        CreateMap<OwnerDTO, OwnerViewModel>().ReverseMap();

        CreateMap<Area, AreaDTO>().ReverseMap();
        CreateMap<AreaDTO, AreaViewModel>().ReverseMap();

        CreateMap<AppleVariety, AppleVarietyDTO>().ReverseMap();
        CreateMap<AppleVarietyDTO, AppleVarietyViewModel>().ReverseMap();

        CreateMap<ForJuice, ForJuiceDTO>().ReverseMap();
        CreateMap<ForJuiceDTO, ForJuiceViewModel>().ReverseMap();

        CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.OrderAppleVarieties, opt => opt.MapFrom(src => src.OrderAppleVarieties))
            .ReverseMap();

        CreateMap<OrderDTO, OrderViewModel>()
            .ForMember(dest => dest.orderAppleVarietyList, opt => opt.MapFrom(src => src.OrderAppleVarieties))
            .ReverseMap();

        CreateMap<OrderAppleVariety, OrderAppleVarietyDTO>().ReverseMap();
        CreateMap<OrderAppleVarietyDTO, OrderAppleVarietyViewModel>().ReverseMap();
    }
}
