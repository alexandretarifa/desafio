using DesafioGuitarras.Domain.Entities;
using DomainValidation.Interfaces.Specification;

namespace DesafioGuitarras.Domain.Specifications.EletricGuitars
{
    public class SkuMaxLength : ISpecification<EletricGuitar>
    {
        public bool IsSatisfiedBy(EletricGuitar entity) => entity.Sku.Length < 501;
    }
}
