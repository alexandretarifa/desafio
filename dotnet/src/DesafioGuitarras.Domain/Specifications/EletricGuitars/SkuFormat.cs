using DesafioGuitarras.Domain.Entities;
using DomainValidation.Interfaces.Specification;
using System.Linq;

namespace DesafioGuitarras.Domain.Specifications.EletricGuitars
{
    public class SkuFormat : ISpecification<EletricGuitar>
    {
        public bool IsSatisfiedBy(EletricGuitar entity)
        {
            if (HasId(entity) && !string.IsNullOrEmpty(entity.Sku)
                && !ContainsWhiteSpace(entity.Sku) && !HasUpperCase(entity.Sku))
            {
                return true;
            }

            return false;
        }

        private bool HasId(EletricGuitar entity) => entity.Id > 0;

        private bool HasUpperCase(string sku) => sku.Any(x => char.IsUpper(x));

        private bool ContainsWhiteSpace(string sku) => sku.Contains(' ');
    }
}
