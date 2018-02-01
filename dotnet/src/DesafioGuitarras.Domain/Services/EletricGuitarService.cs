using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Interfaces;
using DesafioGuitarras.Domain.Interfaces.Repositories;
using DesafioGuitarras.Domain.Interfaces.Services;
using DesafioGuitarras.Domain.Validations.EletricGuitars;

namespace DesafioGuitarras.Domain.Services
{
    public class EletricGuitarService : Service<EletricGuitar>, IEletricGuitarService
    {
        private readonly IUnitOfWork _uow;

        public EletricGuitarService(IUnitOfWork unitOfWork, IEletricGuitarRepository repository) : base(repository)
        {
            _uow = unitOfWork;
        }

        public override EletricGuitar Add(EletricGuitar entity)
        {
            entity.Validation = new FitForRegistering().Validate(entity);
            if(entity.Validation.IsValid)
            {
                _uow.BeginTransaction();
                entity = base.Add(entity);
                _uow.Commit();

                entity.Validation = new SkuFormatValidation().Validate(entity);
                _uow.BeginTransaction();
                if (!entity.Validation.IsValid)
                {
                    Delete(entity); 
                    entity = null;
                }
                else
                    entity = base.Edit(entity);
                _uow.Commit();
            }

            return entity;
        }

        public override EletricGuitar Edit(EletricGuitar entity)
        {
            entity.Validation = new FitForRegistering().Validate(entity);
            if (entity.Validation.IsValid)
            {
                entity.Validation = new SkuFormatValidation().Validate(entity);
                if (entity.Validation.IsValid)
                {
                    _uow.BeginTransaction();
                    entity = base.Edit(entity);
                    _uow.Commit();
                }
            }

            return base.Edit(entity);
        }

    }
}
