namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class j1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "IsFavorite", c => c.Boolean(nullable: false));
            AddColumn("dbo.Player", "IsFavorite", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "IsFavorite");
            DropColumn("dbo.Team", "IsFavorite");
        }
    }
}
