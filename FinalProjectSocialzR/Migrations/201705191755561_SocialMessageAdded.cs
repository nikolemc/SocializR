namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SocialMessageAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SavedSocialMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                        ImageUrl = c.String(),
                        ScreenName = c.String(),
                        Text = c.String(),
                        OriginalText = c.String(),
                        PostTimeStamp = c.DateTime(nullable: false),
                        PostContentUrl = c.String(),
                        UserName = c.String(),
                        Location = c.String(),
                        IsRetweeted = c.Boolean(nullable: false),
                        Language = c.String(),
                        Media = c.String(),
                        AddedToPlaylistTimeStamp = c.DateTime(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SavedSocialMessages");
        }
    }
}
