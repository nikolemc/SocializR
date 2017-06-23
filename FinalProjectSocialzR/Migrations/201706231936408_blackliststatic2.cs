namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blackliststatic2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blacklists", "CompanyId", c => c.Int());
            CreateIndex("dbo.Blacklists", "CompanyId");
            AddForeignKey("dbo.Blacklists", "CompanyId", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blacklists", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Blacklists", new[] { "CompanyId" });
            DropColumn("dbo.Blacklists", "CompanyId");
        }
    }
}
