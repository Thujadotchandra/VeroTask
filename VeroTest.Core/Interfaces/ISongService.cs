using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeroTest.Core.Entities;

namespace VeroTest.Core.Interfaces
{
    public interface ISongService
    {
        Task<IEnumerable<Song>> GetSongsAsync();

        Task<Song> GetSongByIdAsync(int Id);
        Task<bool> BuySongAsync(string emailAddress,int songId);
    }
}
