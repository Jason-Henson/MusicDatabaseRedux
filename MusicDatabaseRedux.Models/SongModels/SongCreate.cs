using System.ComponentModel.DataAnnotations;

namespace MusicDatabaseRedux.Models.SongModels
{
    public class SongCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Song name must be shorter")]
        public string SongName { get; set; }

        public int ArtistId { get; set; }

        public string Genre { get; set; }
    }
}