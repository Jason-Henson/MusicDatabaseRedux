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
                           ArtistName = ctx.Albums.Find(e.AlbumID).Artist.Name
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
                        .Single(e => e.AlbumID == id);
                return
                    new AlbumDetail
                    {
                        AlbumID = entity.AlbumID,
                        AlbumName = entity.AlbumName
                    };
            }
        }
    }
}