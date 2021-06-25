using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeroTest.Web.Models
{
    public class SongDetailsModel
    {
        public string Genres { get; set; }

        public string Artist { get; set; }

        public string Cover { get; set; }

        public string Language { get; set; }

        public string SongName { get; set; }
        public decimal Price { get; set; }

        public int Id { get; set; }
    }
}
