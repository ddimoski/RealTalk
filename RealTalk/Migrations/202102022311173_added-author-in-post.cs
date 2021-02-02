namespace RealTalk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedauthorinpost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Author");
        }
    }
}
