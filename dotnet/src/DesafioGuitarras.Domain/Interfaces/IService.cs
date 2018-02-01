using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioGuitarras.Domain.Interfaces
{
    public interface IService<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetByPrimaryKey(object id);

        TEntity Add(TEntity entity);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> entities);

        TEntity Edit(TEntity entity);
        IEnumerable<TEntity> Edit(IEnumerable<TEntity> entities);

        bool Delete(TEntity entity);
        bool Delete(IEnumerable<TEntity> entities);
        bool Delete(object primaryKey);
        
        void SaveChanges();
    }
}
