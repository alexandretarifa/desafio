using DesafioGuitarras.Data.Context;
using DesafioGuitarras.Data.Repositories;
using DesafioGuitarras.Data.UoW;
using DesafioGuitarras.Domain.Interfaces;
using DesafioGuitarras.Domain.Interfaces.Repositories;
using DesafioGuitarras.Domain.Interfaces.Services;
using DesafioGuitarras.Domain.Services;
using SimpleInjector;

namespace DesafioGuitarras.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterContainer(Container container)
        {
            container.Register<IEletricGuitarRepository, EletricGuitarRepository>(Lifestyle.Scoped);
            container.Register<IEletricGuitarService, EletricGuitarService>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<EletricGuitarChallengeContext>(Lifestyle.Scoped);
        }
    }
}
