namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Portal.Cities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Portal.Dealers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        DealerNo = c.Int(nullable: false),
                        Name = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        CityId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Portal.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.DealerNo)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Portal.Dealers", "CityId", "Portal.Cities");
            DropIndex("Portal.Dealers", new[] { "CityId" });
            DropIndex("Portal.Dealers", new[] { "DealerNo" });
            DropTable("Portal.Dealers");
            DropTable("Portal.Cities");
        }
    }
}
