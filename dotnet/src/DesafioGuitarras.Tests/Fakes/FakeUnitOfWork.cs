using DesafioGuitarras.Domain.Interfaces;
using System;

namespace DesafioGuitarras.Tests.Fakes
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public void BeginTransaction()
        {
            Console.WriteLine("Transaction began!");
        }

        public void Commit()
        {
            Console.WriteLine("Transaction Commited");
        }
    }
}
