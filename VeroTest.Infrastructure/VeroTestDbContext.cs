using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using VeroTest.Core.Entities;
using VeroTest.Infrastructure.Configurations;

namespace VeroTest.Infrastructure
{
    public class VeroTestDbContext : DbContext
    {
        public DbSet<Song> Song { get; set; }

        public DbSet<Sale> Sale { get; set; }

        private readonly IConfiguration _configuration;

        public VeroTestDbContext(DbContextOptions contextOptions, IConfiguration configuration)
            : base(contextOptions)
        {
            _configuration = configuration;
        }

        public override int SaveChanges()
        {
            var timeStamp = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("LastModified").CurrentValue = timeStamp;
                }
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = timeStamp;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetConnectionString("VeroTestDatabase");
            optionsBuilder
                .EnableSensitiveDataLogging()
                .UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("autoincrement").StartsAt(1).IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new SaleConfiguration());

            modelBuilder.ApplyConfiguration(new SongConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}