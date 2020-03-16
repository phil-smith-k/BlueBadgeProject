namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorites : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUser", "Player_PlayerId", "dbo.Player");
            DropIndex("dbo.ApplicationUser", new[] { "Player_PlayerId" });
            DropColumn("dbo.ApplicationUser", "Player_PlayerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Player_PlayerId", c => c.Int());
            CreateIndex("dbo.ApplicationUser", "Player_PlayerId");
            AddForeignKey("dbo.ApplicationUser", "Player_PlayerId", "dbo.Player", "PlayerId");
        }
    }
}
