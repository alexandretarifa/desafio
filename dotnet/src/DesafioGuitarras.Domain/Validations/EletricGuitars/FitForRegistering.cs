using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Specifications.EletricGuitars;
using DomainValidation.Validation;

namespace DesafioGuitarras.Domain.Validations.EletricGuitars
{
    public class FitForRegistering : Validator<EletricGuitar>
    {
        public FitForRegistering()
        {
            Add("NameLength", new Rule<EletricGuitar>(new NameMaxLength(), "NameMaxLength"));
            Add("DescriptionLength", new Rule<EletricGuitar>(new DescriptionMaxLength(), "DescriptionMaxLength"));
        }
    }
}
