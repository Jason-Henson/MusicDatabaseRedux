using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDatabaseRedux.Data
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        public Guid OwnerId { get; set; }
        public string SongName { get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public string Genre { get; set; }
    }
}