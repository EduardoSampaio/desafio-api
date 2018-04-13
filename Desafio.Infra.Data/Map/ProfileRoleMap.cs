using Desafio.Domain.DomainEntities;
using FluentNHibernate.Mapping;

namespace Desafio.Infra.Data.Map
{
    public class ProfileRoleMap : ClassMap<ProfileRole>
    {
        public ProfileRoleMap()
        {
            Table("ProfileRole");
            Id(x => x.Id);
            Map(x => x.ProfileId).Not.Nullable();
            Map(x => x.RoleId).Not.Nullable();
            //References(x => x.Profile).ForeignKey("ProfileId");
            //References(x => x.Role).ForeignKey("RoleId");
        }
    }
}