using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeroTest.Core.Entities;

namespace VeroTest.Web.Models
{
    public class DetailsAndBuyModel
    {
        public DetailsAndBuyModel()
        {
            SongDetails = new SongDetailsModel();
            Buy = new BuyModel();
        }

        public DetailsAndBuyModel(Song song)
        {
            SongDetails = new SongDetailsModel
            {
                SongName = song.SongName,
                Price = song.Price,
                Cover = song.Cover,
                Language = song.Language,
                Artist = song.Artist,
                Id = song.Id,
                Genres = song.Genres
            };
            Buy = new BuyModel();
        }
        public BuyModel Buy { get; }

        public SongDetailsModel SongDetails { get;  }

    }
}
