namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlayerFavorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserPlayer",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Player_PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Player_PlayerId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Player", t => t.Player_PlayerId, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Player_PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserPlayer", "Player_PlayerId", "dbo.Player");
            DropForeignKey("dbo.ApplicationUserPlayer", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUserPlayer", new[] { "Player_PlayerId" });
            DropIndex("dbo.ApplicationUserPlayer", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserPlayer");
        }
    }
}
