using DesafioGuitarras.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGuitarras.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly UmiServerContext _context;
        private bool _disposed;

        public UnitOfWork()
        {
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
