namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lmao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PlayerStats", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PlayerStats", "FullName");
        }
    }
}
