using DesafioGuitarras.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioGuitarras.Domain.Services
{
    public abstract class Service<Entity> : IService<Entity> where Entity : class
    {
        protected readonly IRepository<Entity> _repository;

        public Service(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        public virtual IQueryable<Entity> GetAll() => _repository.GetAll();

        public virtual Entity GetByPrimaryKey(object id) => _repository.GetByPrimaryKey(id);

        public virtual Entity Add(Entity entity) => _repository.Add(entity);

        public virtual IEnumerable<Entity> Add(IEnumerable<Entity> entities) => _repository.Add(entities);

        public virtual Entity Edit(Entity entity) => _repository.Edit(entity);

        public virtual IEnumerable<Entity> Edit(IEnumerable<Entity> entities) => _repository.Edit(entities);

        public virtual bool Delete(Entity entity) => _repository.Delete(entity);

        public virtual bool Delete(object id) => _repository.Delete(GetByPrimaryKey(id));

        public virtual bool Delete(IEnumerable<Entity> entities)
        {
            try
            {
                _repository.Delete(entities);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void SaveChanges() => _repository.Save();

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
