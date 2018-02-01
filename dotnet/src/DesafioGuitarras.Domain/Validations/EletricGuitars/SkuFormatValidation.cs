using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Specifications.EletricGuitars;
using DomainValidation.Validation;

namespace DesafioGuitarras.Domain.Validations.EletricGuitars
{
    public class SkuFormatValidation : Validator<EletricGuitar>
    {
        public SkuFormatValidation()
        {
            Add("SkuLength", new Rule<EletricGuitar>(new SkuMaxLength(), "SkuMaxLength"));
            Add("SkuFormat", new Rule<EletricGuitar>(new SkuFormat(), "SkuFormat"));
        }
    }
}
