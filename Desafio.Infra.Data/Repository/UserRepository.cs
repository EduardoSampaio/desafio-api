using Desafio.Domain.DomainEntities;
using Desafio.Domain.Repository;
using Desafio.Infra.Data.DataSource;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public User Authenticate(string login, string password)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<User>().FirstOrDefault(x => x.Login.Equals(login) && x.Password.Equals(password));
            }
        }

        public bool HasEmail(string email)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return !session.Query<User>().Where(x => x.Email.Equals(email)).Any();
            }
        }

        public bool HasLogin(string login)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return !session.Query<User>().Where(x => x.Login.Equals(login)).Any();
            }
        }


        public User FindUserAddressById(Guid id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {

                //var u = session.Query<User>().FirstOrDefault(x=>x.Id.Equals(id));
                //var a = session.Query<Address>().FirstOrDefault(x=>x.Id.Equals(u.AddressId));

                //var query = from user in u
                //            join address in a on
                //            user.AddressId equals address.Id
                //            into userAdress
                //            from ua in userAdress.DefaultIfEmpty()
                //            where user.Id.Equals(id)
                //            select new User
                //            {
                //                Id = user.Id,
                //                FirstName = user.FirstName,
                //                LastName = user.LastName,
                //                Age = user.Age,
                //                CellPhone = user.CellPhone,
                //                Phone = user.Phone,
                //                Cpf = user.Cpf,
                //                Email = user.Email,
                //                Login = user.Login,
                //                IsActive = user.IsActive,
                //                Nationality = user.Nationality,
                //                ProfileId = user.ProfileId,
                //                CreatedAt = user.CreatedAt,
                //                CreatedBy = user.CreatedBy,
                //                DeletedAt = user.DeletedAt,
                //                DeletedBy = user.DeletedBy,
                //                Address = ua ?? null
                //            };


                return null;
            }
        }

        public IList<User> FindAllUserProfile()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var query = (from user in session.Query<User>()
                             join profile in session.Query<Profile>()
                             on user.ProfileId equals profile.Id
                             select new User
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Age = user.Age,
                                 CellPhone = user.CellPhone,
                                 Phone = user.Phone,
                                 Cpf = user.Cpf,
                                 Email = user.Email,
                                 Login = user.Login,
                                 IsActive = user.IsActive,
                                 Nationality = user.Nationality,
                                 ProfileId = user.ProfileId,
                                 CreatedAt = user.CreatedAt,
                                 CreatedBy = user.CreatedBy,
                                 DeletedAt = user.DeletedAt,
                                 DeletedBy = user.DeletedBy,
                                 Profile = new Profile
                                 {
                                     Id = profile.Id,
                                     Name = profile.Name
                                 }


                             }).ToList();

                return query;
            }
        }
    }
}