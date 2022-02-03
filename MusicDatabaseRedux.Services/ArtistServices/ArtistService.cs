using MusicDatabaseRedux.Data;
using MusicDatabaseRedux.Models.AlbumModels;
using MusicDatabaseRedux.Models.ArtistModels;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Artists
                    .Select(
                        e =>
                        new ArtistListItem
                        {
                            Name = e.Name,
                        }
                        );
                return query.ToArray();
            }
        }

        public ArtistDetail GetArtistById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Artists
                    .SingleOrDefault(e => e.ArtistId == id);
                return new ArtistDetail
                {
                    ArtistId = entity.ArtistId,
                    Name = entity.Name,
                    IsAlive = entity.IsAlive,
                    NumberOfMembers = entity.NumberOfMembers,
                };
            }
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Artists
                    .SingleOrDefault(e => e.ArtistId == model.ArtistId);
                entity.Name = model.Name;
                entity.ArtistId = model.ArtistId;
                entity.IsAlive = model.IsAllive;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Artists.Single(e => e.ArtistId == artistId);
                ctx.Artists.Remove(entity);
                return ctx.SaveChanges() > 0;
            }
        }
    }
}