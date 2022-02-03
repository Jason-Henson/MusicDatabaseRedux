using Microsoft.AspNet.Identity;
using MusicDatabaseRedux.Models.ArtistModels;
using MusicDatabaseRedux.Services.ArtistServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MusicDatabaseRedux.Controllers.Artist_Controller
{
    [Authorize]
    public class ArtistController : ApiController
    {
        private ArtistService CreateArtistService()
        {
            var artistId = Guid.Parse(User.Identity.GetUserId());
            var artistService = new ArtistService(artistId);
            return artistService;
        }

        public IHttpActionResult Get()
        {
            ArtistService artistService = CreateArtistService();
            var artists = artistService.GetArtists();
            return Ok(artists);
        }

        public IHttpActionResult Post(ArtistCreate artist)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.CreateArtist(artist)) return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            ArtistService artistService = CreateArtistService();
            var artists = artistService.GetArtistById(id);
            return Ok(artists);
        }

        public IHttpActionResult Put(ArtistEdit artist)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var artistService = CreateArtistService();

            if (!artistService.UpdateArtist(artist))
                return InternalServerError();

            return Ok("Artiest has been updated");
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateArtistService();
            if (!service.DeleteArtist(id)) return InternalServerError();
            return Ok($"The artist you selected has been removed.");
        }
    }
}