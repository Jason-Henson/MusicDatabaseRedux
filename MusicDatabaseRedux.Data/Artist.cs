using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabaseRedux.Data
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 25, ErrorMessage = "Please choose a number between 1 and 25")]
        public int NumberOfMembers { get; set; }
        [Required]
        public bool IsAlive { get; set; }
    }
}
