namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blacklist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blacklists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Blacklists");
        }
    }
}
