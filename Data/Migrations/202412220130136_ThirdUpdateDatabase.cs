namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdUpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Portal.Dealers", "DealerNo");
        }
        
        public override void Down()
        {
            DropIndex("Portal.Dealers", new[] { "DealerNo" });
        }
    }
}
