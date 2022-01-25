using MusicDatabaseRedux.Data;
using MusicDatabaseRedux.Models.ArtistModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Services.ArtistServices
{
    public class ArtistService
    {
        private readonly Guid _userId;


        public ArtistService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateArtist(ArtistCreate model)
        {
            var entity = new Artist()
            {
                OwnerId = _userId,
                Name = model.Name,
                NumberOfMembers = model.NumberOfMembers,
                IsAlive = model.isAlive
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
