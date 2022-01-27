using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Data
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public Guid OwnerId { get; set; }
        public string SongName { get; set; }
        public int ArtistId { get; set; }
        public string Genre { get; set; }
    }
}
