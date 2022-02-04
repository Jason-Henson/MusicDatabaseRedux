using MusicDatabaseRedux.Data;
using MusicDatabaseRedux.Models.SongAlbumModels;
using MusicDatabaseRedux.Services.SongAlbumServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MusicDatabaseRedux.Controllers.SongAlbum_Controller
{
    public class SongAlbumController : ApiController
    {
        public ApplicationDbContext _ctx = new ApplicationDbContext();

        public IHttpActionResult GetSongAlbums()
        {
            SongAlbumService songAlbumService = new SongAlbumService();

            var songalbum = songAlbumService.GetSongAlbum();

            return Ok(songalbum);
        }

        public IHttpActionResult PostSongAlbum(SongAlbumCreate SongAlbum)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSongAlbumService();

            if(!service.CreateSongAlbum(SongAlbum))
                return InternalServerError();

            return Ok();
        }

        private SongAlbumService CreateSongAlbumService()
        {
            var svc = new SongAlbumService();
            return svc; 
        }

        public IHttpActionResult Get(int id)
        {
            SongAlbumService songalbumService = CreateSongAlbumService();

            var songalbum = songalbumService.GetById(id);

            return Ok(songalbum);
        }

        public IHttpActionResult Delete (int id)
        {
            var service = CreateSongAlbumService();

            if(!service.DeleteSongAlbum(id))
                return InternalServerError();

            return Ok();
        }
    }
}
