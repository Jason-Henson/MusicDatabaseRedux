namespace MusicDatabaseRedux.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addingArtistTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                {
                    ArtistId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    Name = c.String(nullable: false),
                    NumberOfMembers = c.Int(nullable: false),
                    IsAlive = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ArtistId);
        }

        public override void Down()
        {
            DropTable("dbo.Artist");
        }
    }
}