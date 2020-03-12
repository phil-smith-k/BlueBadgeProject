namespace Basketball.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lmfao : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PlayerStats", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlayerStats", "FullName", c => c.String());
        }
    }
}
