using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DesafioGuitarras.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);

        TEntity Edit(TEntity entity);
        IEnumerable<TEntity> Edit(IEnumerable<TEntity> entities);

        bool Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();
        TEntity GetByPrimaryKey(object id);

        int Save();
    }
}
