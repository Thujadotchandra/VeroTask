using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using VeroTest.Core.Entities;
using VeroTest.Core.Interfaces;
using VeroTest.Web.Models;

namespace VeroTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISongService _songService;
        const string SessionSongs = "Songs";

        public HomeController(ILogger<HomeController> logger, ISongService songService)
        {
            _logger = logger;
            _songService = songService;
        }

        public IActionResult Index()
        {
            var songs = HttpContext.Session.Get<List<SongModel>>(SessionSongs);
            if (songs == null)
            {
                return View();
            }
            return View(songs);
        }

        [ActionName("musiclist")]
        public async Task<IActionResult> MusicList()
        {
            var session = HttpContext.Session.Get<List<SongModel>>(SessionSongs);
            var songModel = new SongModel();

            if (session == null)
            {
                var songs = await _songService.GetSongsAsync();

                songModel.GetSongModel(songs);

                HttpContext.Session.Set(SessionSongs, songModel.ListSongModel);

            }
            else
            {
                songModel.ListSongModel = HttpContext.Session.Get<List<SongModel>>(SessionSongs);
            }

            return View(songModel.ListSongModel);
        }

        [ActionName("viewdetails")]
        public async Task<IActionResult> ViewDetails(int id)
        {
            var song = await _songService.GetSongByIdAsync(id);

            var listSongModel = UpdateSession(id, isViewed: true);

            var detail = new DetailsAndBuyModel(song);

            return View(detail);
        }

        [ActionName("buy")]
        public async Task<IActionResult> Buy(DetailsAndBuyModel model)
        {
            var song = await _songService.BuySongAsync(model.Buy.EmailAddress, model.Buy.SongId);

            var listSongModel = UpdateSession(model.Buy.SongId, isPurchased: true);

            return View("Index", listSongModel);
        }

        private List<SongModel> UpdateSession(int songId, bool isPurchased = false, bool isViewed = false)
        {
            var listSongModel = HttpContext.Session.Get<List<SongModel>>(SessionSongs);

            var song = listSongModel.Find(a => a.Id == songId);

            if (isPurchased)
            {
                song.IsPurchased = true;

                foreach (var x in listSongModel)
                {
                    x.LastViewed = false;
                    x.IsViewed = false;
                }
            }

            else if (isViewed)
            {
                foreach (var x in listSongModel)
                {
                    x.LastViewed = false;
                    x.IsPurchased = false;
                }
                song.IsViewed = true;
                song.LastViewed = true;
            }
            HttpContext.Session.Set(SessionSongs, listSongModel);
            return listSongModel;
        }
    }
}
