using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Domain.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        void Delete(Guid id);

        void Update(TEntity entity);

        TEntity FindById(Guid id);

        IList<TEntity> FindAll();
    }
}