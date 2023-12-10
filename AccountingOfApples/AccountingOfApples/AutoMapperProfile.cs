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

        CreateMap<Packaging, PackagingDTO>().ReverseMap();
        CreateMap<PackagingDTO, PackagingViewModel>().ReverseMap();

        CreateMap<AreaDTO, Area>()
            .ForMember(dest => dest.AreaAppleVarieties, opt => opt.MapFrom(src => src.AppleVarieties.Select(av => new AreaAppleVariety { 
                AreaId = src.Id, 
                AppleVarietyId = av.Id 
            })));

        CreateMap<AreaDTO, AreaViewModel>()
            .ForMember(dest => dest.AppleVarieties, opt => opt.MapFrom(src => src.AppleVarieties))
            .ReverseMap();

        CreateMap<Area, AreaDTO>()
            .ForMember(dest => dest.AppleVarieties, opt => opt.MapFrom(src => src.AreaAppleVarieties.Select(aav => aav.AppleVariety).ToList()))
            .ForMember(dest => dest.OrderAppleVarieties, opt => opt.MapFrom(src => src.OrderAppleVarieties));

        CreateMap<AppleVariety, AppleVarietyDTO>()
            .ForMember(dest => dest.AreaAppleVarieties, opt => opt.MapFrom(src => src.AreaAppleVarieties.Select(aav => aav.Area).ToList()))
            .ForMember(dest => dest.OrderAppleVarieties, opt => opt.MapFrom(src => src.OrderAppleVarieties));

    }
}
