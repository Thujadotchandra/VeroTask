using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeroTest.Core.Entities;
using VeroTest.Core.Interfaces;

namespace VeroTest.Core.Services
{
    public class SongService : ISongService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SongService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Song>> GetSongsAsync()
        {
            return await _unitOfWork.Song.GetAllAsync();
        }

        public async Task<Song> GetSongByIdAsync(int Id)
        {
            var song=  await _unitOfWork.Song.GetAsync(Id);

            return song;
        }

        public async Task<bool> BuySongAsync(string emailAddress,int songId)
        {
            var sale = new Sale();

            var song = await GetSongByIdAsync(songId);

            sale.Buy(emailAddress, song);

            await _unitOfWork.Sale.AddAsync(sale);

            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
