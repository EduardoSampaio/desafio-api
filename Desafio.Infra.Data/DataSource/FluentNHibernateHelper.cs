using Desafio.Domain.DomainEntities;
using Desafio.Infra.Data.Map;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;
using System.Reflection;

namespace Desafio.Infra.Data.DataSource
{
    public static class FluentNHibernateHelper
    {
        public static ISession OpenSession()
        {          
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(ConfigurationManager.ConnectionStrings["desafio"].ConnectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoleMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();

        }
    }
}
