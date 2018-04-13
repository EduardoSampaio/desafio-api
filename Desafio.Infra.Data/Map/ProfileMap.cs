using Desafio.Domain.DomainEntities;
using FluentNHibernate.Mapping;

namespace Desafio.Infra.Data.Map
{
    public class ProfileMap : ClassMap<Profile>
    {
        public ProfileMap()
        {
            Table("Profile");
            Id(x => x.Id);
            Map(x => x.Name).Length(30).Not.Nullable();
           // HasMany(x => x.Users)
           //    .Inverse()
           //    .Cascade.All()
           //    .KeyColumn("Users");
           // HasMany(x => x.ProfileRoles)
           //.Inverse()
           //.Cascade.All()
           //.KeyColumn("ProfileRoles");
        }
    }
}