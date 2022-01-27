using System;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabaseRedux.Models.AlbumModels
{
    public class AlbumCreate
    {
        [MaxLength(8000)]
        public string AlbumName { get; set; }

        [Display(Name = "Date Released")]
        public DateTimeOffset ReleaseDate { get; set; }

        [Display(Name = "Artists ID")]
        public int ArtistID { get; set; }
        public int AlbumID { get; set; }
    }
}