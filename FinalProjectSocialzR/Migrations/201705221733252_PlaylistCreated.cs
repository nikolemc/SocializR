namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlaylistCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Playlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaylistName = c.String(),
                        LastModifiedTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SavedSocialMessages", "PlaylistId", c => c.Int());
            CreateIndex("dbo.SavedSocialMessages", "PlaylistId");
            AddForeignKey("dbo.SavedSocialMessages", "PlaylistId", "dbo.Playlists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavedSocialMessages", "PlaylistId", "dbo.Playlists");
            DropIndex("dbo.SavedSocialMessages", new[] { "PlaylistId" });
            DropColumn("dbo.SavedSocialMessages", "PlaylistId");
            DropTable("dbo.Playlists");
        }
    }
}
