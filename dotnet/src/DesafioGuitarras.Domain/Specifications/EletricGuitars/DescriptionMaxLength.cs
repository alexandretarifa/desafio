using DesafioGuitarras.Domain.Entities;
using DomainValidation.Interfaces.Specification;

namespace DesafioGuitarras.Domain.Specifications.EletricGuitars
{
    public class DescriptionMaxLength : ISpecification<EletricGuitar>
    {
        public bool IsSatisfiedBy(EletricGuitar entity) => entity.Description == null || entity.Description.Length < 801;
    }
}
