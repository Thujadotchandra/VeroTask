using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeroTest.Core.Entities;

namespace VeroTest.Infrastructure.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> SongConfiguration)
        {
            SongConfiguration.ToTable("Song");

            SongConfiguration
                .HasKey("Id");

            SongConfiguration
                .Property(b => b.Id)
                .UseHiLo("autoincrement");

            SongConfiguration
                .Property(b => b.SongName)
                .HasMaxLength(500);

            SongConfiguration
                .Property(b => b.Genres)
                .HasMaxLength(500);

            SongConfiguration
                .Property(b => b.Artist)
                .HasMaxLength(100);

            SongConfiguration
                .Property(b => b.Cover)
                .HasMaxLength(500);

            SongConfiguration
                .Property(b => b.Language)
                .HasMaxLength(200);

            SongConfiguration
                .Property(b => b.Lyrics)
                .HasMaxLength(4000);

            SongConfiguration
                .Property(b => b.Price)
                .HasPrecision(18, 2);

            SongConfiguration
                .Property<DateTime>("Created");

            SongConfiguration
                .Property<DateTime?>("LastModified");

        }
    }
}
