namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgametable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        HomeTeamScore = c.Int(nullable: false),
                        AwayTeamScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GameId)
                .ForeignKey("dbo.Team", t => t.AwayTeamId, cascadeDelete: false)
                .ForeignKey("dbo.Team", t => t.HomeTeamId, cascadeDelete: false)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "HomeTeamId", "dbo.Team");
            DropForeignKey("dbo.Game", "AwayTeamId", "dbo.Team");
            DropIndex("dbo.Game", new[] { "AwayTeamId" });
            DropIndex("dbo.Game", new[] { "HomeTeamId" });
            DropTable("dbo.Game");
        }
    }
}
