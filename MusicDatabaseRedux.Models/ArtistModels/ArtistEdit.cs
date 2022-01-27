using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Models.ArtistModels
{
    public class ArtistEdit
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public bool IsAllive { get; set; }
    }
}
