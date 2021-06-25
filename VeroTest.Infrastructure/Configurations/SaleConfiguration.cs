using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using VeroTest.Core.Entities;

namespace VeroTest.Infrastructure.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> SaleConfiguration)
        {
            SaleConfiguration.ToTable("Sale");

            SaleConfiguration
                .HasKey("Id");

            SaleConfiguration
                .Property(b => b.Id)
                .UseHiLo("autoincrement");

            SaleConfiguration
                .Property(d => d.EmailAddress)
                .HasMaxLength(400)
                .IsRequired();

            SaleConfiguration
                .Property<int>("SongId");

            SaleConfiguration
                .HasOne(a => a.Song)
                .WithMany(a => a.Sales);

            SaleConfiguration
                .Property<DateTime?>("LastModified");

            SaleConfiguration
                .Property<DateTime>("Created");
            }
    }
}
