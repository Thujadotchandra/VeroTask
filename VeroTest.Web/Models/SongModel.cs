using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeroTest.Core.Entities;
using VeroTest.Core.Interfaces;

namespace VeroTest.Web.Models
{
    public class SongModel
    {
        public SongModel()
        {
            ListSongModel = new List<SongModel>();
        }

        public void GetSongModel(IEnumerable<Song> songs)
        {
            ListSongModel = new List<SongModel>();

            foreach (var x in songs)
            {
                var song = new SongModel
                {
                    SongName = x.SongName,
                    Id = x.Id
                };
                ListSongModel.Add(song);
            }
        }

        public string SongName { get; set; }

        public int Id { get; set; }

        public bool LastViewed { get; set; }

        public bool IsViewed { get; set; }

        public bool IsPurchased { get; set; }

        public List<SongModel> ListSongModel { get; set; }
    }
}
