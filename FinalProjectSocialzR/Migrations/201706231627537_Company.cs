namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Company : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Playlists", "CompanyId", c => c.Int());
            AddColumn("dbo.SavedSocialMessages", "CompanyId", c => c.Int());
            CreateIndex("dbo.Playlists", "CompanyId");
            CreateIndex("dbo.SavedSocialMessages", "CompanyId");
            AddForeignKey("dbo.Playlists", "CompanyId", "dbo.Companies", "Id");
            AddForeignKey("dbo.SavedSocialMessages", "CompanyId", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavedSocialMessages", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Playlists", "CompanyId", "dbo.Companies");
            DropIndex("dbo.SavedSocialMessages", new[] { "CompanyId" });
            DropIndex("dbo.Playlists", new[] { "CompanyId" });
            DropColumn("dbo.SavedSocialMessages", "CompanyId");
            DropColumn("dbo.Playlists", "CompanyId");
            DropTable("dbo.Companies");
        }
    }
}
