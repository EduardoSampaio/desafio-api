using AutoMapper;
using Desafio.Application.ViewModels;
using Entities = Desafio.Domain.DomainEntities;

namespace Desafio.Application.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UserRegisterViewModel, Entities.User>();
            CreateMap<UserUpdateViewModel, Entities.User>();
            CreateMap<UserViewModel, Entities.User>();
            CreateMap<AddressViewModel, Entities.Address>();
            CreateMap<AddressRegisterViewModel, Entities.Address>();
            CreateMap<ProfileViewModel, Entities.Profile>();
            CreateMap<RoleViewModel, Entities.Role>();
            CreateMap<ProfileViewModel, Entities.ProfileRole>();
        }
    }
}