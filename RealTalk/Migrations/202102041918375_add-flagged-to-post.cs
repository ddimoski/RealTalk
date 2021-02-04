namespace RealTalk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addflaggedtopost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Flagged", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Flagged");
        }
    }
}
