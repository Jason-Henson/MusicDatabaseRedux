using MusicDatabaseRedux.Data;
using MusicDatabaseRedux.Models.SongModels;
using System.Collections.Generic;
using System.Linq;

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
                    .Single(e => e.SongId == id);
                return
                new SongDetails
                {
                    SongId = entity.SongId,
                    SongName = entity.SongName,
                    ArtistId = entity.ArtistId,
                    ArtistName = entity.Artist.Name,
                    Genre = entity.Genre  
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
                            SongId = e.SongId,
                            SongName = e.SongName,
                            ArtistName = e.Artist.Name
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
                    .Single(e => e.SongId == model.SongId);
                entity.SongName = model.SongName;
                entity.ArtistId = model.ArtistId;
                entity.Genre = model.Genre;

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
                    .Single(e => e.SongId == Id);

                ctx.Songs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}