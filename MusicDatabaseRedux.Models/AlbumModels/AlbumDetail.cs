using System;
using System.ComponentModel.DataAnnotations;

namespace MusicDatabaseRedux.Models.AlbumModels
{
    public class AlbumDetail
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}