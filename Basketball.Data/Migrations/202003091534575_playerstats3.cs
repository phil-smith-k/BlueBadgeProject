namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class playerstats3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerStats",
                c => new
                    {
                        PlayerStatsId = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        Rebounds = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerStatsId)
                .ForeignKey("dbo.Game", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerStats", "PlayerId", "dbo.Player");
            DropForeignKey("dbo.PlayerStats", "GameId", "dbo.Game");
            DropIndex("dbo.PlayerStats", new[] { "PlayerId" });
            DropIndex("dbo.PlayerStats", new[] { "GameId" });
            DropTable("dbo.PlayerStats");
        }
    }
}
