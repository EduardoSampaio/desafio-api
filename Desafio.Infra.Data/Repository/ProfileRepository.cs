using Desafio.Domain.DomainEntities;
using Desafio.Domain.Interface;
using Desafio.Infra.Data.DataSource;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace Desafio.Infra.Data.Repository
{
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public string[] FindAllProfileRole()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var profiles = session.Query<Profile>().Select(x => x.Name).ToArray();
                var roles = session.Query<Role>().Select(x => x.Name).ToArray();
                var concat = profiles.Concat(roles);
                return concat.ToArray(); ;
            }
        }

        public string[] FindProfileRoleById(Guid profileId)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                var roles = (from pr in session.Query<ProfileRole>()
                             join r in session.Query<Role>() on pr.RoleId equals r.Id
                             where pr.ProfileId.Equals(profileId)
                             select r.Name).ToArray();

                var profiles = (from pr in session.Query<ProfileRole>()
                                join p in session.Query<Profile>() on pr.ProfileId equals p.Id
                                where pr.ProfileId.Equals(profileId)
                                select p.Name).ToArray().Distinct();
                return profiles.Concat(roles).ToArray();
            }
        }
    }
}