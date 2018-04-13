using Desafio.Domain.DomainEntities;
using Desafio.Domain.Interface;
using System;
using System.Collections.Generic;

namespace Desafio.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool HasEmail(string email);

        bool HasLogin(string login);

        User Authenticate(string login, string password);

        IList<User> FindAllUserProfile();

        User FindUserAddressById(Guid id);
    }
}