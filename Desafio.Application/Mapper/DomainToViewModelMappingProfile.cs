using AutoMapper;
using Desafio.Application.ViewModels;

namespace Desafio.Application.Mapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Domain.DomainEntities.User, UserViewModel>();
            CreateMap<Domain.DomainEntities.Address, AddressViewModel>();
            CreateMap<Domain.DomainEntities.Role, RoleViewModel>();
            CreateMap<Domain.DomainEntities.Profile, ProfileViewModel>();
        }
    }
}