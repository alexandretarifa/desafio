using DesafioGuitarras.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGuitarras.Data.Context
{
    public class EletricGuitarChallengeContext : DbContext
    {
        public EletricGuitarChallengeContext() :
           base(nameof(EletricGuitarChallengeContext))
        {
        }

        public DbSet<EletricGuitar> EletricGuitar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
