namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropIndex("dbo.Player", new[] { "TeamId" });
            AlterColumn("dbo.Player", "TeamId", c => c.Int());
            CreateIndex("dbo.Player", "TeamId");
            AddForeignKey("dbo.Player", "TeamId", "dbo.Team", "TeamId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropIndex("dbo.Player", new[] { "TeamId" });
            AlterColumn("dbo.Player", "TeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Player", "TeamId");
            AddForeignKey("dbo.Player", "TeamId", "dbo.Team", "TeamId", cascadeDelete: true);
        }
    }
}
