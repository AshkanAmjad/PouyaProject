namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Portal.Cities", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("Portal.Cities", "Name", c => c.String(maxLength: 50));
        }
    }
}
