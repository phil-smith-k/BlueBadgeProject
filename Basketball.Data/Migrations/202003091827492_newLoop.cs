namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newLoop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerStats", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.PlayerStats", "Team_TeamId");
            AddForeignKey("dbo.PlayerStats", "Team_TeamId", "dbo.Team", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerStats", "Team_TeamId", "dbo.Team");
            DropIndex("dbo.PlayerStats", new[] { "Team_TeamId" });
            DropColumn("dbo.PlayerStats", "Team_TeamId");
        }
    }
}
