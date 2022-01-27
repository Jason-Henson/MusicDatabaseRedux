using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Models.SongModels
{
    public class SongCreate
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Song name must be shorter")]
        public string SongName { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public string Genre { get; set; }
    }
}
