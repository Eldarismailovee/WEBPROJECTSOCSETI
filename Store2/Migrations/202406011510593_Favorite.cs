namespace Store2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Favorite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "ProductId", "dbo.Products");
            DropIndex("dbo.Favorites", new[] { "ProductId" });
            DropTable("dbo.Favorites");
        }
    }
}
