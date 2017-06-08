namespace FinalProjectSocialzR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavedSocialMessages", "MediaImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SavedSocialMessages", "MediaImage");
        }
    }
}
