using MusicDatabaseRedux.Data;
using MusicDatabaseRedux.Models.SongModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Services
{
    public class SongService
    {
        public bool CreateSong(SongCreate model)
        {
            var entity =
                new Song()
                {
                    SongName = model.SongName,
                    ArtistId = model.ArtistId,
                    Genre = model.Genre
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Songs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public SongDetails GetSongById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.Id == id);
                return
                new SongDetails
                {
                    Id = entity.Id,
                    SongName = entity.SongName,
                    ArtistId = entity.ArtistId,
                };
            }
        }
        public IEnumerable<SongListItem> GetSongs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Songs
                        .Select(
                        e =>
                        new SongListItem
                        {
                            Id = e.Id,
                            SongName = e.SongName,

                        }
            );


                return query.ToArray();
            }

        }
        public bool UpdateSong(SongUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Songs
                    .Single(e => e.Id == model.Id);
                entity.SongName = model.SongName;
                entity.ArtistId = model.ArtistId;

                return ctx.SaveChanges() == 1;
            }

        }
        public bool DeleteSong(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Songs
                    .Single(e => e.Id == Id);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
