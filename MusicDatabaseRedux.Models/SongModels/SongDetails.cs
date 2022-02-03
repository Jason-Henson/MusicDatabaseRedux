namespace MusicDatabaseRedux.Models.SongModels
{
    public class SongDetails
    {
        public int SongId { get; set; }
        public string SongName { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }
    }
}