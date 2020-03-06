namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class homeaway : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Game", "Team_TeamId", "dbo.Team");
            DropIndex("dbo.Game", new[] { "Team_TeamId" });
            DropColumn("dbo.Game", "Team_TeamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Game", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.Game", "Team_TeamId");
            AddForeignKey("dbo.Game", "Team_TeamId", "dbo.Team", "TeamId");
        }
    }
}
