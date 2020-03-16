namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserTeam",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Team_TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Team_TeamId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.Team_TeamId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Team_TeamId);
            
            AddColumn("dbo.ApplicationUser", "Player_PlayerId", c => c.Int());
            CreateIndex("dbo.ApplicationUser", "Player_PlayerId");
            AddForeignKey("dbo.ApplicationUser", "Player_PlayerId", "dbo.Player", "PlayerId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "Player_PlayerId", "dbo.Player");
            DropForeignKey("dbo.ApplicationUserTeam", "Team_TeamId", "dbo.Team");
            DropForeignKey("dbo.ApplicationUserTeam", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUserTeam", new[] { "Team_TeamId" });
            DropIndex("dbo.ApplicationUserTeam", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUser", new[] { "Player_PlayerId" });
            DropColumn("dbo.ApplicationUser", "Player_PlayerId");
            DropTable("dbo.ApplicationUserTeam");
        }
    }
}
