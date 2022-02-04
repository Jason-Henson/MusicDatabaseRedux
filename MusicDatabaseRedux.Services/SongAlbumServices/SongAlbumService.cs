using MusicDatabaseRedux.Data;
using MusicDatabaseRedux.Models.SongAlbumModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Services.SongAlbumServices
{
    public class SongAlbumService
    {
        public bool CreateSongAlbum(SongAlbumCreate model)
        {
            var entity =
                new SongAlbum()
                {
                    
                    SongId = model.SongId,
                    AlbumId = model.AlbumId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.SongAlbums.Add(entity);
                return ctx.SaveChanges() == 1;
            }
           
        }


        public IEnumerable<SongAlbumListItem> GetSongAlbum()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .SongAlbums
                    .Select
                    (
                        e => new SongAlbumListItem
                        {
                            Id = e.Id,
                            SongId = e.SongId,
                            AlbumId = e.AlbumId
                        }

                    );

                return query.ToList();
            }
        }
        public SongAlbumDetail GetById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .SongAlbums.SingleOrDefault(s => s.Id == id);
                if (entity == null)
                    return null;    

                    return
                        new SongAlbumDetail
                        {
                            Id = entity.Id,
                            SongId = entity.SongId,
                            AlbumId = entity.AlbumId
                        };
            }
        }

        public bool DeleteSongAlbum(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                   ctx
                   .SongAlbums.SingleOrDefault(s => s.Id == id);

                ctx.SongAlbums.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}


