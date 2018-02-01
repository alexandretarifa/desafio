using DesafioGuitarras.Data.Context;
using DesafioGuitarras.Domain.Entities;
using DesafioGuitarras.Domain.Interfaces.Repositories;

namespace DesafioGuitarras.Data.Repositories
{
    public class EletricGuitarRepository : Repository<EletricGuitar>, IEletricGuitarRepository
    {
        public EletricGuitarRepository(EletricGuitarChallengeContext context) : base(context)
        {

        }
    }
}
