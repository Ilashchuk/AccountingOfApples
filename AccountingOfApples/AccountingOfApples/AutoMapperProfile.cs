using AccountingOfApples.ViewModels;
using AutoMapper;
using DAL.Models;

namespace AccountingOfApples;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<Client, ClientDTO>().ReverseMap();
        CreateMap<ClientDTO, ClientViewModel>().ReverseMap();
    }
}
