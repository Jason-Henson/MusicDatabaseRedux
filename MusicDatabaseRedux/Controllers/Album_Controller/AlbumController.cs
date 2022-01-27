using Microsoft.AspNet.Identity;
using MusicDatabaseRedux.Models.AlbumModels;
using MusicDatabaseRedux.Services.AlbumServices;
using System;
using System.Web.Http;

namespace MusicDatabaseRedux.Controllers.Album_Controller
{
    [Authorize]
    public class AlbumController : ApiController
    {
        public IHttpActionResult Get()
        {
            AlbumService albumService = CreateService();
            var albums = albumService.GetAlbums();
            return Ok(albums);
        }

        [HttpPost]
        public IHttpActionResult Post(AlbumCreate album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var albumService = CreateService();

            if (!albumService.CreateAlbum(album))
                return InternalServerError();

            return Ok("Success!");
        }

        private AlbumService CreateService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var albumService = new AlbumService(userId);
            return albumService;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            AlbumService albumService = CreateService();
            var album = albumService.GetAlbumById(id);
            return Ok(album);
        }

        public IHttpActionResult Put(AlbumEdit album)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var albumService = CreateService();

            if (!albumService.UpdateAlbum(album))
                return InternalServerError();

            return Ok(albumService);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var albumService = CreateService();

            if (!albumService.DeleteAlbum(id))
                return InternalServerError();

            return Ok(albumService);
        }
    }
}