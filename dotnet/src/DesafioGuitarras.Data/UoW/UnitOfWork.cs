using DesafioGuitarras.Data.Context;
using DesafioGuitarras.Domain.Interfaces;
using System;

namespace DesafioGuitarras.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EletricGuitarChallengeContext _context;
        private bool _disposed;

        public UnitOfWork(EletricGuitarChallengeContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
