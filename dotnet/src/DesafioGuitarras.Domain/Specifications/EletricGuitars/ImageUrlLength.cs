using DesafioGuitarras.Domain.Entities;
using DomainValidation.Interfaces.Specification;

namespace DesafioGuitarras.Domain.Specifications.EletricGuitars
{
    public class ImageUrlLength : ISpecification<EletricGuitar>
    {
        public bool IsSatisfiedBy(EletricGuitar entity) => entity.ImageUrl.Length < 8001;
    }
}
