namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lmao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserPlayer", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserPlayer", "Player_PlayerId", "dbo.Player");
            DropForeignKey("dbo.ApplicationUserTeam", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.ApplicationUserTeam", "Team_TeamId", "dbo.Team");
            DropForeignKey("dbo.PlayerStats", "Team_TeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "AwayTeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "HomeTeamId", "dbo.Team");
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropIndex("dbo.Game", new[] { "HomeTeamId" });
            DropIndex("dbo.Game", new[] { "AwayTeamId" });
            DropIndex("dbo.PlayerStats", new[] { "Team_TeamId" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropIndex("dbo.ApplicationUserPlayer", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserPlayer", new[] { "Player_PlayerId" });
            DropIndex("dbo.ApplicationUserTeam", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserTeam", new[] { "Team_TeamId" });
            AlterColumn("dbo.Game", "HomeTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Game", "AwayTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Player", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Game", "HomeTeamId");
            CreateIndex("dbo.Game", "AwayTeamId");
            CreateIndex("dbo.Player", "TeamId");
            AddForeignKey("dbo.Game", "AwayTeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.Game", "HomeTeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.Player", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            DropColumn("dbo.Team", "IsFavorite");
            DropColumn("dbo.PlayerStats", "Team_TeamId");
            DropColumn("dbo.Player", "IsFavorite");
            DropTable("dbo.ApplicationUserPlayer");
            DropTable("dbo.ApplicationUserTeam");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserTeam",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Team_TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Team_TeamId });
            
            CreateTable(
                "dbo.ApplicationUserPlayer",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Player_PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Player_PlayerId });
            
            AddColumn("dbo.Player", "IsFavorite", c => c.Boolean(nullable: false));
            AddColumn("dbo.PlayerStats", "Team_TeamId", c => c.Int());
            AddColumn("dbo.Team", "IsFavorite", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "HomeTeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "AwayTeamId", "dbo.Team");
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropIndex("dbo.Game", new[] { "AwayTeamId" });
            DropIndex("dbo.Game", new[] { "HomeTeamId" });
            AlterColumn("dbo.Player", "TeamId", c => c.Int());
            AlterColumn("dbo.Game", "AwayTeamId", c => c.Int());
            AlterColumn("dbo.Game", "HomeTeamId", c => c.Int());
            CreateIndex("dbo.ApplicationUserTeam", "Team_TeamId");
            CreateIndex("dbo.ApplicationUserTeam", "ApplicationUser_Id");
            CreateIndex("dbo.ApplicationUserPlayer", "Player_PlayerId");
            CreateIndex("dbo.ApplicationUserPlayer", "ApplicationUser_Id");
            CreateIndex("dbo.Player", "TeamId");
            CreateIndex("dbo.PlayerStats", "Team_TeamId");
            CreateIndex("dbo.Game", "AwayTeamId");
            CreateIndex("dbo.Game", "HomeTeamId");
            AddForeignKey("dbo.Player", "TeamId", "dbo.Team", "TeamId");
            AddForeignKey("dbo.Game", "HomeTeamId", "dbo.Team", "TeamId");
            AddForeignKey("dbo.Game", "AwayTeamId", "dbo.Team", "TeamId");
            AddForeignKey("dbo.PlayerStats", "Team_TeamId", "dbo.Team", "TeamId");
            AddForeignKey("dbo.ApplicationUserTeam", "Team_TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserTeam", "ApplicationUser_Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserPlayer", "Player_PlayerId", "dbo.Player", "PlayerId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserPlayer", "ApplicationUser_Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}
