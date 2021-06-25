using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeroTest.Core.Interfaces;

namespace VeroTest.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly VeroTestDbContext _context;

        public ISaleRepository Sale { get; private set; }

        public ISongRepository Song { get; private set; }


        public UnitOfWork(VeroTestDbContext context)
        {
            _context = context;
            Sale = new SaleRepository(_context);
            Song = new SongRepository(_context);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}