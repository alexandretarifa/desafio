using DesafioGuitarras.Domain.Entities;
using DomainValidation.Interfaces.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGuitarras.Domain.Specifications.EletricGuitars
{
    public class SkuMaxLength : ISpecification<EletricGuitar>
    {
        public bool IsSatisfiedBy(EletricGuitar entity) => entity.Sku.Length < 501;
    }
}
