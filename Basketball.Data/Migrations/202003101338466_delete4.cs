namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Game", "AwayTeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "HomeTeamId", "dbo.Team");
            DropIndex("dbo.Game", new[] { "HomeTeamId" });
            DropIndex("dbo.Game", new[] { "AwayTeamId" });
            AlterColumn("dbo.Game", "HomeTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Game", "AwayTeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Game", "HomeTeamId");
            CreateIndex("dbo.Game", "AwayTeamId");
            AddForeignKey("dbo.Game", "AwayTeamId", "dbo.Team", "TeamId", cascadeDelete: false);
            AddForeignKey("dbo.Game", "HomeTeamId", "dbo.Team", "TeamId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "HomeTeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "AwayTeamId", "dbo.Team");
            DropIndex("dbo.Game", new[] { "AwayTeamId" });
            DropIndex("dbo.Game", new[] { "HomeTeamId" });
            AlterColumn("dbo.Game", "AwayTeamId", c => c.Int());
            AlterColumn("dbo.Game", "HomeTeamId", c => c.Int());
            CreateIndex("dbo.Game", "AwayTeamId");
            CreateIndex("dbo.Game", "HomeTeamId");
            AddForeignKey("dbo.Game", "HomeTeamId", "dbo.Team", "TeamId");
            AddForeignKey("dbo.Game", "AwayTeamId", "dbo.Team", "TeamId");
        }
    }
}
