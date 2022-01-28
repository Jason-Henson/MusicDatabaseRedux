namespace MusicDatabaseRedux.Models.AlbumModels
{
    public class AlbumEdit
    {
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }

        public override string ToString() => AlbumName;
    }
}