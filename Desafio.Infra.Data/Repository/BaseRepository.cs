using Desafio.Domain.Interface;
using Desafio.Infra.Data.DataSource;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Infra.Data.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public virtual void Delete(Guid id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(session.Load<TEntity>(id));
                    transaction.Commit();
                }
            }
        }

        public virtual IList<TEntity> FindAll()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<TEntity>().ToList();
            }
        }

        public virtual TEntity FindById(Guid id)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return session.Get<TEntity>(id);
            }
        }

        public virtual void Save(TEntity entity)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }

            }
        }

        public virtual void Update(TEntity entity)
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(entity);
                    transaction.Commit();
                }
            }
        }
    }
}