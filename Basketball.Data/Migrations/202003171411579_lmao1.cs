namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lmao1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Team", "IsFavorite");
            DropColumn("dbo.Player", "IsFavorite");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Player", "IsFavorite", c => c.Boolean(nullable: false));
            AddColumn("dbo.Team", "IsFavorite", c => c.Boolean(nullable: false));
        }
    }
}
