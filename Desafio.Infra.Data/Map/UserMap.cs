using Desafio.Domain.DomainEntities;
using FluentNHibernate.Mapping;

namespace Desafio.Infra.Data.Map
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.FirstName).Length(30).Not.Nullable();
            Map(x => x.LastName).Length(30).Not.Nullable();
            Map(x => x.Email).Length(30).Not.Nullable();
            Map(x => x.Age).Not.Nullable();
            Map(x => x.Nationality).Not.Nullable();
            Map(x => x.Cpf).Length(15).Not.Nullable();
            Map(x => x.Login).Length(30).Not.Nullable();
            Map(x => x.Password).Length(36).Not.Nullable();
            Map(x => x.Phone).Length(20).Nullable();
            Map(x => x.CellPhone).Length(20).Nullable();
            Map(x => x.IsActive).Not.Nullable();
            Map(x => x.CreatedAt).Not.Nullable();
            Map(x => x.CreatedBy).Not.Nullable();
            Map(x => x.ProfileId).Not.Nullable();
            Map(x => x.DeletedAt).Nullable();
            Map(x => x.DeletedBy).Nullable();
            Map(x => x.AddressId).Nullable();
            //References(x => x.Profile)
            //.Column("ProfileId");
            //References(x => x.Address)
            //.Column("AddressId");

        }
    }
}