namespace RealTalk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedpostmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "TagsText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "TagsText");
        }
    }
}
