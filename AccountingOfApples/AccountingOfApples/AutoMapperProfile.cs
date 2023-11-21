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
    }
}
