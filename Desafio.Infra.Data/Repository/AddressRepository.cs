using Desafio.Domain.DomainEntities;
using Desafio.Domain.Interface;

namespace Desafio.Infra.Data.Repository
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
    }
}