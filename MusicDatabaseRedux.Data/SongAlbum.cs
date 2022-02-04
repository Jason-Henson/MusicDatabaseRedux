using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Data
{
    public class SongAlbum
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Album))]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [Required]
        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
    }
}
