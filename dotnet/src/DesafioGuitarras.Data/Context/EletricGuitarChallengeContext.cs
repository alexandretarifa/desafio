using DesafioGuitarras.Data.Mapping;
using DesafioGuitarras.Domain.Entities;
using System.Data.Entity;

namespace DesafioGuitarras.Data.Context
{
    public class EletricGuitarChallengeContext : DbContext
    {
        public EletricGuitarChallengeContext() : base(nameof(EletricGuitarChallengeContext))
        {
        }

        public DbSet<EletricGuitar> EletricGuitar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EletricGuitarMap());
        }
    }
}
