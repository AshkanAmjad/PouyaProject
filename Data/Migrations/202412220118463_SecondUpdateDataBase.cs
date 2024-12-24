namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondUpdateDataBase : DbMigration
    {
        public override void Up()
        {
            DropIndex("Portal.Dealers", new[] { "DealerNo" });
        }
        
        public override void Down()
        {
            CreateIndex("Portal.Dealers", "DealerNo");
        }
    }
}
