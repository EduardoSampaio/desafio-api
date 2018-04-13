using Desafio.Application.AutoMapper;
using Desafio.Application.Interfaces;
using Desafio.Application.Services;
using Desafio.Domain.Interface;
using Desafio.Domain.Repository;
using Desafio.Infra.Data.Repository;
using SimpleInjector;

namespace Desafio.Infra.Crosscutting.IOC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            //Auto Mapper
            var config = AutoMapperConfig.RegisterMappings();
            container.RegisterSingleton(config);
            container.Register(() => config.CreateMapper(container.GetInstance));

            //Application - Domain
            container.Register<IUserAppService, UserAppService>(Lifestyle.Transient);
            container.Register<IAddressAppService, AddressAppService>(Lifestyle.Transient);
            container.Register<IRoleAppService, RoleAppService>(Lifestyle.Transient);
            container.Register<IProfileAppService, ProfileAppService>(Lifestyle.Transient);
            container.Register<IProfileRoleAppService, ProfileRoleAppService>(Lifestyle.Transient);

            //Domain - Repository
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IAddressRepository, AddressRepository>(Lifestyle.Scoped);
            container.Register<IRoleRepository, RoleRepository>(Lifestyle.Scoped);
            container.Register<IProfileRepository, ProfileRepository>(Lifestyle.Scoped);
            container.Register<IProfileRoleRepository, ProfileRoleRepository>(Lifestyle.Scoped);
        }
    }
}
