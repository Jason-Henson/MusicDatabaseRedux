using Microsoft.AspNet.Identity;
using MusicDatabaseRedux.Models.SongModels;
using MusicDatabaseRedux.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicDatabaseRedux.Controllers.Song_Controller
{
    [Authorize]
    public class SongController : ApiController
    {
        private SongService CreateSongService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var songService = new SongService();
            return songService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongs();
            return Ok(song);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            SongService songService = CreateSongService();
            var song = songService.GetSongById(id);
            return Ok(song);
        }

        [HttpPost]
        public IHttpActionResult CreateSong(SongCreate song)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var service = CreateSongService();
            if (!service.CreateSong(song)) return InternalServerError();
            return Ok("Song Added");

        }

        [HttpPut]
        public IHttpActionResult UpdateSong(SongUpdate song)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateSongService();

            if (!service.UpdateSong(song)) return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteSong(int id)
        {
            var service = CreateSongService();

            if (!service.DeleteSong(id)) return InternalServerError();

            return Ok("Song Deleted");
        }
    }
}
