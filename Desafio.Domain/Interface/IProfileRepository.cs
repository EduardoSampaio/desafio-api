using Desafio.Domain.DomainEntities;
using System;

namespace Desafio.Domain.Interface
{
    public interface IProfileRepository : IBaseRepository<Profile>
    {
        //Profile FindProfileRoleById(Guid id);
    }
}