namespace MusicDatabaseRedux.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePlaylistClass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Song_Album", "AlbumId", "dbo.Album");
            DropForeignKey("dbo.Song_Album", "SongId", "dbo.Song");
            DropIndex("dbo.Song_Album", new[] { "SongId" });
            DropIndex("dbo.Song_Album", new[] { "AlbumId" });
            AddColumn("dbo.Artist", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Song", "OwnerId", c => c.Guid(nullable: false));
            DropTable("dbo.Song_Album");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Song_Album",
                c => new
                    {
                        Song_AlbumId = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Song_AlbumId);
            
            DropColumn("dbo.Song", "OwnerId");
            DropColumn("dbo.Artist", "OwnerId");
            CreateIndex("dbo.Song_Album", "AlbumId");
            CreateIndex("dbo.Song_Album", "SongId");
            AddForeignKey("dbo.Song_Album", "SongId", "dbo.Song", "SongId", cascadeDelete: true);
            AddForeignKey("dbo.Song_Album", "AlbumId", "dbo.Album", "AlbumID", cascadeDelete: true);
        }
    }
}
