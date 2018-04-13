using Desafio.Domain.DomainEntities;
using FluentNHibernate.Mapping;

namespace Desafio.Infra.Data.Map
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("Role");
            Id(x => x.Id);
            Map(x => x.Name).Length(30).Not.Nullable();
            Map(x => x.Description).Length(100).Not.Nullable();
           // HasMany(x => x.ProfileRoles)
           //.Inverse()
           //.Cascade.All()
           //.KeyColumn("ProfileRoles");
        }
    }
}