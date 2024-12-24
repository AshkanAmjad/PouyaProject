namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForthUpdateDataBase : DbMigration
    {
        public override void Up()
        {
            DropIndex("Portal.Dealers", new[] { "DealerNo" });
            CreateIndex("Portal.Dealers", "DealerNo", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("Portal.Dealers", new[] { "DealerNo" });
            CreateIndex("Portal.Dealers", "DealerNo");
        }
    }
}
