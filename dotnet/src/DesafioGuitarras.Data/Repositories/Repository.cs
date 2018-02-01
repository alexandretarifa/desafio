using DesafioGuitarras.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DesafioGuitarras.Data.Repositories
{
    public abstract class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected DbContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(DbContext context)
        {
            this.Db = context;
            this.DbSet = this.Db.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Added;
            return entity;
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> entities)
        {
            if (entities != null && entities.Count() > 0)
            {
                IEnumerable<TEntity> listEntities = new List<TEntity>();

                foreach (TEntity item in entities)
                {
                    Db.Set<TEntity>().Add(item);
                    listEntities.ToList().Add(item);
                }

                return listEntities;
            }
            return null;
        }

        public virtual TEntity Edit(TEntity entity)
        {
            if (entity != null)
            {
                Db.Entry(entity).State = EntityState.Modified;
                return entity;
            }

            return null;
        }

        public virtual IEnumerable<TEntity> Edit(IEnumerable<TEntity> entities)
        {
            if (entities != null && entities.Count() > 0)
            {
                IEnumerable<TEntity> listEntities = new List<TEntity>();

                foreach (TEntity item in entities)
                {
                    Db.Entry(item).State = EntityState.Modified;
                    listEntities.ToList().Add(item);
                }

                return listEntities;
            }

            return null;
        }

        public virtual bool Delete(TEntity entity)
        {
            if (entity != null)
            {
                var entry = Db.Entry(entity);
                if (entry.State == EntityState.Detached)
                    DbSet.Attach(entity);

                Db.Set<TEntity>().Remove(entity);
                return true;
            }

            return false;
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            if (entities != null && entities.Count() > 0)
            {
                foreach (TEntity item in entities)
                {
                    var entry = Db.Entry(item);
                    if (entry.State == EntityState.Detached)
                        DbSet.Attach(item);
                    Db.Set<TEntity>().Remove(item);
                }
            }
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate) => Db.Set<TEntity>().AsNoTracking().Where(predicate).SingleOrDefault();

        public virtual IQueryable<TEntity> GetAll() => Db.Set<TEntity>();

        public virtual TEntity GetByPrimaryKey(object id) => Db.Set<TEntity>().Find(id);

        public int Save() => Db.SaveChanges();

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
