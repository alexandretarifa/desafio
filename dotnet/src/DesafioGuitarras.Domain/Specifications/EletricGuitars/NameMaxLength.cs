using DesafioGuitarras.Domain.Entities;
using DomainValidation.Interfaces.Specification;

namespace DesafioGuitarras.Domain.Specifications.EletricGuitars
{
    public class NameMaxLength : ISpecification<EletricGuitar>
    {
        public bool IsSatisfiedBy(EletricGuitar entity) => entity.Name.Length < 401;
    }
}
