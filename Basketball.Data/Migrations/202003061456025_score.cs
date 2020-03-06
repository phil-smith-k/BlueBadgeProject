namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class score : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "Team_TeamId", c => c.Int());
            CreateIndex("dbo.Game", "Team_TeamId");
            AddForeignKey("dbo.Game", "Team_TeamId", "dbo.Team", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "Team_TeamId", "dbo.Team");
            DropIndex("dbo.Game", new[] { "Team_TeamId" });
            DropColumn("dbo.Game", "Team_TeamId");
        }
    }
}
