namespace MusicDatabaseRedux.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class INit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                {
                    AlbumID = c.Int(nullable: false, identity: true),
                    OwnerID = c.Guid(nullable: false),
                    AlbumName = c.String(nullable: false),
                    ArtistID = c.Int(nullable: false),
                    ReleaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Artist", t => t.ArtistID, cascadeDelete: true)
                .Index(t => t.ArtistID);

            CreateTable(
                "dbo.Song",
                c => new
                {
                    SongId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    SongName = c.String(),
                    ArtistId = c.Int(nullable: false),
                    Genre = c.String(),
                    Album_AlbumID = c.Int(),
                })
                .PrimaryKey(t => t.SongId)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Album", t => t.Album_AlbumID)
                .Index(t => t.ArtistId)
                .Index(t => t.Album_AlbumID);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Song", "Album_AlbumID", "dbo.Album");
            DropForeignKey("dbo.Song", "ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Album", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Song", new[] { "Album_AlbumID" });
            DropIndex("dbo.Song", new[] { "ArtistId" });
            DropIndex("dbo.Album", new[] { "ArtistID" });
            DropTable("dbo.Song");
            DropTable("dbo.Album");
        }
    }
}