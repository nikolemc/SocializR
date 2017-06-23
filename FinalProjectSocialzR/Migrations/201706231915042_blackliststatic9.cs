namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blackliststatic9 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.BlacklistStatics");
        }
        
        public override void Down()
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
    }
}
