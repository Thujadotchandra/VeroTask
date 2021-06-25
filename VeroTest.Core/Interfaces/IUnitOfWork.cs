using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeroTest.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository Song { get; }

        ISaleRepository Sale { get; }

        bool SaveChanges();
    }
}