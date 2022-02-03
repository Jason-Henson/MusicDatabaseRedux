namespace MusicDatabaseRedux.Models.ArtistModels
{
    public class ArtistUpdate
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public int NumberOfMembers { get; set; }
        public bool IsAlive { get; set; }
    }
}