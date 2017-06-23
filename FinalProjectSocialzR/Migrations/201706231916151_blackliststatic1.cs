namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blackliststatic1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlacklistStatics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlacklistStatics");
        }
    }
}
