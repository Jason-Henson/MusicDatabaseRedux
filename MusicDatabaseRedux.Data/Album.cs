using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicDatabaseRedux.Data
{
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }

        public Guid OwnerID { get; set; }

        [Required]
        public string AlbumName { get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistID { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual List<Song> Songs { get; set; } = new List<Song>();

        [Required]
        public DateTimeOffset ReleaseDate { get; set; }
    }
}