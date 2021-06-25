using System.Collections;
using System.Collections.Generic;
using VeroTest.Core.Helper;

namespace VeroTest.Core.Entities
{
    public class Song : Entity
    {
        public Song(string songName,decimal price)
        {
            SongName = songName;
            Price = price;
        }

        public string SongName { get; }

        public decimal Price { get; }

        public string Lyrics { get; private set; }

        public string Cover { get; private set; }

        public string Genres { get; private set; }

        public string Language { get; private set; }

        public string Artist { get; private set; }

        public ICollection<Sale> Sales { get; private set; }


        public void AddLyrics(string lyrics)
        {
            CheckString.IsValid(lyrics);

            Lyrics = lyrics;
        }

        public void AddCover(string cover)
        {
            CheckString.IsValid(cover);

            Cover = cover;
        }


        public void AddGenres(string genres)
        {
            CheckString.IsValid(genres);

            Genres = genres;
        }


        public void AddLanguage(string language)
        {
            CheckString.IsValid(language);

            Language = language;
        }


        public void AddArtist(string artist)
        {
            CheckString.IsValid(artist);

            Artist = artist;
        }
    }
}
