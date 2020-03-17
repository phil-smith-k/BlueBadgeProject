namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwerty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Game", "HomeTeamScore");
            DropColumn("dbo.Game", "AwayTeamScore");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "AwayTeamScore", c => c.Int(nullable: false));
            AddColumn("dbo.Game", "HomeTeamScore", c => c.Int(nullable: false));
        }
    }
}
