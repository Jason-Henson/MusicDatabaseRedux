using System;
using System.ComponentModel.DataAnnotations;

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