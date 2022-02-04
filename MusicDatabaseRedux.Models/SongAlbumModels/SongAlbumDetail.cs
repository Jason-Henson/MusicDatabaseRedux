using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Models.SongAlbumModels
{
    public class SongAlbumDetail
    {
        public int Id { get; set; }

        public int SongId { get; set; }

        public int AlbumId { get; set; }
    }
}
