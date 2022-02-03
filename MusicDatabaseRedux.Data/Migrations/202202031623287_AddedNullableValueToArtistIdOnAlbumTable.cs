namespace MusicDatabaseRedux.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedNullableValueToArtistIdOnAlbumTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Album", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Album", new[] { "ArtistID" });
            AlterColumn("dbo.Album", "ArtistID", c => c.Int());
            CreateIndex("dbo.Album", "ArtistID");
            AddForeignKey("dbo.Album", "ArtistID", "dbo.Artist", "ArtistId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Album", "ArtistID", "dbo.Artist");
            DropIndex("dbo.Album", new[] { "ArtistID" });
            AlterColumn("dbo.Album", "ArtistID", c => c.Int(nullable: false));
            CreateIndex("dbo.Album", "ArtistID");
            AddForeignKey("dbo.Album", "ArtistID", "dbo.Artist", "ArtistId", cascadeDelete: true);
        }
    }
}