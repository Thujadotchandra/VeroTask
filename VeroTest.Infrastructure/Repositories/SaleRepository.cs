using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeroTest.Core.Entities;
using VeroTest.Core.Interfaces;

namespace VeroTest.Infrastructure.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        private readonly VeroTestDbContext _verotestDbContext;


        public SaleRepository(VeroTestDbContext context)
            : base(context)
        {
            _verotestDbContext = context;
        }
    }
}