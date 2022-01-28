using MusicDatabaseRedux.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Models.SongModels
{
    public class SongDetails
    {
        public int Id { get; set; }
        public string SongName { get; set;}

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        public string Genre { get; set; }
    }
}
