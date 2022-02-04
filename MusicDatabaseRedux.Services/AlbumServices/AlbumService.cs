using MusicDatabaseRedux.Data;
using MusicDatabaseRedux.Models.AlbumModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicDatabaseRedux.Services.AlbumServices
{
    public class AlbumService
    {
        private readonly Guid _userId;

        public AlbumService(Guid userId)
        {
            _userId = userId;
        }

        //This is done for now, but changes will have to be made later
        //Album cannot exist without an ArtistID
        public bool CreateAlbum(AlbumCreate model)
        {
            var entity = new Album()
            {
                OwnerID = _userId,
                ArtistID = model.ArtistID,
                AlbumName = model.AlbumName
            };
            using (var ctx = new ApplicationDbContext())
            {
                var artist = ctx.Artists.SingleOrDefault(a => a.ArtistId == entity.ArtistID);
                if (artist is null)
                {
                    return false;
                }
                ctx.Albums.Add(entity);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<AlbumListItem> GetAlbums()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                       .Albums
                       .Select(e => new AlbumListItem
                       {
                           AlbumID = e.AlbumID,
                           ArtistName = e.Artist.Name
                       }
                      );
                return query.ToArray();
            }
        }

        public AlbumDetail GetAlbumById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                        .Albums
                        .SingleOrDefault(e => e.AlbumID == id);
                if (entity is null)
                {
                    return null;
                }
                return
                    new AlbumDetail
                    {
                        ArtistID=entity.ArtistID,
                        AlbumID = entity.AlbumID,
                        ArtistName=entity.Artist.Name,
                        AlbumName = entity.AlbumName,
                    };
            }
        }

        public bool UpdateAlbum(AlbumEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .SingleOrDefault(e => e.AlbumID == model.AlbumID);
                if (entity is null)
                {
                    return false;
                }
                entity.AlbumName = model.AlbumName;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAlbum(int albumID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Albums
                        .Single(e => e.AlbumID == albumID);

                ctx.Albums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}