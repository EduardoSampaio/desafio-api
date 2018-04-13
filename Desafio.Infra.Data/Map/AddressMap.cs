using Desafio.Domain.DomainEntities;
using FluentNHibernate.Mapping;

namespace Desafio.Infra.Data.Map
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Address");
            Id(x => x.Id);
            Map(x => x.Complement).Length(100).Nullable();
            Map(x => x.Number).Length(30).Nullable();
            Map(x => x.Neighborhood).Length(30).Nullable();
            Map(x => x.State).Length(2).Nullable();
            Map(x => x.City).Length(30).Nullable();
            Map(x => x.ZipCode).Length(10).Nullable();
            //HasMany(x => x.Users);
        }
    }
}